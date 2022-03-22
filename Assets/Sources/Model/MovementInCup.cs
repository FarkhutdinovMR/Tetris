using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class MovementInCup : IMovement, IRotation
    {
        private readonly Transformable _transform;
        private readonly Figure _figure;
        private readonly Cup _cup;

        private bool _isStopped;

        public MovementInCup(Figure figure, Cup cup, Transformable transform)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));

            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            _figure = figure;
            _cup = cup;
            _transform = transform;
        }

        public event Action DontMoved;

        public bool IsGrounded(Vector2Int direction) => direction == Vector2Int.down;

        public void Move(Vector2Int direction)
        {
            if (_isStopped)
                return;

            if (_cup.IsCollision(LocalToWorld(_figure.Cells, _transform.Position + direction)) == false)
            {
                _transform.Move(direction);
            }
            else if (IsGrounded(direction))
            {
                if (_cup.IsCollision(LocalToWorld(_figure.Cells, _transform.Position)))
                {
                    DontMoved?.Invoke();
                }
                else
                {
                    _cup.AddCells(LocalToWorld(_figure.Cells, _transform.Position));
                    _figure.Destroy();
                }

                _isStopped = true;
            }
        }

        public void Rotate(int direction)
        {
            if (_isStopped)
                return;

            if (_cup.IsCollision(LocalToWorld(_figure.GetRotatedCells(direction), _transform.Position)) == false)
                _figure.Rotate(direction);
        }

        private IEnumerable<ICell> LocalToWorld(IEnumerable<ICell> cells, Vector2Int position)
        {
            List<ICell> newCells = new List<ICell>();

            foreach (ICell cell in cells)
                newCells.Add(cell.Move(position));

            return newCells;
        }
    }
}