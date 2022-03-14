using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class Movement : IMovement
    {
        private readonly IMovement _movement;
        private readonly Figure _figure;
        private readonly Cup _cup;

        public Movement(IMovement movement, Figure figure, Cup cup)
        {
            if (movement == null)
                throw new ArgumentNullException(nameof(movement));

            if (figure == null)
                throw new ArgumentNullException(nameof(figure));

            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            _movement = movement;
            _figure = figure;
            _cup = cup;
        }

        public Vector2Int Position => _movement.Position;

        public void Move(Vector2Int direction)
        {
            foreach(Vector2Int position in _figure.Cells.Keys)
            {
                Vector2Int currentPosition = _movement.Position + position;
                Vector2Int nextPosition = currentPosition + direction;

                if (nextPosition.x < 0 || nextPosition.x >= _cup.Width)
                    return;

                if (nextPosition.y < 0)
                {
                    _cup.AddCells(_figure.Cells, _movement.Position);
                    return;
                }

                if (_cup.ContainCell(nextPosition))
                {
                    if (currentPosition.y - nextPosition.y == 1)
                        _cup.AddCells(_figure.Cells, _movement.Position);

                    return;
                }
            }

            _movement.Move(direction);
        }

        public void Rotate(int direction)
        {
            Dictionary<Vector2Int, Cell> cells = _figure.GetShape(direction);

            foreach (Vector2Int position in cells.Keys)
            {
                Vector2Int currentPosition = _movement.Position + position;

                if ((currentPosition.x < 0 || currentPosition.x >= _cup.Width) ||
                    (currentPosition.y < 0) ||
                    (_cup.ContainCell(currentPosition)))
                    return;
            }

            _figure.ChangeShape(direction);
        }
    }
}