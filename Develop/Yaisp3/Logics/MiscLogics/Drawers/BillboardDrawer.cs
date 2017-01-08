using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AgencySimulator
{
    /// <summary>
    /// Рисовальщик биллборда.
    /// </summary>
    public class BillboardDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Оперируемый рисовальщиком биллборд.
        /// </summary>
        private Billboard billboard;

        /// <summary>
        /// Высота города.
        /// </summary>
        private int cityHeight;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор рисовальщика биллборда.
        /// </summary>
        /// <param name="Billboard">Оперируемый биллборд.</param>
        /// <param name="CityHeight">Высота города.</param>
        public BillboardDrawer(Billboard Billboard, int CityHeight)
        {
            billboard = Billboard;
            cityHeight = CityHeight;
        }
        
        /// <summary>
        /// Отрисовывает биллборд на канве.
        /// </summary>
        /// <param name="Graphics">Канва, на которой производится рисование.</param>
        public override void Draw(Graphics Graphics)
        {
            (int y, int x) Position = billboard.GetPosition();

            int ScrX = GetScreenX(5 * Position.x);
            int LastX = GetScreenX(5 * Position.x + 5);

            int ScrY = GetScreenY(-cityHeight * 5 + 5 * Position.y);
            int LastY = GetScreenY(-cityHeight * 5 + 5 * Position.y + 5);
            
            switch (billboard.GetState())
            {
                case Billboard.State.Building:
                    Graphics.FillRectangle(Brushes.Gold, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
                    break;
                case Billboard.State.Free:
                    Graphics.FillRectangle(Brushes.CadetBlue, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
                    break;
                case Billboard.State.Personal:
                    Graphics.FillRectangle(Brushes.ForestGreen, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
                    break;
                case Billboard.State.Company:
                    Graphics.FillRectangle(Brushes.DarkOrange, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
                    break;
                case Billboard.State.Government:
                    Graphics.FillRectangle(Brushes.Crimson, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
                    break;
            }
            
            Font MyFont = new Font("Courier New", (float)(I2 / (x2p - x1p)) + 3, FontStyle.Bold);
            Graphics.DrawString(billboard.GetAgencyId().ToString(), MyFont, Brushes.Black, ScrX, ScrY);
        }

        /// <summary>
        /// Возвращает валидность биллборда.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool IsValid() => billboard.GetState() != Billboard.State.Invalid;

        #endregion
    }
}
