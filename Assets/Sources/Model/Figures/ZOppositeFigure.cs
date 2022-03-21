﻿using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    class ZOppositeFigure : IFigureFactory
    {
        public Figure Create()
        {
            var color = Color.yellow;

            Rotation rotation_1 = new Rotation(new List<Pixel>
            {
                new Pixel(new Vector2Int(-1, 0), color),
                new Pixel(new Vector2Int(0, 0), color),
                new Pixel(new Vector2Int(0, 1), color),
                new Pixel(new Vector2Int(1, 1), color)
            });

            Rotation rotation_2 = new Rotation(new List<Pixel>
            {
                new Pixel(new Vector2Int(1, 0), color),
                new Pixel(new Vector2Int(1, 1), color),
                new Pixel(new Vector2Int(0, 1), color),
                new Pixel(new Vector2Int(0, 2), color)
            });

            var rotations = new Rotation[] { rotation_1, rotation_2 };

            return new Figure(rotations, 6);
        }
    }
}
