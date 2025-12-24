using System;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    [Serializable]
    public sealed class TilePuzzleData : IPuzzleData
    {
        [SerializeField] private string _id;
        [SerializeField] private int _gridSize;
        [SerializeField] private int _targetTiles;
        [SerializeField] private int _moveLimit;
        [SerializeField] private int _timeLimit;
        [SerializeField] private int _maxUndoCount;

        public string Id => _id;
        public int GridSize => _gridSize;
        public int TargetTiles => _targetTiles;
        public int MoveLimit => _moveLimit;
        public int TimeLimit => _timeLimit;
        public int MaxUndoCount => _maxUndoCount;
    }
}
