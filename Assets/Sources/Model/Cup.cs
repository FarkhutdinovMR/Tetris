using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tetris.Models
{
    public class Cup : ILineRemover
    {
        private readonly List<Cell> _cells = new List<Cell>();
        private readonly int _width;
        private readonly int _height;
        
        private Action<IEnumerable<int>> _linesRemovers;
        private Timer<IEnumerable<Cell>, List<int>> _timer;
        private int _slowRemoverCount;

        public Cup(int width, int height)
        {
            if (width < 0)
                throw new ArgumentOutOfRangeException(nameof(width));

            if (height < 0)
                throw new ArgumentOutOfRangeException(nameof(height));

            _width = width;
            _height = height;

            _linesRemovers = AnimationRemoveLine;
        }

        public event Action<IReadOnlyList<IReadOnlyCell>> CellsChanged;

        public event Action<int> LineDeleted;

        public event Action spawnFigure;

        public IReadOnlyList<IReadOnlyCell> Cells => _cells;

        public int Width => _width;

        public int Height => _height;

        public bool ContainCell(Vector2Int position)
        {
            return _cells.FindIndex(cell => cell.Position == position) >= 0;
        }

        public bool TryAddCells(IReadOnlyList<IReadOnlyCell> cells, Vector2Int offset)
        {
            foreach (Cell cell in cells)
            {
                Vector2Int position = cell.Position + offset;

                if (CheckCellOutOfRange(position))
                    throw new ArgumentOutOfRangeException(nameof(cells));

                // If new cell position contain in _cells then game over
                if (_cells.FindIndex(c => c.Position == position) >= 0)
                    return false;

                _cells.Add(new Cell(position, cell.Color));
            }

            CellsChanged?.Invoke(_cells);
            return true;
        }

        public void Update(float deltaTime)
        {
            if (_timer != null)
                _timer.Tick(deltaTime);
        }

        public void DeleteLines()
        {
            List<int> lines = FindLines();

            if (lines.Count == 0)
            {
                spawnFigure?.Invoke();
                return;
            }

            _linesRemovers.Invoke(lines);
        }

        private bool CheckCellOutOfRange(Vector2Int position)
        {
            return (position.x >= 0 && position.x < Width && position.x >= 0 && position.x < Height) == false;
        }

        private List<int> FindLines()
        {
            List<int> lines = new List<int>();

            for (int i = 0; i < _height; i++)
            {
                if (_cells.Where(cell => cell.Position.y == i).Count() == Width)
                    lines.Add(i);
            }

            return lines;
        }

        private void MoveDownCells(List<int> lines)
        {
            for (int i = 0; i < lines.Count;)
            {
                int lineDeleted = CalculateLineInRowAt(lines.ToArray(), i);

                IEnumerable<Cell> cells = _cells.
                    Where(cell => cell.Position.y >= lines[i] + lineDeleted).
                    OrderBy(cell => cell.Position.y);

                foreach(Cell cell in cells)
                    MoveCell(cell, new Vector2Int(cell.Position.x, cell.Position.y - lineDeleted));

                i += lineDeleted;
            }

            LineDeleted?.Invoke(lines.Count);
            spawnFigure?.Invoke();
            CellsChanged?.Invoke(_cells);
        }

        private int CalculateLineInRowAt(int[] lines, int start)
        {
            int count = 1;

            for (int i = start; i < lines.Length - 1; i++)
            {
                if (lines[i + 1] - lines[i] == 1)
                    count++;
            }

            return count;
        }

        private void MoveCell(Cell cell, Vector2Int position)
        {
            int index = _cells.FindIndex(c => c == cell);
            _cells[index] = cell.Move(position);
        }

        private void DefaultRemoveLine(IEnumerable<int> lines)
        {
            foreach (int y in lines)
                _cells.RemoveAll(cell => cell.Position.y == y);
        }

        private void AnimationRemoveLine(IEnumerable<int> lines)
        {
            List<Cell> cells = new List<Cell>();

            foreach (int y in lines)
                cells.AddRange(_cells.Where(cell => cell.Position.y == y));

            _slowRemoverCount = 0;
            _timer = new Timer<IEnumerable<Cell>, List<int>>(0.1f, Width / 2, SlowRemoveCells, MoveDownCells, cells, lines.ToList());
        }

        private void SlowRemoveCells(IEnumerable<Cell> cells)
        {
            int center = Width / 2;

            List<Cell> removingCells = new List<Cell>();

            removingCells.AddRange(cells.Where(cell => cell.Position.x == center - 1 - _slowRemoverCount || cell.Position.x == center + _slowRemoverCount));

            foreach (Cell cell in removingCells)
                _cells.Remove(cell);

            _slowRemoverCount++;
            CellsChanged?.Invoke(_cells);
        }
    }
}