using System;

namespace Tetris.Models
{
    public class Figure
    {
        public Figure(Shape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            Shape = shape;
        }

        public Shape Shape { get; private set; }
    }
}