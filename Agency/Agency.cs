﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencySimulator.Interfaces;
using AgencySimulator.StaticLogics;
using AgencySimulator.Types;

namespace AgencySimulator.Agency
{
    /// <summary>
    /// Класс агентства.
    /// </summary>
    public sealed class Agency : IAgency
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
        private List<IBillboard> agencyBillboards;

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

        /// <summary>
        /// Ссылка на объект города.
        /// </summary>
        private ICity cityLink;

        /// <summary>
        /// Ссылка на объект очереди.
        /// </summary>
        private IQueue queueLink;

        /// <summary>
        /// Ссылка на объект главного рисовальщика.
        /// </summary>
        private IMainDrawer drawersLink;

        /// <summary>
        /// ИД агентства.
        /// </summary>
        private int agencyId;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор агентства.
        /// </summary>
        /// <param name="Name">Название агентства.</param>
        /// <param name="Money">Начальный депозит.</param>
        /// <param name="Billboards">Кол-во биллбордов.</param>
        public Agency(string Name, int Money, int Billboards, int AgencyID)
        {
            agencyName = Name;
            agencyId = AgencyID;
            agencyDeposit = Money;
            agencyBillboards = new List<IBillboard>();
            agencySummary = new List<Tuple<double, double>>();
            agencyStaffCount = 1 + Billboards * 3;  //Глава + обслуга
            agencyFreeBillboards = Billboards;
        }

        /// <summary>
        /// Дает ссылки агентству на город и очередь.
        /// </summary>
        /// <param name="City">Ссылка на экземпляр города.</param>
        /// <param name="Queue">Ссылка на экземпляр очереди.</param>
        public void SetLinks(ICity City, IQueue Queue, IMainDrawer Drawers)
        {
            cityLink = City;
            queueLink = Queue;
            drawersLink = Drawers;

            for (int i = 0; i < agencyFreeBillboards; i++)
                PlaceBillboardRnd();
            agencyFreeBillboards = 0;
        }

        /// <summary>
        /// Возвращает кортеж, состоящий из депозита и кол-ва щитов.
        /// </summary>
        /// <returns>Возвращает кортеж из двух целочисленных значений.</returns>
        public Tuple<int, int> GetData()
        {
            return Tuple.Create(agencyDeposit, agencyBillboards.Count + agencyFreeBillboards);
        }

        /// <summary>
        /// Меняет название агентства.
        /// </summary>
        /// <param name="Name">Новое имя агентства.</param>
        public void ChangeName(string Name)
        {
            agencyName = Name;
        }

        /// <summary>
        /// Возвращает количество клиентов в очереди.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int QueueCount()
        {
            if (queueLink == null)
                return 0;
            return queueLink.GetQueueCount();
        }

        /// <summary>
        /// Устанавливает биллборд на случайном месте.
        /// </summary>
        public void PlaceBillboardRnd()
        {
            int Cost = 10000 + MiscellaneousLogics.MainGetRandomValue(-1000, 1000);

            Tuple<IBillboardDrawer, IBillboard> T = cityLink.PlaceBillboard(Cost, agencyId);
            drawersLink.AddDrawer(T.Item1);
            agencyBillboards.Add(T.Item2);
            agencyDeposit -= Cost;
        }

        /// <summary>
        /// Провести день работы.
        /// </summary>
        public bool PassDay()
        {
            if (agencyDeposit <= 0)
                return false;
            foreach (IBillboard Bb in agencyBillboards)
                if (!Bb.BillboardBuilded() && Bb.BillboardBuildToEnd())
                    agencyFreeBillboards += 1;
            int Temp = agencyDeposit;
            while (agencyFreeBillboards > 0 && !queueLink.QueueIsNull())
            {
                FillBillboard(queueLink.QueueTakeClient());
                agencyFreeBillboards--;
            }

            agencyDeposit -= agencyStaffCount * 10;                        //Заплатить стаффу
            for (int i = 0; i < agencyBillboards.Count; i++)
            {
                if (agencyBillboards[i].BillboardIsFilled())
                    if (agencyBillboards[i].PassDay())
                        agencyFreeBillboards++;
                agencyDeposit -= agencyBillboards[i].BillboardPayMoney();  //Заплатить за содержание
                agencyDeposit += agencyBillboards[i].ClientPay();          //Собрать деньгу с заказчика
            }
            agencySummary.Add(Tuple.Create(agencySummary.Count * 0.2, agencyDeposit / 10000.0));
            return true;
        }

        /// <summary>
        /// Заполняет первый свободный биллборд заказом клиента.
        /// </summary>
        /// <param name="ClientDesire">Кортеж желания клиента.</param>
        public void FillBillboard(IClient Client)
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
            for (i = 0; i < OrderCount && temp > 11000; i++)
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

        public int GetBuildingBillboardsCount()
        {
            int C = agencyBillboards.Count;
            int Count = 0;
            for (int i = 0; i < C; i++)
                if (!agencyBillboards[i].BillboardBuilded())
                    Count++;
            return Count;
        }

        /// <summary>
        /// Удаляет сами биллборды и рисовальщики биллбордов.
        /// </summary>
        public void DeleteBillboards()
        {
            int C = agencyBillboards.Count;
            for (int i = 0; i < C; i++)
                DeleteOneBillboard();
        }

        /// <summary>
        /// Удаляет первый невалидный биллборд.
        /// </summary>
        public void DeleteOneBillboard()
         {
             if (cityLink.DeleteOneBillboard())
             {
                 agencyFreeBillboards--;
                 int C = agencyBillboards.Count;
                 for (int i = 0; i < C; i++)
                     if (agencyBillboards[i].GetState() == BillboardState.Invalid)
                     {
                         agencyBillboards.RemoveAt(i);
                         break;
                     }
                 agencyStaffCount -= 3;
                 drawersLink.DeleteFirstBillboardDrawer();
             }
         }

        public override string ToString()
        {
            return agencyName;
        }

        #endregion
    }
}