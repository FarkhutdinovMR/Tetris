using UnityEngine;
using Tetris.Models;

public class FiguresViewFactory : MonoBehaviour
{
    [SerializeField] private Transform _cellTemplate;
    [SerializeField] private TransformableView _figureTemplate;

    private TransformableView _figureView;

    public void Create(Figure figure, Transformable transformable)
    {
        if (_figureView != null)
            Destroy(_figureView.gameObject);

        _figureView = Instantiate(_figureTemplate);
        _figureView.Init(transformable);
        _figureTemplate.transform.position = new Vector2(transformable.Position.x, transformable.Position.y);

        foreach (Vector2Int position in figure.Cells)
        {
            Transform cell = Instantiate(_cellTemplate, _figureView.transform);
            cell.localPosition = new Vector2(position.x, position.y);
        }
    }
}