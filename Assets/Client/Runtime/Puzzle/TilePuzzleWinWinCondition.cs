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

        private readonly CommandInvoker Invoker = new();
        public int UndosLeft { get; private set; }

        private TilePuzzle _puzzle;

        public void Initialise(IPuzzle puzzle)
        {
            _puzzle = (TilePuzzle)puzzle;
            UndosLeft = _puzzle.Data.MaxUndoCount;
            RegisterClicks();
            Invoker.Clear();
        }

        public void Reset()
        {
            UnregisterClicks();
            Invoker.Clear();
        }

        public void UndoMove()
        {
            if (UndosLeft <= 0) return;
            if (Invoker.UndoOnce())
            {
                UndosLeft--;
                OnAdvance.SafeInvoke();
            }
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

        private void HandleClick(ISceneEntity tile)
        {
            if (tile is ICommand command)
            {
                Invoker.ExecuteCommand(command);
            }

            if (IsWinConditionMet())
            {
                Invoker.Clear();
                OnWin.SafeInvoke();
                return;
            }

            OnAdvance.SafeInvoke();
        }

        private bool IsWinConditionMet() => _puzzle.CurrentTargetTiles <= 0;
    }
}