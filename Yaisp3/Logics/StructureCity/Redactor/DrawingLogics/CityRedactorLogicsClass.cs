using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    /// <summary>
    /// Класс логики редактора города.
    /// </summary>
    class CityRedactorLogicsClass : MapLogicsClass
    {
        #region Методы
        
        /// <summary>
        /// Конструктор для создания города с нуля.
        /// </summary>
        /// <param name="Control">Контрол, на котором производится рисование.</param>
        public CityRedactorLogicsClass(Control Control) : base(Control)
        {
            Tuple<int, int> T = MainUnitProcessor.CityGetSize();
            drawingKit = new CityRedactorDrawingClass(Control, T.Item1, T.Item2);
            ClearImage();
            MainDraw();
        }

        /// <summary>
        /// Отрисовка устанавливаемого элемента.
        /// </summary>
        /// <param name="X">Х указателя мыши.</param>
        /// <param name="Y">Y указателя мыши.</param>
        /// <param name="Width">Ширина устанавливаемого элемента.</param>
        /// <param name="Height">Высота устанавливаемого элемента.</param>
        public void DrawCurrentObject(int X, int Y, int Width, int Height)
        {
            drawingKit.ClearCanvas();
            DrawElements();
            (drawingKit as CityRedactorDrawingClass).DrawPlaceableObject(X, Y, Width, Height);
            DrawGrid();
            drawingKit.DrawImage();
        }

        /// <summary>
        /// Добавление устанавливаемого объекта на карту города.
        /// </summary>
        /// <param name="X">Х указателя мыши.</param>
        /// <param name="Y">Y указателя мыши.</param>
        /// <param name="Width">Ширина устанавливаемого элемента.</param>
        /// <param name="Height">Высота устанавливаемого элемента.</param>
        public void AddElementToMatrix(int X, int Y, int Width, int Height)
        {
            int Row, Col;
            if ((drawingKit as CityRedactorDrawingClass).FindPlaceInMatrix(X, Y, out Row, out Col))
                MainUnitProcessor.CityHousePlace(Row, Col, Width, Height);
            ClearImage();
            MainDraw();
        }

        #endregion
    }
}