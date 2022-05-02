using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComponent.Utils
{
    enum SortOrder { None = 0, Ascending = 1, Descending = 2 }
    class SortUtils
    {
        public static SortOrder GetNextOrderValue(SortOrder orderBy)
        {
            int currentValue = (int)orderBy;
            return (SortOrder)(++currentValue % 3);
        }
    }
}
