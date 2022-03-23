using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Models
{
    public class Shape : IShape
    {
        private readonly List<ICell> _cells = new List<ICell>();

        public Shape() { }

        public Shape(List<ICell> cells)
        {
            AddCells(cells);
        }

        public IEnumerable<ICell> Cells => _cells;

        public void AddCells(IEnumerable<ICell> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            if (IsCollision(cells) == true)
                throw new InvalidOperationException();

            foreach (ICell cell in cells)
                _cells.Add(cell);
        }

        public void RemoveCells(IEnumerable<ICell> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            foreach (ICell cell in cells)
                _cells.Remove(cell);
        }

        public bool IsCollision(IEnumerable<ICell> cells)
        {
            CellComparer cellComparer = new CellComparer();

            foreach (ICell cell in cells)
                if (_cells.Contains(cell, cellComparer))
                    return true;

            return false;
        }

        public void Clear()
        {
            _cells.Clear();
        }
    }
}