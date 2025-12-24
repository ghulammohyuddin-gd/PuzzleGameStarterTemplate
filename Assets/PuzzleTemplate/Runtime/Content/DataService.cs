using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace PuzzleTemplate.Runtime
{
    public sealed class DataService : IDataService, IContentLoader
    {
        private readonly IDictionary<string, IData> _dataRegistry = new Dictionary<string, IData>();

        public UniTask LoadContentAsync(IEnumerable<string> tags, CancellationToken cToken = default)
        {
            ValidateTags(tags);
            return ProcessContentAsync(tags, new LoadStrategy(_dataRegistry), cToken);
        }


        public UniTask UnloadContentAsync(IEnumerable<string> tags, CancellationToken cToken = default)
        {
            ValidateTags(tags);
            return ProcessContentAsync(tags, new UnloadStrategy(_dataRegistry), cToken);
        }

        public T GetData<T>(string key)
            where T : IData
        {
            if (_dataRegistry.TryGetValue(key, out var asset) && asset is T typedAsset)
            {
                return typedAsset;
            }

            throw new KeyNotFoundException($"DataAsset with Id '{key}' not found.");
        }

        public IEnumerable<T> GetData<T>(IEnumerable<string> keys)
            where T : IData
            => keys == null ? Enumerable.Empty<T>() : keys.Select(GetData<T>);

        public IEnumerable<T> GetAllData<T>()
            where T : IData
            => _dataRegistry.Values.OfType<T>();

        private async UniTask ProcessContentAsync(IEnumerable<string> tags, IProcessStrategy strategy,
            CancellationToken cToken = default)
        {

            var handle = Addressables.LoadAssetsAsync<TextAsset>(tags, null, Addressables.MergeMode.Union);
            var task = handle.Task.AsUniTask().AttachExternalCancellation(cToken);
            var files = await task;

            foreach (var file in files)
            {
                var objs = GetDataObjects(file);

                foreach (var obj in objs)
                {
                    strategy.Process(obj);
                }
            }

            Addressables.Release(handle);
        }

        private IEnumerable<IData> GetDataObjects(TextAsset file)
        {
            var fileName = file.name;
            var loader = ContentRegistry.GetLoader(fileName);

            if (loader == null)
            {
                Statics.LogInfo($"File '{fileName}' not registered against any Type, skipping.", this);
                return Enumerable.Empty<IData>();
            }

            var wrappedJson = $"{{ \"Items\": {file.text} }}";
            return loader.Load(wrappedJson);
        }

        private void ValidateTags(IEnumerable<string> tags)
        {
            if (tags?.Any(string.IsNullOrEmpty) ?? true)
            {
                throw new ArgumentException("Tags cannot be null, empty, or contain null strings.", nameof(tags));
            }
        }
    }
}