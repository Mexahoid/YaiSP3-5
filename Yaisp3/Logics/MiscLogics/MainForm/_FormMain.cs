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
//Лимит денег ввести

При старте процесса появляются клиенты (физические, юридические лица, госструктуры), которые 
заказывают размещение своей рекламы на баннерах организации. 
//Очередь структур клиентов

Госструктуры могут иметь приоритет и "заказывать" социальную рекламу, за которую они не платят.
//С приоритетом

Учесть, что обслуживание баннеров, содержание штата фирмы, постройка новых
баннеров требует вложений денежных средств со счета организации.  
//Каждый баннер == затраты
 * На каждый баннер добавляется N человек. Стройка за 1 тик.

Реализовать различные стратегии поведения фирмы (агрессивная -- частое строительство новых баннеров,
умеренная -- строительство баннеров при большом росте счета, консервативная -- крайне редкое 
строительство новых баннеров).   
//Радиобатоны

На форме показать размещение баннеров в городе, очередь клиентов, пожелания клиентов,
динамику поведения счета.  
//Графики посуточно
 */
namespace Yaisp3
{
    public partial class _FormMain : Form
    {
        private bool drawing = false;
        private MouseEventArgs eOld;
        private MainFormLogicClass mainLogic;

        public _FormMain()
        {
            MouseWheel += new MouseEventHandler(_ctrlPicBxMap_MouseScroll);
            InitializeComponent();
        }

        private void _ctrlPicBxMap_MouseScroll(object sender, MouseEventArgs e)
        {
            if (mainLogic != null)
                mainLogic.ZoomMap(e.X, e.Y, e.Delta);
        }
        private void _ctrlPicBxMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (mainLogic != null)
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        eOld = e;
                        drawing = true;
                        break;
                    case MouseButtons.Middle:
                        mainLogic.SetNormalZoomMap();
                        break;
                }
        }
        private void _ctrlPicBxMap_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }
        private void _ctrlPicBxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                mainLogic.MoveMap(e.X, e.Y, eOld.X, eOld.Y);
                eOld = e;
                MainDrawMethod();
            }
        }

        private void MainDrawMethod()
        {
            if (MainUnitProcessor.AgencyIsPresent())
            {
                //Что-то делать
            }
        }
        private void _ctrlTSMIAgencyMenu_Click(object sender, EventArgs e)
        {
            if (Program.formCreateAgency.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _ctrlChBIndAgen.Checked = true;
                if (_ctrlChBIndCity.Checked)
                    _ctrlButTimerStart.Enabled = true;
            }
        }
        private void _ctrlTSMIAgencyDelete_Click(object sender, EventArgs e)
        {
            MainUnitProcessor.AgencyDestroy();
            _ctrlChBIndAgen.Checked = false;
        }
        private void _ctrlTSMICreateCity_Click(object sender, EventArgs e)
        {
            if (Program.formCity.ShowDialog() == DialogResult.OK)
            {
                mainLogic = new MainFormLogicClass(_ctrlPicBxMap, _ctrlPicBxGraph);
                _ctrlChBIndCity.Checked = true;
                if (_ctrlChBIndAgen.Checked)
                    _ctrlButTimerStart.Enabled = true;
            }
        }

        private void _ctrlTimer_Tick(object sender, EventArgs e)
        {
            _ctrlLblDate.Text = "Дата: " + MainUnitProcessor.DateGetAsString();
            MainUnitProcessor.DateNewDay();
        }

        private void _ctrlButTimerStart_Click(object sender, EventArgs e)
        {
            MainUnitProcessor.MainReset();
            _ctrlTimer.Enabled = true;
            _ctrlButTimerPause.Enabled = true;
        }

        private void _ctrlButTimerPause_Click(object sender, EventArgs e)
        {
            _ctrlTimer.Enabled = !_ctrlTimer.Enabled;
            if (_ctrlTimer.Enabled)
                _ctrlButTimerPause.Text = "Пауза";
            else
                _ctrlButTimerPause.Text = "Продолжить";
        }

        private void _ctrlTBSpeed_Scroll(object sender, EventArgs e)
        {
            _ctrlTimer.Interval = _ctrlTBSpeed.Value * 10;
        }

        private void CtrlChBProximity_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CtrlTSMIProximityMap_Click(object sender, EventArgs e)
        {
            Program.formProximity.ShowDialog();
        }
    }
}
