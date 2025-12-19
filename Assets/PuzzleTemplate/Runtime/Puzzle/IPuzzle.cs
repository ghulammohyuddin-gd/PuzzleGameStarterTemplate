using System;

namespace PuzzleTemplate.Runtime
{
    public interface IPuzzle
    {
        event Action OnAdvance;

        void Initialise();

        void Reset();
    }
}