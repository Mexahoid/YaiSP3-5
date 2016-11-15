using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
  class GraphLogicsClass : MainLogicsTemplate
  {
    private GraphDrawingClass graphDrawingKit;

    /// <summary>
    /// Создает экземпляр логики графика
    /// </summary>
    /// <param name="Control"></param>
    public GraphLogicsClass(Control Control)
    {
      graphDrawingKit = new GraphDrawingClass(Control);
    }
  }
}
