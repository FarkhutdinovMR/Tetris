using UnityEngine;

namespace Tetris.Models
{
    public class Shape
    {
        public Shape(Vector2Int[] position)
        {
            Cells = position;
        }

        public Vector2Int[] Cells { get; private set; }
    }
}