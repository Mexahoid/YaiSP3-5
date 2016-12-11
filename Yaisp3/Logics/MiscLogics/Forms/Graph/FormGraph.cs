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
    public partial class FormGraph : Form
    {
        private bool drawingGraph = false;
        private MainDrawingProcessor graphDrawer;
        private List<IDrawable> Drawers;
        private List<Tuple<AgencyHandler, StrategyHandler>> Agencies;

        private MouseEventArgs eOld;

        public FormGraph(List<Tuple<AgencyHandler, StrategyHandler>> Agencies)
        {
            this.Agencies = Agencies;
            InitializeComponent();
            InitData();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            CtrlPicBxGraph.MouseWheel += new MouseEventHandler(CtrlPicBxGraph_MouseScroll);
            CtrlPicBxGraph.Invalidate();
        }

        private void InitData()
        {
            graphDrawer = new MainDrawingProcessor();
            Drawers = new List<IDrawable>();
            int C = Agencies.Count;
            List<string> Names = new List<string>();
            List<int> Hashes = new List<int>();
            string Name;
            for (int i = 0; i < C; i++)
            {
                Name = Agencies[i].Item1.ToString();
                Names.Add(Name);
                Hashes.Add(Name.GetHashCode() + MiscellaneousLogics.MainGetRandomValue(-1000, 1000)
                    + MiscellaneousLogics.MainGetRandomValue(-100000, 100000)
                    + MiscellaneousLogics.MainGetRandomValue(-10000000, 10000000));
            }
            graphDrawer.AddDrawer(new GraphLegendDrawer(Names, Hashes));

            for (int i = 0; i < C; i++)
                graphDrawer.AddDrawer(new GraphDrawer(Agencies[i].Item1.AgencyGetSummary(), Hashes[i]));
            graphDrawer.SetCanvas(CtrlPicBxGraph);
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
    }
}
