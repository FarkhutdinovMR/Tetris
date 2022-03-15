using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class CellsViewFactory : MonoBehaviour
{
    [SerializeField] private CellColor _cellTemplate;

    public List<GameObject> Create(IReadOnlyList<IReadOnlyCell> cells, Transform container)
    {
        List<GameObject> newCells = new List<GameObject>();

        foreach (Cell cell in cells)
        {
            CellColor newCell = Instantiate(_cellTemplate, container);
            newCell.transform.localPosition = new Vector2(cell.Position.x, cell.Position.y);
            newCell.Init(cell.Color);
            newCells.Add(newCell.gameObject);
        }

        return newCells;
    }
}