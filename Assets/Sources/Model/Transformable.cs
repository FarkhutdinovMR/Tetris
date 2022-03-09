using UnityEngine;

namespace Tetris.Models
{
    public class Transformable
    {
        public Transformable(Vector2Int position)
        {
            Position = position;
        }

        public Vector2Int Position { get; private set; }

        public void Move(Vector2Int position)
        {
            Position += position;
        }
    }
}