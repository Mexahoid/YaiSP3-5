using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AgencySimulator.Interfaces;

namespace AgencySimulator.City
{
    /// <summary>
    /// Класс элемента дома.
    /// </summary>
    public class House : IHouse
    {
        #region Поля

        /// <summary>
        /// Группа, к которой принадлежит дом.
        /// </summary>
        private int houseElementGroup;

        /// <summary>
        /// Координата строки матрицы.
        /// </summary>
        protected int y0;

        /// <summary>
        /// Координата столбца матрицы.
        /// </summary>
        protected int x0;

        /// <summary>
        /// Ширина элемента.
        /// </summary>
        protected int elementWidth;

        /// <summary>
        /// Высота элемента.
        /// </summary>
        protected int elementHeight;

        #endregion

        #region Методы

        /// <summary>
        /// Создает элемент города заданной группы элементов.
        /// </summary>
        /// <param name="Width">Ширина дома.</param>
        /// <param name="Group">Группа элементов.</param>
        /// <param name="Height">Высота дома.</param>
        public House(int Group, int Width, int Height)
        {
            houseElementGroup = Group;
            elementWidth = Width;
            elementHeight = Height;
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
        /// Возвращает кортеж размеров элемента.
        /// </summary>
        /// <returns>Возвращает кортеж целочисленных значений.</returns>
        public Tuple<int, int> GetElementSize()
        {
            return Tuple.Create(elementWidth, elementHeight);
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
            int x1 = x0 + elementWidth;
            int y1 = y0 + elementHeight;

            int x3 = x2 + Width;
            int y3 = y2 + Height;

            if (Width == 1 && Height == 1)
                return y1 >= y2 && y0 <= y2 &&   //Находится внутри
                    x1 >= x2 && x0 <= x2;
            else
                return x0 < x3 && x1 > x2 && y0 < y3 && y1 > y2;  //Имеют внутрь входящие координаты
        }

        #endregion
    }
}