using UnityEngine;
using Tetris.Models;
using System;

public class CupView : MonoBehaviour
{
    [SerializeField] private GameObject _cellTemplate;

    private ICup _cup;
    private GameObject[,] _cells;

    public void Init(Cup cup)
    {
        if (cup == null)
            throw new ArgumentNullException(nameof(cup));

        _cup = cup;
        _cup.CellChanged += OnChanged;
        _cells = new GameObject[_cup.Width, _cup.Height];
        CreateCup();
    }

    private void OnDisable()
    {
        _cup.CellChanged -= OnChanged;
    }

    private void CreateCup()
    {
        for (int y = 0; y < _cup.Height; y++)
        {
            for (int x = 0; x < _cup.Width; x++)
            {
                _cells[x, y] = Instantiate(_cellTemplate, new Vector2(x, y), Quaternion.identity, transform);
                _cells[x, y].SetActive(false);
            }
        }
    }

    private void OnChanged()
    {
        Rendere();
    }

    private void Rendere()
    {
        for (int y = 0; y < _cup.Height; y++)
        {
            for (int x = 0; x < _cup.Width; x++)
            {
                if (_cup.Cells[x, y] == true)
                    _cells[x, y].SetActive(true);
                else
                    _cells[x, y].SetActive(false);
            }
        }
    }
}