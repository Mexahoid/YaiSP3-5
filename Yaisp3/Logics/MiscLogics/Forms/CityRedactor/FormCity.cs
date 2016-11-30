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
    public partial class FormCity : Form
    {
        private bool moving = false;
        private bool drawing = false;
        private bool placed;
        private MouseEventArgs e0;

        public MainDrawingProcessor Drawers;
        public CityHandler CityLink;
        private HoveringDrawer DrawableObject;

        public FormCity(MainDrawingProcessor OrigDrawers, CityHandler OrigCity)
        {
            InitializeComponent();
            Drawers = OrigDrawers;
            CityLink = OrigCity;
            MouseWheel += new MouseEventHandler(CtrlPicBxMap_MouseScroll);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            placed = true;
        }

        private void CtrlButMarkClick(object sender, EventArgs e)
        {
            CityLink = new CityHandler(CtrlTxbCityName.Text, (int)(CtrlNumCityHeight.Value),
              (int)(CtrlNumCityWidth.Value));
            Drawers = new MainDrawingProcessor();
            Drawers.AddDrawer(new GridDrawer(Tuple.Create((int)(CtrlNumCityWidth.Value),
                (int)(CtrlNumCityHeight.Value))));
            Drawers.SetCanvas(CtrlPicBxCity);
            CtrlButHouse.Enabled = CtrlButReady.Enabled = true;
            Drawers.Draw();
        }

        private void CtrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
        {
            Drawers.Zoom(e.X, e.Y, e.Delta);
            Drawers.Draw();
        }
        private void CtrlPicBxCity_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (drawing)
                    {
                        int Row, Col;
                        if (DrawableObject.FindPlaceInMatrix(out Row, out Col))
                        {
                            DrawableObject = null;
                            Drawers.SetLastDrawer(CityLink.CityHousePlace(Row, Col,
                                (int)(CtrlNumHouseWidth.Value), (int)(CtrlNumHouseHeigth.Value)));
                            Drawers.CheckList();
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
            Drawers.Draw();
        }
        private void CtrlPicBxCity_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }
        private void CtrlPicBxCity_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                Drawers.Move(e.X, e.Y, e0.X, e0.Y);
                e0 = e;
            }
            if (drawing)
                DrawableObject.MoveTo(e.X, e.Y);
            Drawers.Draw();
        }

        private void CtrlButHouseClick(object sender, EventArgs e)
        {
            if (placed)
            {
                DrawableObject = new HoveringDrawer(CityLink.CityGetSize(), (int)CtrlNumHouseWidth.Value, (int)CtrlNumHouseHeigth.Value);
                drawing = true;
                Drawers.AddDrawer(DrawableObject);
                placed = false;
                Drawers.Draw();
            }
            else
            {
                DrawableObject = new HoveringDrawer(CityLink.CityGetSize(), (int)CtrlNumHouseWidth.Value, (int)CtrlNumHouseHeigth.Value);
                Drawers.Draw();
            }
        }

        private void CtrlButReadyClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Костыль для Windows XP.
        /// </summary>
        private void CtrlPicBxCity_Click(object sender, EventArgs e)
        {
            CtrlPicBxCity.Focus();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Drawers.Draw();
        }
    }
}
