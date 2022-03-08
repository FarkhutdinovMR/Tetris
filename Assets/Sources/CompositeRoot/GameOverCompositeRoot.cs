using UnityEngine;
using Tetris.Models;

namespace CompositeRoot
{
    public class GameOverCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private GameObject _gameOverWindow;

        private GameOver _gameOver;

        public override void Compose()
        {
            _gameOver = new GameOver(_cupCompositeRoot.Cup, 19);
            _gameOver.Ended += GameOver;
        }

        public void OnDisable()
        {
            _gameOver.Ended -= GameOver;
        }

        private void GameOver()
        {
            _gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
}