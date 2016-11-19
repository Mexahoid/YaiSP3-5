using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public class Agency
    {
        private string agencyName;
        private int agencyDeposit;
        private List<Billboard> agencyBillboards;
        private int agencyFreeBillboards;
        private double agencyProfitCoeff;

        //Первичные методы
        public Agency(string Name, int Money, int Billboards)
        {
            agencyName = Name;
            agencyDeposit = Money;
            agencyBillboards = new List<Billboard>();

            agencyFreeBillboards = Billboards;
            for (int i = 0; i < agencyFreeBillboards; i++)
                PlaceBillboardRnd();
        }

        /// <summary>
        /// Возвращает кортеж, состоящий из названия агентства, депозита, кол-ва щитов и стратегии
        /// </summary>
        /// <returns></returns>
        public Tuple<string, int, int> GetData()
        {
            return Tuple.Create(agencyName, agencyDeposit, agencyBillboards.Count);
        }

        /// <summary>
        /// У агентства можно менять только название и стратегию
        /// </summary>
        /// <param name="Name">Новое имя агентства</param>
        /// <param name="Strategy">Стратегия агентства</param>
        public void ChangeName(string Name)
        {
            agencyName = Name;
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
            int Temp = agencyDeposit;
            for (int i = 0; i < agencyBillboards.Count; i++)
                agencyDeposit += agencyBillboards[i].BillboardGetMoney();  //Собрать деньги с биллбордов
            agencyProfitCoeff = agencyDeposit / (double)Temp;              //Рассчитать коэффициент дохода
        }

        /// <summary>
        /// Заполняет случайный биллборд заказом клиента
        /// </summary>
        /// <param name="ClientDesire">Кортеж желания клиента</param>
        public void FillBillboard(Tuple<string, int, byte> ClientDesire)
        {
            MainUnitProcessor.CityBillboardFillRandom(ClientDesire);
        }

        /// <summary>
        /// Возвращает баланс агентства.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int GetAgencyDeposit()
        {
            return agencyDeposit;
        }

        /// <summary>
        /// Возвращает коэффициент дохода агентства
        /// </summary>
        /// <returns>Возвращает вещественное значение</returns>
        public double GetAgencyProfitCoeff()
        {
            return agencyProfitCoeff;
        }
    }
}