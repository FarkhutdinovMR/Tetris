using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using System;

namespace Tetris.Models
{
    public class FigureSpawner
    {
        private List<Shape> _shapes;
        private FiguresViewFactory _figuresViewFactory;
        private Gravity figureGravity;

        public FigureSpawner(FiguresViewFactory figuresViewFactory)
        {
            if (figuresViewFactory == null)
                throw new ArgumentNullException(nameof(figuresViewFactory));

            _figuresViewFactory = figuresViewFactory;
            _shapes = new List<Shape>();
            AddFigure();
            Spawn();
        }

        public void Update(float deltaTime)
        {
            if (figureGravity != null)
                figureGravity.Update(deltaTime);
        }

        private void AddFigure()
        {
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

        private void Spawn()
        {
            int index = Random.Range(0, _shapes.Count);

            var figure = new Figure(_shapes[index]);
            var transformable = new Transformable(new Vector2(0, 6), 0);
            figureGravity = new Gravity(transformable, 1);

            _figuresViewFactory.Create(transformable, index);
        }
    }
}