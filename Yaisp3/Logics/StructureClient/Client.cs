using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  class Client
  {
    protected bool clientHighPriority;
    protected string clientName;
    protected string clientDesire;
    protected int clientOffering;

    protected Client(string Name, string Desire)
    {
      clientName = Name;
      clientHighPriority = false;
      clientDesire = Desire;
    }

    public Tuple<bool, string, int> GetOrder()
    {
      return Tuple.Create(clientHighPriority, clientDesire, clientOffering);
    }
  }

  class ClientPhysical : Client
  {
    public ClientPhysical(string Name, string Desire) : base(Name, Desire)
    {
      clientOffering = MainUnitProcessor.GetRandomValue(1, 100);
    }
  }
  class ClientCompany : Client
  {
    public ClientCompany(string Name, string Desire) : base(Name, Desire)
    {
      clientOffering = MainUnitProcessor.GetRandomValue(50, 5000);
    }
  }
  class ClientGovernment : Client
  {
    public ClientGovernment(string Name, string Desire) : base(Name, Desire)
    {
      clientHighPriority = true;
      clientOffering = MainUnitProcessor.GetRandomValue(500, 20000);
    }
  }
}
