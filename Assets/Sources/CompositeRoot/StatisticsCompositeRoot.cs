using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class StatisticsCompositeRoot : CompositeRoot
    {
        private readonly Dictionary<int, int> _costsPerLevels = new Dictionary<int, int>();

        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private TextView _scoreView;
        [SerializeField] private TextView _lineView;

        public Statistics Statistics { get; private set; }

        public override void Compose()
        {
            _costsPerLevels.Add(1, 100);
            _costsPerLevels.Add(2, 300);
            _costsPerLevels.Add(3, 700);
            _costsPerLevels.Add(4, 1500);

            Statistics = new Statistics(_costsPerLevels);
        }

        private void OnEnable()
        {
            _cupCompositeRoot.Lines.LineDeleted += Statistics.Update;
            Statistics.ScoreChanged += _scoreView.Set;
            Statistics.LineChanged += _lineView.Set;
        }

        private void OnDisable()
        {
            _cupCompositeRoot.Lines.LineDeleted -= Statistics.Update;
            Statistics.ScoreChanged -= _scoreView.Set;
            Statistics.LineChanged -= _lineView.Set;
        }
    }
}