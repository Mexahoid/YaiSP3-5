using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencySimulator.Interfaces;
using System.Reflection;

namespace AgencySimulator
{
    public partial class FormAgency : Form
    {
        private AgencyHandler CurrentAgency;
        private Type CurrentStrategy;

        private List<(AgencyHandler agency, IStrategy strategy)> Agencies;
        private List<Type> Strategies;

        private City CityLink;
        private QueueClass QueueLink;
        private MainDrawingProcessor DrawersLink;

        public FormAgency(List<(AgencyHandler agency, IStrategy strategy)> Agencies, List<Type> Strategies,
            City City, QueueClass Queue, MainDrawingProcessor Drawers)
        {
            DrawersLink = Drawers;
            CityLink = City;
            QueueLink = Queue;
            this.Agencies = Agencies;
            this.Strategies = Strategies;
            InitializeComponent();
            List<string> StrategyNames = new List<string>();

            int L = Strategies.Count;
            if (L != 0)
            {
                object[] attrs;
                for (int i = 0; i < L; i++)
                {
                    attrs = Strategies[i].GetCustomAttributes(false);
                if (attrs.Length > 0 && attrs[0] as Description != null)
                    CtrlLBStrategies.Items.Add((attrs[0] as Description).Desc);
                }
            }

            if (Agencies.Count != 0)
            {
                int C = Agencies.Count;
                for (int i = 0; i < C; i++)
                    CtrlLBAgencies.Items.Add(Agencies[i].agency.ToString() + ", " + Agencies[i].strategy.GetName());
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
                CurrentStrategy = Strategies[CtrlLBStrategies.SelectedIndex];
                CurrentAgency.AgencySetLink(CityLink, QueueLink, DrawersLink);              //Агентству заталкиваем ссылки
                IStrategy AgencyStrat = Activator.CreateInstance(CurrentStrategy) as IStrategy;
                Agencies.Add((CurrentAgency, AgencyStrat));                 //И заталкиваем в общий список
                CtrlLBAgencies.Items.Add(CurrentAgency.ToString() + ", " + AgencyStrat.GetName()); //Потом заносим имя агентства в список агентств
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
            IStrategy AgencyStrat = Activator.CreateInstance(CurrentStrategy) as IStrategy;
            Agencies[CtrlLBAgencies.SelectedIndex] = (CurrentAgency, AgencyStrat);
        }
        

        private void CtrlLBAgencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CtrlLBAgencies.SelectedIndex > -1)
            {
                CurrentAgency = Agencies[CtrlLBAgencies.SelectedIndex].agency;
                CurrentStrategy = Agencies[CtrlLBAgencies.SelectedIndex].strategy.GetType();

                int index = CtrlLBStrategies.FindString(CurrentStrategy.ToString(), -1);
                if (index != -1)
                    CtrlLBStrategies.SetSelected(index, true);
                
                CtrlButEdit.Enabled = CtrlButDelete.Enabled = true;
                (int, int) T = CurrentAgency.AgencyGetData();
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
