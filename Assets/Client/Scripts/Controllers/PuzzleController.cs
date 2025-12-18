using Template.Runtime.Core;
using Template.Runtime.Controllers.Interfaces;
using Template.Runtime.Generation;
using UnityEngine;
using PuzzleTemplate.Runtime;
using Client.Runtime;

namespace Template.Runtime.Controllers
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
            if (gridManager == null)
            {
                gridManager = GetComponent<GridManager>();
                if (gridManager == null)
                    gridManager = FindFirstObjectByType<GridManager>();
                if (gridManager == null)
                {
                    GameObject gridObj = new GameObject("GridManager");
                    gridObj.transform.SetParent(transform);
                    gridManager = gridObj.AddComponent<GridManager>();
                    Debug.Log("PuzzleController: Created GridManager dynamically.");
                }
            }

            if (gridManager != null)
            {
                GameObject tilePrefab = Resources.Load<GameObject>("Prefabs/Tiles/PuzzleTile");
                if (tilePrefab != null)
                {
                    gridManager.SetTilePrefab(tilePrefab);
                    Debug.Log("PuzzleController: Loaded tile prefab and assigned to GridManager.");
                }
                else
                {
                    Debug.LogError("PuzzleController: Could not load tile prefab from Resources!");
                }
            }

            if (winConditionChecker == null)
            {
                winConditionChecker = GetComponent<WinConditionChecker>();
                if (winConditionChecker == null)
                    winConditionChecker = FindFirstObjectByType<WinConditionChecker>();
                if (winConditionChecker == null)
                {
                    GameObject winObj = new GameObject("WinConditionChecker");
                    winObj.transform.SetParent(transform);
                    winConditionChecker = winObj.AddComponent<WinConditionChecker>();
                    Debug.Log("PuzzleController: Created WinConditionChecker dynamically.");
                }
            }

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
