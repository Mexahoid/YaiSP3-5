using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    class GraphLogicsClass : MainLogicsTemplate
    {
        /// <summary>
        /// Создает экземпляр логики графика
        /// </summary>
        /// <param name="Control"></param>
        public GraphLogicsClass(Control Control, List<double[]> graphPoints)
        {
            drawingKit = new GraphDrawingClass(Control, graphPoints);
        }

        protected override void MainDraw()
        {
            ((GraphDrawingClass)drawingKit).DrawGraph();
        }
    }
}
