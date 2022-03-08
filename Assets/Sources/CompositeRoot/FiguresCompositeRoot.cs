using System;
using UnityEngine;
using Tetris.Models;
using Random = UnityEngine.Random;

namespace CompositeRoot
{
    public class FiguresCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private LevelCompositeRoot _levelCompositeRoot;
        [SerializeField] private FiguresViewFactory _figuresViewFactory;

        private Figure _figure;
        private Transformable _figureTransformable;
        private FigureInputRouter _figureInputRouter;
        private Gravity _figureGravity;
        private Func<Figure>[] _variants;
        private Movement _figureMovement;

        public override void Compose()
        {
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

            SpawnFigure();
        }

        private void OnEnable()
        {
            _cupCompositeRoot.Cup.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _figureInputRouter.Disable();
            _cupCompositeRoot.Cup.Changed -= OnChanged;
        }

        private void Update()
        {
            if (_figureGravity != null)
                _figureGravity.Update(Time.deltaTime);

            if (_figureInputRouter != null)
                _figureInputRouter.Update(Time.deltaTime);
        }

        private void OnChanged()
        {
            _figureInputRouter.Disable();
            _figure.ShapeChanged -= OnShapeChanged;
            SpawnFigure();
        }

        private void SpawnFigure()
        {
            int index = Random.Range(0, _variants.Length);
            _figure = _variants[index].Invoke();
            _figureTransformable = new Transformable(new Vector2Int(_cupCompositeRoot.Cup.Width/2, _cupCompositeRoot.Cup.Height - 4), 0);
            _figureMovement = new Movement(_figure, _figureTransformable, _cupCompositeRoot.Cup);
            _figureGravity = new Gravity(_figureMovement, _levelCompositeRoot.Level.Value);
            _figureInputRouter = new FigureInputRouter(_figureMovement);
            _figureInputRouter.Enable();
            _figuresViewFactory.Create(_figure, _figureTransformable);
            _figure.ShapeChanged += OnShapeChanged;
        }

        private void OnShapeChanged()
        {
            _figuresViewFactory.Create(_figure, _figureTransformable);
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