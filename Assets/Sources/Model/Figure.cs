using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class Figure
    {
        private readonly Shape[] _shapes;
        private int _index;

        public Figure(Shape[] shapes, int id)
        {
            if (shapes == null)
                throw new ArgumentNullException(nameof(shapes));

            _shapes = shapes;
            Id = id;
        }

        public event Action ShapeChanged;

        public int Id { get; private set; }

        public IReadOnlyDictionary<Vector2Int, Cell> Cells => _shapes[_index].Cells;

        public void ChangeShape(int direction)
        {
            if (direction == 0)
                throw new ArgumentOutOfRangeException(nameof(direction));

            _index = Repeat(_index + direction, _shapes.Length);

            ShapeChanged?.Invoke();
        }

        public Dictionary<Vector2Int, Cell> GetShape(int direction)
        {
            return _shapes[Repeat(_index + direction, _shapes.Length)].Cells;
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