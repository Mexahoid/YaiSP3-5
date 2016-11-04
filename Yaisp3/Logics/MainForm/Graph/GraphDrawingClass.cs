using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Yaisp3
{
  class GraphDrawingClass : MainDrawingTemplate
  {
    private List<Point> graphPoints;

    /// <summary>
    /// Создает новый экземпляр отрисовщика графика
    /// </summary>
    /// <param name="Control"></param>
    public GraphDrawingClass(Control Control)
    {
      graphPoints = new List<Point>();
    }
  }
}
