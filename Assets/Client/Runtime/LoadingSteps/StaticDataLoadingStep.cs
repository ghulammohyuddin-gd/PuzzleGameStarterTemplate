using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public class StaticDataLoadingStep : LoadingStepBase
    {
        [SerializeField] private string[] _tags;

        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            var contentLoader = Locator.Get<IContentLoader>();

            return contentLoader.LoadContentAsync(_tags, cToken);
        }

    }
}
