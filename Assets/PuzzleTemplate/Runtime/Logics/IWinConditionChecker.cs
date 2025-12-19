namespace PuzzleTemplate.Runtime
{
    public interface IWinConditionChecker
    {
        bool IsWinConditionMet();

        bool IsLoseConditionMet();
    }
}