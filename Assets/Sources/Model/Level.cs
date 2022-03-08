using System;

namespace Tetris.Models
{
    public class Level
    {
        private readonly Statistics _statistics;
        private readonly int _lineToLevelUp;

        public Level(Statistics statistics, int lineToLevelUp)
        {
            if (statistics == null)
                throw new ArgumentNullException(nameof(statistics));

            if (lineToLevelUp <= 0)
                throw new ArgumentOutOfRangeException(nameof(lineToLevelUp));

            _statistics = statistics;
            _lineToLevelUp = lineToLevelUp;
            Value = 1;
        }

        public int Value { get; private set; }

        public event Action<int> Changed;

        public void OnEnable()
        {
            _statistics.ValueChanged += OnValueChanged;
        }

        public void OnDisable()
        {
            _statistics.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged(int score, int line)
        {
            Calculate(line);
        }

        private void Calculate(int line)
        {
            if (line >= _lineToLevelUp * Value)
                Up();
        }

        private void Up()
        {
            Value++;
            Changed?.Invoke(Value);
        }
    }
}