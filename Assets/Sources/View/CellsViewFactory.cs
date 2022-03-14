using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class CellsViewFactory : MonoBehaviour
{
    [SerializeField] private CellColor _cellTemplate;

    public List<GameObject> Create(IReadOnlyDictionary<Vector2Int, Cell> cells, Transform container)
    {
        List<GameObject> newCells = new List<GameObject>();

        foreach (KeyValuePair<Vector2Int, Cell> cell in cells)
        {
            CellColor newCell = Instantiate(_cellTemplate, container);
            newCell.transform.localPosition = new Vector2(cell.Key.x, cell.Key.y);
            newCell.Init(cell.Value.Color);
            newCells.Add(newCell.gameObject);
        }

        return newCells;
    }
}