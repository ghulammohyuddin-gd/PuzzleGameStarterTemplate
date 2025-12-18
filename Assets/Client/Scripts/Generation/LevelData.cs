namespace Client.Runtime.Generation
{
    /// <summary>Contains data for a single puzzle level.</summary>
    [System.Serializable]
    public class LevelData
    {
        /// <summary>Size of the grid (e.g., 5 = 5x5 grid).</summary>
        public int GridSize = 2;

        /// <summary>Maximum allowed moves for this level.</summary>
        public int MoveLimit => GridSize * GridSize;
    }
}
