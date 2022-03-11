using UnityEngine;
using UnityEngine.UI;

public class ImageCellColor : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Init(Color color)
    {
        _image.color = color;
    }
}