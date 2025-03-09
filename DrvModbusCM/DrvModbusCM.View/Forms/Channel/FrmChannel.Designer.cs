namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmChannel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChannel));
            tabChannel = new TabControl();
            tabChannelSettings = new TabPage();
            gpbGroup = new GroupBox();
            ckbEnabled = new CheckBox();
            lblName = new Label();
            txtName = new TextBox();
            btnSave = new Button();
            gpbSettingsСhannel = new GroupBox();
            lblСhannelID = new Label();
            txtСhannelID = new TextBox();
            lblType = new Label();
            cmbType = new ComboBox();
            rchChannelInfo = new RichTextBox();
            gpbSerialPort = new GroupBox();
            gbSerialPortSettings = new GroupBox();
            cmbPortName = new ComboBox();
            cmbBaudRate = new ComboBox();
            cmbStopBits = new ComboBox();
            cmbParity = new ComboBox();
            cmbDataBits = new ComboBox();
            lblComPort = new Label();
            lblStopBits = new Label();
            lblBaudRate = new Label();
            lblDataBits = new Label();
            lblParity = new Label();
            gpbSerialPortTypeSignals = new GroupBox();
            ckbRTS = new CheckBox();
            ckbDTR = new CheckBox();
            gpbSerialPortHandshake = new GroupBox();
            numSerialPortReceivedBytesThreshold = new NumericUpDown();
            cmbHandshake = new ComboBox();
            lblSerialPortReceivedBytesThreshold = new Label();
            lblHandshake = new Label();
            gpbTCPUDPClient = new GroupBox();
            gpbTCPUDPClientSettings = new GroupBox();
            numPort = new NumericUpDown();
            txtHost = new TextBox();
            lblPort = new Label();
            lblHost = new Label();
            tabChannelSettingsAdvanced = new TabPage();
            btnSaveOptions = new Button();
            gpbSettingsСhannelGateway = new GroupBox();
            lblConnectedClientsMax = new Label();
            numChannelConnectedClientsMax = new NumericUpDown();
            btnChannelGatewayPortChecked = new Button();
            label2 = new Label();
            numChannelGatewayPort = new NumericUpDown();
            label1 = new Label();
            cmbChannelGatewayTypeProtocol = new ComboBox();
            gpbSettingsChannelTime = new GroupBox();
            numChannelTimeout = new NumericUpDown();
            lblms_3 = new Label();
            numChannelReadTimeout = new NumericUpDown();
            numChannelWriteTimeout = new NumericUpDown();
            lblChannelTimeout = new Label();
            lblms_2 = new Label();
            lblms_1 = new Label();
            lblChannelReadTimeout = new Label();
            lblChannelWriteTimeout = new Label();
            gpbSettingsChannelBufferSize = new GroupBox();
            lblChannelReadBufferSize = new Label();
            lblChannelWriteBufferSize = new Label();
            numChannelWriteBufferSize = new NumericUpDown();
            numChannelReadBufferSize = new NumericUpDown();
            gpbSettingsСhannelNumError = new GroupBox();
            numChannelCountError = new NumericUpDown();
            lblChannelCountError = new Label();
            tabChannel.SuspendLayout();
            tabChannelSettings.SuspendLayout();
            gpbGroup.SuspendLayout();
            gpbSettingsСhannel.SuspendLayout();
            gpbSerialPort.SuspendLayout();
            gbSerialPortSettings.SuspendLayout();
            gpbSerialPortTypeSignals.SuspendLayout();
            gpbSerialPortHandshake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSerialPortReceivedBytesThreshold).BeginInit();
            gpbTCPUDPClient.SuspendLayout();
            gpbTCPUDPClientSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
            tabChannelSettingsAdvanced.SuspendLayout();
            gpbSettingsСhannelGateway.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelConnectedClientsMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelGatewayPort).BeginInit();
            gpbSettingsChannelTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelReadTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteTimeout).BeginInit();
            gpbSettingsChannelBufferSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteBufferSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelReadBufferSize).BeginInit();
            gpbSettingsСhannelNumError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelCountError).BeginInit();
            SuspendLayout();
            // 
            // tabChannel
            // 
            tabChannel.Controls.Add(tabChannelSettings);
            tabChannel.Controls.Add(tabChannelSettingsAdvanced);
            tabChannel.Dock = DockStyle.Fill;
            tabChannel.Location = new Point(0, 0);
            tabChannel.Margin = new Padding(4, 5, 4, 5);
            tabChannel.Name = "tabChannel";
            tabChannel.SelectedIndex = 0;
            tabChannel.Size = new Size(1120, 1090);
            tabChannel.TabIndex = 78;
            // 
            // tabChannelSettings
            // 
            tabChannelSettings.Controls.Add(gpbGroup);
            tabChannelSettings.Controls.Add(btnSave);
            tabChannelSettings.Controls.Add(gpbSettingsСhannel);
            tabChannelSettings.Controls.Add(rchChannelInfo);
            tabChannelSettings.Controls.Add(gpbSerialPort);
            tabChannelSettings.Controls.Add(gpbTCPUDPClient);
            tabChannelSettings.Location = new Point(4, 34);
            tabChannelSettings.Margin = new Padding(4, 5, 4, 5);
            tabChannelSettings.Name = "tabChannelSettings";
            tabChannelSettings.Padding = new Padding(4, 5, 4, 5);
            tabChannelSettings.Size = new Size(1112, 1052);
            tabChannelSettings.TabIndex = 0;
            tabChannelSettings.Text = "Settings";
            tabChannelSettings.UseVisualStyleBackColor = true;
            // 
            // gpbGroup
            // 
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblName);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(10, 10);
            gpbGroup.Margin = new Padding(6, 5, 6, 5);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(6, 5, 6, 5);
            gpbGroup.Size = new Size(643, 112);
            gpbGroup.TabIndex = 64;
            gpbGroup.TabStop = false;
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(497, 55);
            ckbEnabled.Margin = new Padding(6, 5, 6, 5);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(101, 29);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.UseVisualStyleBackColor = true;
            ckbEnabled.TextChanged += control_Changed;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(16, 22);
            lblName.Margin = new Padding(6, 0, 6, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(10, 52);
            txtName.Margin = new Padding(6, 5, 6, 5);
            txtName.Name = "txtName";
            txtName.Size = new Size(471, 31);
            txtName.TabIndex = 1;
            txtName.TextChanged += control_Changed;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(664, 22);
            btnSave.Margin = new Padding(6, 5, 6, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(153, 45);
            btnSave.TabIndex = 65;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // gpbSettingsСhannel
            // 
            gpbSettingsСhannel.Controls.Add(lblСhannelID);
            gpbSettingsСhannel.Controls.Add(txtСhannelID);
            gpbSettingsСhannel.Controls.Add(lblType);
            gpbSettingsСhannel.Controls.Add(cmbType);
            gpbSettingsСhannel.Location = new Point(10, 132);
            gpbSettingsСhannel.Margin = new Padding(6, 5, 6, 5);
            gpbSettingsСhannel.Name = "gpbSettingsСhannel";
            gpbSettingsСhannel.Padding = new Padding(6, 5, 6, 5);
            gpbSettingsСhannel.Size = new Size(807, 135);
            gpbSettingsСhannel.TabIndex = 66;
            gpbSettingsСhannel.TabStop = false;
            gpbSettingsСhannel.Text = "Communication channel";
            // 
            // lblСhannelID
            // 
            lblСhannelID.Location = new Point(11, 30);
            lblСhannelID.Margin = new Padding(6, 0, 6, 0);
            lblСhannelID.Name = "lblСhannelID";
            lblСhannelID.Size = new Size(103, 40);
            lblСhannelID.TabIndex = 69;
            lblСhannelID.Text = "Сhannel ID ";
            lblСhannelID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtСhannelID
            // 
            txtСhannelID.BorderStyle = BorderStyle.FixedSingle;
            txtСhannelID.Location = new Point(126, 30);
            txtСhannelID.Margin = new Padding(6, 5, 6, 5);
            txtСhannelID.Name = "txtСhannelID";
            txtСhannelID.ReadOnly = true;
            txtСhannelID.Size = new Size(356, 31);
            txtСhannelID.TabIndex = 58;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(16, 90);
            lblType.Margin = new Padding(6, 0, 6, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(49, 25);
            lblType.TabIndex = 23;
            lblType.Text = "Type";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Enabled = false;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "None", "Serial Port", "TCP client", "UDP client" });
            cmbType.Location = new Point(126, 80);
            cmbType.Margin = new Padding(6, 5, 6, 5);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(355, 33);
            cmbType.TabIndex = 22;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // rchChannelInfo
            // 
            rchChannelInfo.Location = new Point(9, 277);
            rchChannelInfo.Margin = new Padding(6, 5, 6, 5);
            rchChannelInfo.Name = "rchChannelInfo";
            rchChannelInfo.ReadOnly = true;
            rchChannelInfo.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            rchChannelInfo.Size = new Size(807, 342);
            rchChannelInfo.TabIndex = 25;
            rchChannelInfo.Text = "";
            // 
            // gpbSerialPort
            // 
            gpbSerialPort.Controls.Add(gbSerialPortSettings);
            gpbSerialPort.Controls.Add(gpbSerialPortTypeSignals);
            gpbSerialPort.Controls.Add(gpbSerialPortHandshake);
            gpbSerialPort.Location = new Point(9, 277);
            gpbSerialPort.Margin = new Padding(4, 5, 4, 5);
            gpbSerialPort.Name = "gpbSerialPort";
            gpbSerialPort.Padding = new Padding(4, 5, 4, 5);
            gpbSerialPort.Size = new Size(809, 345);
            gpbSerialPort.TabIndex = 75;
            gpbSerialPort.TabStop = false;
            gpbSerialPort.Text = "Serial port";
            // 
            // gbSerialPortSettings
            // 
            gbSerialPortSettings.Controls.Add(cmbPortName);
            gbSerialPortSettings.Controls.Add(cmbBaudRate);
            gbSerialPortSettings.Controls.Add(cmbStopBits);
            gbSerialPortSettings.Controls.Add(cmbParity);
            gbSerialPortSettings.Controls.Add(cmbDataBits);
            gbSerialPortSettings.Controls.Add(lblComPort);
            gbSerialPortSettings.Controls.Add(lblStopBits);
            gbSerialPortSettings.Controls.Add(lblBaudRate);
            gbSerialPortSettings.Controls.Add(lblDataBits);
            gbSerialPortSettings.Controls.Add(lblParity);
            gbSerialPortSettings.Location = new Point(10, 37);
            gbSerialPortSettings.Margin = new Padding(6, 5, 6, 5);
            gbSerialPortSettings.Name = "gbSerialPortSettings";
            gbSerialPortSettings.Padding = new Padding(6, 5, 6, 5);
            gbSerialPortSettings.Size = new Size(386, 295);
            gbSerialPortSettings.TabIndex = 72;
            gbSerialPortSettings.TabStop = false;
            gbSerialPortSettings.Text = "Settings";
            // 
            // cmbPortName
            // 
            cmbPortName.FormattingEnabled = true;
            cmbPortName.Location = new Point(177, 30);
            cmbPortName.Margin = new Padding(6, 5, 6, 5);
            cmbPortName.Name = "cmbPortName";
            cmbPortName.Size = new Size(195, 33);
            cmbPortName.TabIndex = 1;
            cmbPortName.SelectedIndexChanged += control_Changed;
            // 
            // cmbBaudRate
            // 
            cmbBaudRate.FormattingEnabled = true;
            cmbBaudRate.Items.AddRange(new object[] { "50", "75", "110", "134", "150", "300", "600", "1200", "1800", "2400", "4800", "7800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600" });
            cmbBaudRate.Location = new Point(177, 83);
            cmbBaudRate.Margin = new Padding(6, 5, 6, 5);
            cmbBaudRate.Name = "cmbBaudRate";
            cmbBaudRate.Size = new Size(195, 33);
            cmbBaudRate.TabIndex = 3;
            cmbBaudRate.SelectedIndexChanged += control_Changed;
            // 
            // cmbStopBits
            // 
            cmbStopBits.FormattingEnabled = true;
            cmbStopBits.Items.AddRange(new object[] { "None", "One", "Two", "OnePointFive" });
            cmbStopBits.Location = new Point(177, 238);
            cmbStopBits.Margin = new Padding(6, 5, 6, 5);
            cmbStopBits.Name = "cmbStopBits";
            cmbStopBits.Size = new Size(195, 33);
            cmbStopBits.TabIndex = 9;
            cmbStopBits.SelectedIndexChanged += control_Changed;
            // 
            // cmbParity
            // 
            cmbParity.FormattingEnabled = true;
            cmbParity.Items.AddRange(new object[] { "None", "Odd", "Even", "Mark", "Space" });
            cmbParity.Location = new Point(177, 135);
            cmbParity.Margin = new Padding(6, 5, 6, 5);
            cmbParity.Name = "cmbParity";
            cmbParity.Size = new Size(195, 33);
            cmbParity.TabIndex = 5;
            cmbParity.SelectedIndexChanged += control_Changed;
            // 
            // cmbDataBits
            // 
            cmbDataBits.FormattingEnabled = true;
            cmbDataBits.Items.AddRange(new object[] { "5", "6", "7", "8" });
            cmbDataBits.Location = new Point(177, 187);
            cmbDataBits.Margin = new Padding(6, 5, 6, 5);
            cmbDataBits.Name = "cmbDataBits";
            cmbDataBits.Size = new Size(195, 33);
            cmbDataBits.TabIndex = 7;
            cmbDataBits.SelectedIndexChanged += control_Changed;
            // 
            // lblComPort
            // 
            lblComPort.AutoSize = true;
            lblComPort.Location = new Point(24, 37);
            lblComPort.Margin = new Padding(6, 0, 6, 0);
            lblComPort.Name = "lblComPort";
            lblComPort.Size = new Size(44, 25);
            lblComPort.TabIndex = 0;
            lblComPort.Text = "Port";
            // 
            // lblStopBits
            // 
            lblStopBits.AutoSize = true;
            lblStopBits.Location = new Point(24, 245);
            lblStopBits.Margin = new Padding(6, 0, 6, 0);
            lblStopBits.Name = "lblStopBits";
            lblStopBits.Size = new Size(82, 25);
            lblStopBits.TabIndex = 8;
            lblStopBits.Text = "Stop Bits";
            // 
            // lblBaudRate
            // 
            lblBaudRate.AutoSize = true;
            lblBaudRate.Location = new Point(24, 88);
            lblBaudRate.Margin = new Padding(6, 0, 6, 0);
            lblBaudRate.Name = "lblBaudRate";
            lblBaudRate.Size = new Size(92, 25);
            lblBaudRate.TabIndex = 2;
            lblBaudRate.Text = "Baud Rate";
            // 
            // lblDataBits
            // 
            lblDataBits.AutoSize = true;
            lblDataBits.Location = new Point(24, 192);
            lblDataBits.Margin = new Padding(6, 0, 6, 0);
            lblDataBits.Name = "lblDataBits";
            lblDataBits.Size = new Size(82, 25);
            lblDataBits.TabIndex = 6;
            lblDataBits.Text = "Data Bits";
            // 
            // lblParity
            // 
            lblParity.AutoSize = true;
            lblParity.Location = new Point(24, 140);
            lblParity.Margin = new Padding(6, 0, 6, 0);
            lblParity.Name = "lblParity";
            lblParity.Size = new Size(55, 25);
            lblParity.TabIndex = 4;
            lblParity.Text = "Parity";
            // 
            // gpbSerialPortTypeSignals
            // 
            gpbSerialPortTypeSignals.Controls.Add(ckbRTS);
            gpbSerialPortTypeSignals.Controls.Add(ckbDTR);
            gpbSerialPortTypeSignals.Location = new Point(407, 185);
            gpbSerialPortTypeSignals.Margin = new Padding(6, 5, 6, 5);
            gpbSerialPortTypeSignals.Name = "gpbSerialPortTypeSignals";
            gpbSerialPortTypeSignals.Padding = new Padding(6, 5, 6, 5);
            gpbSerialPortTypeSignals.Size = new Size(386, 88);
            gpbSerialPortTypeSignals.TabIndex = 74;
            gpbSerialPortTypeSignals.TabStop = false;
            gpbSerialPortTypeSignals.Text = "Signal type";
            // 
            // ckbRTS
            // 
            ckbRTS.AutoSize = true;
            ckbRTS.Location = new Point(113, 37);
            ckbRTS.Margin = new Padding(6, 5, 6, 5);
            ckbRTS.Name = "ckbRTS";
            ckbRTS.Size = new Size(67, 29);
            ckbRTS.TabIndex = 1;
            ckbRTS.Text = "RTS";
            ckbRTS.UseVisualStyleBackColor = true;
            ckbRTS.CheckedChanged += control_Changed;
            // 
            // ckbDTR
            // 
            ckbDTR.AutoSize = true;
            ckbDTR.Location = new Point(21, 38);
            ckbDTR.Margin = new Padding(6, 5, 6, 5);
            ckbDTR.Name = "ckbDTR";
            ckbDTR.Size = new Size(70, 29);
            ckbDTR.TabIndex = 0;
            ckbDTR.Text = "DTR";
            ckbDTR.UseVisualStyleBackColor = true;
            ckbDTR.CheckedChanged += control_Changed;
            // 
            // gpbSerialPortHandshake
            // 
            gpbSerialPortHandshake.Controls.Add(numSerialPortReceivedBytesThreshold);
            gpbSerialPortHandshake.Controls.Add(cmbHandshake);
            gpbSerialPortHandshake.Controls.Add(lblSerialPortReceivedBytesThreshold);
            gpbSerialPortHandshake.Controls.Add(lblHandshake);
            gpbSerialPortHandshake.Location = new Point(407, 37);
            gpbSerialPortHandshake.Margin = new Padding(6, 5, 6, 5);
            gpbSerialPortHandshake.Name = "gpbSerialPortHandshake";
            gpbSerialPortHandshake.Padding = new Padding(6, 5, 6, 5);
            gpbSerialPortHandshake.Size = new Size(386, 138);
            gpbSerialPortHandshake.TabIndex = 73;
            gpbSerialPortHandshake.TabStop = false;
            gpbSerialPortHandshake.Text = "Handshake";
            // 
            // numSerialPortReceivedBytesThreshold
            // 
            numSerialPortReceivedBytesThreshold.Location = new Point(260, 87);
            numSerialPortReceivedBytesThreshold.Margin = new Padding(6, 5, 6, 5);
            numSerialPortReceivedBytesThreshold.Name = "numSerialPortReceivedBytesThreshold";
            numSerialPortReceivedBytesThreshold.Size = new Size(114, 31);
            numSerialPortReceivedBytesThreshold.TabIndex = 43;
            numSerialPortReceivedBytesThreshold.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSerialPortReceivedBytesThreshold.ValueChanged += control_Changed;
            // 
            // cmbHandshake
            // 
            cmbHandshake.FormattingEnabled = true;
            cmbHandshake.Items.AddRange(new object[] { "None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff" });
            cmbHandshake.Location = new Point(129, 28);
            cmbHandshake.Margin = new Padding(6, 5, 6, 5);
            cmbHandshake.Name = "cmbHandshake";
            cmbHandshake.Size = new Size(244, 33);
            cmbHandshake.TabIndex = 10;
            cmbHandshake.SelectedIndexChanged += control_Changed;
            // 
            // lblSerialPortReceivedBytesThreshold
            // 
            lblSerialPortReceivedBytesThreshold.AutoSize = true;
            lblSerialPortReceivedBytesThreshold.Location = new Point(24, 95);
            lblSerialPortReceivedBytesThreshold.Margin = new Padding(6, 0, 6, 0);
            lblSerialPortReceivedBytesThreshold.Name = "lblSerialPortReceivedBytesThreshold";
            lblSerialPortReceivedBytesThreshold.Size = new Size(230, 25);
            lblSerialPortReceivedBytesThreshold.TabIndex = 55;
            lblSerialPortReceivedBytesThreshold.Text = "Threshold of bytes received";
            // 
            // lblHandshake
            // 
            lblHandshake.AutoSize = true;
            lblHandshake.Location = new Point(24, 37);
            lblHandshake.Margin = new Padding(6, 0, 6, 0);
            lblHandshake.Name = "lblHandshake";
            lblHandshake.Size = new Size(49, 25);
            lblHandshake.TabIndex = 11;
            lblHandshake.Text = "Type";
            // 
            // gpbTCPUDPClient
            // 
            gpbTCPUDPClient.Controls.Add(gpbTCPUDPClientSettings);
            gpbTCPUDPClient.Location = new Point(9, 277);
            gpbTCPUDPClient.Margin = new Padding(4, 5, 4, 5);
            gpbTCPUDPClient.Name = "gpbTCPUDPClient";
            gpbTCPUDPClient.Padding = new Padding(4, 5, 4, 5);
            gpbTCPUDPClient.Size = new Size(809, 345);
            gpbTCPUDPClient.TabIndex = 76;
            gpbTCPUDPClient.TabStop = false;
            gpbTCPUDPClient.Text = "Client";
            // 
            // gpbTCPUDPClientSettings
            // 
            gpbTCPUDPClientSettings.Controls.Add(numPort);
            gpbTCPUDPClientSettings.Controls.Add(txtHost);
            gpbTCPUDPClientSettings.Controls.Add(lblPort);
            gpbTCPUDPClientSettings.Controls.Add(lblHost);
            gpbTCPUDPClientSettings.Location = new Point(10, 37);
            gpbTCPUDPClientSettings.Margin = new Padding(6, 5, 6, 5);
            gpbTCPUDPClientSettings.Name = "gpbTCPUDPClientSettings";
            gpbTCPUDPClientSettings.Padding = new Padding(6, 5, 6, 5);
            gpbTCPUDPClientSettings.Size = new Size(386, 295);
            gpbTCPUDPClientSettings.TabIndex = 72;
            gpbTCPUDPClientSettings.TabStop = false;
            gpbTCPUDPClientSettings.Text = "Settings";
            // 
            // numPort
            // 
            numPort.Location = new Point(207, 85);
            numPort.Margin = new Padding(6, 5, 6, 5);
            numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numPort.Name = "numPort";
            numPort.Size = new Size(167, 31);
            numPort.TabIndex = 80;
            numPort.Value = new decimal(new int[] { 502, 0, 0, 0 });
            numPort.ValueChanged += control_Changed;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(209, 32);
            txtHost.Margin = new Padding(6, 5, 6, 5);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(164, 31);
            txtHost.TabIndex = 79;
            txtHost.Text = "127.0.0.1";
            txtHost.TextChanged += control_Changed;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(24, 88);
            lblPort.Margin = new Padding(6, 0, 6, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(44, 25);
            lblPort.TabIndex = 77;
            lblPort.Text = "Port";
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(24, 37);
            lblHost.Margin = new Padding(6, 0, 6, 0);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(116, 25);
            lblHost.TabIndex = 78;
            lblHost.Text = "Remote Host";
            // 
            // tabChannelSettingsAdvanced
            // 
            tabChannelSettingsAdvanced.Controls.Add(btnSaveOptions);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsСhannelGateway);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsChannelTime);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsChannelBufferSize);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsСhannelNumError);
            tabChannelSettingsAdvanced.Location = new Point(4, 34);
            tabChannelSettingsAdvanced.Margin = new Padding(4, 5, 4, 5);
            tabChannelSettingsAdvanced.Name = "tabChannelSettingsAdvanced";
            tabChannelSettingsAdvanced.Padding = new Padding(4, 5, 4, 5);
            tabChannelSettingsAdvanced.Size = new Size(1112, 1052);
            tabChannelSettingsAdvanced.TabIndex = 1;
            tabChannelSettingsAdvanced.Text = "Additional options";
            tabChannelSettingsAdvanced.UseVisualStyleBackColor = true;
            // 
            // btnSaveOptions
            // 
            btnSaveOptions.Location = new Point(664, 22);
            btnSaveOptions.Margin = new Padding(6, 5, 6, 5);
            btnSaveOptions.Name = "btnSaveOptions";
            btnSaveOptions.Size = new Size(153, 45);
            btnSaveOptions.TabIndex = 71;
            btnSaveOptions.Text = "Save";
            btnSaveOptions.UseVisualStyleBackColor = true;
            btnSaveOptions.Visible = false;
            btnSaveOptions.Click += btnSaveOptions_Click;
            // 
            // gpbSettingsСhannelGateway
            // 
            gpbSettingsСhannelGateway.Controls.Add(lblConnectedClientsMax);
            gpbSettingsСhannelGateway.Controls.Add(numChannelConnectedClientsMax);
            gpbSettingsСhannelGateway.Controls.Add(btnChannelGatewayPortChecked);
            gpbSettingsСhannelGateway.Controls.Add(label2);
            gpbSettingsСhannelGateway.Controls.Add(numChannelGatewayPort);
            gpbSettingsСhannelGateway.Controls.Add(label1);
            gpbSettingsСhannelGateway.Controls.Add(cmbChannelGatewayTypeProtocol);
            gpbSettingsСhannelGateway.Location = new Point(10, 10);
            gpbSettingsСhannelGateway.Margin = new Padding(6, 5, 6, 5);
            gpbSettingsСhannelGateway.Name = "gpbSettingsСhannelGateway";
            gpbSettingsСhannelGateway.Padding = new Padding(6, 5, 6, 5);
            gpbSettingsСhannelGateway.Size = new Size(643, 148);
            gpbSettingsСhannelGateway.TabIndex = 70;
            gpbSettingsСhannelGateway.TabStop = false;
            gpbSettingsСhannelGateway.Text = "Gateway";
            gpbSettingsСhannelGateway.Visible = false;
            // 
            // lblConnectedClientsMax
            // 
            lblConnectedClientsMax.AutoSize = true;
            lblConnectedClientsMax.Location = new Point(17, 92);
            lblConnectedClientsMax.Margin = new Padding(6, 0, 6, 0);
            lblConnectedClientsMax.Name = "lblConnectedClientsMax";
            lblConnectedClientsMax.Size = new Size(386, 25);
            lblConnectedClientsMax.TabIndex = 53;
            lblConnectedClientsMax.Text = "Number of request attempts in case of an error";
            // 
            // numChannelConnectedClientsMax
            // 
            numChannelConnectedClientsMax.Location = new Point(421, 88);
            numChannelConnectedClientsMax.Margin = new Padding(6, 5, 6, 5);
            numChannelConnectedClientsMax.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numChannelConnectedClientsMax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numChannelConnectedClientsMax.Name = "numChannelConnectedClientsMax";
            numChannelConnectedClientsMax.Size = new Size(120, 31);
            numChannelConnectedClientsMax.TabIndex = 54;
            numChannelConnectedClientsMax.Tag = "";
            numChannelConnectedClientsMax.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numChannelConnectedClientsMax.ValueChanged += control_Changed;
            // 
            // btnChannelGatewayPortChecked
            // 
            btnChannelGatewayPortChecked.BackgroundImage = (Image)resources.GetObject("btnChannelGatewayPortChecked.BackgroundImage");
            btnChannelGatewayPortChecked.BackgroundImageLayout = ImageLayout.Stretch;
            btnChannelGatewayPortChecked.Location = new Point(553, 31);
            btnChannelGatewayPortChecked.Margin = new Padding(6, 5, 6, 5);
            btnChannelGatewayPortChecked.Name = "btnChannelGatewayPortChecked";
            btnChannelGatewayPortChecked.Size = new Size(39, 45);
            btnChannelGatewayPortChecked.TabIndex = 53;
            btnChannelGatewayPortChecked.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnChannelGatewayPortChecked.UseVisualStyleBackColor = true;
            btnChannelGatewayPortChecked.Click += btnChannelGatewayPortChecked_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(343, 42);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 53;
            label2.Text = "Port";
            // 
            // numChannelGatewayPort
            // 
            numChannelGatewayPort.Location = new Point(421, 38);
            numChannelGatewayPort.Margin = new Padding(6, 5, 6, 5);
            numChannelGatewayPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numChannelGatewayPort.Name = "numChannelGatewayPort";
            numChannelGatewayPort.Size = new Size(120, 31);
            numChannelGatewayPort.TabIndex = 53;
            numChannelGatewayPort.Tag = "";
            numChannelGatewayPort.ValueChanged += control_Changed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 42);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 25);
            label1.TabIndex = 25;
            label1.Text = "Type";
            // 
            // cmbChannelGatewayTypeProtocol
            // 
            cmbChannelGatewayTypeProtocol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChannelGatewayTypeProtocol.FormattingEnabled = true;
            cmbChannelGatewayTypeProtocol.Items.AddRange(new object[] { "None", "TCP serverModbus RTU", "TCP server Modbus TCP", "TCP server Modbus ASCII", "TCP server Serial Port" });
            cmbChannelGatewayTypeProtocol.Location = new Point(67, 37);
            cmbChannelGatewayTypeProtocol.Margin = new Padding(6, 5, 6, 5);
            cmbChannelGatewayTypeProtocol.Name = "cmbChannelGatewayTypeProtocol";
            cmbChannelGatewayTypeProtocol.Size = new Size(258, 33);
            cmbChannelGatewayTypeProtocol.TabIndex = 24;
            cmbChannelGatewayTypeProtocol.Click += control_Changed;
            // 
            // gpbSettingsChannelTime
            // 
            gpbSettingsChannelTime.Controls.Add(numChannelTimeout);
            gpbSettingsChannelTime.Controls.Add(lblms_3);
            gpbSettingsChannelTime.Controls.Add(numChannelReadTimeout);
            gpbSettingsChannelTime.Controls.Add(numChannelWriteTimeout);
            gpbSettingsChannelTime.Controls.Add(lblChannelTimeout);
            gpbSettingsChannelTime.Controls.Add(lblms_2);
            gpbSettingsChannelTime.Controls.Add(lblms_1);
            gpbSettingsChannelTime.Controls.Add(lblChannelReadTimeout);
            gpbSettingsChannelTime.Controls.Add(lblChannelWriteTimeout);
            gpbSettingsChannelTime.Location = new Point(10, 365);
            gpbSettingsChannelTime.Margin = new Padding(6, 5, 6, 5);
            gpbSettingsChannelTime.Name = "gpbSettingsChannelTime";
            gpbSettingsChannelTime.Padding = new Padding(6, 5, 6, 5);
            gpbSettingsChannelTime.Size = new Size(643, 190);
            gpbSettingsChannelTime.TabIndex = 68;
            gpbSettingsChannelTime.TabStop = false;
            gpbSettingsChannelTime.Text = "Waiting time for operations to be performed";
            gpbSettingsChannelTime.Visible = false;
            // 
            // numChannelTimeout
            // 
            numChannelTimeout.Location = new Point(421, 135);
            numChannelTimeout.Margin = new Padding(6, 5, 6, 5);
            numChannelTimeout.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelTimeout.Name = "numChannelTimeout";
            numChannelTimeout.Size = new Size(120, 31);
            numChannelTimeout.TabIndex = 56;
            numChannelTimeout.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numChannelTimeout.ValueChanged += control_Changed;
            // 
            // lblms_3
            // 
            lblms_3.AutoSize = true;
            lblms_3.Location = new Point(553, 138);
            lblms_3.Margin = new Padding(6, 0, 6, 0);
            lblms_3.Name = "lblms_3";
            lblms_3.Size = new Size(36, 25);
            lblms_3.TabIndex = 43;
            lblms_3.Text = "ms";
            // 
            // numChannelReadTimeout
            // 
            numChannelReadTimeout.Location = new Point(421, 85);
            numChannelReadTimeout.Margin = new Padding(6, 5, 6, 5);
            numChannelReadTimeout.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelReadTimeout.Name = "numChannelReadTimeout";
            numChannelReadTimeout.Size = new Size(120, 31);
            numChannelReadTimeout.TabIndex = 55;
            numChannelReadTimeout.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numChannelReadTimeout.ValueChanged += control_Changed;
            // 
            // numChannelWriteTimeout
            // 
            numChannelWriteTimeout.Location = new Point(421, 35);
            numChannelWriteTimeout.Margin = new Padding(6, 5, 6, 5);
            numChannelWriteTimeout.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelWriteTimeout.Name = "numChannelWriteTimeout";
            numChannelWriteTimeout.Size = new Size(120, 31);
            numChannelWriteTimeout.TabIndex = 54;
            numChannelWriteTimeout.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numChannelWriteTimeout.ValueChanged += control_Changed;
            // 
            // lblChannelTimeout
            // 
            lblChannelTimeout.AutoSize = true;
            lblChannelTimeout.Location = new Point(14, 138);
            lblChannelTimeout.Margin = new Padding(6, 0, 6, 0);
            lblChannelTimeout.Name = "lblChannelTimeout";
            lblChannelTimeout.Size = new Size(187, 25);
            lblChannelTimeout.TabIndex = 42;
            lblChannelTimeout.Text = "Time between packets";
            // 
            // lblms_2
            // 
            lblms_2.AutoSize = true;
            lblms_2.Location = new Point(553, 88);
            lblms_2.Margin = new Padding(6, 0, 6, 0);
            lblms_2.Name = "lblms_2";
            lblms_2.Size = new Size(36, 25);
            lblms_2.TabIndex = 40;
            lblms_2.Text = "ms";
            // 
            // lblms_1
            // 
            lblms_1.AutoSize = true;
            lblms_1.Location = new Point(553, 38);
            lblms_1.Margin = new Padding(6, 0, 6, 0);
            lblms_1.Name = "lblms_1";
            lblms_1.Size = new Size(36, 25);
            lblms_1.TabIndex = 39;
            lblms_1.Text = "ms";
            // 
            // lblChannelReadTimeout
            // 
            lblChannelReadTimeout.AutoSize = true;
            lblChannelReadTimeout.Location = new Point(14, 88);
            lblChannelReadTimeout.Margin = new Padding(6, 0, 6, 0);
            lblChannelReadTimeout.Name = "lblChannelReadTimeout";
            lblChannelReadTimeout.Size = new Size(116, 25);
            lblChannelReadTimeout.TabIndex = 38;
            lblChannelReadTimeout.Text = "Reading time";
            // 
            // lblChannelWriteTimeout
            // 
            lblChannelWriteTimeout.AutoSize = true;
            lblChannelWriteTimeout.Location = new Point(14, 38);
            lblChannelWriteTimeout.Margin = new Padding(6, 0, 6, 0);
            lblChannelWriteTimeout.Name = "lblChannelWriteTimeout";
            lblChannelWriteTimeout.Size = new Size(132, 25);
            lblChannelWriteTimeout.TabIndex = 36;
            lblChannelWriteTimeout.Text = "Recording time";
            // 
            // gpbSettingsChannelBufferSize
            // 
            gpbSettingsChannelBufferSize.Controls.Add(lblChannelReadBufferSize);
            gpbSettingsChannelBufferSize.Controls.Add(lblChannelWriteBufferSize);
            gpbSettingsChannelBufferSize.Controls.Add(numChannelWriteBufferSize);
            gpbSettingsChannelBufferSize.Controls.Add(numChannelReadBufferSize);
            gpbSettingsChannelBufferSize.Location = new Point(10, 267);
            gpbSettingsChannelBufferSize.Margin = new Padding(6, 5, 6, 5);
            gpbSettingsChannelBufferSize.Name = "gpbSettingsChannelBufferSize";
            gpbSettingsChannelBufferSize.Padding = new Padding(6, 5, 6, 5);
            gpbSettingsChannelBufferSize.Size = new Size(643, 88);
            gpbSettingsChannelBufferSize.TabIndex = 69;
            gpbSettingsChannelBufferSize.TabStop = false;
            gpbSettingsChannelBufferSize.Text = "Buffer";
            gpbSettingsChannelBufferSize.Visible = false;
            // 
            // lblChannelReadBufferSize
            // 
            lblChannelReadBufferSize.AutoSize = true;
            lblChannelReadBufferSize.Location = new Point(343, 37);
            lblChannelReadBufferSize.Margin = new Padding(6, 0, 6, 0);
            lblChannelReadBufferSize.Name = "lblChannelReadBufferSize";
            lblChannelReadBufferSize.Size = new Size(51, 25);
            lblChannelReadBufferSize.TabIndex = 3;
            lblChannelReadBufferSize.Text = "Read";
            // 
            // lblChannelWriteBufferSize
            // 
            lblChannelWriteBufferSize.AutoSize = true;
            lblChannelWriteBufferSize.Location = new Point(14, 37);
            lblChannelWriteBufferSize.Margin = new Padding(6, 0, 6, 0);
            lblChannelWriteBufferSize.Name = "lblChannelWriteBufferSize";
            lblChannelWriteBufferSize.Size = new Size(54, 25);
            lblChannelWriteBufferSize.TabIndex = 2;
            lblChannelWriteBufferSize.Text = "Write";
            // 
            // numChannelWriteBufferSize
            // 
            numChannelWriteBufferSize.Location = new Point(93, 33);
            numChannelWriteBufferSize.Margin = new Padding(6, 5, 6, 5);
            numChannelWriteBufferSize.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelWriteBufferSize.Name = "numChannelWriteBufferSize";
            numChannelWriteBufferSize.Size = new Size(120, 31);
            numChannelWriteBufferSize.TabIndex = 52;
            numChannelWriteBufferSize.Value = new decimal(new int[] { 8192, 0, 0, 0 });
            numChannelWriteBufferSize.ValueChanged += control_Changed;
            // 
            // numChannelReadBufferSize
            // 
            numChannelReadBufferSize.Location = new Point(421, 33);
            numChannelReadBufferSize.Margin = new Padding(6, 5, 6, 5);
            numChannelReadBufferSize.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelReadBufferSize.Name = "numChannelReadBufferSize";
            numChannelReadBufferSize.Size = new Size(120, 31);
            numChannelReadBufferSize.TabIndex = 53;
            numChannelReadBufferSize.Value = new decimal(new int[] { 8192, 0, 0, 0 });
            numChannelReadBufferSize.ValueChanged += control_Changed;
            // 
            // gpbSettingsСhannelNumError
            // 
            gpbSettingsСhannelNumError.Controls.Add(numChannelCountError);
            gpbSettingsСhannelNumError.Controls.Add(lblChannelCountError);
            gpbSettingsСhannelNumError.Location = new Point(10, 168);
            gpbSettingsСhannelNumError.Margin = new Padding(6, 5, 6, 5);
            gpbSettingsСhannelNumError.Name = "gpbSettingsСhannelNumError";
            gpbSettingsСhannelNumError.Padding = new Padding(6, 5, 6, 5);
            gpbSettingsСhannelNumError.Size = new Size(643, 88);
            gpbSettingsСhannelNumError.TabIndex = 67;
            gpbSettingsСhannelNumError.TabStop = false;
            gpbSettingsСhannelNumError.Text = "Communication Parameters";
            gpbSettingsСhannelNumError.Visible = false;
            // 
            // numChannelCountError
            // 
            numChannelCountError.Location = new Point(421, 35);
            numChannelCountError.Margin = new Padding(6, 5, 6, 5);
            numChannelCountError.Name = "numChannelCountError";
            numChannelCountError.Size = new Size(120, 31);
            numChannelCountError.TabIndex = 52;
            numChannelCountError.Tag = "";
            numChannelCountError.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numChannelCountError.ValueChanged += control_Changed;
            // 
            // lblChannelCountError
            // 
            lblChannelCountError.AutoSize = true;
            lblChannelCountError.Location = new Point(14, 38);
            lblChannelCountError.Margin = new Padding(6, 0, 6, 0);
            lblChannelCountError.Name = "lblChannelCountError";
            lblChannelCountError.Size = new Size(386, 25);
            lblChannelCountError.TabIndex = 0;
            lblChannelCountError.Text = "Number of request attempts in case of an error";
            // 
            // FrmChannel
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 1090);
            Controls.Add(tabChannel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmChannel";
            Text = "Channel";
            Load += FrmChannel_Load;
            tabChannel.ResumeLayout(false);
            tabChannelSettings.ResumeLayout(false);
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            gpbSettingsСhannel.ResumeLayout(false);
            gpbSettingsСhannel.PerformLayout();
            gpbSerialPort.ResumeLayout(false);
            gbSerialPortSettings.ResumeLayout(false);
            gbSerialPortSettings.PerformLayout();
            gpbSerialPortTypeSignals.ResumeLayout(false);
            gpbSerialPortTypeSignals.PerformLayout();
            gpbSerialPortHandshake.ResumeLayout(false);
            gpbSerialPortHandshake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSerialPortReceivedBytesThreshold).EndInit();
            gpbTCPUDPClient.ResumeLayout(false);
            gpbTCPUDPClientSettings.ResumeLayout(false);
            gpbTCPUDPClientSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
            tabChannelSettingsAdvanced.ResumeLayout(false);
            gpbSettingsСhannelGateway.ResumeLayout(false);
            gpbSettingsСhannelGateway.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelConnectedClientsMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelGatewayPort).EndInit();
            gpbSettingsChannelTime.ResumeLayout(false);
            gpbSettingsChannelTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelReadTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteTimeout).EndInit();
            gpbSettingsChannelBufferSize.ResumeLayout(false);
            gpbSettingsChannelBufferSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteBufferSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelReadBufferSize).EndInit();
            gpbSettingsСhannelNumError.ResumeLayout(false);
            gpbSettingsСhannelNumError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelCountError).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabChannel;
        private TabPage tabChannelSettings;
        private GroupBox gpbGroup;
        private CheckBox ckbEnabled;
        private Label lblName;
        private TextBox txtName;
        private Button btnSave;
        private GroupBox gpbSettingsСhannel;
        private Label lblСhannelID;
        private TextBox txtСhannelID;
        private Label lblType;
        private ComboBox cmbType;
        private RichTextBox rchChannelInfo;
        private GroupBox gpbSerialPort;
        private GroupBox gbSerialPortSettings;
        private ComboBox cmbPortName;
        private ComboBox cmbBaudRate;
        private ComboBox cmbStopBits;
        private ComboBox cmbParity;
        private ComboBox cmbDataBits;
        private Label lblComPort;
        private Label lblStopBits;
        private Label lblBaudRate;
        private Label lblDataBits;
        private Label lblParity;
        private GroupBox gpbSerialPortTypeSignals;
        private CheckBox ckbRTS;
        private CheckBox ckbDTR;
        private GroupBox gpbSerialPortHandshake;
        private NumericUpDown numSerialPortReceivedBytesThreshold;
        private ComboBox cmbHandshake;
        private Label lblSerialPortReceivedBytesThreshold;
        private Label lblHandshake;
        private GroupBox gpbTCPUDPClient;
        private GroupBox gpbTCPUDPClientSettings;
        private NumericUpDown numPort;
        private TextBox txtHost;
        private Label lblPort;
        private Label lblHost;
        private TabPage tabChannelSettingsAdvanced;
        private Button btnSaveOptions;
        private GroupBox gpbSettingsСhannelGateway;
        private Label lblConnectedClientsMax;
        private NumericUpDown numChannelConnectedClientsMax;
        private Button btnChannelGatewayPortChecked;
        private Label label2;
        private NumericUpDown numChannelGatewayPort;
        private Label label1;
        private ComboBox cmbChannelGatewayTypeProtocol;
        private GroupBox gpbSettingsChannelTime;
        private NumericUpDown numChannelTimeout;
        private Label lblms_3;
        private NumericUpDown numChannelReadTimeout;
        private NumericUpDown numChannelWriteTimeout;
        private Label lblChannelTimeout;
        private Label lblms_2;
        private Label lblms_1;
        private Label lblChannelReadTimeout;
        private Label lblChannelWriteTimeout;
        private GroupBox gpbSettingsChannelBufferSize;
        private Label lblChannelReadBufferSize;
        private Label lblChannelWriteBufferSize;
        private NumericUpDown numChannelWriteBufferSize;
        private NumericUpDown numChannelReadBufferSize;
        private GroupBox gpbSettingsСhannelNumError;
        private NumericUpDown numChannelCountError;
        private Label lblChannelCountError;
    }
}