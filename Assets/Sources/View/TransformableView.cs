using UnityEngine;
using Tetris.Models;

public class TransformableView : MonoBehaviour
{
    private IMovement _transformable;

    public void Init(IMovement transformable)
    {
        _transformable = transformable;
    }

    public void LateUpdate()
    {
        transform.position = new Vector2(_transformable.Position.x, _transformable.Position.y);
    }
}