using UnityEngine;

namespace Tetris.Models
{
    public class Transformable : IMovement
    {
        private Vector2Int _position;

        public Transformable(Vector2Int position)
        {
            _position = position;
        }

        public Vector2Int Position => _position;

        public void Move(Vector2Int position)
        {
            _position += position;
        }

        public void Rotate(int direction)
        {
            throw new System.NotImplementedException();
        }
    }
}