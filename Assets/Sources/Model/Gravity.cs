using System;
using UnityEngine;

namespace Tetris.Models
{
    public class Gravity : IMovement
    {
        private readonly IMovement _movement;
        private readonly float _delay;
        private float _runningTime;

        public Gravity(IMovement movement, float delay)
        {
            if (movement == null)
                throw new ArgumentNullException(nameof(movement));

            if (delay <= 0)
                throw new ArgumentOutOfRangeException(nameof(delay));

            _movement = movement;
            _delay = delay;
        }

        public Vector2Int Position => _movement.Position;

        public void Move(Vector2Int position) => _movement.Move(position);

        public void Rotate(int direction) => _movement.Rotate(direction);

        public void Update(float deltaTime)
        {
            _runningTime += deltaTime;

            if (_runningTime > 1f / _delay)
            {
                _movement.Move(Vector2Int.down);
                _runningTime = 0;
            }
        }
    }
}