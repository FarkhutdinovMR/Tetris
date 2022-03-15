﻿using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    class LineFigure : IFigureFactory
    {
        public Figure Create()
        {
            var color = Color.green;

            Rotation rotation_1 = new Rotation(new List<Cell>
            {
                new Cell(new Vector2Int(-2, 1), color),
                new Cell(new Vector2Int(-1, 1), color),
                new Cell(new Vector2Int(0, 1), color),
                new Cell(new Vector2Int(1, 1), color),
            });

            Rotation rotation_2 = new Rotation(new List<Cell>
            {
                new Cell(new Vector2Int(-1, 0), color),
                new Cell(new Vector2Int(-1, 1), color),
                new Cell(new Vector2Int(-1, 2), color),
                new Cell(new Vector2Int(-1, 3), color),
            });

            var rotations = new Rotation[] { rotation_1, rotation_2 };

            return new Figure(rotations, 2);
        }
    }
}
