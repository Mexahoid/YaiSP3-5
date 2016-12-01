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
    public partial class FormGraph : Form
    {
        private bool drawingGraph = false;
        private MainDrawingProcessor graphDrawer;
        private List<Tuple<AgencyHandler, StrategyHandler>> Agencies;

        private MouseEventArgs eOld;

        public FormGraph(List<Tuple<AgencyHandler, StrategyHandler>> Agencies)
        {
            this.Agencies = Agencies;
            InitializeComponent();
            int C = Agencies.Count;
            for (int i = 0; i < C; i++)
                CtrlLBAgencies.Items.Add(Agencies[i].Item1.ToString());
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            CtrlPicBxGraph.MouseWheel += new MouseEventHandler(CtrlPicBxGraph_MouseScroll);
        }

        private void CtrlPicBxGraph_MouseScroll(object sender, MouseEventArgs e)
        {
            if (graphDrawer != null)
            {
                graphDrawer.Zoom(e.X, e.Y, e.Delta);
                graphDrawer.Draw();
            }
        }
        private void CtrlPicBxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (graphDrawer != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        eOld = e;
                        drawingGraph = true;
                        break;
                    case MouseButtons.Middle:
                        graphDrawer.SetNormalZoom();
                        break;
                }
                graphDrawer.Draw();
            }
        }
        private void CtrlPicBxGraph_MouseUp(object sender, MouseEventArgs e)
        {
            drawingGraph = false;
        }
        private void CtrlPicBxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingGraph)
            {
                graphDrawer.Move(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
                graphDrawer.Draw();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (graphDrawer != null)
                graphDrawer.Draw();
        }

        /// <summary>
        /// Костыль для Windows XP.
        /// </summary>
        private void CtrlPicBxGraph_Click(object sender, EventArgs e)
        {
            CtrlPicBxGraph.Focus();
        }

        private void CtrlLBAgencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphDrawer = new MainDrawingProcessor();
            graphDrawer.AddDrawer(new GraphDrawer(Agencies[CtrlLBAgencies.SelectedIndex].Item1.AgencyGetSummary()));
            graphDrawer.SetCanvas(CtrlPicBxGraph);
            graphDrawer.Draw();
        }
    }
}
