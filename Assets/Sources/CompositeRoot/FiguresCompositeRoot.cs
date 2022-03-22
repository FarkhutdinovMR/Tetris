using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

namespace CompositeRoot
{
    public class FiguresCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private LevelCompositeRoot _levelCompositeRoot;
        [SerializeField] private FiguresTransformableView _figuresViewFactory;
        [SerializeField] private CellsView _nextFigureView;
        [SerializeField] private GameObject _gameOverWindow;

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
            _cupCompositeRoot.Lines.LineDeleted += _figureSpawner.Start;
            _nextFigure.FigureChanged += _nextFigureView.Create;
        }

        private void OnDisable()
        {
            _figureSpawner.FigureSpawned -= OnFigureSpawned;
            _figureSpawner.FigureStopped -= OnFigureStoped;
            _cupCompositeRoot.Lines.LineDeleted -= _figureSpawner.Start;
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

        private void OnFigureSpawned(Figure figure, Transformable transformable)
        {
            _figuresViewFactory.Create(figure, transformable);
            _figureSpawner.Figure.CellsChanged += OnCellsChanged;
            _figureSpawner.Figure.Destroed += _figuresViewFactory.Destroy;
            _figureSpawner.Movement.DontMoved += OnDontMoved;
        }

        private void OnFigureStoped()
        {
            if (_figureSpawner.Figure == null)
                return;

            _figureSpawner.Figure.CellsChanged -= OnCellsChanged;
            _figureSpawner.Figure.Destroed -= _figuresViewFactory.Destroy;
            _figureSpawner.Movement.DontMoved -= OnDontMoved;
        }

        private void OnCellsChanged(IReadOnlyList<ICell> cells)
        {
            _figuresViewFactory.Create(_figureSpawner.Figure, _figureSpawner.Transformable);
        }

        private void OnDontMoved()
        {
            GameOver();
        }

        private void GameOver()
        {
            _gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }
}