using System;
using System.Collections.Generic;

namespace Tetris.Models
{
    public class Figure
    {
        private readonly Shape[] _rotations;
        private readonly int _id;
        private int _angle;

        public Figure(Shape[] rotations, int id)
        {
            if (rotations == null)
                throw new ArgumentNullException(nameof(rotations));

            _rotations = rotations;
            _id = id;
        }

        public event Action<IEnumerable<ICell>> CellsChanged;

        public event Action Destroed;

        public int Id => _id;

        public IEnumerable<ICell> Cells => _rotations[_angle].Cells;

        public void Rotate(int direction)
        {
            if (direction == 0)
                throw new ArgumentOutOfRangeException(nameof(direction));

            _angle = Repeat(_angle + direction, _rotations.Length);

            CellsChanged?.Invoke(Cells);
        }

        public IEnumerable<ICell> GetRotatedCells(int direction)
        {
            return _rotations[Repeat(_angle + direction, _rotations.Length)].Cells;
        }

        public void Destroy()
        {
            Destroed?.Invoke();
        }

        private int Repeat(int value, int length)
        {
            if (value >= length)
                return 0;
            else if (value < 0)
                return length - 1;

            return value;
        }
    }
}