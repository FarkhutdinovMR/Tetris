using System;
using UnityEngine;

namespace Tetris.Models
{
    public class Movement
    {
        private Shape _cup;
        private Shape _figure;
        private Transformable _figureTransformable;

        public Movement(Shape cup, Shape figure, Transformable figureTransformable)
        {
            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            if (figure == null)
                throw new ArgumentNullException(nameof(figure));

            if (figureTransformable == null)
                throw new ArgumentNullException(nameof(figureTransformable));

            _cup = cup;
            _figure = figure;
            _figureTransformable = figureTransformable;
            Enable();
        }

        public void Enable()
        {
            _figureTransformable.Moved += OnMoved;
        }

        public void Disable()
        {
            _figureTransformable.Moved -= OnMoved;
        }

        private void OnMoved()
        {
            TryMove();
        }

        private void TryMove()
        {
            for (int i = 0; i < _figure.Width; i++)
            {
                for (int j = 0; j < _figure.Height; j++)
                {
                    if (_figure.IsEmpty(j, i))
                        continue;

                    Vector2 worldIndex = _figureTransformable.Position + new Vector2(j, i);

                    if (_cup.CheckIndexExist((int)worldIndex.x, (int)worldIndex.y) == false)
                    {
                        _figureTransformable.Stop();
                        Debug.Log("ArgumentOutOfRange");
                        Disable();
                        return;
                    }

                    if (_cup.IsEmpty((int)worldIndex.x, (int)worldIndex.y) == false)
                    {
                        _figureTransformable.Stop();
                        Debug.Log("CellIsNotEmpty");
                        Disable();
                        return;
                    }
                }
            }
        }
    }
}