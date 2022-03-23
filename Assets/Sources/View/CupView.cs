using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class CupView : MonoBehaviour
{
    [SerializeField] private CellsViewFactory _cellsViewFactory;
    [SerializeField] private Transform _container;
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private Range _hue;
    [SerializeField] private Range _saturation;
    [SerializeField] private Range _value;

    private IEnumerable<GameObject> _cells;

    private Color RandomColor => Random.ColorHSV(_hue.Min, _hue.Max, _saturation.Min, _saturation.Max, _value.Min, _value.Max);

    public void BuildWalls()
    {
        if (_cells != null)
        {
            foreach (GameObject cell in _cells)
                DestroyImmediate(cell);
        }

        var cells = new List<ICell>();
        int heightOffset = _height - 2;

        for (int i = -1; i < _width + 1; i++)
        {
            cells.Add(new Pixel(new Vector2Int(i, -1), RandomColor));
            cells.Add(new Pixel(new Vector2Int(i, heightOffset), RandomColor));
        }

        for (int i = 0; i < heightOffset; i++)
        {
            cells.Add(new Pixel(new Vector2Int(-1, i), RandomColor));
            cells.Add(new Pixel(new Vector2Int(_width, i), RandomColor));
        }

        Shape rotation = new Shape(cells);
        var rotations = new Shape[] { rotation };
        var figure = new Figure(rotations, 1);

        _cells = _cellsViewFactory.Create(figure.Cells, _container);
    }
}