using System;

namespace PuzzleTemplate.Runtime
{
    [Serializable]
    public enum WinConstraint
    {
        FreePlay,
        TimerBased,
        MovesLimit
    }
}