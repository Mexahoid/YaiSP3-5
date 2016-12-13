using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Interfaces;
using AgencySimulator.StaticLogics;

namespace AgencySimulator.Plugins
{
    class Aggressive : IStrategy
    {
        #region Поля

        /// <summary>
        /// Максимальное количество заказчиков за день.
        /// </summary>
        private int pastOrderCount = 0;

        /// <summary>
        /// Счетчик остаточных плохих дней до сноса биллборда.
        /// </summary>
        private int badDaysCounter = -1;

        private int daysTillResetting;

        IAgency agency;

        #endregion

        #region Методы

        /// <summary>
        /// Пытается установить столько же биллбордов, сколько заказов сейчас в очереди.
        /// </summary>
        public bool BuildOrderedBillboards()
        {
            if (agency.PassDay())
            {
                if (agency.GetBuildingBillboardsCount() == 0)
                {
                    int Count = agency.HowMuchCanWeAfford(
                         agency.QueueCount());
                    for (int i = 0; i < Count; i++)
                        agency.PlaceBillboardRnd();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public bool Action()
        {
            if (!BuildOrderedBillboards())
                return false;
            if (agency.GetFreeBillboardsCount() == 0)
            {
                int Count = agency.HowMuchCanWeAfford(pastOrderCount);
                for (int i = 0; i < Count; i++)
                    agency.PlaceBillboardRnd();
            }
            int Temp = agency.QueueCount();
            if (pastOrderCount < Temp)
            {
                pastOrderCount = Temp;
                daysTillResetting = MiscellaneousLogics.MainGetRandomValue(0, 6);
            }
            if (--daysTillResetting < 1)
                pastOrderCount = 0;
            List<Tuple<double, double>> Summary = agency.GetAgencySummary();
            int C = Summary.Count;
            if (C > 10)
            {
                if (badDaysCounter > 0)
                {
                    if (Summary[C - 1].Item2 / Summary[C - 11].Item2 < 0.8)
                        badDaysCounter--;
                    else
                        badDaysCounter = -1;
                }
                else
                if (Summary[C - 1].Item2 / Summary[C - 11].Item2 < 0.8)
                    badDaysCounter = MiscellaneousLogics.MainGetRandomValue(30, 100);
                if (badDaysCounter == 0)
                {
                    int A = MiscellaneousLogics.MainGetRandomValue(1,
                        agency.GetFreeBillboardsCount());
                    for (int i = 0; i < A; i++)
                        agency.DeleteOneBillboard();
                    badDaysCounter = -1;
                }
            }
            return true;
        }

        public void CreateLink(IAgency Agency)
        {
            agency = Agency;
        }

        #endregion
    }
}
