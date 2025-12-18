using UnityEngine;

namespace PuzzleGameStarterTemplate.Generation
{
    [System.Serializable]
    public class ProceduralLevelGenerator : MonoBehaviour
    {
        [Header("Grid Settings")]
        public int baseGridSize = 3;             // Starting grid size
        public int maxGridSize = 5;              // Maximum grid size allowed
        public int incrementEveryNLevels = 1;    // Increase grid size every N levels

        // Generate a new level data for a given level index
        public LevelData GenerateLevel(int levelIndex)
        {
            LevelData level = new LevelData();

            // Calculate how many steps of increase
            int increaseSteps = levelIndex / incrementEveryNLevels;
            int newGridSize = baseGridSize + increaseSteps;

            // Clamp to maximum grid size
            level.GridSize = Mathf.Min(newGridSize, maxGridSize);

            // TODO: Add procedural rules for green/red tiles, obstacles, power-ups, etc.

            Debug.Log($"Generated Level {levelIndex + 1} -> GridSize: {level.GridSize}");

            return level;
        }
    }
}
