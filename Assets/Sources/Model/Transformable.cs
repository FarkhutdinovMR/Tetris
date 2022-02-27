using System;
using UnityEngine;

namespace Tetris.Models
{
    public class Transformable
    {
        private bool _isActive;

        public Transformable(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
            _isActive = true;
        }

        public event Action Moved;

        public Vector2 Position { get; private set; }

        public float Rotation { get; private set; }

        public void Translate(Vector2 position)
        {
            if (_isActive == false)
                return;

            Position += position;

            Moved?.Invoke();
        }

        public void Stop()
        {
            _isActive = false;
        }
    }
}