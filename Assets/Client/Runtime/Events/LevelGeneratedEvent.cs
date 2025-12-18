using PuzzleTemplate.Runtime;
using Template.Runtime.Generation;

namespace Client.Runtime
{
    public readonly struct LevelGeneratedEvent : IEvent
    {
        public readonly LevelData CurrentLevelData;

        public LevelGeneratedEvent(LevelData data)
        {
            CurrentLevelData = data;
        }
    }
}