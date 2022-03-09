using UnityEngine;
using Tetris.Models;

namespace CompositeRoot
{
    public class StatisticsCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private ScoreView _scoreView;

        public Statistics Statistics { get; private set; }

        public override void Compose()
        {
            Statistics = new Statistics(_cupCompositeRoot.Cup, 1000);
            Statistics.OnEnable();
            _scoreView.Init(Statistics);
            _scoreView.Enable();
        }

        private void OnDisable()
        {
            Statistics.OnDisable();
            _scoreView.Disable();
        }
    }
}