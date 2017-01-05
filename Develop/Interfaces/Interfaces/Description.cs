using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator.Interfaces
{
    
    public sealed class Description : Attribute
    {
        public string Desc { get; set; }
    }
}
