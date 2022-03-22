using UnityEngine;

namespace Tetris.Models
{
    public class Cell : ICell
    {
        public Vector2Int Position { get; private set; }

        public Cell(Vector2Int position)
        {
            Position = position;
        }

        public virtual ICell Move(Vector2Int position)
        {
            return new Cell(Position + position);
        }
    }
}