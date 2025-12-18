using PuzzleTemplate.Runtime;

namespace Client.Runtime
{
    public readonly struct MovesChangedEvent : IEvent
    {
        public readonly int MovesLeft;

        public MovesChangedEvent(int movesLeft)
        {
            MovesLeft = movesLeft;
        }
    }
}