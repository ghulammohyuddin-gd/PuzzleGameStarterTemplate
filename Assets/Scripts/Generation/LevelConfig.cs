using UnityEngine;

[CreateAssetMenu(menuName = "Puzzle/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    public int BaseGridSize = 5;
    public int MinMoves = 10;
    public int MaxMoves = 20;
    public float DifficultyFactor = 0.5f;
}
