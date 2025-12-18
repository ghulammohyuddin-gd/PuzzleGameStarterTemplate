using PuzzleGameStarterTemplate.Core;
using UnityEngine;

namespace PuzzleGameStarterTemplate.Controllers
{
    public class MoveCounter : MonoBehaviour
    {
        public static MoveCounter Instance { get; private set; }

        public int MovesLeft { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
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
