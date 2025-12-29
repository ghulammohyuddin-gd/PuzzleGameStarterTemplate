using PuzzleTemplate.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Client.Runtime
{
    [RequireComponent(typeof(Image))]
    public sealed class TileDraggable : DragController
    {

        public void SetType(TileType type, bool cache = false)
        {
            if (cache)
            {
                _cached = type;
            }

            Type = type;
            _img.color = type switch
            {
                TileType.Green => Color.green,
                TileType.Red => Color.red,
                _ => Color.gray
            };
        }

        private void Awake()
        {
            _img = GetComponent<Image>();
            SetType(TileType.Tapped);
        }

        protected override void OnDragEnded(PointerEventData eventData)
        {
        }

        protected override void OnDragging(PointerEventData eventData)
        {
        }

        protected override void OnDragStarted(PointerEventData eventData)
        {
        }
    }
}