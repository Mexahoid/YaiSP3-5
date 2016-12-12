using System;
using AgencySimulator.Types;
using AgencySimulator.Interfaces;

namespace AgencySimulator.Queue
{
    /// <summary>
    /// Базовый класс клиента.
    /// </summary>
    public abstract class TemplateClient : IClient
    {
        #region Поля

        /// <summary>
        /// Имя заказчика.
        /// </summary>
        protected string clientName;

        /// <summary>
        /// Желание заказчика (текст рекламы).
        /// </summary>
        protected string clientDesire;

        /// <summary>
        /// Уровень клиента.
        /// </summary>
        protected ClientLevel clientLevel;

        #endregion

        #region Методы

        /// <summary>
        /// Возвращает заказ клиента.
        /// </summary>
        /// <returns>Возвращает кортеж из текста рекламы, цены за аренду и уровня.</returns>
        public string GetOrder()
        {
            return clientDesire;
        }

        /// <summary>
        /// Возвращает информацию о клиенте в текстовом формате.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public abstract string GetTextData();

        /// <summary>
        /// Платит заявленную цену.
        /// </summary>
        /// <returns>Возвращает целочисленное значение</returns>
        public abstract int Pay();

        new public ClientLevel GetType()
        {
            return clientLevel;
        }
        #endregion
    }
}
