using UnityEngine;
using Tetris.Models;
using System.Collections.Generic;

public class FiguresViewFactory : MonoBehaviour
{
    [SerializeField] private List<TransformableView> _figures;

    public void Create(Transformable transformable, int index)
    {
        TransformableView transformableView = Instantiate(_figures[index]);
        transformableView.Init(transformable);
    }
}