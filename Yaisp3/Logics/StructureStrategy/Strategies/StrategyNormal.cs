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
        public StrategyNormal()
        {
            strategy = StrategyType.Normal;
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public override void Action()
        {
            BuildOrderedBillboards();
            List<Tuple<double, double>> Summary = MainUnitProcessor.AgencyGetSummary();
            if (Summary.Count > 15)
            {
                double coeff = Summary[Summary.Count - 1].Item1 / Summary[Summary.Count - 16].Item1;
                if (coeff > 1.5)
                    if (MainUnitProcessor.AgencyCanAffordBillboards(1) == 1)
                        MainUnitProcessor.AgencyPlaceRandBillboard();
            }

        }

        #endregion
    }
}
