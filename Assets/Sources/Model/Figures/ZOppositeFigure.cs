using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    class ZOppositeFigure : IFigure
    {
        public Figure Create()
        {
            var cell = new Cell(Color.yellow);

            Shape shape_1 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(-1, 0), cell },
                { new Vector2Int(0, 0), cell },
                { new Vector2Int(0, 1), cell },
                { new Vector2Int(1, 1), cell },
            });

            Shape shape_2 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(1, 0), cell },
                { new Vector2Int(1, 1), cell },
                { new Vector2Int(0, 1), cell },
                { new Vector2Int(0, 2), cell },
            });

            var shapes = new Shape[] { shape_1, shape_2 };

            return new Figure(shapes, 6);
        }
    }
}
