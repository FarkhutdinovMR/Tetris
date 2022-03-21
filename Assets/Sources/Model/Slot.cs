using System;

namespace Tetris.Models
{
    public class Slot
    {
        private readonly Figure _figure;
        private readonly int _count;

        public Slot(Figure figure, int count)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            _figure = figure;
            _count = count;
        }

        public Figure Figure => _figure;

        public int Count => _count;

        public Slot Increase(Figure figure)
        {
            if (figure.Id != _figure.Id)
                throw new InvalidOperationException();

            return new Slot(Figure, _count + 1);
        }
    }
}