using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  class Billboard2
  {
    public class BillboardData
    {
      public int billboardCostPerDay;
      public string billboardText;
      public bool billboardActive;
    }

    private City.Position billboardPosition;
    private BillboardData billboardData;

    /// <summary>
    /// Начинает строить биллборд на заданной позиции с 1%-й стоимостью от постройки
    /// </summary>
    /// <param name="Position">Позиция в городе</param>
    /// <param name="AllCost">Общая затраченная цена на постройку</param>
    public Billboard2(City.Position Position)//, int AllCost)
    {
      Random Sychev = new Random();
      billboardPosition = Position;
      //billboardData.billboardCostPerDay = AllCost / 100;
      billboardData.billboardActive = false;
    }
    /// <summary>
    /// Активирует биллборд как готовый к заполнению
    /// </summary>
    public void ActivateBillboard()
    {
      billboardData.billboardActive = true;
    }
    public void TakeOrder(int Type, string Text)
    {
      switch (Type)
      {
        case 2: //Частный

          break;
        case 3: //Компания

          break;
        case 4: //Государственный

          break;
      }
    }
    public bool GetActiveState()
    {
        return billboardData.billboardActive;
    }
    public int GetBillboardMoney()
    {
        return billboardData.billboardCostPerDay;
    }
  }
}
