using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class CupView : MonoBehaviour
{
    [SerializeField] private CellsViewFactory _cellsViewFactory;
    [SerializeField] private Transform _container;

    [SerializeField] private Range _hue;
    [SerializeField] private Range _saturation;
    [SerializeField] private Range _value;

    private Color RandomColor => Random.ColorHSV(_hue.Min, _hue.Max, _saturation.Min, _saturation.Max, _value.Min, _value.Max);

    public void BuildWalls(int width, int height)
    {
        var cells = new List<Pixel>();
        int heightOffset = height - 2;

        for (int i = -1; i < width + 1; i++)
        {
            cells.Add(new Pixel(new Vector2Int(i, -1), RandomColor));
            cells.Add(new Pixel(new Vector2Int(i, heightOffset), RandomColor));
        }

        for (int i = 0; i < heightOffset; i++)
        {
            cells.Add(new Pixel(new Vector2Int(-1, i), RandomColor));
            cells.Add(new Pixel(new Vector2Int(width, i), RandomColor));
        }

        Rotation rotation = new Rotation(cells);
        var rotations = new Rotation[] { rotation };
        var figure = new Figure(rotations, 1);

        _cellsViewFactory.Create(figure.Cells, _container);
    }
}