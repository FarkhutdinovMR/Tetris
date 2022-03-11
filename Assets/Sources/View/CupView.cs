using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class CupView : MonoBehaviour
{
    [SerializeField] private CellColor _cellTemplate;

    private List<GameObject> _cells = new List<GameObject>();

    public void Render(IReadOnlyDictionary<Vector2Int, Cell> cells)
    {
        foreach (GameObject cell in _cells)
            Destroy(cell);

        _cells.Clear();

        foreach (KeyValuePair<Vector2Int, Cell> cell in cells)
        {
            CellColor newCell = Instantiate(_cellTemplate, new Vector2(cell.Key.x, cell.Key.y), Quaternion.identity, transform);
            newCell.Init(cell.Value.Color);
            _cells.Add(newCell.gameObject);
        }
    }
}