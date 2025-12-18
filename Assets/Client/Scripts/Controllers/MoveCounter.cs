using PuzzleTemplate.Runtime;
using Template.Runtime.Core;
using UnityEngine;

namespace Template.Runtime.Controllers
{
    /// <summary>Manages move count and lose conditions based on remaining moves.</summary>
    public class MoveCounter : Singleton<MoveCounter>
    {
        private int movesLeft;

        /// <summary>Gets the current number of remaining moves.</summary>
        public int MovesLeft => movesLeft;

        protected override void Awake()
        {
            base.Awake();
        }

        /// <summary>Initializes the move counter with the specified move limit.</summary>
        public void Initialize(int moveLimit)
        {
            movesLeft = moveLimit;
            GameEvents.OnMovesChanged?.Invoke(movesLeft);
        }

        /// <summary>Consumes one move and checks lose conditions.</summary>
        public void UseMove()
        {
            if (movesLeft <= 0)
                return;

            movesLeft--;
            GameEvents.OnMovesChanged?.Invoke(movesLeft);

            if (movesLeft <= 0)
            {
                // Only trigger lose when there are still unclicked green tiles
                var pc = PuzzleController.Instance;
                if (pc != null && pc.GridManager != null)
                {
                    int remainingGreen = pc.GridManager.TotalGreenTiles - pc.GridManager.GetClickedGreenTileCount();
                    if (remainingGreen > 0)
                        GameEvents.OnLevelLose?.Invoke();
                }
                else
                {
                    GameEvents.OnLevelLose?.Invoke();
                }
            }
        }

        /// <summary>Resets the move counter.</summary>
        public void Reset()
        {
            movesLeft = 0;
        }
    }
}
