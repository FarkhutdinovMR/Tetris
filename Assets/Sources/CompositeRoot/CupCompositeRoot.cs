using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class CupCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupView _cupView;
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        private Cup _cup;

        public Cup Cup => _cup;

        public override void Compose()
        {
            _cup = new Cup(_width, _height);
            _cupView.BuildWalls(_width, _height);
        }

        private void OnEnable()
        {
            _cup.CellsChanged += _cupView.Render;
        }

        private void OnDisable()
        {
            _cup.CellsChanged -= _cupView.Render;
        }
    }
}