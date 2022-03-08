using UnityEngine;

namespace Tetris.Models
{
    public class Transformable : ITransform
    {
        public Transformable(Vector2Int position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public Vector2Int Position { get; private set; }

        public float Rotation { get; private set; }

        public void Move(Vector2Int position)
        {
            Position += position;
        }

        public void Rotate(int direction) { }
    }
}