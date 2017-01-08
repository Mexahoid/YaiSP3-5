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

        /// <summary>
        /// Флаг, зависящий от нажатия/подъема кнопки мыши на карте.
        /// </summary>
        private bool movingMap = false;

        /// <summary>
        /// Старые координаты мыши - для движения карты.
        /// </summary>
        private MouseEventArgs eOld;

        /// <summary>
        /// Главное хранилище информации и обработчиков.
        /// </summary>
        private DataHandler mainDataHandler;

        #endregion

        #region Методы

        #region Одиночные методы

        public FormMain()
        {
            InitializeComponent();
            mainDataHandler = new DataHandler();
            mainDataHandler.SetRedrawEvent(OnPaint);
            mainDataHandler.DrawerSetCanvas(CtrlPicBxMap);
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint, true);
            CtrlPicBxMap.MouseWheel += new MouseEventHandler(CtrlPicBxMap_MouseScroll);
            mainDataHandler.SetEventLink(AgencyDestroyEventHandler);
        }

        /// <summary>
        /// Изменяет скорость течения времени.
        /// </summary>
        private void CtrlTBSpeed_Scroll(object sender, EventArgs e)
        {
            CtrlTimer.Interval = CtrlTBSpeed.Value * 20;
        }

        /// <summary>
        /// Переопределяет метода перерисовки для инвалидации.
        /// </summary>
        /// <param name="e">Объект отрисовки.</param>
        protected override void OnPaint(PaintEventArgs e) => mainDataHandler.DrawerDraw();

        /// <summary>
        /// Костыль для Windows XP.
        /// </summary>
        private void CtrlPicBxMap_Click(object sender, EventArgs e) => CtrlPicBxMap.Focus();

        /// <summary>
        /// Загружает плагины.
        /// </summary>
        /// <param name="SelectPath">Путь папки загрузки.</param>
        private void LoadPlugins(string SelectPath)
        {
            string[] pluginFiles = Directory.GetFiles(SelectPath, "*.dll");
            mainDataHandler.TypesClear();

            foreach (string pluginPath in pluginFiles)
            {
                Type objType = null;
                try
                {
                    Assembly assembly = Assembly.LoadFrom(pluginPath);
                    if (assembly != null)
                    {
                        Type[] Temp = assembly.GetTypes();
                        objType = Temp[0];
                        if (objType.GetInterface("IStrategy") != null)
                            mainDataHandler.TypesAdd(objType);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        /// <summary>
        /// Обработчик события уничтожения агентства.
        /// </summary>
        /// <param name="name">Название уничтожаемого агентства.</param>
        private void AgencyDestroyEventHandler(string name)
        {
            CtrlTimer.Enabled = false;
            CtrlButTimerPause.Text = "Продолжить";
            MessageBox.Show("Агентство " + name + " было ликвидировано по причине банкротства.", "Беда!");
        }

        #endregion

        #region Методы мыши

        private void CtrlPicBxMap_MouseScroll(object sender, MouseEventArgs e) =>
            mainDataHandler.DrawerZoom(e.X, e.Y, e.Delta);
        private void CtrlPicBxMap_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                case MouseButtons.Right:
                    eOld = e;
                    movingMap = true;
                    break;
                case MouseButtons.Middle:
                    mainDataHandler.DrawerSetNormalZoom();
                    break;
            }
            mainDataHandler.DrawerDraw();
        }
        private void CtrlPicBxMap_MouseUp(object sender, MouseEventArgs e) =>
            movingMap = false;
        private void CtrlPicBxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (movingMap)
            {
                mainDataHandler.DrawerMove(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
                mainDataHandler.DrawerDraw();
            }
        }

        #endregion

        #region Методы кнопок выпадающего меню

        private void CtrlTSMIAgencyMenuClick(object sender, EventArgs e)
        {
            if (mainDataHandler.TypesNotExist())
                MessageBox.Show("Какие агентства без стратегий? Не забудь их загрузить.", "Неа, не пущу.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                FormAgency Af = new FormAgency(mainDataHandler.AgenciesGetLink(), mainDataHandler.TypesGetLink(),
                    mainDataHandler.CityGetLink().GetCityLink(), mainDataHandler.QueueGetLink(), mainDataHandler.DrawerGetLink());
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
            FormCity Cf = new FormCity(mainDataHandler.DrawerGetLink(), mainDataHandler.CityGetLink());
            if (Cf.ShowDialog() == DialogResult.OK)
            {
                CtrlChBIndCity.Checked = true;
                CtrlTSMIAgencyMenu.Enabled = true;
                if (CtrlChBIndAgen.Checked)
                    CtrlButTimerStart.Enabled = true;
            }
            else
                if (!CtrlChBIndCity.Checked)
                mainDataHandler.CityClear();
            mainDataHandler.DrawerSetCanvas(CtrlPicBxMap);
            CtrlPicBxMap.Invalidate();
        }
        private void CtrlTSMIProximityMapClick(object sender, EventArgs e)
        {
            FormProximity Pr = new FormProximity(mainDataHandler.CityGetLink());
            Pr.Show();
        }
        private void CtrlTSMIGraph_Click(object sender, EventArgs e)
        {
            FormGraph Gr = new FormGraph(mainDataHandler.AgenciesGetLink());
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
            CtrlLblDate.Text = mainDataHandler.DateGet();
            mainDataHandler.QueueNewClient(CtrlTBQueueQuantity.Value, CtrlTBQueueIntense.Value);
            CtrlTxbOrders.Text = mainDataHandler.QueueNames();
            mainDataHandler.AgenciesAction();
            mainDataHandler.DateNew();
            mainDataHandler.DrawerDraw();
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