using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  class CityCreatorLogicsClass
  {
    private int[,] cityMatrix;
    private string cityName;
    private CityCreatorDrawingClass cityDrawingKit;

    public CityCreatorLogicsClass(int Height, int Width, string Name, System.Windows.Forms.Control Control)
    {
      cityMatrix = new int[Height, Width];
      cityName = Name;
      cityDrawingKit = new CityCreatorDrawingClass(Control, Width, Height);
      ClearImage();
      MainDraw();
    }
    public CityCreatorLogicsClass(System.Windows.Forms.Control Control)   //Это для загрузки уже созданного города
    {
      cityMatrix = MainUnitProcessor.CityGetDrawingData();
      cityName = MainUnitProcessor.CityGetName();
      cityDrawingKit = new CityCreatorDrawingClass(Control, cityMatrix.GetLength(1), cityMatrix.GetLength(0));
      ClearImage();
      MainDraw();
    }
    public bool Load(System.Windows.Forms.Control Control, string Input)
    {
      try
      {
        string[] Arr = Input.Split(new string[] { "\n", "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
        int Leng = Arr.Length;
        cityName = Arr[0];
        int Height = int.Parse(Arr[1]);
        int Width = int.Parse(Arr[2]);
        cityMatrix = new int[Height, Width];
        for (int i = 3; i < Height + 3; i++)
          for (int j = 0; j < Width; j++)
            cityMatrix[i, j] = (int)char.GetNumericValue(Arr[i][j]);
        cityDrawingKit = new CityCreatorDrawingClass(Control, Width, Height);
        return true;
      }
      catch
      {
        cityName = "";
        cityMatrix = null;
        cityDrawingKit = null;
        return false;
      }
    }
    public string Save()
    {
      int Width = cityMatrix.GetLength(1);
      int Height = cityMatrix.GetLength(0);
      string Out = cityName + '\n' + 
        Height + '\n' + 
        Width + '\n';
      for (int i = 0; i < Height; i++)
      {
        for (int j = 0; j < Width; j++)
          Out += cityMatrix[i, j];
        Out += '\n';
      }
      return Out;
    }
    public void DrawElements()
    {
      int Rows = cityMatrix.GetLength(0), Cols = cityMatrix.GetLength(1);
      for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
          if (cityMatrix[i, j] != 0)
            cityDrawingKit.DrawCityElement(i, j, cityMatrix[i, j]);
    }
    public void DrawGrid()
    {
      cityDrawingKit.DrawGrid();
    }

    private void ClearImage()
    {
      cityDrawingKit.ClearCanvas();
    }

    public void DestroyCreator()
    {
      cityDrawingKit.ClearCanvas();
      cityDrawingKit.DrawImage();
      cityDrawingKit.DropBitm();
    }
    public void DrawCurrentObject(int X, int Y, int Width, int Height)
    {
      cityDrawingKit.ClearCanvas();
      DrawElements();
      cityDrawingKit.DrawCurrentObject(X, Y, Width, Height);
      DrawGrid();
      cityDrawingKit.DrawImage();
    }
    public void MoveImage(int XN, int YN, int XO, int YO)
    {
      cityDrawingKit.ClearCanvas();
      cityDrawingKit.Move(XN, YN, XO, YO);
      MainDraw();
    }
    public void ZoomImage(int X, int Y, int Delta)
    {
      cityDrawingKit.ClearCanvas();
      cityDrawingKit.Zoom(X, Y, Delta);
      MainDraw();
    }
    public void MainDraw()
    {
      DrawElements();
      DrawGrid();
      cityDrawingKit.DrawImage();
    }

    public void AddElementToMatrix(int X, int Y, int Width, int Height)
    {
      int Row, Col;
      if (cityDrawingKit.FindPlaceInMatrix(X, Y, out Row, out Col))
        if (CanElementBePlaced(Row, Col, Width, Height))
          for (int i = Row; i < Row + Height; i++)
            for (int j = Col; j < Width + Col; j++)
              cityMatrix[i, j] = 1;
      ClearImage();
      MainDraw();
    }
    public bool CanElementBePlaced(int Row, int Col, int Width, int Height)
    {
      for (int i = Row; i < Row + Height; i++)
        for (int j = Col; j < Width + Col; j++)
          if (cityMatrix[i, j] != 0)
            return false;
      return true;
    }
    public void LoadMatrix()
    {
      cityMatrix = MainUnitProcessor.CityGetDrawingData();
    }
    public void CreateCity()
    {
      MainUnitProcessor.CityCreate(cityMatrix, cityName);
    }
    public int[,] GetDrawData()
    {
      return cityMatrix;
    }
  }
}
