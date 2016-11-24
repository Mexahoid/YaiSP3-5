using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Абстрактный класс-предок стратегии.
    /// </summary>
    public abstract class Strategy
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
            MainUnitProcessor.AgencyPassDay();
            int Count = MainUnitProcessor.AgencyCanAffordBillboards(
                    MainUnitProcessor.QueueCount());
            for (int i = 0; i < Count; i++)
                MainUnitProcessor.AgencyPlaceRandBillboard();
        }

        #endregion
    }

    /// <summary>
    /// Класс умеренной стратегии.
    /// </summary>
    class StrategyNormal : Strategy
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

    /// <summary>
    /// Класс консервативной стратегии.
    /// </summary>
    class StrategyConservative : Strategy
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

    /// <summary>
    /// Класс аггрессивной стратегии.
    /// </summary>
    class StrategyAggressive : Strategy
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
