using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class CellsView : MonoBehaviour
{
    [SerializeField] private CellsViewFactory _cellsViewFactory;

    private List<GameObject> _cells = new List<GameObject>();

    public void Create(IReadOnlyList<IReadOnlyCell> cells)
    {
        foreach (GameObject cell in _cells)
            Destroy(cell);

        _cells = _cellsViewFactory.Create(cells, transform);
    }
}