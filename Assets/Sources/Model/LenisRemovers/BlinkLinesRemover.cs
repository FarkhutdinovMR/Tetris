using System;
using UnityEngine;

namespace Tetris.Models
{
    public class BlinkLinesRemover : TimeLinesRemover
    {
        private float _color;

        public BlinkLinesRemover(Cup cup, Action onEnd, float speed, int repeat)
            : base(cup, onEnd, speed, repeat)
        {
        }

        protected override void OnUpdate()
        {
            _color += 0.5f;
            _color = Mathf.Repeat(_color, 1);

            foreach (Pixel cell in RemovingCells)
                cell.Repaint(new Color(_color, _color, _color));

            Cup.ChangeCells();
        }

        protected override void OnEnd()
        {
            Cup.RemoveCells(RemovingCells);
            base.OnEnd();
        }
    }
}