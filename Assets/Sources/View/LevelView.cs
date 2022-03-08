using UnityEngine;
using TMPro;
using Tetris.Models;
using System;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Level _level;

    public void Init(Level level)
    {
        if (level == null)
            throw new ArgumentNullException(nameof(level));

        _level = level;
        _level.Changed += OnChanged;
    }

    private void OnDisable()
    {
        if (_level != null)
            _level.Changed -= OnChanged;
    }

    private void OnChanged(int level)
    {
        _text.SetText(level.ToString());
    }
}