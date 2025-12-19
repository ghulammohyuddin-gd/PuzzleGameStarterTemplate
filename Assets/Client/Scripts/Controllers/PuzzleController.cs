using Client.Runtime.Controllers.Interfaces;
using Client.Runtime.Generation;
using UnityEngine;
using PuzzleTemplate.Runtime;
using Client.Runtime;

namespace Client.Runtime.Controllers
{
    /// <summary>Orchestrates puzzle game flow and coordinates between systems.</summary>
    public class PuzzleController : Singleton<PuzzleController>
    {
        [SerializeField]
        private GridManager gridManager;

        [SerializeField]
        private WinConditionChecker winConditionChecker;

        protected override void Awake()
        {
            base.Awake();
            InitializeComponents();
        }

        /// <summary>Initializes GridManager and WinConditionChecker, creating them if they don't exist.</summary>
        private void InitializeComponents()
        {
            if (gridManager != null)
                Debug.Log("PuzzleController: GridManager initialized successfully.");
            if (winConditionChecker != null)
                Debug.Log("PuzzleController: WinConditionChecker initialized successfully.");
        }

        /// <summary>Initializes the puzzle for a new level.</summary>
        public void InitializePuzzle(LevelData levelData)
        {
            if (gridManager == null)
            {
                Debug.LogError("PuzzleController.InitializePuzzle: GridManager is null!");
                return;
            }

            gridManager.ResetGrid();
            gridManager.GenerateGrid(levelData);

            if (winConditionChecker != null)
                winConditionChecker.Reset();
        }

        /// <summary>Handles notification that a green tile was clicked.</summary>
        public void OnGreenTileClicked()
        {
            if (gridManager == null)
                return;

            gridManager.OnGreenTileClicked();

            if (winConditionChecker != null && winConditionChecker.IsWinConditionMet())
                EventBus.Raise(new LevelWinEvent());
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
