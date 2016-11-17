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
        private List<Billboard> agencyBillboards;
        private int agencyFreeBillboards;

        //Первичные методы
        public Agency(string Name, int Money, int Billboards, Strategies Strategy)
        {
            agencyName = Name;
            agencyDeposit = Money;
            agencyBillboards = new List<Billboard>();

            agencyFreeBillboards = Billboards;
            for (int i = 0; i < agencyFreeBillboards; i++)
                PlaceBillboardRnd();
            agencyStrategy = Strategy;
        }

        /// <summary>
        /// Возвращает кортеж, состоящий из названия агентства, депозита, кол-ва щитов и стратегии
        /// </summary>
        /// <returns></returns>
        public Tuple<string, int, int, Strategies> GetData()
        {
            return Tuple.Create(agencyName, agencyDeposit, 10, agencyStrategy);
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

        //Методы интерфейса

        /// <summary>
        /// Устанавливает биллборд на случайном месте
        /// </summary>
        public void PlaceBillboardRnd()
        {
            Billboard Billboard = new Billboard(10000 + MainUnitProcessor.GetRandomValue(-1000, 1000));
            MainUnitProcessor.CityBillboardPlace(Billboard);   //Добавляем на карту города
            agencyBillboards.Add(Billboard);
        }

        /// <summary>
        /// Провести день работы.
        /// </summary>
        public void PassDay()
        {
            MainUnitProcessor.CityBillboardsBuildToEnd();
            for (int i = 0; i < agencyBillboards.Count; i++)
                agencyDeposit += agencyBillboards[i].BillboardGetMoney();
            PlaceBillboardRnd();
        }

        /// <summary>
        /// Возвращает баланс агентства.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int GetAgencyDeposit()
        {
            return agencyDeposit;
        }
    }
}