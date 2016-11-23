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
        private GraphLogicsClass graphLogic;
        private MouseEventArgs eOld;
        private bool loaded;

        public FormGraph()
        {
            InitializeComponent();
            CtrlPicBxGraph.MouseWheel += new MouseEventHandler(CtrlPicBxGraph_MouseScroll);
            loaded = false;
        }
        private void CtrlPicBxGraph_MouseScroll(object sender, MouseEventArgs e)
        {
            if (graphLogic != null)
                graphLogic.ZoomImage(e.X, e.Y, e.Delta);
        }
        private void CtrlPicBxGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (graphLogic != null)
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        eOld = e;
                        drawingGraph = true;
                        break;
                    case MouseButtons.Middle:
                        graphLogic.SetNormalZoom();
                        break;
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
                graphLogic.MoveImage(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
            }
        }

        private void FormGraph_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (graphLogic != null)
                graphLogic.DestroyCreator();
            graphLogic = null;
            loaded = false;
        }

        private void FormGraph_Load(object sender, EventArgs e)
        {
            if (MainUnitProcessor.AgencyIsPresent())
            {
                if (!loaded)
                {
                    graphLogic = new GraphLogicsClass(CtrlPicBxGraph, MainUnitProcessor.AgencyGetSummary());

                    loaded = true;
                }
            }
        }
    }
}
