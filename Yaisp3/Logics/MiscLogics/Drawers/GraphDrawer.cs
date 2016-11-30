using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс отрисовщика графика бюджета.
    /// </summary>
    class GraphDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Кортеж точек графика.
        /// </summary>
        List<Tuple<double, double>> points;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор рисовальщика графика.
        /// </summary>
        /// <param name="Points">Кортеж точек графика.</param>
        public GraphDrawer(List<Tuple<double, double>> Points)
        {
            points = Points;
        }

        /// <summary>
        /// Отрисовывает график по точкам.
        /// </summary>
        /// <param name="Graphics">Канва, на которой происходит отрисовка.</param>
        public override void Draw(Graphics Graphics)
        {
            int L = points.Count;

            Graphics.DrawLine(Pens.Red, GetScreenX(0), GetScreenY(-500), GetScreenX(0), GetScreenY(500));
            Graphics.DrawLine(Pens.Blue, GetScreenX(-500), GetScreenY(0), GetScreenX(500), GetScreenY(0));
            if (L != 0)
            {
                Graphics.DrawLine(Pens.Green, new Point(GetScreenX(0), GetScreenY(0)),
                  new Point(GetScreenX(points[0].Item1), GetScreenY(-points[0].Item2)));
                Pen P;
                for (int i = 1; i < L; i++)
                {
                    P = points[i - 1].Item2 < points[i].Item2 ? Pens.Green : Pens.Red;
                    Graphics.DrawLine(P,
                        new Point(GetScreenX(points[i - 1].Item1), GetScreenY(-points[i - 1].Item2)),
                         new Point(GetScreenX(points[i].Item1), GetScreenY(-points[i].Item2)));
                }
            }
        }

        #endregion
    }
}
