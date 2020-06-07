using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternalSort_n11b_
{
    class Comparer
    {
        public int Count { get; private set; }

        public Comparer()
        {
            Count = 0;
        }

        public int Compare(int a, int b)
        {
            Count++;
            return a - b;
        }
    }
}
