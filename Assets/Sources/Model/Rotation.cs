using System;
using System.Collections.Generic;

namespace Tetris.Models
{
    public class Rotation
    {
        private readonly IReadOnlyList<ICell> _cells;

        public Rotation(IReadOnlyList<ICell> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            _cells = cells;
        }

        public IReadOnlyList<ICell> Cells => _cells;
    }
}