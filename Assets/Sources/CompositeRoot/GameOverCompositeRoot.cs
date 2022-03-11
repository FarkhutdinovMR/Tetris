using UnityEngine;
using Tetris.Models;

namespace CompositeRoot
{
    public class GameOverCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private GameObject _gameOverWindow;
        [SerializeField] private int _maxPosition;

        private GameOver _gameOver;

        public override void Compose()
        {
            _gameOver = new GameOver(_maxPosition);
        }

        private void OnEnable()
        {
            _cupCompositeRoot.Cup.CellsChanged += _gameOver.StopGame;
            _gameOver.Ended += GameOver;
        }

        private void OnDisable()
        {
            _cupCompositeRoot.Cup.CellsChanged -= _gameOver.StopGame;
            _gameOver.Ended -= GameOver;
        }

        private void GameOver()
        {
            _gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
}