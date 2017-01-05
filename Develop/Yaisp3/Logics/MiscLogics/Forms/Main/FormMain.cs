using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using AgencySimulator.Interfaces;

namespace AgencySimulator
{
    public partial class FormMain : Form
    {
        #region Поля

        private bool drawingMap = false;
        private MouseEventArgs eOld;
        private MainDrawingProcessor drawers;

        private List<Tuple<AgencyHandler, IStrategy>> Agencies;

        private CityHandler City;
        private DateHandler Date;
        private QueueHandler Queue;

        private List<Type> StrategiesTypes;

        #endregion

        #region Методы

        #region Одиночные методы

        public FormMain()
        {
            InitializeComponent();
            Agencies = new List<Tuple<AgencyHandler, IStrategy>>();
            drawers = new MainDrawingProcessor();
            drawers.SetCanvas(CtrlPicBxMap);
            Date = new DateHandler();
            City = new CityHandler();
            Queue = new QueueHandler();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            CtrlPicBxMap.MouseWheel += new MouseEventHandler(CtrlPicBxMap_MouseScroll);

            (int, int) Tally()
            {
                return (0, 0);
            }
        }

        private void CtrlTBSpeed_Scroll(object sender, EventArgs e)
        {
            CtrlTimer.Interval = CtrlTBSpeed.Value * 20;

        }

        /// <summary>
        /// Переопределяет метода перерисовки для инвалидации.
        /// </summary>
        /// <param name="e">Объект отрисовки.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            drawers.Draw();
        }

        /// <summary>
        /// Костыль для Windows XP.
        /// </summary>
        private void CtrlPicBxMap_Click(object sender, EventArgs e)
        {
            CtrlPicBxMap.Focus();
        }

        /// <summary>
        /// Загружает плагины.
        /// </summary>
        /// <param name="SelectPath">Путь папки загрузки.</param>
        private void LoadPlugins(string SelectPath)
        {
            string[] pluginFiles = Directory.GetFiles(SelectPath, "*.dll");
            StrategiesTypes = new List<Type>();

            foreach (string pluginPath in pluginFiles)
            {
                Type objType = null;
                try
                {
                    Assembly assembly = Assembly.LoadFrom(pluginPath);
                    if (assembly != null)
                    {
                        objType = assembly.GetTypes()[0];
                        if (objType.GetInterface("IStrategy") != null)
                            StrategiesTypes.Add(objType);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        #endregion

        #region Методы мыши

        private void CtrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
        {
            drawers.Zoom(e.X, e.Y, e.Delta);
            drawers.Draw();
        }
        private void CtrlPicBxMap_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                case MouseButtons.Right:
                    eOld = e;
                    drawingMap = true;
                    break;
                case MouseButtons.Middle:
                    drawers.SetNormalZoom();
                    break;
            }
            drawers.Draw();
        }
        private void CtrlPicBxMap_MouseUp(object sender, MouseEventArgs e)
        {
            drawingMap = false;
        }
        private void CtrlPicBxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawingMap)
            {
                drawers.Move(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
                drawers.Draw();
            }
        }

        #endregion

        #region Методы кнопок выпадающего меню

        private void CtrlTSMIAgencyMenuClick(object sender, EventArgs e)
        {
            if (StrategiesTypes == null || StrategiesTypes.Count == 0)
            {
                MessageBox.Show("Какие агентства без стратегий? Не забудь их загрузить.", "Неа, не пущу.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                FormAgency Af = new FormAgency(Agencies, StrategiesTypes,
                    City.GetCityLink(), Queue.GetQueueLink(), drawers);
                if (Af.ShowDialog() == DialogResult.OK)
                {
                    CtrlChBIndAgen.Checked = true;
                    if (CtrlChBIndCity.Checked)
                        CtrlButTimerStart.Enabled = true;
                }
            }
        }
        private void CtrlTSMICreateCityClick(object sender, EventArgs e)
        {
            FormCity Cf = new FormCity(drawers, City);
            if (Cf.ShowDialog() == DialogResult.OK)
            {
                CtrlChBIndCity.Checked = true;
                CtrlTSMIAgencyMenu.Enabled = true;
                if (CtrlChBIndAgen.Checked)
                    CtrlButTimerStart.Enabled = true;
            }
            else
                if (!CtrlChBIndCity.Checked)
                City = null;
            drawers.SetCanvas(CtrlPicBxMap);
            CtrlPicBxMap.Invalidate();
        }
        private void CtrlTSMIProximityMapClick(object sender, EventArgs e)
        {
            FormProximity Pr = new FormProximity(City);
            Pr.Show();
        }
        private void CtrlTSMIGraph_Click(object sender, EventArgs e)
        {
            FormGraph Gr = new FormGraph(Agencies);
            Gr.Show();
        }
        private void CtrlTSMIDrop_Click(object sender, EventArgs e)
        {
            if (CtrlTimer.Enabled)
                CtrlButTimerPause.Text = "Продолжить";
            CtrlTimer.Enabled = false;
        }
        private void CtrlTSMILoadPlugins_Click(object sender, EventArgs e)
        {
            if (CtrlFBD.ShowDialog() == DialogResult.OK)
                LoadPlugins(CtrlFBD.SelectedPath);
        }

        #endregion

        #region Методы таймера

        private void CtrlTimer_Tick(object sender, EventArgs e)
        {
            CtrlLblDate.Text = "Дата: " + Date.DateGetAsString();
            Queue.QueueAddRand(CtrlTBQueueQuantity.Value, CtrlTBQueueIntense.Value);
            CtrlTxbOrders.Text = Queue.ToString();
            int C = Agencies.Count;
            for (int i = 0; i < C; i++)
                if (!Agencies[i].Item2.Action(Agencies[i].Item1.GetAgencyLink()))
                {
                    CtrlTimer.Enabled = false;
                    CtrlButTimerPause.Text = "Продолжить";
                    MessageBox.Show("Агентство " + Agencies[i].Item1.ToString() + " было ликвидировано по причине банкротства.", "Беда!");
                    Agencies[i].Item1.AgencyDestroy();
                    Agencies.RemoveAt(i--);
                    C--;
                }
            Date.DateNewDay();
            drawers.Draw();
        }
        private void CtrlButTimerStartClick(object sender, EventArgs e)
        {
            CtrlButTimerStart.Enabled = false;
            CtrlTSMIGraph.Enabled = true;
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

        #endregion


        #endregion
    }
}