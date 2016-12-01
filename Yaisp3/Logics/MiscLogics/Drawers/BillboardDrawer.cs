using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3
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
        
        public override void Draw(Graphics Graphics)
        {
            Tuple<int, int> Position = billboard.GetPosition();

            int ScrX = GetScreenX(5 * Position.Item2);
            int LastX = GetScreenX(5 * Position.Item2 + 5);

            int ScrY = GetScreenY(-cityHeight * 5 + 5 * Position.Item1);
            int LastY = GetScreenY(-cityHeight * 5 + 5 * Position.Item1 + 5);
            
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
        }

        /// <summary>
        /// Возвращает валидность биллборда.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool IsValid()
        {
            return billboard.GetState() != Billboard.State.Invalid;
        }

        #endregion
    }
}
