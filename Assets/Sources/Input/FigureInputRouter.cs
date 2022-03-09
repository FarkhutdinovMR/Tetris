using UnityEngine.InputSystem;
using Tetris.Models;
using System;
using UnityEngine;

public class FigureInputRouter
{
    private readonly FigureInput _figureInput;
    private readonly Timer _moveTimer;
    private IMovement _transform;

    public FigureInputRouter(IMovement transform)
    {
        if (transform == null)
            throw new ArgumentNullException(nameof(transform));

        _transform = transform;
        _figureInput = new FigureInput();
        _moveTimer = new Timer(() => MoveFigure(_figureInput.Figure.Move.ReadValue<Vector2>()), 0.1f);
    }

    public void OnEnable()
    {
        _figureInput.Enable();
        _figureInput.Figure.Move.started += OnMoveStarted;
        _figureInput.Figure.Move.canceled += OnMoveCanceled;
        _figureInput.Figure.Rotate.performed += OnRotate;
    }

    public void OnDisable()
    {
        _figureInput.Disable();
        _figureInput.Figure.Move.started -= OnMoveStarted;
        _figureInput.Figure.Move.canceled -= OnMoveCanceled;
        _figureInput.Figure.Rotate.performed -= OnRotate;
    }

    public void Update(float deltaTime)
    {
        _moveTimer.Tick(deltaTime);
    }

    private void OnMoveStarted(InputAction.CallbackContext context)
    {
        _moveTimer.Start();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveTimer.Stop();
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        RotateFigure(context.ReadValue<float>());
    }

    private void MoveFigure(Vector2 direction)
    {
        _transform.TryMove(Vector2Int.RoundToInt(direction));
    }

    private void RotateFigure(float direction)
    {
        _transform.TryRotate((int)direction);
    }

    private class Timer
    {
        private readonly Action _action;
        private readonly float _frequency;

        private bool _isOn;
        private float _runningTime;

        public Timer(Action action, float frequency)
        {
            _action = action;
            _frequency = frequency;
        }

        public void Start()
        {
            _isOn = true;
            DoAction();
        }

        public void Stop() => _isOn = false;

        public void Tick(float deltaTime)
        {
            if (_isOn)
            {
                _runningTime += deltaTime;

                if (_runningTime >= _frequency)
                    DoAction();
            }
        }

        private void DoAction()
        {
            _action.Invoke();
            _runningTime = 0f;
        }
    }
}