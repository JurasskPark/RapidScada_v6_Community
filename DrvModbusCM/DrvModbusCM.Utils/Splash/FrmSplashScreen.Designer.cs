namespace Splash
{
    partial class SplashScreen
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            lblTime = new Label();
            lblStatus = new Label();
            lblTitle = new Label();
            lblFrame = new Panel();
            pnlStatus = new Panel();
            picLoad = new PictureBox();
            tmrTimer = new System.Windows.Forms.Timer(components);
            lblFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLoad).BeginInit();
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(10, 193);
            lblTime.Margin = new Padding(6, 0, 6, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(0, 25);
            lblTime.TabIndex = 6;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(10, 158);
            lblStatus.Margin = new Padding(6, 0, 6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 25);
            lblStatus.TabIndex = 5;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(6, 10);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(667, 32);
            lblTitle.TabIndex = 4;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFrame
            // 
            lblFrame.BorderStyle = BorderStyle.FixedSingle;
            lblFrame.Controls.Add(pnlStatus);
            lblFrame.Controls.Add(picLoad);
            lblFrame.Controls.Add(lblTitle);
            lblFrame.Location = new Point(3, 3);
            lblFrame.Margin = new Padding(6, 5, 6, 5);
            lblFrame.Name = "lblFrame";
            lblFrame.Size = new Size(679, 272);
            lblFrame.TabIndex = 7;
            // 
            // pnlStatus
            // 
            pnlStatus.ForeColor = Color.FromArgb(0, 192, 0);
            pnlStatus.Location = new Point(6, 225);
            pnlStatus.Margin = new Padding(4, 5, 4, 5);
            pnlStatus.Name = "pnlStatus";
            pnlStatus.Size = new Size(667, 38);
            pnlStatus.TabIndex = 1;
            // 
            // picLoad
            // 
            picLoad.ErrorImage = null;
            picLoad.Image = (Image)resources.GetObject("picLoad.Image");
            picLoad.Location = new Point(280, 53);
            picLoad.Margin = new Padding(6, 5, 6, 5);
            picLoad.Name = "picLoad";
            picLoad.Size = new Size(119, 100);
            picLoad.SizeMode = PictureBoxSizeMode.StretchImage;
            picLoad.TabIndex = 0;
            picLoad.TabStop = false;
            // 
            // tmrTimer
            // 
            tmrTimer.Tick += tmrTimer_Tick;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(686, 280);
            ControlBox = false;
            Controls.Add(lblTime);
            Controls.Add(lblStatus);
            Controls.Add(lblFrame);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6, 5, 6, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SplashScreen";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Splash";
            lblFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLoad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public System.Windows.Forms.Label lblTime;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel lblFrame;
        private System.Windows.Forms.PictureBox picLoad;
        private System.Windows.Forms.Timer tmrTimer;
        private Panel pnlStatus;
    }
}