using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Yaisp3
{
    public class MainDrawingProcessor
    {
        List<DrawingWrapperTemplate> Drawers;

        Graphics CanvasControl;
        Graphics CanvasDrawing;
        Bitmap Bitmap;

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
        protected const double x1old = -10, y1old = -100, x2old = 100, y2old = 10;


        public MainDrawingProcessor()
        {
            Drawers = new List<DrawingWrapperTemplate>();
        }

        public void AddDrawer(DrawingWrapperTemplate Drawer)
        {
            Drawer.SetDims(Tuple.Create(I2, J2, x1p, y1p, x2p, y2p));
            Drawers.Add(Drawer);
        }

        public void SetCanvas(Control Control)
        {
            CanvasControl = Control.CreateGraphics();
            Bitmap = new Bitmap(Control.Width, Control.Height);
            CanvasDrawing = Graphics.FromImage(Bitmap);
            SetNormalZoom();
            I2 = Control.Width;
            J2 = Control.Height;
        }

        public void Draw()
        {
            CanvasDrawing.Clear(Color.White);
            SetDimensions();
            int C = Drawers.Count;
            for (int i = C; i > 0; i--)     //Т.к. Grid должен рисоваться последним
                Drawers[i - 1].Draw(CanvasDrawing);
            CanvasControl.DrawImage(Bitmap, 0, 0);
        }

        public void SetDimensions()
        {
            int C = Drawers.Count;
            for (int i = 0; i < C; i++)
                Drawers[i].SetDims(Tuple.Create(I2, J2, x1p, y1p, x2p, y2p));
        }

        public void SetLastDrawer(DrawingWrapperTemplate Drawer)
        {
            Drawers[Drawers.Count - 1] = Drawer;
        }

        //========================== Набор команд линейных преобразований.

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
            x2p -= dx;
            y1p -= dy;
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
    }
}
