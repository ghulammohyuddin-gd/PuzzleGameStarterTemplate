
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public class LevelManager : MonoBehaviour, ILevelHander
    {
        public IPuzzle CurrentPuzzle { get; set; }

        protected virtual void Awake() => RegisterEvents();

        protected virtual void Start() => StartLevel();

        protected virtual void OnDestroy() => UnregisterEvents();

        protected virtual void RegisterEvents()
        {
            EventBus.Subscribe<RestartLevelEvent>(HandleRestart);
            EventBus.Subscribe<LoadNextLevelEvent>(HandleLoadNext);
        }

        protected virtual void UnregisterEvents()
        {
            EventBus.Unsubscribe<RestartLevelEvent>(HandleRestart);
            EventBus.Unsubscribe<LoadNextLevelEvent>(HandleLoadNext);
        }

        protected virtual void HandleLoadNext(LoadNextLevelEvent @event) => RestartLevel();

        protected virtual void HandleRestart(RestartLevelEvent @event) => RestartLevel();

        protected virtual void StartLevel()
        {
            var puzzleDataProvider = Locator.Get<IPuzzleDataProvider>();
            var puzzleData = puzzleDataProvider.GetData();
            var puzzleGenerator = Locator.Get<IPuzzleGenerator>();
            CurrentPuzzle = puzzleGenerator.Generate(puzzleData);
            CurrentPuzzle.Initialise();
            Locator.Get<IWinConditionChecker>().Initialise(CurrentPuzzle);
            EventBus.Raise(new LevelStartedEvent(CurrentPuzzle));
        }

        protected virtual void ResetLevel()
        {
            Locator.Get<IWinConditionChecker>().Reset();
            CurrentPuzzle.Reset();
        }

        protected virtual void RestartLevel()
        {
            ResetLevel();
            StartLevel();
        }

        void ILevelHander.StartLevel()
        {
            StartLevel();
        }

        void ILevelHander.ResetLevel()
        {
            ResetLevel();
        }

        void ILevelHander.RestartLevel()
        {
            RestartLevel();
        }

    }
}
