using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс биллборда.
    /// </summary>
    public class Billboard : TemplateElement
    {
        #region Поля

        public enum State
        {
            Building,
            Free,
            Personal,
            Company,
            Government
        }

        /// <summary>
        /// Сумма, которую стоит обслуживание этого биллборда за день.
        /// </summary>
        private int billboardCostPerDay;

        /// <summary>
        /// Ссылка на хозяина биллборда.
        /// </summary>
        private TemplateClient billboardOwner;

        /// <summary>
        /// Текст рекламы, записанной на биллборде.
        /// </summary>
        private string billboardText;

        private State billboardState;

        #endregion

        #region Методы

        /// <summary>
        /// Создает новый биллборд.
        /// </summary>
        /// <param name="Position">Позиция установки.</param>
        /// <param name="AllCost">Ощая цена постройки биллборда.</param>
        public Billboard(int AllCost)
        {
            billboardState = State.Building;
            elementHeight = elementWidth = 1;
            billboardCostPerDay = AllCost / 100;
            billboardOwner = null;
        }

        /// <summary>
        /// Активирует биллборд как готовый к заполнению.
        /// </summary>
        public void BillboardBuildToEnd()
        {
            billboardState = State.Free;
        }

        /// <summary>
        /// Возвращает информацию о том, строится ли ещё биллборд.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool BillboardBuilded()
        {
            return billboardState != State.Building;
        }

        /// <summary>
        /// Возвращает информацию о том, есть ли реклама на биллборде.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool BillboardIsFilled()
        {
            return billboardOwner != null;
        }

        /// <summary>
        /// Заполняет биллборд заказом клиента.
        /// </summary>
        /// <param name="ClientDesire">Кортеж из текста рекламы, цены за аренду и уровня заказчика.</param>
        public void BillboardFill(TemplateClient Client)
        {
            billboardOwner = Client;
            billboardText = Client.GetTextData();
            billboardState = Client.GetType() == typeof(ClientGovernment) ? State.Government :
                Client.GetType() == typeof(ClientCompany) ? State.Company : State.Personal;
        }

        /// <summary>
        /// Возвращает дневной доход с биллборда.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int BillboardPayMoney()
        {
            return billboardCostPerDay;
        }

        public State GetState()
        {
            return billboardState;
        }

        public int ClientPay()
        {
            return billboardOwner == null ? 0 : billboardOwner.Pay();
        }

        #endregion
    }
}