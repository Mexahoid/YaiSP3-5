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
        public StrategyConservative()
        {
            strategy = StrategyType.Conservative;
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public override void Action()
        {
            BuildOrderedBillboards();
            if (MainUnitProcessor.MainGetRandomValue(0, 100) == 97)
                if (MainUnitProcessor.AgencyCanAffordBillboards(1) == 1)
                    MainUnitProcessor.AgencyPlaceRandBillboard();
        }

        #endregion
    }
}
