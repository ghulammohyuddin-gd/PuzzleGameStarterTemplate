using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzleMovesWinCondition : MonoBehaviour, IWinConditionChecker
    {
        public event Action OnWin;
        public event Action OnLose;
        public event Action OnAdvance;

        private TilePuzzle _puzzle;

        public int MovesLeft { get; private set; }

        public void Initialise(IPuzzle puzzle)
        {
            _puzzle = (TilePuzzle)puzzle;
            RegisterClicks();
            MovesLeft = _puzzle.TotalGreenTiles + 1;
        }

        public void Reset()
        {
            UnregisterClicks();
            MovesLeft = 0;
            _puzzle = null;
        }

        private void RegisterClicks()
        {
            foreach (var tile in _puzzle.Tiles)
            {
                tile.OnClick += HandleClick;
            }
        }

        private void UnregisterClicks()
        {
            foreach (var tile in _puzzle.Tiles)
            {
                tile.OnClick -= HandleClick;
            }
        }

        private void HandleClick()
        {
            MovesLeft--;
            OnAdvance.SafeInvoke();

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

        private bool IsLoseConditionMet() => MovesLeft <= 0 && !IsWinConditionMet();
    }
}