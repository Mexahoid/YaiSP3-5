using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  class Billboard
  {
    public class BillboardData
    {
      private int billboardCostPerDay;
      private int billboardProfitPerDay;
      private string billboardText;

    }
    private int billboardCostPerDay;
    private int billboardProfitPerDay;
    private City.Position billboardPosition;

    public Billboard(City.Position Position)
    {
      Random Sychev = new Random();
      billboardPosition = Position;
      billboardCostPerDay = Sychev.Next(1, 100);
      billboardProfitPerDay = Sychev.Next(1, 100);
    }
    public int GetBillboardMoney()
    {
      return billboardProfitPerDay - billboardCostPerDay;
    }
  }
}
