using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Models
{
    public class AnimationLinesRemover : ILinesRemover
    {
        private readonly Cup _cup;
        private readonly Action _onEnd;
        private readonly float _speed = 0.1f;
        private readonly List<ICell> _removingCells = new List<ICell>();

        private Timer _timer;
        private int _offset;

        public AnimationLinesRemover(Cup cup, Action onEnd)
        {
            _cup = cup;
            _onEnd = onEnd;
        }

        public int LineCenter => _cup.Size.Width / 2;

        public void Remove(int[] lines)
        {
            foreach (int y in lines)
                _removingCells.AddRange(_cup.Cells.Where(cell => cell.Position.y == y));

            _timer = new Timer(_speed, LineCenter, OnUpdate, () => _onEnd.Invoke());
        }

        public void Update(float deltaTime)
        {
            if (_timer != null)
                _timer.Tick(deltaTime);
        }

        private void OnUpdate()
        {
            List<ICell> removingCells = new List<ICell>();

            removingCells.AddRange(_removingCells.Where(cell => cell.Position.x == LineCenter - 1 - _offset || cell.Position.x == LineCenter + _offset));
            _cup.RemoveCells(removingCells);
            _offset++;
        }
    }
}