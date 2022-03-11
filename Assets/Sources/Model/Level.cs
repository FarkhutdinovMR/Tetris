using System;

namespace Tetris.Models
{
    public class Level
    {
        private readonly int _lineToLevelUp;
        private int _value;

        public Level(int lineToLevelUp)
        {
            if (lineToLevelUp <= 0)
                throw new ArgumentOutOfRangeException(nameof(lineToLevelUp));

            _lineToLevelUp = lineToLevelUp;
            _value = 1;
        }

        public int Value => _value;

        public event Action<int> Changed;

        public void Update(int line)
        {
            if (line < 0)
                throw new ArgumentOutOfRangeException(nameof(line));

            if (line >= _lineToLevelUp * _value)
                Up();
        }

        private void Up()
        {
            _value++;
            Changed?.Invoke(_value);
        }
    }
}