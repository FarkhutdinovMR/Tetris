using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class CupView : MonoBehaviour
{
    [SerializeField] private CellsViewFactory _cellsViewFactory;
    [SerializeField] private CellColor _cellTemplate;
    [SerializeField] private Transform _cupWalls;
    [SerializeField] private Transform _container;

    [SerializeField] private Range _hue;
    [SerializeField] private Range _saturation;
    [SerializeField] private Range _value;

    private List<GameObject> _cells = new List<GameObject>();

    private Color RandomColor => Random.ColorHSV(_hue.Min, _hue.Max, _saturation.Min, _saturation.Max, _value.Min, _value.Max);

    public void Render(IReadOnlyDictionary<Vector2Int, Cell> cells)
    {
        foreach (GameObject cell in _cells)
            Destroy(cell);

        _cells = _cellsViewFactory.Create(cells, _container);
    }

    public void BuildWalls(int width, int height)
    {
        var dictionary = new Dictionary<Vector2Int, Cell>();
        int heightOffset = height - 2;

        for (int i = -1; i < width + 1; i++)
        {
            dictionary.Add(new Vector2Int(i, -1), new Cell(RandomColor));
            dictionary.Add(new Vector2Int(i, heightOffset), new Cell(RandomColor));
        }

        for (int i = 0; i < heightOffset; i++)
        {
            dictionary.Add(new Vector2Int(-1, i), new Cell(RandomColor));
            dictionary.Add(new Vector2Int(width, i), new Cell(RandomColor));
        }

        Shape shape = new Shape(dictionary);
        var shapes = new Shape[] { shape };
        var figure = new Figure(shapes, 1);

        _cellsViewFactory.Create(figure.Cells, _cupWalls);
    }
}