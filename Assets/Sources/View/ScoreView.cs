using UnityEngine;
using TMPro;
using Tetris.Models;
using System;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _lineText;

    private Statistics _score;

    public void Init(Statistics score)
    {
        if (score == null)
            throw new ArgumentNullException(nameof(score));

        _score = score;
    }

    public void Enable()
    {
        _score.ValueChanged += OnValueChanged;
    }

    public void Disable()
    {
        _score.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int score, int lineCount)
    {
        _scoreText.SetText(score.ToString());
        _lineText.SetText(lineCount.ToString());
    }
}