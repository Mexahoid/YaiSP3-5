using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Класс биллборда.
    /// </summary>
    public class Billboard : TemplateElement
    {
        #region Поля

        /// <summary>
        /// Состояние биллборда.
        /// </summary>
        public enum State
        {
            /// <summary>
            /// Биллборд строится.
            /// </summary>
            Building,
            /// <summary>
            /// Биллборд свободен.
            /// </summary>
            Free,
            /// <summary>
            /// Хозяин - частное лицо.
            /// </summary>
            Personal,
            /// <summary>
            /// Хозяин - компания.
            /// </summary>
            Company,
            /// <summary>
            /// Хозяин - гос. компания.
            /// </summary>
            Government,
            /// <summary>
            /// Невалидный экземпляр.
            /// </summary>
            Invalid
        }

        /// <summary>
        /// Сумма, которую стоит обслуживание этого биллборда за день.
        /// </summary>
        private int costPerDay;

        /// <summary>
        /// Ссылка на хозяина биллборда.
        /// </summary>
        private TemplateClient owner;

        /// <summary>
        /// Текст рекламы, записанной на биллборде.
        /// </summary>
        private string text;

        /// <summary>
        /// Состояние биллборда.
        /// </summary>
        private State state;

        /// <summary>
        /// Дней до окончания контракта.
        /// </summary>
        private int daysToExpireDate;

        /// <summary>
        /// ИД агентства-владельца.
        /// </summary>
        private int agencyId;

        /// <summary>
        /// Дней до окончания стройки.
        /// </summary>
        private int daysToBuild = 20;

        #endregion

        #region Методы

        /// <summary>
        /// Создает новый биллборд.
        /// </summary>
        /// <param name="Position">Позиция установки.</param>
        /// <param name="AllCost">Ощая цена постройки биллборда.</param>
        public Billboard(int AllCost, int AgencyID)
        {
            agencyId = AgencyID;
            state = State.Building;
            elementHeight = elementWidth = 1;
            costPerDay = AllCost / 100;
            owner = null;
        }

        /// <summary>
        /// Активирует биллборд как готовый к заполнению.
        /// </summary>
        public bool BillboardBuildToEnd()
        {
            if (--daysToBuild < 1)
            {
                state = State.Free;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Отправляет биллборд на снос.
        /// </summary>
        public void Invalidate() => state = State.Invalid;

        /// <summary>
        /// Проводит день работы биллборда.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool PassDay()
        {
            daysToExpireDate--;
            if (daysToExpireDate < 1)
            {
                owner = null;
                state = State.Free;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращает информацию о том, строится ли ещё биллборд.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool BillboardBuilded() => state != State.Building;

        /// <summary>
        /// Возвращает информацию о том, есть ли реклама на биллборде.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool BillboardIsFilled() =>
            owner != null && state != State.Building;

        /// <summary>
        /// Заполняет биллборд заказом клиента.
        /// </summary>
        /// <param name="ClientDesire">Кортеж из текста рекламы, цены за аренду и уровня заказчика.</param>
        public void BillboardFill(TemplateClient Client)
        {
            owner = Client;
            text = Client.GetTextData();
            state = Client.GetType() == typeof(ClientGovernment) ? State.Government :
                Client.GetType() == typeof(ClientCompany) ? State.Company : State.Personal;
            daysToExpireDate = MiscellaneousLogics.MainGetRandomValue(0, 100);
        }

        /// <summary>
        /// Возвращает дневной доход с биллборда.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int BillboardPayMoney() => costPerDay;

        /// <summary>
        /// Возвращает состояние биллборда.
        /// </summary>
        /// <returns>Возвращает состояние биллборда.</returns>
        public State GetState() => state;

        /// <summary>
        /// Собирает деньги с хозяина биллборда.
        /// </summary>
        /// <returns>Возвращает целое число.</returns>
        public int ClientPay() => owner?.Pay()??0;

        /// <summary>
        /// Возвращает ИД агентства.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int GetAgencyId() => agencyId;

        #endregion
    }
}