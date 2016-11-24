using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    /// <summary>
    /// Логический класс рисования графика.
    /// </summary>
    class GraphLogicsClass : MainLogicsTemplate
    {
        /// <summary>
        /// Создает набор рисования графика.
        /// </summary>
        /// <param name="Control">Элемент управления, на котором производится рисование.</param>
        /// <param name="GraphPoints">Набор точек для отрисовки графика.</param>
        public GraphLogicsClass(Control Control, List<Tuple<double, double>> GraphPoints)
        {
            drawingKit = new GraphDrawingClass(Control, GraphPoints);
        }

        /// <summary>
        /// Главный метод рисования графика.
        /// </summary>
        protected override void MainDraw()
        {
            ((GraphDrawingClass)drawingKit).DrawGraph();
        }
    }
}
