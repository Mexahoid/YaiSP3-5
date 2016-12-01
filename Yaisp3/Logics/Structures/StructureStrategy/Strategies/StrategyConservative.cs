using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс консервативной стратегии.
    /// </summary>
    class StrategyConservative : TemplateStrategy
    {
        #region Методы

        /// <summary>
        /// Конструктор класса стратегии.
        /// </summary>
        public StrategyConservative(Agency agencyLink)
        {
            agency = agencyLink;
            strategy = StrategyType.Conservative;
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public override bool Action()
        {
            if (!BuildOrderedBillboards())
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
            }
            return true;
        }

        #endregion
    }
}
