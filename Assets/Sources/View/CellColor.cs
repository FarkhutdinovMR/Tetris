using UnityEngine;

public class CellColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    public void Init(Color color)
    {
        _sprite.color = color;
    }
}