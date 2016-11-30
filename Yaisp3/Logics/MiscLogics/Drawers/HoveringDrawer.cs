using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yaisp3
{
    /// <summary>
    /// Класс отрисовщика устанавливаемого дома.
    /// </summary>
    class HoveringDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Кортеж X и Y верхнего левого угла дома.
        /// </summary>
        Tuple<double, double> Position;

        /// <summary>
        /// Кортеж ширины и высоты дома.
        /// </summary>
        Tuple<int, int> HouseSize;

        /// <summary>
        /// Кортеж из ширины и высоты города.
        /// </summary>
        Tuple<int, int> CitySize;

        #endregion

        #region Методы
        
        /// <summary>
        /// Создает новый рисовальщик добавляемого дома.
        /// </summary>
        /// <param name="CitySize">Кортеж размеров города.</param>
        /// <param name="Width">Ширина элемента.</param>
        /// <param name="Height">Высота элемента.</param>
        public HoveringDrawer(Tuple<int, int> CitySize, int Width, int Height)
        {
            this.CitySize = CitySize;
            HouseSize = Tuple.Create(Width, Height);
            Position = Tuple.Create(1000.0, 1000.0);
        }

        /// <summary>
        /// Передвигает элемента на данные координаты.
        /// </summary>
        /// <param name="X">Х мыши.</param>
        /// <param name="Y">Y мыши.</param>
        public void MoveTo(int X, int Y)
        {
            Position = Tuple.Create(x1p + (X - I1) * (x2p - x1p) / (I2 - I1), 
                y1p + (Y - J1) * (y2p - y1p) / (J2 - J1));
        }

        /// <summary>
        /// Отрисовывает элемент на канву.
        /// </summary>
        /// <param name="Graphics">Канва отрисовывания.</param>
        public override void Draw(Graphics Graphics)
        {
            int ScrX = GetScreenX(Position.Item1);
            int LastX = GetScreenX(Position.Item1 + 5 * HouseSize.Item1);

            int ScrY = GetScreenY(Position.Item2);
            int LastY = GetScreenY(Position.Item2 + 5 * HouseSize.Item2);

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
            int PapX = (int)(Position.Item1);
            int PapY = (int)(Position.Item2);
            Col = PapX < 0 ? -1 : PapX / 5;
            Row = PapY > 0 ? -1 : CitySize.Item2 - Math.Abs(PapY / 5) - 1;
            return !(Col >= CitySize.Item1 || Row >= CitySize.Item2 || Row < 0 || Col < 0);
        }
        
        #endregion
    }
}
