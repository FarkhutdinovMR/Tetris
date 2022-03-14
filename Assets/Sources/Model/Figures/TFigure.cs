using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class TFigure : IFigure
    {
        public Figure Create()
        {
            var cell = new Cell(Color.white);

            Shape shape_1 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(0, 0), cell },
                { new Vector2Int(-1, 1), cell },
                { new Vector2Int(0, 1), cell },
                { new Vector2Int(1, 1), cell },
            });

            Shape shape_2 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(0, 0), cell },
                { new Vector2Int(0, 1), cell },
                { new Vector2Int(0, 2), cell },
                { new Vector2Int(-1, 1), cell },
            });

            Shape shape_3 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(0, 2), cell },
                { new Vector2Int(-1, 1), cell },
                { new Vector2Int(0, 1), cell },
                { new Vector2Int(1, 1), cell },
            });

            Shape shape_4 = new Shape(new Dictionary<Vector2Int, Cell>
            {
                { new Vector2Int(0, 0), cell },
                { new Vector2Int(0, 1), cell },
                { new Vector2Int(0, 2), cell },
                { new Vector2Int(1, 1), cell },
            });

            var shapes = new Shape[] { shape_1, shape_2, shape_3, shape_4 };

            return new Figure(shapes, 7);
        }
    }
}