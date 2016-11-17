using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    class CityRedactorDrawingClass : MapDrawingClass
    {
        /// <summary>
        /// Создает новый экземпляр отрисовщика города для редактора
        /// </summary>
        /// <param name="Control">Контрол, на котором отрисовывается город</param>
        /// <param name="CWidth">Ширина города (в у.е.)</param>
        /// <param name="CHeight">Высота города (в у.е.)</param>
        public CityRedactorDrawingClass(Control Control, int CWidth, int CHeight) : base(Control, CWidth, CHeight)
        {

        }
        /// <summary>
        /// Рисует устанавливаемый объект
        /// </summary>
        /// <param name="X">Х верхнего левого угла объекта</param>
        /// <param name="Y">Y верхнего левого угла объекта</param>
        /// <param name="Width">Ширина объекта</param>
        /// <param name="Height">Высота объекта</param>
        public void DrawPlaceableObject(int X, int Y, int Width, int Height)
        {
            double PapX = GetGraphX(X) - 2.5;
            double PapY = GetGraphY(Y) - 2.5;
            int a = GetScreenX(PapX),
              b = GetScreenY(PapY),
              c = Math.Abs(a - GetScreenX(PapX - 5 * Width)),
              d = Math.Abs(b - GetScreenY(PapY + 5 * Height));
            _CanvasLogics.FillRectangle(Brushes.Green, a, b, c, d);
            _CanvasLogics.DrawRectangle(Pens.Black, a, b, c, d);
        }
        /// <summary>
        /// Ищет строку и столбец устанавливаемого элемента в матрице
        /// </summary>
        /// <param name="X">Х верхнего левого угла объекта</param>
        /// <param name="Y">Y верхнего левого угла объекта</param>
        /// <param name="Row">Найденная строка в матрице</param>
        /// <param name="Col">Найденный столбец в матрице</param>
        /// <returns>Возвращает True, если объект находится в рамках матрицы</returns>
        public bool FindPlaceInMatrix(int X, int Y, out int Row, out int Col)
        {
            Row = Col = 0;
            int PapX = (int)GetGraphX(X);
            int PapY = (int)GetGraphY(Y);
            Col = PapX / 5;
            Row = CityHeight - Math.Abs(PapY / 5) - 1;
            return !(Col >= CityWidth || Row >= CityHeight || Row < 0 || Col < 0);
        }
    }
}