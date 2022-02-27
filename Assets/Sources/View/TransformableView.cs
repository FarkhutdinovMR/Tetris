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
        transform.position = Transformable.Position;
        transform.rotation = Quaternion.Euler(0, 0, Transformable.Rotation);
    }
}