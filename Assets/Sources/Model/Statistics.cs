using System;
using System.Collections.Generic;

namespace Tetris.Models
{
    public class Statistics
    {
        private readonly Dictionary<int, int> _costsPerLevels;
        private int _score;
        private int _line;

        public Statistics(Dictionary<int, int> costsPerLevels)
        {
            if (costsPerLevels == null)
                throw new ArgumentNullException(nameof(costsPerLevels));

            _costsPerLevels = costsPerLevels;
        }

        public event Action<int> ScoreChanged;

        public event Action<int> LineChanged;

        public void Update(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            _score += _costsPerLevels[count];
            _line += count;

            ScoreChanged?.Invoke(_score);
            LineChanged?.Invoke(_line);
        }
    }
}