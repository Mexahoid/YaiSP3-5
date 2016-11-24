using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Yaisp3
{
    /// <summary>
    /// Главный темплейт рисования изображения.
    /// </summary>
    class MainDrawingTemplate
    {
        #region Поля

        /// <summary>
        /// Графика элемента управления.
        /// </summary>
        protected Graphics CanvasControl;

        /// <summary>
        /// Графика битмапа рисования.
        /// </summary>
        protected Graphics _CanvasLogics;

        /// <summary>
        /// Битмап рисования.
        /// </summary>
        protected Bitmap _CanvasImage;


        /// <summary>
        /// Координаты изображения окна.
        /// </summary>
        protected int I1 = 0, I2 = 0, J1 = 0, J2 = 0;

        /// <summary>
        /// Координаты сиюминутного видимого куска графика.
        /// </summary>
        protected double x1p = -10, y1p = -100, x2p = 100, y2p = 10;

        /// <summary>
        /// Координаты изначального видимого куска графика.
        /// </summary>
        protected double x1old = -10, y1old = -100, x2old = 100, y2old = 10; 

        #endregion

        #region Методы

        /// <summary>
        /// Выгружает канвасы из памяти.
        /// </summary>
        public void DisposeBitmap()
        {
            CanvasControl.Dispose();
            _CanvasLogics.Dispose();
            _CanvasImage.Dispose();
        }

        /// <summary>
        /// Отрисовывает изображение на канвас.
        /// </summary>
        public void DrawImage()
        {
            CanvasControl.DrawImage(_CanvasImage, 0, 0);
        }

        /// <summary>
        /// Очищает канвас.
        /// </summary>
        public void ClearCanvas()
        {
            _CanvasLogics.Clear(Color.White);
        }

        //=============================   Преобразования координат

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

        /// <summary>
        /// Превращает Х экрана в Х графика.
        /// </summary>
        /// <param name="I">Х экрана.</param>
        /// <returns>Возвращает вещественное значение.</returns>
        protected double GetGraphX(int I)
        {
            return x1p + (I - I1) * (x2p - x1p) / (I2 - I1);
        }

        /// <summary>
        /// Превращает Y экрана в Y графика.
        /// </summary>
        /// <param name="J">Y экрана.</param>
        /// <returns>Возвращает вещественное значение.</returns>
        protected double GetGraphY(int J)
        {
            return y1p + (J - J1) * (y2p - y1p) / (J2 - J1);
        }

        /// <summary>
        /// Двигает изображение из одной точки в другую.
        /// </summary>
        /// <param name="MouseX">Х конечной точки.</param>
        /// <param name="MouseY">Y конечной точки.</param>
        /// <param name="OldCoordsX">Х первичной точки.</param>
        /// <param name="OldCoordsY">Y первичной точки.</param>
        public void Move(int MouseX, int MouseY, int OldCoordsX, int OldCoordsY)
        {
            double dx = GetGraphX(MouseX) - GetGraphX(OldCoordsX);
            double dy = GetGraphY(MouseY) - GetGraphY(OldCoordsY);

            x1p -= dx;
            y1p -= dy;
            x2p -= dx;
            y2p -= dy;
        }

        /// <summary>
        /// Восстанавливает изначальный масштаб.
        /// </summary>
        public void SetNormalZoom()
        {
            x1p = x1old;
            x2p = x2old;
            y1p = y1old;
            y2p = y2old;
        }

        /// <summary>
        /// Увеличение масштаба в точке Х, Y.
        /// </summary>
        /// <param name="IX">X точки масштаба.</param>
        /// <param name="IY">Y точки масштаба.</param>
        /// <param name="Delta">Меньше 0 - увеличение, больше - уменьшение.</param>
        public void Zoom(int IX, int IY, int Delta)
        {
            double x = GetGraphX(IX);
            double y = GetGraphY(IY);
            double coeff = 0;
            if (Delta < 0)
                coeff = 1.03;
            else
                coeff = 0.97;
            x1p = x - (x - x1p) * coeff;  //x1 > x
            x2p = x + (x2p - x) * coeff;
            y1p = y - (y - y1p) * coeff;
            y2p = y + (y2p - y) * coeff;
        }

        #endregion

    }
}