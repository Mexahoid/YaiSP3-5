namespace Yaisp3
{
    partial class FormMain
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
            this.CtrlPicBxMap = new System.Windows.Forms.PictureBox();
            this.CtrlLblMisc1 = new System.Windows.Forms.Label();
            this.CtrlLblDate = new System.Windows.Forms.Label();
            this.CtrlMainStrip = new System.Windows.Forms.ToolStrip();
            this.CtrlTSMIDrop = new System.Windows.Forms.ToolStripDropDownButton();
            this.CtrlTSMICreateCity = new System.Windows.Forms.ToolStripMenuItem();
            this.CtrlTSMIAgencyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CtrlTSMIAgencyDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.CtrlTSMIProximityMap = new System.Windows.Forms.ToolStripMenuItem();
            this.CtrlTSMIGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.CtrlTimer = new System.Windows.Forms.Timer(this.components);
            this.CtrlButTimerPause = new System.Windows.Forms.Button();
            this.CtrlButTimerStart = new System.Windows.Forms.Button();
            this.CtrlGrBTime = new System.Windows.Forms.GroupBox();
            this.CtrlLblMisc3 = new System.Windows.Forms.Label();
            this.CtrlLblMisc2 = new System.Windows.Forms.Label();
            this.CtrlTBSpeed = new System.Windows.Forms.TrackBar();
            this.CtrlChBIndCity = new System.Windows.Forms.CheckBox();
            this.CtrlChBIndAgen = new System.Windows.Forms.CheckBox();
            this.CtrlGrbIndic = new System.Windows.Forms.GroupBox();
            this.CtrlGrBQueue = new System.Windows.Forms.GroupBox();
            this.CtrlLblMisc7 = new System.Windows.Forms.Label();
            this.CtrlLblMisc6 = new System.Windows.Forms.Label();
            this.CtrlTBQueueIntense = new System.Windows.Forms.TrackBar();
            this.CtrlLblMisc5 = new System.Windows.Forms.Label();
            this.CtrlLblMisc4 = new System.Windows.Forms.Label();
            this.CtrlTBQueueQuantity = new System.Windows.Forms.TrackBar();
            this.CtrlTxbOrders = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxMap)).BeginInit();
            this.CtrlMainStrip.SuspendLayout();
            this.CtrlGrBTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBSpeed)).BeginInit();
            this.CtrlGrbIndic.SuspendLayout();
            this.CtrlGrBQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBQueueIntense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBQueueQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlPicBxMap
            // 
            this.CtrlPicBxMap.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CtrlPicBxMap.Location = new System.Drawing.Point(15, 41);
            this.CtrlPicBxMap.Name = "CtrlPicBxMap";
            this.CtrlPicBxMap.Size = new System.Drawing.Size(635, 635);
            this.CtrlPicBxMap.TabIndex = 0;
            this.CtrlPicBxMap.TabStop = false;
            this.CtrlPicBxMap.Click += new System.EventHandler(this.CtrlPicBxMap_Click);
            this.CtrlPicBxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxMap_MouseDown);
            this.CtrlPicBxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxMap_MouseMove);
            this.CtrlPicBxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxMap_MouseUp);
            // 
            // CtrlLblMisc1
            // 
            this.CtrlLblMisc1.AutoSize = true;
            this.CtrlLblMisc1.Location = new System.Drawing.Point(12, 25);
            this.CtrlLblMisc1.Name = "CtrlLblMisc1";
            this.CtrlLblMisc1.Size = new System.Drawing.Size(75, 13);
            this.CtrlLblMisc1.TabIndex = 2;
            this.CtrlLblMisc1.Text = "Карта города";
            // 
            // CtrlLblDate
            // 
            this.CtrlLblDate.AutoSize = true;
            this.CtrlLblDate.Location = new System.Drawing.Point(6, 24);
            this.CtrlLblDate.Name = "CtrlLblDate";
            this.CtrlLblDate.Size = new System.Drawing.Size(93, 13);
            this.CtrlLblDate.TabIndex = 3;
            this.CtrlLblDate.Text = "Дата: 01.01.1970";
            // 
            // CtrlMainStrip
            // 
            this.CtrlMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtrlTSMIDrop});
            this.CtrlMainStrip.Location = new System.Drawing.Point(0, 0);
            this.CtrlMainStrip.Name = "CtrlMainStrip";
            this.CtrlMainStrip.Size = new System.Drawing.Size(911, 25);
            this.CtrlMainStrip.TabIndex = 6;
            this.CtrlMainStrip.Text = "toolStrip1";
            // 
            // CtrlTSMIDrop
            // 
            this.CtrlTSMIDrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CtrlTSMIDrop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtrlTSMICreateCity,
            this.CtrlTSMIAgencyMenu,
            this.CtrlTSMIAgencyDelete,
            this.CtrlTSMIProximityMap,
            this.CtrlTSMIGraph});
            this.CtrlTSMIDrop.Name = "CtrlTSMIDrop";
            this.CtrlTSMIDrop.Size = new System.Drawing.Size(54, 22);
            this.CtrlTSMIDrop.Text = "Меню";
            this.CtrlTSMIDrop.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.CtrlTSMIDrop.Click += new System.EventHandler(this.CtrlTSMIDrop_Click);
            // 
            // CtrlTSMICreateCity
            // 
            this.CtrlTSMICreateCity.Name = "CtrlTSMICreateCity";
            this.CtrlTSMICreateCity.Size = new System.Drawing.Size(174, 22);
            this.CtrlTSMICreateCity.Text = "Создать город";
            this.CtrlTSMICreateCity.Click += new System.EventHandler(this.CtrlTSMICreateCityClick);
            // 
            // CtrlTSMIAgencyMenu
            // 
            this.CtrlTSMIAgencyMenu.Enabled = false;
            this.CtrlTSMIAgencyMenu.Name = "CtrlTSMIAgencyMenu";
            this.CtrlTSMIAgencyMenu.Size = new System.Drawing.Size(174, 22);
            this.CtrlTSMIAgencyMenu.Text = "Меню агентства";
            this.CtrlTSMIAgencyMenu.Click += new System.EventHandler(this.CtrlTSMIAgencyMenuClick);
            // 
            // CtrlTSMIAgencyDelete
            // 
            this.CtrlTSMIAgencyDelete.Enabled = false;
            this.CtrlTSMIAgencyDelete.Name = "CtrlTSMIAgencyDelete";
            this.CtrlTSMIAgencyDelete.Size = new System.Drawing.Size(174, 22);
            this.CtrlTSMIAgencyDelete.Text = "Удалить агентство";
            this.CtrlTSMIAgencyDelete.Click += new System.EventHandler(this.CtrlTSMIAgencyDeleteClick);
            // 
            // CtrlTSMIProximityMap
            // 
            this.CtrlTSMIProximityMap.Name = "CtrlTSMIProximityMap";
            this.CtrlTSMIProximityMap.Size = new System.Drawing.Size(174, 22);
            this.CtrlTSMIProximityMap.Text = "Зоны покрытия";
            this.CtrlTSMIProximityMap.Click += new System.EventHandler(this.CtrlTSMIProximityMapClick);
            // 
            // CtrlTSMIGraph
            // 
            this.CtrlTSMIGraph.Name = "CtrlTSMIGraph";
            this.CtrlTSMIGraph.Size = new System.Drawing.Size(174, 22);
            this.CtrlTSMIGraph.Text = "График бюджета";
            this.CtrlTSMIGraph.Click += new System.EventHandler(this.CtrlTSMIGraph_Click);
            // 
            // CtrlTimer
            // 
            this.CtrlTimer.Interval = 500;
            this.CtrlTimer.Tick += new System.EventHandler(this.CtrlTimer_Tick);
            // 
            // CtrlButTimerPause
            // 
            this.CtrlButTimerPause.Enabled = false;
            this.CtrlButTimerPause.Location = new System.Drawing.Point(133, 19);
            this.CtrlButTimerPause.Name = "CtrlButTimerPause";
            this.CtrlButTimerPause.Size = new System.Drawing.Size(91, 23);
            this.CtrlButTimerPause.TabIndex = 7;
            this.CtrlButTimerPause.Text = "Пауза";
            this.CtrlButTimerPause.UseVisualStyleBackColor = true;
            this.CtrlButTimerPause.Click += new System.EventHandler(this.CtrlButTimerPauseClick);
            // 
            // CtrlButTimerStart
            // 
            this.CtrlButTimerStart.Enabled = false;
            this.CtrlButTimerStart.Location = new System.Drawing.Point(817, 375);
            this.CtrlButTimerStart.Name = "CtrlButTimerStart";
            this.CtrlButTimerStart.Size = new System.Drawing.Size(75, 23);
            this.CtrlButTimerStart.TabIndex = 8;
            this.CtrlButTimerStart.Text = "Начать";
            this.CtrlButTimerStart.UseVisualStyleBackColor = true;
            this.CtrlButTimerStart.Click += new System.EventHandler(this.CtrlButTimerStartClick);
            // 
            // CtrlGrBTime
            // 
            this.CtrlGrBTime.Controls.Add(this.CtrlLblMisc3);
            this.CtrlGrBTime.Controls.Add(this.CtrlLblMisc2);
            this.CtrlGrBTime.Controls.Add(this.CtrlTBSpeed);
            this.CtrlGrBTime.Controls.Add(this.CtrlButTimerPause);
            this.CtrlGrBTime.Controls.Add(this.CtrlLblDate);
            this.CtrlGrBTime.Location = new System.Drawing.Point(668, 41);
            this.CtrlGrBTime.Name = "CtrlGrBTime";
            this.CtrlGrBTime.Size = new System.Drawing.Size(230, 101);
            this.CtrlGrBTime.TabIndex = 9;
            this.CtrlGrBTime.TabStop = false;
            this.CtrlGrBTime.Text = "Управление временем";
            // 
            // CtrlLblMisc3
            // 
            this.CtrlLblMisc3.AutoSize = true;
            this.CtrlLblMisc3.Location = new System.Drawing.Point(179, 85);
            this.CtrlLblMisc3.Name = "CtrlLblMisc3";
            this.CtrlLblMisc3.Size = new System.Drawing.Size(45, 13);
            this.CtrlLblMisc3.TabIndex = 10;
            this.CtrlLblMisc3.Text = "Быстро";
            // 
            // CtrlLblMisc2
            // 
            this.CtrlLblMisc2.AutoSize = true;
            this.CtrlLblMisc2.Location = new System.Drawing.Point(6, 85);
            this.CtrlLblMisc2.Name = "CtrlLblMisc2";
            this.CtrlLblMisc2.Size = new System.Drawing.Size(58, 13);
            this.CtrlLblMisc2.TabIndex = 9;
            this.CtrlLblMisc2.Text = "Медленно";
            // 
            // CtrlTBSpeed
            // 
            this.CtrlTBSpeed.Location = new System.Drawing.Point(6, 49);
            this.CtrlTBSpeed.Maximum = 25;
            this.CtrlTBSpeed.Minimum = 1;
            this.CtrlTBSpeed.Name = "CtrlTBSpeed";
            this.CtrlTBSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CtrlTBSpeed.Size = new System.Drawing.Size(218, 45);
            this.CtrlTBSpeed.TabIndex = 8;
            this.CtrlTBSpeed.Value = 25;
            this.CtrlTBSpeed.Scroll += new System.EventHandler(this.CtrlTBSpeed_Scroll);
            // 
            // CtrlChBIndCity
            // 
            this.CtrlChBIndCity.AutoSize = true;
            this.CtrlChBIndCity.Enabled = false;
            this.CtrlChBIndCity.Location = new System.Drawing.Point(6, 19);
            this.CtrlChBIndCity.Name = "CtrlChBIndCity";
            this.CtrlChBIndCity.Size = new System.Drawing.Size(56, 17);
            this.CtrlChBIndCity.TabIndex = 10;
            this.CtrlChBIndCity.Text = "Город";
            this.CtrlChBIndCity.UseVisualStyleBackColor = true;
            // 
            // CtrlChBIndAgen
            // 
            this.CtrlChBIndAgen.AutoSize = true;
            this.CtrlChBIndAgen.Enabled = false;
            this.CtrlChBIndAgen.Location = new System.Drawing.Point(6, 42);
            this.CtrlChBIndAgen.Name = "CtrlChBIndAgen";
            this.CtrlChBIndAgen.Size = new System.Drawing.Size(78, 17);
            this.CtrlChBIndAgen.TabIndex = 11;
            this.CtrlChBIndAgen.Text = "Агентство";
            this.CtrlChBIndAgen.UseVisualStyleBackColor = true;
            // 
            // CtrlGrbIndic
            // 
            this.CtrlGrbIndic.Controls.Add(this.CtrlChBIndCity);
            this.CtrlGrbIndic.Controls.Add(this.CtrlChBIndAgen);
            this.CtrlGrbIndic.Location = new System.Drawing.Point(667, 333);
            this.CtrlGrbIndic.Name = "CtrlGrbIndic";
            this.CtrlGrbIndic.Size = new System.Drawing.Size(89, 66);
            this.CtrlGrbIndic.TabIndex = 12;
            this.CtrlGrbIndic.TabStop = false;
            this.CtrlGrbIndic.Text = "Готовность";
            // 
            // CtrlGrBQueue
            // 
            this.CtrlGrBQueue.Controls.Add(this.CtrlLblMisc7);
            this.CtrlGrBQueue.Controls.Add(this.CtrlLblMisc6);
            this.CtrlGrBQueue.Controls.Add(this.CtrlTBQueueIntense);
            this.CtrlGrBQueue.Controls.Add(this.CtrlLblMisc5);
            this.CtrlGrBQueue.Controls.Add(this.CtrlLblMisc4);
            this.CtrlGrBQueue.Controls.Add(this.CtrlTBQueueQuantity);
            this.CtrlGrBQueue.Location = new System.Drawing.Point(668, 158);
            this.CtrlGrBQueue.Name = "CtrlGrBQueue";
            this.CtrlGrBQueue.Size = new System.Drawing.Size(230, 123);
            this.CtrlGrBQueue.TabIndex = 13;
            this.CtrlGrBQueue.TabStop = false;
            this.CtrlGrBQueue.Text = "Интенсивность заказов";
            // 
            // CtrlLblMisc7
            // 
            this.CtrlLblMisc7.AutoSize = true;
            this.CtrlLblMisc7.Location = new System.Drawing.Point(188, 102);
            this.CtrlLblMisc7.Name = "CtrlLblMisc7";
            this.CtrlLblMisc7.Size = new System.Drawing.Size(36, 13);
            this.CtrlLblMisc7.TabIndex = 14;
            this.CtrlLblMisc7.Text = "Чаще";
            // 
            // CtrlLblMisc6
            // 
            this.CtrlLblMisc6.AutoSize = true;
            this.CtrlLblMisc6.Location = new System.Drawing.Point(6, 102);
            this.CtrlLblMisc6.Name = "CtrlLblMisc6";
            this.CtrlLblMisc6.Size = new System.Drawing.Size(34, 13);
            this.CtrlLblMisc6.TabIndex = 13;
            this.CtrlLblMisc6.Text = "Реже";
            // 
            // CtrlTBQueueIntense
            // 
            this.CtrlTBQueueIntense.Location = new System.Drawing.Point(6, 70);
            this.CtrlTBQueueIntense.Maximum = 12;
            this.CtrlTBQueueIntense.Name = "CtrlTBQueueIntense";
            this.CtrlTBQueueIntense.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CtrlTBQueueIntense.Size = new System.Drawing.Size(218, 45);
            this.CtrlTBQueueIntense.TabIndex = 12;
            this.CtrlTBQueueIntense.Value = 1;
            // 
            // CtrlLblMisc5
            // 
            this.CtrlLblMisc5.AutoSize = true;
            this.CtrlLblMisc5.Location = new System.Drawing.Point(177, 51);
            this.CtrlLblMisc5.Name = "CtrlLblMisc5";
            this.CtrlLblMisc5.Size = new System.Drawing.Size(46, 13);
            this.CtrlLblMisc5.TabIndex = 11;
            this.CtrlLblMisc5.Text = "Больше";
            // 
            // CtrlLblMisc4
            // 
            this.CtrlLblMisc4.AutoSize = true;
            this.CtrlLblMisc4.Location = new System.Drawing.Point(6, 51);
            this.CtrlLblMisc4.Name = "CtrlLblMisc4";
            this.CtrlLblMisc4.Size = new System.Drawing.Size(48, 13);
            this.CtrlLblMisc4.TabIndex = 10;
            this.CtrlLblMisc4.Text = "Меньше";
            // 
            // CtrlTBQueueQuantity
            // 
            this.CtrlTBQueueQuantity.Location = new System.Drawing.Point(6, 19);
            this.CtrlTBQueueQuantity.Maximum = 12;
            this.CtrlTBQueueQuantity.Name = "CtrlTBQueueQuantity";
            this.CtrlTBQueueQuantity.Size = new System.Drawing.Size(218, 45);
            this.CtrlTBQueueQuantity.TabIndex = 9;
            this.CtrlTBQueueQuantity.Value = 1;
            // 
            // CtrlTxbOrders
            // 
            this.CtrlTxbOrders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CtrlTxbOrders.Location = new System.Drawing.Point(666, 405);
            this.CtrlTxbOrders.Multiline = true;
            this.CtrlTxbOrders.Name = "CtrlTxbOrders";
            this.CtrlTxbOrders.ReadOnly = true;
            this.CtrlTxbOrders.Size = new System.Drawing.Size(232, 119);
            this.CtrlTxbOrders.TabIndex = 14;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 691);
            this.Controls.Add(this.CtrlTxbOrders);
            this.Controls.Add(this.CtrlGrBQueue);
            this.Controls.Add(this.CtrlGrbIndic);
            this.Controls.Add(this.CtrlButTimerStart);
            this.Controls.Add(this.CtrlGrBTime);
            this.Controls.Add(this.CtrlMainStrip);
            this.Controls.Add(this.CtrlLblMisc1);
            this.Controls.Add(this.CtrlPicBxMap);
            this.Name = "FormMain";
            this.Text = "Рекламное баннерное агентство";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxMap)).EndInit();
            this.CtrlMainStrip.ResumeLayout(false);
            this.CtrlMainStrip.PerformLayout();
            this.CtrlGrBTime.ResumeLayout(false);
            this.CtrlGrBTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBSpeed)).EndInit();
            this.CtrlGrbIndic.ResumeLayout(false);
            this.CtrlGrbIndic.PerformLayout();
            this.CtrlGrBQueue.ResumeLayout(false);
            this.CtrlGrBQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBQueueIntense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlTBQueueQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CtrlPicBxMap;
        private System.Windows.Forms.ToolStrip CtrlMainStrip;
        private System.Windows.Forms.ToolStripDropDownButton CtrlTSMIDrop;
        private System.Windows.Forms.ToolStripMenuItem CtrlTSMICreateCity;
        private System.Windows.Forms.ToolStripMenuItem CtrlTSMIAgencyMenu;
        private System.Windows.Forms.ToolStripMenuItem CtrlTSMIAgencyDelete;
        private System.Windows.Forms.ToolStripMenuItem CtrlTSMIProximityMap;
        private System.Windows.Forms.ToolStripMenuItem CtrlTSMIGraph;
        private System.Windows.Forms.Timer CtrlTimer;
        private System.Windows.Forms.Button CtrlButTimerPause;
        private System.Windows.Forms.Button CtrlButTimerStart;
        private System.Windows.Forms.CheckBox CtrlChBIndCity;
        private System.Windows.Forms.CheckBox CtrlChBIndAgen;
        private System.Windows.Forms.GroupBox CtrlGrBTime;
        private System.Windows.Forms.GroupBox CtrlGrbIndic;
        private System.Windows.Forms.GroupBox CtrlGrBQueue;
        private System.Windows.Forms.TextBox CtrlTxbOrders;
        private System.Windows.Forms.Label CtrlLblDate;
        private System.Windows.Forms.Label CtrlLblMisc1;
        private System.Windows.Forms.Label CtrlLblMisc3;
        private System.Windows.Forms.Label CtrlLblMisc2;
        private System.Windows.Forms.Label CtrlLblMisc5;
        private System.Windows.Forms.Label CtrlLblMisc4;
        private System.Windows.Forms.Label CtrlLblMisc7;
        private System.Windows.Forms.Label CtrlLblMisc6;
        private System.Windows.Forms.TrackBar CtrlTBSpeed;
        private System.Windows.Forms.TrackBar CtrlTBQueueQuantity;
        private System.Windows.Forms.TrackBar CtrlTBQueueIntense;
    }
}

