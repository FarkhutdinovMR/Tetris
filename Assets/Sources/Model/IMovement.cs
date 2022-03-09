using UnityEngine;

namespace Tetris.Models
{
    public interface IMovement
    {
        public void TryMove(Vector2Int position);
        public void TryRotate(int direction);
    }
}