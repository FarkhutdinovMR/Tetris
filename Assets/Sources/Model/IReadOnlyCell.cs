using UnityEngine;

namespace Tetris.Models
{
    public interface IReadOnlyCell
    {
        public Vector2Int Position { get; }
        public Color Color { get; }
    }
}