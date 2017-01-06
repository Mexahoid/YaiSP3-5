using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator.Interfaces
{
    public interface IAgency
    {
        bool PassDay();

        int GetFreeBillboardsCount();

        int GetBuildingBillboardsCount();

        int QueueCount();

        int HowMuchCanWeAfford(int OrderCount);

        void PlaceBillboardRnd();

        List<(double, double)> GetAgencySummary();

        void DeleteOneBillboard();
    }
}
