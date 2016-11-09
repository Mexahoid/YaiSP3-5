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
  public partial class _FormAgency : Form
  {
    int Strategy;
    public _FormAgency()
    {
      InitializeComponent();
    }

    private void _ctrlButCreate_Click(object sender, EventArgs e)
    {
      if (!MainUnitProcessor.AgencyCreate(_ctrlTxbName.Text, (int)_ctrlNumDeposit.Value, (int)_ctrlNumBillboards.Value, Strategy))
        MessageBox.Show("Вы ввели недопустимое значение в каком-то из полей. Проверьте правильность информации.", "Ошибка значений", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      else
        Close();
    }  
    private void _ctrlButEdit_Click(object sender, EventArgs e)
    {
      MainUnitProcessor.AgencyChangeData(_ctrlTxbName.Text, Strategy);
      Close();
    }

    private void _FormAgency_Load(object sender, EventArgs e)
    {
      _ctrlButEdit.Enabled = MainUnitProcessor.AgencyIsPresent();
      _ctrlButCreate.Enabled = _ctrlNumBillboards.Enabled = _ctrlNumDeposit.Enabled = !MainUnitProcessor.AgencyIsPresent();
      if (MainUnitProcessor.AgencyIsPresent())
      {
        Tuple<string, int, int, Agency.Strategies> T =
          MainUnitProcessor.AgencyGetData();
        _ctrlNumBillboards.Value = T.Item3;
        _ctrlNumDeposit.Value = T.Item2;
        _ctrlTxbName.Text = T.Item1;
        switch (T.Item4)
        {
          case Agency.Strategies.Conservative:
            _ctrlRadConserv.Checked = true;
            break;
          case Agency.Strategies.Normal:
            _ctrlRadNormal.Checked = true;
            break;
          case Agency.Strategies.Aggressive:
            _ctrlRadAggro.Checked = true;
            break;
        }
      }
      else
      {
        _ctrlTxbName.Text = "ООО \"Вектор\"";
        _ctrlRadConserv.Checked = true;
      }
    }
     
    private void ChangeStrategyEvent(object sender, EventArgs e)
    {
      Strategy = Convert.ToInt32((sender as RadioButton).Tag);
    }
  }
}
