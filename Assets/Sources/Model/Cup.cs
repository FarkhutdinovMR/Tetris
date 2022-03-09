using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public interface ILineRemover
    {
        public event Action<int> LineDeleted;
    }

    public interface ICup
    {
        public bool[,] Cells { get; }

        public int Width { get; }

        public int Height { get; }

        public event Action CellChanged;
    }

    public class Cup : ICup, ILineRemover
    {
        public Cup(bool[,] cells)
        {
            if (cells == null)
                throw new ArgumentNullException(nameof(cells));

            Cells = cells;
        }

        public event Action CellChanged;

        public event Action<int> LineDeleted;

        public bool[,] Cells { get; private set; }

        public IReadOnlyList<bool> f;

        public int Width => Cells.GetLength(0);

        public int Height => Cells.GetLength(1);

        public bool IsEmpty(Vector2Int position)
        {
            return Cells[position.x, position.y] == false;
        }

        public bool CheckExist(Vector2Int index)
        {
            return (index.x >= 0 && index.x < Width && index.y >= 0 && index.y < Height);
        }

        public void Edit(Vector2Int[] positions, Vector2Int offset)
        {
            foreach (Vector2Int position in positions)
            {
                Vector2Int nextPosition = offset + position;

                if (CheckExist(nextPosition) == false)
                    throw new ArgumentOutOfRangeException();

                Cells[nextPosition.x, nextPosition.y] = true;
            }

            DeleteLines();
            CellChanged?.Invoke();
        }

        public bool IsLine(int y)
        {
            for (int x = 0; x < Width; x++)
            {
                if (Cells[x, y] == false)
                    return false;
            }

            return true;
        }

        private void DeleteLines()
        {
            List<int> lines = FindLines();

            if (lines.Count == 0)
                return;

            RemoveLines(lines);
            MoveDownLines(lines);

            LineDeleted?.Invoke(lines.Count);
        }

        private List<int> FindLines()
        {
            List<int> lines = new List<int>();

            for (int y = 0; y < Height; y++)
            {
                if (IsLine(y))
                    lines.Add(y);
            }

            return lines;
        }

        private void RemoveLines(List<int> lines)
        {
            foreach(int y in lines)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cells[x, y] = false;
                }
            }
        }

        private void MoveDownLines(List<int> lines)
        {
            for (int i = 0; i < lines.Count;)
            {
                int offset = 1;

                for (int j = i; j < lines.Count; j++)
                {
                    if (i + j + 1 < lines.Count && lines[i + j + 1] - lines[i + j] == 1)
                        offset++;
                }

                for (int y = lines[i];  y < Height;  y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (y + offset >= Height)
                            break;

                        Cells[x, y] = Cells[x, y + offset];
                    }
                }

                i += offset;
            }
        }
    }
}