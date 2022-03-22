using UnityEngine;

namespace Tetris.Models
{
    public class Pixel : Cell
    {
        private Color _color;

        public Pixel(Vector2Int position, Color color) : base(position)
        {
            _color = color;
        }

        public Color Color => _color;

        public override ICell Move(Vector2Int position)
        {
            return new Pixel(Position + position, _color);
        }

        public void Repaint(Color newColor)
        {
            _color = newColor;
        }
    }
}