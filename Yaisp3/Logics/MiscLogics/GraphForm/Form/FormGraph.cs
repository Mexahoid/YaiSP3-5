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
        private GraphDrawingClass graphDrawer;
        private MouseEventArgs eOld;

        public FormGraph(List<Tuple<double, double>> graphPoints)
        {
            InitializeComponent();
            graphDrawer = new GraphDrawingClass(CtrlPicBxGraph, graphPoints);
            CtrlPicBxGraph.MouseWheel += new MouseEventHandler(CtrlPicBxGraph_MouseScroll);
            graphDrawer.DrawGraph();
        }

        private void CtrlPicBxGraph_MouseScroll(object sender, MouseEventArgs e)
        {
            if (graphDrawer != null)
            {
                graphDrawer.Zoom(e.X, e.Y, e.Delta);
                graphDrawer.DrawGraph();
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
                graphDrawer.DrawGraph();
            }
        }
        private void CtrlPicBxGraph_MouseUp(object sender, MouseEventArgs e)
        {
            drawingGraph = false;
            graphDrawer.DrawGraph();
        }
        private void CtrlPicBxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingGraph)
            {
                graphDrawer.Move(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
                graphDrawer.DrawGraph();
            }
        }
    }
}
