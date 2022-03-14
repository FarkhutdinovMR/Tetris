using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class FiguresCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private LevelCompositeRoot _levelCompositeRoot;
        [SerializeField] private FiguresTransformableView _figuresViewFactory;
        [SerializeField] private FigureView _nextFigureView;

        private Figures _figures;
        private FigureSpawner _figureSpawner;
        private NextFigure _nextFigure;

        public Figures Figures => _figures;

        public FigureSpawner FigureSpawner => _figureSpawner;

        public override void Compose()
        {
            _figures = new Figures();
            _nextFigure = new NextFigure(_figures);
            _figureSpawner = new FigureSpawner(_cupCompositeRoot.Cup, _levelCompositeRoot.Level, _nextFigure);
        }

        private void OnEnable()
        {
            _figureSpawner.FigureSpawned += OnFigureSpawned;
            _figureSpawner.FigureStopped += OnFigureStoped;
            _cupCompositeRoot.Cup.CellsChanged += _figureSpawner.Start;
            _nextFigure.FigureChanged += _nextFigureView.Create;
        }

        private void OnDisable()
        {
            _figureSpawner.FigureSpawned -= OnFigureSpawned;
            _figureSpawner.FigureStopped -= OnFigureStoped;
            _cupCompositeRoot.Cup.CellsChanged -= _figureSpawner.Start;
            _nextFigure.FigureChanged -= _nextFigureView.Create;
        }

        private void Start()
        {
            _figureSpawner.Spawn();
        }

        private void Update()
        {
            _figureSpawner.Update(Time.deltaTime);
        }

        private void OnFigureSpawned(Figure figure, IMovement transformable)
        {
            _figuresViewFactory.Create(figure, transformable);
            _figureSpawner.Figure.ShapeChanged += OnShapeChanged;
        }

        private void OnFigureStoped()
        {
            if (_figureSpawner.Figure == null)
                return;

            _figureSpawner.Figure.ShapeChanged -= OnShapeChanged;
        }

        private void OnShapeChanged()
        {
            _figuresViewFactory.Create(_figureSpawner.Figure, _figureSpawner.Movement);
        }
    }
}