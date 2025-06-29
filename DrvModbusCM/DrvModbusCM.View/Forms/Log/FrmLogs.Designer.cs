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
            fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            lblChannel = new Label();
            cmbChannel = new ComboBox();
            ckbPause = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).BeginInit();
            SuspendLayout();
            // 
            // fastColoredTextBox1
            // 
            fastColoredTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fastColoredTextBox1.AutoCompleteBracketsList = new char[]
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
            fastColoredTextBox1.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            fastColoredTextBox1.AutoScrollMinSize = new Size(2, 14);
            fastColoredTextBox1.BackBrush = null;
            fastColoredTextBox1.BorderStyle = BorderStyle.FixedSingle;
            fastColoredTextBox1.CharHeight = 14;
            fastColoredTextBox1.CharWidth = 8;
            fastColoredTextBox1.DefaultMarkerSize = 8;
            fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBox1.Hotkeys = "Tab=IndentIncrease";
            fastColoredTextBox1.IsReplaceMode = false;
            fastColoredTextBox1.Location = new Point(12, 35);
            fastColoredTextBox1.Name = "fastColoredTextBox1";
            fastColoredTextBox1.Paddings = new Padding(0);
            fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            //fastColoredTextBox1.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fastColoredTextBox1.ServiceColors");
            fastColoredTextBox1.ShowLineNumbers = false;
            fastColoredTextBox1.Size = new Size(776, 403);
            fastColoredTextBox1.TabIndex = 0;
            fastColoredTextBox1.Zoom = 100;
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
            // 
            // FrmLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ckbPause);
            Controls.Add(cmbChannel);
            Controls.Add(lblChannel);
            Controls.Add(fastColoredTextBox1);
            Name = "FrmLogs";
            Text = "Logs";
            FormClosing += FrmLogs_FormClosing;
            Load += FrmLogs_Load;
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private Label lblChannel;
        private ComboBox cmbChannel;
        private CheckBox ckbPause;
    }
}