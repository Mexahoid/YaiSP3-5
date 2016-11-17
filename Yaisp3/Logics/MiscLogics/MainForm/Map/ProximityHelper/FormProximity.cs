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
        private ProximityLogicsClass proximityLogic;
        private bool loaded;
        private bool drawing = false;

        public FormProximity()
        {
            InitializeComponent();
            MouseWheel += new MouseEventHandler(CtrlPicBx_MouseWheel);
            loaded = false;
        }

        private void CtrlPicBx_MouseDown(object sender, MouseEventArgs e)
        {
            if (proximityLogic != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        eOld = e;
                        drawing = true;
                        break;
                    case MouseButtons.Middle:
                        proximityLogic.SetNormalZoom();
                        break;
                }
            }
        }

        private void CtrlPicBx_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                proximityLogic.MoveImage(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
            }
        }

        private void CtrlPicBx_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }
        private void CtrlPicBx_MouseWheel(object sender, MouseEventArgs e)
        {
            if (proximityLogic != null)
                proximityLogic.ZoomImage(e.X, e.Y, e.Delta);
        }

        private void FormProximity_Load(object sender, EventArgs e)
        {
            if (MainUnitProcessor.CityIsPresent())
            {
                if (!loaded)
                {
                    proximityLogic = new ProximityLogicsClass(CtrlPicBx);
                    loaded = true;
                }
            }
        }
    }
}
