using Microsoft.Win32;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmChannel : Form
    {
        public FrmChannel()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form
        public FrmConfig frmParentGloabal;              // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified
        #endregion Form

        #region Channel

        ProjectChannel currentChannel;

        #endregion Channel

        #endregion Variables

        #region Load

        public FrmChannel(ProjectNodeData ProjectNodeData)
        {
            currentChannel = ProjectNodeData.channel;

            InitializeComponent();
            FormatWindow(true);
        }

        public FrmChannel(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            currentChannel = ProjectNodeData.channel;
            boolParent = hasParent;
            InitializeComponent();
            FormatWindow(boolParent);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                btnSave.Visible = true;
                btnSaveOptions.Visible = true;
                cmbType.Enabled = true;
                gpbSettingsСhannelNumError.Visible = true;
                gpbSettingsChannelBufferSize.Visible = true;
                gpbSettingsChannelTime.Visible = true;
                gpbSettingsСhannelGateway.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
                TopLevel = false;

                ToolTip t = new ToolTip();
                t.SetToolTip(btnChannelGatewayPortChecked, DriverPhrases.ChannelGatewayPortChecked);
            }
        }

        private void FrmChannel_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();
        }

        private void ConfigToControls()
        {
            txtСhannelID.Text = currentChannel.ID.ToString();
            txtName.Text = currentChannel.Name;

            ckbEnabled.Checked = currentChannel.Enabled;
            cmbType.SelectedIndex = currentChannel.Type;

            cmbPortName.SelectedIndex = cmbPortName.FindString(currentChannel.SerialPortName);
            cmbBaudRate.SelectedIndex = cmbBaudRate.FindString(currentChannel.SerialPortBaudRate);
            cmbDataBits.SelectedIndex = cmbDataBits.FindString(currentChannel.SerialPortDataBits);
            cmbParity.SelectedIndex = cmbParity.FindString(currentChannel.SerialPortParity);
            cmbStopBits.SelectedIndex = cmbStopBits.FindString(currentChannel.SerialPortStopBits);
            cmbHandshake.SelectedIndex = cmbHandshake.FindString(currentChannel.SerialPortHandshake);
            ckbDTR.Checked = currentChannel.SerialPortDtrEnable;
            ckbRTS.Checked = currentChannel.SerialPortRtsEnable;
            numSerialPortReceivedBytesThreshold.Value = currentChannel.SerialPortReceivedBytesThreshold;

            txtHost.Text = currentChannel.ClientHost;
            numPort.Value = Convert.ToInt32(currentChannel.ClientPort);

            numChannelWriteTimeout.Value = currentChannel.WriteTimeout;
            numChannelReadTimeout.Value = currentChannel.ReadTimeout;
            numChannelTimeout.Value = currentChannel.Timeout;

            numChannelWriteBufferSize.Value = currentChannel.WriteBufferSize;
            numChannelReadBufferSize.Value = currentChannel.ReadBufferSize;

            numChannelCountError.Value = currentChannel.CountError;

            cmbChannelGatewayTypeProtocol.SelectedIndex = currentChannel.GatewayTypeProtocol;
            numChannelGatewayPort.Value = currentChannel.GatewayPort;
            //Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            numChannelConnectedClientsMax.Minimum = 0;
            numChannelConnectedClientsMax.Value = currentChannel.GatewayConnectedClientsMax;
            //А вот потом говорим, что так делать нельзя :)
            numChannelConnectedClientsMax.Minimum = 1;

            if (cmbType.SelectedIndex == 0)
            {
                rchChannelInfo.Clear();
            }

            Modified = false;
        }

        #endregion Load

        #region Save

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnSaveOptions_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ControlsToConfig();

            if (txtName.Text == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }

            frmParentGloabal.trvProject.LabelEdit = true;
            frmParentGloabal.trvProject.SelectedNode.BeginEdit();
            TreeNode stn = frmParentGloabal.trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.channel = currentChannel;
            stn.Tag = projectNodeData;
            stn.Text = currentChannel.Name;

            string imageKey = stn.ImageKey;
            int imageIndex = stn.ImageIndex;

            switch (currentChannel.Type)
            {
                case 0:
                    imageKey = ListImages.ImageKey.ChannelEmpty;
                    break;
                case 1:
                    imageKey = ListImages.ImageKey.ChannelSerialPort;
                    break;
                case 2:
                    imageKey = ListImages.ImageKey.ChannelEthernet;
                    break;
                case 3:
                    imageKey = ListImages.ImageKey.ChannelEthernet;
                    break;
                default:
                    imageKey = ListImages.ImageKey.ChannelEmpty;
                    break;
            }

            currentChannel.KeyImage = imageKey;
            stn.ImageKey = imageKey;
            stn.SelectedImageKey = imageKey;

            frmParentGloabal.trvProject.SelectedNode.EndEdit(true);
            frmParentGloabal.trvProject.LabelEdit = false;

            Modified = false;
        }

        private void ControlsToConfig()
        {
            currentChannel.ID = DriverUtils.StringToGuid(txtСhannelID.Text);
            currentChannel.Name = txtName.Text;
            currentChannel.Description = "";

            currentChannel.Enabled = ckbEnabled.Checked;
            currentChannel.Type = cmbType.SelectedIndex;

            currentChannel.WriteTimeout = Convert.ToInt32(numChannelWriteTimeout.Value);
            currentChannel.ReadTimeout = Convert.ToInt32(numChannelReadTimeout.Value);
            currentChannel.Timeout = Convert.ToInt32(numChannelTimeout.Value);

            currentChannel.WriteBufferSize = Convert.ToInt32(numChannelWriteBufferSize.Value);
            currentChannel.ReadBufferSize = Convert.ToInt32(numChannelReadBufferSize.Value);

            currentChannel.CountError = Convert.ToInt32(numChannelCountError.Value);

            currentChannel.GatewayTypeProtocol = cmbChannelGatewayTypeProtocol.SelectedIndex;
            currentChannel.GatewayPort = Convert.ToInt32(numChannelGatewayPort.Value);
            currentChannel.GatewayConnectedClientsMax = Convert.ToInt32(numChannelConnectedClientsMax.Value);

            currentChannel.SerialPortName = cmbPortName.Text;
            currentChannel.SerialPortBaudRate = cmbBaudRate.Text;
            currentChannel.SerialPortDataBits = cmbDataBits.Text;
            currentChannel.SerialPortParity = cmbParity.Text;
            currentChannel.SerialPortStopBits = cmbStopBits.Text;
            currentChannel.SerialPortHandshake = cmbHandshake.Text;
            currentChannel.SerialPortDtrEnable = ckbDTR.Checked;
            currentChannel.SerialPortRtsEnable = ckbRTS.Checked;
            currentChannel.SerialPortReceivedBytesThreshold = Convert.ToInt32(numSerialPortReceivedBytesThreshold.Value);

            currentChannel.ClientHost = txtHost.Text;
            currentChannel.ClientPort = Convert.ToInt32(numPort.Value);


        }

        #endregion Save

        #region Component

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cur = cmbType.SelectedIndex;
            if (cmbType.SelectedIndex == 0)
            {
                rchChannelInfo.Visible = true;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = false;
            }
            else if (cmbType.SelectedIndex == 1)
            {
                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = true;
                gpbTCPUDPClient.Visible = false;

                cmbPortName.SelectedIndex = cmbPortName.FindString(currentChannel.SerialPortName);
                cmbBaudRate.SelectedIndex = cmbBaudRate.FindString(currentChannel.SerialPortBaudRate);
                cmbDataBits.SelectedIndex = cmbDataBits.FindString(currentChannel.SerialPortDataBits);
                cmbParity.SelectedIndex = cmbParity.FindString(currentChannel.SerialPortParity);
                cmbStopBits.SelectedIndex = cmbStopBits.FindString(currentChannel.SerialPortStopBits);
                cmbHandshake.SelectedIndex = cmbHandshake.FindString(currentChannel.SerialPortHandshake);
                ckbDTR.Checked = currentChannel.SerialPortDtrEnable;
                ckbRTS.Checked = currentChannel.SerialPortRtsEnable;
                numSerialPortReceivedBytesThreshold.Value = currentChannel.SerialPortReceivedBytesThreshold;

                SerialPortParametrsRefresh();
            }
            else if (cmbType.SelectedIndex == 2)
            {
                gpbTCPUDPClient.Text = DriverDictonary.ClientTCP;

                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = true;

                txtHost.Text = currentChannel.ClientHost;
                numPort.Value = currentChannel.ClientPort;
            }
            else if (cmbType.SelectedIndex == 3)
            {
                gpbTCPUDPClient.Text = DriverDictonary.ClientUDP;

                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = true;

                txtHost.Text = currentChannel.ClientHost;
                numPort.Value = currentChannel.ClientPort;
            }

            Modified = true;
        }

        private void SerialPortParametrsRefresh()
        {
            try
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(GetPortNames());

                if (cmbPortName.Items.Count == 1)
                {
                    cmbPortName.SelectedIndex = 0;
                }
                else if (cmbPortName.Items.Count > 1)
                {
                    cmbPortName.SelectedIndex = cmbPortName.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show(this, DriverPhrases.NoComPort, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }

            try
            {
                cmbBaudRate.SelectedIndex = cmbBaudRate.FindString("9600");
                cmbParity.SelectedIndex = cmbParity.FindString("None");
                cmbDataBits.SelectedIndex = cmbDataBits.FindString("8");
                cmbStopBits.SelectedIndex = cmbStopBits.FindString("One");
                cmbHandshake.SelectedIndex = cmbHandshake.FindString("None");
                ckbDTR.Checked = currentChannel.SerialPortDtrEnable;
                ckbRTS.Checked = currentChannel.SerialPortRtsEnable;
                numSerialPortReceivedBytesThreshold.Value = 1;
            }
            catch { }
        }

        public static string[] GetPortNames()
        {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DEVICEMAP\\SERIALCOMM"))
            {
                if (registryKey != null)
                {
                    string[] valueNames = registryKey.GetValueNames();
                    for (int i = 0; i < valueNames.Length; i++)
                    {
                        valueNames[i] = (string)registryKey.GetValue(valueNames[i]);
                    }
                    return valueNames;
                }
            }
            return Array.Empty<string>();
        }

        #endregion Component

        #region Form
        /// <summary>
        /// Gets or sets a value indicating whether the configuration was modified.
        /// </summary>
        private bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                btnSave.Enabled = modified;
                btnSaveOptions.Enabled = modified;
            }
        }

        /// <summary>
        /// Indication of a component change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_Changed(object sender, EventArgs e)
        {
            Modified = true;
        }
        #endregion Form

        private void btnChannelGatewayPortChecked_Click(object sender, EventArgs e)
        {
            bool checked_port = CommunicationMethods.TcpServerPortGenerator.CheckAvailableServerPort(Convert.ToInt32(numChannelGatewayPort.Value));
            if (checked_port == true)
            {
                MessageBox.Show(DriverPhrases.PortFree, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(DriverPhrases.PortBusy, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
