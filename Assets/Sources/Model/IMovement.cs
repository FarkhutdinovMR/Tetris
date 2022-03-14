using UnityEngine;

namespace Tetris.Models
{
    public interface IMovement
    {
        public Vector2Int Position { get; }
        public void Move(Vector2Int position);
        public void Rotate(int direction);
    }
}