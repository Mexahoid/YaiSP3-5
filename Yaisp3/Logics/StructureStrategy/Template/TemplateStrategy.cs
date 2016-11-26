using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Абстрактный класс-предок стратегии.
    /// </summary>
    public abstract class TemplateStrategy
    {
        #region Поля

        /// <summary>
        /// Тип стратегии
        /// </summary>
        public enum StrategyType
        {
            /// <summary>
            /// Умеренная
            /// </summary>
            Normal,
            /// <summary>
            /// Консервативная
            /// </summary>
            Conservative,
            /// <summary>
            /// Аггрессивная
            /// </summary>
            Aggressive
        }

        /// <summary>
        /// Поле типа стратегии
        /// </summary>
        protected StrategyType strategy;

        protected Agency agency;

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает тип стратегии
        /// </summary>
        /// <returns></returns>
        public StrategyType ReturnStrategyType()
        {
            return strategy;
        }

        /// <summary>
        /// Абстрактный метод работы стратегии.
        /// </summary>
        public abstract void Action();

        /// <summary>
        /// Пытается установить столько же биллбордов, сколько заказов сейчас в очереди.
        /// </summary>
        protected void BuildOrderedBillboards()
        {
            agency.PassDay();
            int Count = agency.HowMuchCanWeAfford(
                    agency.QueueCount());
            for (int i = 0; i < Count; i++)
                agency.PlaceBillboardRnd();
        }

        #endregion
    }
}
