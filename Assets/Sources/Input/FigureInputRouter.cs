using UnityEngine.InputSystem;
using Tetris.Models;
using System;
using UnityEngine;

public partial class FigureInputRouter : IMovement, IRotation
{
    private readonly FigureInput _figureInput;
    private readonly RepeatTimer _moveTimer;
    private readonly IMovement _movement;
    private readonly IRotation _rotation;
    private readonly float _rate = 0.1f;

    public FigureInputRouter(IMovement movement, IRotation rotation)
    {
        if (movement == null)
            throw new ArgumentNullException(nameof(movement));

        _movement = movement;
        _rotation = rotation;
        _figureInput = new FigureInput();
        _moveTimer = new RepeatTimer(() => Move(Vector2Int.RoundToInt(_figureInput.Figure.Move.ReadValue<Vector2>())), _rate);
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

    public void Move(Vector2Int direction)
    {
        _movement.Move(direction);
    }

    public void Rotate(int direction)
    {
        _rotation.Rotate(direction);
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
        Rotate((int)context.ReadValue<float>());
    }
}