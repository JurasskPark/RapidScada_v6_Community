namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class FrmSplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplashScreen));
            this.line3 = new System.Windows.Forms.Label();
            this.line2 = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.Label();
            this.line4 = new System.Windows.Forms.Panel();
            this.pic_Load = new System.Windows.Forms.PictureBox();
            this.line4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Load)).BeginInit();
            this.SuspendLayout();
            // 
            // line3
            // 
            this.line3.AutoSize = true;
            this.line3.Location = new System.Drawing.Point(7, 65);
            this.line3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.line3.Name = "line3";
            this.line3.Size = new System.Drawing.Size(0, 15);
            this.line3.TabIndex = 6;
            // 
            // line2
            // 
            this.line2.AutoSize = true;
            this.line2.Location = new System.Drawing.Point(7, 45);
            this.line2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(0, 15);
            this.line2.TabIndex = 5;
            // 
            // line1
            // 
            this.line1.AutoSize = true;
            this.line1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.line1.Location = new System.Drawing.Point(205, 15);
            this.line1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(91, 19);
            this.line1.TabIndex = 4;
            this.line1.Text = "Загрузка...";
            this.line1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line4
            // 
            this.line4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.line4.Controls.Add(this.pic_Load);
            this.line4.Location = new System.Drawing.Point(1, 1);
            this.line4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.line4.Name = "line4";
            this.line4.Size = new System.Drawing.Size(464, 83);
            this.line4.TabIndex = 7;
            // 
            // pic_Load
            // 
            this.pic_Load.ErrorImage = null;
            this.pic_Load.Image = ((System.Drawing.Image)(resources.GetObject("pic_Load.Image")));
            this.pic_Load.Location = new System.Drawing.Point(150, 3);
            this.pic_Load.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pic_Load.Name = "pic_Load";
            this.pic_Load.Size = new System.Drawing.Size(50, 35);
            this.pic_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Load.TabIndex = 0;
            this.pic_Load.TabStop = false;
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(467, 85);
            this.ControlBox = false;
            this.Controls.Add(this.line3);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.line4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SplashForm_FormClosing);
            this.line4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Load)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label line3;
        public System.Windows.Forms.Label line2;
        public System.Windows.Forms.Label line1;
        private System.Windows.Forms.Panel line4;
        private System.Windows.Forms.PictureBox pic_Load;
    }
}