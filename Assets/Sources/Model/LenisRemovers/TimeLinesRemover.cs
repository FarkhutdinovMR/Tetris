using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Models
{
    public abstract class TimeLinesRemover : ILinesRemover
    {
        private readonly Action _onEnd;
        private readonly float _speed;
        private readonly int _repeat;

        protected Cup Cup { get; private set; }
        protected List<ICell> RemovingCells = new List<ICell>();

        private Timer _timer;

        public TimeLinesRemover(Cup cup, Action onEnd, float speed, int repeat)
        {
            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            Cup = cup;
            _onEnd = onEnd;
            _speed = speed;
            _repeat = repeat;
        }

        public void Remove(int[] lines)
        {
            foreach (int y in lines)
                RemovingCells.AddRange(Cup.Cells.Where(cell => cell.Position.y == y));

            _timer = new Timer(_speed, _repeat, OnUpdate, OnEnd);
        }

        public void Update(float deltaTime)
        {
            if (_timer != null)
                _timer.Tick(deltaTime);
        }

        protected virtual void OnUpdate() { }

        protected virtual void OnEnd()
        {
            _onEnd.Invoke();
        }
    }
}