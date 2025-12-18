namespace PuzzleTemplate.Runtime
{
    public readonly struct LoadingStepExecutedEvent : IEvent
    {
        public readonly float Progress;

        public LoadingStepExecutedEvent(float progress)
        {
            Progress = progress;
        }
    }
}