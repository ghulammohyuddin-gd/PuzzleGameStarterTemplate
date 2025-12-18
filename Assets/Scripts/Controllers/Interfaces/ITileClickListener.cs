namespace Template.Runtime.Controllers.Interfaces
{
    /// <summary>Defines the contract for receiving tile click events.</summary>
    public interface ITileClickListener
    {
        /// <summary>Called when a tile is clicked by the player.</summary>
        void OnTileClicked(PuzzleTile tile);
    }
}
