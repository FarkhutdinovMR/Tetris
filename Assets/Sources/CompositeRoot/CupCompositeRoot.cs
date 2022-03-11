using UnityEngine;
using Tetris.Models;

namespace CompositeRoot
{
    public class CupCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupView _cupView;
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        private Cup _cup;

        public override void Compose()
        {
            _cup = new Cup(_width, _height);
        }

        public Cup Cup => _cup;

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