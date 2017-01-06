using System;
using System.Collections.Generic;
using System.Drawing;

namespace AgencySimulator
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
        private List<(double x, double y)> points;

        /// <summary>
        /// Хэш названия данного агентства.
        /// </summary>
        private long hash;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор рисовальщика графика.
        /// </summary>
        /// <param name="Points">Кортеж точек графика.</param>
        /// <param name="HashCode">Хэш названия агентства.</param>
        public GraphDrawer(List<(double, double)> Points, long HashCode)
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
                int B = (int)(hash % 100 * 2);
                while (B * 2 < 255)
                    B *= 2;
                int G = (int)(hash % 10_000 / 50);
                while (G * 2 < 255)
                    G *= 2;
                int R = (int)(hash % 1_000_000 / 5_000);
                while (R * 2 < 255)
                    R *= 2;
                Pen P = new Pen(Color.FromArgb(R, G, B), 2);
                Graphics.DrawLine(P, new Point(GetScreenX(0), GetScreenY(0)),
                  new Point(GetScreenX(points[0].x), GetScreenY(-points[0].y)));
                for (int i = 1; i < L; i++)
                {
                    Graphics.DrawLine(P,
                        new Point(GetScreenX(points[i - 1].x), GetScreenY(-points[i - 1].y)),
                         new Point(GetScreenX(points[i].x), GetScreenY(-points[i].y)));
                }
            }
        }

        #endregion
    }
}