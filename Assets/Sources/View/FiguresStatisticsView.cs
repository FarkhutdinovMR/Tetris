using System.Collections.Generic;
using Tetris.Models;
using UnityEngine;

public class FiguresStatisticsView : MonoBehaviour
{
    [SerializeField] private CellsViewFactory _cellsViewFactory;
    [SerializeField] private Transform _figureContainer;
    [SerializeField] private TextView _textTemplate;
    [SerializeField] private Transform _figuresContainer;
    [SerializeField] private float _space;

    private readonly List<TextView> _textViews = new List<TextView>();
    private float _verticalOffset;

    public void Render(IEnumerable<Slot> figures)
    {
        _verticalOffset = 0;

        if (_textViews != null && _textViews.Count > 0)
        {
            int i = 0;
            foreach (Slot figure in figures)
            {
                _textViews[i].Set(figure.Count);
                i++;
            }

            return;
        }

        foreach (Slot figure in figures)
        {
            Transform figureView = Instantiate(_figureContainer, _figuresContainer);
            figureView.transform.localPosition -= new Vector3(0, _verticalOffset);
            _cellsViewFactory.Create(figure.Figure.Cells, figureView);

            TextView textView = Instantiate(_textTemplate, transform);
            textView.Set(figure.Count);
            _textViews.Add(textView);

            _verticalOffset += _space;
        }
    }
}