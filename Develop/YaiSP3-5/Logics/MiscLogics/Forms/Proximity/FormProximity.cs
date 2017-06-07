using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgencySimulator
{
    public partial class FormProximity : Form
    {
        private MouseEventArgs eOld;
        private MainDrawingProcessor drawer;
        private bool drawing = false;

        public FormProximity(CityHandler City)
        {
            InitializeComponent();
            drawer = new MainDrawingProcessor();
            drawer.SetRedrawEvent(new MainDrawingProcessor.DelegateReDraw(OnPaint));
            drawer.AddDrawer(new GridDrawer(City.CityGetSize()));
            drawer.AddDrawer(City.CityGetCoeffsMap());
            drawer.SetCanvas(CtrlPicBx);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            MouseWheel += new MouseEventHandler(CtrlPicBx_MouseWheel);
        }

        private void CtrlPicBx_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                case MouseButtons.Right:
                    eOld = e;
                    drawing = true;
                    break;
                case MouseButtons.Middle:
                    drawer.SetNormalZoom();
                    break;
            }
        }
        private void CtrlPicBx_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawer.Move(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
            }
        }
        private void CtrlPicBx_MouseUp(object sender, MouseEventArgs e) => drawing = false;
        private void CtrlPicBx_MouseWheel(object sender, MouseEventArgs e) => drawer.Zoom(e.X, e.Y, e.Delta);

        protected override void OnPaint(PaintEventArgs e) => drawer.Draw();

        /// <summary>
        /// Костыль для Windows XP.
        /// </summary>
        private void CtrlPicBx_Click(object sender, EventArgs e) => CtrlPicBx.Focus();
    }
}
