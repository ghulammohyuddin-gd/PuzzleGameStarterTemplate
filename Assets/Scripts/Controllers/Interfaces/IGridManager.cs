using Template.Runtime.Generation;
using UnityEngine;

namespace Template.Runtime.Controllers.Interfaces
{
    /// <summary>Defines the contract for grid management and tile state tracking.</summary>
    public interface IGridManager
    {
        /// <summary>Gets the total number of green tiles in the current grid.</summary>
        int TotalGreenTiles { get; }

        /// <summary>Gets the list of currently active tile game objects.</summary>
        System.Collections.Generic.List<GameObject> ActiveTiles { get; }

        /// <summary>Generates a grid based on the provided level data.</summary>
        void GenerateGrid(LevelData levelData);

        /// <summary>Resets the grid to its initial state.</summary>
        void ResetGrid();

        /// <summary>Marks a green tile as clicked and updates the grid state.</summary>
        void OnGreenTileClicked();

        /// <summary>Gets the current count of clicked green tiles.</summary>
        int GetClickedGreenTileCount();
    }
}
