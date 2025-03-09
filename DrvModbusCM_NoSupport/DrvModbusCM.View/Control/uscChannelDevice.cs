using Microsoft.Win32;
using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscChannelDevice : UserControl
    {
        public uscChannelDevice()
        {
            InitializeComponent();
        }

        #region Variables

        #region Channel
        private ProjectNodeData mtNodeData;
        public ProjectNodeData MTNodeData
        {
            get { return mtNodeData; }
            set { mtNodeData = value; }
        }

        //ID канала
        private Guid channelID;
        public Guid ChannelID
        {
            get { return channelID; }
            set { channelID = value; }
        }

        //Название канала
        private string channelName;
        public string ChannelName
        {
            get { return channelName; }
            set { channelName = value; }
        }

        //Описание канала
        private string channelDescription;
        public string ChannelDescription
        {
            get { return channelDescription; }
            set { channelDescription = value; }
        }

        //Иконка
        private string channelKeyImage;
        public string ChannelKeyImage
        {
            get { return channelKeyImage; }
            set { channelKeyImage = value; }
        }

        //Состаяние канала
        private bool channelEnabled;
        public bool ChannelEnabled
        {
            get { return channelEnabled; }
            set { channelEnabled = value; }
        }

        //Тип канала
        private int channelType;
        public int ChannelType
        {
            get { return channelType; }
            set { channelType = value; }
        }

        //Для запуска канала в потоке
        private bool channelThreadEnabled;
        public bool ChannelThreadEnabled
        {
            get { return channelThreadEnabled; }
            set { channelThreadEnabled = value; }
        }

        //Время записи
        private int writeTimeout;
        public int WriteTimeout
        {
            get { return writeTimeout; }
            set { writeTimeout = value; }
        }

        //Время чтения
        private int readTimeout;
        public int ReadTimeout
        {
            get { return readTimeout; }
            set { readTimeout = value; }
        }

        //Буфер запись
        private int writeBufferSize;
        public int WriteBufferSize
        {
            get { return writeBufferSize; }
            set { writeBufferSize = value; }
        }

        //Буфер чтения
        private int readBufferSize;
        public int ReadBufferSize
        {
            get { return readBufferSize; }
            set { readBufferSize = value; }
        }

        //Таймаут между пакетами
        private int timeout;
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        //Количество ошибок
        private int countError;
        public int CountError
        {
            get { return countError; }
            set { countError = value; }
        }
        #endregion Channel

        #region Gateway

        //Протокол
        private int gatewayTypeProtocol;
        public int GatewayTypeProtocol
        {
            get { return gatewayTypeProtocol; }
            set { gatewayTypeProtocol = value; }
        }

        //Порт 
        private int gatewayPort;
        public int GatewayPort
        {
            get { return gatewayPort; }
            set { gatewayPort = value; }
        }

        //Максимальное количество клиентов
        private int gatewayConnectedClientsMax;
        public int GatewayConnectedClientsMax
        {
            get { return gatewayConnectedClientsMax; }
            set { gatewayConnectedClientsMax = value; }
        }
        #endregion Gateway

        #region SerialPort
        private string serialPortName;
        public string SerialPortName
        {
            get { return serialPortName; }
            set { serialPortName = value; }
        }

        private string serialPortBaudRate;
        public string SerialPortBaudRate
        {
            get { return serialPortBaudRate; }
            set { serialPortBaudRate = value; }
        }

        private string serialPortDataBits;
        public string SerialPortDataBits
        {
            get { return serialPortDataBits; }
            set { serialPortDataBits = value; }
        }

        private string serialPortParity;
        public string SerialPortParity
        {
            get { return serialPortParity; }
            set { serialPortParity = value; }
        }

        private string serialPortStopBits;
        public string SerialPortStopBits
        {
            get { return serialPortStopBits; }
            set { serialPortStopBits = value; }
        }

        private string serialPortHandshake;
        public string SerialPortHandshake
        {
            get { return serialPortHandshake; }
            set { serialPortHandshake = value; }
        }

        private bool serialPortDtrEnable;
        public bool SerialPortDtrEnable
        {
            get { return serialPortDtrEnable; }
            set { serialPortDtrEnable = value; }
        }

        private bool serialPortRtsEnable;
        public bool SerialPortRtsEnable
        {
            get { return serialPortRtsEnable; }
            set { serialPortRtsEnable = value; }
        }

        private int serialPortReceivedBytesThreshold;
        public int SerialPortReceivedBytesThreshold
        {
            get { return serialPortReceivedBytesThreshold; }
            set { serialPortReceivedBytesThreshold = value; }
        }

        #endregion SerialPort

        #region TCP, UDP client

        private string clientHost;
        public string ClientHost
        {
            get { return clientHost; }
            set { clientHost = value; }
        }

        private int clientPort;
        public int ClientPort
        {
            get { return clientPort; }
            set { clientPort = value; }
        }

        #endregion TCP, UDP client

        #endregion Variables

        #region Load

        public uscChannelDevice(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;
            ChannelID = ProjectNodeData.channel.ChannelID;

            ChannelName = ProjectNodeData.channel.ChannelName;
            ChannelDescription = ProjectNodeData.channel.ChannelDescription;
            ChannelKeyImage = ProjectNodeData.channel.ChannelKeyImage;
            ChannelEnabled = ProjectNodeData.channel.ChannelEnabled;
            ChannelThreadEnabled = ProjectNodeData.channel.ChannelThreadEnabled;
            ChannelType = ProjectNodeData.channel.ChannelType;

            WriteTimeout = ProjectNodeData.channel.WriteTimeout;
            ReadTimeout = ProjectNodeData.channel.ReadTimeout;
            Timeout = ProjectNodeData.channel.Timeout;

            WriteBufferSize = ProjectNodeData.channel.WriteBufferSize;
            ReadBufferSize = ProjectNodeData.channel.ReadBufferSize;

            CountError = ProjectNodeData.channel.CountError;
            SerialPortName = ProjectNodeData.channel.SerialPortName;
            SerialPortBaudRate = ProjectNodeData.channel.SerialPortBaudRate;
            SerialPortDataBits = ProjectNodeData.channel.SerialPortDataBits;
            SerialPortParity = ProjectNodeData.channel.SerialPortParity;
            SerialPortStopBits = ProjectNodeData.channel.SerialPortStopBits;

            SerialPortHandshake = ProjectNodeData.channel.SerialPortHandshake;
            SerialPortDtrEnable = ProjectNodeData.channel.SerialPortDtrEnable;
            SerialPortRtsEnable = ProjectNodeData.channel.SerialPortRtsEnable;
            SerialPortReceivedBytesThreshold = ProjectNodeData.channel.SerialPortReceivedBytesThreshold;

            GatewayTypeProtocol = ProjectNodeData.channel.GatewayTypeProtocol;
            GatewayPort = ProjectNodeData.channel.GatewayPort;
            GatewayConnectedClientsMax = ProjectNodeData.channel.GatewayConnectedClientsMax;

            ClientHost = ProjectNodeData.channel.ClientHost;
            ClientPort = ProjectNodeData.channel.ClientPort;

            InitializeComponent();
            FormatWindow(true);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.BorderStyle = BorderStyle.None;
                btnChannelSave.Visible = true;
                cmbChannelType.Enabled = true;
                gpbSettingsСhannelNumError.Visible = true;
                gpbSettingsChannelBufferSize.Visible = true;
                gpbSettingsChannelTime.Visible = true;
                gpbSettingsСhannelGateway.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;

                ToolTip t = new ToolTip();
                t.SetToolTip(btnChannelGatewayPortChecked, "Проверка свободности выбранного порта.");
            }
        }

        private void uscChannelDevice_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();
        }

        private void ConfigToControls()
        {
            txtСhannelID.Text = ChannelID.ToString();
            txtСhannelName.Text = ChannelName;

            ckbСhannelEnabled.Checked = ChannelEnabled;
            cmbChannelType.SelectedIndex = ChannelType;

            cmbPortName.SelectedIndex = cmbPortName.FindString(SerialPortName);
            cmbBaudRate.SelectedIndex = cmbBaudRate.FindString(SerialPortBaudRate);
            cmbDataBits.SelectedIndex = cmbDataBits.FindString(SerialPortDataBits);
            cmbParity.SelectedIndex = cmbParity.FindString(SerialPortParity);
            cmbStopBits.SelectedIndex = cmbStopBits.FindString(SerialPortStopBits);
            cmbHandshake.SelectedIndex = cmbHandshake.FindString(SerialPortHandshake);
            ckbDTR.Checked = SerialPortDtrEnable;
            ckbRTS.Checked = SerialPortRtsEnable;
            numSerialPortReceivedBytesThreshold.Value = SerialPortReceivedBytesThreshold;

            txtHost.Text = ClientHost;
            numPort.Value = Convert.ToInt32(ClientPort);

            numChannelWriteTimeout.Value = WriteTimeout;
            numChannelReadTimeout.Value = ReadTimeout;
            numChannelTimeout.Value = Timeout;

            numChannelWriteBufferSize.Value = WriteBufferSize;
            numChannelReadBufferSize.Value = ReadBufferSize;

            numChannelCountError.Value = CountError;

            cmbChannelGatewayTypeProtocol.SelectedIndex = GatewayTypeProtocol;
            numChannelGatewayPort.Value = GatewayPort;
            //Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            numChannelConnectedClientsMax.Minimum = 0;
            numChannelConnectedClientsMax.Value = GatewayConnectedClientsMax;
            //А вот потом говорим, что так делать нельзя :)
            numChannelConnectedClientsMax.Minimum = 1;

            if (cmbChannelType.SelectedIndex == 0)
            {
                rchChannelInfo.Clear();
            }
        }

        #endregion Load

        #region Save

        private void btnChannelSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ControlsToConfig();

            if (channelName == "")
            {
                MessageBox.Show("Поле Наименование не может быть пустым");
                return;
            }

            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.channel.ChannelID = ChannelID;
            //projectNodeData.channel.HardwareGroupModbusID = HardwareGroupModbusID;
            projectNodeData.channel.ChannelName = ChannelName;
            projectNodeData.channel.ChannelDescription = ChannelDescription;
            projectNodeData.channel.ChannelEnabled = ChannelEnabled;
            projectNodeData.channel.ChannelThreadEnabled = ChannelThreadEnabled;
            projectNodeData.channel.ChannelType = ChannelType;
            /////
            projectNodeData.channel.SerialPortName = SerialPortName;
            projectNodeData.channel.SerialPortBaudRate = SerialPortBaudRate;
            projectNodeData.channel.SerialPortDataBits = SerialPortDataBits;
            projectNodeData.channel.SerialPortParity = SerialPortParity;
            projectNodeData.channel.SerialPortStopBits = SerialPortStopBits;

            projectNodeData.channel.SerialPortHandshake = SerialPortHandshake;
            projectNodeData.channel.SerialPortDtrEnable = SerialPortDtrEnable;
            projectNodeData.channel.SerialPortRtsEnable = SerialPortRtsEnable;
            projectNodeData.channel.SerialPortReceivedBytesThreshold = SerialPortReceivedBytesThreshold;
            /////
            projectNodeData.channel.ClientHost = ClientHost;
            projectNodeData.channel.ClientPort = ClientPort;
            /////
            projectNodeData.channel.WriteTimeout = WriteTimeout;
            projectNodeData.channel.ReadTimeout = ReadTimeout;
            projectNodeData.channel.Timeout = Timeout;

            projectNodeData.channel.WriteBufferSize = WriteBufferSize;
            projectNodeData.channel.ReadBufferSize = ReadBufferSize;

            projectNodeData.channel.CountError = CountError;

            projectNodeData.channel.GatewayTypeProtocol = GatewayTypeProtocol;
            projectNodeData.channel.GatewayPort = GatewayPort;
            projectNodeData.channel.GatewayConnectedClientsMax = GatewayConnectedClientsMax;

            projectNodeData.channel.ChannelKeyImage = stn.ImageKey = stn.SelectedImageKey = ProjectChannelDevice.KeyImageName(ChannelType);

            stn.Text = ChannelName;
            stn.Tag = projectNodeData;
        }

        private void ControlsToConfig()
        {
            ChannelID = DriverUtils.StringToGuid(txtСhannelID.Text);
            ChannelName = txtСhannelName.Text;
            ChannelDescription = "";

            ChannelEnabled = ckbСhannelEnabled.Checked;
            ChannelType = cmbChannelType.SelectedIndex;

            WriteTimeout = Convert.ToInt32(numChannelWriteTimeout.Value);
            ReadTimeout = Convert.ToInt32(numChannelReadTimeout.Value);
            Timeout = Convert.ToInt32(numChannelTimeout.Value);

            WriteBufferSize = Convert.ToInt32(numChannelWriteBufferSize.Value);
            ReadBufferSize = Convert.ToInt32(numChannelReadBufferSize.Value);

            CountError = Convert.ToInt32(numChannelCountError.Value);

            GatewayTypeProtocol = cmbChannelGatewayTypeProtocol.SelectedIndex;
            GatewayPort = Convert.ToInt32(numChannelGatewayPort.Value);
            GatewayConnectedClientsMax = Convert.ToInt32(numChannelConnectedClientsMax.Value);

            SerialPortName = cmbPortName.Text;
            SerialPortBaudRate = cmbBaudRate.Text;
            SerialPortDataBits = cmbDataBits.Text;
            SerialPortParity = cmbParity.Text;
            SerialPortStopBits = cmbStopBits.Text;
            SerialPortHandshake = cmbHandshake.Text;
            SerialPortDtrEnable = ckbDTR.Checked;
            SerialPortRtsEnable = ckbRTS.Checked;
            SerialPortReceivedBytesThreshold = Convert.ToInt32(numSerialPortReceivedBytesThreshold.Value);

            ClientHost = txtHost.Text;
            ClientPort = Convert.ToInt32(numPort.Value);
        }

        #endregion Save

        #region Component

        private void cmbChannelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cur = cmbChannelType.SelectedIndex;
            if (cmbChannelType.SelectedIndex == 0)
            {
                rchChannelInfo.Visible = true;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = false;
            }
            else if (cmbChannelType.SelectedIndex == 1)
            {
                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = true;
                gpbTCPUDPClient.Visible = false;

                cmbPortName.SelectedIndex = cmbPortName.FindString(SerialPortName);
                cmbBaudRate.SelectedIndex = cmbBaudRate.FindString(SerialPortBaudRate);
                cmbDataBits.SelectedIndex = cmbDataBits.FindString(SerialPortDataBits);
                cmbParity.SelectedIndex = cmbParity.FindString(SerialPortParity);
                cmbStopBits.SelectedIndex = cmbStopBits.FindString(SerialPortStopBits);
                cmbHandshake.SelectedIndex = cmbHandshake.FindString(SerialPortHandshake);
                ckbDTR.Checked = SerialPortDtrEnable;
                ckbRTS.Checked = SerialPortRtsEnable;
                numSerialPortReceivedBytesThreshold.Value = SerialPortReceivedBytesThreshold;

                SerialPortParametrsRefresh();
            }
            else if (cmbChannelType.SelectedIndex == 2)
            {
                gpbTCPUDPClient.Text = "TCP клиент";

                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = true;

                txtHost.Text = ClientHost;
                numPort.Value = ClientPort;
            }
            else if (cmbChannelType.SelectedIndex == 3)
            {
                gpbTCPUDPClient.Text = "UDP клиент";

                rchChannelInfo.Visible = false;
                gpbSerialPort.Visible = false;
                gpbTCPUDPClient.Visible = true;

                txtHost.Text = ClientHost;
                numPort.Value = ClientPort;
            }
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
                    MessageBox.Show(this, "На данном компьютере COM-порты не обнаружены.\nПожалуйста, установите COM-порт и перезапустите это приложение", "COM-порты не обнаружены", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ckbDTR.Checked = SerialPortDtrEnable;
                ckbRTS.Checked = SerialPortRtsEnable;
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

    }
}
