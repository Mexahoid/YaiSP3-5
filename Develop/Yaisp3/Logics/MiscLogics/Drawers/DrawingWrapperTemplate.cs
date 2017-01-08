using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AgencySimulator
{
    /// <summary>
    /// Абстрактный класс рисовальщика.
    /// </summary>
    public abstract class DrawingWrapperTemplate : IDrawable
    {
        #region Поля
        
        /// <summary>
        /// Координаты изображения окна.
        /// </summary>
        protected int I1 = 0, I2 = 0, J1 = 0, J2 = 0;

        /// <summary>
        /// Координаты сиюминутного видимого куска графика.
        /// </summary>
        protected double x1p = -10, y1p = -100, x2p = 100, y2p = 10;

        #endregion

        #region Методы
        
        /// <summary>
        /// Абстрактный метод рисования.
        /// </summary>
        /// <param name="Graphics">Канва, на которой рисуется элемент.</param>
        public abstract void Draw(Graphics Graphics);

        /// <summary>
        /// Устанавливает координаты рисования.
        /// </summary>
        /// <param name="Coords">Кортеж координатных составляющих.</param>
        public void SetDims((int height, int width, double x1p, double y1p, double x2p, double y2p) Coords)
        {
            I2 = Coords.height;
            J2 = Coords.width;
            x1p = Coords.x1p;
            y1p = Coords.y1p;
            x2p = Coords.x2p;
            y2p = Coords.y2p;
        }

        /// <summary>
        /// Превращает Х графика в Х экрана.
        /// </summary>
        /// <param name="x">Х графика.</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        protected int GetScreenX(double x) =>
            I1 + (int)((x - x1p) * (I2 - I1) / (x2p - x1p));

        /// <summary>
        /// Превращает Y графика в Y экрана.
        /// </summary>
        /// <param name="y">Y графика.</param>
        /// <returns>Возвращает целочисленное значение.</returns>
        protected int GetScreenY(double y) =>
            J1 + (int)((y - y1p) * (J1 - J2) / (y1p - y2p));

        #endregion
    }
}