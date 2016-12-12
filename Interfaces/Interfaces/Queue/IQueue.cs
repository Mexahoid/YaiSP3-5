using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Types;

namespace AgencySimulator.Interfaces
{
    public interface IQueue
    {
        void QueueAdd(IClient Data);

        bool QueueIsNull();
        
        IClient QueueTakeClient();

        int GetQueueCount();
    }
}
