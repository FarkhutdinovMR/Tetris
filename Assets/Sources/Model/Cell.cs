using UnityEngine;

namespace Tetris.Models
{
    public class Cell : IReadOnlyCell
    {
        private readonly Color _color;

        public Cell(Color color)
        {
            _color = color;
        }

        public Color Color => _color;
    }
}