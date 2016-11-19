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
        private int agencyStaffCount;
        private List<double[]> agencySummary;

        //Первичные методы
        public Agency(string Name, int Money, int Billboards)
        {
            agencyName = Name;
            agencyDeposit = Money;
            agencyBillboards = new List<Billboard>();
            agencySummary = new List<double[]>();
            agencyStaffCount = 1 + Billboards * 3;  //Глава + обслуга

            agencyFreeBillboards = 0;
            for (int i = 0; i < Billboards; i++)
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
        /// Меняет название агентства
        /// </summary>
        /// <param name="Name">Новое имя агентства</param>
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
            int Cost = 10000 + MainUnitProcessor.GetRandomValue(-1000, 1000);
            Billboard Billboard = new Billboard(Cost);
            MainUnitProcessor.CityBillboardPlace(Billboard);   //Добавляем на карту города
            agencyBillboards.Add(Billboard);
            agencyDeposit -= Cost;
        }

        /// <summary>
        /// Провести день работы.
        /// </summary>
        public void PassDay()
        {
            agencyFreeBillboards += MainUnitProcessor.CityBillboardsBuildToEnd();
            int Temp = agencyDeposit;
            while (agencyFreeBillboards > 0 && !MainUnitProcessor.QueueIsNull())
            {
                FillBillboard(MainUnitProcessor.QueueTakeOrder());
                agencyFreeBillboards--;
            }

            agencyDeposit -= agencyStaffCount * 10;                        //Заплатить стаффу
            for (int i = 0; i < agencyBillboards.Count; i++)
                agencyDeposit += agencyBillboards[i].BillboardGetMoney();  //Собрать деньги с биллбордов
            agencySummary.Add(new double[] { agencySummary.Count *2, agencyDeposit / 10000.0 });
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

        public List<double[]> GetAgencySummary()
        {
            return agencySummary;
        }
    }
}