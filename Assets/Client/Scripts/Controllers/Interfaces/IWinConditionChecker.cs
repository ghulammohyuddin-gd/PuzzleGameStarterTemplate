namespace Client.Runtime.Controllers.Interfaces
{
    /// <summary>Defines the contract for evaluating win and lose conditions.</summary>
    public interface IWinConditionChecker
    {
        /// <summary>Checks if the current game state satisfies win conditions.</summary>
        bool IsWinConditionMet();

        /// <summary>Checks if the current game state satisfies lose conditions.</summary>
        bool IsLoseConditionMet();

        /// <summary>Resets the condition checker to its initial state.</summary>
        void Reset();
    }
}
