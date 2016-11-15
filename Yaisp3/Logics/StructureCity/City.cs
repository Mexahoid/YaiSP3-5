using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  public class City
  {
    /// <summary>
    /// Класс позиции элемента в городе
    /// </summary>
    public class Position
    {
      /// <summary>
      /// Ряд в матрице
      /// </summary>
      public int row;
      /// <summary>
      /// Столбец в матрице
      /// </summary>
      public int col;
      /// <summary>
      /// Конструктор позиции
      /// </summary>
      /// <param name="Row">Ряд</param>
      /// <param name="Col">Столбец</param>
      public Position(int Row, int Col)
      {
        row = Row;
        col = Col;
      }
    }


    //private int[,] cityMatrix;


    /// <summary>
    /// Название города
    /// </summary>
    private string cityName;
    /// <summary>
    /// Матрица города для расчетов эпицентров и волн коэффициентов удаления
    /// </summary>
    private double[,] cityMatrixProximity;
    /// <summary>
    /// Главная матрица элементов
    /// </summary>
    private Element[,] cityMatrix;
    /// <summary>
    /// Количество групп элементов домов
    /// </summary>
    private int cityHouseGroups;

    /// <summary>
    /// Главный конструктор города
    /// </summary>
    /// <param name="Name">Название города</param>
    /// <param name="Width">Ширина города</param>
    /// <param name="Height">Высота города</param>
    public City(string Name, int Width, int Height)
    {
      cityMatrix = new Element[Height, Width];
      cityMatrixProximity = new double[Height, Width];
      cityName = Name;
    }

    public string GetName()
    {
      return cityName;
    }

    /// <summary>
    /// Проверяет возможность установки элемента
    /// </summary>
    /// <param name="X00">Х верхней левой точки элемента</param>
    /// <param name="Y00">Y верхней левой точки элемента</param>
    /// <param name="RightWidth">Ширина элемента</param>
    /// <param name="DownDepth">Высота (вниз) элемента</param>
    /// <returns></returns>
    private bool TryToPlaceElement(int X00, int Y00, int RightWidth, int DownDepth)
    {
      for (int i = Y00; i <= RightWidth + Y00; i++)
        for (int j = X00; j <= DownDepth + X00; j++)
          if (cityMatrix[i, j] != null)
            return false;
      return true;
    }

    /// <summary>
    /// Создает новый экземпляр дома
    /// </summary>
    /// <param name="Width">Ширина дома</param>
    /// <param name="Height">Высота дома</param>
    /// <returns>Возвращает дом новой группы</returns>
    public House CreateHouse(int Width, int Height)
    {
      House House = new House(cityHouseGroups++, Width, Height);
      return House;
    }

    /// <summary>
    /// Устанавливает элемент
    /// </summary>
    /// <param name="X00">Х верхней левой точки элемента</param>
    /// <param name="Y00">Y верхней левой точки элемента</param>
    /// <param name="Element">Устанавливаемый элемент</param>
    public void PlaceElement(int X00, int Y00, Element Element)
    {
      if (Element.ReturnType())
      {
        Tuple<int, int> T = ((House)Element).GetHouseSize();
        if (TryToPlaceElement(X00, Y00, T.Item1, T.Item2))
          for (int i = Y00; i < T.Item1 + Y00; i++)
            for (int j = X00; j < T.Item2 + X00; j++)
              cityMatrix[i, j] = Element;
      }
      else
        cityMatrix[X00, Y00] = Element;
    }

    public System.Drawing.Color[,] GetDrawingData()
    {
      int Rows = cityMatrix.GetLength(0);
      int Cols = cityMatrix.GetLength(1);

      System.Drawing.Color[,] Colors = new System.Drawing.Color[Rows, Cols];
      for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
          if (cityMatrix[i, j] != null)
            if (cityMatrix[i, j].ReturnType())
              Colors[i, j] = System.Drawing.Color.Gray;
            else
              Colors[i,j] = ((Billboard)cityMatrix[i, j]).GetBillboardColor();
      return Colors;
    }
    public List<Position> GetFreeSpaces()
    {
      List<Position> FreeSpaces = new List<Position>();
      int Rows = cityMatrix.GetLength(0);
      int Cols = cityMatrix.GetLength(1);
      for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
          if (cityMatrix[i, j] == null)
            FreeSpaces.Add(new Position(i, j));
      return FreeSpaces;
    }
  }
}
