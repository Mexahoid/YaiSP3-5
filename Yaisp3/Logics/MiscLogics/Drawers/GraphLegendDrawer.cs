using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    class GraphLegendDrawer : IDrawable
    {
        private List<string> agencyNames;
        private int leftBoundary;

        public GraphLegendDrawer(List<string> Names, int LeftBoundary)
        {
            agencyNames = Names;
            leftBoundary = LeftBoundary;
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
            SizeF S = Graphics.MeasureString(MaxName, new Font("Arial", 10));
            SizeF A = Graphics.MeasureString("Легенда", new Font("Arial", 14));
            Graphics.FillRectangle(Brushes.LightGray, 
                leftBoundary - S.Width - 30, 0, S.Width + 30,
                A.Height + (Height + 1) * S.Height);
            Graphics.DrawRectangle(Pens.Black,
                leftBoundary - S.Width - 30, 0, S.Width + 30,
                A.Height + (Height + 1) * S.Height);
        }
    }
}
