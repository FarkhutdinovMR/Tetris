using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    class SquareFigure : IFigureFactory
    {
        public Figure Create()
        {
            var color = Color.red;

            Rotation rotation_1 = new Rotation(new List<Cell>
            {
                new Cell(new Vector2Int(-1, 0), color),
                new Cell(new Vector2Int(-1, 1), color),
                new Cell(new Vector2Int(0, 0), color),
                new Cell(new Vector2Int(0, 1), color)
            });

            var rotations = new Rotation[] { rotation_1 };

            return new Figure(rotations, 1);
        }
    }
}
