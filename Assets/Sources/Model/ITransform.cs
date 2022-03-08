using UnityEngine;

namespace Tetris.Models
{
    public interface ITransform
    {
        public void Move(Vector2Int position);
        public void Rotate(int direction);
    }
}