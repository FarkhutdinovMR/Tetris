using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class Shape
    {
        private readonly Dictionary<Vector2Int, Cell> _cells;

        public Shape(Dictionary<Vector2Int, Cell> cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            _cells = cells;
        }

        public Dictionary<Vector2Int, Cell> Cells => _cells;
    }
}