using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс аггрессивной стратегии.
    /// </summary>
    class StrategyAggressive : TemplateStrategy
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


        #endregion

        #region Методы

        /// <summary>
        /// Конструктор класса стратегии.
        /// </summary>
        public StrategyAggressive(Agency agencyLink)
        {
            agency = agencyLink;
            strategy = StrategyType.Aggressive;
            if (agency != null)
                pastOrderCount = agency.QueueCount();
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public override bool Action()
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

        #endregion
    }
}
