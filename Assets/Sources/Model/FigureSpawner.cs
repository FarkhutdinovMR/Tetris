using System;
using UnityEngine;

namespace Tetris.Models
{
    public class FigureSpawner
    {
        private readonly Cup _cup;
        private readonly Level _level;
        private readonly NextFigure _nextFigure;

        private Figure _figure;
        private FigureInputRouter _inputRouter;
        private MovementInCup _movement;
        private Gravity _gravity;
        private Transformable _transform;

        public FigureSpawner(Cup cup, Level level, NextFigure nextFigure)
        {
            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            if (level == null)
                throw new ArgumentNullException(nameof(level));

            if (nextFigure == null)
                throw new ArgumentNullException(nameof(nextFigure));

            _level = level;
            _cup = cup;
            _nextFigure = nextFigure;
        }

        public event Action<Figure, Transformable> FigureSpawned;

        public event Action FigureStopped;

        public Figure Figure => _figure;

        public Transformable Transformable => _transform;

        public MovementInCup Movement => _movement;

        public void Update(float deltaTime)
        {
            if (_gravity != null)
                _gravity.Update(deltaTime);

            if (_inputRouter != null)
                _inputRouter.Update(deltaTime);
        }

        public void Start(int lines)
        {
            if (_inputRouter != null)
                _inputRouter.OnDisable();

            FigureStopped?.Invoke();

            Spawn();
        }

        public void Spawn()
        {
            var position = new Vector2Int(5, 18);
            _figure = _nextFigure.GetFigure();

            _transform = new Transformable(position);
            _movement = new MovementInCup(_figure, _cup, _transform);
            _gravity = new Gravity(_movement, _level.Value);
            _inputRouter = new FigureInputRouter(_gravity, _movement);

            _inputRouter.OnEnable();
            FigureSpawned?.Invoke(_figure, _transform);
        }
    }
}