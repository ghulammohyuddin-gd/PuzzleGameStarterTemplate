namespace PuzzleTemplate.Runtime
{
    public interface ILevelHander
    {
        IPuzzle CurrentPuzzle { get; }

        void StartLevel();

        void ResetLevel();

        void RestartLevel();
    }
}