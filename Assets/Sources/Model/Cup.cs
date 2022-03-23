using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Models
{
    public class Cup : IShape
    {
        private readonly IShape _shape;
        private readonly Size _size;

        public Cup(IShape shape, Size size)
        {
            if (shape == null)
                throw new ArgumentNullException(nameof(shape));

            if (size == null)
                throw new ArgumentNullException(nameof(size));

            _shape = shape;
            _size = size;
        }

        public event Action<IEnumerable<ICell>> CellsChanged;

        public IEnumerable<ICell> Cells => _shape.Cells;

        public Size Size => _size;

        public void AddCells(IEnumerable<ICell> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            if (IsCollision(cells) == true)
                throw new InvalidOperationException();

            _shape.AddCells(cells);

            CellsChanged?.Invoke(Cells);
        }

        public void RemoveCells(IEnumerable<ICell> cells)
        {
            _shape.RemoveCells(cells);

            CellsChanged?.Invoke(Cells);
        }

        public bool IsCollision(IEnumerable<ICell> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            IEnumerable<ICell> outOfRangeCells = cells.Where(cell => cell.Position.x < 0 || cell.Position.x >= _size.Width
            || cell.Position.y < 0 || cell.Position.y >= _size.Height);

            if (outOfRangeCells.Count() > 0)
                return true;

            return _shape.IsCollision(cells);
        }

        public void Clear()
        {
            _shape.Clear();
        }

        public void ChangeCells()
        {
            CellsChanged?.Invoke(Cells);
        }
    }
}