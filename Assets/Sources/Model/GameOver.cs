using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Models
{
    public class GameOver
    {
        private readonly int _maxPosition;
        private bool _isEndGame;

        public GameOver(int maxPosition)
        {
            if (maxPosition < 0)
                throw new ArgumentOutOfRangeException(nameof(maxPosition));

            _maxPosition = maxPosition;
        }

        public event Action Ended;

        public void StopGame(IReadOnlyList<IReadOnlyCell> cells)
        {
            if (_isEndGame)
                throw new InvalidOperationException();

            if (cells.Where(cell => cell.Position.y >= _maxPosition).Count() > 0)
            {
                _isEndGame = true;
                Ended?.Invoke();
                return;
            }
        }
    }
}