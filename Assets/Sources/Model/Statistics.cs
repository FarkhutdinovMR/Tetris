using System;

namespace Tetris.Models
{
    public class Statistics
    {
        private readonly ILineRemover _cup;
        private readonly int _costPerLine;

        private int _score;
        private int _line;

        public Statistics(ILineRemover cup, int costPerLine)
        {
            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            if (costPerLine < 0)
                throw new ArgumentOutOfRangeException(nameof(costPerLine));

            _cup = cup;
            _costPerLine = costPerLine;
        }

        public event Action<int, int> ValueChanged;

        public void OnEnable()
        {
            _cup.LineDeleted += OnLineDeleted;
        }

        public void OnDisable()
        {
            _cup.LineDeleted -= OnLineDeleted;
        }

        private void OnLineDeleted(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            Calculate(count);
        }

        private void Calculate(int count)
        {
            _score += count * _costPerLine;
            _line += count;

            ValueChanged?.Invoke(_score, _line);
        }
    }
}