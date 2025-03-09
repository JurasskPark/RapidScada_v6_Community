namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmRegisterInputValue
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
            btn_Ok = new Button();
            btn_Cancel = new Button();
            gpb_Boolean = new GroupBox();
            rdb_True = new RadioButton();
            rdb_False = new RadioButton();
            gpb_Value = new GroupBox();
            num_Value = new NumericUpDown();
            gpb_Boolean.SuspendLayout();
            gpb_Value.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_Value).BeginInit();
            SuspendLayout();
            // 
            // btn_Ok
            // 
            btn_Ok.Location = new Point(14, 77);
            btn_Ok.Margin = new Padding(4, 3, 4, 3);
            btn_Ok.Name = "btn_Ok";
            btn_Ok.Size = new Size(88, 27);
            btn_Ok.TabIndex = 2;
            btn_Ok.TabStop = false;
            btn_Ok.Text = "Ок";
            btn_Ok.UseVisualStyleBackColor = true;
            btn_Ok.Click += btn_Ok_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(108, 77);
            btn_Cancel.Margin = new Padding(4, 3, 4, 3);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(88, 27);
            btn_Cancel.TabIndex = 3;
            btn_Cancel.TabStop = false;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // gpb_Boolean
            // 
            gpb_Boolean.Controls.Add(rdb_True);
            gpb_Boolean.Controls.Add(rdb_False);
            gpb_Boolean.Location = new Point(14, 14);
            gpb_Boolean.Margin = new Padding(4, 3, 4, 3);
            gpb_Boolean.Name = "gpb_Boolean";
            gpb_Boolean.Padding = new Padding(4, 3, 4, 3);
            gpb_Boolean.Size = new Size(182, 57);
            gpb_Boolean.TabIndex = 48;
            gpb_Boolean.TabStop = false;
            // 
            // rdb_True
            // 
            rdb_True.AutoSize = true;
            rdb_True.Location = new Point(94, 22);
            rdb_True.Margin = new Padding(4, 3, 4, 3);
            rdb_True.Name = "rdb_True";
            rdb_True.Size = new Size(47, 19);
            rdb_True.TabIndex = 51;
            rdb_True.TabStop = true;
            rdb_True.Text = "True";
            rdb_True.UseVisualStyleBackColor = true;
            // 
            // rdb_False
            // 
            rdb_False.AutoSize = true;
            rdb_False.Location = new Point(29, 22);
            rdb_False.Margin = new Padding(4, 3, 4, 3);
            rdb_False.Name = "rdb_False";
            rdb_False.Size = new Size(51, 19);
            rdb_False.TabIndex = 50;
            rdb_False.TabStop = true;
            rdb_False.Text = "False";
            rdb_False.UseVisualStyleBackColor = true;
            // 
            // gpb_Value
            // 
            gpb_Value.Controls.Add(num_Value);
            gpb_Value.Location = new Point(14, 14);
            gpb_Value.Margin = new Padding(4, 3, 4, 3);
            gpb_Value.Name = "gpb_Value";
            gpb_Value.Padding = new Padding(4, 3, 4, 3);
            gpb_Value.Size = new Size(182, 57);
            gpb_Value.TabIndex = 4;
            gpb_Value.TabStop = false;
            // 
            // num_Value
            // 
            num_Value.Location = new Point(7, 20);
            num_Value.Margin = new Padding(4, 3, 4, 3);
            num_Value.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            num_Value.Name = "num_Value";
            num_Value.Size = new Size(168, 23);
            num_Value.TabIndex = 0;
            num_Value.Enter += num_Value_Enter;
            num_Value.KeyDown += num_Value_KeyDown;
            // 
            // FrmRegisterInputValue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(212, 115);
            ControlBox = false;
            Controls.Add(gpb_Boolean);
            Controls.Add(btn_Ok);
            Controls.Add(btn_Cancel);
            Controls.Add(gpb_Value);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegisterInputValue";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Load += frm_RegisterInputValue_Load;
            gpb_Boolean.ResumeLayout(false);
            gpb_Boolean.PerformLayout();
            gpb_Value.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)num_Value).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox gpb_Boolean;
        private System.Windows.Forms.RadioButton rdb_True;
        private System.Windows.Forms.RadioButton rdb_False;
        private System.Windows.Forms.GroupBox gpb_Value;
        private System.Windows.Forms.NumericUpDown num_Value;
    }
}