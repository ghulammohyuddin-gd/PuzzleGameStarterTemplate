using Client.Runtime.Controllers;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    /// <summary>Checks and manages game win and lose conditions.</summary>
    public class WinConditionChecker : MonoBehaviour, IWinConditionChecker
    {
        private void Awake()
        {
            PuzzleTile.OnTileClicked += OnTileClicked;
        }

        private void OnDestroy()
        {
            PuzzleTile.OnTileClicked -= OnTileClicked;
        }

        public bool IsWinConditionMet()
        {
            var gridManager = GridManager.Instance;
            return gridManager.GetClickedGreenTileCount() >= gridManager.TotalGreenTiles;
        }

        public bool IsLoseConditionMet()
        {
            return MoveCounter.Instance.MovesLeft <= 0 && !IsWinConditionMet();
        }

        private void OnTileClicked(PuzzleTile tile)
        {
            MoveCounter.Instance.UseMove();

            if (tile.Type == PuzzleTile.TileType.Green)
            {
                PuzzleController.Instance.OnGreenTileClicked();
            }
        }
    }
}
