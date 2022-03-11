using UnityEngine;

namespace Tetris.Models
{
    public interface IReadOnlyCell
    {
        public Color Color { get; }
    }

    public class Cell : IReadOnlyCell
    {
        private readonly Color _color;

        public Cell(Color color)
        {
            _color = color;
        }

        public Color Color => _color;

        public void Make() { }
    }
}