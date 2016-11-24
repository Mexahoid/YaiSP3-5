using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/*8. Баннерное рекламное агенство.
В городе баннерное агенство может строить свои рекламные щиты и размещать на них рекламу.
//Ввести словарь для года? Неа

Показать процесс развития рекламного агенства с учетом движения денежных средств. Изначально 
у рекламного агенства есть несколько рекламных щитов и некая сумма денег на счету.  
//Лимит денег ввести Ееее, безопаснееее

При старте процесса появляются клиенты (физические, юридические лица, госструктуры), которые 
заказывают размещение своей рекламы на баннерах организации. 
//Очередь структур клиентов   Готово

Госструктуры могут иметь приоритет и "заказывать" социальную рекламу, за которую они не платят.
//С приоритетом     Готово

Учесть, что обслуживание баннеров, содержание штата фирмы, постройка новых
баннеров требует вложений денежных средств со счета организации.  
//Каждый баннер == затраты
 * На каждый баннер добавляется N человек. Стройка за 1 тик.     Hit

Реализовать различные стратегии поведения фирмы (агрессивная -- частое строительство новых баннеров,
умеренная -- строительство баннеров при большом росте счета, консервативная -- крайне редкое 
строительство новых баннеров).    Осталось это
//Радиобатоны

На форме показать размещение баннеров в городе, очередь клиентов, пожелания клиентов,
динамику поведения счета.      Еее, готвоо
//Графики посуточно
 */
namespace Yaisp3
{
    public partial class FormMain : Form
    {
        private bool drawingMap = false;
        private MouseEventArgs eOld;
        private MapLogicsClass mainLogic;

        public FormMain()
        {
            InitializeComponent();
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
            //MainUnitProcessor.MainReset();
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
            Program.formProximity.ShowDialog();
        }

        private void CtrlTSMIGraph_Click(object sender, EventArgs e)
        {
            Program.formGraph.ShowDialog();
        }

        private void CtrlTSMIDrop_Click(object sender, EventArgs e)
        {
            CtrlTimer.Enabled = false;
            CtrlButTimerPause.Text = "Продолжить";
        }
    }
}
