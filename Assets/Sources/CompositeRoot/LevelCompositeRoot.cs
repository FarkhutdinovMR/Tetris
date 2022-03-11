using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class LevelCompositeRoot : CompositeRoot
    {
        [SerializeField] private StatisticsCompositeRoot _statisticsCompositeRoot;
        [SerializeField] private TextView _levelView;
        [SerializeField] private int _lineToLevelUp;

        private Level _level;

        public Level Level => _level;

        public override void Compose()
        {
            _level = new Level(_lineToLevelUp);
        }

        private void OnEnable()
        {
            _statisticsCompositeRoot.Statistics.LineChanged += _level.Update;
            _level.Changed += _levelView.Set;
        }

        private void OnDisable()
        {
            _statisticsCompositeRoot.Statistics.LineChanged -= _level.Update;
            _level.Changed -= _levelView.Set;
        }
    }
}