using System.Collections.Generic;
using UnityEngine;
using Tetris.Models;
using Random = UnityEngine.Random;

namespace CompositeRoot
{
    public class FiguresCompositeRoot : CompositeRoot
    {
        [SerializeField] private FiguresViewFactory _figuresViewFactory;

        private Shape _cup;
        private Figure _figure;
        private Transformable _figureTransformable;
        private FigureInputRouter _figureInputRouter;
        private Gravity _figureGravity;
        private List<Shape> _shapes;

        public override void Compose()
        {
            _figureInputRouter = new FigureInputRouter();
            _cup = new Shape(new bool[10, 20]);

            AddFigure();
            Spawn();
        }

        private void OnEnable()
        {
            _figureInputRouter.Enable();
        }

        private void OnDisable()
        {
            _figureInputRouter.Disable();
        }

        private void Update()
        {
            if (_figureGravity != null)
                _figureGravity.Update(Time.deltaTime);
        }

        private void Spawn()
        {
            int index = Random.Range(0, _shapes.Count);

            _figure = new Figure(_shapes[index]);
            _figureTransformable = new Transformable(new Vector2(0, 13), 0);
            _figureGravity = new Gravity(_figureTransformable, 1);

            _figuresViewFactory.Create(_figureTransformable, index);

            _figureInputRouter.SetFigureTransformable(_figureTransformable);

            var movement = new Movement(_cup, _shapes[index], _figureTransformable);
        }

        private void AddFigure()
        {
            _shapes = new List<Shape>();

            bool[,] shape =
            {
                { true, true, false, false },
                { true, true, false, false },
                { false, false, false, false },
                { false, false, false, false }
            };

            _shapes.Add(new Shape(shape));

            shape = new bool[,]
            {
                { true, false, false, false },
                { true, false, false, false },
                { true, false, false, false },
                { true, false, false, false }
            };

            _shapes.Add(new Shape(shape));
        }
    }
}