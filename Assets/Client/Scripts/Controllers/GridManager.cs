using System.Collections.Generic;
using Client.Runtime.Generation;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime.Controllers
{
    /// <summary>Manages grid generation, tile creation, and tile state tracking.</summary>
    public class GridManager : Singleton<GridManager>
    {
        [SerializeField]
        private GameObject tilePrefab;

        [SerializeField]
        private float tileSpacing = 1f;

        private List<GameObject> activeTiles = new List<GameObject>();
        private int totalGreenTiles;
        private int clickedGreenTiles;

        public int TotalGreenTiles => totalGreenTiles;
        public List<GameObject> ActiveTiles => activeTiles;

        /// <summary>Generates a grid based on level data and randomizes tile types.</summary>
        public void GenerateGrid(LevelData levelData)
        {
            if (tilePrefab == null)
            {
                Debug.LogError("GridManager.GenerateGrid: tilePrefab is not assigned!");
                return;
            }

            ResetGrid();

            int gridSize = levelData.GridSize;
            float offset = (gridSize - 1) * tileSpacing / 2f;

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    GameObject tile = Instantiate(tilePrefab, transform);
                    tile.transform.localPosition = new Vector3(x * tileSpacing - offset, y * tileSpacing - offset, 0);

                    PuzzleTile puzzleTile = tile.GetComponent<PuzzleTile>();
                    if (puzzleTile == null)
                        continue;

                    puzzleTile.Type = (Random.value > 0.5f) ? PuzzleTile.TileType.Green : PuzzleTile.TileType.Red;

                    SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();
                    if (sr != null)
                        sr.color = (puzzleTile.Type == PuzzleTile.TileType.Green) ? Color.green : Color.red;

                    if (puzzleTile.Type == PuzzleTile.TileType.Green)
                        totalGreenTiles++;

                    activeTiles.Add(tile);
                }
            }

            Debug.Log($"GridManager: Generated {gridSize}x{gridSize} grid with {totalGreenTiles} green tiles.");
        }

        /// <summary>Marks a green tile as clicked and increments the click counter.</summary>
        public void OnGreenTileClicked()
        {
            clickedGreenTiles++;
        }

        /// <summary>Gets the count of green tiles clicked so far.</summary>
        public int GetClickedGreenTileCount()
        {
            return clickedGreenTiles;
        }

        /// <summary>Resets the grid by destroying all tiles and clearing counters.</summary>
        public void ResetGrid()
        {
            foreach (var tile in activeTiles)
                Destroy(tile);

            activeTiles.Clear();
            totalGreenTiles = 0;
            clickedGreenTiles = 0;
        }
    }
}
