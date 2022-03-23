using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class ZFigure : IFigureFactory
    {
        public Figure Create()
        {
            var color = Color.gray;

            Shape rotation_1 = new Shape(new List<ICell>
            {
                new Pixel(new Vector2Int(0, 0), color),
                new Pixel(new Vector2Int(1, 0), color),
                new Pixel(new Vector2Int(-1, 1), color),
                new Pixel(new Vector2Int(0, 1), color),
            });

            Shape rotation_2 = new Shape(new List<ICell>
            {
                new Pixel(new Vector2Int(0, 0), color),
                new Pixel(new Vector2Int(0, 1), color),
                new Pixel(new Vector2Int(1, 1), color),
                new Pixel(new Vector2Int(1, 2), color),
            });

            var rotations = new Shape[] { rotation_1, rotation_2 };

            return new Figure(rotations, 5);
        }
    }
}
