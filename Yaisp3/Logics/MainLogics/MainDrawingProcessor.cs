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

        Graphics ControlCanvas;
        Graphics DrawingCanvas;
        Bitmap Bitmap;

        /// <summary>
        /// Координаты изображения окна.
        /// </summary>
        protected int I2 = 0, J2 = 0;

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
            Drawers.Add(Drawer);
        }

        public void SetCanvas(Control Control)
        {
            ControlCanvas = Control.CreateGraphics();
            Bitmap = new Bitmap(Control.Width, Control.Height);
            DrawingCanvas = Graphics.FromImage(Bitmap);

            I2 = Control.Width;
            J2 = Control.Height;
        }

        public void Draw()
        {
            DrawingCanvas.Clear(Color.White);
            int C = Drawers.Count;
            for (int i = C - 1; i >= 0; i--)     //Т.к. Grid должен рисоваться последним
                Drawers[i].Draw(DrawingCanvas);
            ControlCanvas.DrawImage(Bitmap, 0, 0);
        }

        public void SetDimensions()
        {
            int C = Drawers.Count;
            for (int i = 0; i < C; i++)
                Drawers[i].SetDims(Tuple.Create(I2, J2, x1p, y1p, x2p, y2p));
        }


    }
}
