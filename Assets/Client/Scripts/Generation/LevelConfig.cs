using UnityEngine;

namespace Client.Runtime.Generation
{
    /// <summary>Scriptable object containing difficulty configuration for level generation.</summary>
    [CreateAssetMenu(menuName = "Puzzle/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        /// <summary>Starting grid size for the first level.</summary>
        public int BaseGridSize = 5;

        /// <summary>Minimum moves allowed for a level.</summary>
        public int MinMoves = 10;

        /// <summary>Maximum moves allowed for a level.</summary>
        public int MaxMoves = 20;

        /// <summary>Factor used to scale difficulty progression.</summary>
        public float DifficultyFactor = 0.5f;
    }
}
