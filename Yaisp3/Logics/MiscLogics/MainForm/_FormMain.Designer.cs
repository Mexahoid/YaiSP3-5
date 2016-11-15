namespace Yaisp3
{
    partial class _FormMain
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
            this.components = new System.ComponentModel.Container();
            this._ctrlPicBxMap = new System.Windows.Forms.PictureBox();
            this._ctrlPicBxGraph = new System.Windows.Forms.PictureBox();
            this._ctrlLblMisc1 = new System.Windows.Forms.Label();
            this._ctrlLblDate = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._ctrlMainStrip = new System.Windows.Forms.ToolStrip();
            this._ctrlTSMIDrop = new System.Windows.Forms.ToolStripDropDownButton();
            this._ctrlTSMICreateCity = new System.Windows.Forms.ToolStripMenuItem();
            this._ctrlTSMIAgencyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._ctrlTSMIAgencyDelete = new System.Windows.Forms.ToolStripMenuItem();
            this._ctrlTimer = new System.Windows.Forms.Timer(this.components);
            this._ctrlButTimerPause = new System.Windows.Forms.Button();
            this._ctrlButTimerStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._ctrlTBSpeed = new System.Windows.Forms.TrackBar();
            this._ctrlChBIndCity = new System.Windows.Forms.CheckBox();
            this._ctrlChBIndAgen = new System.Windows.Forms.CheckBox();
            this._ctrlGrbIndic = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxGraph)).BeginInit();
            this._ctrlMainStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlTBSpeed)).BeginInit();
            this._ctrlGrbIndic.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ctrlPicBxMap
            // 
            this._ctrlPicBxMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._ctrlPicBxMap.Location = new System.Drawing.Point(15, 41);
            this._ctrlPicBxMap.Name = "_ctrlPicBxMap";
            this._ctrlPicBxMap.Size = new System.Drawing.Size(635, 635);
            this._ctrlPicBxMap.TabIndex = 0;
            this._ctrlPicBxMap.TabStop = false;
            this._ctrlPicBxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxMap_MouseDown);
            this._ctrlPicBxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxMap_MouseMove);
            this._ctrlPicBxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this._ctrlPicBxMap_MouseUp);
            // 
            // _ctrlPicBxGraph
            // 
            this._ctrlPicBxGraph.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._ctrlPicBxGraph.Location = new System.Drawing.Point(705, 410);
            this._ctrlPicBxGraph.Name = "_ctrlPicBxGraph";
            this._ctrlPicBxGraph.Size = new System.Drawing.Size(100, 50);
            this._ctrlPicBxGraph.TabIndex = 1;
            this._ctrlPicBxGraph.TabStop = false;
            // 
            // _ctrlLblMisc1
            // 
            this._ctrlLblMisc1.AutoSize = true;
            this._ctrlLblMisc1.Location = new System.Drawing.Point(12, 25);
            this._ctrlLblMisc1.Name = "_ctrlLblMisc1";
            this._ctrlLblMisc1.Size = new System.Drawing.Size(75, 13);
            this._ctrlLblMisc1.TabIndex = 2;
            this._ctrlLblMisc1.Text = "Карта города";
            // 
            // _ctrlLblDate
            // 
            this._ctrlLblDate.AutoSize = true;
            this._ctrlLblDate.Location = new System.Drawing.Point(6, 24);
            this._ctrlLblDate.Name = "_ctrlLblDate";
            this._ctrlLblDate.Size = new System.Drawing.Size(93, 13);
            this._ctrlLblDate.TabIndex = 3;
            this._ctrlLblDate.Text = "Дата: 01.01.1970";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(804, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(731, 324);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // _ctrlMainStrip
            // 
            this._ctrlMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ctrlTSMIDrop});
            this._ctrlMainStrip.Location = new System.Drawing.Point(0, 0);
            this._ctrlMainStrip.Name = "_ctrlMainStrip";
            this._ctrlMainStrip.Size = new System.Drawing.Size(911, 25);
            this._ctrlMainStrip.TabIndex = 6;
            this._ctrlMainStrip.Text = "toolStrip1";
            // 
            // _ctrlTSMIDrop
            // 
            this._ctrlTSMIDrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._ctrlTSMIDrop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ctrlTSMICreateCity,
            this._ctrlTSMIAgencyMenu,
            this._ctrlTSMIAgencyDelete});
            this._ctrlTSMIDrop.Name = "_ctrlTSMIDrop";
            this._ctrlTSMIDrop.Size = new System.Drawing.Size(49, 22);
            this._ctrlTSMIDrop.Text = "Меню";
            this._ctrlTSMIDrop.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // _ctrlTSMICreateCity
            // 
            this._ctrlTSMICreateCity.Name = "_ctrlTSMICreateCity";
            this._ctrlTSMICreateCity.Size = new System.Drawing.Size(184, 22);
            this._ctrlTSMICreateCity.Text = "Создать город";
            this._ctrlTSMICreateCity.Click += new System.EventHandler(this._ctrlTSMICreateCity_Click);
            // 
            // _ctrlTSMIAgencyMenu
            // 
            this._ctrlTSMIAgencyMenu.Name = "_ctrlTSMIAgencyMenu";
            this._ctrlTSMIAgencyMenu.Size = new System.Drawing.Size(184, 22);
            this._ctrlTSMIAgencyMenu.Text = "Меню агентства";
            this._ctrlTSMIAgencyMenu.Click += new System.EventHandler(this._ctrlTSMIAgencyMenu_Click);
            // 
            // _ctrlTSMIAgencyDelete
            // 
            this._ctrlTSMIAgencyDelete.Name = "_ctrlTSMIAgencyDelete";
            this._ctrlTSMIAgencyDelete.Size = new System.Drawing.Size(184, 22);
            this._ctrlTSMIAgencyDelete.Text = "Удалить агентство";
            this._ctrlTSMIAgencyDelete.Click += new System.EventHandler(this._ctrlTSMIAgencyDelete_Click);
            // 
            // _ctrlTimer
            // 
            this._ctrlTimer.Tick += new System.EventHandler(this._ctrlTimer_Tick);
            // 
            // _ctrlButTimerPause
            // 
            this._ctrlButTimerPause.Enabled = false;
            this._ctrlButTimerPause.Location = new System.Drawing.Point(133, 19);
            this._ctrlButTimerPause.Name = "_ctrlButTimerPause";
            this._ctrlButTimerPause.Size = new System.Drawing.Size(91, 23);
            this._ctrlButTimerPause.TabIndex = 7;
            this._ctrlButTimerPause.Text = "Пауза";
            this._ctrlButTimerPause.UseVisualStyleBackColor = true;
            this._ctrlButTimerPause.Click += new System.EventHandler(this._ctrlButTimerPause_Click);
            // 
            // _ctrlButTimerStart
            // 
            this._ctrlButTimerStart.Enabled = false;
            this._ctrlButTimerStart.Location = new System.Drawing.Point(668, 162);
            this._ctrlButTimerStart.Name = "_ctrlButTimerStart";
            this._ctrlButTimerStart.Size = new System.Drawing.Size(75, 23);
            this._ctrlButTimerStart.TabIndex = 8;
            this._ctrlButTimerStart.Text = "Начать";
            this._ctrlButTimerStart.UseVisualStyleBackColor = true;
            this._ctrlButTimerStart.Click += new System.EventHandler(this._ctrlButTimerStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._ctrlTBSpeed);
            this.groupBox1.Controls.Add(this._ctrlButTimerPause);
            this.groupBox1.Controls.Add(this._ctrlLblDate);
            this.groupBox1.Location = new System.Drawing.Point(668, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 101);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление временем";
            // 
            // _ctrlTBSpeed
            // 
            this._ctrlTBSpeed.Location = new System.Drawing.Point(6, 49);
            this._ctrlTBSpeed.Maximum = 25;
            this._ctrlTBSpeed.Minimum = 1;
            this._ctrlTBSpeed.Name = "_ctrlTBSpeed";
            this._ctrlTBSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._ctrlTBSpeed.Size = new System.Drawing.Size(218, 42);
            this._ctrlTBSpeed.TabIndex = 8;
            this._ctrlTBSpeed.Value = 10;
            this._ctrlTBSpeed.Scroll += new System.EventHandler(this._ctrlTBSpeed_Scroll);
            // 
            // _ctrlChBIndCity
            // 
            this._ctrlChBIndCity.AutoSize = true;
            this._ctrlChBIndCity.Enabled = false;
            this._ctrlChBIndCity.Location = new System.Drawing.Point(6, 19);
            this._ctrlChBIndCity.Name = "_ctrlChBIndCity";
            this._ctrlChBIndCity.Size = new System.Drawing.Size(56, 17);
            this._ctrlChBIndCity.TabIndex = 10;
            this._ctrlChBIndCity.Text = "Город";
            this._ctrlChBIndCity.UseVisualStyleBackColor = true;
            // 
            // _ctrlChBIndAgen
            // 
            this._ctrlChBIndAgen.AutoSize = true;
            this._ctrlChBIndAgen.Enabled = false;
            this._ctrlChBIndAgen.Location = new System.Drawing.Point(6, 42);
            this._ctrlChBIndAgen.Name = "_ctrlChBIndAgen";
            this._ctrlChBIndAgen.Size = new System.Drawing.Size(78, 17);
            this._ctrlChBIndAgen.TabIndex = 11;
            this._ctrlChBIndAgen.Text = "Агентство";
            this._ctrlChBIndAgen.UseVisualStyleBackColor = true;
            // 
            // _ctrlGrbIndic
            // 
            this._ctrlGrbIndic.Controls.Add(this._ctrlChBIndCity);
            this._ctrlGrbIndic.Controls.Add(this._ctrlChBIndAgen);
            this._ctrlGrbIndic.Location = new System.Drawing.Point(812, 162);
            this._ctrlGrbIndic.Name = "_ctrlGrbIndic";
            this._ctrlGrbIndic.Size = new System.Drawing.Size(87, 66);
            this._ctrlGrbIndic.TabIndex = 12;
            this._ctrlGrbIndic.TabStop = false;
            this._ctrlGrbIndic.Text = "Готовность";
            // 
            // _FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 691);
            this.Controls.Add(this._ctrlGrbIndic);
            this.Controls.Add(this._ctrlButTimerStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._ctrlMainStrip);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._ctrlLblMisc1);
            this.Controls.Add(this._ctrlPicBxGraph);
            this.Controls.Add(this._ctrlPicBxMap);
            this.Name = "_FormMain";
            this.Text = "Рекламное баннерное агентство";
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlPicBxGraph)).EndInit();
            this._ctrlMainStrip.ResumeLayout(false);
            this._ctrlMainStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ctrlTBSpeed)).EndInit();
            this._ctrlGrbIndic.ResumeLayout(false);
            this._ctrlGrbIndic.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _ctrlPicBxMap;
        private System.Windows.Forms.PictureBox _ctrlPicBxGraph;
        private System.Windows.Forms.Label _ctrlLblMisc1;
    private System.Windows.Forms.Label _ctrlLblDate;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ToolStrip _ctrlMainStrip;
    private System.Windows.Forms.ToolStripDropDownButton _ctrlTSMIDrop;
    private System.Windows.Forms.ToolStripMenuItem _ctrlTSMIAgencyMenu;
    private System.Windows.Forms.ToolStripMenuItem _ctrlTSMIAgencyDelete;
    private System.Windows.Forms.ToolStripMenuItem _ctrlTSMICreateCity;
    private System.Windows.Forms.Timer _ctrlTimer;
    private System.Windows.Forms.Button _ctrlButTimerPause;
    private System.Windows.Forms.Button _ctrlButTimerStart;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TrackBar _ctrlTBSpeed;
    private System.Windows.Forms.CheckBox _ctrlChBIndCity;
    private System.Windows.Forms.CheckBox _ctrlChBIndAgen;
    private System.Windows.Forms.GroupBox _ctrlGrbIndic;
  }
}

