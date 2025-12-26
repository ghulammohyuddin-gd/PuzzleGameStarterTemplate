using System.Collections.Generic;
using System.Linq;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public sealed class TilePuzzle : IPuzzle<TilePuzzleData>
    {
        public readonly IList<Tile> Tiles;

        public TilePuzzle(IList<Tile> tiles) => Tiles = tiles;

        public TilePuzzleData Data { get; private set; }

        public void SetData(TilePuzzleData data) => Data = data;

        public int CurrentTargetTiles => Tiles.Count(t => t.Type == TileType.Green);

        public void Initialise()
        {
            var types = new List<TileType>();

            for (int i = 0; i < Tiles.Count; i++)
            {
                types.Add(i < Data.TargetTiles ? TileType.Green : TileType.Red);
            }

            var shuffledTypes = types.OrderBy(x => Random.value).ToList();

            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].SetType(shuffledTypes[i], true);
            }
        }

        public void Reset()
        {
            foreach (var tile in Tiles)
            {
                Object.Destroy(tile.gameObject);
            }
        }
    }
}