using System;
using UnityEngine;

namespace Tetris.Models
{
    public class GameOver
    {
        private readonly Cup _cup;
        private readonly int _maxPosition;

        private bool _isEndGame;

        public GameOver(Cup cup, int maxPosition)
        {
            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            if (maxPosition < 0)
                throw new ArgumentOutOfRangeException(nameof(maxPosition));

            _cup = cup;
            _maxPosition = maxPosition;
            _cup.Changed += OnChanged;
        }

        public event Action Ended;

        public void OnDisable()
        {
            _cup.Changed -= OnChanged;
        }

        private void OnChanged()
        {
            Update();
        }

        private void Update()
        {
            if (_isEndGame)
                throw new InvalidOperationException();

            for (int i = 0; i < _cup.Width; i++)
            {
                if (_cup.IsEmpty(new Vector2Int(i, _maxPosition)) == false)
                {
                    _isEndGame = true;
                    Ended?.Invoke();
                    _cup.Changed -= OnChanged;
                    return;
                }
            }
        }
    }
}