
namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmCommand1_2_3_4
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
            ckbEnabled = new CheckBox();
            gpbGroup = new GroupBox();
            txtCode = new TextBox();
            lblCode = new Label();
            lblName = new Label();
            txtName = new TextBox();
            btnSave = new Button();
            gpbOptions = new GroupBox();
            lblRegisterCountWrite = new Label();
            nudRegisterCountWrite = new NumericUpDown();
            lblRegisterStartAddressWrite = new Label();
            cmbFunctionCodeWrite = new ComboBox();
            nudRegisterStartAddressWrite = new NumericUpDown();
            ckbWriteDataOther = new CheckBox();
            cmbFunctionCode = new ComboBox();
            lblRegisterCount = new Label();
            nudRegisterCount = new NumericUpDown();
            lblRegisterStartAddress = new Label();
            nudRegisterStartAddress = new NumericUpDown();
            gpbGroup.SuspendLayout();
            gpbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCountWrite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddressWrite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddress).BeginInit();
            SuspendLayout();
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(329, 35);
            ckbEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(68, 19);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.UseVisualStyleBackColor = true;
            // 
            // gpbGroup
            // 
            gpbGroup.Controls.Add(txtCode);
            gpbGroup.Controls.Add(lblCode);
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblName);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(14, 14);
            gpbGroup.Margin = new Padding(4, 3, 4, 3);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(4, 3, 4, 3);
            gpbGroup.Size = new Size(439, 108);
            gpbGroup.TabIndex = 18;
            gpbGroup.TabStop = false;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(7, 77);
            txtCode.Margin = new Padding(6, 5, 6, 5);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(314, 23);
            txtCode.TabIndex = 22;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(7, 57);
            lblCode.Margin = new Padding(6, 0, 6, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(93, 15);
            lblCode.TabIndex = 23;
            lblCode.Text = "Command code";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(7, 13);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(7, 31);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(314, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += control_Changed;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(461, 21);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // gpbOptions
            // 
            gpbOptions.Controls.Add(lblRegisterCountWrite);
            gpbOptions.Controls.Add(nudRegisterCountWrite);
            gpbOptions.Controls.Add(lblRegisterStartAddressWrite);
            gpbOptions.Controls.Add(cmbFunctionCodeWrite);
            gpbOptions.Controls.Add(nudRegisterStartAddressWrite);
            gpbOptions.Controls.Add(ckbWriteDataOther);
            gpbOptions.Controls.Add(cmbFunctionCode);
            gpbOptions.Controls.Add(lblRegisterCount);
            gpbOptions.Controls.Add(nudRegisterCount);
            gpbOptions.Controls.Add(lblRegisterStartAddress);
            gpbOptions.Controls.Add(nudRegisterStartAddress);
            gpbOptions.Location = new Point(14, 128);
            gpbOptions.Margin = new Padding(4, 3, 4, 3);
            gpbOptions.Name = "gpbOptions";
            gpbOptions.Padding = new Padding(4, 3, 4, 3);
            gpbOptions.Size = new Size(439, 235);
            gpbOptions.TabIndex = 21;
            gpbOptions.TabStop = false;
            gpbOptions.Text = "Options";
            // 
            // lblRegisterCountWrite
            // 
            lblRegisterCountWrite.AutoSize = true;
            lblRegisterCountWrite.Location = new Point(7, 196);
            lblRegisterCountWrite.Margin = new Padding(4, 0, 4, 0);
            lblRegisterCountWrite.Name = "lblRegisterCountWrite";
            lblRegisterCountWrite.Size = new Size(196, 15);
            lblRegisterCountWrite.TabIndex = 25;
            lblRegisterCountWrite.Text = "Number of registers for writing data";
            lblRegisterCountWrite.Visible = false;
            // 
            // nudRegisterCountWrite
            // 
            nudRegisterCountWrite.Location = new Point(321, 192);
            nudRegisterCountWrite.Margin = new Padding(4, 3, 4, 3);
            nudRegisterCountWrite.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            nudRegisterCountWrite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRegisterCountWrite.Name = "nudRegisterCountWrite";
            nudRegisterCountWrite.Size = new Size(110, 23);
            nudRegisterCountWrite.TabIndex = 24;
            nudRegisterCountWrite.TextAlign = HorizontalAlignment.Center;
            nudRegisterCountWrite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudRegisterCountWrite.Visible = false;
            // 
            // lblRegisterStartAddressWrite
            // 
            lblRegisterStartAddressWrite.AutoSize = true;
            lblRegisterStartAddressWrite.Location = new Point(7, 167);
            lblRegisterStartAddressWrite.Margin = new Padding(4, 0, 4, 0);
            lblRegisterStartAddressWrite.Name = "lblRegisterStartAddressWrite";
            lblRegisterStartAddressWrite.Size = new Size(251, 15);
            lblRegisterStartAddressWrite.TabIndex = 23;
            lblRegisterStartAddressWrite.Text = "Starting address of the register for writing data";
            lblRegisterStartAddressWrite.Visible = false;
            // 
            // cmbFunctionCodeWrite
            // 
            cmbFunctionCodeWrite.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionCodeWrite.DropDownWidth = 350;
            cmbFunctionCodeWrite.FlatStyle = FlatStyle.Flat;
            cmbFunctionCodeWrite.FormattingEnabled = true;
            cmbFunctionCodeWrite.Items.AddRange(new object[] { "(01) — Coils", "(02) — Discrete Inputs", "(03) — Holding Registers", "(04) — Input Registers" });
            cmbFunctionCodeWrite.Location = new Point(7, 134);
            cmbFunctionCodeWrite.Margin = new Padding(4, 3, 4, 3);
            cmbFunctionCodeWrite.Name = "cmbFunctionCodeWrite";
            cmbFunctionCodeWrite.Size = new Size(424, 23);
            cmbFunctionCodeWrite.TabIndex = 23;
            cmbFunctionCodeWrite.Visible = false;
            // 
            // nudRegisterStartAddressWrite
            // 
            nudRegisterStartAddressWrite.Location = new Point(321, 163);
            nudRegisterStartAddressWrite.Margin = new Padding(4, 3, 4, 3);
            nudRegisterStartAddressWrite.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRegisterStartAddressWrite.Name = "nudRegisterStartAddressWrite";
            nudRegisterStartAddressWrite.Size = new Size(110, 23);
            nudRegisterStartAddressWrite.TabIndex = 22;
            nudRegisterStartAddressWrite.TextAlign = HorizontalAlignment.Center;
            nudRegisterStartAddressWrite.Visible = false;
            // 
            // ckbWriteDataOther
            // 
            ckbWriteDataOther.AutoSize = true;
            ckbWriteDataOther.Location = new Point(7, 109);
            ckbWriteDataOther.Margin = new Padding(4, 3, 4, 3);
            ckbWriteDataOther.Name = "ckbWriteDataOther";
            ckbWriteDataOther.Size = new Size(172, 19);
            ckbWriteDataOther.TabIndex = 22;
            ckbWriteDataOther.Text = "Write data to other registers";
            ckbWriteDataOther.UseVisualStyleBackColor = true;
            ckbWriteDataOther.CheckedChanged += ckbWriteDataOther_CheckedChanged;
            // 
            // cmbFunctionCode
            // 
            cmbFunctionCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionCode.DropDownWidth = 350;
            cmbFunctionCode.FlatStyle = FlatStyle.Flat;
            cmbFunctionCode.FormattingEnabled = true;
            cmbFunctionCode.Items.AddRange(new object[] { "(01) — Read Coils", "(02) — Read Discrete Inputs", "(03) — Read Holding Registers", "(04) — Read Input Registers" });
            cmbFunctionCode.Location = new Point(7, 22);
            cmbFunctionCode.Margin = new Padding(4, 3, 4, 3);
            cmbFunctionCode.Name = "cmbFunctionCode";
            cmbFunctionCode.Size = new Size(424, 23);
            cmbFunctionCode.TabIndex = 22;
            cmbFunctionCode.SelectedIndexChanged += cmb_FunctionCode_SelectedIndexChanged;
            // 
            // lblRegisterCount
            // 
            lblRegisterCount.AutoSize = true;
            lblRegisterCount.Location = new Point(7, 84);
            lblRegisterCount.Margin = new Padding(4, 0, 4, 0);
            lblRegisterCount.Name = "lblRegisterCount";
            lblRegisterCount.Size = new Size(112, 15);
            lblRegisterCount.TabIndex = 6;
            lblRegisterCount.Text = "Number of registers";
            // 
            // nudRegisterCount
            // 
            nudRegisterCount.Location = new Point(321, 80);
            nudRegisterCount.Margin = new Padding(4, 3, 4, 3);
            nudRegisterCount.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            nudRegisterCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRegisterCount.Name = "nudRegisterCount";
            nudRegisterCount.Size = new Size(110, 23);
            nudRegisterCount.TabIndex = 3;
            nudRegisterCount.TextAlign = HorizontalAlignment.Center;
            nudRegisterCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudRegisterCount.ValueChanged += nud_RegisterCount_ValueChanged;
            // 
            // lblRegisterStartAddress
            // 
            lblRegisterStartAddress.AutoSize = true;
            lblRegisterStartAddress.Location = new Point(7, 55);
            lblRegisterStartAddress.Margin = new Padding(4, 0, 4, 0);
            lblRegisterStartAddress.Name = "lblRegisterStartAddress";
            lblRegisterStartAddress.Size = new Size(167, 15);
            lblRegisterStartAddress.TabIndex = 3;
            lblRegisterStartAddress.Text = "Starting address of the register";
            // 
            // nudRegisterStartAddress
            // 
            nudRegisterStartAddress.Location = new Point(321, 51);
            nudRegisterStartAddress.Margin = new Padding(4, 3, 4, 3);
            nudRegisterStartAddress.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRegisterStartAddress.Name = "nudRegisterStartAddress";
            nudRegisterStartAddress.Size = new Size(110, 23);
            nudRegisterStartAddress.TabIndex = 2;
            nudRegisterStartAddress.TextAlign = HorizontalAlignment.Center;
            nudRegisterStartAddress.ValueChanged += nud_RegisterStartAddress_ValueChanged;
            // 
            // FrmCommand1_2_3_4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 387);
            ControlBox = false;
            Controls.Add(gpbOptions);
            Controls.Add(gpbGroup);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCommand1_2_3_4";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Command";
            Load += FrmCommand_Load;
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            gpbOptions.ResumeLayout(false);
            gpbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCountWrite).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddressWrite).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddress).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.CheckBox ckbEnabled;
        private System.Windows.Forms.Button btn_ModbusCommandCancel;
        private System.Windows.Forms.GroupBox gpbGroup;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btn_ModbusCommandAdd;
        private System.Windows.Forms.GroupBox gpbOptions;
        private System.Windows.Forms.Label lblRegisterCount;
        private System.Windows.Forms.NumericUpDown nudRegisterCount;
        private System.Windows.Forms.Label lblRegisterStartAddress;
        private System.Windows.Forms.NumericUpDown nudRegisterStartAddress;
        private System.Windows.Forms.ComboBox cmbFunctionCode;
        private CheckBox ckbWriteDataOther;
        private Label lblRegisterStartAddressWrite;
        private ComboBox cmbFunctionCodeWrite;
        private NumericUpDown nudRegisterStartAddressWrite;
        private Label lblRegisterCountWrite;
        private NumericUpDown nudRegisterCountWrite;
        private TextBox txtCode;
        private Label lblCode;
    }
}