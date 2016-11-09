using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  public class Agency
  {
    /// <summary>
    /// Стратегии агентства
    /// </summary>
    public enum Strategies
    {
      Conservative = 1,
      Normal,
      Aggressive
    }

    private Strategies agencyStrategy;
    private string agencyName;
    private int agencyDeposit;
    private int agencyBillboardsCount;
    private List<Billboard> agencyBillboards;

    public Agency(string Name, int Money, int Billboards, Strategies Strategy)
    {
      agencyName = Name;
      agencyDeposit = Money;
      agencyBillboards = new List<Billboard>();
      agencyBillboardsCount = Billboards;
      for (int i = 0; i < agencyBillboardsCount; i++)
        agencyBillboards.Add(new Billboard(MainUnitProcessor.CityReturnFreePosition()));
      agencyStrategy = Strategy;
    }

    /// <summary>
    /// Возвращает кортеж, состоящий из названия агентства, депозита, кол-ва щитов и стратегии
    /// </summary>
    /// <returns></returns>
    public Tuple<string, int, int, Strategies> GetData()
    {
      return Tuple.Create(agencyName, agencyDeposit, agencyBillboardsCount, agencyStrategy);
    }
    /// <summary>
    /// У агентства можно менять только название и стратегию
    /// </summary>
    /// <param name="Name">Новое имя агентства</param>
    /// <param name="Strategy">Стратегия агентства</param>
    public void ChangeMainData(string Name, Strategies Strategy) 
    {
      agencyName = Name;
      agencyStrategy = Strategy;
    }

    public void PlaceBillboardRnd()
    {
      if (MainUnitProcessor.DateIsWorkday())
      {
        /*Random Sychev = new Random();
        if (Sychev.Next(1, 5) == 4)
          agencyBillboards.Add(new Billboard(MainUnitProcessor.CityReturnFreePosition()));*/  
      }
    }
    public void PassDay()
    {
      int AllMoneyForDay = 0;
      for (int i = 0; i < agencyBillboardsCount; i++)
        AllMoneyForDay += agencyBillboards[i].GetBillboardMoney();
      PlaceBillboardRnd();
    }
  }
}