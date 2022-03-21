using UnityEngine;
using Tetris.Models;

public class TransformableView : MonoBehaviour
{
    private Transformable _transformable;

    public void Init(Transformable transformable)
    {
        _transformable = transformable;
    }

    private void LateUpdate()
    {
        transform.position = new Vector2(_transformable.Position.x, _transformable.Position.y);
    }
}