using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Models
{
    public class FastLinesRemover : ILinesRemover
    {
        private readonly Cup _cup;
        private readonly Action<IReadOnlyList<int>> _onEnd;

        public FastLinesRemover(Cup cup, Action<IReadOnlyList<int>> onEnd)
        {
            _cup = cup;
            _onEnd = onEnd;
        }

        public void Remove(int[] lines)
        {
            //List<ICell> removingCells = new List<ICell>();

            //foreach (int y in lines)
            //    removingCells.AddRange(_cup.Cells.Where(cell => cell.Position.y == y));

            //_cup.RemoveCells(removingCells);

            //_onEnd.Invoke(lines.ToList());
        }

        public void Update(float deltaTime) { }
    }
}