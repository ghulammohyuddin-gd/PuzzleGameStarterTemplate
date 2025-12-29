using PuzzleTemplate.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Runtime
{
    [RequireComponent(typeof(Image))]
    public sealed class Tile : ClickController, ICommand
    {
        private Image _img;
        private TileType _cached;

        public TileType Type { get; private set; }

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

        public void Execute() => SetType(TileType.Tapped);

        public void Undo() => SetType(_cached);

        protected override void OnClicked() => SetType(TileType.Tapped);
    }

    public enum TileType
    {
        Tapped = 0,
        Green,
        Red
    }
}
