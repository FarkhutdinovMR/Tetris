using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    class ZFigure : IFigure
    {
        public Figure Create()
        {
            var cell = new Cell(Color.gray);

            Shape shape_1 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(0, 0), cell },
                { new Vector2Int(1, 0), cell },
                { new Vector2Int(-1, 1), cell },
                { new Vector2Int(0, 1), cell },
            });

            Shape shape_2 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(0, 0), cell },
                { new Vector2Int(0, 1), cell },
                { new Vector2Int(1, 1), cell },
                { new Vector2Int(1, 2), cell },
            });

            var shapes = new Shape[] { shape_1, shape_2 };

            return new Figure(shapes, 5);
        }
    }
}
