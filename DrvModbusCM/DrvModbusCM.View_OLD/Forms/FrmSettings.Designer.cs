namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class FrmSettings
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
            gpbSettings = new GroupBox();
            ckbDebug = new CheckBox();
            btnOk = new Button();
            gpbSettings.SuspendLayout();
            SuspendLayout();
            // 
            // gpbSettings
            // 
            gpbSettings.Controls.Add(ckbDebug);
            gpbSettings.Location = new Point(12, 12);
            gpbSettings.Name = "gpbSettings";
            gpbSettings.Size = new Size(776, 96);
            gpbSettings.TabIndex = 0;
            gpbSettings.TabStop = false;
            gpbSettings.Text = "Settings";
            // 
            // ckbDebug
            // 
            ckbDebug.AutoSize = true;
            ckbDebug.Location = new Point(6, 22);
            ckbDebug.Name = "ckbDebug";
            ckbDebug.Size = new Size(61, 19);
            ckbDebug.TabIndex = 1;
            ckbDebug.Text = "Debug";
            ckbDebug.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(363, 114);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 144);
            Controls.Add(btnOk);
            Controls.Add(gpbSettings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSettings";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosing += FrmSettings_FormClosing;
            Load += FrmSettings_Load;
            gpbSettings.ResumeLayout(false);
            gpbSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbSettings;
        private CheckBox ckbDebug;
        private Button btnOk;
    }
}