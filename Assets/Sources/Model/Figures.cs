using System;
using System.Collections.Generic;

namespace Tetris.Models
{
    public class Figures
    {
        private readonly Dictionary<int, IFigure> _variants;

        public Figures()
        {
            _variants = new Dictionary<int, IFigure>()
            {
                { 0, new TFigure() },
                { 1, new LFigure() },
                { 2, new ZFigure() },
                { 3, new SquareFigure() },
                { 4, new ZOppositeFigure() },
                { 5, new LOppositeFigure() },
                { 6, new LineFigure() },
            };
        }

        public IReadOnlyDictionary<int, IFigure> Variants => _variants;

        public Figure CreateFigure(int id)
        {
            if (_variants.ContainsKey(id) == false)
                throw new InvalidOperationException();

            return _variants[id].Create();
        }

        public List<Figure> CreateAllFigures()
        {
            List<Figure> figures = new List<Figure>();

            foreach (var variant in _variants.Values)
                figures.Add(variant.Create());

            return figures;
        }
    }
}