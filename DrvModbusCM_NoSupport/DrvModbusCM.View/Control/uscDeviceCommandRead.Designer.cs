namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscDeviceCommandRead
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpbCommand = new System.Windows.Forms.GroupBox();
            this.cmbFunctionCode = new System.Windows.Forms.ComboBox();
            this.lblRegisterCount = new System.Windows.Forms.Label();
            this.nudRegisterCount = new System.Windows.Forms.NumericUpDown();
            this.lblRegisterStartAddress = new System.Windows.Forms.Label();
            this.nudRegisterStartAddress = new System.Windows.Forms.NumericUpDown();
            this.gpbGroup = new System.Windows.Forms.GroupBox();
            this.ckbDeviceCommandEnabled = new System.Windows.Forms.CheckBox();
            this.lblNameGroup = new System.Windows.Forms.Label();
            this.txtDeviceCommandName = new System.Windows.Forms.TextBox();
            this.btnCommandSave = new System.Windows.Forms.Button();
            this.gpbCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddress)).BeginInit();
            this.gpbGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCommand
            // 
            this.gpbCommand.Controls.Add(this.cmbFunctionCode);
            this.gpbCommand.Controls.Add(this.lblRegisterCount);
            this.gpbCommand.Controls.Add(this.nudRegisterCount);
            this.gpbCommand.Controls.Add(this.lblRegisterStartAddress);
            this.gpbCommand.Controls.Add(this.nudRegisterStartAddress);
            this.gpbCommand.Location = new System.Drawing.Point(4, 77);
            this.gpbCommand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbCommand.Name = "gpbCommand";
            this.gpbCommand.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbCommand.Size = new System.Drawing.Size(439, 235);
            this.gpbCommand.TabIndex = 26;
            this.gpbCommand.TabStop = false;
            this.gpbCommand.Text = "Параметры";
            // 
            // cmbFunctionCode
            // 
            this.cmbFunctionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunctionCode.DropDownWidth = 350;
            this.cmbFunctionCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFunctionCode.FormattingEnabled = true;
            this.cmbFunctionCode.Items.AddRange(new object[] {
            "(01) — Чтение регистров флагов (Read Coils) ",
            "(02) — Чтение дискретных входов (Read Discrete Inputs)",
            "(03) — Чтение регистров хранения (Read Holding Registers)",
            "(04) — Чтение регистров ввода (Read Input Registers)",
            "(05) — Запись одного флага (Force Single Coil)",
            "(06) — Запись регистр хранения (Preset Single Register)",
            "(07) — Чтение сигналов состояния (Read Exception Status)",
            "(08) — Диагностика (Diagnostic)",
            "(11) — Чтение счетчика событий (Get Com Event Counter)",
            "(12) — Чтение журнала событий (Get Com Event Log)",
            "(15) — Запись регистров флагов (Write Multiple Coils)",
            "(16) — Запись регистров хранения (Write Multiple Holding Registers)",
            "(17) — Чтение информации об устройстве (Report Slave ID)",
            "(20) — Чтение из файла (Read File Record)",
            "(21) — Запись в файл (Write File Record)",
            "(22) — Запись в один регистр хранения (Mask Write Register)",
            "(24) — Чтение данных из очереди (Read FIFO Queue)",
            "(43) — Encapsulated Interface Transport",
            "(99) — Произвольная команда"});
            this.cmbFunctionCode.Location = new System.Drawing.Point(7, 22);
            this.cmbFunctionCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbFunctionCode.Name = "cmbFunctionCode";
            this.cmbFunctionCode.Size = new System.Drawing.Size(424, 23);
            this.cmbFunctionCode.TabIndex = 22;
            this.cmbFunctionCode.SelectedIndexChanged += new System.EventHandler(this.cmbFunctionCode_SelectedIndexChanged);
            // 
            // lblRegisterCount
            // 
            this.lblRegisterCount.AutoSize = true;
            this.lblRegisterCount.Location = new System.Drawing.Point(125, 88);
            this.lblRegisterCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterCount.Name = "lblRegisterCount";
            this.lblRegisterCount.Size = new System.Drawing.Size(131, 15);
            this.lblRegisterCount.TabIndex = 6;
            this.lblRegisterCount.Text = "Количество регистров";
            // 
            // nudRegisterCount
            // 
            this.nudRegisterCount.Location = new System.Drawing.Point(7, 85);
            this.nudRegisterCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterCount.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nudRegisterCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegisterCount.Name = "nudRegisterCount";
            this.nudRegisterCount.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterCount.TabIndex = 3;
            this.nudRegisterCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegisterCount.ValueChanged += new System.EventHandler(this.nudRegisterCount_ValueChanged);
            // 
            // lblRegisterStartAddress
            // 
            this.lblRegisterStartAddress.AutoSize = true;
            this.lblRegisterStartAddress.Location = new System.Drawing.Point(125, 58);
            this.lblRegisterStartAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterStartAddress.Name = "lblRegisterStartAddress";
            this.lblRegisterStartAddress.Size = new System.Drawing.Size(157, 15);
            this.lblRegisterStartAddress.TabIndex = 3;
            this.lblRegisterStartAddress.Text = "Начальный адрес регистра";
            // 
            // nudRegisterStartAddress
            // 
            this.nudRegisterStartAddress.Location = new System.Drawing.Point(7, 55);
            this.nudRegisterStartAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterStartAddress.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudRegisterStartAddress.Name = "nudRegisterStartAddress";
            this.nudRegisterStartAddress.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterStartAddress.TabIndex = 2;
            this.nudRegisterStartAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterStartAddress.ValueChanged += new System.EventHandler(this.nudRegisterStartAddress_ValueChanged);
            // 
            // gpbGroup
            // 
            this.gpbGroup.Controls.Add(this.ckbDeviceCommandEnabled);
            this.gpbGroup.Controls.Add(this.lblNameGroup);
            this.gpbGroup.Controls.Add(this.txtDeviceCommandName);
            this.gpbGroup.Location = new System.Drawing.Point(4, 3);
            this.gpbGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbGroup.Name = "gpbGroup";
            this.gpbGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbGroup.Size = new System.Drawing.Size(439, 67);
            this.gpbGroup.TabIndex = 23;
            this.gpbGroup.TabStop = false;
            // 
            // ckbDeviceCommandEnabled
            // 
            this.ckbDeviceCommandEnabled.AutoSize = true;
            this.ckbDeviceCommandEnabled.Location = new System.Drawing.Point(329, 33);
            this.ckbDeviceCommandEnabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbDeviceCommandEnabled.Name = "ckbDeviceCommandEnabled";
            this.ckbDeviceCommandEnabled.Size = new System.Drawing.Size(78, 19);
            this.ckbDeviceCommandEnabled.TabIndex = 13;
            this.ckbDeviceCommandEnabled.Text = "Активное";
            this.ckbDeviceCommandEnabled.UseVisualStyleBackColor = true;
            // 
            // lblNameGroup
            // 
            this.lblNameGroup.AutoSize = true;
            this.lblNameGroup.Location = new System.Drawing.Point(8, 13);
            this.lblNameGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameGroup.Name = "lblNameGroup";
            this.lblNameGroup.Size = new System.Drawing.Size(90, 15);
            this.lblNameGroup.TabIndex = 2;
            this.lblNameGroup.Text = "Наименование";
            // 
            // txtDeviceCommandName
            // 
            this.txtDeviceCommandName.Location = new System.Drawing.Point(7, 31);
            this.txtDeviceCommandName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeviceCommandName.Name = "txtDeviceCommandName";
            this.txtDeviceCommandName.Size = new System.Drawing.Size(314, 23);
            this.txtDeviceCommandName.TabIndex = 1;
            // 
            // btnCommandSave
            // 
            this.btnCommandSave.Location = new System.Drawing.Point(451, 10);
            this.btnCommandSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCommandSave.Name = "btnCommandSave";
            this.btnCommandSave.Size = new System.Drawing.Size(107, 27);
            this.btnCommandSave.TabIndex = 25;
            this.btnCommandSave.Text = "Сохранить";
            this.btnCommandSave.UseVisualStyleBackColor = true;
            this.btnCommandSave.Visible = false;
            this.btnCommandSave.Click += new System.EventHandler(this.btnCommandSave_Click);
            // 
            // uscDeviceCommandRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbCommand);
            this.Controls.Add(this.gpbGroup);
            this.Controls.Add(this.btnCommandSave);
            this.Name = "uscDeviceCommandRead";
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.uscDeviceCommandRead_Load);
            this.gpbCommand.ResumeLayout(false);
            this.gpbCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddress)).EndInit();
            this.gpbGroup.ResumeLayout(false);
            this.gpbGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gpbCommand;
        private ComboBox cmbFunctionCode;
        private Label lblRegisterCount;
        private NumericUpDown nudRegisterCount;
        private Label lblRegisterStartAddress;
        private NumericUpDown nudRegisterStartAddress;
        private GroupBox gpbGroup;
        private CheckBox ckbDeviceCommandEnabled;
        private Label lblNameGroup;
        private TextBox txtDeviceCommandName;
        private Button btnCommandSave;
    }
}
