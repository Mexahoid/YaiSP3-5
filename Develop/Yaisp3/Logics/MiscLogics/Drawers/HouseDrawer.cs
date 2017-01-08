using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AgencySimulator
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
        private House house;

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
        public HouseDrawer(House House, int CityHeight)
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
            (int y, int x) Position = house.GetPosition();
            (int width, int height) Size = house.GetElementSize();
            
            int ScrX = GetScreenX(5 * Position.x);
            int LastX = GetScreenX(5 * Position.x + 5 * Size.width);

            int ScrY = GetScreenY(-cityHeight * 5 + 5 * Position.y);
            int LastY = GetScreenY(-cityHeight * 5 + 5 * Position.y + 5 * Size.height);

            Graphics.FillRectangle(Brushes.DarkGray, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
        }

        #endregion
    }
}
