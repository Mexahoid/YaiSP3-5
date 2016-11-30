using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yaisp3
{
    public abstract class DrawingWrapperTemplate
    {
        /// <summary>
        /// Координаты изображения окна.
        /// </summary>
        protected int I1 = 0, I2 = 0, J1 = 0, J2 = 0;

        /// <summary>
        /// Координаты сиюминутного видимого куска графика.
        /// </summary>
        protected double x1p = -10, y1p = -100, x2p = 100, y2p = 10;

        public abstract void Draw(Graphics Graphics);
        
        public void SetDims(Tuple<int, int, double, double, double, double> Coords)
        {
            I2 = Coords.Item1;
            J2 = Coords.Item2;
            x1p = Coords.Item3;
            y1p = Coords.Item4;
            x2p = Coords.Item5;
            y2p = Coords.Item6;
        }

        /// <summary>
        /// Превращает Х графика в Х экрана.
        /// </summary>
        /// <param name="x">Х графика.</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        protected int GetScreenX(double x)
        {
            return I1 + (int)((x - x1p) * (I2 - I1) / (x2p - x1p));
        }

        /// <summary>
        /// Превращает Y графика в Y экрана.
        /// </summary>
        /// <param name="y">Y графика.</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        protected int GetScreenY(double y)
        {
            return J1 + (int)((y - y1p) * (J1 - J2) / (y1p - y2p));
        }

    }
}
