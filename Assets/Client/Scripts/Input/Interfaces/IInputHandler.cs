using Client.Runtime.Controllers;
using UnityEngine;

namespace Client.Runtime.Input.Interfaces
{
    /// <summary>Defines the contract for input handling and tile detection.</summary>
    public interface IInputHandler
    {
        /// <summary>Enables input detection.</summary>
        void EnableInput();

        /// <summary>Disables input detection.</summary>
        void DisableInput();

        /// <summary>Attempts to get the tile at the given world position.</summary>
        bool TryGetTileAtPosition(Vector2 worldPosition, out PuzzleTile tile);
    }
}
