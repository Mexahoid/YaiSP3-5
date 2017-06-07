using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Interfaces;

namespace AgencySimulator
{
    /// <summary>
    /// Класс-инкапсулятор для стратегий-плагинов.
    /// </summary>
    public class StrategyHandler
    {
        #region Поля

        /// <summary>
        /// Инкапсулированный темплейт рабочей стратегии.
        /// </summary>
        private IStrategy encasedStrategy;

        /// <summary>
        /// Инкапсулированное агентство.
        /// </summary>
        private Agency encasedAgency;

        #endregion

        #region Методы

        /// <summary>
        /// Заставляет стратегию действовать на агентство.
        /// </summary>
        public bool Action()
        {
            return encasedStrategy.Action(encasedAgency);
        }

        /// <summary>
        /// Конструктор инкапсулятора.
        /// </summary>
        /// <param name="AgencyLink">Ссылка на агентство.</param>
        /// <param name="StrategyTemplate">Ссылка на рабочую стратегию.</param>
        public StrategyHandler(Agency AgencyLink)
        {
            encasedAgency = AgencyLink;
        }

        public void SetStrategy(IStrategy StrategyTemplate)
        {
            encasedStrategy = StrategyTemplate;
        }

        public override string ToString()
        {
            return encasedStrategy.GetName();
        }

        #endregion
    }
}
