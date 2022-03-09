using System;
using UnityEngine;

namespace Tetris.Models
{
    public class Gravity
    {
        private readonly IMovement _transform;
        private readonly float _delay;
        private float _runningTime;

        public Gravity(IMovement transform, float delay)
        {
            if (transform == null)
                throw new ArgumentNullException(nameof(transform));

            if (delay <= 0)
                throw new ArgumentOutOfRangeException(nameof(delay));

            _transform = transform;
            _delay = delay;
        }

        public void Update(float deltaTime)
        {
            _runningTime += deltaTime;

            if (_runningTime > 1f / _delay)
            {
                _transform.TryMove(Vector2Int.down);

                _runningTime = 0;
            }
        }
    }
}