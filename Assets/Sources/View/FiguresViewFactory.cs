using UnityEngine;
using Tetris.Models;
using System.Collections.Generic;

public class FiguresViewFactory : MonoBehaviour
{
    [SerializeField] private CellColor _cellTemplate;
    [SerializeField] private TransformableView _figureTemplate;

    private TransformableView _figure;

    public void Create(Figure figure, Transformable transformable)
    {
        if (_figure != null)
            Destroy(_figure.gameObject);

        _figure = Instantiate(_figureTemplate);
        _figure.Init(transformable);
        _figure.transform.position = new Vector2(transformable.Position.x, transformable.Position.y);

        foreach (KeyValuePair<Vector2Int, Cell> cell in figure.Cells)
        {
            CellColor newCell = Instantiate(_cellTemplate, _figure.transform);
            newCell.transform.localPosition = new Vector2(cell.Key.x, cell.Key.y);
            newCell.Init(cell.Value.Color);
        }
    }
}