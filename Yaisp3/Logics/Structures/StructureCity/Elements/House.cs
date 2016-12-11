using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Класс элемента дома.
    /// </summary>
    public class House : TemplateElement
    {
        #region Поля

        /// <summary>
        /// Группа, к которой принадлежит дом.
        /// </summary>
        private int houseElementGroup;

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
        #endregion
    }
}