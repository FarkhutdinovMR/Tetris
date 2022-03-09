using UnityEngine;
using Tetris.Models;

namespace CompositeRoot
{
    public class FiguresCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupCompositeRoot _cupCompositeRoot;
        [SerializeField] private LevelCompositeRoot _levelCompositeRoot;
        [SerializeField] private FiguresViewFactory _figuresViewFactory;

        private FigureSpawner _figureSpawner;

        public override void Compose()
        {
            _figureSpawner = new FigureSpawner(_cupCompositeRoot.Cup, _levelCompositeRoot.Level.Value);
        }

        private void OnEnable()
        {
            _figureSpawner.OnEnable();
            _figureSpawner.FigureSpawned += OnFigureSpawned;
            _figureSpawner.FigureStopped += OnFigureStoped;
        }

        private void OnDisable()
        {
            _figureSpawner.OnDisable();
            _figureSpawner.FigureSpawned -= OnFigureSpawned;
            _figureSpawner.FigureStopped -= OnFigureStoped;
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
            _figuresViewFactory.Create(_figureSpawner.Figure, _figureSpawner.Transformable);
        }
    }
}