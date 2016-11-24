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

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор класса стратегии.
        /// </summary>
        public StrategyAggressive()
        {
            strategy = StrategyType.Aggressive;
            pastOrderCount = MainUnitProcessor.QueueCount();
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public override void Action()
        {
            BuildOrderedBillboards();
            if (MainUnitProcessor.AgencyFreeCount() == 0)
            {
                int Count = MainUnitProcessor.AgencyCanAffordBillboards(pastOrderCount);
                for (int i = 0; i < Count; i++)
                    MainUnitProcessor.AgencyPlaceRandBillboard();
            }
            int Temp = MainUnitProcessor.QueueCount();
            if (pastOrderCount < Temp)
                pastOrderCount = Temp;
        }

        #endregion
    }
}
