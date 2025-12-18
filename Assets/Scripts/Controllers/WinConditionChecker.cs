using Template.Runtime.Controllers.Interfaces;
using UnityEngine;

namespace Template.Runtime.Controllers
{
    /// <summary>Checks and manages game win and lose conditions.</summary>
    public class WinConditionChecker : MonoBehaviour, IWinConditionChecker
    {
        [SerializeField]
        private IGridManager gridManager;

        [SerializeField]
        private MoveCounter moveCounter;

        private void OnEnable()
        {
            if (gridManager == null)
                gridManager = GetComponent<IGridManager>();
            if (moveCounter == null)
                moveCounter = GetComponent<MoveCounter>();

            PuzzleTile.OnTileClicked += OnTileClicked;
        }

        private void OnDisable()
        {
            PuzzleTile.OnTileClicked -= OnTileClicked;
        }

        /// <summary>Checks if the win condition is met (all green tiles clicked).</summary>
        public bool IsWinConditionMet()
        {
            if (gridManager == null)
                return false;

            return gridManager.GetClickedGreenTileCount() >= gridManager.TotalGreenTiles;
        }

        /// <summary>Checks if the lose condition is met (no moves left with unclicked green tiles).</summary>
        public bool IsLoseConditionMet()
        {
            if (moveCounter == null)
                return false;

            return moveCounter.MovesLeft <= 0 && !IsWinConditionMet();
        }

        /// <summary>Resets the condition checker to its initial state.</summary>
        public void Reset()
        {
        }

        private void OnTileClicked(PuzzleTile tile)
        {
            if (tile.Type == PuzzleTile.TileType.Green && moveCounter != null)
            {
                moveCounter.UseMove();
            }
        }
    }
}
