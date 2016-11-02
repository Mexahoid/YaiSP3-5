using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  class CityCreatorDrawingClass : DrawingClassCity
  {
    public CityCreatorDrawingClass(System.Windows.Forms.Control Control, int CWidth, int CHeight) : base(Control, CWidth, CHeight)
    {
    }
    public void DrawCurrentObject(int X, int Y, int Width, int Height)
    {
      double PapX = GetGraphX(X) - 2.5;
      double PapY = GetGraphY(Y) - 2.5;
      int a = GetScreenX(PapX),
        b = GetScreenY(PapY),
        c = Math.Abs(a - GetScreenX(PapX - 5 * Width)),
        d = Math.Abs(b - GetScreenY(PapY + 5 * Height));
      _CanvasLogics.FillRectangle(Brushes.Green, a, b, c, d);
      _CanvasLogics.DrawRectangle(Pens.Black, a, b, c, d);
    }
    public bool FindPlaceInMatrix(int X, int Y, out int Row, out int Col)
    {
      Row = Col = 0;
      int PapX = (int)GetGraphX(X);
      int PapY = (int)GetGraphY(Y);
      Col = PapX / 5;
      Row = CityHeight - Math.Abs(PapY / 5) - 1;
      return !(Col >= CityWidth || Row >= CityHeight || Row < 0 || Col < 0);
    }
  }
}
