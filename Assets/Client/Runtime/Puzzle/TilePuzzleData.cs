using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    [Serializable]
    public sealed class TilePuzzleData : IPuzzleData
    {
        [SerializeField] private int _gridSize;
        [SerializeField] private float _seconds;

        public TilePuzzleData(int gridSize, float seconds)
        {
            _gridSize = gridSize;
            _seconds = seconds;
        }

        public int GridSize => _gridSize;
        public float Seconds => _seconds;
    }
}
