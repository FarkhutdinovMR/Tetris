using System;

namespace Tetris.Models
{
    class Timer<T1, T2>
    {
        private readonly float _time;
        private readonly int _count;
        private readonly Action<T1> _update;
        private readonly Action<T2> _onEnd;
        private readonly T1 _context1;
        private readonly T2 _context2;

        private float _accumulatedTime;
        private int _repeatCount;
        private bool _isStop;

        public Timer(float time, int count, Action<T1> update, Action<T2> onEnd, T1 context1, T2 context2)
        {
            _time = time;
            _count = count;
            _update = update;
            _onEnd = onEnd;
            _context1 = context1;
            _context2 = context2;
            _accumulatedTime = float.MaxValue;
        }

        public void Tick(float deltaTime)
        {
            if (_isStop)
                return;

            _accumulatedTime += deltaTime;

            if (_accumulatedTime >= _time)
            {
                _repeatCount++;
                _accumulatedTime = 0;
                _update.Invoke(_context1);
            }

            if (_repeatCount > _count)
            {
                _isStop = true;
                _onEnd.Invoke(_context2);
            }
        }
    }
}