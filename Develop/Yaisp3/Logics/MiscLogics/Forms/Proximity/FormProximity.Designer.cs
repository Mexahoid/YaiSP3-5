namespace AgencySimulator
{
    partial class FormProximity
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
            this.CtrlPicBx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBx)).BeginInit();
            this.SuspendLayout();
            // 
            // CtrlPicBx
            // 
            this.CtrlPicBx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CtrlPicBx.Location = new System.Drawing.Point(12, 12);
            this.CtrlPicBx.Name = "CtrlPicBx";
            this.CtrlPicBx.Size = new System.Drawing.Size(500, 500);
            this.CtrlPicBx.TabIndex = 0;
            this.CtrlPicBx.TabStop = false;
            this.CtrlPicBx.Click += new System.EventHandler(this.CtrlPicBx_Click);
            this.CtrlPicBx.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBx_MouseDown);
            this.CtrlPicBx.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBx_MouseMove);
            this.CtrlPicBx.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CtrlPicBx_MouseUp);
            // 
            // FormProximity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 521);
            this.Controls.Add(this.CtrlPicBx);
            this.Name = "FormProximity";
            this.Text = "Зоны покрытия";
            ((System.ComponentModel.ISupportInitialize)(this.CtrlPicBx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CtrlPicBx;
    }
}