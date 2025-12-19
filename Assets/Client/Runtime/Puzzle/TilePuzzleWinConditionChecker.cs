using System;
using PuzzleTemplate.Runtime;

namespace Client.Runtime
{
    public sealed class TilePuzzleWinConditionChecker : IWinConditionChecker
    {
        public event Action OnWin;
        public event Action OnLose;

        private TilePuzzle _puzzle;

        public void SetPuzzle(IPuzzle puzzle)
        {
            if (_puzzle != null)
            {
                _puzzle.OnAdvance -= HandleAdvance;
            }

            _puzzle = (TilePuzzle)puzzle;
            _puzzle.OnAdvance += HandleAdvance;
        }

        private void HandleAdvance()
        {
            if (IsWinConditionMet())
            {
                OnWin.SafeInvoke();
                return;
            }

            if (IsLoseConditionMet())
            {
                OnLose.SafeInvoke();
                return;
            }
        }

        private bool IsWinConditionMet() => _puzzle.CurrentGreenTiles >= _puzzle.TotalGreenTiles;

        private bool IsLoseConditionMet() => _puzzle.MovesLeft <= 0 && !IsWinConditionMet();
    }
}