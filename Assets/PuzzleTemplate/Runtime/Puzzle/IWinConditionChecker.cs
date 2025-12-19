using System;

namespace PuzzleTemplate.Runtime
{
    public interface IWinConditionChecker
    {
        event Action OnWin;
        event Action OnLose;

        void SetPuzzle(IPuzzle puzzle);
    }
}