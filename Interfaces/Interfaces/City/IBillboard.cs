using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Types;

namespace AgencySimulator.Interfaces
{
    public interface IBillboard : IElement
    {
        BillboardState GetState();

        int GetAgencyId();

        bool BillboardBuildToEnd();
        
        void Invalidate();

        bool PassDay();
        
        bool BillboardBuilded();
        
        bool BillboardIsFilled();

        void BillboardFill(IClient Client);

        int BillboardPayMoney();
        
        int ClientPay();
    }
}
