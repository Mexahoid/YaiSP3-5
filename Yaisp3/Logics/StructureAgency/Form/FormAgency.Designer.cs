namespace Yaisp3
{
  partial class FormAgency
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.CtrlTxbName = new System.Windows.Forms.TextBox();
            this.CtrlLblMisc1 = new System.Windows.Forms.Label();
            this.CtrlLblMisc2 = new System.Windows.Forms.Label();
            this.CtrlGrBStrat = new System.Windows.Forms.GroupBox();
            this.CtrlRadConserv = new System.Windows.Forms.RadioButton();
            this.CtrlRadNormal = new System.Windows.Forms.RadioButton();
            this.CtrlRadAggro = new System.Windows.Forms.RadioButton();
            this.CtrlLblMisc3 = new System.Windows.Forms.Label();
            this.CtrlButCreate = new System.Windows.Forms.Button();
            this.CtrlButEdit = new System.Windows.Forms.Button();
            this.CtrlNumBillboards = new System.Windows.Forms.NumericUpDown();
            this.CtrlNumDeposit = new System.Windows.Forms.NumericUpDown();
            this.CtrlGrBStrat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumBillboards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumDeposit)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlTxbName
            // 
            this.CtrlTxbName.Location = new System.Drawing.Point(75, 6);
            this.CtrlTxbName.Name = "CtrlTxbName";
            this.CtrlTxbName.Size = new System.Drawing.Size(169, 20);
            this.CtrlTxbName.TabIndex = 0;
            // 
            // CtrlLblMisc1
            // 
            this.CtrlLblMisc1.AutoSize = true;
            this.CtrlLblMisc1.Location = new System.Drawing.Point(12, 9);
            this.CtrlLblMisc1.Name = "CtrlLblMisc1";
            this.CtrlLblMisc1.Size = new System.Drawing.Size(60, 13);
            this.CtrlLblMisc1.TabIndex = 1;
            this.CtrlLblMisc1.Text = "Название:";
            // 
            // CtrlLblMisc2
            // 
            this.CtrlLblMisc2.AutoSize = true;
            this.CtrlLblMisc2.Location = new System.Drawing.Point(12, 35);
            this.CtrlLblMisc2.Name = "CtrlLblMisc2";
            this.CtrlLblMisc2.Size = new System.Drawing.Size(57, 13);
            this.CtrlLblMisc2.TabIndex = 3;
            this.CtrlLblMisc2.Text = "Депозит: ";
            // 
            // CtrlGrBStrat
            // 
            this.CtrlGrBStrat.Controls.Add(this.CtrlRadConserv);
            this.CtrlGrBStrat.Controls.Add(this.CtrlRadNormal);
            this.CtrlGrBStrat.Controls.Add(this.CtrlRadAggro);
            this.CtrlGrBStrat.Location = new System.Drawing.Point(15, 85);
            this.CtrlGrBStrat.Name = "CtrlGrBStrat";
            this.CtrlGrBStrat.Size = new System.Drawing.Size(121, 90);
            this.CtrlGrBStrat.TabIndex = 4;
            this.CtrlGrBStrat.TabStop = false;
            this.CtrlGrBStrat.Tag = "3";
            this.CtrlGrBStrat.Text = "Стратегия";
            // 
            // CtrlRadConserv
            // 
            this.CtrlRadConserv.AutoSize = true;
            this.CtrlRadConserv.Location = new System.Drawing.Point(6, 42);
            this.CtrlRadConserv.Name = "CtrlRadConserv";
            this.CtrlRadConserv.Size = new System.Drawing.Size(109, 17);
            this.CtrlRadConserv.TabIndex = 7;
            this.CtrlRadConserv.Tag = "1";
            this.CtrlRadConserv.Text = "Консервативная";
            this.CtrlRadConserv.UseVisualStyleBackColor = true;
            this.CtrlRadConserv.CheckedChanged += new System.EventHandler(this.ChangeStrategyEvent);
            // 
            // CtrlRadNormal
            // 
            this.CtrlRadNormal.AutoSize = true;
            this.CtrlRadNormal.Checked = true;
            this.CtrlRadNormal.Location = new System.Drawing.Point(6, 19);
            this.CtrlRadNormal.Name = "CtrlRadNormal";
            this.CtrlRadNormal.Size = new System.Drawing.Size(83, 17);
            this.CtrlRadNormal.TabIndex = 6;
            this.CtrlRadNormal.TabStop = true;
            this.CtrlRadNormal.Tag = "0";
            this.CtrlRadNormal.Text = "Умеренная";
            this.CtrlRadNormal.UseVisualStyleBackColor = true;
            this.CtrlRadNormal.CheckedChanged += new System.EventHandler(this.ChangeStrategyEvent);
            // 
            // CtrlRadAggro
            // 
            this.CtrlRadAggro.AutoSize = true;
            this.CtrlRadAggro.Location = new System.Drawing.Point(6, 65);
            this.CtrlRadAggro.Name = "CtrlRadAggro";
            this.CtrlRadAggro.Size = new System.Drawing.Size(91, 17);
            this.CtrlRadAggro.TabIndex = 5;
            this.CtrlRadAggro.Tag = "2";
            this.CtrlRadAggro.Text = "Агрессивная";
            this.CtrlRadAggro.UseVisualStyleBackColor = true;
            this.CtrlRadAggro.CheckedChanged += new System.EventHandler(this.ChangeStrategyEvent);
            // 
            // CtrlLblMisc3
            // 
            this.CtrlLblMisc3.AutoSize = true;
            this.CtrlLblMisc3.Location = new System.Drawing.Point(12, 61);
            this.CtrlLblMisc3.Name = "CtrlLblMisc3";
            this.CtrlLblMisc3.Size = new System.Drawing.Size(42, 13);
            this.CtrlLblMisc3.TabIndex = 6;
            this.CtrlLblMisc3.Text = "Щиты: ";
            // 
            // CtrlButCreate
            // 
            this.CtrlButCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CtrlButCreate.Location = new System.Drawing.Point(169, 121);
            this.CtrlButCreate.Name = "CtrlButCreate";
            this.CtrlButCreate.Size = new System.Drawing.Size(75, 23);
            this.CtrlButCreate.TabIndex = 7;
            this.CtrlButCreate.Text = "Создать";
            this.CtrlButCreate.UseVisualStyleBackColor = true;
            this.CtrlButCreate.Click += new System.EventHandler(this.CtrlButCreateClick);
            // 
            // CtrlButEdit
            // 
            this.CtrlButEdit.Location = new System.Drawing.Point(169, 152);
            this.CtrlButEdit.Name = "CtrlButEdit";
            this.CtrlButEdit.Size = new System.Drawing.Size(75, 23);
            this.CtrlButEdit.TabIndex = 8;
            this.CtrlButEdit.Text = "Изменить";
            this.CtrlButEdit.UseVisualStyleBackColor = true;
            this.CtrlButEdit.Click += new System.EventHandler(this.CtrlButEditClick);
            // 
            // CtrlNumBillboards
            // 
            this.CtrlNumBillboards.Location = new System.Drawing.Point(75, 59);
            this.CtrlNumBillboards.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CtrlNumBillboards.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CtrlNumBillboards.Name = "CtrlNumBillboards";
            this.CtrlNumBillboards.Size = new System.Drawing.Size(70, 20);
            this.CtrlNumBillboards.TabIndex = 9;
            this.CtrlNumBillboards.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // CtrlNumDeposit
            // 
            this.CtrlNumDeposit.Location = new System.Drawing.Point(75, 33);
            this.CtrlNumDeposit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.CtrlNumDeposit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CtrlNumDeposit.Name = "CtrlNumDeposit";
            this.CtrlNumDeposit.Size = new System.Drawing.Size(70, 20);
            this.CtrlNumDeposit.TabIndex = 10;
            this.CtrlNumDeposit.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // FormAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 187);
            this.Controls.Add(this.CtrlNumDeposit);
            this.Controls.Add(this.CtrlNumBillboards);
            this.Controls.Add(this.CtrlButEdit);
            this.Controls.Add(this.CtrlButCreate);
            this.Controls.Add(this.CtrlLblMisc3);
            this.Controls.Add(this.CtrlGrBStrat);
            this.Controls.Add(this.CtrlLblMisc2);
            this.Controls.Add(this.CtrlLblMisc1);
            this.Controls.Add(this.CtrlTxbName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAgency";
            this.Text = "Рекламное баннерное агентство";
            this.Load += new System.EventHandler(this.FormAgency_Load);
            this.CtrlGrBStrat.ResumeLayout(false);
            this.CtrlGrBStrat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumBillboards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumDeposit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox CtrlTxbName;
    private System.Windows.Forms.Label CtrlLblMisc1;
    private System.Windows.Forms.Label CtrlLblMisc2;
    private System.Windows.Forms.GroupBox CtrlGrBStrat;
    private System.Windows.Forms.RadioButton CtrlRadConserv;
    private System.Windows.Forms.RadioButton CtrlRadNormal;
    private System.Windows.Forms.RadioButton CtrlRadAggro;
    private System.Windows.Forms.Label CtrlLblMisc3;
    private System.Windows.Forms.Button CtrlButCreate;
    private System.Windows.Forms.Button CtrlButEdit;
    private System.Windows.Forms.NumericUpDown CtrlNumBillboards;
    private System.Windows.Forms.NumericUpDown CtrlNumDeposit;
  }
}