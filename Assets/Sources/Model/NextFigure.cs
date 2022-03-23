using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Tetris.Models
{
    public class NextFigure
    {
        private readonly Figures _figures;
        private Figure _figure;

        public NextFigure(Figures figures)
        {
            if (figures == null)
                throw new ArgumentNullException(nameof(figures));

            _figures = figures;
            _figure = _figures.CreateFigure(Random.Range(0, _figures.Variants.Count));
        }

        public event Action<IEnumerable<ICell>> FigureChanged;

        public Figure GetFigure()
        {
            Figure currentFigure = _figure;
            _figure = _figures.CreateFigure(Random.Range(0, _figures.Variants.Count));
            FigureChanged?.Invoke(_figure.Cells);

            return currentFigure;
        }
    }
}