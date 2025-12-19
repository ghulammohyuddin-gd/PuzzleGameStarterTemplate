using System;
using Client.Runtime.UI;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class LevelManager : MonoBehaviour
    {
        [SerializeField] private HUDController _hudController;
        [SerializeField] private LevelViewsController _viewsController;
        [SerializeField] private TilePuzzleGenerator _puzzleGenerator;
        [SerializeField] private int _gridSize = 5;

        private readonly IWinConditionChecker _checker = new TilePuzzleWinConditionChecker();
        private IPuzzle _puzzle;

        private void Start()
        {
            RegisterEvents();
            _viewsController.SetWinConditionChecker(_checker);
            StartLevel();
        }

        private void Destroy()
        {

            UnregisterEvents();
        }

        private void StartLevel()
        {
            _puzzle = _puzzleGenerator.Generate(new TilePuzzleData(_gridSize));
            _checker.SetPuzzle(_puzzle);
            _hudController.SetPuzzle(_puzzle);
            _puzzle.Initialise();
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
            _gridSize += 1;
            StartLevel();
        }

        private void HandleRestart(RestartLevelEvent @event)
        {
            _puzzle.Reset();
            _puzzle.Initialise();
        }
    }
}
