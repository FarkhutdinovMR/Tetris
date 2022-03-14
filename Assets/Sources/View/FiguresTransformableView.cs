using Tetris.Models;
using UnityEngine;

public class FiguresTransformableView : MonoBehaviour
{
    [SerializeField] private CellsViewFactory _cellsViewFactory;
    [SerializeField] private TransformableView _figureTemplate;

    private TransformableView _figure;

    public void Create(Figure figure, IMovement transformable)
    {
        if (_figure != null)
            Destroy(_figure.gameObject);

        _figure = Instantiate(_figureTemplate);
        _figure.Init(transformable);
        _figure.transform.position = new Vector2(transformable.Position.x, transformable.Position.y);

        _cellsViewFactory.Create(figure.Cells, _figure.transform);
    }
}