using UnityEngine.InputSystem;
using Tetris.Models;
using System;
using UnityEngine;

public class FigureInputRouter
{
    private FigureInput _figureInput;
    private Transformable _figureTransformable;

    public FigureInputRouter()
    {
        _figureInput = new FigureInput();
    }

    public void SetFigureTransformable(Transformable figureTransformable)
    {
        if (figureTransformable == null)
            throw new ArgumentNullException(nameof(figureTransformable));

        _figureTransformable = figureTransformable;
    }

    public void Enable()
    {
        _figureInput.Enable();
        _figureInput.Figure.Move.performed += OnFigureMove;
        _figureInput.Figure.Rotate.performed += OnRotateMove;
    }

    public void Disable()
    {
        _figureInput.Disable();
        _figureInput.Figure.Move.performed -= OnFigureMove;
        _figureInput.Figure.Rotate.performed -= OnRotateMove;
    }

    private void OnFigureMove(InputAction.CallbackContext context)
    {
        MoveFigure(context.ReadValue<Vector2>());
    }

    private void OnRotateMove(InputAction.CallbackContext context)
    {
    }

    private void MoveFigure(Vector2 direction)
    {
        _figureTransformable.Translate(direction);
    }
}