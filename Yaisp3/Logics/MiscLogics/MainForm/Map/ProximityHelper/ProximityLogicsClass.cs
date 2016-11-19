using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    class ProximityLogicsClass : MainLogicsTemplate
    {
        private System.Drawing.Color[,] colorMatrix;
        public ProximityLogicsClass(Control Control)
        {
            colorMatrix = MainUnitProcessor.CityGetProximityMap();
            drawingKit = new MapDrawingClass(Control, colorMatrix.GetLength(1), colorMatrix.GetLength(0));
            ClearImage();
            MainDraw();
        }

        /// <summary>
        /// Полная отрисовка изображения на канвас
        /// </summary>
        protected override void MainDraw()
        {
            colorMatrix = MainUnitProcessor.CityGetProximityMap();
            DrawProximityMap();
            ((MapDrawingClass)drawingKit).DrawGrid();
            drawingKit.DrawImage();
        }

        private void DrawProximityMap()
        {
            int Rows = colorMatrix.GetLength(0), Cols = colorMatrix.GetLength(1);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    ((MapDrawingClass)drawingKit).DrawCityElement(i, j, colorMatrix[i, j]);
        }
    }
}
