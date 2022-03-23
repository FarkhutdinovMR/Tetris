using System.Collections.Generic;

namespace Tetris.Models
{
    public interface IShape
    {
        public IEnumerable<ICell> Cells { get; }

        public void AddCells(IEnumerable<ICell> cells);

        public bool IsCollision(IEnumerable<ICell> cells);

        public void RemoveCells(IEnumerable<ICell> cells);

        public void Clear();
    }
}