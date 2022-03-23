using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class LOppositeFigure : IFigureFactory
    {
        public Figure Create()
        {
            var color = Color.cyan;

            Shape rotation_1 = new Shape(new List<ICell>
            {
                new Pixel(new Vector2Int(-1, 0), color),
                new Pixel(new Vector2Int(-1, 1), color),
                new Pixel(new Vector2Int(0, 1), color),
                new Pixel(new Vector2Int(1, 1), color),
            });

            Shape rotation_2 = new Shape(new List<ICell>
            {
                new Pixel(new Vector2Int(0, 0), color),
                new Pixel(new Vector2Int(0, 1), color),
                new Pixel(new Vector2Int(0, 2), color),
                new Pixel(new Vector2Int(-1, 2), color),
            });

            Shape rotation_3 = new Shape(new List<ICell>
            {
                new Pixel(new Vector2Int(-1, 1), color),
                new Pixel(new Vector2Int(0, 1), color),
                new Pixel(new Vector2Int(1, 1), color),
                new Pixel(new Vector2Int(1, 2), color),
            });

            Shape rotation_4 = new Shape(new List<ICell>
            {
                new Pixel(new Vector2Int(1, 0), color),
                new Pixel(new Vector2Int(0, 0), color),
                new Pixel(new Vector2Int(0, 1), color),
                new Pixel(new Vector2Int(0, 2), color),
            });

            var rotations = new Shape[] { rotation_1, rotation_2, rotation_3, rotation_4 };

            return new Figure(rotations, 4);
        }
    }
}
