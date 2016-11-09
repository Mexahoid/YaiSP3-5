using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  public class City
  {
    public class Position
    {
      public int row;
      public int col;
      public Position(int Row, int Col)
      {
        row = Row;
        col = Col;
      }
    }

    private string cityName;
    private int[,] cityMatrix;

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
    public bool TryToPlaceElement(int X00, int Y00, int RightWidth, int DownDepth)
    {  //Проверка на доступность постройки здания
      for (int i = Y00; i <= RightWidth; i++)
        for (int j = X00; j <= DownDepth; j++)
          if (cityMatrix[i, j] != 0)
            return false;
      return true;
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
