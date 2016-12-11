using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgencySimulator
{
    public partial class FormAgency : Form
    {
        private AgencyHandler AgencyLink;
        private StrategyHandler StrategyLink;

        private List<Tuple<AgencyHandler, StrategyHandler>> Agencies;
        private City CityLink;
        private QueueClass QueueLink;
        private MainDrawingProcessor DrawersLink;
        
        private TemplateStrategy.StrategyType Strategy = TemplateStrategy.StrategyType.Normal;

        public FormAgency(List<Tuple<AgencyHandler, StrategyHandler>> Agencies,
            City City, QueueClass Queue, MainDrawingProcessor Drawers)
        {
            DrawersLink = Drawers;
            CityLink = City;
            QueueLink = Queue;
            this.Agencies = Agencies;
            InitializeComponent();

            if (Agencies.Count != 0)
            {
                int C = Agencies.Count;
                for (int i = 0; i < C; i++)
                    CtrlLBAgencies.Items.Add(Agencies[i].Item1.ToString());
                AgencyLink = Agencies[0].Item1;
                StrategyLink = Agencies[0].Item2;     //Выбираем их только если список не пуст

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
                Tuple<int, int> T = AgencyLink.AgencyGetData();
                CtrlTxbName.Text = AgencyLink.ToString();
                CtrlButEdit.Enabled = CtrlButDelete.Enabled = true;
                CtrlNumDeposit.Value = T.Item1;
                CtrlNumBillboards.Value = T.Item2;
            }
        }

        /// <summary>
        /// Создаём агентство.
        /// </summary>
        private void CtrlButCreateClick(object sender, EventArgs e)
        {
            AgencyLink = new AgencyHandler();
            if (!AgencyLink.AgencyCreate(CtrlTxbName.Text,  //Если плохое имя - выдаем мсгбокс
                (int)CtrlNumDeposit.Value,
                (int)CtrlNumBillboards.Value, Agencies.Count + 1))
                MessageBox.Show("Вы ввели недопустимое значение в каком-то из полей. Проверьте правильность информации.", "Ошибка значений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                StrategyLink = new StrategyHandler();
                StrategyLink.CreateLink(Strategy,
                    AgencyLink.GetAgencyLink());            //Иначе создаем нормальную стратегию
                AgencyLink.AgencySetLink(CityLink, QueueLink, DrawersLink);
                Agencies.Add(Tuple.Create(AgencyLink, StrategyLink));
                CtrlLBAgencies.Items.Add(AgencyLink.ToString());
                AgencyLink = null;
                StrategyLink = null;

                CtrlButSuction.Enabled = true;
            }
        }

        /// <summary>
        /// Меняем имя и стратегию у агентства.
        /// </summary>
        private void CtrlButEditClick(object sender, EventArgs e)
        {
            AgencyLink.AgencyChangeName(CtrlTxbName.Text);
            StrategyLink.CreateLink(Strategy, AgencyLink.GetAgencyLink());
        }

        /// <summary>
        /// Меняем нынешнюю стратегию в форме.
        /// </summary>
        private void ChangeStrategyEvent(object sender, EventArgs e)
        {
            Strategy = (TemplateStrategy.StrategyType)Convert.ToByte((sender as RadioButton).Tag);
        }

        private void CtrlLBAgencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CtrlLBAgencies.SelectedIndex > -1)
            {
                AgencyLink = Agencies[CtrlLBAgencies.SelectedIndex].Item1;
                StrategyLink = Agencies[CtrlLBAgencies.SelectedIndex].Item2;

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

                CtrlButEdit.Enabled = CtrlButDelete.Enabled = true;
                Tuple<int, int> T = AgencyLink.AgencyGetData();
                CtrlTxbName.Text = AgencyLink.ToString();
                CtrlNumDeposit.Value = T.Item1;
                CtrlNumBillboards.Value = T.Item2;
            }
        }

        private void CtrlButDelete_Click(object sender, EventArgs e)
        {
            AgencyLink.AgencyDestroy();
            StrategyLink = null;
            Agencies.RemoveAt(CtrlLBAgencies.SelectedIndex);
            CtrlLBAgencies.Items.RemoveAt(CtrlLBAgencies.SelectedIndex);
            if (Agencies.Count == 0)
                CtrlButSuction.Enabled = false;
        }

        private void CtrlButSuction_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
