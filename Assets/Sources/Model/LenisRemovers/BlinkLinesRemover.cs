using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tetris.Models
{
    public class BlinkLinesRemover : ILinesRemover
    {
        private readonly Cup _cup;
        private readonly Action _onEnd;
        private readonly List<ICell> _removingCells = new List<ICell>();

        private Timer _timer;
        private float _color;

        public BlinkLinesRemover(Cup cup, Action onEnd)
        {
            _cup = cup;
            _onEnd = onEnd;
        }

        public void Remove(int[] lines)
        {
            foreach (int y in lines)
                _removingCells.AddRange(_cup.Cells.Where(cell => cell.Position.y == y));

            _timer = new Timer(0.05f, 6, OnUpdate, OnEnd);
        }

        public void Update(float deltaTime)
        {
            if (_timer != null)
                _timer.Tick(deltaTime);
        }

        private void OnUpdate()
        {
            _color += 0.5f;
            _color = Mathf.Repeat(_color, 1);

            foreach (Pixel cell in _removingCells)
                cell.Repaint(new Color(_color, _color, _color));

            _cup.ChangeCells();
        }

        private void OnEnd()
        {
            _cup.RemoveCells(_removingCells);
            _onEnd.Invoke();
        }
    }
}