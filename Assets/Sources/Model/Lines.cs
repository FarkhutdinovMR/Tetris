using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tetris.Models
{
    public class Lines
    {
        private const int Tetris = 4;

        private readonly Cup _cup;

        private ILinesRemover _linesRemover;
        private int[] _lines;
        private bool _isActive;

        public Lines(Cup cup)
        {
            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            _cup = cup;
        }

        public event Action<int> LineDeleted;

        public int Length => _cup.Size.Width;

        public void Update(float deltaTime)
        {
            if (_linesRemover != null)
                _linesRemover.Update(deltaTime);
        }

        public void Upadate(IEnumerable<ICell> cells)
        {
            if (_isActive)
                return;

            _lines = Find(cells);

            if (_lines.Count() == Tetris)
            {
                _linesRemover = new BlinkLinesRemover(_cup, OnLineRemoved, 0.05f, 6);
            }
            else if (_lines.Count() > 0)
            {
                _linesRemover = new AnimationLinesRemover(_cup, OnLineRemoved, 0.1f, _cup.Size.Width / 2);
            }
            else
            {
                LineDeleted?.Invoke(_lines.Count());
                return;
            }

            _isActive = true;
            _linesRemover.Remove(_lines);
        }

        private int[] Find(IEnumerable<ICell> cells)
        {
            List<int> lines = new List<int>();

            for (int i = 0; i < _cup.Size.Height; i++)
                if (cells.Count(cell => cell.Position.y == i) == Length)
                    lines.Add(i);

            return lines.ToArray();
        }

        private void OnLineRemoved()
        {
            LowerCells();
            LineDeleted?.Invoke(_lines.Count());
            _isActive = false;
        }

        private void LowerCells()
        {
            var newCells = new List<ICell>();

            foreach (ICell cell in _cup.Cells)
            {
                int offset = _lines.Count(line => line < cell.Position.y);
                newCells.Add(cell.Move(new Vector2Int(0, -offset)));
            }

            _cup.Clear();
            _cup.AddCells(newCells);
        }
    }
}