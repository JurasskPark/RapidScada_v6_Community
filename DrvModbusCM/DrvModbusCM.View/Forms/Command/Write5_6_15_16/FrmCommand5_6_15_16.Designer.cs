
namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmCommand5_6_15_16
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
            lblName = new Label();
            txtName = new TextBox();
            btnSave = new Button();
            gpbOptions = new GroupBox();
            dgvRegisterValue = new DataGridView();
            cmbFunctionCode = new ComboBox();
            lblRegisterCount = new Label();
            nudRegisterCount = new NumericUpDown();
            lblRegisterStartAddress = new Label();
            nudRegisterStartAddress = new NumericUpDown();
            gpbGroup.SuspendLayout();
            gpbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegisterValue).BeginInit();
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
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblName);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(14, 14);
            gpbGroup.Margin = new Padding(4, 3, 4, 3);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(4, 3, 4, 3);
            gpbGroup.Size = new Size(439, 67);
            gpbGroup.TabIndex = 18;
            gpbGroup.TabStop = false;
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
            gpbOptions.Controls.Add(dgvRegisterValue);
            gpbOptions.Controls.Add(cmbFunctionCode);
            gpbOptions.Controls.Add(lblRegisterCount);
            gpbOptions.Controls.Add(nudRegisterCount);
            gpbOptions.Controls.Add(lblRegisterStartAddress);
            gpbOptions.Controls.Add(nudRegisterStartAddress);
            gpbOptions.Location = new Point(14, 88);
            gpbOptions.Margin = new Padding(4, 3, 4, 3);
            gpbOptions.Name = "gpbOptions";
            gpbOptions.Padding = new Padding(4, 3, 4, 3);
            gpbOptions.Size = new Size(439, 235);
            gpbOptions.TabIndex = 21;
            gpbOptions.TabStop = false;
            gpbOptions.Text = "Options";
            // 
            // dgvRegisterValue
            // 
            dgvRegisterValue.AllowUserToAddRows = false;
            dgvRegisterValue.AllowUserToResizeColumns = false;
            dgvRegisterValue.AllowUserToResizeRows = false;
            dgvRegisterValue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegisterValue.Location = new Point(7, 115);
            dgvRegisterValue.Margin = new Padding(4, 3, 4, 3);
            dgvRegisterValue.Name = "dgvRegisterValue";
            dgvRegisterValue.Size = new Size(425, 106);
            dgvRegisterValue.TabIndex = 23;
            dgvRegisterValue.CellContentClick += dgv_RegisterValue_CellContentClick;
            dgvRegisterValue.CellValueChanged += dgv_RegisterValue_CellValueChanged;
            dgvRegisterValue.EditingControlShowing += dgv_RegisterValue_EditingControlShowing;
            // 
            // cmbFunctionCode
            // 
            cmbFunctionCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionCode.DropDownWidth = 350;
            cmbFunctionCode.FlatStyle = FlatStyle.Flat;
            cmbFunctionCode.FormattingEnabled = true;
            cmbFunctionCode.Items.AddRange(new object[] { "(01) — Чтение регистров флагов (Read Coils) ", "(02) — Чтение дискретных входов (Read Discrete Inputs)", "(03) — Чтение регистров хранения (Read Holding Registers)", "(04) — Чтение регистров ввода (Read Input Registers)", "(05) — Запись одного флага (Force Single Coil)", "(06) — Запись регистр хранения (Preset Single Register)", "(07) — Чтение сигналов состояния (Read Exception Status)", "(08) — Диагностика (Diagnostic)", "(11) — Чтение счетчика событий (Get Com Event Counter)", "(12) — Чтение журнала событий (Get Com Event Log)", "(15) — Запись регистров флагов (Write Multiple Coils)", "(16) — Запись регистров хранения (Write Multiple Holding Registers)", "(17) — Чтение информации об устройстве (Report Slave ID)", "(20) — Чтение из файла (Read File Record)", "(21) — Запись в файл (Write File Record)", "(22) — Запись в один регистр хранения (Mask Write Register)", "(24) — Чтение данных из очереди (Read FIFO Queue)", "(43) — Encapsulated Interface Transport", "(99) — Произвольная команда" });
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
            lblRegisterCount.Location = new Point(124, 88);
            lblRegisterCount.Margin = new Padding(4, 0, 4, 0);
            lblRegisterCount.Name = "lblRegisterCount";
            lblRegisterCount.Size = new Size(112, 15);
            lblRegisterCount.TabIndex = 6;
            lblRegisterCount.Text = "Number of registers";
            // 
            // nudRegisterCount
            // 
            nudRegisterCount.Location = new Point(7, 85);
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
            lblRegisterStartAddress.Location = new Point(124, 58);
            lblRegisterStartAddress.Margin = new Padding(4, 0, 4, 0);
            lblRegisterStartAddress.Name = "lblRegisterStartAddress";
            lblRegisterStartAddress.Size = new Size(167, 15);
            lblRegisterStartAddress.TabIndex = 3;
            lblRegisterStartAddress.Text = "Starting address of the register";
            // 
            // nudRegisterStartAddress
            // 
            nudRegisterStartAddress.Location = new Point(7, 55);
            nudRegisterStartAddress.Margin = new Padding(4, 3, 4, 3);
            nudRegisterStartAddress.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRegisterStartAddress.Name = "nudRegisterStartAddress";
            nudRegisterStartAddress.Size = new Size(110, 23);
            nudRegisterStartAddress.TabIndex = 2;
            nudRegisterStartAddress.TextAlign = HorizontalAlignment.Center;
            nudRegisterStartAddress.ValueChanged += nud_RegisterStartAddress_ValueChanged;
            // 
            // FrmCommand5_6_15_16
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 389);
            ControlBox = false;
            Controls.Add(gpbOptions);
            Controls.Add(gpbGroup);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCommand5_6_15_16";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Command";
            Load += FrmCommand_Load;
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            gpbOptions.ResumeLayout(false);
            gpbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegisterValue).EndInit();
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
        private System.Windows.Forms.DataGridView dgvRegisterValue;
    }
}