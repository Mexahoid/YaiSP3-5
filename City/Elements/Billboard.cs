using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Interfaces;
using AgencySimulator.StaticLogics;
using AgencySimulator.Types;

namespace AgencySimulator.City
{
    /// <summary>
    /// Класс биллборда.
    /// </summary>
    public class Billboard : IBillboard
    {
        #region Поля

        /// <summary>
        /// Координата строки матрицы.
        /// </summary>
        protected int y0;

        /// <summary>
        /// Координата столбца матрицы.
        /// </summary>
        protected int x0;

        /// <summary>
        /// Сумма, которую стоит обслуживание этого биллборда за день.
        /// </summary>
        private int costPerDay;

        /// <summary>
        /// Ссылка на хозяина биллборда.
        /// </summary>
        private IClient owner;

        /// <summary>
        /// Текст рекламы, записанной на биллборде.
        /// </summary>
        private string text;

        /// <summary>
        /// Состояние биллборда.
        /// </summary>
        private BillboardState state;

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
            state = BillboardState.Building;
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
                state = BillboardState.Free;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Отправляет биллборд на снос.
        /// </summary>
        public void Invalidate()
        {
            state = BillboardState.Invalid;
        }

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
                state = BillboardState.Free;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Возвращает информацию о том, строится ли ещё биллборд.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool BillboardBuilded()
        {
            return state != BillboardState.Building;
        }

        /// <summary>
        /// Возвращает информацию о том, есть ли реклама на биллборде.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool BillboardIsFilled()
        {
            return owner != null && state != BillboardState.Building;
        }

        /// <summary>
        /// Заполняет биллборд заказом клиента.
        /// </summary>
        /// <param name="ClientDesire">Кортеж из текста рекламы, цены за аренду и уровня заказчика.</param>
        public void BillboardFill(IClient Client)
        {
            owner = Client;
            text = Client.GetTextData();
            state = (BillboardState)(Client.GetType());
            daysToExpireDate = MiscellaneousLogics.MainGetRandomValue(0, 100);
        }

        /// <summary>
        /// Возвращает дневной доход с биллборда.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int BillboardPayMoney()
        {
            return costPerDay;
        }

        /// <summary>
        /// Возвращает состояние биллборда.
        /// </summary>
        /// <returns>Возвращает состояние биллборда.</returns>
        public BillboardState GetState()
        {
            return state;
        }

        /// <summary>
        /// Собирает деньги с хозяина биллборда.
        /// </summary>
        /// <returns>Возвращает целое число.</returns>
        public int ClientPay()
        {
            return owner == null ? 0 : owner.Pay();
        }

        /// <summary>
        /// Возвращает ИД агентства.
        /// </summary>
        /// <returns>Возвращает целочисленное значение.</returns>
        public int GetAgencyId()
        {
            return agencyId;
        }


        /// <summary>
        /// Устанавливает позицию элемента (левый верхний угол).
        /// </summary>
        /// <param name="Row">Строка матрицы.</param>
        /// <param name="Col">Столбец матрицы.</param>
        public void SetPosition(int Row, int Col)
        {
            y0 = Row;
            x0 = Col;
        }

        /// <summary>
        /// Возвращает кортеж позиции верхнего левого угла элемента.
        /// </summary>
        /// <returns>Возвращает кортеж целочисленных значений.</returns>
        public Tuple<int, int> GetPosition()
        {
            return Tuple.Create(y0, x0);
        }

        /// <summary>
        /// Пересекается ли элемент с другим.
        /// </summary>
        /// <param name="y2">Столбец матрицы сравниваемого элемента.</param>
        /// <param name="x2">Строка матрицы сравниваемого элемента.</param>
        /// <param name="Width">Ширина сравниваемого элемента.</param>
        /// <param name="Height">Высота сравниваемого элемента.</param>
        /// <returns>Возвращает логическое значение.</returns>
        public bool ContainsPosition(int y2, int x2, int Width, int Height)
        {
            int x1 = x0 + 1;
            int y1 = y0 + 1;

            int x3 = x2 + Width;
            int y3 = y2 + Height;

            if (Width == 1 && Height == 1)
                return y2 == y0 && x2 == x0;   //Находятся на одной клетке
            else
                return y0 < y3 && y0 > y2 && //Находится внутри
                    x0 < x3 && x0 > x2;
        }

        #endregion
    }
}