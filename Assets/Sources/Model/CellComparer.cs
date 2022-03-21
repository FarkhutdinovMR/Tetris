using System.Collections.Generic;

namespace Tetris.Models
{
    public class CellComparer : IEqualityComparer<ICell>
    {
        public bool Equals(ICell x, ICell y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Position == y.Position;
        }

        public int GetHashCode(ICell product)
        {
            if (ReferenceEquals(product, null)) return 0;

            int hashProductCode = product.Position.GetHashCode();

            return hashProductCode;
        }
    }
}