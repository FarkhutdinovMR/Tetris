using System;

namespace Tetris.Models
{
    public class Timer
    {
        private readonly float _time;
        private readonly int _count;
        private readonly Action _update;
        private readonly Action _onEnd;

        private float _accumulatedTime;
        private int _repeatCount;
        private bool _isStop;

        public Timer(float interval, int cycleCount, Action update, Action onEnd)
        {
            _time = interval;
            _count = cycleCount;
            _update = update;
            _onEnd = onEnd;
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
                _update();
            }

            if (_repeatCount > _count)
            {
                _isStop = true;
                _onEnd();
            }
        }
    }
}