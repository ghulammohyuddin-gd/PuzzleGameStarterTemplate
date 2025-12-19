using System;
using System.Collections.Generic;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzleGenerator : MonoBehaviour, IPuzzleGenerator
    {
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private float _tileSpacing = 1f;

        public IPuzzle Generate(IPuzzleData data)
        {
            if (data is not TilePuzzleData tilePuzzleData)
            {
                throw new InvalidOperationException("Puzzle data type mismatch.");
            }

            int gridSize = tilePuzzleData.GridSize;
            var offset = (gridSize - 1) * _tileSpacing / 2f;
            var spawned = new List<Tile>();

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    var tile = Instantiate(_tilePrefab, transform);
                    tile.transform.localPosition = new Vector3(x * _tileSpacing - offset, y * _tileSpacing - offset, 0);
                    spawned.Add(tile);
                }
            }

            return new TilePuzzle(spawned);
        }
    }
}
