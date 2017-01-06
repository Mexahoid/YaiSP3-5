namespace AgencySimulator
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
            this.CtrlLblMisc3 = new System.Windows.Forms.Label();
            this.CtrlButCreate = new System.Windows.Forms.Button();
            this.CtrlButEdit = new System.Windows.Forms.Button();
            this.CtrlNumBillboards = new System.Windows.Forms.NumericUpDown();
            this.CtrlNumDeposit = new System.Windows.Forms.NumericUpDown();
            this.CtrlLBAgencies = new System.Windows.Forms.ListBox();
            this.CtrlButSuction = new System.Windows.Forms.Button();
            this.CtrlButDelete = new System.Windows.Forms.Button();
            this.CtrlLBStrategies = new System.Windows.Forms.ListBox();
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
            this.CtrlTxbName.Text = "ООО \"Вектор\"";
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
            this.CtrlButCreate.Location = new System.Drawing.Point(169, 61);
            this.CtrlButCreate.Name = "CtrlButCreate";
            this.CtrlButCreate.Size = new System.Drawing.Size(75, 23);
            this.CtrlButCreate.TabIndex = 7;
            this.CtrlButCreate.Text = "Создать";
            this.CtrlButCreate.UseVisualStyleBackColor = true;
            this.CtrlButCreate.Click += new System.EventHandler(this.CtrlButCreateClick);
            // 
            // CtrlButEdit
            // 
            this.CtrlButEdit.Enabled = false;
            this.CtrlButEdit.Location = new System.Drawing.Point(169, 90);
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
            // CtrlLBAgencies
            // 
            this.CtrlLBAgencies.FormattingEnabled = true;
            this.CtrlLBAgencies.Location = new System.Drawing.Point(252, 12);
            this.CtrlLBAgencies.Name = "CtrlLBAgencies";
            this.CtrlLBAgencies.Size = new System.Drawing.Size(218, 160);
            this.CtrlLBAgencies.TabIndex = 11;
            this.CtrlLBAgencies.SelectedIndexChanged += new System.EventHandler(this.CtrlLBAgencies_SelectedIndexChanged);
            // 
            // CtrlButSuction
            // 
            this.CtrlButSuction.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CtrlButSuction.Enabled = false;
            this.CtrlButSuction.Location = new System.Drawing.Point(169, 149);
            this.CtrlButSuction.Name = "CtrlButSuction";
            this.CtrlButSuction.Size = new System.Drawing.Size(75, 23);
            this.CtrlButSuction.TabIndex = 12;
            this.CtrlButSuction.Text = "Готово";
            this.CtrlButSuction.UseVisualStyleBackColor = true;
            this.CtrlButSuction.Click += new System.EventHandler(this.CtrlButSuction_Click);
            // 
            // CtrlButDelete
            // 
            this.CtrlButDelete.Enabled = false;
            this.CtrlButDelete.Location = new System.Drawing.Point(169, 119);
            this.CtrlButDelete.Name = "CtrlButDelete";
            this.CtrlButDelete.Size = new System.Drawing.Size(75, 23);
            this.CtrlButDelete.TabIndex = 13;
            this.CtrlButDelete.Text = "Удалить";
            this.CtrlButDelete.UseVisualStyleBackColor = true;
            this.CtrlButDelete.Click += new System.EventHandler(this.CtrlButDelete_Click);
            // 
            // CtrlLBStrategies
            // 
            this.CtrlLBStrategies.FormattingEnabled = true;
            this.CtrlLBStrategies.Location = new System.Drawing.Point(12, 90);
            this.CtrlLBStrategies.Name = "CtrlLBStrategies";
            this.CtrlLBStrategies.Size = new System.Drawing.Size(151, 82);
            this.CtrlLBStrategies.TabIndex = 14;
            // 
            // FormAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 186);
            this.Controls.Add(this.CtrlLBStrategies);
            this.Controls.Add(this.CtrlButDelete);
            this.Controls.Add(this.CtrlButSuction);
            this.Controls.Add(this.CtrlLBAgencies);
            this.Controls.Add(this.CtrlNumDeposit);
            this.Controls.Add(this.CtrlNumBillboards);
            this.Controls.Add(this.CtrlButEdit);
            this.Controls.Add(this.CtrlButCreate);
            this.Controls.Add(this.CtrlLblMisc3);
            this.Controls.Add(this.CtrlLblMisc2);
            this.Controls.Add(this.CtrlLblMisc1);
            this.Controls.Add(this.CtrlTxbName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAgency";
            this.Text = "Редактор агентств.";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumBillboards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumDeposit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox CtrlTxbName;
    private System.Windows.Forms.Label CtrlLblMisc1;
    private System.Windows.Forms.Label CtrlLblMisc2;
    private System.Windows.Forms.Label CtrlLblMisc3;
    private System.Windows.Forms.Button CtrlButCreate;
    private System.Windows.Forms.Button CtrlButEdit;
    private System.Windows.Forms.NumericUpDown CtrlNumBillboards;
    private System.Windows.Forms.NumericUpDown CtrlNumDeposit;
        private System.Windows.Forms.ListBox CtrlLBAgencies;
        private System.Windows.Forms.Button CtrlButSuction;
        private System.Windows.Forms.Button CtrlButDelete;
        private System.Windows.Forms.ListBox CtrlLBStrategies;
    }
}