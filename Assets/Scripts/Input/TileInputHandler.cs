using Template.Runtime.Controllers;
using UnityEngine;

namespace Template.Runtime.Input
{
    public class TileInputHandler : MonoBehaviour
    {
        private Camera mainCam;

        void Start()
        {
            mainCam = Camera.main;
        }

        void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = mainCam.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
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
}
