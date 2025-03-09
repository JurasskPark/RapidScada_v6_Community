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
            this.components = new System.ComponentModel.Container();
            this.tabDevice = new System.Windows.Forms.TabControl();
            this.tabDeviceSettings = new System.Windows.Forms.TabPage();
            this.btnDeviceSave = new System.Windows.Forms.Button();
            this.gpbSettingsModbus = new System.Windows.Forms.GroupBox();
            this.lblDevicePollingOnScheduleStatus = new System.Windows.Forms.Label();
            this.cmbDeviceGatewayRegistersBytes = new System.Windows.Forms.ComboBox();
            this.lblDeviceGatewayRegistersBytes = new System.Windows.Forms.Label();
            this.cmbDeviceFloatFormat = new System.Windows.Forms.ComboBox();
            this.lblFloatType = new System.Windows.Forms.Label();
            this.cmbDeviceRegistersBytes = new System.Windows.Forms.ComboBox();
            this.lblRegisters = new System.Windows.Forms.Label();
            this.cmbDeviceStatus = new System.Windows.Forms.ComboBox();
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.numDeviceIntervalPool = new System.Windows.Forms.NumericUpDown();
            this.numDeviceAddress = new System.Windows.Forms.NumericUpDown();
            this.ckbDevicePollingOnScheduleStatus = new System.Windows.Forms.CheckBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cmbDeviceTypeProtocol = new System.Windows.Forms.ComboBox();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.lblDeviceTypeProtocol = new System.Windows.Forms.Label();
            this.lblIntervalPool = new System.Windows.Forms.Label();
            this.lblDeviceAddress = new System.Windows.Forms.Label();
            this.txtDeviceDateTimeLastSuccessfully = new System.Windows.Forms.TextBox();
            this.lblTimeLastSuccessPool = new System.Windows.Forms.Label();
            this.gpbGroup = new System.Windows.Forms.GroupBox();
            this.txtDeviceDescription = new System.Windows.Forms.TextBox();
            this.lblDescriptionGroup = new System.Windows.Forms.Label();
            this.ckbDeviceEnabled = new System.Windows.Forms.CheckBox();
            this.lblNameGroup = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.tabDeviceBuff = new System.Windows.Forms.TabPage();
            this.spltBuffer = new System.Windows.Forms.SplitContainer();
            this.nudTimerInfo = new System.Windows.Forms.NumericUpDown();
            this.btnTimerInfo = new System.Windows.Forms.Button();
            this.lblTimerInfo = new System.Windows.Forms.Label();
            this.ckbAutoRefreshListRegisters = new System.Windows.Forms.CheckBox();
            this.btnSearchValue = new System.Windows.Forms.Button();
            this.cmbTypeData = new System.Windows.Forms.ComboBox();
            this.lblStartRegister = new System.Windows.Forms.Label();
            this.numRegisterStart = new System.Windows.Forms.NumericUpDown();
            this.tabDeviceBuffer = new System.Windows.Forms.TabControl();
            this.tabCoils = new System.Windows.Forms.TabPage();
            this.lstCoils = new System.Windows.Forms.ListView();
            this.clmAddressCoils = new System.Windows.Forms.ColumnHeader();
            this.clmStateCoils = new System.Windows.Forms.ColumnHeader();
            this.cmnuRegisterEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tolRegisterRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tolRegisterChange = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsSeparator_1 = new System.Windows.Forms.ToolStripSeparator();
            this.tolRegistersResetToZero = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsSeparator_2 = new System.Windows.Forms.ToolStripSeparator();
            this.tolDataLoadAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tolDataSaveAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.tabDiscreteInputs = new System.Windows.Forms.TabPage();
            this.lstDiscreteInputs = new System.Windows.Forms.ListView();
            this.clmAddressDiscreteInputs = new System.Windows.Forms.ColumnHeader();
            this.clmStateDiscreteInputs = new System.Windows.Forms.ColumnHeader();
            this.tabHoldingRegisters = new System.Windows.Forms.TabPage();
            this.lstHoldingRegisters = new System.Windows.Forms.ListView();
            this.clmAddressHoldingRegisters = new System.Windows.Forms.ColumnHeader();
            this.clmBINHoldingRegisters = new System.Windows.Forms.ColumnHeader();
            this.clmHEXHoldingRegisters = new System.Windows.Forms.ColumnHeader();
            this.clmValueHoldingRegisters = new System.Windows.Forms.ColumnHeader();
            this.tabInputRegisters = new System.Windows.Forms.TabPage();
            this.lstInputRegisters = new System.Windows.Forms.ListView();
            this.clmAddressInputRegisters = new System.Windows.Forms.ColumnHeader();
            this.clmBINInputRegisters = new System.Windows.Forms.ColumnHeader();
            this.clmHEXInputRegisters = new System.Windows.Forms.ColumnHeader();
            this.clmValueInputRegisters = new System.Windows.Forms.ColumnHeader();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.tabDevice.SuspendLayout();
            this.tabDeviceSettings.SuspendLayout();
            this.gpbSettingsModbus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceIntervalPool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceAddress)).BeginInit();
            this.gpbGroup.SuspendLayout();
            this.tabDeviceBuff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltBuffer)).BeginInit();
            this.spltBuffer.Panel1.SuspendLayout();
            this.spltBuffer.Panel2.SuspendLayout();
            this.spltBuffer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegisterStart)).BeginInit();
            this.tabDeviceBuffer.SuspendLayout();
            this.tabCoils.SuspendLayout();
            this.cmnuRegisterEdit.SuspendLayout();
            this.tabDiscreteInputs.SuspendLayout();
            this.tabHoldingRegisters.SuspendLayout();
            this.tabInputRegisters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.tabDeviceSettings);
            this.tabDevice.Controls.Add(this.tabDeviceBuff);
            this.tabDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDevice.Location = new System.Drawing.Point(0, 0);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.SelectedIndex = 0;
            this.tabDevice.Size = new System.Drawing.Size(900, 700);
            this.tabDevice.TabIndex = 0;
            // 
            // tabDeviceSettings
            // 
            this.tabDeviceSettings.Controls.Add(this.btnDeviceSave);
            this.tabDeviceSettings.Controls.Add(this.gpbSettingsModbus);
            this.tabDeviceSettings.Controls.Add(this.gpbGroup);
            this.tabDeviceSettings.Location = new System.Drawing.Point(4, 24);
            this.tabDeviceSettings.Name = "tabDeviceSettings";
            this.tabDeviceSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceSettings.Size = new System.Drawing.Size(892, 672);
            this.tabDeviceSettings.TabIndex = 0;
            this.tabDeviceSettings.Text = "Настройки";
            this.tabDeviceSettings.UseVisualStyleBackColor = true;
            // 
            // btnDeviceSave
            // 
            this.btnDeviceSave.Location = new System.Drawing.Point(441, 13);
            this.btnDeviceSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDeviceSave.Name = "btnDeviceSave";
            this.btnDeviceSave.Size = new System.Drawing.Size(107, 27);
            this.btnDeviceSave.TabIndex = 25;
            this.btnDeviceSave.Text = "Сохранить";
            this.btnDeviceSave.UseVisualStyleBackColor = true;
            this.btnDeviceSave.Click += new System.EventHandler(this.btnDeviceSave_Click);
            // 
            // gpbSettingsModbus
            // 
            this.gpbSettingsModbus.Controls.Add(this.lblDevicePollingOnScheduleStatus);
            this.gpbSettingsModbus.Controls.Add(this.cmbDeviceGatewayRegistersBytes);
            this.gpbSettingsModbus.Controls.Add(this.lblDeviceGatewayRegistersBytes);
            this.gpbSettingsModbus.Controls.Add(this.cmbDeviceFloatFormat);
            this.gpbSettingsModbus.Controls.Add(this.lblFloatType);
            this.gpbSettingsModbus.Controls.Add(this.cmbDeviceRegistersBytes);
            this.gpbSettingsModbus.Controls.Add(this.lblRegisters);
            this.gpbSettingsModbus.Controls.Add(this.cmbDeviceStatus);
            this.gpbSettingsModbus.Controls.Add(this.lblDeviceStatus);
            this.gpbSettingsModbus.Controls.Add(this.numDeviceIntervalPool);
            this.gpbSettingsModbus.Controls.Add(this.numDeviceAddress);
            this.gpbSettingsModbus.Controls.Add(this.ckbDevicePollingOnScheduleStatus);
            this.gpbSettingsModbus.Controls.Add(this.lblID);
            this.gpbSettingsModbus.Controls.Add(this.cmbDeviceTypeProtocol);
            this.gpbSettingsModbus.Controls.Add(this.txtDeviceID);
            this.gpbSettingsModbus.Controls.Add(this.lblDeviceTypeProtocol);
            this.gpbSettingsModbus.Controls.Add(this.lblIntervalPool);
            this.gpbSettingsModbus.Controls.Add(this.lblDeviceAddress);
            this.gpbSettingsModbus.Controls.Add(this.txtDeviceDateTimeLastSuccessfully);
            this.gpbSettingsModbus.Controls.Add(this.lblTimeLastSuccessPool);
            this.gpbSettingsModbus.Location = new System.Drawing.Point(7, 200);
            this.gpbSettingsModbus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbSettingsModbus.Name = "gpbSettingsModbus";
            this.gpbSettingsModbus.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbSettingsModbus.Size = new System.Drawing.Size(539, 317);
            this.gpbSettingsModbus.TabIndex = 26;
            this.gpbSettingsModbus.TabStop = false;
            // 
            // lblDevicePollingOnScheduleStatus
            // 
            this.lblDevicePollingOnScheduleStatus.AutoSize = true;
            this.lblDevicePollingOnScheduleStatus.Location = new System.Drawing.Point(8, 111);
            this.lblDevicePollingOnScheduleStatus.Name = "lblDevicePollingOnScheduleStatus";
            this.lblDevicePollingOnScheduleStatus.Size = new System.Drawing.Size(132, 15);
            this.lblDevicePollingOnScheduleStatus.TabIndex = 95;
            this.lblDevicePollingOnScheduleStatus.Text = "Опрос по расписанию";
            // 
            // cmbDeviceGatewayRegistersBytes
            // 
            this.cmbDeviceGatewayRegistersBytes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceGatewayRegistersBytes.FormattingEnabled = true;
            this.cmbDeviceGatewayRegistersBytes.Items.AddRange(new object[] {
            "2-x байтовые",
            "4-х байтовые"});
            this.cmbDeviceGatewayRegistersBytes.Location = new System.Drawing.Point(243, 165);
            this.cmbDeviceGatewayRegistersBytes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDeviceGatewayRegistersBytes.Name = "cmbDeviceGatewayRegistersBytes";
            this.cmbDeviceGatewayRegistersBytes.Size = new System.Drawing.Size(289, 23);
            this.cmbDeviceGatewayRegistersBytes.TabIndex = 93;
            // 
            // lblDeviceGatewayRegistersBytes
            // 
            this.lblDeviceGatewayRegistersBytes.Location = new System.Drawing.Point(7, 166);
            this.lblDeviceGatewayRegistersBytes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeviceGatewayRegistersBytes.Name = "lblDeviceGatewayRegistersBytes";
            this.lblDeviceGatewayRegistersBytes.Size = new System.Drawing.Size(232, 24);
            this.lblDeviceGatewayRegistersBytes.TabIndex = 94;
            this.lblDeviceGatewayRegistersBytes.Text = "Тип регистров (для передачи из ПО)";
            this.lblDeviceGatewayRegistersBytes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDeviceFloatFormat
            // 
            this.cmbDeviceFloatFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceFloatFormat.FormattingEnabled = true;
            this.cmbDeviceFloatFormat.Items.AddRange(new object[] {
            "0123",
            "1032",
            "0132",
            "3210"});
            this.cmbDeviceFloatFormat.Location = new System.Drawing.Point(243, 196);
            this.cmbDeviceFloatFormat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDeviceFloatFormat.Name = "cmbDeviceFloatFormat";
            this.cmbDeviceFloatFormat.Size = new System.Drawing.Size(289, 23);
            this.cmbDeviceFloatFormat.TabIndex = 93;
            // 
            // lblFloatType
            // 
            this.lblFloatType.Location = new System.Drawing.Point(7, 197);
            this.lblFloatType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFloatType.Name = "lblFloatType";
            this.lblFloatType.Size = new System.Drawing.Size(232, 24);
            this.lblFloatType.TabIndex = 94;
            this.lblFloatType.Text = "Формат Float (порядок байт)";
            this.lblFloatType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDeviceRegistersBytes
            // 
            this.cmbDeviceRegistersBytes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceRegistersBytes.FormattingEnabled = true;
            this.cmbDeviceRegistersBytes.Items.AddRange(new object[] {
            "2-x байтовые",
            "4-х байтовые"});
            this.cmbDeviceRegistersBytes.Location = new System.Drawing.Point(243, 134);
            this.cmbDeviceRegistersBytes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDeviceRegistersBytes.Name = "cmbDeviceRegistersBytes";
            this.cmbDeviceRegistersBytes.Size = new System.Drawing.Size(289, 23);
            this.cmbDeviceRegistersBytes.TabIndex = 91;
            // 
            // lblRegisters
            // 
            this.lblRegisters.Location = new System.Drawing.Point(7, 135);
            this.lblRegisters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisters.Name = "lblRegisters";
            this.lblRegisters.Size = new System.Drawing.Size(232, 24);
            this.lblRegisters.TabIndex = 92;
            this.lblRegisters.Text = "Тип регистров (на устройстве)";
            this.lblRegisters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDeviceStatus
            // 
            this.cmbDeviceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceStatus.Enabled = false;
            this.cmbDeviceStatus.FormattingEnabled = true;
            this.cmbDeviceStatus.Items.AddRange(new object[] {
            "Неизвестно",
            "На связи",
            "Не доступно",
            "Поиск"});
            this.cmbDeviceStatus.Location = new System.Drawing.Point(243, 47);
            this.cmbDeviceStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDeviceStatus.Name = "cmbDeviceStatus";
            this.cmbDeviceStatus.Size = new System.Drawing.Size(289, 23);
            this.cmbDeviceStatus.TabIndex = 62;
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.Location = new System.Drawing.Point(7, 48);
            this.lblDeviceStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(232, 24);
            this.lblDeviceStatus.TabIndex = 90;
            this.lblDeviceStatus.Text = "Статус устройства";
            this.lblDeviceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numDeviceIntervalPool
            // 
            this.numDeviceIntervalPool.Enabled = false;
            this.numDeviceIntervalPool.Location = new System.Drawing.Point(243, 228);
            this.numDeviceIntervalPool.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numDeviceIntervalPool.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numDeviceIntervalPool.Name = "numDeviceIntervalPool";
            this.numDeviceIntervalPool.Size = new System.Drawing.Size(84, 23);
            this.numDeviceIntervalPool.TabIndex = 88;
            // 
            // numDeviceAddress
            // 
            this.numDeviceAddress.Location = new System.Drawing.Point(243, 286);
            this.numDeviceAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numDeviceAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numDeviceAddress.Name = "numDeviceAddress";
            this.numDeviceAddress.Size = new System.Drawing.Size(84, 23);
            this.numDeviceAddress.TabIndex = 87;
            this.numDeviceAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ckbDevicePollingOnScheduleStatus
            // 
            this.ckbDevicePollingOnScheduleStatus.AutoSize = true;
            this.ckbDevicePollingOnScheduleStatus.Location = new System.Drawing.Point(243, 112);
            this.ckbDevicePollingOnScheduleStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbDevicePollingOnScheduleStatus.Name = "ckbDevicePollingOnScheduleStatus";
            this.ckbDevicePollingOnScheduleStatus.Size = new System.Drawing.Size(15, 14);
            this.ckbDevicePollingOnScheduleStatus.TabIndex = 86;
            this.ckbDevicePollingOnScheduleStatus.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(7, 18);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(154, 24);
            this.lblID.TabIndex = 69;
            this.lblID.Text = "ID устройства";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDeviceTypeProtocol
            // 
            this.cmbDeviceTypeProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceTypeProtocol.FormattingEnabled = true;
            this.cmbDeviceTypeProtocol.Items.AddRange(new object[] {
            "",
            "Modbus RTU",
            "Modbus TCP",
            "Modbus ASCII",
            "ВТД"});
            this.cmbDeviceTypeProtocol.Location = new System.Drawing.Point(243, 257);
            this.cmbDeviceTypeProtocol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDeviceTypeProtocol.Name = "cmbDeviceTypeProtocol";
            this.cmbDeviceTypeProtocol.Size = new System.Drawing.Size(289, 23);
            this.cmbDeviceTypeProtocol.TabIndex = 61;
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceID.Location = new System.Drawing.Point(243, 18);
            this.txtDeviceID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.ReadOnly = true;
            this.txtDeviceID.Size = new System.Drawing.Size(289, 23);
            this.txtDeviceID.TabIndex = 58;
            // 
            // lblDeviceTypeProtocol
            // 
            this.lblDeviceTypeProtocol.Location = new System.Drawing.Point(7, 257);
            this.lblDeviceTypeProtocol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeviceTypeProtocol.Name = "lblDeviceTypeProtocol";
            this.lblDeviceTypeProtocol.Size = new System.Drawing.Size(154, 24);
            this.lblDeviceTypeProtocol.TabIndex = 79;
            this.lblDeviceTypeProtocol.Text = "Тип протокола";
            this.lblDeviceTypeProtocol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIntervalPool
            // 
            this.lblIntervalPool.Location = new System.Drawing.Point(7, 228);
            this.lblIntervalPool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIntervalPool.Name = "lblIntervalPool";
            this.lblIntervalPool.Size = new System.Drawing.Size(154, 24);
            this.lblIntervalPool.TabIndex = 78;
            this.lblIntervalPool.Text = "Интервал опроса (сек)";
            this.lblIntervalPool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeviceAddress
            // 
            this.lblDeviceAddress.Location = new System.Drawing.Point(7, 286);
            this.lblDeviceAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeviceAddress.Name = "lblDeviceAddress";
            this.lblDeviceAddress.Size = new System.Drawing.Size(154, 24);
            this.lblDeviceAddress.TabIndex = 75;
            this.lblDeviceAddress.Text = "Устройства адрес";
            this.lblDeviceAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDeviceDateTimeLastSuccessfully
            // 
            this.txtDeviceDateTimeLastSuccessfully.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeviceDateTimeLastSuccessfully.Location = new System.Drawing.Point(243, 78);
            this.txtDeviceDateTimeLastSuccessfully.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeviceDateTimeLastSuccessfully.Name = "txtDeviceDateTimeLastSuccessfully";
            this.txtDeviceDateTimeLastSuccessfully.ReadOnly = true;
            this.txtDeviceDateTimeLastSuccessfully.Size = new System.Drawing.Size(289, 23);
            this.txtDeviceDateTimeLastSuccessfully.TabIndex = 59;
            // 
            // lblTimeLastSuccessPool
            // 
            this.lblTimeLastSuccessPool.Location = new System.Drawing.Point(7, 78);
            this.lblTimeLastSuccessPool.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLastSuccessPool.Name = "lblTimeLastSuccessPool";
            this.lblTimeLastSuccessPool.Size = new System.Drawing.Size(232, 24);
            this.lblTimeLastSuccessPool.TabIndex = 77;
            this.lblTimeLastSuccessPool.Text = "Время последнего успешного опроса";
            this.lblTimeLastSuccessPool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gpbGroup
            // 
            this.gpbGroup.Controls.Add(this.txtDeviceDescription);
            this.gpbGroup.Controls.Add(this.lblDescriptionGroup);
            this.gpbGroup.Controls.Add(this.ckbDeviceEnabled);
            this.gpbGroup.Controls.Add(this.lblNameGroup);
            this.gpbGroup.Controls.Add(this.txtDeviceName);
            this.gpbGroup.Location = new System.Drawing.Point(7, 6);
            this.gpbGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbGroup.Name = "gpbGroup";
            this.gpbGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbGroup.Size = new System.Drawing.Size(425, 188);
            this.gpbGroup.TabIndex = 23;
            this.gpbGroup.TabStop = false;
            // 
            // txtDeviceDescription
            // 
            this.txtDeviceDescription.Location = new System.Drawing.Point(7, 74);
            this.txtDeviceDescription.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeviceDescription.Multiline = true;
            this.txtDeviceDescription.Name = "txtDeviceDescription";
            this.txtDeviceDescription.Size = new System.Drawing.Size(408, 93);
            this.txtDeviceDescription.TabIndex = 88;
            // 
            // lblDescriptionGroup
            // 
            this.lblDescriptionGroup.AutoSize = true;
            this.lblDescriptionGroup.Location = new System.Drawing.Point(8, 55);
            this.lblDescriptionGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescriptionGroup.Name = "lblDescriptionGroup";
            this.lblDescriptionGroup.Size = new System.Drawing.Size(62, 15);
            this.lblDescriptionGroup.TabIndex = 87;
            this.lblDescriptionGroup.Text = "Описание";
            // 
            // ckbDeviceEnabled
            // 
            this.ckbDeviceEnabled.AutoSize = true;
            this.ckbDeviceEnabled.Location = new System.Drawing.Point(330, 35);
            this.ckbDeviceEnabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbDeviceEnabled.Name = "ckbDeviceEnabled";
            this.ckbDeviceEnabled.Size = new System.Drawing.Size(78, 19);
            this.ckbDeviceEnabled.TabIndex = 13;
            this.ckbDeviceEnabled.Text = "Активное";
            this.ckbDeviceEnabled.UseVisualStyleBackColor = true;
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
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(7, 31);
            this.txtDeviceName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(314, 23);
            this.txtDeviceName.TabIndex = 1;
            // 
            // tabDeviceBuff
            // 
            this.tabDeviceBuff.Controls.Add(this.spltBuffer);
            this.tabDeviceBuff.Location = new System.Drawing.Point(4, 24);
            this.tabDeviceBuff.Name = "tabDeviceBuff";
            this.tabDeviceBuff.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceBuff.Size = new System.Drawing.Size(892, 672);
            this.tabDeviceBuff.TabIndex = 1;
            this.tabDeviceBuff.Text = "Буфер";
            this.tabDeviceBuff.UseVisualStyleBackColor = true;
            // 
            // spltBuffer
            // 
            this.spltBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltBuffer.Location = new System.Drawing.Point(3, 3);
            this.spltBuffer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.spltBuffer.Name = "spltBuffer";
            this.spltBuffer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltBuffer.Panel1
            // 
            this.spltBuffer.Panel1.Controls.Add(this.nudTimerInfo);
            this.spltBuffer.Panel1.Controls.Add(this.btnTimerInfo);
            this.spltBuffer.Panel1.Controls.Add(this.lblTimerInfo);
            this.spltBuffer.Panel1.Controls.Add(this.ckbAutoRefreshListRegisters);
            this.spltBuffer.Panel1.Controls.Add(this.btnSearchValue);
            this.spltBuffer.Panel1.Controls.Add(this.cmbTypeData);
            this.spltBuffer.Panel1.Controls.Add(this.lblStartRegister);
            this.spltBuffer.Panel1.Controls.Add(this.numRegisterStart);
            // 
            // spltBuffer.Panel2
            // 
            this.spltBuffer.Panel2.Controls.Add(this.tabDeviceBuffer);
            this.spltBuffer.Size = new System.Drawing.Size(886, 666);
            this.spltBuffer.SplitterDistance = 47;
            this.spltBuffer.SplitterWidth = 5;
            this.spltBuffer.TabIndex = 23;
            // 
            // nudTimerInfo
            // 
            this.nudTimerInfo.Location = new System.Drawing.Point(751, 11);
            this.nudTimerInfo.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudTimerInfo.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTimerInfo.Name = "nudTimerInfo";
            this.nudTimerInfo.Size = new System.Drawing.Size(87, 23);
            this.nudTimerInfo.TabIndex = 114;
            this.nudTimerInfo.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudTimerInfo.Visible = false;
            // 
            // btnTimerInfo
            // 
            this.btnTimerInfo.Location = new System.Drawing.Point(844, 9);
            this.btnTimerInfo.Name = "btnTimerInfo";
            this.btnTimerInfo.Size = new System.Drawing.Size(30, 27);
            this.btnTimerInfo.TabIndex = 113;
            this.btnTimerInfo.Text = "Ok";
            this.btnTimerInfo.UseVisualStyleBackColor = true;
            this.btnTimerInfo.Visible = false;
            // 
            // lblTimerInfo
            // 
            this.lblTimerInfo.AutoSize = true;
            this.lblTimerInfo.Location = new System.Drawing.Point(669, 15);
            this.lblTimerInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimerInfo.Name = "lblTimerInfo";
            this.lblTimerInfo.Size = new System.Drawing.Size(70, 15);
            this.lblTimerInfo.TabIndex = 96;
            this.lblTimerInfo.Text = "00:00:00.000";
            // 
            // ckbAutoRefreshListRegisters
            // 
            this.ckbAutoRefreshListRegisters.AutoSize = true;
            this.ckbAutoRefreshListRegisters.Location = new System.Drawing.Point(542, 13);
            this.ckbAutoRefreshListRegisters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbAutoRefreshListRegisters.Name = "ckbAutoRefreshListRegisters";
            this.ckbAutoRefreshListRegisters.Size = new System.Drawing.Size(119, 19);
            this.ckbAutoRefreshListRegisters.TabIndex = 95;
            this.ckbAutoRefreshListRegisters.Text = "Автообновление";
            this.ckbAutoRefreshListRegisters.UseVisualStyleBackColor = true;
            // 
            // btnSearchValue
            // 
            this.btnSearchValue.Location = new System.Drawing.Point(151, 10);
            this.btnSearchValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSearchValue.Name = "btnSearchValue";
            this.btnSearchValue.Size = new System.Drawing.Size(117, 24);
            this.btnSearchValue.TabIndex = 93;
            this.btnSearchValue.Text = "Найти значение";
            this.btnSearchValue.UseVisualStyleBackColor = true;
            // 
            // cmbTypeData
            // 
            this.cmbTypeData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeData.FormattingEnabled = true;
            this.cmbTypeData.Items.AddRange(new object[] {
            "Coils",
            "Discrete Inputs",
            "Holding Registers",
            "Input Registers"});
            this.cmbTypeData.Location = new System.Drawing.Point(4, 11);
            this.cmbTypeData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbTypeData.Name = "cmbTypeData";
            this.cmbTypeData.Size = new System.Drawing.Size(139, 23);
            this.cmbTypeData.TabIndex = 92;
            // 
            // lblStartRegister
            // 
            this.lblStartRegister.AutoSize = true;
            this.lblStartRegister.Location = new System.Drawing.Point(276, 15);
            this.lblStartRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartRegister.Name = "lblStartRegister";
            this.lblStartRegister.Size = new System.Drawing.Size(102, 15);
            this.lblStartRegister.TabIndex = 91;
            this.lblStartRegister.Text = "Номер страницы";
            // 
            // numRegisterStart
            // 
            this.numRegisterStart.Location = new System.Drawing.Point(386, 11);
            this.numRegisterStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numRegisterStart.Maximum = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.numRegisterStart.Name = "numRegisterStart";
            this.numRegisterStart.Size = new System.Drawing.Size(58, 23);
            this.numRegisterStart.TabIndex = 90;
            // 
            // tabDeviceBuffer
            // 
            this.tabDeviceBuffer.Controls.Add(this.tabCoils);
            this.tabDeviceBuffer.Controls.Add(this.tabDiscreteInputs);
            this.tabDeviceBuffer.Controls.Add(this.tabHoldingRegisters);
            this.tabDeviceBuffer.Controls.Add(this.tabInputRegisters);
            this.tabDeviceBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDeviceBuffer.Location = new System.Drawing.Point(0, 0);
            this.tabDeviceBuffer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabDeviceBuffer.Name = "tabDeviceBuffer";
            this.tabDeviceBuffer.SelectedIndex = 0;
            this.tabDeviceBuffer.Size = new System.Drawing.Size(886, 614);
            this.tabDeviceBuffer.TabIndex = 21;
            // 
            // tabCoils
            // 
            this.tabCoils.Controls.Add(this.lstCoils);
            this.tabCoils.Location = new System.Drawing.Point(4, 24);
            this.tabCoils.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabCoils.Name = "tabCoils";
            this.tabCoils.Size = new System.Drawing.Size(878, 586);
            this.tabCoils.TabIndex = 2;
            this.tabCoils.Text = "Coils";
            this.tabCoils.UseVisualStyleBackColor = true;
            // 
            // lstCoils
            // 
            this.lstCoils.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAddressCoils,
            this.clmStateCoils});
            this.lstCoils.ContextMenuStrip = this.cmnuRegisterEdit;
            this.lstCoils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCoils.FullRowSelect = true;
            this.lstCoils.GridLines = true;
            this.lstCoils.Location = new System.Drawing.Point(0, 0);
            this.lstCoils.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstCoils.MultiSelect = false;
            this.lstCoils.Name = "lstCoils";
            this.lstCoils.Size = new System.Drawing.Size(878, 586);
            this.lstCoils.TabIndex = 19;
            this.lstCoils.UseCompatibleStateImageBehavior = false;
            this.lstCoils.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressCoils
            // 
            this.clmAddressCoils.Text = "Адрес";
            this.clmAddressCoils.Width = 100;
            // 
            // clmStateCoils
            // 
            this.clmStateCoils.Text = "Статус";
            this.clmStateCoils.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmStateCoils.Width = 100;
            // 
            // cmnuRegisterEdit
            // 
            this.cmnuRegisterEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tolRegisterRefresh,
            this.tolRegisterChange,
            this.tlsSeparator_1,
            this.tolRegistersResetToZero,
            this.tlsSeparator_2,
            this.tolDataLoadAsCSV,
            this.tolDataSaveAsCSV});
            this.cmnuRegisterEdit.Name = "contextMenuDeviceEdit";
            this.cmnuRegisterEdit.Size = new System.Drawing.Size(184, 126);
            // 
            // tolRegisterRefresh
            // 
            this.tolRegisterRefresh.Name = "tolRegisterRefresh";
            this.tolRegisterRefresh.Size = new System.Drawing.Size(183, 22);
            this.tolRegisterRefresh.Text = "Обновить";
            // 
            // tolRegisterChange
            // 
            this.tolRegisterChange.Name = "tolRegisterChange";
            this.tolRegisterChange.Size = new System.Drawing.Size(183, 22);
            this.tolRegisterChange.Text = "Изменить";
            // 
            // tlsSeparator_1
            // 
            this.tlsSeparator_1.Name = "tlsSeparator_1";
            this.tlsSeparator_1.Size = new System.Drawing.Size(180, 6);
            // 
            // tolRegistersResetToZero
            // 
            this.tolRegistersResetToZero.Name = "tolRegistersResetToZero";
            this.tolRegistersResetToZero.Size = new System.Drawing.Size(183, 22);
            this.tolRegistersResetToZero.Text = "Обнулить регистры";
            // 
            // tlsSeparator_2
            // 
            this.tlsSeparator_2.Name = "tlsSeparator_2";
            this.tlsSeparator_2.Size = new System.Drawing.Size(180, 6);
            // 
            // tolDataLoadAsCSV
            // 
            this.tolDataLoadAsCSV.Name = "tolDataLoadAsCSV";
            this.tolDataLoadAsCSV.Size = new System.Drawing.Size(183, 22);
            this.tolDataLoadAsCSV.Text = "Загрузить из CSV";
            // 
            // tolDataSaveAsCSV
            // 
            this.tolDataSaveAsCSV.Name = "tolDataSaveAsCSV";
            this.tolDataSaveAsCSV.Size = new System.Drawing.Size(183, 22);
            this.tolDataSaveAsCSV.Text = "Выгрузить в CSV";
            // 
            // tabDiscreteInputs
            // 
            this.tabDiscreteInputs.Controls.Add(this.lstDiscreteInputs);
            this.tabDiscreteInputs.Location = new System.Drawing.Point(4, 24);
            this.tabDiscreteInputs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabDiscreteInputs.Name = "tabDiscreteInputs";
            this.tabDiscreteInputs.Size = new System.Drawing.Size(878, 586);
            this.tabDiscreteInputs.TabIndex = 4;
            this.tabDiscreteInputs.Text = "Discrete Inputs";
            this.tabDiscreteInputs.UseVisualStyleBackColor = true;
            // 
            // lstDiscreteInputs
            // 
            this.lstDiscreteInputs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAddressDiscreteInputs,
            this.clmStateDiscreteInputs});
            this.lstDiscreteInputs.ContextMenuStrip = this.cmnuRegisterEdit;
            this.lstDiscreteInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDiscreteInputs.FullRowSelect = true;
            this.lstDiscreteInputs.GridLines = true;
            this.lstDiscreteInputs.Location = new System.Drawing.Point(0, 0);
            this.lstDiscreteInputs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstDiscreteInputs.MultiSelect = false;
            this.lstDiscreteInputs.Name = "lstDiscreteInputs";
            this.lstDiscreteInputs.Size = new System.Drawing.Size(878, 586);
            this.lstDiscreteInputs.TabIndex = 19;
            this.lstDiscreteInputs.UseCompatibleStateImageBehavior = false;
            this.lstDiscreteInputs.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressDiscreteInputs
            // 
            this.clmAddressDiscreteInputs.Text = "Адрес";
            this.clmAddressDiscreteInputs.Width = 100;
            // 
            // clmStateDiscreteInputs
            // 
            this.clmStateDiscreteInputs.Text = "Статус";
            this.clmStateDiscreteInputs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmStateDiscreteInputs.Width = 100;
            // 
            // tabHoldingRegisters
            // 
            this.tabHoldingRegisters.Controls.Add(this.lstHoldingRegisters);
            this.tabHoldingRegisters.Location = new System.Drawing.Point(4, 24);
            this.tabHoldingRegisters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabHoldingRegisters.Name = "tabHoldingRegisters";
            this.tabHoldingRegisters.Size = new System.Drawing.Size(878, 586);
            this.tabHoldingRegisters.TabIndex = 5;
            this.tabHoldingRegisters.Text = "Holding Registers";
            this.tabHoldingRegisters.UseVisualStyleBackColor = true;
            // 
            // lstHoldingRegisters
            // 
            this.lstHoldingRegisters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAddressHoldingRegisters,
            this.clmBINHoldingRegisters,
            this.clmHEXHoldingRegisters,
            this.clmValueHoldingRegisters});
            this.lstHoldingRegisters.ContextMenuStrip = this.cmnuRegisterEdit;
            this.lstHoldingRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHoldingRegisters.FullRowSelect = true;
            this.lstHoldingRegisters.GridLines = true;
            this.lstHoldingRegisters.Location = new System.Drawing.Point(0, 0);
            this.lstHoldingRegisters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstHoldingRegisters.Name = "lstHoldingRegisters";
            this.lstHoldingRegisters.Size = new System.Drawing.Size(878, 586);
            this.lstHoldingRegisters.TabIndex = 16;
            this.lstHoldingRegisters.UseCompatibleStateImageBehavior = false;
            this.lstHoldingRegisters.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressHoldingRegisters
            // 
            this.clmAddressHoldingRegisters.Text = "Адрес";
            this.clmAddressHoldingRegisters.Width = 100;
            // 
            // clmBINHoldingRegisters
            // 
            this.clmBINHoldingRegisters.Text = "BIN";
            this.clmBINHoldingRegisters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmBINHoldingRegisters.Width = 220;
            // 
            // clmHEXHoldingRegisters
            // 
            this.clmHEXHoldingRegisters.Text = "HEX";
            this.clmHEXHoldingRegisters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmHEXHoldingRegisters.Width = 100;
            // 
            // clmValueHoldingRegisters
            // 
            this.clmValueHoldingRegisters.Text = "Значение";
            this.clmValueHoldingRegisters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmValueHoldingRegisters.Width = 100;
            // 
            // tabInputRegisters
            // 
            this.tabInputRegisters.Controls.Add(this.lstInputRegisters);
            this.tabInputRegisters.Location = new System.Drawing.Point(4, 24);
            this.tabInputRegisters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabInputRegisters.Name = "tabInputRegisters";
            this.tabInputRegisters.Size = new System.Drawing.Size(878, 586);
            this.tabInputRegisters.TabIndex = 6;
            this.tabInputRegisters.Text = "Input Registers";
            this.tabInputRegisters.UseVisualStyleBackColor = true;
            // 
            // lstInputRegisters
            // 
            this.lstInputRegisters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmAddressInputRegisters,
            this.clmBINInputRegisters,
            this.clmHEXInputRegisters,
            this.clmValueInputRegisters});
            this.lstInputRegisters.ContextMenuStrip = this.cmnuRegisterEdit;
            this.lstInputRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInputRegisters.FullRowSelect = true;
            this.lstInputRegisters.GridLines = true;
            this.lstInputRegisters.Location = new System.Drawing.Point(0, 0);
            this.lstInputRegisters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstInputRegisters.Name = "lstInputRegisters";
            this.lstInputRegisters.Size = new System.Drawing.Size(878, 586);
            this.lstInputRegisters.TabIndex = 19;
            this.lstInputRegisters.UseCompatibleStateImageBehavior = false;
            this.lstInputRegisters.View = System.Windows.Forms.View.Details;
            // 
            // clmAddressInputRegisters
            // 
            this.clmAddressInputRegisters.Text = "Адрес";
            this.clmAddressInputRegisters.Width = 100;
            // 
            // clmBINInputRegisters
            // 
            this.clmBINInputRegisters.Text = "BIN";
            this.clmBINInputRegisters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmBINInputRegisters.Width = 220;
            // 
            // clmHEXInputRegisters
            // 
            this.clmHEXInputRegisters.Text = "HEX";
            this.clmHEXInputRegisters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmHEXInputRegisters.Width = 100;
            // 
            // clmValueInputRegisters
            // 
            this.clmValueInputRegisters.Text = "Значение";
            this.clmValueInputRegisters.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clmValueInputRegisters.Width = 100;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 250;
            // 
            // uscDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabDevice);
            this.Name = "uscDevice";
            this.Size = new System.Drawing.Size(900, 700);
            this.Load += new System.EventHandler(this.uscDevice_Load);
            this.tabDevice.ResumeLayout(false);
            this.tabDeviceSettings.ResumeLayout(false);
            this.gpbSettingsModbus.ResumeLayout(false);
            this.gpbSettingsModbus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceIntervalPool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceAddress)).EndInit();
            this.gpbGroup.ResumeLayout(false);
            this.gpbGroup.PerformLayout();
            this.tabDeviceBuff.ResumeLayout(false);
            this.spltBuffer.Panel1.ResumeLayout(false);
            this.spltBuffer.Panel1.PerformLayout();
            this.spltBuffer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltBuffer)).EndInit();
            this.spltBuffer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRegisterStart)).EndInit();
            this.tabDeviceBuffer.ResumeLayout(false);
            this.tabCoils.ResumeLayout(false);
            this.cmnuRegisterEdit.ResumeLayout(false);
            this.tabDiscreteInputs.ResumeLayout(false);
            this.tabHoldingRegisters.ResumeLayout(false);
            this.tabInputRegisters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabDevice;
        private TabPage tabDeviceSettings;
        private TabPage tabDeviceBuff;
        private Button btnDeviceSave;
        private GroupBox gpbSettingsModbus;
        private ComboBox cmbDeviceGatewayRegistersBytes;
        private Label lblDeviceGatewayRegistersBytes;
        private ComboBox cmbDeviceFloatFormat;
        private Label lblFloatType;
        private ComboBox cmbDeviceRegistersBytes;
        private Label lblRegisters;
        private ComboBox cmbDeviceStatus;
        private Label lblDeviceStatus;
        private NumericUpDown numDeviceIntervalPool;
        private NumericUpDown numDeviceAddress;
        private CheckBox ckbDevicePollingOnScheduleStatus;
        private Label lblID;
        private ComboBox cmbDeviceTypeProtocol;
        private TextBox txtDeviceID;
        private Label lblDeviceTypeProtocol;
        private Label lblIntervalPool;
        private Label lblDeviceAddress;
        private TextBox txtDeviceDateTimeLastSuccessfully;
        private Label lblTimeLastSuccessPool;
        private GroupBox gpbGroup;
        private TextBox txtDeviceDescription;
        private Label lblDescriptionGroup;
        private CheckBox ckbDeviceEnabled;
        private Label lblNameGroup;
        private TextBox txtDeviceName;
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
        private Label lblDevicePollingOnScheduleStatus;
        private NumericUpDown nudTimerInfo;
        private Button btnTimerInfo;
    }
}
