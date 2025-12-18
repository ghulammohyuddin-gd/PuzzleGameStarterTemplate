using UnityEngine;

namespace Client.Runtime.Generation
{
    /// <summary>Generates level data procedurally based on difficulty scaling.</summary>
    [System.Serializable]
    public class ProceduralLevelGenerator : MonoBehaviour
    {
        /// <summary>Starting grid size for level 1.</summary>
        [SerializeField]
        private int baseGridSize = 3;

        /// <summary>Maximum grid size to prevent excessive difficulty scaling.</summary>
        [SerializeField]
        private int maxGridSize = 5;

        /// <summary>Number of levels between each grid size increase.</summary>
        [SerializeField]
        private int incrementEveryNLevels = 1;

        /// <summary>Generates level data for the given level index with progressive difficulty.</summary>
        public LevelData GenerateLevel(int levelIndex)
        {
            LevelData level = new LevelData();

            int increaseSteps = levelIndex / incrementEveryNLevels;
            int newGridSize = baseGridSize + increaseSteps;
            level.GridSize = Mathf.Min(newGridSize, maxGridSize);

            return level;
        }
    }
}
