using UnityEngine;

namespace Tetris.Models
{
    public interface ICell
    {
        public Vector2Int Position { get; }
        public ICell Move(Vector2Int position);
    }
}