using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс агентства.
    /// </summary>
    public sealed class Agency
    {
        #region Поля

        /// <summary>
        /// Название агентства.
        /// </summary>
        private string agencyName;

        /// <summary>
        /// Бюджет агентства.
        /// </summary>
        private int agencyDeposit;

        /// <summary>
        /// Список биллбордов агентства.
        /// </summary>
        private List<Billboard> agencyBillboards;

        /// <summary>
        /// Количество свободных построенных(!) биллбордов.
        /// </summary>
        private int agencyFreeBillboards;

        /// <summary>
        /// Количество рабочего персонала.
        /// </summary>
        private int agencyStaffCount;

        /// <summary>
        /// Список из подневных коэффициентов бюджета.
        /// </summary>
        private List<Tuple<double, double>> agencySummary;

        private City cityLink;

        private QueueClass queueLink;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор агентства.
        /// </summary>
        /// <param name="Name">Название агентства.</param>
        /// <param name="Money">Начальный депозит.</param>
        /// <param name="Billboards">Кол-во биллбордов.</param>
        public Agency(string Name, int Money, int Billboards, City city, QueueClass queue)
        {
            cityLink = city;
            queueLink = queue;


            agencyName = Name;
            agencyDeposit = Money;
            agencyBillboards = new List<Billboard>();
            agencySummary = new List<Tuple<double, double>>();
            agencyStaffCount = 1 + Billboards * 3;  //Глава + обслуга

            agencyFreeBillboards = 0;
            for (int i = 0; i < Billboards; i++)
                PlaceBillboardRnd();
        }

        #region Обмен информацией 

        /// <summary>
        /// Возвращает кортеж, состоящий из названия агентства, депозита, кол-ва щитов и стратегии.
        /// </summary>
        /// <returns>Возвращает кортеж из строки и двух целочисленных значений.</returns>
        public Tuple<string, int, int> GetData()
        {
            return Tuple.Create(agencyName, agencyDeposit, agencyBillboards.Count);
        }

        /// <summary>
        /// Меняет название агентства.
        /// </summary>
        /// <param name="Name">Новое имя агентства.</param>
        public void ChangeName(string Name)
        {
            agencyName = Name;
        }

        public int QueueCount()
        {
            return queueLink.GetQueueCount();
        }

        #endregion

        /// <summary>
        /// Устанавливает биллборд на случайном месте.
        /// </summary>
        public void PlaceBillboardRnd()
        {
            int Cost = 10000 + MiscellaneousLogics.MainGetRandomValue(-1000, 1000);
            Billboard Billboard = new Billboard(Cost);
            cityLink.PlaceBillboard(Billboard);   //Добавляем на карту города
            agencyBillboards.Add(Billboard);
            agencyDeposit -= Cost;
        }

        /// <summary>
        /// Провести день работы.
        /// </summary>
        public void PassDay()
        {
            foreach (Billboard Bb in agencyBillboards)
                if (!Bb.BillboardBuilded())
                {
                    Bb.BillboardBuildToEnd();
                    agencyFreeBillboards += 1;
                }
            int Temp = agencyDeposit;
            while (agencyFreeBillboards > 0 && !queueLink.QueueIsNull())
            {
                FillBillboard(queueLink.QueueTakeClient());
                agencyFreeBillboards--;
            }

            agencyDeposit -= agencyStaffCount * 10;                        //Заплатить стаффу
            for (int i = 0; i < agencyBillboards.Count; i++)
            {
                agencyDeposit -= agencyBillboards[i].BillboardPayMoney();  //Заплатить за содержание
                agencyDeposit += agencyBillboards[i].ClientPay();          //Собрать деньгу с заказчика
            }
            agencySummary.Add(Tuple.Create(agencySummary.Count * 0.2, agencyDeposit / 10000.0));
        }

        /// <summary>
        /// Заполняет первый свободный биллборд заказом клиента.
        /// </summary>
        /// <param name="ClientDesire">Кортеж желания клиента.</param>
        public void FillBillboard(TemplateClient Client)
        {
            int L = agencyBillboards.Count;
            for (int i = 0; i < L; i++)
                if (!agencyBillboards[i].BillboardIsFilled())
                {
                    agencyBillboards[i].BillboardFill(Client);
                    break;
                }
        }

        /// <summary>
        /// Возвращает число позволяемых установиться биллбордов.
        /// </summary>
        /// <param name="OrderCount">Количество заказов в очереди.</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int HowMuchCanWeAfford(int OrderCount)
        {
            int temp = agencyDeposit;
            int i;
            for (i = 0; i < OrderCount && temp > 0; i++)
                temp -= 11000;
            return i;
        }

        /// <summary>
        /// Возвращает список из подневных значений счета агентства.
        /// </summary>
        /// <returns>Возвращает кортеж вещественных значений.</returns>
        public List<Tuple<double, double>> GetAgencySummary()
        {
            return agencySummary;
        }

        /// <summary>
        /// Возвращает количество свободных биллбордов.
        /// </summary>
        /// <returns>Возвращает целое значение.</returns>
        public int GetFreeBillboardsCount()
        {
            return agencyFreeBillboards;
        }

        #endregion
    }
}