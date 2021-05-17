using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComponent.Events
{
    public class SortEventArgs
    {
        public string OrderByColumn { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
