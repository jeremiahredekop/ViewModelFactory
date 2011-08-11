using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// This code is property of GeniusCode, LLC
// Licensed under MS-PL

namespace WpfApplication1
{
    public class InstanceBehaviorAttribute : Attribute
    {
        public InstanceBehaviorAttribute(bool shareInstances)
        {
            ShareInstances = shareInstances;
        }

        public bool ShareInstances { get; set; }
    }
}
