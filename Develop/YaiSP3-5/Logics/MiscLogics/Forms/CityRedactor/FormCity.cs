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
    public partial class FormCity : Form
    {
        private bool moving = false;
        private bool drawing = false;
        private bool placed;
        private MouseEventArgs e0;

        private MainDrawingProcessor Drawers;
        private CityHandler CityLink;

        public FormCity(MainDrawingProcessor OrigDrawers, CityHandler OrigCity)
        {
            InitializeComponent();
            Drawers = OrigDrawers;
            CityLink = OrigCity;
            MouseWheel += new MouseEventHandler(CtrlPicBxMap_MouseScroll);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            Drawers.SetRedrawEvent(OnPaint);
            placed = true;
        }

        private void CtrlPicBxMap_MouseScroll(object sender, MouseEventArgs e) => Drawers.Zoom(e.X, e.Y, e.Delta);
        private void CtrlPicBxCity_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (drawing)
                    {
                        if (Drawers.SetLastDrawer(CityLink,
                                (int)(CtrlNumHouseWidth.Value), (int)(CtrlNumHouseHeigth.Value)))
                        {
                            placed = true;
                            drawing = false;
                        }
                    }
                    else
                    {
                        moving = true;
                        e0 = e;
                    }
                    break;
                case MouseButtons.Right:
                    moving = true;
                    e0 = e;
                    break;
                case MouseButtons.Middle:
                    Drawers.SetNormalZoom();
                    break;
            }
        }
        private void CtrlPicBxCity_MouseUp(object sender, MouseEventArgs e) => moving = false;
        private void CtrlPicBxCity_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Drawers.Move(e.X, e.Y, e0.X, e0.Y);
                e0 = e;
            }
            if (drawing)
                Drawers.MoveHovering(e.X, e.Y);
        }

        private void CtrlButMarkClick(object sender, EventArgs e)
        {
            CityLink.CreateCity(CtrlTxbCityName.Text, (int)(CtrlNumCityHeight.Value),
              (int)(CtrlNumCityWidth.Value));
            Drawers.CleanDrawers();
            Drawers.AddDrawer(new GridDrawer(((int)(CtrlNumCityWidth.Value),
                (int)(CtrlNumCityHeight.Value))));
            Drawers.SetCanvas(CtrlPicBxCity);
            CtrlButHouse.Enabled = CtrlButReady.Enabled = true;
        }
        private void CtrlButHouseClick(object sender, EventArgs e)
        {
            if (placed)
            {
                drawing = true;
                Drawers.AddDrawer(new HoveringDrawer(CityLink.CityGetSize(),
                    (int)CtrlNumHouseWidth.Value, (int)CtrlNumHouseHeigth.Value));
                placed = false;
            }
        }
        private void CtrlButReadyClick(object sender, EventArgs e) => Close();

        /// <summary>
        /// Костыль для Windows XP.
        /// </summary>
        private void CtrlPicBxCity_Click(object sender, EventArgs e) => CtrlPicBxCity.Focus();
        protected override void OnPaint(PaintEventArgs e) => Drawers.Draw();
    }
}
