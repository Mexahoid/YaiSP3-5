using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
  class Interfaces
  {
    public interface ICityDrawable
    {
      void DrawGrid();
      void DrawCityElement(int MatrRow, int MatrCol, int House);
    }
  }
}
