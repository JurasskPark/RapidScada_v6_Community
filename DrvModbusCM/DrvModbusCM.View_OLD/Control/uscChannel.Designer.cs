namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscChannel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscChannel));
            lblChannelCountError = new Label();
            lblms_3 = new Label();
            numChannelReadTimeout = new NumericUpDown();
            numChannelWriteTimeout = new NumericUpDown();
            lblChannelTimeout = new Label();
            gpbSettingsСhannel = new GroupBox();
            lblСhannelID = new Label();
            txtСhannelID = new TextBox();
            lblType = new Label();
            cmbType = new ComboBox();
            rchChannelInfo = new RichTextBox();
            numChannelTimeout = new NumericUpDown();
            lblConnectedClientsMax = new Label();
            btnSave = new Button();
            gpbSettingsСhannelNumError = new GroupBox();
            numChannelCountError = new NumericUpDown();
            lblms_2 = new Label();
            numChannelConnectedClientsMax = new NumericUpDown();
            btnChannelGatewayPortChecked = new Button();
            label2 = new Label();
            numChannelGatewayPort = new NumericUpDown();
            cmbChannelGatewayTypeProtocol = new ComboBox();
            gpbSettingsСhannelGateway = new GroupBox();
            label1 = new Label();
            lblChannelReadBufferSize = new Label();
            lblChannelWriteBufferSize = new Label();
            numChannelWriteBufferSize = new NumericUpDown();
            numChannelReadBufferSize = new NumericUpDown();
            gpbSettingsChannelBufferSize = new GroupBox();
            gpbSettingsChannelTime = new GroupBox();
            lblms_1 = new Label();
            lblChannelReadTimeout = new Label();
            lblChannelWriteTimeout = new Label();
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
            gpbSerialPort = new GroupBox();
            gpbTCPUDPClient = new GroupBox();
            gpbTCPUDPClientSettings = new GroupBox();
            numPort = new NumericUpDown();
            txtHost = new TextBox();
            lblPort = new Label();
            lblHost = new Label();
            tabChannel = new TabControl();
            tabChannelSettings = new TabPage();
            gpbСhannel = new GroupBox();
            ckbEnabled = new CheckBox();
            lblNameGroup = new Label();
            txtName = new TextBox();
            tabChannelSettingsAdvanced = new TabPage();
            btnSaveOptions = new Button();
            ((System.ComponentModel.ISupportInitialize)numChannelReadTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteTimeout).BeginInit();
            gpbSettingsСhannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelTimeout).BeginInit();
            gpbSettingsСhannelNumError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelCountError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelConnectedClientsMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelGatewayPort).BeginInit();
            gpbSettingsСhannelGateway.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteBufferSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChannelReadBufferSize).BeginInit();
            gpbSettingsChannelBufferSize.SuspendLayout();
            gpbSettingsChannelTime.SuspendLayout();
            gbSerialPortSettings.SuspendLayout();
            gpbSerialPortTypeSignals.SuspendLayout();
            gpbSerialPortHandshake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSerialPortReceivedBytesThreshold).BeginInit();
            gpbSerialPort.SuspendLayout();
            gpbTCPUDPClient.SuspendLayout();
            gpbTCPUDPClientSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
            tabChannel.SuspendLayout();
            tabChannelSettings.SuspendLayout();
            gpbСhannel.SuspendLayout();
            tabChannelSettingsAdvanced.SuspendLayout();
            SuspendLayout();
            // 
            // lblChannelCountError
            // 
            lblChannelCountError.AutoSize = true;
            lblChannelCountError.Location = new Point(9, 23);
            lblChannelCountError.Margin = new Padding(4, 0, 4, 0);
            lblChannelCountError.Name = "lblChannelCountError";
            lblChannelCountError.Size = new Size(254, 15);
            lblChannelCountError.TabIndex = 0;
            lblChannelCountError.Text = "Number of request attempts in case of an error";
            // 
            // lblms_3
            // 
            lblms_3.AutoSize = true;
            lblms_3.Location = new Point(386, 83);
            lblms_3.Margin = new Padding(4, 0, 4, 0);
            lblms_3.Name = "lblms_3";
            lblms_3.Size = new Size(23, 15);
            lblms_3.TabIndex = 43;
            lblms_3.Text = "ms";
            // 
            // numChannelReadTimeout
            // 
            numChannelReadTimeout.Location = new Point(295, 51);
            numChannelReadTimeout.Margin = new Padding(4, 3, 4, 3);
            numChannelReadTimeout.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelReadTimeout.Name = "numChannelReadTimeout";
            numChannelReadTimeout.Size = new Size(84, 23);
            numChannelReadTimeout.TabIndex = 55;
            numChannelReadTimeout.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numChannelReadTimeout.ValueChanged += control_Changed;
            // 
            // numChannelWriteTimeout
            // 
            numChannelWriteTimeout.Location = new Point(295, 21);
            numChannelWriteTimeout.Margin = new Padding(4, 3, 4, 3);
            numChannelWriteTimeout.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelWriteTimeout.Name = "numChannelWriteTimeout";
            numChannelWriteTimeout.Size = new Size(84, 23);
            numChannelWriteTimeout.TabIndex = 54;
            numChannelWriteTimeout.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numChannelWriteTimeout.ValueChanged += control_Changed;
            // 
            // lblChannelTimeout
            // 
            lblChannelTimeout.AutoSize = true;
            lblChannelTimeout.Location = new Point(9, 83);
            lblChannelTimeout.Margin = new Padding(4, 0, 4, 0);
            lblChannelTimeout.Name = "lblChannelTimeout";
            lblChannelTimeout.Size = new Size(124, 15);
            lblChannelTimeout.TabIndex = 42;
            lblChannelTimeout.Text = "Time between packets";
            // 
            // gpbSettingsСhannel
            // 
            gpbSettingsСhannel.Controls.Add(lblСhannelID);
            gpbSettingsСhannel.Controls.Add(txtСhannelID);
            gpbSettingsСhannel.Controls.Add(lblType);
            gpbSettingsСhannel.Controls.Add(cmbType);
            gpbSettingsСhannel.Location = new Point(7, 79);
            gpbSettingsСhannel.Margin = new Padding(4, 3, 4, 3);
            gpbSettingsСhannel.Name = "gpbSettingsСhannel";
            gpbSettingsСhannel.Padding = new Padding(4, 3, 4, 3);
            gpbSettingsСhannel.Size = new Size(565, 81);
            gpbSettingsСhannel.TabIndex = 66;
            gpbSettingsСhannel.TabStop = false;
            gpbSettingsСhannel.Text = "Communication channel";
            // 
            // lblСhannelID
            // 
            lblСhannelID.Location = new Point(8, 18);
            lblСhannelID.Margin = new Padding(4, 0, 4, 0);
            lblСhannelID.Name = "lblСhannelID";
            lblСhannelID.Size = new Size(72, 24);
            lblСhannelID.TabIndex = 69;
            lblСhannelID.Text = "Сhannel ID ";
            lblСhannelID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtСhannelID
            // 
            txtСhannelID.BorderStyle = BorderStyle.FixedSingle;
            txtСhannelID.Location = new Point(88, 18);
            txtСhannelID.Margin = new Padding(4, 3, 4, 3);
            txtСhannelID.Name = "txtСhannelID";
            txtСhannelID.ReadOnly = true;
            txtСhannelID.Size = new Size(250, 23);
            txtСhannelID.TabIndex = 58;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(10, 54);
            lblType.Margin = new Padding(4, 0, 4, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(31, 15);
            lblType.TabIndex = 23;
            lblType.Text = "Type";
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Enabled = false;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "None", "Serial Port", "TCP client", "UDP client" });
            cmbType.Location = new Point(88, 48);
            cmbType.Margin = new Padding(4, 3, 4, 3);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(250, 23);
            cmbType.TabIndex = 22;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // rchChannelInfo
            // 
            rchChannelInfo.Location = new Point(6, 166);
            rchChannelInfo.Margin = new Padding(4, 3, 4, 3);
            rchChannelInfo.Name = "rchChannelInfo";
            rchChannelInfo.ReadOnly = true;
            rchChannelInfo.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            rchChannelInfo.Size = new Size(566, 207);
            rchChannelInfo.TabIndex = 25;
            rchChannelInfo.Text = "";
            // 
            // numChannelTimeout
            // 
            numChannelTimeout.Location = new Point(295, 81);
            numChannelTimeout.Margin = new Padding(4, 3, 4, 3);
            numChannelTimeout.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelTimeout.Name = "numChannelTimeout";
            numChannelTimeout.Size = new Size(84, 23);
            numChannelTimeout.TabIndex = 56;
            numChannelTimeout.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numChannelTimeout.ValueChanged += control_Changed;
            // 
            // lblConnectedClientsMax
            // 
            lblConnectedClientsMax.AutoSize = true;
            lblConnectedClientsMax.Location = new Point(11, 55);
            lblConnectedClientsMax.Margin = new Padding(4, 0, 4, 0);
            lblConnectedClientsMax.Name = "lblConnectedClientsMax";
            lblConnectedClientsMax.Size = new Size(254, 15);
            lblConnectedClientsMax.TabIndex = 53;
            lblConnectedClientsMax.Text = "Number of request attempts in case of an error";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(465, 13);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 65;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // gpbSettingsСhannelNumError
            // 
            gpbSettingsСhannelNumError.Controls.Add(numChannelCountError);
            gpbSettingsСhannelNumError.Controls.Add(lblChannelCountError);
            gpbSettingsСhannelNumError.Location = new Point(7, 101);
            gpbSettingsСhannelNumError.Margin = new Padding(4, 3, 4, 3);
            gpbSettingsСhannelNumError.Name = "gpbSettingsСhannelNumError";
            gpbSettingsСhannelNumError.Padding = new Padding(4, 3, 4, 3);
            gpbSettingsСhannelNumError.Size = new Size(450, 53);
            gpbSettingsСhannelNumError.TabIndex = 67;
            gpbSettingsСhannelNumError.TabStop = false;
            gpbSettingsСhannelNumError.Text = "Communication Parameters";
            gpbSettingsСhannelNumError.Visible = false;
            // 
            // numChannelCountError
            // 
            numChannelCountError.Location = new Point(295, 21);
            numChannelCountError.Margin = new Padding(4, 3, 4, 3);
            numChannelCountError.Name = "numChannelCountError";
            numChannelCountError.Size = new Size(84, 23);
            numChannelCountError.TabIndex = 52;
            numChannelCountError.Tag = "";
            numChannelCountError.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numChannelCountError.ValueChanged += control_Changed;
            // 
            // lblms_2
            // 
            lblms_2.AutoSize = true;
            lblms_2.Location = new Point(386, 53);
            lblms_2.Margin = new Padding(4, 0, 4, 0);
            lblms_2.Name = "lblms_2";
            lblms_2.Size = new Size(23, 15);
            lblms_2.TabIndex = 40;
            lblms_2.Text = "ms";
            // 
            // numChannelConnectedClientsMax
            // 
            numChannelConnectedClientsMax.Location = new Point(295, 53);
            numChannelConnectedClientsMax.Margin = new Padding(4, 3, 4, 3);
            numChannelConnectedClientsMax.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numChannelConnectedClientsMax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numChannelConnectedClientsMax.Name = "numChannelConnectedClientsMax";
            numChannelConnectedClientsMax.Size = new Size(84, 23);
            numChannelConnectedClientsMax.TabIndex = 54;
            numChannelConnectedClientsMax.Tag = "";
            numChannelConnectedClientsMax.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numChannelConnectedClientsMax.ValueChanged += control_Changed;
            // 
            // btnChannelGatewayPortChecked
            // 
            btnChannelGatewayPortChecked.BackgroundImage = (Image)resources.GetObject("btnChannelGatewayPortChecked.BackgroundImage");
            btnChannelGatewayPortChecked.BackgroundImageLayout = ImageLayout.Stretch;
            btnChannelGatewayPortChecked.Location = new Point(387, 20);
            btnChannelGatewayPortChecked.Margin = new Padding(4, 3, 4, 3);
            btnChannelGatewayPortChecked.Name = "btnChannelGatewayPortChecked";
            btnChannelGatewayPortChecked.Size = new Size(27, 27);
            btnChannelGatewayPortChecked.TabIndex = 53;
            btnChannelGatewayPortChecked.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnChannelGatewayPortChecked.UseVisualStyleBackColor = true;
            btnChannelGatewayPortChecked.Click += btnChannelGatewayPortChecked_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 53;
            label2.Text = "Port";
            // 
            // numChannelGatewayPort
            // 
            numChannelGatewayPort.Location = new Point(295, 23);
            numChannelGatewayPort.Margin = new Padding(4, 3, 4, 3);
            numChannelGatewayPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numChannelGatewayPort.Name = "numChannelGatewayPort";
            numChannelGatewayPort.Size = new Size(84, 23);
            numChannelGatewayPort.TabIndex = 53;
            numChannelGatewayPort.Tag = "";
            numChannelGatewayPort.ValueChanged += control_Changed;
            // 
            // cmbChannelGatewayTypeProtocol
            // 
            cmbChannelGatewayTypeProtocol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChannelGatewayTypeProtocol.FormattingEnabled = true;
            cmbChannelGatewayTypeProtocol.Items.AddRange(new object[] { "None", "TCP serverModbus RTU", "TCP server Modbus TCP", "TCP server Modbus ASCII", "TCP server Serial Port" });
            cmbChannelGatewayTypeProtocol.Location = new Point(47, 22);
            cmbChannelGatewayTypeProtocol.Margin = new Padding(4, 3, 4, 3);
            cmbChannelGatewayTypeProtocol.Name = "cmbChannelGatewayTypeProtocol";
            cmbChannelGatewayTypeProtocol.Size = new Size(182, 23);
            cmbChannelGatewayTypeProtocol.TabIndex = 24;
            cmbChannelGatewayTypeProtocol.SelectedIndexChanged += control_Changed;
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
            gpbSettingsСhannelGateway.Location = new Point(7, 6);
            gpbSettingsСhannelGateway.Margin = new Padding(4, 3, 4, 3);
            gpbSettingsСhannelGateway.Name = "gpbSettingsСhannelGateway";
            gpbSettingsСhannelGateway.Padding = new Padding(4, 3, 4, 3);
            gpbSettingsСhannelGateway.Size = new Size(450, 89);
            gpbSettingsСhannelGateway.TabIndex = 70;
            gpbSettingsСhannelGateway.TabStop = false;
            gpbSettingsСhannelGateway.Text = "Gateway";
            gpbSettingsСhannelGateway.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 25;
            label1.Text = "Type";
            // 
            // lblChannelReadBufferSize
            // 
            lblChannelReadBufferSize.AutoSize = true;
            lblChannelReadBufferSize.Location = new Point(239, 22);
            lblChannelReadBufferSize.Margin = new Padding(4, 0, 4, 0);
            lblChannelReadBufferSize.Name = "lblChannelReadBufferSize";
            lblChannelReadBufferSize.Size = new Size(33, 15);
            lblChannelReadBufferSize.TabIndex = 3;
            lblChannelReadBufferSize.Text = "Read";
            // 
            // lblChannelWriteBufferSize
            // 
            lblChannelWriteBufferSize.AutoSize = true;
            lblChannelWriteBufferSize.Location = new Point(9, 22);
            lblChannelWriteBufferSize.Margin = new Padding(4, 0, 4, 0);
            lblChannelWriteBufferSize.Name = "lblChannelWriteBufferSize";
            lblChannelWriteBufferSize.Size = new Size(35, 15);
            lblChannelWriteBufferSize.TabIndex = 2;
            lblChannelWriteBufferSize.Text = "Write";
            // 
            // numChannelWriteBufferSize
            // 
            numChannelWriteBufferSize.Location = new Point(65, 20);
            numChannelWriteBufferSize.Margin = new Padding(4, 3, 4, 3);
            numChannelWriteBufferSize.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelWriteBufferSize.Name = "numChannelWriteBufferSize";
            numChannelWriteBufferSize.Size = new Size(84, 23);
            numChannelWriteBufferSize.TabIndex = 52;
            numChannelWriteBufferSize.Value = new decimal(new int[] { 8192, 0, 0, 0 });
            numChannelWriteBufferSize.ValueChanged += control_Changed;
            // 
            // numChannelReadBufferSize
            // 
            numChannelReadBufferSize.Location = new Point(295, 20);
            numChannelReadBufferSize.Margin = new Padding(4, 3, 4, 3);
            numChannelReadBufferSize.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numChannelReadBufferSize.Name = "numChannelReadBufferSize";
            numChannelReadBufferSize.Size = new Size(84, 23);
            numChannelReadBufferSize.TabIndex = 53;
            numChannelReadBufferSize.Value = new decimal(new int[] { 8192, 0, 0, 0 });
            numChannelReadBufferSize.ValueChanged += control_Changed;
            // 
            // gpbSettingsChannelBufferSize
            // 
            gpbSettingsChannelBufferSize.Controls.Add(lblChannelReadBufferSize);
            gpbSettingsChannelBufferSize.Controls.Add(lblChannelWriteBufferSize);
            gpbSettingsChannelBufferSize.Controls.Add(numChannelWriteBufferSize);
            gpbSettingsChannelBufferSize.Controls.Add(numChannelReadBufferSize);
            gpbSettingsChannelBufferSize.Location = new Point(7, 160);
            gpbSettingsChannelBufferSize.Margin = new Padding(4, 3, 4, 3);
            gpbSettingsChannelBufferSize.Name = "gpbSettingsChannelBufferSize";
            gpbSettingsChannelBufferSize.Padding = new Padding(4, 3, 4, 3);
            gpbSettingsChannelBufferSize.Size = new Size(450, 53);
            gpbSettingsChannelBufferSize.TabIndex = 69;
            gpbSettingsChannelBufferSize.TabStop = false;
            gpbSettingsChannelBufferSize.Text = "Buffer";
            gpbSettingsChannelBufferSize.Visible = false;
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
            gpbSettingsChannelTime.Location = new Point(7, 219);
            gpbSettingsChannelTime.Margin = new Padding(4, 3, 4, 3);
            gpbSettingsChannelTime.Name = "gpbSettingsChannelTime";
            gpbSettingsChannelTime.Padding = new Padding(4, 3, 4, 3);
            gpbSettingsChannelTime.Size = new Size(450, 114);
            gpbSettingsChannelTime.TabIndex = 68;
            gpbSettingsChannelTime.TabStop = false;
            gpbSettingsChannelTime.Text = "Waiting time for operations to be performed";
            gpbSettingsChannelTime.Visible = false;
            // 
            // lblms_1
            // 
            lblms_1.AutoSize = true;
            lblms_1.Location = new Point(386, 23);
            lblms_1.Margin = new Padding(4, 0, 4, 0);
            lblms_1.Name = "lblms_1";
            lblms_1.Size = new Size(23, 15);
            lblms_1.TabIndex = 39;
            lblms_1.Text = "ms";
            // 
            // lblChannelReadTimeout
            // 
            lblChannelReadTimeout.AutoSize = true;
            lblChannelReadTimeout.Location = new Point(9, 53);
            lblChannelReadTimeout.Margin = new Padding(4, 0, 4, 0);
            lblChannelReadTimeout.Name = "lblChannelReadTimeout";
            lblChannelReadTimeout.Size = new Size(77, 15);
            lblChannelReadTimeout.TabIndex = 38;
            lblChannelReadTimeout.Text = "Reading time";
            // 
            // lblChannelWriteTimeout
            // 
            lblChannelWriteTimeout.AutoSize = true;
            lblChannelWriteTimeout.Location = new Point(9, 23);
            lblChannelWriteTimeout.Margin = new Padding(4, 0, 4, 0);
            lblChannelWriteTimeout.Name = "lblChannelWriteTimeout";
            lblChannelWriteTimeout.Size = new Size(88, 15);
            lblChannelWriteTimeout.TabIndex = 36;
            lblChannelWriteTimeout.Text = "Recording time";
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
            gbSerialPortSettings.Location = new Point(7, 22);
            gbSerialPortSettings.Margin = new Padding(4, 3, 4, 3);
            gbSerialPortSettings.Name = "gbSerialPortSettings";
            gbSerialPortSettings.Padding = new Padding(4, 3, 4, 3);
            gbSerialPortSettings.Size = new Size(270, 177);
            gbSerialPortSettings.TabIndex = 72;
            gbSerialPortSettings.TabStop = false;
            gbSerialPortSettings.Text = "Settings";
            // 
            // cmbPortName
            // 
            cmbPortName.FormattingEnabled = true;
            cmbPortName.Location = new Point(124, 18);
            cmbPortName.Margin = new Padding(4, 3, 4, 3);
            cmbPortName.Name = "cmbPortName";
            cmbPortName.Size = new Size(138, 23);
            cmbPortName.TabIndex = 1;
            // 
            // cmbBaudRate
            // 
            cmbBaudRate.FormattingEnabled = true;
            cmbBaudRate.Items.AddRange(new object[] { "50", "75", "110", "134", "150", "300", "600", "1200", "1800", "2400", "4800", "7800", "9600", "19200", "38400", "57600", "115200", "230400", "460800", "921600" });
            cmbBaudRate.Location = new Point(124, 50);
            cmbBaudRate.Margin = new Padding(4, 3, 4, 3);
            cmbBaudRate.Name = "cmbBaudRate";
            cmbBaudRate.Size = new Size(138, 23);
            cmbBaudRate.TabIndex = 3;
            // 
            // cmbStopBits
            // 
            cmbStopBits.FormattingEnabled = true;
            cmbStopBits.Items.AddRange(new object[] { "None", "One", "Two", "OnePointFive" });
            cmbStopBits.Location = new Point(124, 143);
            cmbStopBits.Margin = new Padding(4, 3, 4, 3);
            cmbStopBits.Name = "cmbStopBits";
            cmbStopBits.Size = new Size(138, 23);
            cmbStopBits.TabIndex = 9;
            // 
            // cmbParity
            // 
            cmbParity.FormattingEnabled = true;
            cmbParity.Items.AddRange(new object[] { "None", "Odd", "Even", "Mark", "Space" });
            cmbParity.Location = new Point(124, 81);
            cmbParity.Margin = new Padding(4, 3, 4, 3);
            cmbParity.Name = "cmbParity";
            cmbParity.Size = new Size(138, 23);
            cmbParity.TabIndex = 5;
            // 
            // cmbDataBits
            // 
            cmbDataBits.FormattingEnabled = true;
            cmbDataBits.Items.AddRange(new object[] { "5", "6", "7", "8" });
            cmbDataBits.Location = new Point(124, 112);
            cmbDataBits.Margin = new Padding(4, 3, 4, 3);
            cmbDataBits.Name = "cmbDataBits";
            cmbDataBits.Size = new Size(138, 23);
            cmbDataBits.TabIndex = 7;
            // 
            // lblComPort
            // 
            lblComPort.AutoSize = true;
            lblComPort.Location = new Point(16, 22);
            lblComPort.Margin = new Padding(4, 0, 4, 0);
            lblComPort.Name = "lblComPort";
            lblComPort.Size = new Size(29, 15);
            lblComPort.TabIndex = 0;
            lblComPort.Text = "Port";
            // 
            // lblStopBits
            // 
            lblStopBits.AutoSize = true;
            lblStopBits.Location = new Point(16, 147);
            lblStopBits.Margin = new Padding(4, 0, 4, 0);
            lblStopBits.Name = "lblStopBits";
            lblStopBits.Size = new Size(53, 15);
            lblStopBits.TabIndex = 8;
            lblStopBits.Text = "Stop Bits";
            // 
            // lblBaudRate
            // 
            lblBaudRate.AutoSize = true;
            lblBaudRate.Location = new Point(16, 53);
            lblBaudRate.Margin = new Padding(4, 0, 4, 0);
            lblBaudRate.Name = "lblBaudRate";
            lblBaudRate.Size = new Size(60, 15);
            lblBaudRate.TabIndex = 2;
            lblBaudRate.Text = "Baud Rate";
            // 
            // lblDataBits
            // 
            lblDataBits.AutoSize = true;
            lblDataBits.Location = new Point(16, 115);
            lblDataBits.Margin = new Padding(4, 0, 4, 0);
            lblDataBits.Name = "lblDataBits";
            lblDataBits.Size = new Size(53, 15);
            lblDataBits.TabIndex = 6;
            lblDataBits.Text = "Data Bits";
            // 
            // lblParity
            // 
            lblParity.AutoSize = true;
            lblParity.Location = new Point(16, 84);
            lblParity.Margin = new Padding(4, 0, 4, 0);
            lblParity.Name = "lblParity";
            lblParity.Size = new Size(37, 15);
            lblParity.TabIndex = 4;
            lblParity.Text = "Parity";
            // 
            // gpbSerialPortTypeSignals
            // 
            gpbSerialPortTypeSignals.Controls.Add(ckbRTS);
            gpbSerialPortTypeSignals.Controls.Add(ckbDTR);
            gpbSerialPortTypeSignals.Location = new Point(285, 111);
            gpbSerialPortTypeSignals.Margin = new Padding(4, 3, 4, 3);
            gpbSerialPortTypeSignals.Name = "gpbSerialPortTypeSignals";
            gpbSerialPortTypeSignals.Padding = new Padding(4, 3, 4, 3);
            gpbSerialPortTypeSignals.Size = new Size(270, 53);
            gpbSerialPortTypeSignals.TabIndex = 74;
            gpbSerialPortTypeSignals.TabStop = false;
            gpbSerialPortTypeSignals.Text = "Signal type";
            // 
            // ckbRTS
            // 
            ckbRTS.AutoSize = true;
            ckbRTS.Location = new Point(78, 22);
            ckbRTS.Margin = new Padding(4, 3, 4, 3);
            ckbRTS.Name = "ckbRTS";
            ckbRTS.Size = new Size(44, 19);
            ckbRTS.TabIndex = 1;
            ckbRTS.Text = "RTS";
            ckbRTS.UseVisualStyleBackColor = true;
            // 
            // ckbDTR
            // 
            ckbDTR.AutoSize = true;
            ckbDTR.Location = new Point(14, 23);
            ckbDTR.Margin = new Padding(4, 3, 4, 3);
            ckbDTR.Name = "ckbDTR";
            ckbDTR.Size = new Size(46, 19);
            ckbDTR.TabIndex = 0;
            ckbDTR.Text = "DTR";
            ckbDTR.UseVisualStyleBackColor = true;
            // 
            // gpbSerialPortHandshake
            // 
            gpbSerialPortHandshake.Controls.Add(numSerialPortReceivedBytesThreshold);
            gpbSerialPortHandshake.Controls.Add(cmbHandshake);
            gpbSerialPortHandshake.Controls.Add(lblSerialPortReceivedBytesThreshold);
            gpbSerialPortHandshake.Controls.Add(lblHandshake);
            gpbSerialPortHandshake.Location = new Point(285, 22);
            gpbSerialPortHandshake.Margin = new Padding(4, 3, 4, 3);
            gpbSerialPortHandshake.Name = "gpbSerialPortHandshake";
            gpbSerialPortHandshake.Padding = new Padding(4, 3, 4, 3);
            gpbSerialPortHandshake.Size = new Size(270, 83);
            gpbSerialPortHandshake.TabIndex = 73;
            gpbSerialPortHandshake.TabStop = false;
            gpbSerialPortHandshake.Text = "Handshake";
            // 
            // numSerialPortReceivedBytesThreshold
            // 
            numSerialPortReceivedBytesThreshold.Location = new Point(182, 52);
            numSerialPortReceivedBytesThreshold.Margin = new Padding(4, 3, 4, 3);
            numSerialPortReceivedBytesThreshold.Name = "numSerialPortReceivedBytesThreshold";
            numSerialPortReceivedBytesThreshold.Size = new Size(80, 23);
            numSerialPortReceivedBytesThreshold.TabIndex = 43;
            numSerialPortReceivedBytesThreshold.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cmbHandshake
            // 
            cmbHandshake.FormattingEnabled = true;
            cmbHandshake.Items.AddRange(new object[] { "None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff" });
            cmbHandshake.Location = new Point(90, 17);
            cmbHandshake.Margin = new Padding(4, 3, 4, 3);
            cmbHandshake.Name = "cmbHandshake";
            cmbHandshake.Size = new Size(172, 23);
            cmbHandshake.TabIndex = 10;
            // 
            // lblSerialPortReceivedBytesThreshold
            // 
            lblSerialPortReceivedBytesThreshold.AutoSize = true;
            lblSerialPortReceivedBytesThreshold.Location = new Point(16, 57);
            lblSerialPortReceivedBytesThreshold.Margin = new Padding(4, 0, 4, 0);
            lblSerialPortReceivedBytesThreshold.Name = "lblSerialPortReceivedBytesThreshold";
            lblSerialPortReceivedBytesThreshold.Size = new Size(151, 15);
            lblSerialPortReceivedBytesThreshold.TabIndex = 55;
            lblSerialPortReceivedBytesThreshold.Text = "Threshold of bytes received";
            // 
            // lblHandshake
            // 
            lblHandshake.AutoSize = true;
            lblHandshake.Location = new Point(16, 22);
            lblHandshake.Margin = new Padding(4, 0, 4, 0);
            lblHandshake.Name = "lblHandshake";
            lblHandshake.Size = new Size(31, 15);
            lblHandshake.TabIndex = 11;
            lblHandshake.Text = "Type";
            // 
            // gpbSerialPort
            // 
            gpbSerialPort.Controls.Add(gbSerialPortSettings);
            gpbSerialPort.Controls.Add(gpbSerialPortTypeSignals);
            gpbSerialPort.Controls.Add(gpbSerialPortHandshake);
            gpbSerialPort.Location = new Point(6, 166);
            gpbSerialPort.Name = "gpbSerialPort";
            gpbSerialPort.Size = new Size(566, 207);
            gpbSerialPort.TabIndex = 75;
            gpbSerialPort.TabStop = false;
            gpbSerialPort.Text = "Serial port";
            // 
            // gpbTCPUDPClient
            // 
            gpbTCPUDPClient.Controls.Add(gpbTCPUDPClientSettings);
            gpbTCPUDPClient.Location = new Point(6, 166);
            gpbTCPUDPClient.Name = "gpbTCPUDPClient";
            gpbTCPUDPClient.Size = new Size(566, 207);
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
            gpbTCPUDPClientSettings.Location = new Point(7, 22);
            gpbTCPUDPClientSettings.Margin = new Padding(4, 3, 4, 3);
            gpbTCPUDPClientSettings.Name = "gpbTCPUDPClientSettings";
            gpbTCPUDPClientSettings.Padding = new Padding(4, 3, 4, 3);
            gpbTCPUDPClientSettings.Size = new Size(270, 177);
            gpbTCPUDPClientSettings.TabIndex = 72;
            gpbTCPUDPClientSettings.TabStop = false;
            gpbTCPUDPClientSettings.Text = "Settings";
            // 
            // numPort
            // 
            numPort.Location = new Point(145, 51);
            numPort.Margin = new Padding(4, 3, 4, 3);
            numPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numPort.Name = "numPort";
            numPort.Size = new Size(117, 23);
            numPort.TabIndex = 80;
            numPort.Value = new decimal(new int[] { 502, 0, 0, 0 });
            // 
            // txtHost
            // 
            txtHost.Location = new Point(146, 19);
            txtHost.Margin = new Padding(4, 3, 4, 3);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(116, 23);
            txtHost.TabIndex = 79;
            txtHost.Text = "127.0.0.1";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(16, 53);
            lblPort.Margin = new Padding(4, 0, 4, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(29, 15);
            lblPort.TabIndex = 77;
            lblPort.Text = "Port";
            // 
            // lblHost
            // 
            lblHost.AutoSize = true;
            lblHost.Location = new Point(16, 22);
            lblHost.Margin = new Padding(4, 0, 4, 0);
            lblHost.Name = "lblHost";
            lblHost.Size = new Size(76, 15);
            lblHost.TabIndex = 78;
            lblHost.Text = "Remote Host";
            // 
            // tabChannel
            // 
            tabChannel.Controls.Add(tabChannelSettings);
            tabChannel.Controls.Add(tabChannelSettingsAdvanced);
            tabChannel.Dock = DockStyle.Fill;
            tabChannel.Location = new Point(0, 0);
            tabChannel.Name = "tabChannel";
            tabChannel.SelectedIndex = 0;
            tabChannel.Size = new Size(800, 700);
            tabChannel.TabIndex = 77;
            // 
            // tabChannelSettings
            // 
            tabChannelSettings.Controls.Add(gpbСhannel);
            tabChannelSettings.Controls.Add(btnSave);
            tabChannelSettings.Controls.Add(gpbSettingsСhannel);
            tabChannelSettings.Controls.Add(rchChannelInfo);
            tabChannelSettings.Controls.Add(gpbSerialPort);
            tabChannelSettings.Controls.Add(gpbTCPUDPClient);
            tabChannelSettings.Location = new Point(4, 24);
            tabChannelSettings.Name = "tabChannelSettings";
            tabChannelSettings.Padding = new Padding(3);
            tabChannelSettings.Size = new Size(792, 672);
            tabChannelSettings.TabIndex = 0;
            tabChannelSettings.Text = "Settings";
            tabChannelSettings.UseVisualStyleBackColor = true;
            // 
            // gpbСhannel
            // 
            gpbСhannel.Controls.Add(ckbEnabled);
            gpbСhannel.Controls.Add(lblNameGroup);
            gpbСhannel.Controls.Add(txtName);
            gpbСhannel.Location = new Point(7, 6);
            gpbСhannel.Margin = new Padding(4, 3, 4, 3);
            gpbСhannel.Name = "gpbСhannel";
            gpbСhannel.Padding = new Padding(4, 3, 4, 3);
            gpbСhannel.Size = new Size(450, 67);
            gpbСhannel.TabIndex = 64;
            gpbСhannel.TabStop = false;
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(347, 33);
            ckbEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(68, 19);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.UseVisualStyleBackColor = true;
            ckbEnabled.TextChanged += control_Changed;
            // 
            // lblNameGroup
            // 
            lblNameGroup.AutoSize = true;
            lblNameGroup.Location = new Point(10, 13);
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
            txtName.Size = new Size(331, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += control_Changed;
            // 
            // tabChannelSettingsAdvanced
            // 
            tabChannelSettingsAdvanced.Controls.Add(btnSaveOptions);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsСhannelGateway);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsChannelTime);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsChannelBufferSize);
            tabChannelSettingsAdvanced.Controls.Add(gpbSettingsСhannelNumError);
            tabChannelSettingsAdvanced.Location = new Point(4, 24);
            tabChannelSettingsAdvanced.Name = "tabChannelSettingsAdvanced";
            tabChannelSettingsAdvanced.Padding = new Padding(3);
            tabChannelSettingsAdvanced.Size = new Size(792, 672);
            tabChannelSettingsAdvanced.TabIndex = 1;
            tabChannelSettingsAdvanced.Text = "Additional options";
            tabChannelSettingsAdvanced.UseVisualStyleBackColor = true;
            // 
            // btnSaveOptions
            // 
            btnSaveOptions.Location = new Point(465, 13);
            btnSaveOptions.Margin = new Padding(4, 3, 4, 3);
            btnSaveOptions.Name = "btnSaveOptions";
            btnSaveOptions.Size = new Size(107, 27);
            btnSaveOptions.TabIndex = 71;
            btnSaveOptions.Text = "Save";
            btnSaveOptions.UseVisualStyleBackColor = true;
            btnSaveOptions.Visible = false;
            btnSaveOptions.Click += btnSaveOptions_Click;
            // 
            // uscChannel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabChannel);
            Name = "uscChannel";
            Size = new Size(800, 700);
            Load += uscChannelDevice_Load;
            ((System.ComponentModel.ISupportInitialize)numChannelReadTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteTimeout).EndInit();
            gpbSettingsСhannel.ResumeLayout(false);
            gpbSettingsСhannel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelTimeout).EndInit();
            gpbSettingsСhannelNumError.ResumeLayout(false);
            gpbSettingsСhannelNumError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelCountError).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelConnectedClientsMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelGatewayPort).EndInit();
            gpbSettingsСhannelGateway.ResumeLayout(false);
            gpbSettingsСhannelGateway.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChannelWriteBufferSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChannelReadBufferSize).EndInit();
            gpbSettingsChannelBufferSize.ResumeLayout(false);
            gpbSettingsChannelBufferSize.PerformLayout();
            gpbSettingsChannelTime.ResumeLayout(false);
            gpbSettingsChannelTime.PerformLayout();
            gbSerialPortSettings.ResumeLayout(false);
            gbSerialPortSettings.PerformLayout();
            gpbSerialPortTypeSignals.ResumeLayout(false);
            gpbSerialPortTypeSignals.PerformLayout();
            gpbSerialPortHandshake.ResumeLayout(false);
            gpbSerialPortHandshake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSerialPortReceivedBytesThreshold).EndInit();
            gpbSerialPort.ResumeLayout(false);
            gpbTCPUDPClient.ResumeLayout(false);
            gpbTCPUDPClientSettings.ResumeLayout(false);
            gpbTCPUDPClientSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
            tabChannel.ResumeLayout(false);
            tabChannelSettings.ResumeLayout(false);
            gpbСhannel.ResumeLayout(false);
            gpbСhannel.PerformLayout();
            tabChannelSettingsAdvanced.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblChannelCountError;
        private Label lblms_3;
        private NumericUpDown numChannelReadTimeout;
        private NumericUpDown numChannelWriteTimeout;
        private Label lblChannelTimeout;
        private GroupBox gpbSettingsСhannel;
        private Label lblСhannelID;
        private RichTextBox rchChannelInfo;
        private TextBox txtСhannelID;
        private Label lblType;
        private ComboBox cmbType;
        private NumericUpDown numChannelTimeout;
        private Label lblConnectedClientsMax;
        private Button btnSave;
        private GroupBox gpbSettingsСhannelNumError;
        private NumericUpDown numChannelCountError;
        private Label lblms_2;
        private NumericUpDown numChannelConnectedClientsMax;
        private Button btnChannelGatewayPortChecked;
        private Label label2;
        private NumericUpDown numChannelGatewayPort;
        private ComboBox cmbChannelGatewayTypeProtocol;
        private GroupBox gpbSettingsСhannelGateway;
        private Label label1;
        private Label lblChannelReadBufferSize;
        private Label lblChannelWriteBufferSize;
        private NumericUpDown numChannelWriteBufferSize;
        private NumericUpDown numChannelReadBufferSize;
        private GroupBox gpbSettingsChannelBufferSize;
        private GroupBox gpbSettingsChannelTime;
        private Label lblms_1;
        private Label lblChannelReadTimeout;
        private Label lblChannelWriteTimeout;
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
        private GroupBox gpbSerialPort;
        private GroupBox gpbTCPUDPClient;
        private GroupBox gpbTCPUDPClientSettings;
        private NumericUpDown numPort;
        private TextBox txtHost;
        private Label lblPort;
        private Label lblHost;
        private TabControl tabChannel;
        private TabPage tabChannelSettings;
        private TabPage tabChannelSettingsAdvanced;
        private GroupBox gpbСhannel;
        private CheckBox ckbEnabled;
        private Label lblNameGroup;
        private TextBox txtName;
        private Button btnSaveOptions;
    }
}
