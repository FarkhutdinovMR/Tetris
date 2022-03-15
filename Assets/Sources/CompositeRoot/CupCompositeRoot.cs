using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class CupCompositeRoot : CompositeRoot
    {
        [SerializeField] private CellsView _view;
        [SerializeField] private CupView _cupView;
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        private Cup _cup;

        public Cup Cup => _cup;

        private void OnValidate()
        {
            _width = Mathf.Clamp(_width, 0, int.MaxValue);
            _height = Mathf.Clamp(_height, 0, int.MaxValue);
        }

        public override void Compose()
        {
            _cup = new Cup(_width, _height);
            _cupView.BuildWalls(_width, _height);
        }

        private void OnEnable()
        {
            _cup.CellsChanged += _view.Create;
        }

        private void OnDisable()
        {
            _cup.CellsChanged -= _view.Create;
        }

        private void Update()
        {
            _cup.Update(Time.deltaTime);
        }
    }
}