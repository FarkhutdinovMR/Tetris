using System;
using UnityEngine;

[Serializable]
public struct Range
{
    [SerializeField] [Range(0, 1)] private float _min;
    [SerializeField] [Range(0, 1)] private float _max;

    public Range(float min, float max)
    {
        if (min >= max)
            throw new ArgumentOutOfRangeException(nameof(min));

        _min = min;
        _max = max;
    }

    public float Min => _min;

    public float Max => _max;
}