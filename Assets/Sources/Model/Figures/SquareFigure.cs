using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class SquareFigure : IFigureFactory
    {
        public Figure Create()
        {
            var color = Color.red;

            Shape rotation_1 = new Shape(new List<ICell>
            {
                new Pixel(new Vector2Int(-1, 0), color),
                new Pixel(new Vector2Int(-1, 1), color),
                new Pixel(new Vector2Int(0, 0), color),
                new Pixel(new Vector2Int(0, 1), color),
            });

            var rotations = new Shape[] { rotation_1 };

            return new Figure(rotations, 1);
        }
    }
}
