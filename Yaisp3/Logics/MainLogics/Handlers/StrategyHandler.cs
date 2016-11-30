using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    public class StrategyHandler
    {
        /// <summary>
        /// Экземпляр стратегии.
        /// </summary>
        private TemplateStrategy Strategy;

        /// <summary>
        /// Изменяет стратегию.
        /// </summary>
        /// <param name="Type">Тип новой стратегии.</param>
        public StrategyHandler(TemplateStrategy.StrategyType Type, Agency Agency)
        {
            switch (Type)
            {
                case TemplateStrategy.StrategyType.Normal:
                    Strategy = new StrategyNormal(Agency);
                    break;
                case TemplateStrategy.StrategyType.Conservative:
                    Strategy = new StrategyConservative(Agency);
                    break;
                case TemplateStrategy.StrategyType.Aggressive:
                    Strategy = new StrategyAggressive(Agency);
                    break;
            }
        }

        /// <summary>
        /// Возвращает тип стратегии агентства.
        /// </summary>
        /// <returns>Возвращает тип стратегии.</returns>
        public TemplateStrategy.StrategyType StrategyGetType()
        {
            return Strategy.ReturnStrategyType();
        }

        /// <summary>
        /// Совершает действие стратегии.
        /// </summary>
        public void StrategyAction()
        {
            Strategy.Action();
        }
    }
}
