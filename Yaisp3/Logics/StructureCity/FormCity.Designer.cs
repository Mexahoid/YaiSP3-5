namespace Yaisp3
{
  partial class FormCity
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
        this.CtrlPicBxCity = new System.Windows.Forms.PictureBox();
        this.CtrlButMark = new System.Windows.Forms.Button();
        this.CtrlNumCityHeight = new System.Windows.Forms.NumericUpDown();
        this.CtrlNumCityWidth = new System.Windows.Forms.NumericUpDown();
        this.CtrlMiscLbl1 = new System.Windows.Forms.Label();
        this.CtrlMiscLbl2 = new System.Windows.Forms.Label();
        this.CtrlGrBCity = new System.Windows.Forms.GroupBox();
        this.CtrlGrBHouse = new System.Windows.Forms.GroupBox();
        this.CtrlButHouse = new System.Windows.Forms.Button();
        this.CtrlLblMisc4 = new System.Windows.Forms.Label();
        this.CtrlNumHouseWidth = new System.Windows.Forms.NumericUpDown();
        this.CtrlLblMisc3 = new System.Windows.Forms.Label();
        this.CtrlNumHouseHeigth = new System.Windows.Forms.NumericUpDown();
        this.CtrlTxbCityName = new System.Windows.Forms.TextBox();
        this.CtrlLblMisc5 = new System.Windows.Forms.Label();
        this.CtrlButReady = new System.Windows.Forms.Button();
        this.CtrlReset = new System.Windows.Forms.Button();
        this.CtrlButSave = new System.Windows.Forms.Button();
        this.CtrlButLoad = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxCity)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityHeight)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityWidth)).BeginInit();
        this.CtrlGrBCity.SuspendLayout();
        this.CtrlGrBHouse.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseWidth)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseHeigth)).BeginInit();
        this.SuspendLayout();
        // 
        // CtrlPicBxCity
        // 
        this.CtrlPicBxCity.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.CtrlPicBxCity.Location = new System.Drawing.Point(12, 12);
        this.CtrlPicBxCity.Name = "CtrlPicBxCity";
        this.CtrlPicBxCity.Size = new System.Drawing.Size(450, 450);
        this.CtrlPicBxCity.TabIndex = 0;
        this.CtrlPicBxCity.TabStop = false;
        this.CtrlPicBxCity.Click += new System.EventHandler(this.CtrlPicBxCity_Click);
        this.CtrlPicBxCity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxCity_MouseDown);
        this.CtrlPicBxCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxCity_MouseMove);
        this.CtrlPicBxCity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxCity_MouseUp);
        // 
        // CtrlButMark
        // 
        this.CtrlButMark.Location = new System.Drawing.Point(6, 68);
        this.CtrlButMark.Name = "CtrlButMark";
        this.CtrlButMark.Size = new System.Drawing.Size(97, 26);
        this.CtrlButMark.TabIndex = 1;
        this.CtrlButMark.Text = "Разметить";
        this.CtrlButMark.UseVisualStyleBackColor = true;
        this.CtrlButMark.Click += new System.EventHandler(this.CtrlButMarkClick);
        // 
        // CtrlNumCityHeight
        // 
        this.CtrlNumCityHeight.Location = new System.Drawing.Point(54, 42);
        this.CtrlNumCityHeight.Name = "CtrlNumCityHeight";
        this.CtrlNumCityHeight.Size = new System.Drawing.Size(48, 20);
        this.CtrlNumCityHeight.TabIndex = 2;
        this.CtrlNumCityHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // CtrlNumCityWidth
        // 
        this.CtrlNumCityWidth.Location = new System.Drawing.Point(54, 16);
        this.CtrlNumCityWidth.Name = "CtrlNumCityWidth";
        this.CtrlNumCityWidth.Size = new System.Drawing.Size(48, 20);
        this.CtrlNumCityWidth.TabIndex = 3;
        this.CtrlNumCityWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // CtrlMiscLbl1
        // 
        this.CtrlMiscLbl1.AutoSize = true;
        this.CtrlMiscLbl1.Location = new System.Drawing.Point(4, 18);
        this.CtrlMiscLbl1.Name = "CtrlMiscLbl1";
        this.CtrlMiscLbl1.Size = new System.Drawing.Size(46, 13);
        this.CtrlMiscLbl1.TabIndex = 4;
        this.CtrlMiscLbl1.Text = "Ширина";
        // 
        // CtrlMiscLbl2
        // 
        this.CtrlMiscLbl2.AutoSize = true;
        this.CtrlMiscLbl2.Location = new System.Drawing.Point(4, 44);
        this.CtrlMiscLbl2.Name = "CtrlMiscLbl2";
        this.CtrlMiscLbl2.Size = new System.Drawing.Size(45, 13);
        this.CtrlMiscLbl2.TabIndex = 5;
        this.CtrlMiscLbl2.Text = "Высота";
        // 
        // CtrlGrBCity
        // 
        this.CtrlGrBCity.Controls.Add(this.CtrlButMark);
        this.CtrlGrBCity.Controls.Add(this.CtrlMiscLbl2);
        this.CtrlGrBCity.Controls.Add(this.CtrlNumCityHeight);
        this.CtrlGrBCity.Controls.Add(this.CtrlMiscLbl1);
        this.CtrlGrBCity.Controls.Add(this.CtrlNumCityWidth);
        this.CtrlGrBCity.Location = new System.Drawing.Point(468, 64);
        this.CtrlGrBCity.Name = "CtrlGrBCity";
        this.CtrlGrBCity.Size = new System.Drawing.Size(113, 100);
        this.CtrlGrBCity.TabIndex = 6;
        this.CtrlGrBCity.TabStop = false;
        this.CtrlGrBCity.Text = "Разметка города";
        // 
        // CtrlGrBHouse
        // 
        this.CtrlGrBHouse.Controls.Add(this.CtrlButHouse);
        this.CtrlGrBHouse.Controls.Add(this.CtrlLblMisc4);
        this.CtrlGrBHouse.Controls.Add(this.CtrlNumHouseWidth);
        this.CtrlGrBHouse.Controls.Add(this.CtrlLblMisc3);
        this.CtrlGrBHouse.Controls.Add(this.CtrlNumHouseHeigth);
        this.CtrlGrBHouse.Location = new System.Drawing.Point(468, 184);
        this.CtrlGrBHouse.Name = "CtrlGrBHouse";
        this.CtrlGrBHouse.Size = new System.Drawing.Size(113, 100);
        this.CtrlGrBHouse.TabIndex = 7;
        this.CtrlGrBHouse.TabStop = false;
        this.CtrlGrBHouse.Text = "Вставка дома";
        // 
        // CtrlButHouse
        // 
        this.CtrlButHouse.Location = new System.Drawing.Point(6, 68);
        this.CtrlButHouse.Name = "CtrlButHouse";
        this.CtrlButHouse.Size = new System.Drawing.Size(97, 26);
        this.CtrlButHouse.TabIndex = 1;
        this.CtrlButHouse.Text = "Установить";
        this.CtrlButHouse.UseVisualStyleBackColor = true;
        this.CtrlButHouse.Click += new System.EventHandler(this.CtrlButHouseClick);
        // 
        // CtrlLblMisc4
        // 
        this.CtrlLblMisc4.AutoSize = true;
        this.CtrlLblMisc4.Location = new System.Drawing.Point(3, 44);
        this.CtrlLblMisc4.Name = "CtrlLblMisc4";
        this.CtrlLblMisc4.Size = new System.Drawing.Size(45, 13);
        this.CtrlLblMisc4.TabIndex = 5;
        this.CtrlLblMisc4.Text = "Высота";
        // 
        // CtrlNumHouseWidth
        // 
        this.CtrlNumHouseWidth.Location = new System.Drawing.Point(55, 13);
        this.CtrlNumHouseWidth.Name = "CtrlNumHouseWidth";
        this.CtrlNumHouseWidth.Size = new System.Drawing.Size(48, 20);
        this.CtrlNumHouseWidth.TabIndex = 2;
        this.CtrlNumHouseWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // CtrlLblMisc3
        // 
        this.CtrlLblMisc3.AutoSize = true;
        this.CtrlLblMisc3.Location = new System.Drawing.Point(3, 15);
        this.CtrlLblMisc3.Name = "CtrlLblMisc3";
        this.CtrlLblMisc3.Size = new System.Drawing.Size(46, 13);
        this.CtrlLblMisc3.TabIndex = 4;
        this.CtrlLblMisc3.Text = "Ширина";
        // 
        // CtrlNumHouseHeigth
        // 
        this.CtrlNumHouseHeigth.Location = new System.Drawing.Point(55, 42);
        this.CtrlNumHouseHeigth.Name = "CtrlNumHouseHeigth";
        this.CtrlNumHouseHeigth.Size = new System.Drawing.Size(48, 20);
        this.CtrlNumHouseHeigth.TabIndex = 3;
        this.CtrlNumHouseHeigth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
        // 
        // CtrlTxbCityName
        // 
        this.CtrlTxbCityName.Location = new System.Drawing.Point(468, 38);
        this.CtrlTxbCityName.Name = "CtrlTxbCityName";
        this.CtrlTxbCityName.Size = new System.Drawing.Size(113, 20);
        this.CtrlTxbCityName.TabIndex = 8;
        this.CtrlTxbCityName.Text = "Город";
        // 
        // CtrlLblMisc5
        // 
        this.CtrlLblMisc5.AutoSize = true;
        this.CtrlLblMisc5.Location = new System.Drawing.Point(476, 22);
        this.CtrlLblMisc5.Name = "CtrlLblMisc5";
        this.CtrlLblMisc5.Size = new System.Drawing.Size(95, 13);
        this.CtrlLblMisc5.TabIndex = 9;
        this.CtrlLblMisc5.Text = "Название города";
        // 
        // CtrlButReady
        // 
        this.CtrlButReady.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.CtrlButReady.Location = new System.Drawing.Point(468, 319);
        this.CtrlButReady.Name = "CtrlButReady";
        this.CtrlButReady.Size = new System.Drawing.Size(113, 23);
        this.CtrlButReady.TabIndex = 10;
        this.CtrlButReady.Text = "Готово";
        this.CtrlButReady.UseVisualStyleBackColor = true;
        this.CtrlButReady.Click += new System.EventHandler(this.CtrlButReadyClick);
        // 
        // CtrlReset
        // 
        this.CtrlReset.Location = new System.Drawing.Point(468, 290);
        this.CtrlReset.Name = "CtrlReset";
        this.CtrlReset.Size = new System.Drawing.Size(113, 23);
        this.CtrlReset.TabIndex = 11;
        this.CtrlReset.Text = "Сброс";
        this.CtrlReset.UseVisualStyleBackColor = true;
        this.CtrlReset.Click += new System.EventHandler(this.CtrlResetClick);
        // 
        // CtrlButSave
        // 
        this.CtrlButSave.Enabled = false;
        this.CtrlButSave.Location = new System.Drawing.Point(468, 407);
        this.CtrlButSave.Name = "CtrlButSave";
        this.CtrlButSave.Size = new System.Drawing.Size(113, 23);
        this.CtrlButSave.TabIndex = 12;
        this.CtrlButSave.Text = "Сохранить";
        this.CtrlButSave.UseVisualStyleBackColor = true;
        this.CtrlButSave.Click += new System.EventHandler(this.CtrlButSaveClick);
        // 
        // CtrlButLoad
        // 
        this.CtrlButLoad.Location = new System.Drawing.Point(468, 436);
        this.CtrlButLoad.Name = "CtrlButLoad";
        this.CtrlButLoad.Size = new System.Drawing.Size(113, 23);
        this.CtrlButLoad.TabIndex = 13;
        this.CtrlButLoad.Text = "Загрузить";
        this.CtrlButLoad.UseVisualStyleBackColor = true;
        this.CtrlButLoad.Click += new System.EventHandler(this.CtrlButLoadClick);
        // 
        // FormCity
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(591, 471);
        this.Controls.Add(this.CtrlButLoad);
        this.Controls.Add(this.CtrlButSave);
        this.Controls.Add(this.CtrlReset);
        this.Controls.Add(this.CtrlButReady);
        this.Controls.Add(this.CtrlLblMisc5);
        this.Controls.Add(this.CtrlTxbCityName);
        this.Controls.Add(this.CtrlGrBHouse);
        this.Controls.Add(this.CtrlGrBCity);
        this.Controls.Add(this.CtrlPicBxCity);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FormCity";
        this.Text = "Редактор города";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCity_FormClosed);
        this.Load += new System.EventHandler(this.FormCity_Load);
        ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxCity)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityHeight)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityWidth)).EndInit();
        this.CtrlGrBCity.ResumeLayout(false);
        this.CtrlGrBCity.PerformLayout();
        this.CtrlGrBHouse.ResumeLayout(false);
        this.CtrlGrBHouse.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseWidth)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseHeigth)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox CtrlPicBxCity;
    private System.Windows.Forms.Button CtrlButMark;
    private System.Windows.Forms.NumericUpDown CtrlNumCityHeight;
    private System.Windows.Forms.NumericUpDown CtrlNumCityWidth;
    private System.Windows.Forms.Label CtrlMiscLbl1;
    private System.Windows.Forms.Label CtrlMiscLbl2;
    private System.Windows.Forms.GroupBox CtrlGrBCity;
    private System.Windows.Forms.GroupBox CtrlGrBHouse;
    private System.Windows.Forms.Button CtrlButHouse;
    private System.Windows.Forms.Label CtrlLblMisc4;
    private System.Windows.Forms.NumericUpDown CtrlNumHouseWidth;
    private System.Windows.Forms.Label CtrlLblMisc3;
    private System.Windows.Forms.NumericUpDown CtrlNumHouseHeigth;
    private System.Windows.Forms.TextBox CtrlTxbCityName;
    private System.Windows.Forms.Label CtrlLblMisc5;
    private System.Windows.Forms.Button CtrlButReady;
    private System.Windows.Forms.Button CtrlReset;
    private System.Windows.Forms.Button CtrlButSave;
    private System.Windows.Forms.Button CtrlButLoad;
  }
}