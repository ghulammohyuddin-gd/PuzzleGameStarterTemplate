
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public class LevelManager : MonoBehaviour
    {
        protected IPuzzle _puzzle;

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
            _puzzle = puzzleGenerator.Generate(puzzleData);
            _puzzle.Initialise();
            Locator.Get<IWinConditionChecker>().Initialise(_puzzle);
            EventBus.Raise(new LevelStartedEvent(_puzzle));
        }

        protected virtual void ResetLevel()
        {
            Locator.Get<IWinConditionChecker>().Reset();
            _puzzle.Reset();
        }

        protected virtual void RestartLevel()
        {
            ResetLevel();
            StartLevel();
        }
    }
}
