using System;
using System.Collections.Generic;
using System.Drawing;

namespace AgencySimulator.Drawers
{
    /// <summary>
    /// Класс отрисовщика графика бюджета.
    /// </summary>
    public class GraphDrawer : DrawingWrapperTemplate
    {
        #region Поля

        /// <summary>
        /// Кортеж точек графика.
        /// </summary>
        private List<Tuple<double, double>> points;

        /// <summary>
        /// Хэш названия данного агентства.
        /// </summary>
        private int hash;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор рисовальщика графика.
        /// </summary>
        /// <param name="Points">Кортеж точек графика.</param>
        /// <param name="HashCode">Хэш названия агентства.</param>
        public GraphDrawer(List<Tuple<double, double>> Points, int HashCode)
        {
            points = Points;
            hash = HashCode;
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
                Pen P = new Pen(Color.FromArgb(hash), 2);
                Graphics.DrawLine(P, new Point(GetScreenX(0), GetScreenY(0)),
                  new Point(GetScreenX(points[0].Item1), GetScreenY(-points[0].Item2)));
                for (int i = 1; i < L; i++)
                {
                    Graphics.DrawLine(P,
                        new Point(GetScreenX(points[i - 1].Item1), GetScreenY(-points[i - 1].Item2)),
                         new Point(GetScreenX(points[i].Item1), GetScreenY(-points[i].Item2)));
                }
            }
        }

        #endregion
    }
}