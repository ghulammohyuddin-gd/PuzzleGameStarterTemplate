using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    [Serializable]
    public sealed class TilePuzzleData : IPuzzleData
    {
        [SerializeField] private int _gridSize = 2;

        public TilePuzzleData(int gridSize) => _gridSize = gridSize;

        public int GridSize => _gridSize;
    }
}
