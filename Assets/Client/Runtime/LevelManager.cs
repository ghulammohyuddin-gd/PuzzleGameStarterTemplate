using Client.Runtime.UI;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class LevelManager : MonoBehaviour
    {
        [SerializeField] private HUDController _hudController;
        [SerializeField] private LevelViewsController _viewsController;
        [SerializeField] private MonoBehaviour _puzzleGeneratorGo;
        [SerializeField] private TilePuzzleData _puzzleData;

        private readonly IWinConditionChecker _checker = new TilePuzzleWinConditionChecker();
        private IPuzzleGenerator _puzzleGenerator;

        private IPuzzle _puzzle;

        private void Awake()
        {
            _puzzleGenerator = _puzzleGeneratorGo as IPuzzleGenerator;
        }

        private void Start()
        {
            _viewsController.SetWinConditionChecker(_checker);
            RegisterEvents();
            StartLevel();
        }

        private void Destroy()
        {
            UnregisterEvents();
        }

        private void RegisterEvents()
        {
            EventBus.Subscribe<RestartLevelEvent>(HandleRestart);
            EventBus.Subscribe<LoadNextLevelEvent>(HandleLoadNext);
        }

        private void UnregisterEvents()
        {
            EventBus.Unsubscribe<RestartLevelEvent>(HandleRestart);
            EventBus.Unsubscribe<LoadNextLevelEvent>(HandleLoadNext);
        }

        private void HandleLoadNext(LoadNextLevelEvent @event)
        {
            _puzzleData = new TilePuzzleData(_puzzleData.GridSize + 1);
            ResetLevel();
            StartLevel();
        }

        private void HandleRestart(RestartLevelEvent @event)
        {
            ResetLevel();
            StartLevel();
        }

        private void StartLevel()
        {
            _puzzle = _puzzleGenerator.Generate(_puzzleData);
            _checker.Initialise(_puzzle);
            _puzzle.Initialise();
            _hudController.Initialise(_puzzle);
        }

        private void ResetLevel()
        {
            _checker.Reset();
            _hudController.Reset();
            _puzzle.Reset();
        }
    }
}
