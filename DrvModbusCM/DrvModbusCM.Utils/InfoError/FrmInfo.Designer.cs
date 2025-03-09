namespace InfoError
{
    partial class FrmInfo
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
            lblError = new Label();
            txtError = new TextBox();
            btnOk = new Button();
            txtStackTrace = new TextBox();
            lblStackTrace = new Label();
            txtFrame = new TextBox();
            lblFrame = new Label();
            txtLine = new TextBox();
            lblLine = new Label();
            SuspendLayout();
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(12, 9);
            lblError.Name = "lblError";
            lblError.Size = new Size(32, 15);
            lblError.TabIndex = 0;
            lblError.Text = "Error";
            // 
            // txtError
            // 
            txtError.Location = new Point(129, 6);
            txtError.Multiline = true;
            txtError.Name = "txtError";
            txtError.Size = new Size(499, 50);
            txtError.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnOk.Location = new Point(283, 330);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtStackTrace
            // 
            txtStackTrace.Location = new Point(129, 62);
            txtStackTrace.Multiline = true;
            txtStackTrace.Name = "txtStackTrace";
            txtStackTrace.Size = new Size(500, 100);
            txtStackTrace.TabIndex = 4;
            // 
            // lblStackTrace
            // 
            lblStackTrace.AutoSize = true;
            lblStackTrace.Location = new Point(12, 65);
            lblStackTrace.Name = "lblStackTrace";
            lblStackTrace.Size = new Size(65, 15);
            lblStackTrace.TabIndex = 3;
            lblStackTrace.Text = "Stack Trace";
            // 
            // txtFrame
            // 
            txtFrame.Location = new Point(129, 168);
            txtFrame.Multiline = true;
            txtFrame.Name = "txtFrame";
            txtFrame.Size = new Size(500, 100);
            txtFrame.TabIndex = 6;
            // 
            // lblFrame
            // 
            lblFrame.AutoSize = true;
            lblFrame.Location = new Point(12, 171);
            lblFrame.Name = "lblFrame";
            lblFrame.Size = new Size(40, 15);
            lblFrame.TabIndex = 5;
            lblFrame.Text = "Frame";
            // 
            // txtLine
            // 
            txtLine.Location = new Point(129, 274);
            txtLine.Multiline = true;
            txtLine.Name = "txtLine";
            txtLine.Size = new Size(499, 50);
            txtLine.TabIndex = 8;
            // 
            // lblLine
            // 
            lblLine.AutoSize = true;
            lblLine.Location = new Point(12, 277);
            lblLine.Name = "lblLine";
            lblLine.Size = new Size(29, 15);
            lblLine.TabIndex = 7;
            lblLine.Text = "Line";
            // 
            // FrmInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 365);
            Controls.Add(txtLine);
            Controls.Add(lblLine);
            Controls.Add(txtFrame);
            Controls.Add(lblFrame);
            Controls.Add(txtStackTrace);
            Controls.Add(lblStackTrace);
            Controls.Add(btnOk);
            Controls.Add(txtError);
            Controls.Add(lblError);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmInfo";
            ShowIcon = false;
            Text = "Error";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblError;
        private TextBox txtError;
        private Button btnOk;
        private TextBox txtStackTrace;
        private Label lblStackTrace;
        private TextBox txtFrame;
        private Label lblFrame;
        private TextBox txtLine;
        private Label lblLine;
    }
}