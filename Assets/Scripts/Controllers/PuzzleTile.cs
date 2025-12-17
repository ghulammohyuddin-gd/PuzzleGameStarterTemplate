using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    public enum TileType { Green, Red }
    public TileType tileType;

    private bool clicked = false;
    public bool IsClicked => clicked;

    public void HandleClick()
    {
        if (clicked) return;
        clicked = true;

        // Reduce moves
        MoveCounter.Instance?.UseMove();

        // Notify PuzzleController if green
        if (tileType == TileType.Green)
            PuzzleController.Instance?.GreenTileClicked();

        // Gray out tile
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = Color.gray;

        // Play click sound
        AudioManager.Instance?.PlaySFX(null);
    }
}
