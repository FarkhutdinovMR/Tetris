using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

class FigureView : MonoBehaviour
{
    [SerializeField] private CellColor _cellTemplate;

    private readonly List<GameObject> _cells = new List<GameObject>();

    public void Show(Figure figure)
    {
        foreach (GameObject cell in _cells)
            Destroy(cell);

        _cells.Clear();

        foreach (KeyValuePair<Vector2Int, Cell> cell in figure.Cells)
        {
            CellColor newCell = Instantiate(_cellTemplate, transform);
            newCell.transform.localPosition = new Vector2(cell.Key.x, cell.Key.y);
            newCell.Init(cell.Value.Color);
            _cells.Add(newCell.gameObject);
        }
    }
}