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
        private AgencyHandler AgencyLink;
        private StrategyHandler StrategyLink;
        private List<Tuple<AgencyHandler, StrategyHandler>> Agencies;


        private TemplateStrategy.StrategyType Strategy = TemplateStrategy.StrategyType.Normal;

        public FormAgency(AgencyHandler AgencyOrig, StrategyHandler StrategyOrig)
        {
            AgencyLink = AgencyOrig;
            StrategyLink = StrategyOrig;
            InitializeComponent();
            
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

            if (AgencyLink.AgencyIsPresent())                         //Если агентство не пусто, то запрещаем создатние.
            {
                CtrlButCreate.Enabled = CtrlNumBillboards.Enabled = CtrlNumDeposit.Enabled = false;
                CtrlButEdit.Enabled = true;
                Tuple<string, int, int> T = AgencyLink.AgencyGetData();
                CtrlTxbName.Text = T.Item1;
                CtrlNumDeposit.Value = T.Item2;
                CtrlNumBillboards.Value = T.Item3;

                Strategy = StrategyLink.StrategyGetType();    //Т.к. стратегия без агентства не существует.
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

        }

        /// <summary>
        /// Создаём агентство.
        /// </summary>
        private void CtrlButCreateClick(object sender, EventArgs e)
        {
            if (AgencyLink == null)                         //Если агентство пустое - нужно создать
                AgencyLink = new AgencyHandler();
            if (!AgencyLink.AgencyCreate(CtrlTxbName.Text,  //Если плохое имя - выдаем мсгбокс
                (int)CtrlNumDeposit.Value,
                (int)CtrlNumBillboards.Value, 1))
                MessageBox.Show("Вы ввели недопустимое значение в каком-то из полей. Проверьте правильность информации.", "Ошибка значений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                StrategyLink.CreateLink(Strategy, 
                    AgencyLink.GetAgencyLink());            //Иначе создаем нормальную стратегию
                Close();                                    //И закрываем.
            }
        }

        /// <summary>
        /// Меняем имя и стратегию у агентства.
        /// </summary>
        private void CtrlButEditClick(object sender, EventArgs e)
        {
            AgencyLink.AgencyChangeName(CtrlTxbName.Text);
            StrategyLink.CreateLink(Strategy, AgencyLink.GetAgencyLink());
            Close();
        }

        /// <summary>
        /// Меняем нынешнюю стратегию в форме.
        /// </summary>
        private void ChangeStrategyEvent(object sender, EventArgs e)
        {
            Strategy = (TemplateStrategy.StrategyType)Convert.ToByte((sender as RadioButton).Tag);
        }
    }
}
