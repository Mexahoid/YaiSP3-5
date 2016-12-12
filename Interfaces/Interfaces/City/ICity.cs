using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator.Interfaces
{
    public interface ICity
    {
        Tuple<IBillboardDrawer, IBillboard> PlaceBillboard(int Cost, int AgencyId);

        void DeleteBillboards();

        bool DeleteOneBillboard();
    }
}
