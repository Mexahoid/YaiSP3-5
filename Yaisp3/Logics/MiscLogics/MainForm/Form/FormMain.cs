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
    public partial class FormMain : Form
    {
        private bool drawingMap = false;
        private MouseEventArgs eOld;
        private MapLogicsClass mainLogic;
        private MainDrawingProcessor drawers;

        

        public FormMain()
        {
            InitializeComponent();
            drawers = new MainDrawingProcessor();
            drawers.SetCanvas(CtrlPicBxMap);
            CtrlPicBxMap.MouseWheel += new MouseEventHandler(CtrlPicBxMap_MouseScroll);
        }

        private void CtrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
        {
            if (mainLogic != null)
                mainLogic.ZoomImage(e.X, e.Y, e.Delta);
        }

        private void CtrlPicBxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mainLogic != null)
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        eOld = e;
                        drawingMap = true;
                        break;
                    case MouseButtons.Middle:
                        mainLogic.SetNormalZoom();
                        break;
                }
        }
        private void CtrlPicBxMap_MouseUp(object sender, MouseEventArgs e)
        {
            drawingMap = false;
        }
        private void CtrlPicBxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingMap)
            {
                mainLogic.MoveImage(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
            }
        }

        private void CtrlTSMIAgencyMenuClick(object sender, EventArgs e)
        {
            if (Program.formCreateAgency.ShowDialog() == DialogResult.OK)
            {
                CtrlChBIndAgen.Checked = true;
                if (CtrlChBIndCity.Checked)
                    CtrlButTimerStart.Enabled = true;
            }
        }
        private void CtrlTSMIAgencyDeleteClick(object sender, EventArgs e)
        {
            MainUnitProcessor.AgencyDestroy();
            CtrlChBIndAgen.Checked = false;
        }
        private void CtrlTSMICreateCityClick(object sender, EventArgs e)
        {

            if (Program.formCity.ShowDialog() == DialogResult.OK)
            {
                mainLogic = new MapLogicsClass(CtrlPicBxMap);
                CtrlChBIndCity.Checked = true;
                CtrlTSMIAgencyDelete.Enabled = CtrlTSMIAgencyMenu.Enabled = true;
                if (CtrlChBIndAgen.Checked)
                    CtrlButTimerStart.Enabled = true;
            }
        }

        private void CtrlTimer_Tick(object sender, EventArgs e)
        {
            CtrlLblDate.Text = "Дата: " + MainUnitProcessor.DateGetAsString();
            MainUnitProcessor.QueueAddRand(CtrlTBQueueQuantity.Value, CtrlTBQueueIntense.Value);
            CtrlTxbOrders.Text = MainUnitProcessor.QueueGetText();
            MainUnitProcessor.PassDay();
            mainLogic.MoveImage(0, 0, 0, 0);
        }

        private void CtrlButTimerStartClick(object sender, EventArgs e)
        {
            CtrlButTimerStart.Enabled = false;
            MainUnitProcessor.QueueCreate();
            TextStorageClass.ParseTextData();
            CtrlTimer.Enabled = true;
            CtrlButTimerPause.Enabled = true;
        }

        private void CtrlButTimerPauseClick(object sender, EventArgs e)
        {
            CtrlTimer.Enabled = !CtrlTimer.Enabled;
            if (CtrlTimer.Enabled)
                CtrlButTimerPause.Text = "Пауза";
            else
                CtrlButTimerPause.Text = "Продолжить";
        }

        private void CtrlTBSpeed_Scroll(object sender, EventArgs e)
        {
            CtrlTimer.Interval = CtrlTBSpeed.Value * 20;
        }

        private void CtrlTSMIProximityMapClick(object sender, EventArgs e)
        {
            FormProximity Pr = new FormProximity(drawers);
            Pr.Show();
        }

        private void CtrlTSMIGraph_Click(object sender, EventArgs e)
        {
            FormGraph Gr = new FormGraph(MainUnitProcessor.AgencyGetSummary());
            Gr.Show();
        }

        private void CtrlTSMIDrop_Click(object sender, EventArgs e)
        {
            if (CtrlTimer.Enabled)
                CtrlButTimerPause.Text = "Продолжить";
            CtrlTimer.Enabled = false;
        }

        private void CtrlPicBxMap_Click(object sender, EventArgs e)
        {
            CtrlPicBxMap.Focus();
        }

        private void CtrlPicBxMap_Paint(object sender, PaintEventArgs e)
        {
            if (mainLogic != null)
            mainLogic.MoveImage(0, 0, 0, 0);
        }
    }
}
