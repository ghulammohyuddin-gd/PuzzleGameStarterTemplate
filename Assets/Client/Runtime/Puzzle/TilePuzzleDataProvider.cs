using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzleDataProvider : MonoBehaviour, IPuzzleDataProvider
    {
        [SerializeField] private int _minGridSize = 3;
        [SerializeField] private int _maxGridSize = 10;

        public IPuzzleData GetData()
        {
            var level = PrefsManager.LoadLevel();
            var gridSize = Math.Clamp(level + 3, _minGridSize, _maxGridSize);
            return new TilePuzzleData(gridSize);
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