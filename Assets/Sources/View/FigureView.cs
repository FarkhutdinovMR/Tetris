using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class FigureView : MonoBehaviour
{
    [SerializeField] private CellsViewFactory _cellsViewFactory;

    private List<GameObject> _cells = new List<GameObject>();

    public void Create(IReadOnlyDictionary<Vector2Int, Cell> cells)
    {
        foreach (GameObject cell in _cells)
            Destroy(cell);

        _cells = _cellsViewFactory.Create(cells, transform);
    }
}