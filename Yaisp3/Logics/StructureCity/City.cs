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


    private int[,] cityMatrix;


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
    private Element[,] cityMatrix1;
    /// <summary>
    /// Количество групп элементов домов
    /// </summary>
    private int cityHouseGroups;

    /// <summary>
    /// Главный конструктор города
    /// </summary>
    /// <param name="Name">Название города</param>
    /// <param name="Matrix"></param>
    public City(string Name, int[,] Matrix)
    {
      cityMatrix = Matrix;
      cityName = Name;
    }
    public int[,] GetDrawingData()
    {
      return cityMatrix;
    }
    public string GetName()
    {
      return cityName;
    }
    public void PlaceBillBoard(int X00, int Y00)
    {
      cityMatrix[X00, Y00] = 2;
    }

    /// <summary>
    /// Проверяет возможность установки элемента
    /// </summary>
    /// <param name="X00">Х верхней левой точки элемента</param>
    /// <param name="Y00">Y верхней левой точки элемента</param>
    /// <param name="RightWidth">Ширина элемента</param>
    /// <param name="DownDepth">Высота (вниз) элемента</param>
    /// <returns></returns>
    public bool TryToPlaceElement(int X00, int Y00, int RightWidth, int DownDepth)
    {
      for (int i = Y00; i <= RightWidth; i++)
        for (int j = X00; j <= DownDepth; j++)
          if (cityMatrix1[i, j] != null)
            return false;
      return true;
    }

    /// <summary>
    /// Устанавливает элемент
    /// </summary>
    /// <param name="X00">Х верхней левой точки элемента</param>
    /// <param name="Y00">Y верхней левой точки элемента</param>
    /// <param name="RightWidth">Ширина элемента</param>
    /// <param name="DownDepth">Высота (вниз) элемента</param>
    public void PlaceElement(int X00, int Y00, int RightWidth, int DownDepth)
    {
      House House = new House(null, 1);
      for (int i = Y00; i <= RightWidth; i++)
        for (int j = X00; j <= DownDepth; j++)
          cityMatrix1[i, j] = House;
    }


    public void RecreateMatrix(int[,] Matrix)
    {
      cityMatrix = Matrix;
    }
    public List<Position> GetFreeSpaces()
    {
      List<Position> FreeSpaces = new List<Position>();
      int Rows = cityMatrix.GetLength(0);
      int Cols = cityMatrix.GetLength(1);
      for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
          if (cityMatrix[i, j] == 0)
            FreeSpaces.Add(new Position(i, j));
      return FreeSpaces;
    }
    public void FillSpace(Position Pos)
    {
      cityMatrix[Pos.row, Pos.col] = 2;
    }
  }
}
