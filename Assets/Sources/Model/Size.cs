using System;

namespace Tetris.Models
{
    public class Size
    {
        private readonly int _width;
        private readonly int _height;

        public Size(int width, int height)
        {
            if (width < 0)
                throw new ArgumentOutOfRangeException(nameof(width));

            if (height < 0)
                throw new ArgumentOutOfRangeException(nameof(height));

            _width = width;
            _height = height;
        }

        public int Width => _width;

        public int Height => _height;
    }
}