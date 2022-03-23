using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class CupCompositeRoot : CompositeRoot
    {
        [SerializeField] private CellsView _view;
        [SerializeField] private int _width;
        [SerializeField] private int _height;

        private Cup _cup;
        private Lines _lines;

        public Cup Cup => _cup;

        public Lines Lines => _lines;

        public override void Compose()
        {
            var shape = new Shape();
            _cup = new Cup(shape, new Size(_width, _height));
            _lines = new Lines(_cup);
            _view.Create(shape.Cells);
        }

        private void OnValidate()
        {
            _width = Mathf.Clamp(_width, 0, int.MaxValue);
            _height = Mathf.Clamp(_height, 0, int.MaxValue);
        }

        private void OnEnable()
        {
            _cup.CellsChanged += _view.Create;
            _cup.CellsChanged += _lines.Upadate;
        }

        private void OnDisable()
        {
            _cup.CellsChanged -= _view.Create;
            _cup.CellsChanged -= _lines.Upadate;
        }

        private void Update()
        {
            _lines.Update(Time.deltaTime);
        }
    }
}