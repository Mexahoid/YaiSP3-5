using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yaisp3
{
    public partial class FormProximity : Form
    {
        private MouseEventArgs eOld;
        private MapDrawingClass proximityDrawer;
        private bool loaded;
        private bool drawing = false;

        public FormProximity(MainDrawingProcessor Drawing)
        {
            InitializeComponent();
            MouseWheel += new MouseEventHandler(CtrlPicBx_MouseWheel);
            loaded = false;
        }

        private void CtrlPicBx_MouseDown(object sender, MouseEventArgs e)
        {
            if (proximityDrawer != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        eOld = e;
                        drawing = true;
                        break;
                    case MouseButtons.Middle:
                        proximityDrawer.SetNormalZoom();
                        break;
                }
            }
        }
        private void CtrlPicBx_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                proximityDrawer.Move(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
            }
        }
        private void CtrlPicBx_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }
        private void CtrlPicBx_MouseWheel(object sender, MouseEventArgs e)
        {
            if (proximityDrawer != null)
                proximityDrawer.Zoom(e.X, e.Y, e.Delta);
        }
    }
}
