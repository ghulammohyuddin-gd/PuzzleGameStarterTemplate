using Template.Runtime.Core;
using Template.Runtime.Controllers.Interfaces;
using Template.Runtime.Generation;
using UnityEngine;

namespace Template.Runtime.Controllers
{
    /// <summary>Orchestrates puzzle game flow and coordinates between systems.</summary>
    public class PuzzleController : Singleton<PuzzleController>
    {
        private IGridManager gridManager;
        private IWinConditionChecker winConditionChecker;

        protected override void Awake()
        {
            base.Awake();
            gridManager = GetComponent<IGridManager>();
            winConditionChecker = GetComponent<IWinConditionChecker>();
        }

        /// <summary>Initializes the puzzle for a new level.</summary>
        public void InitializePuzzle(LevelData levelData)
        {
            gridManager?.ResetGrid();
            gridManager?.GenerateGrid(levelData);
            winConditionChecker?.Reset();
        }

        /// <summary>Handles notification that a green tile was clicked.</summary>
        public void OnGreenTileClicked()
        {
            gridManager?.OnGreenTileClicked();

            if (winConditionChecker != null && winConditionChecker.IsWinConditionMet())
                GameEvents.OnLevelWin?.Invoke();
        }

        /// <summary>Resets the puzzle to its initial state.</summary>
        public void ResetPuzzle()
        {
            gridManager?.ResetGrid();
            winConditionChecker?.Reset();
        }

        /// <summary>Gets the grid manager instance.</summary>
        public IGridManager GridManager => gridManager;
    }
}
