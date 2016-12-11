namespace AgencySimulator
{
    partial class FormGraph
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
            this.CtrlPicBxGraph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlPicBxGraph
            // 
            this.CtrlPicBxGraph.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CtrlPicBxGraph.Location = new System.Drawing.Point(12, 12);
            this.CtrlPicBxGraph.Name = "CtrlPicBxGraph";
            this.CtrlPicBxGraph.Size = new System.Drawing.Size(548, 501);
            this.CtrlPicBxGraph.TabIndex = 0;
            this.CtrlPicBxGraph.TabStop = false;
            this.CtrlPicBxGraph.Click += new System.EventHandler(this.CtrlPicBxGraph_Click);
            this.CtrlPicBxGraph.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxGraph_MouseDown);
            this.CtrlPicBxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxGraph_MouseMove);
            this.CtrlPicBxGraph.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBxGraph_MouseUp);
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 525);
            this.Controls.Add(this.CtrlPicBxGraph);
            this.Name = "FormGraph";
            this.Text = "График доходов";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBxGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CtrlPicBxGraph;
    }
}