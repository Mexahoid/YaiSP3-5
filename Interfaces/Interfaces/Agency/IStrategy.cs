using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator;

namespace AgencySimulator.Interfaces
{
    public interface IStrategy
    {
        string StrategyName { get; }
        
        
        bool Action();

    }
}
