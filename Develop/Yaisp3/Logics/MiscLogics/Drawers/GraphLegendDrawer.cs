using System;
using System.Collections.Generic;
using System.Drawing;

namespace AgencySimulator
{
    /// <summary>
    /// Класс отрисовщика легенды графиков.
    /// </summary>
    class GraphLegendDrawer : IDrawable
    {
        #region Поля

        /// <summary>
        /// Список названий агентств.
        /// </summary>
        private List<string> agencyNames;

        /// <summary>
        /// Список хэшей названий.
        /// </summary>
        private List<long> hashes;

        /// <summary>
        /// Правая граница канваса.
        /// </summary>
        private int rightBoundary;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор отрисовщика легенды.
        /// </summary>
        /// <param name="Names">Список названий агентств.</param>
        /// <param name="Hashes">Список хэшей от названий.</param>
        public GraphLegendDrawer(List<string> Names, List<long> Hashes)
        {
            agencyNames = Names;
            hashes = Hashes;
        }

        /// <summary>
        /// Отрисовывает сетку города.
        /// </summary>
        /// <param name="Graphics">Канва, на которой производится рисование.</param>
        public void Draw(Graphics Graphics)
        {
            int Height = agencyNames.Count;
            string MaxName = "";
            for (int i = 0; i < Height; i++)
                if (agencyNames[i].Length > MaxName.Length)
                    MaxName = agencyNames[i];
            if (MaxName.Length <= 7)
                MaxName = "Легенда";
            SizeF S = Graphics.MeasureString(MaxName, new Font("Arial", 10));
            SizeF A = Graphics.MeasureString("Легенда", new Font("Arial", 14));
            Graphics.FillRectangle(Brushes.LightGray,
                rightBoundary - S.Width - 30, 0, S.Width + 30,
                A.Height + (Height + 1) * S.Height);
            Graphics.DrawRectangle(Pens.Black,
                rightBoundary - S.Width - 30, 0, S.Width + 30,
                A.Height + (Height + 1) * S.Height);
            Graphics.DrawString("Легенда", new Font("Arial", 14), Brushes.Black,
                rightBoundary - (S.Width + 30) / 2 - A.Width / 2, 0);
            for (int i = 0; i < Height; i++)
            {
                Graphics.DrawString(agencyNames[i], new Font("Arial", 10), Brushes.Black,
                  rightBoundary - S.Width - 25, A.Height + i * S.Height);
                int B = (int)(hashes[i] % 100 * 2);
                while (B * 2 < 255)
                    B *= 2;
                int G = (int)(hashes[i] % 10_000 / 50);
                while (G * 2 < 255)
                    G *= 2;
                int R = (int)(hashes[i] % 1_000_000 / 5_000);
                while (R * 2 < 255)
                    R *= 2;
                Graphics.DrawLine(new Pen(Color.FromArgb(R, G, B), 2),
                    new PointF(rightBoundary - 25, A.Height + i * S.Height + S.Height / 2),
                    new PointF(rightBoundary - 5, A.Height + i * S.Height + S.Height / 2));
            }
        }

        /// <summary>
        /// Устанавливает ширину графики для позиционирования окна.
        /// </summary>
        /// <param name="T">Кортеж координат.</param>
        public void SetDims(Tuple<int, int, double, double, double, double> T)
        {
            rightBoundary = T.Item2;
        }

        #endregion
    }
}
