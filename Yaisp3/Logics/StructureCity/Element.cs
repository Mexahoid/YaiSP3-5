﻿using System;

namespace Yaisp3
{
    /// <summary>
    /// Класс базового элемента города
    /// </summary>
    public class Element
    {
        /// <summary>
        /// Ширина элемента
        /// </summary>
        protected int elementWidth;
        /// <summary>
        /// Высота элемента
        /// </summary>
        protected int elementHeight;
        /// <summary>
        /// True, если элемент - дом, False - если биллборд
        /// </summary>
        protected bool elementType;

        /// <summary>
        /// Возвращает состояние элемента
        /// </summary>
        /// <returns>True, если элемент - дом, False - Если биллборд</returns>
        public bool ReturnType()
        {
            return elementType;
        }
    }

    /// <summary>
    /// Класс элемента дома
    /// </summary>
    public class House : Element
    {
        /// <summary>
        /// Группа, к которой принадлежит дом
        /// </summary>
        private int houseElementGroup;

        /// <summary>
        /// Возвращает кортеж с размером дома
        /// </summary>
        /// <returns></returns>
        public Tuple<int, int> GetHouseSize()
        {
            return Tuple.Create(elementWidth, elementHeight);
        }

        /// <summary>
        /// Создает элемент города заданной группы элементов
        /// </summary>
        /// <param name="Width">Ширина дома</param>
        /// <param name="Group">Группа элементов</param>
        /// <param name="Height">Высота дома</param>
        public House(int Group, int Width, int Height)
        {
            houseElementGroup = Group;
            elementWidth = Width;
            elementHeight = Height;
            elementType = true;
        }
    }

    /// <summary>
    /// Класс биллборда
    /// </summary>
    public class Billboard : Element
    {
        #region Переменные
        /// <summary>
        /// Состояние биллборда
        /// </summary>
        enum State : byte
        {
            /// <summary>
            /// Биллборд строится
            /// </summary>
            Building,
            /// <summary>
            /// Биллборд построен, но не заполнен
            /// </summary>
            Free,
            /// <summary>
            /// На биллборде размещена реклама частного лица
            /// </summary>
            Personal,
            /// <summary>
            /// На биллборде размещена реклама компании
            /// </summary>
            Company,
            /// <summary>
            /// На биллборде размещена социальная реклама
            /// </summary>
            Government
        }

        /// <summary>
        /// Сумма, которую стоит обслуживание этого биллборда
        /// </summary>
        private int billboardCostPerDay;

        /// <summary>
        /// Сумма, которую приносит этот биллборд в день
        /// </summary>
        private int billboardProfitPerDay;

        /// <summary>
        /// Текст рекламы, записанной на биллборде
        /// </summary>
        private string billboardText;

        /// <summary>
        /// Состояние биллборда
        /// </summary>
        private State billboardType;
        #endregion

        /// <summary>
        /// Создает новый биллборд.
        /// </summary>
        /// <param name="Position">Позиция установки</param>
        /// <param name="AllCost">Ощая цена постройки биллборда</param>
        public Billboard(int AllCost)
        {
            billboardProfitPerDay = 0;
            elementHeight = elementWidth = 1;
            billboardCostPerDay = AllCost / 100;
            billboardType = State.Building;
            elementType = false;
        }

        /// <summary>
        /// Активирует биллборд как готовый к заполнению.
        /// </summary>
        public void BillboardBuildToEnd()
        {
            billboardType = State.Free;
        }

        /// <summary>
        /// Возвращает значение True, Если биллборд ещё строится
        /// </summary>
        /// <returns></returns>
        public bool BillboardIsBuilding()
        {
            return billboardType == State.Building;
        }

        /// <summary>
        /// Возвращает значение True, если биллборд свободен
        /// </summary>
        /// <returns></returns>
        public bool BillboardIsFilled()
        {
            return billboardType == State.Free && billboardType != State.Building;  //Это просто защита
        }

        /// <summary>
        /// Заполняет биллборд заказом клиента
        /// </summary>
        /// <param name="ClientDesire">Кортеж из текста рекламы, цены за аренду и уровня заказчика</param>
        public void BillboardFill(Tuple<string, int, byte> ClientDesire)
        {
            billboardText = ClientDesire.Item1;
            billboardProfitPerDay = ClientDesire.Item2;
            billboardType = (State)ClientDesire.Item3;   //Значения Rank и State для заказов совпадают
        }

        /// <summary>
        /// Возвращает соответствующий цвет для отрисовки биллборда на карте
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Color BillboardGetColor()
        {
            switch (billboardType)
            {
                case State.Building:
                    return System.Drawing.Color.LightBlue;
                case State.Free:
                    return System.Drawing.Color.Aquamarine;
                case State.Personal:
                    return System.Drawing.Color.Green;
                case State.Company:
                    return System.Drawing.Color.Orange;
                default: // State.Government:
                    return System.Drawing.Color.Crimson;
            }
        }

        /// <summary>
        /// Возвращает дневной доход с биллборда
        /// </summary>
        /// <returns>Возвращает положительное или отрицательное целое число</returns>
        public int BillboardGetMoney()
        {
            return billboardProfitPerDay - billboardCostPerDay;
        }
    }
}
