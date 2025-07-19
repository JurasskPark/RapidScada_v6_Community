using DrvModbusCM.Shared.Communication;
using FastColoredTextBoxNS;
using Microsoft.Win32;
using System;
using System.Data;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmChannel : Form
    {
        public FrmChannel()
        {
            InitializeComponent();
            InitializeTypeClient();
        }

        public FrmChannel(ProjectNodeData ProjectNodeData)
        {
            currentChannel = ProjectNodeData.Channel;

            InitializeComponent();
            InitializeTypeClient();
            FormatWindow(true);
        }

        public FrmChannel(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            currentChannel = ProjectNodeData.Channel;
            boolParent = hasParent;
            InitializeComponent();
            InitializeTypeClient();
            FormatWindow(boolParent);
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

        

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                btnSave.Visible = true;
                btnSaveOptions.Visible = true;
                cmbTypeClient.Enabled = true;
                gpbSettingsСhannelNumError.Visible = true;
                gpbSettingsChannelBufferSize.Visible = true;
                gpbSettingsChannelTime.Visible = true;
                gpbSettingsСhannelGateway.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
                TopLevel = false;

                System.Windows.Forms.ToolTip t = new System.Windows.Forms.ToolTip();
                t.SetToolTip(btnChannelGatewayPortChecked, DriverPhrases.ChannelGatewayPortChecked);
            }
        }

        private void FrmChannel_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();
        }

        private void InitializeTypeClient()
        {
            // Получение отсортированного списка строк
            List<string> sortedStrings = Enum.GetValues(typeof(CommunicationClient))
                .Cast<CommunicationClient>()
                .OrderBy(x => (int)(object)x)
                .Select(x => x.ToString())
                .ToList();

            cmbTypeClient.Items.Clear();
            cmbTypeClient.Items.AddRange(sortedStrings.ToArray());
        }


        private void ConfigToControls()
        {
            txtСhannelID.Text = currentChannel.ID.ToString();
            txtName.Text = currentChannel.Name;

            ckbEnabled.Checked = currentChannel.Enabled;

            #region Combobox
            //DataTable dataTableChannels = new DataTable();
            //dataTableChannels.TableName = "Data";
            //dataTableChannels.Columns.Add("Id", typeof(int));
            //dataTableChannels.Columns.Add("Name", typeof(string));

            //foreach (string name in Enum.GetNames(typeof(CommunicationClient)))
            //{
            //    dataTableChannels.Rows.Add((int)(CommunicationClient)Enum.Parse(typeof(CommunicationClient), name), DriverUtils.GetEnumDescription((CommunicationClient)Enum.Parse(typeof(CommunicationClient), name)));
            //}

            //cmbTypeClient.DataSource = dataTableChannels;
            //cmbTypeClient.ValueMember = "Id";
            //cmbTypeClient.DisplayMember = "Name";
            //cmbTypeClient.SelectedIndex = 0;

            //foreach (string name in Enum.GetNames(typeof(CommunicationClient)))
            //    Console.WriteLine(name);

            //cmbTypeClient.SelectedIndex = cmbTypeClient.FindString(Enum.GetName(typeof(CommunicationClient), currentChannel.TypeClient));

            #endregion Combobox

            cmbTypeClient.SelectedIndex = (int)currentChannel.TypeClient;


            cmbPortName.SelectedIndex = cmbPortName.FindString(currentChannel.SerialPortSettings.SerialPortName);
            cmbBaudRate.SelectedIndex = cmbBaudRate.FindString(currentChannel.SerialPortSettings.SerialPortBaudRate.ToString());
            cmbDataBits.SelectedIndex = cmbDataBits.FindString(currentChannel.SerialPortSettings.SerialPortDataBits.ToString());
            cmbParity.SelectedIndex = cmbParity.FindString(Enum.GetName(typeof(Parity), currentChannel.SerialPortSettings.SerialPortParity));
            cmbStopBits.SelectedIndex = cmbStopBits.FindString(Enum.GetName(typeof(StopBits), currentChannel.SerialPortSettings.SerialPortStopBits));
            cmbHandshake.SelectedIndex = cmbHandshake.FindString(Enum.GetName(typeof(Handshake), currentChannel.SerialPortSettings.SerialPortHandshake));
            ckbDTR.Checked = currentChannel.SerialPortSettings.SerialPortDtrEnable;
            ckbRTS.Checked = currentChannel.SerialPortSettings.SerialPortRtsEnable;
            numSerialPortReceivedBytesThreshold.Value = currentChannel.SerialPortSettings.SerialPortReceivedBytesThreshold;

            txtHost.Text = currentChannel.EthernetClientSettings.ClientHost.ToString();
            numPort.Value = Convert.ToDecimal(currentChannel.EthernetClientSettings.ClientPort);

            numChannelWriteTimeout.Value = currentChannel.WriteTimeout;
            numChannelReadTimeout.Value = currentChannel.ReadTimeout;
            numChannelTimeout.Value = currentChannel.Timeout;

            numChannelWriteBufferSize.Value = currentChannel.WriteBufferSize;
            numChannelReadBufferSize.Value = currentChannel.ReadBufferSize;

            numChannelCountError.Value = currentChannel.CountError;

            //cmbChannelGatewayTypeProtocol.SelectedIndex = currentChannel.GatewayTypeProtocol;
            //numChannelGatewayPort.Value = currentChannel.GatewayPort;
            ////Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            //numChannelConnectedClientsMax.Minimum = 0;
            //numChannelConnectedClientsMax.Value = currentChannel.GatewayConnectedClientsMax;
            ////А вот потом говорим, что так делать нельзя :)
            //numChannelConnectedClientsMax.Minimum = 1;

            if (cmbTypeClient.SelectedIndex == 0)
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
            projectNodeData.Channel = currentChannel;
            stn.Tag = projectNodeData;
            stn.Text = currentChannel.Name;

            string imageKey = stn.ImageKey;
            int imageIndex = stn.ImageIndex;

            switch (currentChannel.TypeClient)
            {
                case CommunicationClient.None:
                    imageKey = ListImages.ImageKey.ChannelEmpty;
                    break;
                case CommunicationClient.SerialPort:
                    imageKey = ListImages.ImageKey.ChannelSerialPort;
                    break;
                case CommunicationClient.TcpClient:
                    imageKey = ListImages.ImageKey.ChannelEthernet;
                    break;
                case CommunicationClient.UdpClient:
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
            currentChannel.TypeClient = (CommunicationClient)cmbTypeClient.SelectedIndex;

            currentChannel.WriteTimeout = Convert.ToInt32(numChannelWriteTimeout.Value);
            currentChannel.ReadTimeout = Convert.ToInt32(numChannelReadTimeout.Value);
            currentChannel.Timeout = Convert.ToInt32(numChannelTimeout.Value);

            currentChannel.WriteBufferSize = Convert.ToInt32(numChannelWriteBufferSize.Value);
            currentChannel.ReadBufferSize = Convert.ToInt32(numChannelReadBufferSize.Value);

            currentChannel.CountError = Convert.ToInt32(numChannelCountError.Value);

            //currentChannel.GatewayTypeProtocol = cmbChannelGatewayTypeProtocol.SelectedIndex;
            //currentChannel.GatewayPort = Convert.ToInt32(numChannelGatewayPort.Value);
            //currentChannel.GatewayConnectedClientsMax = Convert.ToInt32(numChannelConnectedClientsMax.Value);

            currentChannel.SerialPortSettings.SerialPortName = cmbPortName.Text;
            currentChannel.SerialPortSettings.SerialPortBaudRate = Convert.ToInt32(cmbBaudRate.Text);
            currentChannel.SerialPortSettings.SerialPortDataBits = Convert.ToInt32(cmbDataBits.Text);
            currentChannel.SerialPortSettings.SerialPortParity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
            currentChannel.SerialPortSettings.SerialPortStopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
            currentChannel.SerialPortSettings.SerialPortHandshake = (Handshake)Enum.Parse(typeof(Handshake), cmbHandshake.Text); 
            currentChannel.SerialPortSettings.SerialPortDtrEnable = ckbDTR.Checked;
            currentChannel.SerialPortSettings.SerialPortRtsEnable = ckbRTS.Checked;
            currentChannel.SerialPortSettings.SerialPortReceivedBytesThreshold = Convert.ToInt32(numSerialPortReceivedBytesThreshold.Value);

            currentChannel.EthernetClientSettings.ClientHost = IPAddress.Parse(txtHost.Text.Trim());
            currentChannel.EthernetClientSettings.ClientPort = Convert.ToInt32(numPort.Value);


        }

        #endregion Save

        #region Component

        private void cmbTypeClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataRowView dataRowView = (DataRowView)cmbTypeClient.SelectedItem;
                if (dataRowView != null)
                {
                    currentChannel.TypeClient = (CommunicationClient)dataRowView.Row.ItemArray[0];
                    //nameServer = Convert.ToString(dataRowView.Row.ItemArray[1]).Trim();
                }
            }
            catch { }


            if (cmbTypeClient.SelectedIndex == 0)
            {
                rchChannelInfo.Visible = true;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = false;
            }
            else if (cmbTypeClient.SelectedIndex == 1)
            {
                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = true;
                gpbTCPUDPClient.Visible = false;

                //cmbPortName.SelectedIndex = cmbPortName.FindString(currentChannel.SerialPortName);
                //cmbBaudRate.SelectedIndex = cmbBaudRate.FindString(currentChannel.SerialPortBaudRate);
                //cmbDataBits.SelectedIndex = cmbDataBits.FindString(currentChannel.SerialPortDataBits);
                //cmbParity.SelectedIndex = cmbParity.FindString(currentChannel.SerialPortParity);
                //cmbStopBits.SelectedIndex = cmbStopBits.FindString(currentChannel.SerialPortStopBits);
                //cmbHandshake.SelectedIndex = cmbHandshake.FindString(currentChannel.SerialPortHandshake);
                //ckbDTR.Checked = currentChannel.SerialPortDtrEnable;
                //ckbRTS.Checked = currentChannel.SerialPortRtsEnable;
                //numSerialPortReceivedBytesThreshold.Value = currentChannel.SerialPortReceivedBytesThreshold;

                SerialPortParametrsRefresh();
            }
            else if (cmbTypeClient.SelectedIndex == 2)
            {
                gpbTCPUDPClient.Text = DriverDictonary.ClientTCP;

                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = true;

                //txtHost.Text = currentChannel.ClientHost;
                //numPort.Value = currentChannel.ClientPort;
            }
            else if (cmbTypeClient.SelectedIndex == 3)
            {
                gpbTCPUDPClient.Text = DriverDictonary.ClientUDP;

                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = true;

                //txtHost.Text = currentChannel.ClientHost;
                //numPort.Value = currentChannel.ClientPort;
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
                //cmbBaudRate.SelectedIndex = cmbBaudRate.FindString("9600");
                //cmbParity.SelectedIndex = cmbParity.FindString("None");
                //cmbDataBits.SelectedIndex = cmbDataBits.FindString("8");
                //cmbStopBits.SelectedIndex = cmbStopBits.FindString("One");
                //cmbHandshake.SelectedIndex = cmbHandshake.FindString("None");
                //ckbDTR.Checked = currentChannel.SerialPortDtrEnable;
                //ckbRTS.Checked = currentChannel.SerialPortRtsEnable;
                //numSerialPortReceivedBytesThreshold.Value = 1;
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
