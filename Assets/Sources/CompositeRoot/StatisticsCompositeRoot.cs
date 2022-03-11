using UnityEngine;
using Tetris.Models;
using System.Collections.Generic;

namespace CompositeRoot
{
    public class StatisticsCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private TextView _scoreView;
        [SerializeField] private TextView _lineView;
        
        private readonly Dictionary<int, int> _costsPerLevels = new Dictionary<int, int>();

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
            _cupCompositeRoot.Cup.LineDeleted += Statistics.Update;
            Statistics.ScoreChanged += _scoreView.Set;
            Statistics.LineChanged += _lineView.Set;
        }

        private void OnDisable()
        {
            _cupCompositeRoot.Cup.LineDeleted -= Statistics.Update;
            Statistics.ScoreChanged -= _scoreView.Set;
            Statistics.LineChanged -= _lineView.Set;
        }
    }
}