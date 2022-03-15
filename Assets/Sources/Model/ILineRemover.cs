using System;
using System.Collections.Generic;

namespace Tetris.Models
{
    public interface ILineRemover
    {
        public event Action<int> LineDeleted;
    }
}