using UnityEngine;
using Tetris.Models;

public class TransformableView : MonoBehaviour
{
    public Transformable Transformable { get; private set; }

    public void Init(Transformable transformable)
    {
        Transformable = transformable;
    }

    public void LateUpdate()
    {
        if (Transformable == null)
            return;

        transform.position = new Vector2(Transformable.Position.x, Transformable.Position.y);
        transform.rotation = Quaternion.Euler(0, 0, Transformable.Rotation);
    }
}