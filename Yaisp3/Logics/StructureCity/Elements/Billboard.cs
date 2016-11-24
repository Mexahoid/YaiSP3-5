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

        /// <summary>
        /// Состояние биллборда.
        /// </summary>
        private bool billboardBuilded;

        #endregion

        #region Методы

        /// <summary>
        /// Создает новый биллборд.
        /// </summary>
        /// <param name="Position">Позиция установки.</param>
        /// <param name="AllCost">Ощая цена постройки биллборда.</param>
        public Billboard(int AllCost)
        {
            elementHeight = elementWidth = 1;
            billboardCostPerDay = AllCost / 100;
            elementColor = System.Drawing.Color.LightBlue;
            billboardOwner = null;
        }

        /// <summary>
        /// Активирует биллборд как готовый к заполнению.
        /// </summary>
        public void BillboardBuildToEnd()
        {
            elementColor = System.Drawing.Color.Aquamarine;
            billboardBuilded = true;
        }

        /// <summary>
        /// Возвращает информацию о том, строится ли ещё биллборд.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool BillboardBuilded()
        {
            return billboardBuilded;
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
            elementColor = Client.GetType() == typeof(ClientGovernment) ? System.Drawing.Color.Crimson :
                Client.GetType() == typeof(ClientCompany) ? System.Drawing.Color.Orange : System.Drawing.Color.Green;
        }

        /// <summary>
        /// Возвращает дневной доход с биллборда.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int BillboardPayMoney()
        {
            return billboardCostPerDay;
        }

        public int ClientPay()
        {
            return billboardOwner == null ? 0 : billboardOwner.Pay();
        }

        #endregion
    }
}