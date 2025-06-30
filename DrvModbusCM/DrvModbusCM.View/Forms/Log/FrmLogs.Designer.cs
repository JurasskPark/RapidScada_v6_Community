namespace DrvModbusCM.View.Forms.Log
{
    partial class FrmLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogs));
            fctLog = new FastColoredTextBoxNS.FastColoredTextBox();
            lblChannel = new Label();
            cmbChannel = new ComboBox();
            ckbPause = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)fctLog).BeginInit();
            SuspendLayout();
            // 
            // fctLog
            // 
            fctLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fctLog.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fctLog.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            fctLog.AutoScrollMinSize = new Size(2, 14);
            fctLog.BackBrush = null;
            fctLog.BorderStyle = BorderStyle.FixedSingle;
            fctLog.CharHeight = 14;
            fctLog.CharWidth = 8;
            fctLog.DefaultMarkerSize = 8;
            fctLog.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fctLog.Font = new Font("Courier New", 9.75F);
            fctLog.Hotkeys = "Tab=IndentIncrease";
            fctLog.IsReplaceMode = false;
            fctLog.Location = new Point(12, 35);
            fctLog.Name = "fctLog";
            fctLog.Paddings = new Padding(0);
            fctLog.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            fctLog.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fctLog.ServiceColors");
            fctLog.ShowLineNumbers = false;
            fctLog.Size = new Size(776, 403);
            fctLog.TabIndex = 0;
            fctLog.Zoom = 100;
            // 
            // lblChannel
            // 
            lblChannel.AutoSize = true;
            lblChannel.Location = new Point(12, 9);
            lblChannel.Name = "lblChannel";
            lblChannel.Size = new Size(51, 15);
            lblChannel.TabIndex = 1;
            lblChannel.Text = "Channel";
            // 
            // cmbChannel
            // 
            cmbChannel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChannel.FormattingEnabled = true;
            cmbChannel.Location = new Point(69, 6);
            cmbChannel.Name = "cmbChannel";
            cmbChannel.Size = new Size(340, 23);
            cmbChannel.TabIndex = 2;
            cmbChannel.SelectedIndexChanged += cmbChannel_SelectedIndexChanged;
            cmbChannel.MouseClick += cmbChannel_MouseClick;
            cmbChannel.MouseUp += cmbChannel_MouseUp;
            // 
            // ckbPause
            // 
            ckbPause.AutoSize = true;
            ckbPause.Location = new Point(415, 8);
            ckbPause.Name = "ckbPause";
            ckbPause.Size = new Size(57, 19);
            ckbPause.TabIndex = 3;
            ckbPause.Text = "Pause";
            ckbPause.UseVisualStyleBackColor = true;
            ckbPause.CheckedChanged += ckbPause_CheckedChanged;
            // 
            // FrmLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ckbPause);
            Controls.Add(cmbChannel);
            Controls.Add(lblChannel);
            Controls.Add(fctLog);
            Name = "FrmLogs";
            Text = "Logs";
            FormClosing += FrmLogs_FormClosing;
            Load += FrmLogs_Load;
            ((System.ComponentModel.ISupportInitialize)fctLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctLog;
        private Label lblChannel;
        private ComboBox cmbChannel;
        private CheckBox ckbPause;
    }
}