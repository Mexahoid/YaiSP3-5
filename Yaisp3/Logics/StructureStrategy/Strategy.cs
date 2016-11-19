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

        }
    }

    /// <summary>
    /// Класс аггрессивной стратегии
    /// </summary>
    class StrategyAggressive : Strategy
    {
        public StrategyAggressive()
        {
            strategy = StrategyType.Aggressive;
        }
        public override void Action()
        {

        }
    }
}
