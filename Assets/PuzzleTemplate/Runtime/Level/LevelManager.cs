using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public class LevelManager : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] protected GameObject _winConditionCheckerRef;
        [SerializeField] protected GameObject _puzzleGeneratorRef;
        [SerializeField] protected GameObject _puzzleDataProviderRef;

        protected IWinConditionChecker _winConditionChecker;
        protected IPuzzleGenerator _puzzleGenerator;
        protected IPuzzleDataProvider _puzzleDataProvider;
        protected IPuzzle _puzzle;

        protected virtual void Awake()
        {
            _winConditionChecker = _winConditionCheckerRef.GetComponent<IWinConditionChecker>();
            _puzzleGenerator = _puzzleGeneratorRef.GetComponent<IPuzzleGenerator>();
            _puzzleDataProvider = _puzzleDataProviderRef.GetComponent<IPuzzleDataProvider>();
            RegisterEvents();
        }

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
            var puzzleData = _puzzleDataProvider.GetData();
            _puzzle = _puzzleGenerator.Generate(puzzleData);
            _winConditionChecker.Initialise(_puzzle);
            _puzzle.Initialise();
            EventBus.Raise(new LevelStartedEvent(_puzzle));
        }

        protected virtual void ResetLevel()
        {
            _winConditionChecker.Reset();
            _puzzle.Reset();
        }

        protected virtual void RestartLevel()
        {
            ResetLevel();
            StartLevel();
        }
    }
}
