using System;
using System.Collections.Generic;
using System.Linq;
using PuzzleTemplate.Runtime;

namespace Client.Runtime
{
    public sealed class TilePuzzle : IPuzzle
    {
        public readonly IList<Tile> Tiles;

        public event Action OnAdvance;

        public TilePuzzle(IList<Tile> tiles) => Tiles = tiles;

        public int TotalGreenTiles { get; private set; }

        public int CurrentGreenTiles => Tiles.Count(t => t.Type == TileType.Green);

        public int MovesLeft { get; private set; }

        public void Initialise()
        {
            foreach (var tile in Tiles)
            {
                tile.SetType(GetRandomTileType());
            }
            TotalGreenTiles = Tiles.Count(t => t.Type == TileType.Green);
            MovesLeft = TotalGreenTiles + 1;
            RegisterClicks();
        }

        public void Reset()
        {
            UnregisterClicks();
            TotalGreenTiles = 0;
        }

        private void RegisterClicks()
        {
            foreach (var tile in Tiles)
            {
                tile.OnClick += HandleClick;
            }
        }

        private void UnregisterClicks()
        {
            foreach (var tile in Tiles)
            {
                tile.OnClick -= HandleClick;
            }
        }

        private void HandleClick()
        {
            MovesLeft--;
            OnAdvance.SafeInvoke();
        }

        private TileType GetRandomTileType() => (UnityEngine.Random.value > 0.5f) ? TileType.Green : TileType.Red;
    }
}