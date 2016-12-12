using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using AgencySimulator.Interfaces;

namespace AgencySimulator.Drawers
{
    /// <summary>
    /// Класс отрисовщика дома.
    /// </summary>
    public class HouseDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Дом, с которым общается отрисовщик.
        /// </summary>
        private IHouse house;

        /// <summary>
        /// Высота города.
        /// </summary>
        private int cityHeight;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор отрисовщика дома.
        /// </summary>
        /// <param name="House">Объект дома.</param>
        /// <param name="CityHeight">Высота города.</param>
        public HouseDrawer(IHouse House, int CityHeight)
        {
            house = House;
            cityHeight = CityHeight;
        }

        /// <summary>
        /// Отрисовывает дом на канве.
        /// </summary>
        /// <param name="Graphics">Канва, на которой происходит отрисовка.</param>
        public override void Draw(Graphics Graphics)
        {
            Tuple<int, int> Position = house.GetPosition();
            Tuple<int, int> Size = house.GetElementSize();
            
            int ScrX = GetScreenX(5 * Position.Item2);
            int LastX = GetScreenX(5 * Position.Item2 + 5 * Size.Item1);

            int ScrY = GetScreenY(-cityHeight * 5 + 5 * Position.Item1);
            int LastY = GetScreenY(-cityHeight * 5 + 5 * Position.Item1 + 5 * Size.Item2);

            Graphics.FillRectangle(Brushes.DarkGray, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
        }

        #endregion
    }
}
