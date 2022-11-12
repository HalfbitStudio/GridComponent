using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComponent.Events
{
    public class GridFilterEventArgs
    {
        public Dictionary<string, string> Filters { get; set; }
    }
}
