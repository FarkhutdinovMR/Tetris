using System;
using UnityEngine;

namespace Tetris.Models
{
    public class Movement : ITransform
    {
        private readonly Cup _cup;
        private readonly Figure _figure;
        private readonly Transformable _figureTransformable;

        public Movement(Figure figure, Transformable figureTransformable, Cup cup)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));

            if (figureTransformable == null)
                throw new ArgumentNullException(nameof(figureTransformable));

            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            _figure = figure;
            _figureTransformable = figureTransformable;
            _cup = cup;
        }

        public void Move(Vector2Int direction)
        {
            foreach(Vector2Int position in _figure.Cells)
            {
                Vector2Int currentPosition = _figureTransformable.Position + position;
                Vector2Int nextPosition = currentPosition + direction;

                if (nextPosition.x < 0 || nextPosition.x >= _cup.Width)
                    return;

                if (nextPosition.y < 0)
                {
                    _cup.Edit(_figure.Cells, _figureTransformable.Position);
                    return;
                }

                if (_cup.IsEmpty(nextPosition) == false)
                {
                    if (currentPosition.y - nextPosition.y == 1)
                        _cup.Edit(_figure.Cells, _figureTransformable.Position);

                    return;
                }
            }

            _figureTransformable.Move(direction);
        }

        public void Rotate(int direction)
        {
            Vector2Int[] cells = _figure.GetShape(direction);

            foreach (Vector2Int position in cells)
            {
                Vector2Int currentPosition = _figureTransformable.Position + position;

                if (currentPosition.x < 0 || currentPosition.x >= _cup.Width)
                    return;

                if (currentPosition.y < 0)
                    return;

                if (_cup.IsEmpty(currentPosition) == false)
                    return;
            }

            _figure.ChangeShape(direction);
        }
    }
}