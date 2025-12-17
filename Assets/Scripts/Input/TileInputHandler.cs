using UnityEngine;

public class TileInputHandler : MonoBehaviour
{
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                PuzzleTile tile = hit.collider.GetComponent<PuzzleTile>();
                if (tile != null && !tile.IsClicked)
                {
                    tile.HandleClick();
                }
            }
        }
    }
}
