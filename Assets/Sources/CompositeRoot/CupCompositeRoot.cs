using UnityEngine;
using Tetris.Models;

namespace CompositeRoot
{
    public class CupCompositeRoot : CompositeRoot
    {
        [SerializeField] private CupView _cupView;

        public Cup Cup { get; private set; }

        public override void Compose()
        {
            Cup = new Cup(new bool[10, 22]);
            _cupView.Init(Cup);
        }
    }
}