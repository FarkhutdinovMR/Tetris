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

        private bool _isActive = true;

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
            if (_isActive == false)
                return;

            foreach (Cell cell in _figure.Cells)
            {
                Vector2Int currentPosition = _movement.Position + cell.Position;
                Vector2Int nextPosition = currentPosition + direction;

                if (nextPosition.x < 0 || nextPosition.x >= _cup.Width)
                    return;

                if (nextPosition.y < 0)
                {
                    TakeCells();
                    return;
                }

                if (_cup.ContainCell(nextPosition))
                {
                    if (currentPosition.y - nextPosition.y == 1)
                        TakeCells();

                    return;
                }
            }

            _movement.Move(direction);
        }

        public void Rotate(int direction)
        {
            if (_isActive == false)
                return;

            IReadOnlyList<IReadOnlyCell> cells = _figure.GetRotatedCells(direction);

            foreach (Cell cell in cells)
            {
                Vector2Int currentPosition = _movement.Position + cell.Position;

                if ((currentPosition.x < 0 || currentPosition.x >= _cup.Width) ||
                    (currentPosition.y < 0) ||
                    (_cup.ContainCell(currentPosition)))
                {
                    return;
                }
            }

            _figure.Rotate(direction);
        }

        private void TakeCells()
        {
            _isActive = false;

            if (_cup.TryAddCells(_figure.Cells, _movement.Position))
            {
                _figure.Destroy();
                _cup.DeleteLines();
            }
        }
    }
}