using System;
using System.Collections.Generic;

namespace Tetris.Models
{
    public class Rotation
    {
        private readonly IReadOnlyList<IReadOnlyCell> _cells;

        public Rotation(IReadOnlyList<IReadOnlyCell> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            _cells = cells;
        }

        public IReadOnlyList<IReadOnlyCell> Cells => _cells;
    }
}