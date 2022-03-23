using System;
using System.Collections.Generic;

namespace Tetris.Models
{
    public class FigureStatistics
    {
        private readonly List<Slot> _variants = new List<Slot>();

        public FigureStatistics(Figure[] figures)
        {
            if (figures == null)
                throw new ArgumentNullException(nameof(figures));

            foreach (Figure figure in figures)
                _variants.Add(new Slot(figure, 0));
        }

        public event Action<IEnumerable<Slot>> Changed;

        public void IncreaseCount(Figure figure, IMovement movement)
        {
            int index = _variants.FindIndex(f => f.Figure.Id == figure.Id);

            if (index == -1)
                throw new InvalidOperationException();

            _variants[index] = _variants[index].Increase(figure);
            Changed?.Invoke(_variants);
        }
    }
}