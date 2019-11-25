using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MathGen
{
    public class NumberCollectionLine : IComparable<NumberCollectionLine>
    {
        public List<int> Numbers { get; set; }

        public int Count => Numbers == null ? 0 : Numbers.Count;
        public int RowNumber { get; set; }

        public int CompareTo([AllowNull] NumberCollectionLine t)
        {
            if (t == null)
            {
                return 0;
            }

            return RowNumber.CompareTo(t.RowNumber);
        }
    }
}
