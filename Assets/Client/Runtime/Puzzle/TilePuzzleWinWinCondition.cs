using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzleWinWinCondition : MonoBehaviour, IWinConditionChecker
    {
        public event Action OnWin;
        public event Action OnLose;
        public event Action OnAdvance;

        public readonly CommandInvoker Invoker = new();
        private TilePuzzle _puzzle;

        public void Initialise(IPuzzle puzzle)
        {
            _puzzle = (TilePuzzle)puzzle;
            Invoker.Clear();
            RegisterClicks();
        }

        public void Reset()
        {
            UnregisterClicks();
            Invoker.Clear();
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

        private void HandleClick(Tile tile)
        {
            Invoker.ExecuteCommand(tile);

            if (IsWinConditionMet())
            {
                Invoker.Clear();
                OnWin.SafeInvoke();
                return;
            }

            OnAdvance.SafeInvoke();
        }

        private bool IsWinConditionMet() => _puzzle.CurrentGreenTiles <= 0;
    }
}