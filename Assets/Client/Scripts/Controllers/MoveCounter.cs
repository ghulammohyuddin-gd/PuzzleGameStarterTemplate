using Client.Runtime;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime.Controllers
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
            EventBus.Raise(new MovesChangedEvent(movesLeft));
        }

        /// <summary>Consumes one move and checks lose conditions.</summary>
        public void UseMove()
        {
            if (movesLeft <= 0)
                return;

            movesLeft--;
            EventBus.Raise(new MovesChangedEvent(movesLeft));

            if (movesLeft <= 0)
            {
                // Only trigger lose when there are still unclicked green tiles
                var pc = PuzzleController.Instance;
                var gm = GridManager.Instance;
                if (pc != null && gm != null)
                {
                    int remainingGreen = gm.TotalGreenTiles - gm.GetClickedGreenTileCount();
                    if (remainingGreen > 0)
                        EventBus.Raise(new LevelLoseEvent());
                }
                else
                {
                    EventBus.Raise(new LevelLoseEvent());
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
