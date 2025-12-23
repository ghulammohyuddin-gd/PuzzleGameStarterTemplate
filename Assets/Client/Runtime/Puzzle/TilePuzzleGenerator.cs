using System;
using System.Collections.Generic;
using PuzzleTemplate.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime
{
    public sealed class TilePuzzleGenerator : MonoBehaviour, IPuzzleGenerator
    {
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private GridLayoutGroup _layout;

        public IPuzzle Generate(IPuzzleData data)
        {
            if (data is not TilePuzzleData tilePuzzleData)
            {
                throw new InvalidOperationException("Puzzle data type mismatch.");
            }

            int gridSize = tilePuzzleData.GridSize;
            _layout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _layout.constraintCount = gridSize;

            var len = gridSize * gridSize;
            var spawned = new List<Tile>();

            for (var x = 0; x < len; x++)
            {
                var tile = Instantiate(_tilePrefab, _layout.transform);
                spawned.Add(tile);
            }

            return new TilePuzzle(spawned, tilePuzzleData.Seconds);
        }
    }
}
