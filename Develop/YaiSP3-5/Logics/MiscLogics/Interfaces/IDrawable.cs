using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AgencySimulator
{
    /// <summary>
    /// Интерфейс отрисовываемого объекта.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// Метод отрисовки.
        /// </summary>
        /// <param name="Graphics">Канва, на которой производится отрисовка.</param>
        void Draw(Graphics Graphics);

        /// <summary>
        /// Установка координат.
        /// </summary>
        /// <param name="T">Кортеж линейных координат.</param>
        void SetDims((int height, int width, double x1p, double y1p, double x2p, double y2p) T);
    }
}
