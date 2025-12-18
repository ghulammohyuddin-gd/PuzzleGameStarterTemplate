using Client.Runtime.Controllers;
using Client.Runtime.Input.Interfaces;
using UnityEngine;

namespace Client.Runtime.Input
{
    /// <summary>Handles mouse input detection and tile raycasting.</summary>
    public class TileInputHandler : MonoBehaviour, IInputHandler
    {
        private Camera mainCamera;
        private bool inputEnabled = true;

        private void Start()
        {
            mainCamera = Camera.main;
            if (mainCamera == null)
                Debug.LogError("TileInputHandler: Main camera not found!");
        }

        private void Update()
        {
            if (!inputEnabled || mainCamera == null)
                return;

            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                if (TryGetTileAtPosition(mousePos, out PuzzleTile tile))
                {
                    tile.HandleClick();
                }
            }
        }

        /// <summary>Enables input detection.</summary>
        public void EnableInput()
        {
            inputEnabled = true;
        }

        /// <summary>Disables input detection.</summary>
        public void DisableInput()
        {
            inputEnabled = false;
        }

        /// <summary>Attempts to get the tile at the specified world position via raycast.</summary>
        public bool TryGetTileAtPosition(Vector2 worldPosition, out PuzzleTile tile)
        {
            tile = null;
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null)
            {
                PuzzleTile foundTile = hit.collider.GetComponent<PuzzleTile>();
                if (foundTile != null && !foundTile.IsClicked)
                {
                    tile = foundTile;
                    return true;
                }
            }

            return false;
        }
    }
}
