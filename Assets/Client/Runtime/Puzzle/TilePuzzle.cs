using System;
using System.Collections.Generic;
using System.Linq;
using PuzzleTemplate.Runtime;

namespace Client.Runtime
{
    public sealed class TilePuzzle : IPuzzle
    {
        public readonly IList<Tile> Tiles;
        public readonly float Seconds;

        public event Action OnAdvance;

        public TilePuzzle(IList<Tile> tiles, float seconds)
        {
            Tiles = tiles;
            Seconds = seconds;
        }

        public int TotalGreenTiles { get; private set; }

        public int CurrentGreenTiles => Tiles.Count(t => t.Type == TileType.Green);

        public void Initialise()
        {
            foreach (var tile in Tiles)
            {
                tile.SetType(GetRandomTileType(), true);
            }
            TotalGreenTiles = Tiles.Count(t => t.Type == TileType.Green);
        }

        public void Reset()
        {
            TotalGreenTiles = 0;

            foreach (var tile in Tiles)
            {
                UnityEngine.Object.Destroy(tile.gameObject);
            }
        }

        private TileType GetRandomTileType() => (UnityEngine.Random.value > 0.5f) ? TileType.Green : TileType.Red;
    }
}