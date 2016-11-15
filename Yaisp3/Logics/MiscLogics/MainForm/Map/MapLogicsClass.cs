using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
  class MapLogicsClass : MainLogicsTemplate
  {
    protected int[,] cityMatrix;
    protected string cityName;

    /// <summary>
    /// Конструктор для загрузки города, загруженного в программе
    /// </summary>
    /// <param name="Control">Контрол, на котором производится рисование</param>
    public MapLogicsClass(Control Control)
    {
      cityMatrix = MainUnitProcessor.CityGetDrawingData();
      cityName = MainUnitProcessor.CityGetName();
      drawingKit = new CityRedactorDrawingClass(Control, cityMatrix.GetLength(1), cityMatrix.GetLength(0));
      ClearImage();
      MainDraw();
    }
    public MapLogicsClass()
    {

    }
    /// <summary>
    /// Отрисовывает все заполненные клетки
    /// </summary>
    protected void DrawElements()
    {
      int Rows = cityMatrix.GetLength(0), Cols = cityMatrix.GetLength(1);
      for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
          if (cityMatrix[i, j] != 0)
            drawingKit.DrawCityElement(i, j, cityMatrix[i, j]);
    }
    /// <summary>
    /// Рисует сетку города
    /// </summary>
    protected void DrawGrid()
    {
      drawingKit.DrawGrid();
    }
    /// <summary>
    /// Полная отрисовка изображения на канвас
    /// </summary>
    protected override void MainDraw()
    {
      DrawElements();
      DrawGrid();
      drawingKit.DrawImage();
    }
  }
}
