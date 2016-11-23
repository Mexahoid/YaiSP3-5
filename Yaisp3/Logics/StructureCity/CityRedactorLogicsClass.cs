using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    class CityRedactorLogicsClass : MapLogicsClass
    {
        /// <summary>
        /// Конструктор для создания города с нуля
        /// </summary>
        /// <param name="Control">Контрол, на котором производится рисование</param>
        /// <param name="Height">Высота города (в у.е.)</param>
        /// <param name="Width">Ширина города (в у.е.)</param>
        /// <param name="Name">Название города</param>
        public CityRedactorLogicsClass(Control Control) : base(Control)
        {
            cityName = MainUnitProcessor.CityGetName();
            colorMatrix = MainUnitProcessor.CityGetDrawingData();
            drawingKit = new CityRedactorDrawingClass(Control, colorMatrix.GetLength(1), colorMatrix.GetLength(0));
            ClearImage();
            MainDraw();
        }

        /// <summary>
        /// Конструктор для парсинга и загрузки города из файла
        /// </summary>
        /// <param name="Control">Контрол, на котором производится рисование</param>
        /// <param name="Input">Входная на парсер строка</param>
        /*public CityRedactorLogicsClass(Control Control, string Input) : base()
        {
            try
            {
              string[] Arr = Input.Split(new string[] { "\n", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
              cityName = Arr[0];
              int Height = int.Parse(Arr[1]);
              int Width = int.Parse(Arr[2]);
              cityMatrix = new int[Height, Width];
              for (int i = 3; i < Height + 3; i++)
                for (int j = 0; j < Width; j++)
                  cityMatrix[i - 3, j] = (int)char.GetNumericValue(Arr[i][j]);
              drawingKit = new CityRedactorDrawingClass(Control, Width, Height);
              MainDraw();
            }
            catch
            {
              cityName = "";
              cityMatrix = null;
              drawingKit = null;
            }
        }*/

        /// <summary>
        /// Сохранение карты города
        /// </summary>
        /// <returns>Возвращает строку-данные города</returns>
        public string Save()
        {
            //int Height = cityMatrix.GetLength(0);
            //int Width = cityMatrix.GetLength(1);
            string Out = cityName + '\n';
            /*  Height + '\n' +
              Width + '\n';
            for (int i = 0; i < Height; i++)
            {
              for (int j = 0; j < Width; j++)
                Out += cityMatrix[i, j];
              Out += '\n';
            }*/
            return Out;
        }

        /// <summary>
        /// Отрисовка устанавливаемого элемента
        /// </summary>
        /// <param name="X">Х указателя мыши</param>
        /// <param name="Y">Y указателя мыши</param>
        /// <param name="Width">Ширина устанавливаемого элемента (в у.е.)</param>
        /// <param name="Height">Высота устанавливаемого элемента (в у.е.)</param>
        public void DrawCurrentObject(int X, int Y, int Width, int Height)
        {
            drawingKit.ClearCanvas();
            DrawElements();
            (drawingKit as CityRedactorDrawingClass).DrawPlaceableObject(X, Y, Width, Height);
            DrawGrid();
            drawingKit.DrawImage();
        }

        /// <summary>
        /// Добавление устанавливаемого объекта на карту города
        /// </summary>
        /// <param name="X">Х указателя мыши</param>
        /// <param name="Y">Y указателя мыши</param>
        /// <param name="Width">Ширина устанавливаемого элемента (в у.е.)</param>
        /// <param name="Height">Высота устанавливаемого элемента (в у.е.)</param>
        public void AddElementToMatrix(int X, int Y, int Width, int Height)
        {
            int Row, Col;
            if ((drawingKit as CityRedactorDrawingClass).FindPlaceInMatrix(X, Y, out Row, out Col))
                MainUnitProcessor.CityHousePlace(Row, Col, Width, Height);
            ClearImage();
            MainDraw();
        }
    }
}