using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Interfaces;
using AgencySimulator.StaticLogics;

namespace AgencySimulator.Plugins
{
    class Normal : IStrategy
    {
        #region Поля

        IAgency agency;

        int badDaysCounter = -1;

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
            List<Tuple<double, double>> Summary = agency.GetAgencySummary();
            int C = Summary.Count;
            if (C > 15)
            {
                double coeff = Summary[Summary.Count - 1].Item2 / Summary[Summary.Count - 16].Item2;
                if (coeff > 1.5)
                    if (agency.HowMuchCanWeAfford(1) == 1)
                        agency.PlaceBillboardRnd();
            }
            if (C > 10)
            {
                if (badDaysCounter > 0)
                {
                    if (Summary[C - 1].Item2 / Summary[C - 11].Item2 < 0.9)
                        badDaysCounter--;
                    else
                        badDaysCounter = -1;
                }
                else
                    if (Summary[C - 1].Item2 / Summary[C - 11].Item2 < 0.9)
                    badDaysCounter = MiscellaneousLogics.MainGetRandomValue(1, 15);
                if (badDaysCounter == 0 && agency.GetFreeBillboardsCount() > 0)
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
