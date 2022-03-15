using UnityEngine;

namespace Tetris.Models
{
    public class Cell : IReadOnlyCell
    {
        private readonly Vector2Int _position;
        private readonly Color _color;

        public Cell(Vector2Int position, Color color)
        {
            _position = position;
            _color = color;
        }

        public Cell Move(Vector2Int position)
        {
            return new Cell(position, _color);
        }

        public Vector2Int Position => _position;

        public Color Color => _color;
    }
}