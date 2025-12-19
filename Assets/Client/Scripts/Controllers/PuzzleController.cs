using Client.Runtime.Generation;
using UnityEngine;
using PuzzleTemplate.Runtime;

namespace Client.Runtime.Controllers
{
    /// <summary>Orchestrates puzzle game flow and coordinates between systems.</summary>
    public class PuzzleController : Singleton<PuzzleController>
    {
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
            if (winConditionChecker != null)
                Debug.Log("PuzzleController: WinConditionChecker initialized successfully.");
        }

        /// <summary>Initializes the puzzle for a new level.</summary>
        public void InitializePuzzle(LevelData levelData)
        {
            var gridManager = GridManager.Instance;


            gridManager.ResetGrid();
            gridManager.GenerateGrid(levelData);
        }

        /// <summary>Handles notification that a green tile was clicked.</summary>
        public void OnGreenTileClicked()
        {
            GridManager.Instance.OnGreenTileClicked();

            if (winConditionChecker != null && winConditionChecker.IsWinConditionMet())
                EventBus.Raise(new LevelWinEvent());
        }

        /// <summary>Resets the puzzle to its initial state.</summary>
        public void ResetPuzzle()
        {
            GridManager.Instance.ResetGrid();
        }
    }
}
