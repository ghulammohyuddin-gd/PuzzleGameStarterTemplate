using System;
using System.Linq;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzleDataProvider : MonoBehaviour, IPuzzleDataProvider
    {

        public IPuzzleData GetData()
        {
            var level = PrefsManager.LoadLevel();
            var dataService = Locator.Get<IDataService>();
            var levelDatas = dataService.GetAllData<TilePuzzleData>().ToArray();
            var idx = Math.Clamp(level, 0, levelDatas.Length - 1);
            return levelDatas[idx];
        }

        private void Awake() => RegisterEvents();

        private void OnDestroy() => UnregisterEvents();

        private void RegisterEvents() => EventBus.Subscribe<LoadNextLevelEvent>(HandleLoadNext);

        private void UnregisterEvents() => EventBus.Unsubscribe<LoadNextLevelEvent>(HandleLoadNext);

        private void HandleLoadNext(LoadNextLevelEvent @event)
        {
            var level = PrefsManager.LoadLevel();
            PrefsManager.SaveLevel(level + 1);
        }
    }
}