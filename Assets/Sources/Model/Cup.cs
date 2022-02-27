using System;

namespace Tetris.Models
{
    public class Cup
    {
        public Cup(Shape shape)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            Shape = shape;
        }

        public Shape Shape { get; private set; }
    }
}