using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Interfaces;

namespace AgencySimulator.Plugins
{
    class Normal : IStrategy
    {
        IAgency agency;
        /// <summary>
        /// Пытается установить столько же биллбордов, сколько заказов сейчас в очереди.
        /// </summary>
        private bool BuildOrderedBillboards()
        {
            if (agency.PassDay())
            {
                if (agency.GetBuildingBillboardsCount() == 0)
                {
                    int Count = agency.HowMuchCanWeAfford(
                         agency.QueueCount());
                    for (int i = 0; i < Count; i++)
                        agency.PlaceBillboardRnd();
                }
                return true;
            }
            return false;
        }

    }
}
