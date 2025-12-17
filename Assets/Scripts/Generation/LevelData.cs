[System.Serializable]
public class LevelData
{
    public int GridSize = 2; // default 2x2 grid
    // You can expand with more level config later
    public int MoveLimit => GridSize * GridSize; // placeholder
}
