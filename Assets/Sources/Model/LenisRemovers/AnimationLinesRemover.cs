using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Models
{
    public class AnimationLinesRemover : TimeLinesRemover
    {
        private int _offset;

        public AnimationLinesRemover(Cup cup, Action onEnd, float speed, int repeat) : base(cup, onEnd, speed, repeat) { }

        public int LineCenter => Cup.Size.Width / 2;

        protected override void OnUpdate()
        {
            List<ICell> removingCells = new List<ICell>();

            removingCells.AddRange(RemovingCells.Where(cell => cell.Position.x == LineCenter - 1 - _offset || cell.Position.x == LineCenter + _offset));
            Cup.RemoveCells(removingCells);
            _offset++;
        }
    }
}