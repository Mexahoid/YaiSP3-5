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
        private bool loaded = true;
        private MouseEventArgs e0;
        private CityRedactorLogicsClass CityCreationKit;

        public FormCity()
        {
            InitializeComponent();
            MouseWheel += new MouseEventHandler(CtrlPicBxMap_MouseScroll);
        }
        private void CtrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
        {
            if (CityCreationKit != null)
                CityCreationKit.ZoomImage(e.X, e.Y, e.Delta);
        }

        private void CtrlButMarkClick(object sender, EventArgs e)
        {
            MainUnitProcessor.CityCreate(CtrlTxbCityName.Text, (int)(CtrlNumCityHeight.Value),
              (int)(CtrlNumCityWidth.Value));

            CityCreationKit = new CityRedactorLogicsClass(CtrlPicBxCity);
            CtrlButSave.Enabled = true;
        }

        private void CtrlPicBxCity_MouseDown(object sender, MouseEventArgs e)
        {
            if (CityCreationKit != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        if (drawing)
                        {
                            CityCreationKit.AddElementToMatrix(e.X, e.Y,
                              (int)(CtrlNumHouseWidth.Value), (int)(CtrlNumHouseHeigth.Value));
                            drawing = false;
                        }
                        break;
                    case MouseButtons.Right:
                        moving = true;
                        e0 = e;
                        break;
                    case MouseButtons.Middle:
                        CityCreationKit.SetNormalZoom();
                        break;
                }
            }
        }
        private void CtrlPicBxCity_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }
        private void CtrlPicBxCity_MouseMove(object sender, MouseEventArgs e)
        {
            if (CityCreationKit != null)
            {
                if (moving)
                {
                    CityCreationKit.MoveImage(e.X, e.Y, e0.X, e0.Y);
                    e0 = e;
                }
                if (drawing)
                    CityCreationKit.DrawCurrentObject(e.X, e.Y, (int)CtrlNumHouseWidth.Value, (int)CtrlNumHouseHeigth.Value);
            }
        }

        private void CtrlButHouseClick(object sender, EventArgs e)
        {
            drawing = true;
        }
        private void CtrlResetClick(object sender, EventArgs e)
        {
            CityCreationKit.DestroyCreator();
        }
        private void CtrlButReadyClick(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCity_Load(object sender, EventArgs e)
        {
            if (MainUnitProcessor.CityIsPresent())
            {
                if (!loaded)
                {
                    CityCreationKit = new CityRedactorLogicsClass(CtrlPicBxCity);
                    loaded = true;
                }
                CtrlButSave.Enabled = true;
            }
        }

        private void CtrlButSaveClick(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                {
                    sw.Write(CityCreationKit.Save());
                    sw.Close();
                }
        }
        private void CtrlButLoadClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName))
                {
                    //CityCreationKit = new CityRedactorLogicsClass(CtrlPicBxCity, sr.ReadToEnd());
                    CtrlButSave.Enabled = true;
                    sr.Close();
                }
        }

        private void FormCity_FormClosed(object sender, FormClosedEventArgs e)
        {
            CityCreationKit.DestroyCreator();
            CityCreationKit = null;
            loaded = false;
        }
    }
}
