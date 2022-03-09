using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetris.Models
{
    public class FigureSpawner
    {
        private readonly Cup _cup;
        private readonly int _level;
        private readonly Func<Figure>[] _variants;

        private Figure _figure;
        private Gravity _gravity;
        private FigureInputRouter _inputRouter;
        private Transformable _transformable;
        private Movement _movement;

        public FigureSpawner(Cup cup, int level)
        {
            if (cup == null)
                throw new ArgumentNullException(nameof(cup));

            _level = level;
            _cup = cup;

            _variants = new Func<Figure>[]
            {
                CreateSquare,
                CreateLine,
                CreateL,
                CreateLOpposite,
                CreateZ,
                CreateZOpposite,
                CreateT
            };
        }

        public event Action<Figure, Transformable> FigureSpawned;

        public event Action FigureStopped;

        public Figure Figure => _figure;

        public Transformable Transformable => _transformable;

        public void OnEnable()
        {
            _cup.CellChanged += OnChanged;
        }

        public void OnDisable()
        {
            _cup.CellChanged -= OnChanged;
        }

        public void Update(float deltaTime)
        {
            if (_gravity != null)
                _gravity.Update(deltaTime);

            if (_inputRouter != null)
                _inputRouter.Update(deltaTime);
        }

        public void Spawn()
        {
            int index = Random.Range(0, _variants.Length);
            _figure = _variants[index].Invoke();
            _transformable = new Transformable(new Vector2Int(_cup.Width / 2, _cup.Height - 4));
            _movement = new Movement(_figure, _transformable, _cup);
            _gravity = new Gravity(_movement, _level);
            _inputRouter = new FigureInputRouter(_movement);
            _inputRouter.OnEnable();

            FigureSpawned?.Invoke(_figure, _transformable);
        }

        private void OnChanged()
        {
            if (_inputRouter != null)
                _inputRouter.OnDisable();

            FigureStopped?.Invoke();

            Spawn();
        }

        private Figure CreateSquare()
        {
            Vector2Int[] cells =
            {
                new Vector2Int(-1, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 0),
                new Vector2Int(0, 1)
            };

            var shapes = new Shape[] { new Shape(cells) };

            return new Figure(shapes, 1);
        }

        private Figure CreateLine()
        {
            Vector2Int[] cell_1 =
            {
                new Vector2Int(-2, 1),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1)
            };

            Vector2Int[] cell_2 =
            {
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                new Vector2Int(0, 3)
            };

            var shapes = new Shape[] { new Shape(cell_1), new Shape(cell_2) };

            return new Figure(shapes, 2);
        }

        private Figure CreateL()
        {
            Vector2Int[] cells_1 =
            {
                new Vector2Int(1, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1)
            };

            Vector2Int[] cells_2 =
{
                new Vector2Int(-1, 0),
                new Vector2Int(-0, 0),
                new Vector2Int(-0, 1),
                new Vector2Int(-0, 2)
            };

            Vector2Int[] cells_3 =
{
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1),
                new Vector2Int(-1, 2)
            };

            Vector2Int[] cells_4 =
{
                new Vector2Int(-1, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(-1, 2),
                new Vector2Int(0, 2)
            };

            var shapes = new Shape[] { new Shape(cells_1), new Shape(cells_2), new Shape(cells_3), new Shape(cells_4) };

            return new Figure(shapes, 3);
        }

        private Figure CreateLOpposite()
        {
            Vector2Int[] cells_1 =
            {
                new Vector2Int(-1, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1)
            };

            Vector2Int[] cells_2 =
{
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                new Vector2Int(-1, 2)
            };

            Vector2Int[] cells_3 =
{
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1),
                new Vector2Int(1, 2)
            };

            Vector2Int[] cells_4 =
{
                new Vector2Int(1, 0),
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2)
            };

            var shapes = new Shape[] { new Shape(cells_1), new Shape(cells_2), new Shape(cells_3), new Shape(cells_4) };

            return new Figure(shapes, 4);
        }

        private Figure CreateZ()
        {
            Vector2Int[] cell_1 =
            {
                new Vector2Int(0, 0),
                new Vector2Int(1, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1)
            };

            Vector2Int[] cell_2 =
{
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1),
                new Vector2Int(1, 2)
            };

            var shapes = new Shape[] { new Shape(cell_1), new Shape(cell_2) };

            return new Figure(shapes, 5);
        }

        private Figure CreateZOpposite()
        {
            Vector2Int[] cell_1 =
            {
                new Vector2Int(-1, 0),
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1)
            };

            Vector2Int[] cell_2 =
{
                new Vector2Int(1, 0),
                new Vector2Int(1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2)
            };

            var shapes = new Shape[] { new Shape(cell_1), new Shape(cell_2) };

            return new Figure(shapes, 6);
        }

        private Figure CreateT()
        {
            Vector2Int[] cell_1 =
            {
                new Vector2Int(0, 0),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1)
            };

            Vector2Int[] cell_2 =
{
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                new Vector2Int(-1, 1)
            };

            Vector2Int[] cell_3 =
{
                new Vector2Int(0, 2),
                new Vector2Int(-1, 1),
                new Vector2Int(0, 1),
                new Vector2Int(1, 1)
            };

            Vector2Int[] cell_4 =
{
                new Vector2Int(0, 0),
                new Vector2Int(0, 1),
                new Vector2Int(0, 2),
                new Vector2Int(1, 1)
            };

            var shapes = new Shape[] { new Shape(cell_1), new Shape(cell_2), new Shape(cell_3), new Shape(cell_4) };

            return new Figure(shapes, 7);
        }
    }
}