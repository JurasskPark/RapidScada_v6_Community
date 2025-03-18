namespace Scada.Comm.Drivers.DrvModbusCM.View
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
            ckbAutoRun = new CheckBox();
            ckbDebug = new CheckBox();
            btnCancel = new Button();
            btnSave = new Button();
            gpbSettings.SuspendLayout();
            SuspendLayout();
            // 
            // gpbSettings
            // 
            gpbSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbSettings.Controls.Add(ckbAutoRun);
            gpbSettings.Controls.Add(ckbDebug);
            gpbSettings.Location = new Point(12, 12);
            gpbSettings.Name = "gpbSettings";
            gpbSettings.Size = new Size(776, 118);
            gpbSettings.TabIndex = 0;
            gpbSettings.TabStop = false;
            gpbSettings.Text = "Settings";
            // 
            // ckbAutoRun
            // 
            ckbAutoRun.AutoSize = true;
            ckbAutoRun.Location = new Point(6, 47);
            ckbAutoRun.Name = "ckbAutoRun";
            ckbAutoRun.Size = new Size(73, 19);
            ckbAutoRun.TabIndex = 2;
            ckbAutoRun.Text = "AutoRun";
            ckbAutoRun.UseVisualStyleBackColor = true;
            ckbAutoRun.CheckedChanged += control_Changed;
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
            ckbDebug.CheckedChanged += control_Changed;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(657, 138);
            btnCancel.Margin = new Padding(4, 5, 4, 5);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 26);
            btnCancel.TabIndex = 44;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Enabled = false;
            btnSave.Location = new Point(519, 138);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 26);
            btnSave.TabIndex = 43;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FrmSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 178);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(gpbSettings);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmSettings";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += FrmSettings_Load;
            gpbSettings.ResumeLayout(false);
            gpbSettings.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbSettings;
        private CheckBox ckbDebug;
        private CheckBox ckbAutoRun;
        private Button btnCancel;
        private Button btnSave;
    }
}