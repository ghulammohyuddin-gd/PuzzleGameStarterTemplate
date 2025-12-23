using System;

namespace PuzzleTemplate.Runtime
{
    public interface IWinConditionChecker
    {
        event Action OnWin;
        event Action OnLose;
        event Action OnAdvance;

        void Initialise(IPuzzle puzzle);

        void Reset();
    }
}