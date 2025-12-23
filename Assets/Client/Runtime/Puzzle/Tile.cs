using System;
using PuzzleTemplate.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Client.Runtime
{
    [RequireComponent(typeof(Image))]
    public sealed class Tile : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnClick;

        private Image _img;

        public TileType Type { get; private set; }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Type == TileType.Tapped) return;

            SetType(TileType.Tapped);
            OnClick.SafeInvoke();
        }

        public void SetType(TileType type)
        {
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
    }

    public enum TileType
    {
        Tapped = 0,
        Green,
        Red
    }
}
