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
        public AgencyHandler AgencyLink;
        public StrategyHandler StrategyLink;
        private TemplateStrategy.StrategyType Strategy = TemplateStrategy.StrategyType.Normal;

        public FormAgency(AgencyHandler AgencyOrig, StrategyHandler StrategyOrig)
        {
            AgencyLink = AgencyOrig;
            StrategyLink = StrategyOrig;
            InitializeComponent();
            if (StrategyLink != null)
            {
                Strategy = StrategyLink.StrategyGetType();
                switch (Strategy)
                {
                    case TemplateStrategy.StrategyType.Normal:
                        CtrlRadNormal.Checked = true;
                        break;
                    case TemplateStrategy.StrategyType.Conservative:
                        CtrlRadConserv.Checked = true;
                        break;
                    case TemplateStrategy.StrategyType.Aggressive:
                        CtrlRadAggro.Checked = true;
                        break;
                }
            }
            if (AgencyLink != null)
            {
                CtrlButCreate.Enabled = CtrlNumBillboards.Enabled = CtrlNumDeposit.Enabled = false;
                CtrlButEdit.Enabled = true;
                Tuple<string, int, int> T = AgencyLink.AgencyGetData();
                CtrlTxbName.Text = T.Item1;
                CtrlNumDeposit.Value = T.Item2;
                CtrlNumBillboards.Value = T.Item3;
            }
        }
        

        private void CtrlButCreateClick(object sender, EventArgs e)
        {
            if (AgencyLink == null)
                AgencyLink = new AgencyHandler();
            if (!AgencyLink.AgencyCreate(CtrlTxbName.Text,
                (int)CtrlNumDeposit.Value,
                (int)CtrlNumBillboards.Value))
                MessageBox.Show("Вы ввели недопустимое значение в каком-то из полей. Проверьте правильность информации.", "Ошибка значений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                StrategyLink = new StrategyHandler(Strategy, AgencyLink.GetAgencyLink());
                Close();
            }
        }

        private void CtrlButEditClick(object sender, EventArgs e)
        {
            AgencyLink.AgencyChangeName(CtrlTxbName.Text);
            StrategyLink = new StrategyHandler(Strategy, AgencyLink.GetAgencyLink());
            Close();
        }

        private void ChangeStrategyEvent(object sender, EventArgs e)
        {
            Strategy = (TemplateStrategy.StrategyType)Convert.ToByte((sender as RadioButton).Tag);
        }
    }
}
