using PuzzleTemplate.Runtime;

namespace Client.Runtime
{
    public readonly struct LevelChangedEvent : IEvent
    {
        public readonly int CurrentLevelIdx;

        public LevelChangedEvent(int idx)
        {
            CurrentLevelIdx = idx;
        }
    }
}