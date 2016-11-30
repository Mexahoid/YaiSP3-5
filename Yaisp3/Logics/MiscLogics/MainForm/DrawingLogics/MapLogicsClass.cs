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
        protected List<Tuple<System.Drawing.Color, int, int, int, int>> colorTuple;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор для загрузки города, загруженного в программе.
        /// </summary>
        /// <param name="Control">Элемент управления, на котором производится рисование.</param>
        public MapLogicsClass(Control Control)
        {
            //colorTuple = MainUnitProcessor.CityGetDrawingData();
            //Tuple<int, int> T = MainUnitProcessor.CityGetSize();
           // drawingKit = new MapDrawingClass(Control, T.Item1, T.Item2);
            ClearImage();
            MainDraw();
        }

        /// <summary>
        /// Отрисовывает все заполненные клетки.
        /// </summary>
        protected void DrawElements()
        {
            int L = colorTuple.Count;
            for (int i = 0; i < L; i++)
                ((MapDrawingClass)drawingKit).DrawCityElement(
                    colorTuple[i].Item2,
                    colorTuple[i].Item3,
                    colorTuple[i].Item4,
                    colorTuple[i].Item5,
                    colorTuple[i].Item1);
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
            //colorTuple = MainUnitProcessor.CityGetDrawingData();
            DrawElements();
            DrawGrid();
            drawingKit.DrawImage();
        }

        #endregion
    }
}