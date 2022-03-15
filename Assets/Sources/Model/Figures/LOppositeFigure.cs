﻿using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    class LOppositeFigure : IFigureFactory
    {
        public Figure Create()
        {
            var color = Color.cyan;

            Rotation rotation_1 = new Rotation(new List<Cell>
            {
                new Cell(new Vector2Int(-1, 0), color),
                new Cell(new Vector2Int(-1, 1), color),
                new Cell(new Vector2Int(0, 1), color),
                new Cell(new Vector2Int(1, 1), color)
            });

            Rotation rotation_2 = new Rotation(new List<Cell>
            {
                new Cell(new Vector2Int(0, 0), color),
                new Cell(new Vector2Int(0, 1), color),
                new Cell(new Vector2Int(0, 2), color),
                new Cell(new Vector2Int(-1, 2), color)
            });

            Rotation rotation_3 = new Rotation(new List<Cell>
            {
                new Cell(new Vector2Int(-1, 1), color),
                new Cell(new Vector2Int(0, 1), color),
                new Cell(new Vector2Int(1, 1), color),
                new Cell(new Vector2Int(1, 2), color)
            });

            Rotation rotation_4 = new Rotation(new List<Cell>
            {
                new Cell(new Vector2Int(1, 0), color),
                new Cell(new Vector2Int(0, 0), color),
                new Cell(new Vector2Int(0, 1), color),
                new Cell(new Vector2Int(0, 2), color)
            });

            var rotations = new Rotation[] { rotation_1, rotation_2, rotation_3, rotation_4 };

            return new Figure(rotations, 4);
        }
    }
}
