using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    class MapLogicsClass : MainLogicsTemplate
    {
        /// <summary>
        /// Цветовая матрица элементов города
        /// </summary>
        protected System.Drawing.Color[,] colorMatrix;
        /// <summary>
        /// Название города
        /// </summary>
        protected string cityName;

        /// <summary>
        /// Конструктор для загрузки города, загруженного в программе
        /// </summary>
        /// <param name="Control">Контрол, на котором производится рисование</param>
        public MapLogicsClass(Control Control)
        {
            colorMatrix = MainUnitProcessor.CityGetDrawingData();
            cityName = MainUnitProcessor.CityGetName();
            drawingKit = new CityRedactorDrawingClass(Control, colorMatrix.GetLength(1), colorMatrix.GetLength(0));
            ClearImage();
            MainDraw();
        }

        /// <summary>
        /// Отрисовывает все заполненные клетки
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
        /// Рисует сетку города
        /// </summary>
        protected void DrawGrid()
        {
            ((MapDrawingClass)drawingKit).DrawGrid();
        }
        /// <summary>
        /// Полная отрисовка изображения на канвас
        /// </summary>
        protected override void MainDraw()
        {
            colorMatrix = MainUnitProcessor.CityGetDrawingData();
            DrawElements();
            DrawGrid();
            drawingKit.DrawImage();
        }
    }
}