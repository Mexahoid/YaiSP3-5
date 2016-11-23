using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Абстрактный класс-предок стратегии
    /// </summary>
    public abstract class Strategy
    {
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

        protected StrategyType strategy;

        /// <summary>
        /// Возвращает тип стратегии
        /// </summary>
        /// <returns></returns>
        public StrategyType ReturnStrategyType()
        {
            return strategy;
        }
        /// <summary>
        /// Абстрактный метод работы стратегии
        /// </summary>
        public abstract void Action();

        /// <summary>
        /// Пытается установить столько же биллбордов, сколько заказов сейчас в очереди
        /// </summary>
        protected void BuildOrderedBillboards()
        {
            MainUnitProcessor.AgencyPassDay();
            int Count = MainUnitProcessor.AgencyCanAffordBillboards(
                    MainUnitProcessor.QueueCount());
                for (int i = 0; i < Count; i++)
                    MainUnitProcessor.AgencyPlaceRandBillboard();
        }
    }

    /// <summary>
    /// Класс умеренной стратегии
    /// </summary>
    class StrategyNormal : Strategy
    {
        public StrategyNormal()
        {
            strategy = StrategyType.Normal;
        }
        public override void Action()
        {
            BuildOrderedBillboards();
            List<double[]> Summary = MainUnitProcessor.AgencyGetSummary();
            if (Summary.Count > 15)
            {
                double coeff = Summary[Summary.Count - 1][0] / Summary[Summary.Count - 16][0];
                if (coeff > 1.5)
                    if (MainUnitProcessor.AgencyCanAffordBillboards(1) == 1)
                        MainUnitProcessor.AgencyPlaceRandBillboard();
            } 

        }
    }

    /// <summary>
    /// Класс консервативной стратегии
    /// </summary>
    class StrategyConservative : Strategy
    {
        public StrategyConservative()
        {
            strategy = StrategyType.Conservative;
        }
        public override void Action()
        {
            BuildOrderedBillboards();
            if (MainUnitProcessor.MainGetRandomValue(0, 100) == 97)
                if (MainUnitProcessor.AgencyCanAffordBillboards(1) == 1)
                    MainUnitProcessor.AgencyPlaceRandBillboard();
        }
    }

    /// <summary>
    /// Класс аггрессивной стратегии
    /// </summary>
    class StrategyAggressive : Strategy
    {
        private int pastOrderCount = 0;
        public StrategyAggressive()
        {
            strategy = StrategyType.Aggressive;
            pastOrderCount = MainUnitProcessor.QueueCount();
        }
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
    }
}
