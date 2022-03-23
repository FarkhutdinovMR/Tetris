using System;
using Tetris.Models;
using UnityEngine;
using UnityEngine.InputSystem;

public class FigureInputRouter : IMovement, IRotation
{
    private readonly FigureInput _figureInput;
    private readonly RepeatTimer _horizontalMoveTimer;
    private readonly RepeatTimer _verticalMoveTimer;
    private readonly IMovement _movement;
    private readonly IRotation _rotation;
    private readonly float _horizontalRate = 0.1f;
    private readonly float _verticalRate = 0.05f;

    public FigureInputRouter(IMovement movement, IRotation rotation)
    {
        if (movement == null)
            throw new ArgumentNullException(nameof(movement));

        if (rotation == null)
            throw new ArgumentNullException(nameof(rotation));

        _movement = movement;
        _rotation = rotation;
        _figureInput = new FigureInput();
        _horizontalMoveTimer = new RepeatTimer(() => Move(new Vector2Int((int)_figureInput.Figure.HorizontalMove.ReadValue<float>(), 0)), _horizontalRate);
        _verticalMoveTimer = new RepeatTimer(() => Move(new Vector2Int(0, (int)_figureInput.Figure.VerticalMove.ReadValue<float>())), _verticalRate);
    }

    public void OnEnable()
    {
        _figureInput.Enable();
        _figureInput.Figure.HorizontalMove.started += OnMoveStarted;
        _figureInput.Figure.HorizontalMove.canceled += OnMoveCanceled;
        _figureInput.Figure.VerticalMove.started += OnVerticalMoveStarted;
        _figureInput.Figure.VerticalMove.canceled += OnVerticalMoveCanceled;
        _figureInput.Figure.Rotate.performed += OnRotate;
    }

    public void OnDisable()
    {
        _figureInput.Disable();
        _figureInput.Figure.HorizontalMove.started -= OnMoveStarted;
        _figureInput.Figure.HorizontalMove.canceled -= OnMoveCanceled;
        _figureInput.Figure.VerticalMove.started -= OnVerticalMoveStarted;
        _figureInput.Figure.VerticalMove.canceled -= OnVerticalMoveCanceled;
        _figureInput.Figure.Rotate.performed -= OnRotate;
    }

    public void Update(float deltaTime)
    {
        _horizontalMoveTimer.Tick(deltaTime);
        _verticalMoveTimer.Tick(deltaTime);
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
        _horizontalMoveTimer.Start();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _horizontalMoveTimer.Stop();
    }

    private void OnVerticalMoveStarted(InputAction.CallbackContext context)
    {
        _verticalMoveTimer.Start();
    }

    private void OnVerticalMoveCanceled(InputAction.CallbackContext context)
    {
        _verticalMoveTimer.Stop();
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        Rotate((int)context.ReadValue<float>());
    }
}