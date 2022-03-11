using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetris.Models
{
    public class FigureSpawner
    {
        private readonly Cup _cup;
        private readonly Level _level;
        private readonly NextFigure _nextFigure;

        private Figure _figure;
        private Gravity _gravity;
        private FigureInputRouter _inputRouter;
        private Transformable _transformable;
        private Movement _movement;

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

        public event Action<Figure> IdFigureSpawned;

        public event Action FigureStopped;

        public Figure Figure => _figure;

        public Transformable Transformable => _transformable;

        public void Update(float deltaTime)
        {
            if (_gravity != null)
                _gravity.Update(deltaTime);

            if (_inputRouter != null)
                _inputRouter.Update(deltaTime);
        }

        public void Start(IReadOnlyDictionary<Vector2Int, Cell> cells)
        {
            if (_inputRouter != null)
                _inputRouter.OnDisable();

            FigureStopped?.Invoke();

            Spawn();
        }

        public void Spawn()
        {
            _figure = _nextFigure.GetFigure();
            _transformable = new Transformable(new Vector2Int(_cup.Width / 2, _cup.Height - 4));
            _movement = new Movement(_figure, _transformable, _cup);
            _gravity = new Gravity(_movement, _level.Value);
            _inputRouter = new FigureInputRouter(_movement);
            _inputRouter.OnEnable();

            FigureSpawned?.Invoke(_figure, _transformable);
            IdFigureSpawned?.Invoke(_figure);
        }
    }
}