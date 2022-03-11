using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class FiguresStatisticsCompositeRoot : CompositeRoot
    {
        [SerializeField] private FiguresCompositeRoot _figuresCompositeRoot;
        [SerializeField] private FiguresStatisticsView _view;

        private FigureStatistics _statistics;

        public override void Compose()
        {
            _statistics = new FigureStatistics(_figuresCompositeRoot.Figures.CreateAllFigures().ToArray());
        }

        private void OnEnable()
        {
            _figuresCompositeRoot.FigureSpawner.IdFigureSpawned += _statistics.IncreaseCount;
            _statistics.Changed += _view.Render;
        }

        private void OnDisable()
        {
            _figuresCompositeRoot.FigureSpawner.IdFigureSpawned -= _statistics.IncreaseCount;
            _statistics.Changed -= _view.Render;
        }
    }
}