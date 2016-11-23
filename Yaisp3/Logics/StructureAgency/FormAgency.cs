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
    public partial class FormAgency : Form
    {
        public FormAgency()
        {
            InitializeComponent();
        }

        private void CtrlButCreateClick(object sender, EventArgs e)
        {
            if (!MainUnitProcessor.AgencyCreate(CtrlTxbName.Text, 
                (int)CtrlNumDeposit.Value, 
                (int)CtrlNumBillboards.Value,
                (CtrlRadConserv.Checked ? 1 : CtrlRadNormal.Checked ? 0 : 2)
                ))
                MessageBox.Show("Вы ввели недопустимое значение в каком-то из полей. Проверьте правильность информации.", "Ошибка значений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                Close();
        }

        private void CtrlButEditClick(object sender, EventArgs e)
        {
            MainUnitProcessor.AgencyChangeData(CtrlTxbName.Text);
            Close();
        }

        private void FormAgency_Load(object sender, EventArgs e)
        {
            CtrlButEdit.Enabled = MainUnitProcessor.AgencyIsPresent();
            CtrlButCreate.Enabled = CtrlNumBillboards.Enabled = CtrlNumDeposit.Enabled = !MainUnitProcessor.AgencyIsPresent();
            if (MainUnitProcessor.AgencyIsPresent())
            {
                Tuple<string, int, int> T =
                  MainUnitProcessor.AgencyGetData();
                CtrlNumBillboards.Value = T.Item3;
                CtrlNumDeposit.Value = T.Item2;
                CtrlTxbName.Text = T.Item1;

                switch (MainUnitProcessor.StrategyGetType())
                {
                    case Strategy.StrategyType.Conservative:
                        CtrlRadConserv.Checked = true;
                        break;
                    case Strategy.StrategyType.Normal:
                        CtrlRadNormal.Checked = true;
                        break;
                    case Strategy.StrategyType.Aggressive:
                        CtrlRadAggro.Checked = true;
                        break;
                }
            }
            else
            {
                CtrlTxbName.Text = "ООО \"Вектор\"";
                CtrlRadConserv.Checked = true;
            }
        }

        private void ChangeStrategyEvent(object sender, EventArgs e)
        {
            MainUnitProcessor.StrategyChange((Strategy.StrategyType)(Convert.ToByte((sender as RadioButton).Tag)));
        }
    }
}
