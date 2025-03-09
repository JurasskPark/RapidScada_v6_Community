namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscDevice
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
            components = new System.ComponentModel.Container();
            tabDevice = new TabControl();
            tabDeviceSettings = new TabPage();
            btnSave = new Button();
            gpbSettingsModbus = new GroupBox();
            nudDeviceGatewayRegistersBytes = new NumericUpDown();
            lblPollingOnScheduleStatus = new Label();
            nudDeviceRegistersBytes = new NumericUpDown();
            lblDeviceGatewayRegistersBytes = new Label();
            lblRegisters = new Label();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            numIntervalPool = new NumericUpDown();
            numAddress = new NumericUpDown();
            ckbPollingOnScheduleStatus = new CheckBox();
            lblID = new Label();
            cmbTypeProtocol = new ComboBox();
            txtDeviceID = new TextBox();
            lblTypeProtocol = new Label();
            lblIntervalPool = new Label();
            lblAddress = new Label();
            txtDateTimeLastSuccessfully = new TextBox();
            lblTimeLastSuccessPool = new Label();
            gpbGroup = new GroupBox();
            txtDescription = new TextBox();
            lblDescriptionGroup = new Label();
            ckbEnabled = new CheckBox();
            lblNameGroup = new Label();
            txtName = new TextBox();
            tabDeviceBuff = new TabPage();
            spltBuffer = new SplitContainer();
            nudTimerInfo = new NumericUpDown();
            btnTimerInfo = new Button();
            lblTimerInfo = new Label();
            ckbAutoRefreshListRegisters = new CheckBox();
            btnSearchValue = new Button();
            cmbTypeData = new ComboBox();
            lblStartRegister = new Label();
            numRegisterStart = new NumericUpDown();
            tabDeviceBuffer = new TabControl();
            tabCoils = new TabPage();
            lstCoils = new ListView();
            clmAddressCoils = new ColumnHeader();
            clmStateCoils = new ColumnHeader();
            cmnuRegisterEdit = new ContextMenuStrip(components);
            tolRegisterRefresh = new ToolStripMenuItem();
            tolRegisterChange = new ToolStripMenuItem();
            tlsSeparator_1 = new ToolStripSeparator();
            tolRegistersResetToZero = new ToolStripMenuItem();
            tlsSeparator_2 = new ToolStripSeparator();
            tolDataLoadAsCSV = new ToolStripMenuItem();
            tolDataSaveAsCSV = new ToolStripMenuItem();
            tabDiscreteInputs = new TabPage();
            lstDiscreteInputs = new ListView();
            clmAddressDiscreteInputs = new ColumnHeader();
            clmStateDiscreteInputs = new ColumnHeader();
            tabHoldingRegisters = new TabPage();
            lstHoldingRegisters = new ListView();
            clmAddressHoldingRegisters = new ColumnHeader();
            clmBINHoldingRegisters = new ColumnHeader();
            clmHEXHoldingRegisters = new ColumnHeader();
            clmHEX2HoldingRegisters = new ColumnHeader();
            clmValueHoldingRegisters = new ColumnHeader();
            clmValueFloatHoldingRegisters = new ColumnHeader();
            tabInputRegisters = new TabPage();
            lstInputRegisters = new ListView();
            clmAddressInputRegisters = new ColumnHeader();
            clmBINInputRegisters = new ColumnHeader();
            clmHEXInputRegisters = new ColumnHeader();
            clmValueInputRegisters = new ColumnHeader();
            tmrTimer = new System.Windows.Forms.Timer(components);
            tabDevice.SuspendLayout();
            tabDeviceSettings.SuspendLayout();
            gpbSettingsModbus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDeviceGatewayRegistersBytes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDeviceRegistersBytes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIntervalPool).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numAddress).BeginInit();
            gpbGroup.SuspendLayout();
            tabDeviceBuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spltBuffer).BeginInit();
            spltBuffer.Panel1.SuspendLayout();
            spltBuffer.Panel2.SuspendLayout();
            spltBuffer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTimerInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRegisterStart).BeginInit();
            tabDeviceBuffer.SuspendLayout();
            tabCoils.SuspendLayout();
            cmnuRegisterEdit.SuspendLayout();
            tabDiscreteInputs.SuspendLayout();
            tabHoldingRegisters.SuspendLayout();
            tabInputRegisters.SuspendLayout();
            SuspendLayout();
            // 
            // tabDevice
            // 
            tabDevice.Controls.Add(tabDeviceSettings);
            tabDevice.Controls.Add(tabDeviceBuff);
            tabDevice.Dock = DockStyle.Fill;
            tabDevice.Location = new Point(0, 0);
            tabDevice.Name = "tabDevice";
            tabDevice.SelectedIndex = 0;
            tabDevice.Size = new Size(900, 700);
            tabDevice.TabIndex = 0;
            // 
            // tabDeviceSettings
            // 
            tabDeviceSettings.Controls.Add(btnSave);
            tabDeviceSettings.Controls.Add(gpbSettingsModbus);
            tabDeviceSettings.Controls.Add(gpbGroup);
            tabDeviceSettings.Location = new Point(4, 24);
            tabDeviceSettings.Name = "tabDeviceSettings";
            tabDeviceSettings.Padding = new Padding(3);
            tabDeviceSettings.Size = new Size(892, 672);
            tabDeviceSettings.TabIndex = 0;
            tabDeviceSettings.Text = "Settings";
            tabDeviceSettings.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(441, 13);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnDeviceSave_Click;
            // 
            // gpbSettingsModbus
            // 
            gpbSettingsModbus.Controls.Add(nudDeviceGatewayRegistersBytes);
            gpbSettingsModbus.Controls.Add(lblPollingOnScheduleStatus);
            gpbSettingsModbus.Controls.Add(nudDeviceRegistersBytes);
            gpbSettingsModbus.Controls.Add(lblDeviceGatewayRegistersBytes);
            gpbSettingsModbus.Controls.Add(lblRegisters);
            gpbSettingsModbus.Controls.Add(cmbStatus);
            gpbSettingsModbus.Controls.Add(lblStatus);
            gpbSettingsModbus.Controls.Add(numIntervalPool);
            gpbSettingsModbus.Controls.Add(numAddress);
            gpbSettingsModbus.Controls.Add(ckbPollingOnScheduleStatus);
            gpbSettingsModbus.Controls.Add(lblID);
            gpbSettingsModbus.Controls.Add(cmbTypeProtocol);
            gpbSettingsModbus.Controls.Add(txtDeviceID);
            gpbSettingsModbus.Controls.Add(lblTypeProtocol);
            gpbSettingsModbus.Controls.Add(lblIntervalPool);
            gpbSettingsModbus.Controls.Add(lblAddress);
            gpbSettingsModbus.Controls.Add(txtDateTimeLastSuccessfully);
            gpbSettingsModbus.Controls.Add(lblTimeLastSuccessPool);
            gpbSettingsModbus.Location = new Point(7, 200);
            gpbSettingsModbus.Margin = new Padding(4, 3, 4, 3);
            gpbSettingsModbus.Name = "gpbSettingsModbus";
            gpbSettingsModbus.Padding = new Padding(4, 3, 4, 3);
            gpbSettingsModbus.Size = new Size(539, 289);
            gpbSettingsModbus.TabIndex = 26;
            gpbSettingsModbus.TabStop = false;
            // 
            // nudDeviceGatewayRegistersBytes
            // 
            nudDeviceGatewayRegistersBytes.Location = new Point(242, 219);
            nudDeviceGatewayRegistersBytes.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudDeviceGatewayRegistersBytes.Name = "nudDeviceGatewayRegistersBytes";
            nudDeviceGatewayRegistersBytes.Size = new Size(84, 23);
            nudDeviceGatewayRegistersBytes.TabIndex = 28;
            nudDeviceGatewayRegistersBytes.Value = new decimal(new int[] { 2, 0, 0, 0 });
            nudDeviceGatewayRegistersBytes.ValueChanged += control_Changed;
            // 
            // lblPollingOnScheduleStatus
            // 
            lblPollingOnScheduleStatus.AutoSize = true;
            lblPollingOnScheduleStatus.Location = new Point(7, 111);
            lblPollingOnScheduleStatus.Name = "lblPollingOnScheduleStatus";
            lblPollingOnScheduleStatus.Size = new Size(99, 15);
            lblPollingOnScheduleStatus.TabIndex = 95;
            lblPollingOnScheduleStatus.Text = "Scheduled survey";
            // 
            // nudDeviceRegistersBytes
            // 
            nudDeviceRegistersBytes.Location = new Point(242, 190);
            nudDeviceRegistersBytes.Maximum = new decimal(new int[] { 4, 0, 0, 0 });
            nudDeviceRegistersBytes.Name = "nudDeviceRegistersBytes";
            nudDeviceRegistersBytes.Size = new Size(84, 23);
            nudDeviceRegistersBytes.TabIndex = 27;
            nudDeviceRegistersBytes.Value = new decimal(new int[] { 2, 0, 0, 0 });
            nudDeviceRegistersBytes.ValueChanged += control_Changed;
            // 
            // lblDeviceGatewayRegistersBytes
            // 
            lblDeviceGatewayRegistersBytes.Location = new Point(7, 216);
            lblDeviceGatewayRegistersBytes.Margin = new Padding(4, 0, 4, 0);
            lblDeviceGatewayRegistersBytes.Name = "lblDeviceGatewayRegistersBytes";
            lblDeviceGatewayRegistersBytes.Size = new Size(232, 24);
            lblDeviceGatewayRegistersBytes.TabIndex = 94;
            lblDeviceGatewayRegistersBytes.Text = "Register type (for transfer from software)";
            lblDeviceGatewayRegistersBytes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRegisters
            // 
            lblRegisters.Location = new Point(7, 187);
            lblRegisters.Margin = new Padding(4, 0, 4, 0);
            lblRegisters.Name = "lblRegisters";
            lblRegisters.Size = new Size(232, 24);
            lblRegisters.TabIndex = 92;
            lblRegisters.Text = "Register type (on the device)";
            lblRegisters.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Enabled = false;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Неизвестно", "На связи", "Не доступно", "Поиск" });
            cmbStatus.Location = new Point(243, 47);
            cmbStatus.Margin = new Padding(4, 3, 4, 3);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(289, 23);
            cmbStatus.TabIndex = 62;
            cmbStatus.SelectedIndexChanged += control_Changed;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(7, 48);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(232, 24);
            lblStatus.TabIndex = 90;
            lblStatus.Text = "Device status";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numIntervalPool
            // 
            numIntervalPool.Enabled = false;
            numIntervalPool.Location = new Point(242, 248);
            numIntervalPool.Margin = new Padding(4, 3, 4, 3);
            numIntervalPool.Maximum = new decimal(new int[] { 86400, 0, 0, 0 });
            numIntervalPool.Name = "numIntervalPool";
            numIntervalPool.Size = new Size(84, 23);
            numIntervalPool.TabIndex = 88;
            numIntervalPool.ValueChanged += control_Changed;
            // 
            // numAddress
            // 
            numAddress.Location = new Point(242, 161);
            numAddress.Margin = new Padding(4, 3, 4, 3);
            numAddress.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numAddress.Name = "numAddress";
            numAddress.Size = new Size(84, 23);
            numAddress.TabIndex = 87;
            numAddress.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numAddress.ValueChanged += control_Changed;
            // 
            // ckbPollingOnScheduleStatus
            // 
            ckbPollingOnScheduleStatus.AutoSize = true;
            ckbPollingOnScheduleStatus.Location = new Point(243, 112);
            ckbPollingOnScheduleStatus.Margin = new Padding(4, 3, 4, 3);
            ckbPollingOnScheduleStatus.Name = "ckbPollingOnScheduleStatus";
            ckbPollingOnScheduleStatus.Size = new Size(15, 14);
            ckbPollingOnScheduleStatus.TabIndex = 86;
            ckbPollingOnScheduleStatus.UseVisualStyleBackColor = true;
            ckbPollingOnScheduleStatus.TextChanged += control_Changed;
            // 
            // lblID
            // 
            lblID.Location = new Point(7, 18);
            lblID.Margin = new Padding(4, 0, 4, 0);
            lblID.Name = "lblID";
            lblID.Size = new Size(154, 24);
            lblID.TabIndex = 69;
            lblID.Text = "Device ID";
            lblID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbTypeProtocol
            // 
            cmbTypeProtocol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeProtocol.FormattingEnabled = true;
            cmbTypeProtocol.Items.AddRange(new object[] { "", "Modbus RTU", "Modbus TCP", "Modbus ASCII", "VTD" });
            cmbTypeProtocol.Location = new Point(242, 132);
            cmbTypeProtocol.Margin = new Padding(4, 3, 4, 3);
            cmbTypeProtocol.Name = "cmbTypeProtocol";
            cmbTypeProtocol.Size = new Size(289, 23);
            cmbTypeProtocol.TabIndex = 61;
            cmbTypeProtocol.SelectedIndexChanged += control_Changed;
            // 
            // txtDeviceID
            // 
            txtDeviceID.BorderStyle = BorderStyle.FixedSingle;
            txtDeviceID.Location = new Point(243, 18);
            txtDeviceID.Margin = new Padding(4, 3, 4, 3);
            txtDeviceID.Name = "txtDeviceID";
            txtDeviceID.ReadOnly = true;
            txtDeviceID.Size = new Size(289, 23);
            txtDeviceID.TabIndex = 58;
            txtDeviceID.TextChanged += control_Changed;
            // 
            // lblTypeProtocol
            // 
            lblTypeProtocol.Location = new Point(7, 132);
            lblTypeProtocol.Margin = new Padding(4, 0, 4, 0);
            lblTypeProtocol.Name = "lblTypeProtocol";
            lblTypeProtocol.Size = new Size(154, 24);
            lblTypeProtocol.TabIndex = 79;
            lblTypeProtocol.Text = "Type of protocol";
            lblTypeProtocol.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIntervalPool
            // 
            lblIntervalPool.Location = new Point(7, 245);
            lblIntervalPool.Margin = new Padding(4, 0, 4, 0);
            lblIntervalPool.Name = "lblIntervalPool";
            lblIntervalPool.Size = new Size(154, 24);
            lblIntervalPool.TabIndex = 78;
            lblIntervalPool.Text = "Polling interval (sec)";
            lblIntervalPool.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(7, 161);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(154, 24);
            lblAddress.TabIndex = 75;
            lblAddress.Text = "Devices address";
            lblAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDateTimeLastSuccessfully
            // 
            txtDateTimeLastSuccessfully.BorderStyle = BorderStyle.FixedSingle;
            txtDateTimeLastSuccessfully.Location = new Point(243, 78);
            txtDateTimeLastSuccessfully.Margin = new Padding(4, 3, 4, 3);
            txtDateTimeLastSuccessfully.Name = "txtDateTimeLastSuccessfully";
            txtDateTimeLastSuccessfully.ReadOnly = true;
            txtDateTimeLastSuccessfully.Size = new Size(289, 23);
            txtDateTimeLastSuccessfully.TabIndex = 59;
            txtDateTimeLastSuccessfully.TextChanged += control_Changed;
            // 
            // lblTimeLastSuccessPool
            // 
            lblTimeLastSuccessPool.Location = new Point(7, 78);
            lblTimeLastSuccessPool.Margin = new Padding(4, 0, 4, 0);
            lblTimeLastSuccessPool.Name = "lblTimeLastSuccessPool";
            lblTimeLastSuccessPool.Size = new Size(232, 24);
            lblTimeLastSuccessPool.TabIndex = 77;
            lblTimeLastSuccessPool.Text = "Time of the last successful survey";
            lblTimeLastSuccessPool.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpbGroup
            // 
            gpbGroup.Controls.Add(txtDescription);
            gpbGroup.Controls.Add(lblDescriptionGroup);
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblNameGroup);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(7, 6);
            gpbGroup.Margin = new Padding(4, 3, 4, 3);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(4, 3, 4, 3);
            gpbGroup.Size = new Size(425, 188);
            gpbGroup.TabIndex = 23;
            gpbGroup.TabStop = false;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(7, 74);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(408, 93);
            txtDescription.TabIndex = 88;
            txtDescription.TextChanged += control_Changed;
            // 
            // lblDescriptionGroup
            // 
            lblDescriptionGroup.AutoSize = true;
            lblDescriptionGroup.Location = new Point(8, 55);
            lblDescriptionGroup.Margin = new Padding(4, 0, 4, 0);
            lblDescriptionGroup.Name = "lblDescriptionGroup";
            lblDescriptionGroup.Size = new Size(67, 15);
            lblDescriptionGroup.TabIndex = 87;
            lblDescriptionGroup.Text = "Description";
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(330, 35);
            ckbEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(68, 19);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.UseVisualStyleBackColor = true;
            ckbEnabled.CheckedChanged += control_Changed;
            // 
            // lblNameGroup
            // 
            lblNameGroup.AutoSize = true;
            lblNameGroup.Location = new Point(8, 13);
            lblNameGroup.Margin = new Padding(4, 0, 4, 0);
            lblNameGroup.Name = "lblNameGroup";
            lblNameGroup.Size = new Size(39, 15);
            lblNameGroup.TabIndex = 2;
            lblNameGroup.Text = "Name";
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
            // tabDeviceBuff
            // 
            tabDeviceBuff.Controls.Add(spltBuffer);
            tabDeviceBuff.Location = new Point(4, 24);
            tabDeviceBuff.Name = "tabDeviceBuff";
            tabDeviceBuff.Padding = new Padding(3);
            tabDeviceBuff.Size = new Size(892, 672);
            tabDeviceBuff.TabIndex = 1;
            tabDeviceBuff.Text = "Buffer";
            tabDeviceBuff.UseVisualStyleBackColor = true;
            // 
            // spltBuffer
            // 
            spltBuffer.Dock = DockStyle.Fill;
            spltBuffer.Location = new Point(3, 3);
            spltBuffer.Margin = new Padding(4, 3, 4, 3);
            spltBuffer.Name = "spltBuffer";
            spltBuffer.Orientation = Orientation.Horizontal;
            // 
            // spltBuffer.Panel1
            // 
            spltBuffer.Panel1.Controls.Add(nudTimerInfo);
            spltBuffer.Panel1.Controls.Add(btnTimerInfo);
            spltBuffer.Panel1.Controls.Add(lblTimerInfo);
            spltBuffer.Panel1.Controls.Add(ckbAutoRefreshListRegisters);
            spltBuffer.Panel1.Controls.Add(btnSearchValue);
            spltBuffer.Panel1.Controls.Add(cmbTypeData);
            spltBuffer.Panel1.Controls.Add(lblStartRegister);
            spltBuffer.Panel1.Controls.Add(numRegisterStart);
            // 
            // spltBuffer.Panel2
            // 
            spltBuffer.Panel2.Controls.Add(tabDeviceBuffer);
            spltBuffer.Size = new Size(886, 666);
            spltBuffer.SplitterDistance = 47;
            spltBuffer.SplitterWidth = 5;
            spltBuffer.TabIndex = 23;
            // 
            // nudTimerInfo
            // 
            nudTimerInfo.Location = new Point(751, 11);
            nudTimerInfo.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            nudTimerInfo.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nudTimerInfo.Name = "nudTimerInfo";
            nudTimerInfo.Size = new Size(87, 23);
            nudTimerInfo.TabIndex = 114;
            nudTimerInfo.Value = new decimal(new int[] { 100, 0, 0, 0 });
            nudTimerInfo.Visible = false;
            // 
            // btnTimerInfo
            // 
            btnTimerInfo.Location = new Point(844, 9);
            btnTimerInfo.Name = "btnTimerInfo";
            btnTimerInfo.Size = new Size(30, 27);
            btnTimerInfo.TabIndex = 113;
            btnTimerInfo.Text = "Ok";
            btnTimerInfo.UseVisualStyleBackColor = true;
            btnTimerInfo.Visible = false;
            // 
            // lblTimerInfo
            // 
            lblTimerInfo.AutoSize = true;
            lblTimerInfo.Location = new Point(669, 15);
            lblTimerInfo.Margin = new Padding(4, 0, 4, 0);
            lblTimerInfo.Name = "lblTimerInfo";
            lblTimerInfo.Size = new Size(70, 15);
            lblTimerInfo.TabIndex = 96;
            lblTimerInfo.Text = "00:00:00.000";
            // 
            // ckbAutoRefreshListRegisters
            // 
            ckbAutoRefreshListRegisters.AutoSize = true;
            ckbAutoRefreshListRegisters.Location = new Point(542, 13);
            ckbAutoRefreshListRegisters.Margin = new Padding(4, 3, 4, 3);
            ckbAutoRefreshListRegisters.Name = "ckbAutoRefreshListRegisters";
            ckbAutoRefreshListRegisters.Size = new Size(89, 19);
            ckbAutoRefreshListRegisters.TabIndex = 95;
            ckbAutoRefreshListRegisters.Text = "Autoupdate";
            ckbAutoRefreshListRegisters.UseVisualStyleBackColor = true;
            // 
            // btnSearchValue
            // 
            btnSearchValue.Location = new Point(151, 10);
            btnSearchValue.Margin = new Padding(4, 3, 4, 3);
            btnSearchValue.Name = "btnSearchValue";
            btnSearchValue.Size = new Size(117, 24);
            btnSearchValue.TabIndex = 93;
            btnSearchValue.Text = "Find value";
            btnSearchValue.UseVisualStyleBackColor = true;
            // 
            // cmbTypeData
            // 
            cmbTypeData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTypeData.FormattingEnabled = true;
            cmbTypeData.Items.AddRange(new object[] { "Coils", "Discrete Inputs", "Holding Registers", "Input Registers" });
            cmbTypeData.Location = new Point(4, 11);
            cmbTypeData.Margin = new Padding(4, 3, 4, 3);
            cmbTypeData.Name = "cmbTypeData";
            cmbTypeData.Size = new Size(139, 23);
            cmbTypeData.TabIndex = 92;
            // 
            // lblStartRegister
            // 
            lblStartRegister.AutoSize = true;
            lblStartRegister.Location = new Point(276, 15);
            lblStartRegister.Margin = new Padding(4, 0, 4, 0);
            lblStartRegister.Name = "lblStartRegister";
            lblStartRegister.Size = new Size(78, 15);
            lblStartRegister.TabIndex = 91;
            lblStartRegister.Text = "Page number";
            // 
            // numRegisterStart
            // 
            numRegisterStart.Location = new Point(386, 11);
            numRegisterStart.Margin = new Padding(4, 3, 4, 3);
            numRegisterStart.Maximum = new decimal(new int[] { 65, 0, 0, 0 });
            numRegisterStart.Name = "numRegisterStart";
            numRegisterStart.Size = new Size(58, 23);
            numRegisterStart.TabIndex = 90;
            numRegisterStart.ValueChanged += numRegisterStart_ValueChanged;
            // 
            // tabDeviceBuffer
            // 
            tabDeviceBuffer.Controls.Add(tabCoils);
            tabDeviceBuffer.Controls.Add(tabDiscreteInputs);
            tabDeviceBuffer.Controls.Add(tabHoldingRegisters);
            tabDeviceBuffer.Controls.Add(tabInputRegisters);
            tabDeviceBuffer.Dock = DockStyle.Fill;
            tabDeviceBuffer.Location = new Point(0, 0);
            tabDeviceBuffer.Margin = new Padding(4, 3, 4, 3);
            tabDeviceBuffer.Name = "tabDeviceBuffer";
            tabDeviceBuffer.SelectedIndex = 0;
            tabDeviceBuffer.Size = new Size(886, 614);
            tabDeviceBuffer.TabIndex = 21;
            // 
            // tabCoils
            // 
            tabCoils.Controls.Add(lstCoils);
            tabCoils.Location = new Point(4, 24);
            tabCoils.Margin = new Padding(4, 3, 4, 3);
            tabCoils.Name = "tabCoils";
            tabCoils.Size = new Size(878, 586);
            tabCoils.TabIndex = 2;
            tabCoils.Text = "Coils";
            tabCoils.UseVisualStyleBackColor = true;
            // 
            // lstCoils
            // 
            lstCoils.Columns.AddRange(new ColumnHeader[] { clmAddressCoils, clmStateCoils });
            lstCoils.ContextMenuStrip = cmnuRegisterEdit;
            lstCoils.Dock = DockStyle.Fill;
            lstCoils.FullRowSelect = true;
            lstCoils.GridLines = true;
            lstCoils.Location = new Point(0, 0);
            lstCoils.Margin = new Padding(4, 3, 4, 3);
            lstCoils.MultiSelect = false;
            lstCoils.Name = "lstCoils";
            lstCoils.Size = new Size(878, 586);
            lstCoils.TabIndex = 19;
            lstCoils.UseCompatibleStateImageBehavior = false;
            lstCoils.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressCoils
            // 
            clmAddressCoils.Text = "Address";
            clmAddressCoils.Width = 100;
            // 
            // clmStateCoils
            // 
            clmStateCoils.Text = "State";
            clmStateCoils.TextAlign = HorizontalAlignment.Center;
            clmStateCoils.Width = 100;
            // 
            // cmnuRegisterEdit
            // 
            cmnuRegisterEdit.Items.AddRange(new ToolStripItem[] { tolRegisterRefresh, tolRegisterChange, tlsSeparator_1, tolRegistersResetToZero, tlsSeparator_2, tolDataLoadAsCSV, tolDataSaveAsCSV });
            cmnuRegisterEdit.Name = "contextMenuDeviceEdit";
            cmnuRegisterEdit.Size = new Size(166, 126);
            // 
            // tolRegisterRefresh
            // 
            tolRegisterRefresh.Name = "tolRegisterRefresh";
            tolRegisterRefresh.Size = new Size(165, 22);
            tolRegisterRefresh.Text = "Refresh";
            // 
            // tolRegisterChange
            // 
            tolRegisterChange.Name = "tolRegisterChange";
            tolRegisterChange.Size = new Size(165, 22);
            tolRegisterChange.Text = "Change";
            tolRegisterChange.Click += tolRegisterChange_Click;
            // 
            // tlsSeparator_1
            // 
            tlsSeparator_1.Name = "tlsSeparator_1";
            tlsSeparator_1.Size = new Size(162, 6);
            // 
            // tolRegistersResetToZero
            // 
            tolRegistersResetToZero.Name = "tolRegistersResetToZero";
            tolRegistersResetToZero.Size = new Size(165, 22);
            tolRegistersResetToZero.Text = "Reset registers";
            // 
            // tlsSeparator_2
            // 
            tlsSeparator_2.Name = "tlsSeparator_2";
            tlsSeparator_2.Size = new Size(162, 6);
            // 
            // tolDataLoadAsCSV
            // 
            tolDataLoadAsCSV.Name = "tolDataLoadAsCSV";
            tolDataLoadAsCSV.Size = new Size(165, 22);
            tolDataLoadAsCSV.Text = "Upload from CSV";
            // 
            // tolDataSaveAsCSV
            // 
            tolDataSaveAsCSV.Name = "tolDataSaveAsCSV";
            tolDataSaveAsCSV.Size = new Size(165, 22);
            tolDataSaveAsCSV.Text = "Upload to CSV";
            // 
            // tabDiscreteInputs
            // 
            tabDiscreteInputs.Controls.Add(lstDiscreteInputs);
            tabDiscreteInputs.Location = new Point(4, 24);
            tabDiscreteInputs.Margin = new Padding(4, 3, 4, 3);
            tabDiscreteInputs.Name = "tabDiscreteInputs";
            tabDiscreteInputs.Size = new Size(878, 586);
            tabDiscreteInputs.TabIndex = 4;
            tabDiscreteInputs.Text = "Discrete Inputs";
            tabDiscreteInputs.UseVisualStyleBackColor = true;
            // 
            // lstDiscreteInputs
            // 
            lstDiscreteInputs.Columns.AddRange(new ColumnHeader[] { clmAddressDiscreteInputs, clmStateDiscreteInputs });
            lstDiscreteInputs.ContextMenuStrip = cmnuRegisterEdit;
            lstDiscreteInputs.Dock = DockStyle.Fill;
            lstDiscreteInputs.FullRowSelect = true;
            lstDiscreteInputs.GridLines = true;
            lstDiscreteInputs.Location = new Point(0, 0);
            lstDiscreteInputs.Margin = new Padding(4, 3, 4, 3);
            lstDiscreteInputs.MultiSelect = false;
            lstDiscreteInputs.Name = "lstDiscreteInputs";
            lstDiscreteInputs.Size = new Size(878, 586);
            lstDiscreteInputs.TabIndex = 19;
            lstDiscreteInputs.UseCompatibleStateImageBehavior = false;
            lstDiscreteInputs.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressDiscreteInputs
            // 
            clmAddressDiscreteInputs.Text = "Address";
            clmAddressDiscreteInputs.Width = 100;
            // 
            // clmStateDiscreteInputs
            // 
            clmStateDiscreteInputs.Text = "State";
            clmStateDiscreteInputs.TextAlign = HorizontalAlignment.Center;
            clmStateDiscreteInputs.Width = 100;
            // 
            // tabHoldingRegisters
            // 
            tabHoldingRegisters.Controls.Add(lstHoldingRegisters);
            tabHoldingRegisters.Location = new Point(4, 24);
            tabHoldingRegisters.Margin = new Padding(4, 3, 4, 3);
            tabHoldingRegisters.Name = "tabHoldingRegisters";
            tabHoldingRegisters.Size = new Size(878, 586);
            tabHoldingRegisters.TabIndex = 5;
            tabHoldingRegisters.Text = "Holding Registers";
            tabHoldingRegisters.UseVisualStyleBackColor = true;
            // 
            // lstHoldingRegisters
            // 
            lstHoldingRegisters.Columns.AddRange(new ColumnHeader[] { clmAddressHoldingRegisters, clmBINHoldingRegisters, clmHEXHoldingRegisters, clmHEX2HoldingRegisters, clmValueHoldingRegisters, clmValueFloatHoldingRegisters });
            lstHoldingRegisters.ContextMenuStrip = cmnuRegisterEdit;
            lstHoldingRegisters.Dock = DockStyle.Fill;
            lstHoldingRegisters.FullRowSelect = true;
            lstHoldingRegisters.GridLines = true;
            lstHoldingRegisters.Location = new Point(0, 0);
            lstHoldingRegisters.Margin = new Padding(4, 3, 4, 3);
            lstHoldingRegisters.Name = "lstHoldingRegisters";
            lstHoldingRegisters.Size = new Size(878, 586);
            lstHoldingRegisters.TabIndex = 16;
            lstHoldingRegisters.UseCompatibleStateImageBehavior = false;
            lstHoldingRegisters.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressHoldingRegisters
            // 
            clmAddressHoldingRegisters.Text = "Address";
            clmAddressHoldingRegisters.Width = 100;
            // 
            // clmBINHoldingRegisters
            // 
            clmBINHoldingRegisters.Text = "BIN";
            clmBINHoldingRegisters.TextAlign = HorizontalAlignment.Center;
            clmBINHoldingRegisters.Width = 220;
            // 
            // clmHEXHoldingRegisters
            // 
            clmHEXHoldingRegisters.Text = "HEX";
            clmHEXHoldingRegisters.TextAlign = HorizontalAlignment.Center;
            clmHEXHoldingRegisters.Width = 100;
            // 
            // clmHEX2HoldingRegisters
            // 
            clmHEX2HoldingRegisters.Text = "HEX (x2)";
            clmHEX2HoldingRegisters.TextAlign = HorizontalAlignment.Center;
            clmHEX2HoldingRegisters.Width = 100;
            // 
            // clmValueHoldingRegisters
            // 
            clmValueHoldingRegisters.Text = "Value";
            clmValueHoldingRegisters.TextAlign = HorizontalAlignment.Center;
            clmValueHoldingRegisters.Width = 100;
            // 
            // clmValueFloatHoldingRegisters
            // 
            clmValueFloatHoldingRegisters.Text = "Float";
            clmValueFloatHoldingRegisters.TextAlign = HorizontalAlignment.Center;
            clmValueFloatHoldingRegisters.Width = 100;
            // 
            // tabInputRegisters
            // 
            tabInputRegisters.Controls.Add(lstInputRegisters);
            tabInputRegisters.Location = new Point(4, 24);
            tabInputRegisters.Margin = new Padding(4, 3, 4, 3);
            tabInputRegisters.Name = "tabInputRegisters";
            tabInputRegisters.Size = new Size(878, 586);
            tabInputRegisters.TabIndex = 6;
            tabInputRegisters.Text = "Input Registers";
            tabInputRegisters.UseVisualStyleBackColor = true;
            // 
            // lstInputRegisters
            // 
            lstInputRegisters.Columns.AddRange(new ColumnHeader[] { clmAddressInputRegisters, clmBINInputRegisters, clmHEXInputRegisters, clmValueInputRegisters });
            lstInputRegisters.ContextMenuStrip = cmnuRegisterEdit;
            lstInputRegisters.Dock = DockStyle.Fill;
            lstInputRegisters.FullRowSelect = true;
            lstInputRegisters.GridLines = true;
            lstInputRegisters.Location = new Point(0, 0);
            lstInputRegisters.Margin = new Padding(4, 3, 4, 3);
            lstInputRegisters.Name = "lstInputRegisters";
            lstInputRegisters.Size = new Size(878, 586);
            lstInputRegisters.TabIndex = 19;
            lstInputRegisters.UseCompatibleStateImageBehavior = false;
            lstInputRegisters.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressInputRegisters
            // 
            clmAddressInputRegisters.Text = "Address";
            clmAddressInputRegisters.Width = 100;
            // 
            // clmBINInputRegisters
            // 
            clmBINInputRegisters.Text = "BIN";
            clmBINInputRegisters.TextAlign = HorizontalAlignment.Center;
            clmBINInputRegisters.Width = 220;
            // 
            // clmHEXInputRegisters
            // 
            clmHEXInputRegisters.Text = "HEX";
            clmHEXInputRegisters.TextAlign = HorizontalAlignment.Center;
            clmHEXInputRegisters.Width = 100;
            // 
            // clmValueInputRegisters
            // 
            clmValueInputRegisters.Text = "Value";
            clmValueInputRegisters.TextAlign = HorizontalAlignment.Center;
            clmValueInputRegisters.Width = 100;
            // 
            // tmrTimer
            // 
            tmrTimer.Interval = 250;
            // 
            // uscDevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabDevice);
            Name = "uscDevice";
            Size = new Size(900, 700);
            Load += uscDevice_Load;
            tabDevice.ResumeLayout(false);
            tabDeviceSettings.ResumeLayout(false);
            gpbSettingsModbus.ResumeLayout(false);
            gpbSettingsModbus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDeviceGatewayRegistersBytes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDeviceRegistersBytes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIntervalPool).EndInit();
            ((System.ComponentModel.ISupportInitialize)numAddress).EndInit();
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            tabDeviceBuff.ResumeLayout(false);
            spltBuffer.Panel1.ResumeLayout(false);
            spltBuffer.Panel1.PerformLayout();
            spltBuffer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spltBuffer).EndInit();
            spltBuffer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudTimerInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRegisterStart).EndInit();
            tabDeviceBuffer.ResumeLayout(false);
            tabCoils.ResumeLayout(false);
            cmnuRegisterEdit.ResumeLayout(false);
            tabDiscreteInputs.ResumeLayout(false);
            tabHoldingRegisters.ResumeLayout(false);
            tabInputRegisters.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabDevice;
        private TabPage tabDeviceSettings;
        private TabPage tabDeviceBuff;
        private Button btnSave;
        private GroupBox gpbSettingsModbus;
        private Label lblDeviceGatewayRegistersBytes;
        private Label lblRegisters;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private NumericUpDown numIntervalPool;
        private NumericUpDown numAddress;
        private CheckBox ckbPollingOnScheduleStatus;
        private Label lblID;
        private ComboBox cmbTypeProtocol;
        private TextBox txtDeviceID;
        private Label lblTypeProtocol;
        private Label lblIntervalPool;
        private Label lblAddress;
        private TextBox txtDateTimeLastSuccessfully;
        private Label lblTimeLastSuccessPool;
        private GroupBox gpbGroup;
        private TextBox txtDescription;
        private Label lblDescriptionGroup;
        private CheckBox ckbEnabled;
        private Label lblNameGroup;
        private TextBox txtName;
        private ContextMenuStrip cmnuRegisterEdit;
        private ToolStripMenuItem tolRegisterRefresh;
        private ToolStripMenuItem tolRegisterChange;
        private ToolStripSeparator tlsSeparator_1;
        private ToolStripMenuItem tolRegistersResetToZero;
        private ToolStripSeparator tlsSeparator_2;
        private ToolStripMenuItem tolDataLoadAsCSV;
        private ToolStripMenuItem tolDataSaveAsCSV;
        private System.Windows.Forms.Timer tmrTimer;
        private SplitContainer spltBuffer;
        private Label lblTimerInfo;
        private CheckBox ckbAutoRefreshListRegisters;
        private Button btnSearchValue;
        private ComboBox cmbTypeData;
        private Label lblStartRegister;
        private NumericUpDown numRegisterStart;
        private TabControl tabDeviceBuffer;
        private TabPage tabCoils;
        private ListView lstCoils;
        private ColumnHeader clmAddressCoils;
        private ColumnHeader clmStateCoils;
        private TabPage tabDiscreteInputs;
        private ListView lstDiscreteInputs;
        private ColumnHeader clmAddressDiscreteInputs;
        private ColumnHeader clmStateDiscreteInputs;
        private TabPage tabHoldingRegisters;
        private ListView lstHoldingRegisters;
        private ColumnHeader clmAddressHoldingRegisters;
        private ColumnHeader clmBINHoldingRegisters;
        private ColumnHeader clmHEXHoldingRegisters;
        private ColumnHeader clmValueHoldingRegisters;
        private TabPage tabInputRegisters;
        private ListView lstInputRegisters;
        private ColumnHeader clmAddressInputRegisters;
        private ColumnHeader clmBINInputRegisters;
        private ColumnHeader clmHEXInputRegisters;
        private ColumnHeader clmValueInputRegisters;
        private Label lblPollingOnScheduleStatus;
        private NumericUpDown nudTimerInfo;
        private Button btnTimerInfo;
        private NumericUpDown nudDeviceGatewayRegistersBytes;
        private NumericUpDown nudDeviceRegistersBytes;
        private ColumnHeader clmHEX2HoldingRegisters;
        private ColumnHeader clmValueFloatHoldingRegisters;
    }
}
