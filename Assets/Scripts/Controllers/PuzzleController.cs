using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public static PuzzleController Instance { get; private set; }

    public GameObject tilePrefab;
    public float spacing = 1f;

    private List<GameObject> activeTiles = new List<GameObject>();
    private int totalGreenTiles = 0;
    private int greenTilesClicked = 0;

    public int TotalGreenTiles => totalGreenTiles;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void GenerateGrid(LevelData level)
    {
        // Clear previous tiles
        foreach (var tile in activeTiles)
            Destroy(tile);
        activeTiles.Clear();

        totalGreenTiles = 0;
        greenTilesClicked = 0;

        int gridSize = level.GridSize;
        float offset = (gridSize - 1) * spacing / 2f;

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject tile = Instantiate(tilePrefab, transform);
                tile.transform.localPosition = new Vector3(x * spacing - offset, y * spacing - offset, 0);

                PuzzleTile puzzleTile = tile.GetComponent<PuzzleTile>();

                // Randomly assign Green/Red
                puzzleTile.tileType = (Random.value > 0.5f) ? PuzzleTile.TileType.Green : PuzzleTile.TileType.Red;

                var sr = tile.GetComponent<SpriteRenderer>();
                if (sr != null)
                    sr.color = (puzzleTile.tileType == PuzzleTile.TileType.Green) ? Color.green : Color.red;

                if (puzzleTile.tileType == PuzzleTile.TileType.Green)
                    totalGreenTiles++;

                activeTiles.Add(tile);
            }
        }

        Debug.Log($"Level Generated: TotalGreenTiles = {totalGreenTiles}");
    }

    public void GreenTileClicked()
    {
        greenTilesClicked++;
        Debug.Log($"Green Tiles Clicked: {greenTilesClicked}/{totalGreenTiles}");

        if (greenTilesClicked >= totalGreenTiles)
        {
            Debug.Log("All green tiles clicked! Level Won!");
            GameEvents.OnLevelWin?.Invoke();
        }
    }

    public void ResetController()
    {
        foreach (var tile in activeTiles)
            Destroy(tile);

        activeTiles.Clear();
        totalGreenTiles = 0;
        greenTilesClicked = 0;
    }
}
