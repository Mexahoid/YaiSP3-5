using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Yaisp3
{
    /// <summary>
    /// Класс рисования карты города на главной форме.
    /// </summary>
    class MapDrawingClass : MainDrawingTemplate
    {
        #region Поля

        /// <summary>
        /// Ширина города.
        /// </summary>
        protected int CityWidth;

        /// <summary>
        /// Высота города.
        /// </summary>
        protected int CityHeight;

        #endregion

        #region Методы

        /// <summary>
        /// Создает новый экземпляр отрисовщика города для главной формы.
        /// </summary>
        /// <param name="Control">Контрол, на котором отрисовывается город.</param>
        /// <param name="CWidth">Ширина города.</param>
        /// <param name="CHeight">Высота города.</param>
        public MapDrawingClass(Control Control, int CWidth, int CHeight)
        {
            CanvasControl = Control.CreateGraphics();
            _CanvasImage = new Bitmap(Control.Width, Control.Height);
            I2 = Control.Width;
            J2 = Control.Height;
            _CanvasLogics = Graphics.FromImage(_CanvasImage);
            CityHeight = CHeight;
            CityWidth = CWidth;
        }

        /// <summary>
        /// Рисует сетку города.
        /// </summary>
        public void DrawGrid()
        {
            _CanvasLogics.DrawLine(Pens.Red, GetScreenX(0), GetScreenY(-500), GetScreenX(0), GetScreenY(500));
            _CanvasLogics.DrawLine(Pens.Blue, GetScreenX(-500), GetScreenY(0), GetScreenX(500), GetScreenY(0));
            for (int i = 0; i <= CityHeight; i++)
                _CanvasLogics.DrawLine(Pens.Black, GetScreenX(0), GetScreenY(i * -5),
                  GetScreenX(CityWidth * 5), GetScreenY(i * -5));
            for (int i = 0; i <= CityWidth; i++)
                _CanvasLogics.DrawLine(Pens.Black, GetScreenX(i * 5), GetScreenY(0),
                  GetScreenX(i * 5), GetScreenY(CityHeight * -5));
        }

        /// <summary>
        /// Рисует элемент города из соответствующих координат.
        /// </summary>
        /// <param name="MatrRow">Строка матрицы.</param>
        /// <param name="MatrCol">Столбец матрицы.</param>
        /// <param name="Color">Цвет заполняемой клетки.</param>
        public void DrawCityElement(int MatrRow, int MatrCol, int Width, int Height, Color Color)
        {
            int ScrX = GetScreenX(5 * MatrCol);
            int LastX = GetScreenX(5 * MatrCol + 5 * Width);

            int ScrY = GetScreenY(-CityHeight * 5 + 5 * MatrRow);
            int LastY = GetScreenY(-CityHeight * 5 + 5 * MatrRow + 5 * Height);

            SolidBrush Br = new SolidBrush(Color);
            _CanvasLogics.FillRectangle(Br, ScrX, ScrY, LastX - ScrX, Math.Abs(LastY - ScrY));
        }

        #endregion
    }
}