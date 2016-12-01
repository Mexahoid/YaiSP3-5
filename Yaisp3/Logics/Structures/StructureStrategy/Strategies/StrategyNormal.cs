using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс умеренной стратегии.
    /// </summary>
    class StrategyNormal : TemplateStrategy
    {
        #region Методы

        /// <summary>
        /// Конструктор класса стратегии.
        /// </summary>
        public StrategyNormal(Agency agencyLink)
        {
            agency = agencyLink;
            strategy = StrategyType.Normal;
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public override bool Action()
        {
            if (!BuildOrderedBillboards())
                return false;
            List<Tuple<double, double>> Summary = agency.GetAgencySummary();
            if (Summary.Count > 15)
            {
                double coeff = Summary[Summary.Count - 1].Item1 / Summary[Summary.Count - 16].Item1;
                if (coeff > 1.5)
                    if (agency.HowMuchCanWeAfford(1) == 1)
                        agency.PlaceBillboardRnd();
            }
            return true;
        }

        #endregion
    }
}
