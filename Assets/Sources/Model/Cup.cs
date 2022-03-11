using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tetris.Models
{
    public interface ILineRemover
    {
        public event Action<int> LineDeleted;
    }

    public interface ICup
    {
        public IReadOnlyDictionary<Vector2Int, Cell> Cells { get; }

        public int Width { get; }

        public int Height { get; }

        public event Action<IReadOnlyDictionary<Vector2Int, Cell>> CellsChanged;
    }

    public class Cup : ICup, ILineRemover
    {
        private readonly Dictionary<Vector2Int, Cell> _cells = new Dictionary<Vector2Int, Cell>();
        private readonly int _width;
        private readonly int _height;

        public Cup(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public event Action<IReadOnlyDictionary<Vector2Int, Cell>> CellsChanged;

        public event Action<int> LineDeleted;

        public IReadOnlyDictionary<Vector2Int, Cell> Cells => _cells;

        public int Width => _width;

        public int Height => _height;

        public bool ContainCell(Vector2Int position)
        {
            return _cells.ContainsKey(position);
        }

        public void AddCells(IReadOnlyDictionary<Vector2Int, Cell> cells, Vector2Int offset)
        {
            foreach (KeyValuePair<Vector2Int, Cell> cell in cells)
            {
                Vector2Int position = cell.Key + offset;

                if (CheckCellOutOfRange(position))
                    throw new ArgumentOutOfRangeException(nameof(cells));

                _cells.Add(position, cell.Value);
            }

            DeleteLines();
            CellsChanged?.Invoke(_cells);
        }

        private bool CheckCellOutOfRange(Vector2Int position)
        {
            return (position.x >= 0 && position.x < Width && position.x >= 0 && position.x < Height) == false;
        }

        private void DeleteLines()
        {
            List<int> lines = FindLines();

            if (lines.Count == 0)
                return;

            RemoveLines(lines);
            MoveDownCells(lines);

            LineDeleted?.Invoke(lines.Count);
        }

        private List<int> FindLines()
        {
            List<int> lines = new List<int>();

            for (int i = 0; i < _height; i++)
            {
                if (_cells.Keys.Where(key => key.y == i).Count() == Width)
                    lines.Add(i);
            }

            return lines;
        }

        private void RemoveLines(List<int> lines)
        {
            foreach(int y in lines)
            {
                List<Vector2Int> cells = _cells.Keys.Where(position => position.y == y).ToList();

                foreach (Vector2Int position in cells)
                    _cells.Remove(position);
            }
        }

        private void MoveDownCells(List<int> lines)
        {
            for (int i = 0; i < lines.Count;)
            {
                int offset = 1;

                for (int j = i; j < lines.Count; j++)
                {
                    if (i + j + 1 < lines.Count && lines[i + j + 1] - lines[i + j] == 1)
                        offset++;
                }

                Vector2Int[] cells = _cells.Keys.
                    Where(position => position.y >= lines[i] + offset).
                    OrderBy(position => position.y).
                    ToArray();

                foreach (Vector2Int position in cells)
                    ReplaceCell(new Vector2Int(position.x, position.y - offset), position);

                i += offset;
            }
        }

        private void ReplaceCell(Vector2Int newCell, Vector2Int oldCell)
        {
            _cells.Add(newCell, _cells[oldCell]);
            _cells.Remove(oldCell);
        }
    }
}