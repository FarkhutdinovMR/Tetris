using UnityEngine;

namespace Tetris.Models
{
    public class Cell : ICell
    {
        public Cell(Vector2Int position)
        {
            Position = position;
        }

        public Vector2Int Position { get; private set; }

        public virtual ICell Move(Vector2Int position)
        {
            return new Cell(Position + position);
        }
    }
}