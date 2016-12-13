using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencySimulator.Interfaces;
using AgencySimulator;


namespace AgencySimulator.Plugins
{
    public class Conservative : IStrategy
    {
        #region Поля

        /// <summary>
        /// Агентство, с которым работает стратегия.
        /// </summary>
        IAgency agency;

        #endregion

        #region Методы

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public bool Action()
        {
            /*if (!BuildOrderedBillboards())
                return false;
            if (MiscellaneousLogics.MainGetRandomValue(0, 100) == 97)
                if (agency.HowMuchCanWeAfford(1) == 1)
                    agency.PlaceBillboardRnd();
            List<Tuple<double, double>> Summary = agency.GetAgencySummary();
            int C = Summary.Count;
            if (C > 10)
            {
                if (Summary[C - 1].Item2 / Summary[C - 11].Item2 < 0.8)
                {
                    int A = agency.GetFreeBillboardsCount();
                    for (int i = 0; i < A; i++)
                        agency.DeleteOneBillboard();
                }
            }*/
            return true;
        }

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
        /// Дает стратегии ссылку на агентство.
        /// </summary>
        /// <param name="Agency"></param>
        public void CreateLink(IAgency Agency)
        {
            agency = Agency;
        }

        #endregion
    }
}
