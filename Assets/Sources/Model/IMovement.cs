using UnityEngine;

namespace Tetris.Models
{
    public interface IMovement
    {
        public void Move(Vector2Int direction);
    }

    public interface IRotation
    {
        public void Rotate(int direction);
    }
}