using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AgencySimulator
{
    /// <summary>
    /// Класс отрисовщика устанавливаемого дома.
    /// </summary>
    public class HoveringDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Кортеж X и Y верхнего левого угла дома.
        /// </summary>
        (double x, double y) Position;

        /// <summary>
        /// Кортеж ширины и высоты дома.
        /// </summary>
        (int width, int height) HouseSize;

        /// <summary>
        /// Кортеж из ширины и высоты города.
        /// </summary>
        (int width, int height) CitySize;

        #endregion

        #region Методы
        
        /// <summary>
        /// Создает новый рисовальщик добавляемого дома.
        /// </summary>
        /// <param name="CitySize">Кортеж размеров города.</param>
        /// <param name="Width">Ширина элемента.</param>
        /// <param name="Height">Высота элемента.</param>
        public HoveringDrawer((int, int) CitySize, int Width, int Height)
        {
            this.CitySize = CitySize;
            HouseSize = (Width, Height);
            Position = (1000.0, 1000.0);
        }

        /// <summary>
        /// Передвигает элемента на данные координаты.
        /// </summary>
        /// <param name="X">Х мыши.</param>
        /// <param name="Y">Y мыши.</param>
        public void MoveTo(int X, int Y) =>
            Position = (x1p + (X - I1) * (x2p - x1p) / (I2 - I1), 
                y1p + (Y - J1) * (y2p - y1p) / (J2 - J1));

        /// <summary>
        /// Отрисовывает элемент на канву.
        /// </summary>
        /// <param name="Graphics">Канва отрисовывания.</param>
        public override void Draw(Graphics Graphics)
        {
            int ScrX = GetScreenX(Position.x);
            int LastX = GetScreenX(Position.x + 5 * HouseSize.width);

            int ScrY = GetScreenY(Position.y);
            int LastY = GetScreenY(Position.y + 5 * HouseSize.height);

            Graphics.FillRectangle(Brushes.Crimson,
                ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
        }

        /// <summary>
        /// Пытается найти место в матрице.
        /// </summary>
        /// <param name="Row">Отдаваемая строка матрицы.</param>
        /// <param name="Col">Отдаваемый столбец матрицы.</param>
        /// <returns>Возвращает логическое значение.</returns>
        public bool FindPlaceInMatrix(out int Row, out int Col)
        {
            Row = Col = 0;
            int PapX = (int)(Position.x);
            int PapY = (int)(Position.y);
            Col = PapX < 0 ? -1 : PapX / 5;
            Row = PapY > 0 ? -1 : CitySize.height - Math.Abs(PapY / 5) - 1;
            return !(Col >= CitySize.width || Row >= CitySize.height || Row < 0 || Col < 0);
        }
        
        #endregion
    }
}
