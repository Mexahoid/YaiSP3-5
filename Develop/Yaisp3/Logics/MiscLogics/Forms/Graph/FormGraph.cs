using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencySimulator.Interfaces;

namespace AgencySimulator
{
    public partial class FormGraph : Form
    {
        #region Поля

        private bool drawingGraph = false;
        private MainDrawingProcessor graphDrawer;
        private List<IDrawable> Drawers;
        private List<(AgencyHandler agency, IStrategy strategy)> Agencies;

        private MouseEventArgs eOld;

        #endregion

        #region Методы

        public FormGraph(List<(AgencyHandler agency, IStrategy strategy)> Agencies)
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
            graphDrawer.SetRedrawEvent(OnPaint);
            Drawers = new List<IDrawable>();
            int C = Agencies.Count;
            List<string> Names = new List<string>();
            List<long> Hashes = new List<long>();
            string Name;
            int Temp = 0;
            for (int i = 0; i < C; i++)
            {
                Name = Agencies[i].Item1.ToString();
                Names.Add(Name);
                Temp = Math.Abs(Name.GetHashCode() + MiscellaneousLogics.MainGetRandomValue(-1_000, 1_000)
                    + MiscellaneousLogics.MainGetRandomValue(-100_000, 100_000)
                    + MiscellaneousLogics.MainGetRandomValue(-10_000_000, 10_000_000));
                if (Temp < 10_000_000)
                    Temp += MiscellaneousLogics.MainGetRandomValue(10, 99) * 1_000_000;
                Hashes.Add(Temp);
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

        /// <summary>
        /// Вызывает метод отрисовки на графике.
        /// </summary>
        /// <param name="e">Графика отрисовки.</param>
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

        #endregion
    }
}
