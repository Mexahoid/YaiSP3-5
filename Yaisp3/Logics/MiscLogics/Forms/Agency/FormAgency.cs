using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencySimulator.Interfaces;

namespace AgencySimulator
{
    public partial class FormAgency : Form
    {
        private AgencyHandler CurrentAgency;
        private StrategyHandler CurrentStrategy;

        private List<Tuple<AgencyHandler, StrategyHandler>> Agencies;
        private List<IStrategy> Strategies;

        private City CityLink;
        private QueueClass QueueLink;
        private MainDrawingProcessor DrawersLink;

        public FormAgency(List<Tuple<AgencyHandler, StrategyHandler>> Agencies, List<IStrategy> Strategies,
            City City, QueueClass Queue, MainDrawingProcessor Drawers)
        {
            DrawersLink = Drawers;
            CityLink = City;
            QueueLink = Queue;
            this.Agencies = Agencies;
            this.Strategies = Strategies;
            InitializeComponent();

            int L = Strategies.Count;
            if (L != 0)
            {
                for (int i = 0; i < L; i++)
                    CtrlLBStrategies.Items.Add(Strategies[i].GetName());
            }

            if (Agencies.Count != 0)
            {
                int C = Agencies.Count;
                for (int i = 0; i < C; i++)
                    CtrlLBAgencies.Items.Add(Agencies[i].ToString());
            }
        }

        /// <summary>
        /// Создаём агентство.
        /// </summary>
        private void CtrlButCreateClick(object sender, EventArgs e)
        {
            CurrentAgency = new AgencyHandler();
            if (!CurrentAgency.AgencyCreate(CtrlTxbName.Text,  //Если плохое имя - выдаем мсгбокс
                (int)CtrlNumDeposit.Value,
                (int)CtrlNumBillboards.Value, Agencies.Count + 1))
                MessageBox.Show("Вы ввели недопустимое значение в каком-то из полей. Проверьте правильность информации.", "Ошибка значений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                CurrentAgency.AgencySetLink(CityLink, QueueLink, DrawersLink);              //Агентству заталкиваем ссылки
                CurrentStrategy = new StrategyHandler(CurrentAgency.GetAgencyLink());       //Потом заталкиваем агентство в хэндлер стратегии
                CurrentStrategy.SetStrategy(Strategies[CtrlLBStrategies.SelectedIndex]);    //Хэндлеру прописываем нужную стратегию
                Agencies.Add(Tuple.Create(CurrentAgency, CurrentStrategy));                 //И заталкиваем в общий список
                CtrlLBAgencies.Items.Add(CurrentAgency.ToString());                         //Потом заносим имя агентства в список агентств
                CurrentAgency = null;
                CurrentStrategy = null;

                CtrlButSuction.Enabled = true;
            }
        }

        /// <summary>
        /// Меняем имя и стратегию у агентства.
        /// </summary>
        private void CtrlButEditClick(object sender, EventArgs e)
        {
            CurrentAgency.AgencyChangeName(CtrlTxbName.Text);
            CurrentStrategy = new StrategyHandler(CurrentAgency.GetAgencyLink());
            CurrentStrategy.SetStrategy(Strategies[CtrlLBStrategies.SelectedIndex]);
        }
        

        private void CtrlLBAgencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CtrlLBAgencies.SelectedIndex > -1)
            {
                CurrentAgency = Agencies[CtrlLBAgencies.SelectedIndex].Item1;
                CurrentStrategy = Agencies[CtrlLBAgencies.SelectedIndex].Item2;

                int index = CtrlLBStrategies.FindString(CurrentStrategy.ToString(), -1);
                if (index != -1)
                    CtrlLBStrategies.SetSelected(index, true);
                
                CtrlButEdit.Enabled = CtrlButDelete.Enabled = true;
                Tuple<int, int> T = CurrentAgency.AgencyGetData();
                CtrlTxbName.Text = CurrentAgency.ToString();
                CtrlNumDeposit.Value = T.Item1;
                CtrlNumBillboards.Value = T.Item2;
            }
        }

        private void CtrlButDelete_Click(object sender, EventArgs e)
        {
            CurrentAgency.AgencyDestroy();
            CurrentStrategy = null;
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
