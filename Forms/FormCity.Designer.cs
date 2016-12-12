namespace AgencySimulator.Forms
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
            this.CtrlButReady = new System.Windows.Forms.Button();
            this.CtrlLblMisc5 = new System.Windows.Forms.Label();
            this.CtrlTxbCityName = new System.Windows.Forms.TextBox();
            this.CtrlGrBHouse = new System.Windows.Forms.GroupBox();
            this.CtrlButHouse = new System.Windows.Forms.Button();
            this.CtrlLblMisc4 = new System.Windows.Forms.Label();
            this.CtrlNumHouseWidth = new System.Windows.Forms.NumericUpDown();
            this.CtrlLblMisc3 = new System.Windows.Forms.Label();
            this.CtrlNumHouseHeigth = new System.Windows.Forms.NumericUpDown();
            this.CtrlGrBCity = new System.Windows.Forms.GroupBox();
            this.CtrlButMark = new System.Windows.Forms.Button();
            this.CtrlMiscLbl2 = new System.Windows.Forms.Label();
            this.CtrlNumCityHeight = new System.Windows.Forms.NumericUpDown();
            this.CtrlMiscLbl1 = new System.Windows.Forms.Label();
            this.CtrlNumCityWidth = new System.Windows.Forms.NumericUpDown();
            this.CtrlPicBxCity = new System.Windows.Forms.PictureBox();
            this.CtrlGrBHouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseHeigth)).BeginInit();
            this.CtrlGrBCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxCity)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlButReady
            // 
            this.CtrlButReady.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CtrlButReady.Enabled = false;
            this.CtrlButReady.Location = new System.Drawing.Point(468, 320);
            this.CtrlButReady.Name = "CtrlButReady";
            this.CtrlButReady.Size = new System.Drawing.Size(113, 23);
            this.CtrlButReady.TabIndex = 16;
            this.CtrlButReady.Text = "Готово";
            this.CtrlButReady.UseVisualStyleBackColor = true;
            this.CtrlButReady.Click += new System.EventHandler(this.CtrlButReady_Click);
            // 
            // CtrlLblMisc5
            // 
            this.CtrlLblMisc5.AutoSize = true;
            this.CtrlLblMisc5.Location = new System.Drawing.Point(476, 23);
            this.CtrlLblMisc5.Name = "CtrlLblMisc5";
            this.CtrlLblMisc5.Size = new System.Drawing.Size(95, 13);
            this.CtrlLblMisc5.TabIndex = 15;
            this.CtrlLblMisc5.Text = "Название города";
            // 
            // CtrlTxbCityName
            // 
            this.CtrlTxbCityName.Location = new System.Drawing.Point(468, 39);
            this.CtrlTxbCityName.Name = "CtrlTxbCityName";
            this.CtrlTxbCityName.Size = new System.Drawing.Size(113, 20);
            this.CtrlTxbCityName.TabIndex = 14;
            this.CtrlTxbCityName.Text = "Город";
            // 
            // CtrlGrBHouse
            // 
            this.CtrlGrBHouse.Controls.Add(this.CtrlButHouse);
            this.CtrlGrBHouse.Controls.Add(this.CtrlLblMisc4);
            this.CtrlGrBHouse.Controls.Add(this.CtrlNumHouseWidth);
            this.CtrlGrBHouse.Controls.Add(this.CtrlLblMisc3);
            this.CtrlGrBHouse.Controls.Add(this.CtrlNumHouseHeigth);
            this.CtrlGrBHouse.Location = new System.Drawing.Point(468, 185);
            this.CtrlGrBHouse.Name = "CtrlGrBHouse";
            this.CtrlGrBHouse.Size = new System.Drawing.Size(113, 111);
            this.CtrlGrBHouse.TabIndex = 13;
            this.CtrlGrBHouse.TabStop = false;
            this.CtrlGrBHouse.Text = "Вставка дома";
            // 
            // CtrlButHouse
            // 
            this.CtrlButHouse.Enabled = false;
            this.CtrlButHouse.Location = new System.Drawing.Point(6, 75);
            this.CtrlButHouse.Name = "CtrlButHouse";
            this.CtrlButHouse.Size = new System.Drawing.Size(97, 26);
            this.CtrlButHouse.TabIndex = 1;
            this.CtrlButHouse.Text = "Установить";
            this.CtrlButHouse.UseVisualStyleBackColor = true;
            this.CtrlButHouse.Click += new System.EventHandler(this.CtrlButHouse_Click);
            // 
            // CtrlLblMisc4
            // 
            this.CtrlLblMisc4.AutoSize = true;
            this.CtrlLblMisc4.Location = new System.Drawing.Point(3, 51);
            this.CtrlLblMisc4.Name = "CtrlLblMisc4";
            this.CtrlLblMisc4.Size = new System.Drawing.Size(45, 13);
            this.CtrlLblMisc4.TabIndex = 5;
            this.CtrlLblMisc4.Text = "Высота";
            // 
            // CtrlNumHouseWidth
            // 
            this.CtrlNumHouseWidth.Location = new System.Drawing.Point(55, 20);
            this.CtrlNumHouseWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.CtrlLblMisc3.Location = new System.Drawing.Point(3, 22);
            this.CtrlLblMisc3.Name = "CtrlLblMisc3";
            this.CtrlLblMisc3.Size = new System.Drawing.Size(46, 13);
            this.CtrlLblMisc3.TabIndex = 4;
            this.CtrlLblMisc3.Text = "Ширина";
            // 
            // CtrlNumHouseHeigth
            // 
            this.CtrlNumHouseHeigth.Location = new System.Drawing.Point(55, 49);
            this.CtrlNumHouseHeigth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CtrlNumHouseHeigth.Name = "CtrlNumHouseHeigth";
            this.CtrlNumHouseHeigth.Size = new System.Drawing.Size(48, 20);
            this.CtrlNumHouseHeigth.TabIndex = 3;
            this.CtrlNumHouseHeigth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CtrlGrBCity
            // 
            this.CtrlGrBCity.Controls.Add(this.CtrlButMark);
            this.CtrlGrBCity.Controls.Add(this.CtrlMiscLbl2);
            this.CtrlGrBCity.Controls.Add(this.CtrlNumCityHeight);
            this.CtrlGrBCity.Controls.Add(this.CtrlMiscLbl1);
            this.CtrlGrBCity.Controls.Add(this.CtrlNumCityWidth);
            this.CtrlGrBCity.Location = new System.Drawing.Point(468, 65);
            this.CtrlGrBCity.Name = "CtrlGrBCity";
            this.CtrlGrBCity.Size = new System.Drawing.Size(113, 114);
            this.CtrlGrBCity.TabIndex = 12;
            this.CtrlGrBCity.TabStop = false;
            this.CtrlGrBCity.Text = "Разметка города";
            // 
            // CtrlButMark
            // 
            this.CtrlButMark.Location = new System.Drawing.Point(6, 75);
            this.CtrlButMark.Name = "CtrlButMark";
            this.CtrlButMark.Size = new System.Drawing.Size(97, 26);
            this.CtrlButMark.TabIndex = 1;
            this.CtrlButMark.Text = "Разметить";
            this.CtrlButMark.UseVisualStyleBackColor = true;
            this.CtrlButMark.Click += new System.EventHandler(this.CtrlButMark_Click);
            // 
            // CtrlMiscLbl2
            // 
            this.CtrlMiscLbl2.AutoSize = true;
            this.CtrlMiscLbl2.Location = new System.Drawing.Point(4, 51);
            this.CtrlMiscLbl2.Name = "CtrlMiscLbl2";
            this.CtrlMiscLbl2.Size = new System.Drawing.Size(45, 13);
            this.CtrlMiscLbl2.TabIndex = 5;
            this.CtrlMiscLbl2.Text = "Высота";
            // 
            // CtrlNumCityHeight
            // 
            this.CtrlNumCityHeight.Location = new System.Drawing.Point(54, 49);
            this.CtrlNumCityHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CtrlNumCityHeight.Name = "CtrlNumCityHeight";
            this.CtrlNumCityHeight.Size = new System.Drawing.Size(48, 20);
            this.CtrlNumCityHeight.TabIndex = 2;
            this.CtrlNumCityHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CtrlMiscLbl1
            // 
            this.CtrlMiscLbl1.AutoSize = true;
            this.CtrlMiscLbl1.Location = new System.Drawing.Point(4, 25);
            this.CtrlMiscLbl1.Name = "CtrlMiscLbl1";
            this.CtrlMiscLbl1.Size = new System.Drawing.Size(46, 13);
            this.CtrlMiscLbl1.TabIndex = 4;
            this.CtrlMiscLbl1.Text = "Ширина";
            // 
            // CtrlNumCityWidth
            // 
            this.CtrlNumCityWidth.Location = new System.Drawing.Point(54, 23);
            this.CtrlNumCityWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CtrlNumCityWidth.Name = "CtrlNumCityWidth";
            this.CtrlNumCityWidth.Size = new System.Drawing.Size(48, 20);
            this.CtrlNumCityWidth.TabIndex = 3;
            this.CtrlNumCityWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CtrlPicBxCity
            // 
            this.CtrlPicBxCity.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CtrlPicBxCity.Location = new System.Drawing.Point(12, 13);
            this.CtrlPicBxCity.Name = "CtrlPicBxCity";
            this.CtrlPicBxCity.Size = new System.Drawing.Size(450, 450);
            this.CtrlPicBxCity.TabIndex = 11;
            this.CtrlPicBxCity.TabStop = false;
            this.CtrlPicBxCity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxCity_MouseDown);
            this.CtrlPicBxCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxCity_MouseMove);
            this.CtrlPicBxCity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxCity_MouseUp);
            // 
            // FormCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 476);
            this.Controls.Add(this.CtrlButReady);
            this.Controls.Add(this.CtrlLblMisc5);
            this.Controls.Add(this.CtrlTxbCityName);
            this.Controls.Add(this.CtrlGrBHouse);
            this.Controls.Add(this.CtrlGrBCity);
            this.Controls.Add(this.CtrlPicBxCity);
            this.Name = "FormCity";
            this.Text = "FormCity";
            this.CtrlGrBHouse.ResumeLayout(false);
            this.CtrlGrBHouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumHouseHeigth)).EndInit();
            this.CtrlGrBCity.ResumeLayout(false);
            this.CtrlGrBCity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlNumCityWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxCity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CtrlButReady;
        private System.Windows.Forms.Label CtrlLblMisc5;
        private System.Windows.Forms.TextBox CtrlTxbCityName;
        private System.Windows.Forms.GroupBox CtrlGrBHouse;
        private System.Windows.Forms.Button CtrlButHouse;
        private System.Windows.Forms.Label CtrlLblMisc4;
        private System.Windows.Forms.NumericUpDown CtrlNumHouseWidth;
        private System.Windows.Forms.Label CtrlLblMisc3;
        private System.Windows.Forms.NumericUpDown CtrlNumHouseHeigth;
        private System.Windows.Forms.GroupBox CtrlGrBCity;
        private System.Windows.Forms.Button CtrlButMark;
        private System.Windows.Forms.Label CtrlMiscLbl2;
        private System.Windows.Forms.NumericUpDown CtrlNumCityHeight;
        private System.Windows.Forms.Label CtrlMiscLbl1;
        private System.Windows.Forms.NumericUpDown CtrlNumCityWidth;
        private System.Windows.Forms.PictureBox CtrlPicBxCity;
    }
}