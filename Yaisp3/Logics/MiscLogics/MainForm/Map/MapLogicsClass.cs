using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    /// <summary>
    /// Логический класс рисования карты.
    /// </summary>
    class MapLogicsClass : MainLogicsTemplate
    {
        #region Поля

        /// <summary>
        /// Цветовая матрица элементов города.
        /// </summary>
        protected System.Drawing.Color[,] colorMatrix;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор для загрузки города, загруженного в программе.
        /// </summary>
        /// <param name="Control">Элемент управления, на котором производится рисование.</param>
        public MapLogicsClass(Control Control)
        {
            colorMatrix = MainUnitProcessor.CityGetDrawingData();
            drawingKit = new CityRedactorDrawingClass(Control, colorMatrix.GetLength(1), colorMatrix.GetLength(0));
            ClearImage();
            MainDraw();
        }

        /// <summary>
        /// Отрисовывает все заполненные клетки.
        /// </summary>
        protected void DrawElements()
        {
            int Rows = colorMatrix.GetLength(0), Cols = colorMatrix.GetLength(1);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    if (colorMatrix[i, j] != null)
                        ((MapDrawingClass)drawingKit).DrawCityElement(i, j, colorMatrix[i, j]);
        }

        /// <summary>
        /// Рисует сетку города.
        /// </summary>
        protected void DrawGrid()
        {
            ((MapDrawingClass)drawingKit).DrawGrid();
        }

        /// <summary>
        /// Полная отрисовка изображения на канвас.
        /// </summary>
        protected override void MainDraw()
        {
            colorMatrix = MainUnitProcessor.CityGetDrawingData();
            DrawElements();
            DrawGrid();
            drawingKit.DrawImage();
        }

        #endregion
    }
}