namespace PuzzleTemplate.Runtime
{
    public readonly struct LevelStartedEvent : IEvent
    {
        public readonly IPuzzle Puzzle;

        public LevelStartedEvent(IPuzzle puzzle)
        {
            Puzzle = puzzle;
        }
    }
}