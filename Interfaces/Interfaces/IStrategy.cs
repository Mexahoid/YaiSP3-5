﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator.Interfaces
{
    public interface IStrategy
    {      
        bool Action();

        bool BuildOrderedBillboards();

        void CreateLink(IAgency agency);
    }
}