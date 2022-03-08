using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class LevelCompositeRoot : CompositeRoot
    {
        [SerializeField] private StatisticsCompositeRoot _statisticsCompositeRoot;
        [SerializeField] private LevelView _levelView;

        public Level Level { get; private set; }

        public override void Compose()
        {
            Level = new Level(_statisticsCompositeRoot.Statistics, 5);
            Level.OnEnable();
            _levelView.Init(Level);
        }

        public void OnDisable()
        {
            Level.OnDisable();
        }
    }
}