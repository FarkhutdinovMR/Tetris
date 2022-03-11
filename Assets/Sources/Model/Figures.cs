using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris.Models
{
    public class Figures
    {
        private readonly Dictionary<int, Func<Figure>> _variants;

        public Figures()
        {
            _variants = new Dictionary<int, Func<Figure>>();
            _variants.Add(_variants.Count, CreateT);
            _variants.Add(_variants.Count, CreateL);
            _variants.Add(_variants.Count, CreateZ);
            _variants.Add(_variants.Count, CreateSquare);
            _variants.Add(_variants.Count, CreateZOpposite);
            _variants.Add(_variants.Count, CreateLOpposite);
            _variants.Add(_variants.Count, CreateLine);
        }

        public IReadOnlyDictionary<int, Func<Figure>> Variants => _variants;

        public Figure CreateFigure(int id)
        {
            if (_variants.ContainsKey(id) == false)
                throw new InvalidOperationException();

            return _variants[id].Invoke();
        }

        public List<Figure> CreateAllFigures()
        {
            List<Figure> figures = new List<Figure>();

            foreach (var variant in _variants.Values)
                figures.Add(variant.Invoke());

            return figures;
        }

        private Figure CreateSquare()
        {
            var cell = new Cell(Color.red);

            var dictionary = new Dictionary<Vector2Int, Cell>();
            dictionary.Add(new Vector2Int(-1, 0), cell);
            dictionary.Add(new Vector2Int(-1, 1), cell);
            dictionary.Add(new Vector2Int(0, 0), cell);
            dictionary.Add(new Vector2Int(0, 1), cell);

            Shape shape_1 = new Shape(dictionary);

            var shapes = new Shape[] { shape_1 };

            return new Figure(shapes, 1);
        }

        private Figure CreateLine()
        {
            var cell = new Cell(Color.green);

            var dictionary_1 = new Dictionary<Vector2Int, Cell>();
            dictionary_1.Add(new Vector2Int(-2, 1), cell);
            dictionary_1.Add(new Vector2Int(-1, 1), cell);
            dictionary_1.Add(new Vector2Int(0, 1), cell);
            dictionary_1.Add(new Vector2Int(1, 1), cell);

            Shape shape_1 = new Shape(dictionary_1);

            var dictionary_2 = new Dictionary<Vector2Int, Cell>();
            dictionary_2.Add(new Vector2Int(-1, 0), cell);
            dictionary_2.Add(new Vector2Int(-1, 1), cell);
            dictionary_2.Add(new Vector2Int(-1, 2), cell);
            dictionary_2.Add(new Vector2Int(-1, 3), cell);

            Shape shape_2 = new Shape(dictionary_2);

            var shapes = new Shape[] { shape_1, shape_2 };

            return new Figure(shapes, 2);
        }

        private Figure CreateL()
        {
            var cell = new Cell(Color.blue);

            var dictionary_1 = new Dictionary<Vector2Int, Cell>();
            dictionary_1.Add(new Vector2Int(1, 0), cell);
            dictionary_1.Add(new Vector2Int(-1, 1), cell);
            dictionary_1.Add(new Vector2Int(0, 1), cell);
            dictionary_1.Add(new Vector2Int(1, 1), cell);

            Shape shape_1 = new Shape(dictionary_1);

            var dictionary_2 = new Dictionary<Vector2Int, Cell>();
            dictionary_2.Add(new Vector2Int(-1, 0), cell);
            dictionary_2.Add(new Vector2Int(0, 0), cell);
            dictionary_2.Add(new Vector2Int(0, 1), cell);
            dictionary_2.Add(new Vector2Int(0, 2), cell);

            Shape shape_2 = new Shape(dictionary_2);

            var dictionary_3 = new Dictionary<Vector2Int, Cell>();
            dictionary_3.Add(new Vector2Int(-1, 1), cell);
            dictionary_3.Add(new Vector2Int(0, 1), cell);
            dictionary_3.Add(new Vector2Int(1, 1), cell);
            dictionary_3.Add(new Vector2Int(-1, 2), cell);

            Shape shape_3 = new Shape(dictionary_3);

            var dictionary_4 = new Dictionary<Vector2Int, Cell>();
            dictionary_4.Add(new Vector2Int(-1, 0), cell);
            dictionary_4.Add(new Vector2Int(-1, 1), cell);
            dictionary_4.Add(new Vector2Int(-1, 2), cell);
            dictionary_4.Add(new Vector2Int(0, 2), cell);

            Shape shape_4 = new Shape(dictionary_4);

            var shapes = new Shape[] { shape_1, shape_2, shape_3, shape_4 };

            return new Figure(shapes, 3);
        }

        private Figure CreateLOpposite()
        {
            var cell = new Cell(Color.cyan);

            var dictionary_1 = new Dictionary<Vector2Int, Cell>();
            dictionary_1.Add(new Vector2Int(-1, 0), cell);
            dictionary_1.Add(new Vector2Int(-1, 1), cell);
            dictionary_1.Add(new Vector2Int(0, 1), cell);
            dictionary_1.Add(new Vector2Int(1, 1), cell);

            Shape shape_1 = new Shape(dictionary_1);

            var dictionary_2 = new Dictionary<Vector2Int, Cell>();
            dictionary_2.Add(new Vector2Int(0, 0), cell);
            dictionary_2.Add(new Vector2Int(0, 1), cell);
            dictionary_2.Add(new Vector2Int(0, 2), cell);
            dictionary_2.Add(new Vector2Int(-1, 2), cell);

            Shape shape_2 = new Shape(dictionary_2);

            var dictionary_3 = new Dictionary<Vector2Int, Cell>();
            dictionary_3.Add(new Vector2Int(-1, 1), cell);
            dictionary_3.Add(new Vector2Int(0, 1), cell);
            dictionary_3.Add(new Vector2Int(1, 1), cell);
            dictionary_3.Add(new Vector2Int(1, 2), cell);

            Shape shape_3 = new Shape(dictionary_3);

            var dictionary_4 = new Dictionary<Vector2Int, Cell>();
            dictionary_4.Add(new Vector2Int(1, 0), cell);
            dictionary_4.Add(new Vector2Int(0, 0), cell);
            dictionary_4.Add(new Vector2Int(0, 1), cell);
            dictionary_4.Add(new Vector2Int(0, 2), cell);

            Shape shape_4 = new Shape(dictionary_4);

            var shapes = new Shape[] { shape_1, shape_2, shape_3, shape_4 };

            return new Figure(shapes, 4);
        }

        private Figure CreateZ()
        {
            var cell = new Cell(Color.gray);

            var dictionary_1 = new Dictionary<Vector2Int, Cell>();
            dictionary_1.Add(new Vector2Int(0, 0), cell);
            dictionary_1.Add(new Vector2Int(1, 0), cell);
            dictionary_1.Add(new Vector2Int(-1, 1), cell);
            dictionary_1.Add(new Vector2Int(0, 1), cell);

            Shape shape_1 = new Shape(dictionary_1);

            var dictionary_2 = new Dictionary<Vector2Int, Cell>();
            dictionary_2.Add(new Vector2Int(0, 0), cell);
            dictionary_2.Add(new Vector2Int(0, 1), cell);
            dictionary_2.Add(new Vector2Int(1, 1), cell);
            dictionary_2.Add(new Vector2Int(1, 2), cell);

            Shape shape_2 = new Shape(dictionary_2);

            var shapes = new Shape[] { shape_1, shape_2 };

            return new Figure(shapes, 5);
        }

        private Figure CreateZOpposite()
        {
            var cell = new Cell(Color.yellow);

            var dictionary_1 = new Dictionary<Vector2Int, Cell>();
            dictionary_1.Add(new Vector2Int(-1, 0), cell);
            dictionary_1.Add(new Vector2Int(0, 0), cell);
            dictionary_1.Add(new Vector2Int(0, 1), cell);
            dictionary_1.Add(new Vector2Int(1, 1), cell);

            Shape shape_1 = new Shape(dictionary_1);

            var dictionary_2 = new Dictionary<Vector2Int, Cell>();
            dictionary_2.Add(new Vector2Int(1, 0), cell);
            dictionary_2.Add(new Vector2Int(1, 1), cell);
            dictionary_2.Add(new Vector2Int(0, 1), cell);
            dictionary_2.Add(new Vector2Int(0, 2), cell);

            Shape shape_2 = new Shape(dictionary_2);

            var shapes = new Shape[] { shape_1, shape_2 };

            return new Figure(shapes, 6);
        }

        private Figure CreateT()
        {
            var cell = new Cell(Color.white);

            var dictionary_1 = new Dictionary<Vector2Int, Cell>();
            dictionary_1.Add(new Vector2Int(0, 0), cell);
            dictionary_1.Add(new Vector2Int(-1, 1), cell);
            dictionary_1.Add(new Vector2Int(0, 1), cell);
            dictionary_1.Add(new Vector2Int(1, 1), cell);

            Shape shape_1 = new Shape(dictionary_1);

            var dictionary_2 = new Dictionary<Vector2Int, Cell>();
            dictionary_2.Add(new Vector2Int(0, 0), cell);
            dictionary_2.Add(new Vector2Int(0, 1), cell);
            dictionary_2.Add(new Vector2Int(0, 2), cell);
            dictionary_2.Add(new Vector2Int(-1, 1), cell);

            Shape shape_2 = new Shape(dictionary_2);

            var dictionary_3 = new Dictionary<Vector2Int, Cell>();
            dictionary_3.Add(new Vector2Int(0, 2), cell);
            dictionary_3.Add(new Vector2Int(-1, 1), cell);
            dictionary_3.Add(new Vector2Int(0, 1), cell);
            dictionary_3.Add(new Vector2Int(1, 1), cell);

            Shape shape_3 = new Shape(dictionary_3);

            var dictionary_4 = new Dictionary<Vector2Int, Cell>();
            dictionary_4.Add(new Vector2Int(0, 0), cell);
            dictionary_4.Add(new Vector2Int(0, 1), cell);
            dictionary_4.Add(new Vector2Int(0, 2), cell);
            dictionary_4.Add(new Vector2Int(1, 1), cell);

            Shape shape_4 = new Shape(dictionary_4);

            var shapes = new Shape[] { shape_1, shape_2, shape_3, shape_4 };

            return new Figure(shapes, 7);
        }
    }
}