﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComponent.Events
{
    public class FilterChangedEventArgs
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
