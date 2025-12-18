using System;
using UnityEngine;

namespace Template.Runtime.Controllers
{
    /// <summary>Represents an individual puzzle tile with click and visual state management.</summary>
    public class PuzzleTile : MonoBehaviour
    {
        /// <summary>Enumeration of tile types.</summary>
        public enum TileType { Green, Red }

        /// <summary>Fired when this tile is clicked by the player.</summary>
        public static event Action<PuzzleTile> OnTileClicked;

        [SerializeField]
        private TileType typeOfTile;

        private bool isClicked;

        /// <summary>Gets or sets the tile type.</summary>
        public TileType Type
        {
            get => typeOfTile;
            set => typeOfTile = value;
        }

        /// <summary>Gets whether this tile has been clicked.</summary>
        public bool IsClicked => isClicked;

        /// <summary>Handles the click event and notifies listeners.</summary>
        public void HandleClick()
        {
            if (isClicked)
                return;

            isClicked = true;
            SetVisualStateClicked();
            OnTileClicked?.Invoke(this);
        }

        /// <summary>Sets the tile's visual appearance to the clicked state (gray).</summary>
        private void SetVisualStateClicked()
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = Color.gray;
        }

        /// <summary>Resets the tile to its initial state.</summary>
        public void Reset()
        {
            isClicked = false;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.color = (typeOfTile == TileType.Green) ? Color.green : Color.red;
        }
    }
}
