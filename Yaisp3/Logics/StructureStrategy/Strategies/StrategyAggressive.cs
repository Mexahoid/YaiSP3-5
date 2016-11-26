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
            pastOrderCount = agency.QueueCount();
        }

        /// <summary>
        /// Действие стратегии.
        /// </summary>
        public override void Action()
        {
            BuildOrderedBillboards();
            if (agency.GetFreeBillboardsCount() == 0)
            {
                int Count = agency.HowMuchCanWeAfford(pastOrderCount);
                for (int i = 0; i < Count; i++)
                    agency.PlaceBillboardRnd();
            }
            int Temp = agency.QueueCount();
            if (pastOrderCount < Temp)
                pastOrderCount = Temp;
        }

        #endregion
    }
}
