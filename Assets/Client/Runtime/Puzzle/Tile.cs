using System;
using PuzzleTemplate.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Client.Runtime
{
    [RequireComponent(typeof(Image))]
    public sealed class Tile : MonoBehaviour, IPointerClickHandler, ICommand
    {
        public event Action<Tile> OnClick;

        private Image _img;

        private TileType _cached;
        public TileType Type { get; private set; }

        public void OnPointerClick(PointerEventData eventData) => Execute();

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

        public void Execute()
        {
            if (Type == TileType.Tapped) return;

            SetType(TileType.Tapped);
            OnClick.SafeInvoke(this);
        }

        public void Undo() => SetType(_cached);
    }

    public enum TileType
    {
        Tapped = 0,
        Green,
        Red
    }
}
