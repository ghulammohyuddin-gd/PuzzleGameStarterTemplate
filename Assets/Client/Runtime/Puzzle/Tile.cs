using System;
using PuzzleTemplate.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client.Runtime
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class Tile : MonoBehaviour, IPointerClickHandler
    {
        public event Action OnClick;

        private SpriteRenderer _sr;

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
            _sr.color = type switch
            {
                TileType.Green => Color.green,
                TileType.Red => Color.red,
                _ => Color.gray
            };
        }

        private void Awake()
        {
            _sr = GetComponent<SpriteRenderer>();
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
