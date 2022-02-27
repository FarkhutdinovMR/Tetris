using System;
using UnityEngine;

namespace Tetris.Models
{
    public class Gravity
    {
        private Transformable _transformable;
        private float _delay;
        private float _runningTime;

        public Gravity(Transformable transformable, float delay)
        {
            if (transformable == null)
                throw new ArgumentNullException(nameof(transformable));

            if (delay < 0)
                throw new ArgumentOutOfRangeException(nameof(delay));

            _transformable = transformable;
            _delay = delay;
        }

        public void Update(float deltaTime)
        {
            _runningTime += deltaTime;

            if (_runningTime > _delay)
            {
                _transformable.Translate(Vector2.down);
                _runningTime = 0;
            }
        }
    }
}