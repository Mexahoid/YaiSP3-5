using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  public class Agency
  {
    public enum Strategies
    {
      Conservative = 1,
      Normal,
      Aggressive
    }
    Strategies agencyStrategy;
    string agencyName;
    int agencyDeposit;
    int agencyBillboardsCount;

    public Agency(string Name, int Money, int Billboards, Strategies Strategy)
    {
      agencyName = Name;
      agencyDeposit = Money;
      agencyBillboardsCount = Billboards;
      agencyStrategy = Strategy;
    }
    public void GetData(out string Name, out int Money, out int Billboards, out Strategies Strategy)
    {
      Name = agencyName;
      Money = agencyDeposit;
      Billboards = agencyBillboardsCount;
      Strategy = agencyStrategy;
    }
    public void ChangeMainData(string Name, Strategies Strategy)
    {
      agencyName = Name;
      agencyStrategy = Strategy;
    }
  }
}
