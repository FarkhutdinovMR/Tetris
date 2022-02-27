using UnityEngine;
using Tetris.Models;

namespace CompositeRoot
{
    public class CupCompositeRoot : CompositeRoot
    {
        private Cup _cup;

        public override void Compose()
        {
            var map = new bool[10, 20];
            _cup = new Cup(new Shape(map));
        }
    }
}