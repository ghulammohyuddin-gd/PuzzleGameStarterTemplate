using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzleMovesWinCondition : MonoBehaviour, IWinConditionChecker
    {
        public event Action OnWin;
        public event Action OnLose;

        private TilePuzzle _puzzle;

        public void Initialise(IPuzzle puzzle)
        {
            _puzzle = (TilePuzzle)puzzle;
            _puzzle.OnAdvance += HandleAdvance;
        }

        public void Reset()
        {
            _puzzle.OnAdvance -= HandleAdvance;
            _puzzle = null;
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

        private bool IsWinConditionMet() => _puzzle.CurrentGreenTiles <= 0;

        private bool IsLoseConditionMet() => _puzzle.MovesLeft <= 0 && !IsWinConditionMet();
    }
}