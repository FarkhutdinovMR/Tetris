using System;
using UnityEngine;

namespace Tetris.Models
{
    public class Shape
    {
        public Shape(bool[,] cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            Cells = cells;
        }

        public bool[,] Cells { get; private set; }

        public int Width => Cells.GetLength(0);

        public int Height => Cells.GetLength(1);

        public bool IsEmpty(int x, int y)
        {
            return Cells[x, y] == false;
        }

        public bool CheckIndexExist(int x, int y)
        {
            return (x >= 0 && x < Width && y >= 0 && y < Height);
        }
    }
}