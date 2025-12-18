using Template.Runtime.Core;
using UnityEngine;

namespace Template.Runtime.Controllers
{
    public class MoveCounter : Singleton<MoveCounter> // Changed inheritance
    {
        // Removed: public static MoveCounter Instance { get; private set; }

        public int MovesLeft { get; private set; }

        protected override void Awake() // Changed to protected override
        {
            base.Awake(); // Call base Singleton Awake logic
            // No additional custom logic needed here for now
        }

        public void Initialize(int moveLimit)
        {
            MovesLeft = moveLimit;
            GameEvents.OnMovesChanged?.Invoke(MovesLeft);
        }

        public void UseMove()
        {
            if (MovesLeft <= 0) return;

            MovesLeft--;
            GameEvents.OnMovesChanged?.Invoke(MovesLeft);

            // Lose condition: moves over & green tiles remain
            if (MovesLeft <= 0 && PuzzleController.Instance != null && PuzzleController.Instance.TotalGreenTiles > 0)
                GameEvents.OnLevelLose?.Invoke();
        }
    }
}
