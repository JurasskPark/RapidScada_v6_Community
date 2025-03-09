using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class FrmConfigForm : Form
    {

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmConfigForm(AppDirs appDirs, int deviceNum)
            : this()
        {
            try
            {
                this.AppDirs = appDirs ?? throw new ArgumentNullException(nameof(appDirs));
                this.ConfigDir = appDirs.ConfigDir;
                this.DeviceNum = deviceNum;
                this.DriverCode = DriverUtils.DriverCode;
                this.Text = DriverUtils.GetFileName(deviceNum);

                LoadData();

            }
            catch { }
        }

        #region Project

        /// <summary>
        /// Project Node Data
        /// </summary>
        ProjectNodeData mtNodeData = new ProjectNodeData();

        /// <summary>
        /// Project
        /// </summary>
        private Project project = new Project();

        /// <summary>
        /// The application directories
        /// </summary>
        private AppDirs appDirs;
        public AppDirs AppDirs
        {
            get { return appDirs; }
            set { appDirs = value; }
        }

        /// <summary>
        /// The directory with configuration files
        /// </summary>
        private string configDir;
        public string ConfigDir
        {
            get { return configDir; }
            set { configDir = value; }
        }

        /// <summary>
        /// The driver code
        /// </summary>
        private string driverCode;
        public string DriverCode
        {
            get { return driverCode; }
            set { driverCode = value; }
        }

        /// <summary>
        /// The device number
        /// </summary>
        private int deviceNum;
        public int DeviceNum
        {
            get { return deviceNum; }
            set { deviceNum = value; }
        }

        private string projectPath;
        public string ProjectPath
        {
            get { return projectPath; }
            set { projectPath = value; }
        }

        private string projectFileName;
        public string ProjectFileName
        {
            get { return projectFileName; }
            set { projectFileName = value; }
        }

        private string projectFileNameFull;
        public string ProjectFileNameFull
        {
            get { return projectFileNameFull; }
            set { projectFileNameFull = value; }
        }

        #endregion Project

        #region Project Xml
        private const string XmlNodeTag = "NODE";
        private const string XmlNodeTextAtt = "TEXT";
        private const string XmlNodeTagAtt = "TAG";
        private const string XmlNodeImageIndexAtt = "IMAGEKEY";
        #endregion Project Xml

        #region Displayed window
        private UserControl uscPropertyControl = new UserControl();
        #endregion Displayed window

        #region Load Programm
        private void FrmConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            ProjectDefaultNew(DialogResult.No);
            ProjectFileNameFull = Path.Combine(ConfigDir, DriverUtils.GetFileName(DeviceNum));
            LoadProgramm(ProjectFileNameFull);

            if (trvProject.Nodes.Count == 0)
            {
                ProjectDefaultNew(DialogResult.No);
            }
        }


        public void LoadProgramm(string fileName)
        {
            ProjectLoad(fileName);
        }

        #endregion Load Programm

        #region ToolStrip Menu
        private void tlsProjectNew_Click(object sender, EventArgs e)
        {
            ProjectDefaultNew(DialogResult.Yes);
        }

        private void tlsProjectOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileproject = new OpenFileDialog();
            openfileproject.Filter = "XML files (*.xml)|*.xml";
            if (openfileproject.ShowDialog() == DialogResult.OK)
            {
                ProjectFileNameFull = openfileproject.FileName;
                ProjectLoad(ProjectFileNameFull);
            }
        }

        private void tlsProjectSave_Click(object sender, EventArgs e)
        {
            ProjectSave();
        }

        #endregion ToolStrip Menu

        #region Context Menu
        private void cmnuDeviceAdd_Click(object sender, EventArgs e)
        {
            ProjectDeviceAdd();
        }

        private void cmnuDeviceDel_Click(object sender, EventArgs e)
        {
            ProjectDeviceDelete();
        }

        private void cmnuDeviceCommandAdd_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Tag.ToString())
            {
                case "READCOILS":
                    {
                        ProjectDeviceCommandAdd(1);
                        break;
                    }
                case "READINPUTS":
                    {
                        ProjectDeviceCommandAdd(2);
                        break;
                    }
                case "READHOLDINGREGISTERS":
                    {
                        ProjectDeviceCommandAdd(3);
                        break;
                    }
                case "READINPUTREGISTERS":
                    {
                        ProjectDeviceCommandAdd(4);
                        break;
                    }
                case "WRITECOIL":
                    {
                        ProjectDeviceCommandAdd(5);
                        break;
                    }
                case "WRITEHOLDINGREGISTER":
                    {
                        ProjectDeviceCommandAdd(6);
                        break;
                    }
                case "WRITEMULTIPLECOILS":
                    {
                        ProjectDeviceCommandAdd(15);
                        break;
                    }
                case "WRITEMULTIPLEHOLDINGREGISTERS":
                    {
                        ProjectDeviceCommandAdd(16);
                        break;
                    }
                case "ARBITRARY":
                    {
                        ProjectDeviceCommandAdd(99);
                        break;
                    }
                case "CALCULATORCONFIGURATION":
                    {
                        ProjectDeviceCommandAdd(80);
                        break;
                    }
                case "VALUES81":
                    {
                        ProjectDeviceCommandAdd(81);
                        break;
                    }
                case "VALUES82":
                    {
                        ProjectDeviceCommandAdd(82);
                        break;
                    }
                case "VALUES83":
                    {
                        ProjectDeviceCommandAdd(83);
                        break;
                    }
                case "ARCHIVEVALUES84":
                    {
                        ProjectDeviceCommandAdd(84);
                        break;
                    }
                case "ARCHIVEVALUES85":
                    {
                        ProjectDeviceCommandAdd(85);
                        break;
                    }
                case "ARCHIVEVALUES86":
                    {
                        ProjectDeviceCommandAdd(86);
                        break;
                    }
                case "ARCHIVESITUATIONS":
                    {
                        ProjectDeviceCommandAdd(87);
                        break;
                    }
                case "TOTALVOLUME":
                    {
                        ProjectDeviceCommandAdd(88);
                        break;
                    }
                case "ARCHIVE100POWERBREAKS":
                    {
                        ProjectDeviceCommandAdd(90);
                        break;
                    }
                case "ARCHIVE450EMERGENCYSITUATIONS":
                    {
                        ProjectDeviceCommandAdd(91);
                        break;
                    }
                case "CALCULATORCONFIGURATION95":
                    {
                        ProjectDeviceCommandAdd(95);
                        break;
                    }
                case "ENTERINGPARAMETERS":
                    {
                        ProjectDeviceCommandAdd(96);
                        break;
                    }
            }
        }

        private void cmnuDeviceCommandDel_Click(object sender, EventArgs e)
        {
            ProjectDeviceCommandDelete();
        }

        private void cmnuDeviceTagAdd_Click(object sender, EventArgs e)
        {
            ProjectDeviceTagAdd();
        }

        private void cmnuDeviceTagDel_Click(object sender, EventArgs e)
        {
            ProjectDeviceTagDelete();
        }

        #endregion Context Menu

        #region Project

        private void ProjectDefaultNew(DialogResult dialog)
        {
            if (dialog == DialogResult.Yes)
            {
                DialogResult dialogResult = MessageBox.Show("Создать новую конфигурацию?", "Создание конфигурации", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ProjectNew();
                }
            }

            if (dialog == DialogResult.No)
            {
                ProjectNew();
            }
        }

        private void ProjectNew()
        {
            //Проверка вкладок
            ValidateTabPage();
            //Убираем имя проекта и путь до него
            ProjectFileName = "";
            ProjectPath = "";
            //Создаем новый проект с настройками по умолчанию
            project = new Project();
            //Очищаем проект
            trvProject.Nodes.Clear();
            //Добавляем канал
            ProjectChannelDeviceAdd();
        }

        private void ProjectLoad(string fileName)
        {
            if (File.Exists(fileName))
            {
                DeserializeTreeView(trvProject, fileName);
            }
        }

        public void DeserializeTreeView(System.Windows.Forms.TreeView treeView, string fileName)
        {
            treeView.Nodes.Clear();
            XmlTextReader reader = null;
            try
            {
                // disabling re-drawing of treeview till all nodes are added
                treeView.BeginUpdate();
                reader = new XmlTextReader(fileName);
                TreeNode parentNode = null;
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            TreeNode newNode = new TreeNode();
                            bool isEmptyElement = reader.IsEmptyElement;

                            // loading node attributes
                            int attributeCount = reader.AttributeCount;

                            if (attributeCount > 0)
                            {
                                Dictionary<string, string> attributes = new Dictionary<string, string>();
                                string newNodeName = string.Empty;
                                string newNodeImageKey = string.Empty;
                                string newNodeType = string.Empty;

                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    attributes.Add(reader.Name, reader.Value);
                                }

                                newNodeName = attributes[XmlNodeTextAtt];
                                if (attributes.TryGetValue(XmlNodeTextAtt, out string attributesValue1))
                                {
                                    newNodeName = attributes[XmlNodeTextAtt];
                                }

                                newNodeImageKey = attributes[XmlNodeImageIndexAtt];
                                if (attributes.TryGetValue(XmlNodeImageIndexAtt, out string attributesValue2))
                                {
                                    newNodeImageKey = attributes[XmlNodeImageIndexAtt];
                                }

                                if (attributes.TryGetValue(XmlNodeTagAtt, out string attributesValue3))
                                {
                                    newNodeType = attributes[XmlNodeTagAtt];
                                }

                                ProjectNodeData projectNodeData = new ProjectNodeData();

                                switch (newNodeType)
                                {
                                    case "CHANNEL":
                                        #region Channel
                                        ProjectChannelDevice projectChannelDevice = new ProjectChannelDevice();

                                        try { projectChannelDevice.ChannelKeyImage = attributes["NAME"]; } catch { }
                                        try { projectChannelDevice.ChannelID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectChannelDevice.ChannelName = attributes["NAME"]; } catch { }
                                        try { projectChannelDevice.ChannelDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectChannelDevice.ChannelEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
                                        try { projectChannelDevice.ChannelType = Convert.ToInt32(attributes["TYPE"]); } catch { }
                                        try { projectChannelDevice.GatewayTypeProtocol = Convert.ToInt32(attributes["GATEWAY"]); } catch { }
                                        try { projectChannelDevice.GatewayPort = Convert.ToInt32(attributes["GATEWAYPORT"]); } catch { }
                                        try { projectChannelDevice.GatewayConnectedClientsMax = Convert.ToInt32(attributes["CONNECTEDCLIENTSMAX"]); } catch { }

                                        try { projectChannelDevice.WriteTimeout = Convert.ToInt32(attributes["WRITETIMEOUT"]); } catch { }
                                        try { projectChannelDevice.ReadTimeout = Convert.ToInt32(attributes["READTIMEOUT"]); } catch { }
                                        try { projectChannelDevice.Timeout = Convert.ToInt32(attributes["TIMEOUT"]); } catch { }

                                        try { projectChannelDevice.WriteBufferSize = Convert.ToInt32(attributes["WRITEBUFFERSIZE"]); } catch { }
                                        try { projectChannelDevice.ReadBufferSize = Convert.ToInt32(attributes["READBUFFERSIZE"]); } catch { }

                                        try { projectChannelDevice.CountError = Convert.ToInt32(attributes["COUNTERROR"]); } catch { }

                                        if (Convert.ToInt32(attributes["TYPE"]) == 1) //Последовательный порт
                                        {
                                            try { projectChannelDevice.SerialPortName = attributes["SERIALPORTNAME"]; } catch { }
                                            try { projectChannelDevice.SerialPortBaudRate = attributes["SERIALPORTBAUDRATE"]; } catch { }
                                            try { projectChannelDevice.SerialPortDataBits = attributes["SERIALPORTDATABITS"]; } catch { }
                                            try { projectChannelDevice.SerialPortParity = attributes["SERIALPORTPARITY"]; } catch { }
                                            try { projectChannelDevice.SerialPortStopBits = attributes["SERIALPORTSTOPBITS"]; } catch { }

                                            try { projectChannelDevice.SerialPortHandshake = attributes["HANDSHAKE"]; } catch { }
                                            try { projectChannelDevice.SerialPortDtrEnable = Convert.ToBoolean(attributes["DTR"]); } catch { }
                                            try { projectChannelDevice.SerialPortRtsEnable = Convert.ToBoolean(attributes["RTS"]); } catch { }
                                            try { projectChannelDevice.SerialPortReceivedBytesThreshold = Convert.ToInt32(attributes["RECEIVEDBYTESTHRESHOLD"]); } catch { }
                                        }

                                        if (Convert.ToInt32(attributes["TYPE"]) == 2 || Convert.ToInt32(attributes["TYPE"]) == 3) // TCP UDP клиент
                                        {
                                            try { projectChannelDevice.ClientHost = attributes["CLIENTHOST"]; } catch { }
                                            try { projectChannelDevice.ClientPort = Convert.ToInt32(attributes["CLIENTPORT"]); } catch { }
                                        }

                                        projectNodeData.channel = projectChannelDevice;
                                        projectNodeData.nodeType = ProjectNodeType.Channel;

                                        newNode.Tag = projectNodeData;
                                        #endregion Channel
                                        break;
                                    case "DEVICE":
                                        #region Device
                                        ProjectDevice projectDevice = new ProjectDevice();

                                        try { projectDevice.ChannelID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDevice.DeviceID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDevice.DeviceAddress = Convert.ToUInt16(attributes["ADDRESS"]); } catch { }
                                        try { projectDevice.DeviceName = attributes["NAME"]; } catch { }
                                        try { projectDevice.DeviceDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDevice.DeviceEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

                                        try
                                        {
                                            // 2x 4x byte device
                                            projectDevice.DeviceRegistersBytes = 0;
                                            foreach (string key in attributes.Keys)
                                            {
                                                if (key.Contains("REGISTERSBYTES"))
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(attributes["REGISTERSBYTES"]) == 2)
                                                        {
                                                            projectDevice.DeviceRegistersBytes = 0;
                                                        }
                                                        else if (Convert.ToInt32(attributes["REGISTERSBYTES"]) == 4)
                                                        {
                                                            projectDevice.DeviceRegistersBytes = 1;
                                                        }
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        catch { }

                                        try
                                        {
                                            // 2x 4x byte device (gateway)
                                            projectDevice.DeviceGatewayRegistersBytes = 0;
                                            foreach (string key in attributes.Keys)
                                            {
                                                if (key.Contains("GATEWAYREGISTERSBYTES"))
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(attributes["GATEWAYREGISTERSBYTES"]) == 2)
                                                        {
                                                            projectDevice.DeviceGatewayRegistersBytes = 0;
                                                        }
                                                        else if (Convert.ToInt32(attributes["GATEWAYREGISTERSBYTES"]) == 4)
                                                        {
                                                            projectDevice.DeviceGatewayRegistersBytes = 1;
                                                        }
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        catch { }

                                        // format float
                                        try { projectDevice.DeviceFloatFormat = Convert.ToInt32(attributes["FLOATFORMAT"]); } catch { }

                                        try { projectDevice.DeviceStatus = Convert.ToInt32(attributes["STATUS"]); } catch { }
                                        try { projectDevice.DevicePollingOnScheduleStatus = Convert.ToBoolean(attributes["POLLINGONSCHEDULESTATUS"]); } catch { }
                                        try { projectDevice.DeviceIntervalPool = Convert.ToInt32(attributes["INTERVALPOOL"]); } catch { }
                                        try { projectDevice.DeviceTypeProtocol = Convert.ToInt32(attributes["TYPEPROTOCOL"]); } catch { }

                                        try { projectDevice.DeviceDateTimeLastSuccessfully = DateTime.Parse(attributes["DATETIMELASTSUCCESSFULLY"]); } catch { }
                                        try
                                        {
                                            // creating a buffer
                                            // adding Registers 65535
                                            for (ulong index = 0; index < (ulong)65535; ++index)
                                            {
                                                bool status = false;
                                                ulong value = 0;

                                                projectDevice.SetCoil(Convert.ToUInt64(index), status);
                                                projectDevice.SetDiscreteInput(Convert.ToUInt64(index), status);
                                                projectDevice.SetHoldingRegister(Convert.ToUInt64(index), value);
                                                projectDevice.SetInputRegister(Convert.ToUInt64(index), value);
                                            }

                                            for (ulong index = 0; index < (ulong)9999999; ++index)
                                            {
                                                ulong value = 0;
                                                projectDevice.SetDataBuffer(Convert.ToUInt64(index), value);
                                            }
                                        }
                                        catch { }

                                        // fill in the registers by the name of the attribute and its value from the dictionary of Attribute registers 65535
                                        foreach (string key in attributes.Keys)
                                        {
                                            if (key.Contains("COILREGISTER"))
                                            {
                                                try
                                                {
                                                    bool Coil = Convert.ToBoolean(attributes[key]);
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("COILREGISTER", ""));
                                                    projectDevice.SetCoil(RegAddr, Coil);
                                                }
                                                catch { }
                                            }
                                            else if (key.Contains("DISCRETEINPUT"))
                                            {
                                                try
                                                {
                                                    bool DiscreteInput = Convert.ToBoolean(attributes[key]);
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("DISCRETEINPUT", ""));
                                                    projectDevice.SetDiscreteInput(RegAddr, DiscreteInput);
                                                }
                                                catch { }
                                            }
                                            else if (key.Contains("HOLDINGREGISTER"))
                                            {
                                                try
                                                {
                                                    ulong HoldingRegister = Convert.ToUInt64(attributes[key]);
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("HOLDINGREGISTER", ""));
                                                    projectDevice.SetHoldingRegister(RegAddr, HoldingRegister);
                                                }
                                                catch { }
                                            }
                                            else if (key.Contains("INPUTREGISTER"))
                                            {
                                                try
                                                {
                                                    ulong InputRegister = Convert.ToUInt16(Convert.ToInt64(attributes[key]));
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("INPUTREGISTER", ""));
                                                    projectDevice.SetInputRegister(RegAddr, InputRegister);
                                                }
                                                catch { }
                                            }
                                        }

                                        projectNodeData.device = projectDevice;
                                        projectNodeData.nodeType = ProjectNodeType.Device;

                                        newNode.Tag = projectNodeData;
                                        #endregion Device
                                        break;
                                    case "DEVICEGROUPCOMMAND":
                                        #region Device Group Command
                                        ProjectDeviceGroupCommand projectDeviceGroupCommand = new ProjectDeviceGroupCommand();

                                        try { projectDeviceGroupCommand.DeviceID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandName = attributes["NAME"]; } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

                                        projectNodeData.deviceGroupCommand = projectDeviceGroupCommand;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceGroupCommand;

                                        newNode.Tag = projectNodeData;
                                        #endregion Device Group Command
                                        break;
                                    case "DEVICECOMMAND":
                                        #region Device
                                        ProjectDeviceCommand projectDeviceCommand = new ProjectDeviceCommand();

                                        try { projectDeviceCommand.DeviceID = DriverUtils.StringToGuid(attributes["IDDEVICE"]); } catch { }
                                        try { projectDeviceCommand.DeviceGroupCommandID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandName = attributes["NAME"]; } catch { }
                                        try { projectDeviceCommand.DeviceCommandDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceCommand.DeviceCommandEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandFunctionCode = Convert.ToUInt16(attributes["FUNCTION"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterStartAddress = Convert.ToUInt16(attributes["REGISTERSTARTADDRESS"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterCount = Convert.ToUInt16(attributes["REGISTERCOUNT"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandParametr = Convert.ToUInt16(attributes["REGISTERPARAMETR"]); } catch { }

                                        try { projectDeviceCommand.DeviceCommandRegisterNameReadData = attributes["REGISTERNAMEREADDATA"].Split(' '); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterReadData = Array.ConvertAll(attributes["REGISTERREADDATA"].Split(' '), x => { ulong res = Convert.ToUInt64(x); return res; }); } catch { }

                                        try { projectDeviceCommand.DeviceCommandRegisterNameWriteData = attributes["REGISTERNAMEWRITEDATA"].Split(' '); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterWriteData = Array.ConvertAll(attributes["REGISTERWRITEDATA"].Split(' '), x => { ulong res = Convert.ToUInt64(x); return res; }); } catch { }

                                        projectNodeData.deviceCommand = projectDeviceCommand;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceCommand;

                                        newNode.Tag = projectNodeData;

                                        #endregion Device
                                        break;
                                    case "DEVICEGROUPTAG":
                                        #region Device Group Tag
                                        ProjectDeviceGroupTag projectDeviceGroupTag = new ProjectDeviceGroupTag();

                                        try { projectDeviceGroupTag.DeviceID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagName = attributes["NAME"]; } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

                                        projectNodeData.deviceGroupTag = projectDeviceGroupTag;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceGroupTag;

                                        newNode.Tag = projectNodeData;

                                        #endregion Device Group Tag
                                        break;
                                    case "DEVICETAG":
                                        #region Device Tag
                                        ProjectDeviceTag projectDeviceTag = new ProjectDeviceTag();

                                        try { projectDeviceTag.DeviceID = DriverUtils.StringToGuid(attributes["DEVICEID"]); } catch { }
                                        try { projectDeviceTag.DeviceGroupTagID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceTag.DeviceTagID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceTag.DeviceTagEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
                                        try { projectDeviceTag.DeviceTagAddress = attributes["ADDRESS"]; } catch { }
                                        try { projectDeviceTag.DeviceTagname = attributes["NAME"]; } catch { }
                                        try { projectDeviceTag.DeviceTagCode = attributes["CODE"]; } catch { }
                                        try { projectDeviceTag.DeviceTagDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceTag.DeviceTagCoefficient = Convert.ToSingle(attributes["COEFFICIENT"]); } catch { }
                                        try { projectDeviceTag.DeviceTagSorting = attributes["SORTING"]; } catch { }

                                        try { projectDeviceTag.DeviceTagScaled = Convert.ToInt32(attributes["SCALED"]); } catch { }
                                        try { projectDeviceTag.DeviceTagScaledHigh = Convert.ToSingle(attributes["SCALEDHIGH"]); } catch { }
                                        try { projectDeviceTag.DeviceTagScaledLow = Convert.ToSingle(attributes["SCALEDLOW"]); } catch { }
                                        try { projectDeviceTag.DeviceTagRowHigh = Convert.ToSingle(attributes["ROWHIGH"]); } catch { }
                                        try { projectDeviceTag.DeviceTagRowLow = Convert.ToSingle(attributes["ROWLOW"]); } catch { }

                                        try
                                        {
                                            ProjectDeviceTag.DeviceTagFormatData Type = (ProjectDeviceTag.DeviceTagFormatData)Enum.Parse(typeof(ProjectDeviceTag.DeviceTagFormatData), attributes["TYPE"]);
                                            projectDeviceTag.DeviceTagType = Type;
                                        }
                                        catch { }

                                        projectNodeData.deviceTag = projectDeviceTag;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceTag;

                                        newNode.Tag = projectNodeData;
                                        #endregion Device Tag
                                        break;
                                    default:
                                        newNode.Tag = projectNodeData;
                                        break;
                                }

                                newNode.Text = newNodeName;
                                newNode.ImageKey = newNodeImageKey;
                            }

                            // add new node to Parent Node or TreeView
                            if (parentNode != null)
                            {
                                parentNode.Nodes.Add(newNode);
                            }
                            else
                            {
                                treeView.Nodes.Add(newNode);
                            }

                            // making current node 'ParentNode' if its not empty
                            if (!isEmptyElement)
                            {
                                parentNode = newNode;
                            }
                        }
                    }
                    // moving up to in TreeView if end tag is encountered
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            parentNode = parentNode.Parent;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    {
                        //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        parentNode.Nodes.Add(reader.Value);
                    }

                }
            }
            finally
            {
                // enabling redrawing of treeview after all nodes are added
                treeView.EndUpdate();
                reader.Close();
            }
        }

        private void ProjectSave()
        {
            if (String.IsNullOrEmpty(ProjectFileNameFull))
            {
                ProjectFileNameFull = Path.Combine(ConfigDir, DriverUtils.GetFileName(DeviceNum));
            }

            SerializeTreeView(trvProject, ProjectFileNameFull);
        }

        public void SerializeTreeView(System.Windows.Forms.TreeView treeView, string fileName)
        {
            XmlTextWriter textWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
            // writing the xml declaration tag
            textWriter.WriteStartDocument();
            //textWriter.WriteRaw("\r\n");
            // writing the main tag that encloses all node tags
            textWriter.WriteStartElement(DriverUtils.DriverCode);

            // save the nodes, recursive method
            SaveNodes(treeView.Nodes, textWriter);

            textWriter.WriteEndElement();
            textWriter.Close();
        }

        private void SaveNodes(TreeNodeCollection nodesCollection, XmlTextWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                ProjectNodeData prNodeData = (ProjectNodeData)node.Tag;

                textWriter.WriteStartElement(XmlNodeTag);
                textWriter.WriteAttributeString(XmlNodeTextAtt, node.Text);
                textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageKey.ToString());


                if (node.Tag != null)
                {
                    #region Channel
                    // channel
                    if (prNodeData.nodeType == ProjectNodeType.Channel)
                    {
                        try { textWriter.WriteAttributeString(XmlNodeTagAtt, "CHANNEL"); } catch { }

                        try { textWriter.WriteAttributeString("ID", prNodeData.channel.ChannelID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("NAME", prNodeData.channel.ChannelName); } catch { }
                        try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.channel.ChannelDescription); } catch { }
                        try { textWriter.WriteAttributeString("ENABLED", prNodeData.channel.ChannelEnabled.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("TYPE", prNodeData.channel.ChannelType.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("GATEWAY", prNodeData.channel.GatewayTypeProtocol.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("GATEWAYPORT", prNodeData.channel.GatewayPort.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("CONNECTEDCLIENTSMAX", prNodeData.channel.GatewayConnectedClientsMax.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("WRITETIMEOUT", prNodeData.channel.WriteTimeout.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("READTIMEOUT", prNodeData.channel.ReadTimeout.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("TIMEOUT", prNodeData.channel.Timeout.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("WRITEBUFFERSIZE", prNodeData.channel.WriteBufferSize.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("READBUFFERSIZE", prNodeData.channel.ReadBufferSize.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("COUNTERROR", prNodeData.channel.CountError.ToString()); } catch { }

                        if (prNodeData.channel.ChannelType == 1) //Последовательный порт
                        {
                            try { textWriter.WriteAttributeString("SERIALPORTNAME", prNodeData.channel.SerialPortName); } catch { }
                            try { textWriter.WriteAttributeString("SERIALPORTBAUDRATE", prNodeData.channel.SerialPortBaudRate); } catch { }
                            try { textWriter.WriteAttributeString("SERIALPORTDATABITS", prNodeData.channel.SerialPortDataBits); } catch { }
                            try { textWriter.WriteAttributeString("SERIALPORTPARITY", prNodeData.channel.SerialPortParity); } catch { }
                            try { textWriter.WriteAttributeString("SERIALPORTSTOPBITS", prNodeData.channel.SerialPortStopBits); } catch { }

                            try { textWriter.WriteAttributeString("HANDSHAKE", prNodeData.channel.SerialPortHandshake); } catch { }
                            try { textWriter.WriteAttributeString("DTR", prNodeData.channel.SerialPortDtrEnable.ToString()); } catch { }
                            try { textWriter.WriteAttributeString("RTS", prNodeData.channel.SerialPortRtsEnable.ToString()); } catch { }
                            try { textWriter.WriteAttributeString("RECEIVEDBYTESTHRESHOLD", prNodeData.channel.SerialPortReceivedBytesThreshold.ToString()); } catch { }
                        }

                        if (prNodeData.channel.ChannelType == 2 || prNodeData.channel.ChannelType == 3) //TCP UDP клиент
                        {
                            try { textWriter.WriteAttributeString("CLIENTHOST", prNodeData.channel.ClientHost); } catch { }
                            try { textWriter.WriteAttributeString("CLIENTPORT", prNodeData.channel.ClientPort.ToString()); } catch { }
                        }
                    }
                    #endregion Channel

                    #region Device
                    // device
                    if (prNodeData.nodeType == ProjectNodeType.Device)
                    {
                        try { textWriter.WriteAttributeString(XmlNodeTagAtt, "DEVICE"); } catch { }

                        try { textWriter.WriteAttributeString("IDPARENT", prNodeData.device.ChannelID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ID", prNodeData.device.DeviceID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ADDRESS", prNodeData.device.DeviceAddress.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("NAME", prNodeData.device.DeviceName); } catch { }
                        try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.device.DeviceDescription); } catch { }
                        try { textWriter.WriteAttributeString("ENABLED", prNodeData.device.DeviceEnabled.ToString()); } catch { }

                        if (prNodeData.device.DeviceRegistersBytes == 0)
                        {
                            try { textWriter.WriteAttributeString("REGISTERSBYTES", "2"); } catch { }
                        }
                        else if (prNodeData.device.DeviceRegistersBytes == 1)
                        {
                            try { textWriter.WriteAttributeString("REGISTERSBYTES", "4"); } catch { }
                        }

                        if (prNodeData.device.DeviceGatewayRegistersBytes == 0)
                        {
                            try { textWriter.WriteAttributeString("GATEWAYREGISTERSBYTES", "2"); } catch { }
                        }
                        else if (prNodeData.device.DeviceGatewayRegistersBytes == 1)
                        {
                            try { textWriter.WriteAttributeString("GATEWAYREGISTERSBYTES", "4"); } catch { }
                        }

                        try { textWriter.WriteAttributeString("FLOATFORMAT", prNodeData.device.DeviceFloatFormat.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("STATUS", prNodeData.device.DeviceStatus.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("POLLINGONSCHEDULESTATUS", prNodeData.device.DevicePollingOnScheduleStatus.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("INTERVALPOOL", prNodeData.device.DeviceIntervalPool.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("TYPEPROTOCOL", prNodeData.device.DeviceTypeProtocol.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("DATETIMELASTSUCCESSFULLY", prNodeData.device.DeviceDateTimeLastSuccessfully.ToString()); } catch { }

                        #region Buffer
                        for (int index = 0; index < 65535; ++index)
                        {
                            //Coils
                            if (prNodeData.device.CoilsExists(Convert.ToUInt16(index)))
                            {
                                string TextCoilsID = (index).ToString();
                                string TextCoilsWord = prNodeData.device.GetBooleanCoil(Convert.ToUInt64(index)).ToString();

                                if (TextCoilsWord != "False")
                                {
                                    try { textWriter.WriteAttributeString("COILREGISTER" + TextCoilsID, TextCoilsWord); } catch { }
                                }
                            }

                            //DiscreteInputs
                            if (prNodeData.device.DiscreteInputsExists(Convert.ToUInt16(index)))
                            {
                                string TextDiscreteInputsID = (index).ToString();
                                string TextDiscreteInputsWord = prNodeData.device.GetBooleanDiscreteInput(Convert.ToUInt64(index)).ToString();

                                if (TextDiscreteInputsWord != "False")
                                {
                                    try { textWriter.WriteAttributeString("DISCRETEINPUT" + TextDiscreteInputsID, TextDiscreteInputsWord); } catch { }
                                }
                            }

                            //HoldingRegisters
                            if (prNodeData.device.HoldingRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextHoldingID = (index).ToString();
                                string TextHoldingWord = prNodeData.device.GetUlongHoldingRegister(Convert.ToUInt64(index)).ToString();

                                if (TextHoldingWord != "0")
                                {
                                    try { textWriter.WriteAttributeString("HOLDINGREGISTER" + TextHoldingID, TextHoldingWord); } catch { }
                                }
                            }

                            //InputRegisters
                            if (prNodeData.device.InputRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextInputID = (index).ToString();
                                string TextInputWord = prNodeData.device.GetUlongInputRegister(Convert.ToUInt64(index)).ToString();

                                if (TextInputWord != "0")
                                {
                                    try { textWriter.WriteAttributeString("INPUTREGISTER" + TextInputID, TextInputWord); } catch { }
                                }
                            }
                        }
                        #endregion Buffer

                    }
                    #endregion Device

                    #region Device Group Command

                    if (prNodeData.nodeType == ProjectNodeType.DeviceGroupCommand)
                    {
                        try { textWriter.WriteAttributeString(XmlNodeTagAtt, "DEVICEGROUPCOMMAND"); } catch { }

                        try { textWriter.WriteAttributeString("IDPARENT", prNodeData.deviceGroupCommand.DeviceID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ID", prNodeData.deviceGroupCommand.DeviceGroupCommandID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("NAME", prNodeData.deviceGroupCommand.DeviceGroupCommandName); } catch { }
                        try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.deviceGroupCommand.DeviceGroupCommandDescription); } catch { }
                        try { textWriter.WriteAttributeString("ENABLED", prNodeData.deviceGroupCommand.DeviceGroupCommandEnabled.ToString()); } catch { }
                    }

                    #endregion Device Group Command

                    #region Device Command

                    if (prNodeData.nodeType == ProjectNodeType.DeviceCommand)
                    {
                        try { textWriter.WriteAttributeString(XmlNodeTagAtt, "DEVICECOMMAND"); } catch { }

                        try { textWriter.WriteAttributeString("IDDEVICE", prNodeData.deviceCommand.DeviceID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("IDPARENT", prNodeData.deviceCommand.DeviceGroupCommandID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ID", prNodeData.deviceCommand.DeviceCommandID.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("NAME", prNodeData.deviceCommand.DeviceCommandName); } catch { }
                        try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.deviceCommand.DeviceCommandDescription); } catch { }
                        try { textWriter.WriteAttributeString("ENABLED", prNodeData.deviceCommand.DeviceCommandEnabled.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("FUNCTION", prNodeData.deviceCommand.DeviceCommandFunctionCode.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("REGISTERSTARTADDRESS", prNodeData.deviceCommand.DeviceCommandRegisterStartAddress.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("REGISTERCOUNT", prNodeData.deviceCommand.DeviceCommandRegisterCount.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("REGISTERPARAMETR", prNodeData.deviceCommand.DeviceCommandParametr.ToString()); } catch { }

                        try
                        {
                            string[] commandRegisterReadName = prNodeData.deviceCommand.DeviceCommandRegisterNameReadData;
                            textWriter.WriteAttributeString("REGISTERNAMEREADDATA", String.Join(" ", commandRegisterReadName));
                        }
                        catch { }

                        try
                        {
                            ulong[] commandRegisterReadData = prNodeData.deviceCommand.DeviceCommandRegisterReadData;
                            string[] strCommandRegisterReadData = Array.ConvertAll(commandRegisterReadData, x => { string res = x.ToString(); return res; });
                            textWriter.WriteAttributeString("REGISTERREADDATA", String.Join(" ", strCommandRegisterReadData));
                        }
                        catch { }

                        try
                        {
                            string[] CommandRegisterWriteName = prNodeData.deviceCommand.DeviceCommandRegisterNameWriteData;
                            textWriter.WriteAttributeString("REGISTERNAMEWRITEDATA", String.Join(" ", CommandRegisterWriteName));
                        }
                        catch { }

                        try
                        {
                            ulong[] CommandRegisterWriteData = prNodeData.deviceCommand.DeviceCommandRegisterWriteData;
                            string[] str_tmp_CommandRegisterWriteData = Array.ConvertAll(CommandRegisterWriteData, x => { string res = x.ToString(); return res; });
                            textWriter.WriteAttributeString("REGISTERWRITEDATA", String.Join(" ", str_tmp_CommandRegisterWriteData));
                        }
                        catch { }
                    }

                    #endregion Device Command

                    #region Device Group Tag

                    if (prNodeData.nodeType == ProjectNodeType.DeviceGroupTag)
                    {
                        try { textWriter.WriteAttributeString(XmlNodeTagAtt, "DEVICEGROUPTAG"); } catch { }

                        try { textWriter.WriteAttributeString("IDPARENT", prNodeData.deviceGroupTag.DeviceID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ID", prNodeData.deviceGroupTag.DeviceGroupTagID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("NAME", prNodeData.deviceGroupTag.DeviceGroupTagName); } catch { }
                        try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.deviceGroupTag.DeviceGroupTagDescription); } catch { }
                        try { textWriter.WriteAttributeString("ENABLED", prNodeData.deviceGroupTag.DeviceGroupTagEnabled.ToString()); } catch { }

                    }

                    #endregion Device Group Tag

                    #region Device Tag
                    if (prNodeData.nodeType == ProjectNodeType.DeviceTag)
                    {

                        try { textWriter.WriteAttributeString(XmlNodeTagAtt, "DEVICETAG"); } catch { }

                        try { textWriter.WriteAttributeString("DEVICEID", prNodeData.deviceTag.DeviceID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("IDPARENT", prNodeData.deviceTag.DeviceGroupTagID.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ID", prNodeData.deviceTag.DeviceTagID.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("ENABLED", prNodeData.deviceTag.DeviceTagEnabled.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ADDRESS", prNodeData.deviceTag.DeviceTagAddress.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("NAME", prNodeData.deviceTag.DeviceTagname.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("CODE", prNodeData.deviceTag.DeviceTagCode.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("TYPE", DriverUtils.NullToString(prNodeData.deviceTag.DeviceTagType)); } catch { }
                        try { textWriter.WriteAttributeString("SORTING", prNodeData.deviceTag.DeviceTagSorting.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("COEFFICIENT", prNodeData.deviceTag.DeviceTagCoefficient.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.deviceTag.DeviceTagDescription.ToString()); } catch { }

                        try { textWriter.WriteAttributeString("SCALED", prNodeData.deviceTag.DeviceTagScaled.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("SCALEDHIGH", prNodeData.deviceTag.DeviceTagScaledHigh.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("SCALEDLOW", prNodeData.deviceTag.DeviceTagScaledLow.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ROWHIGH", prNodeData.deviceTag.DeviceTagRowHigh.ToString()); } catch { }
                        try { textWriter.WriteAttributeString("ROWLOW", prNodeData.deviceTag.DeviceTagRowLow.ToString()); } catch { }
                    }
                    #endregion Device Tag

                }

                // add other node properties to serialize here  
                if (node.Nodes.Count > 0)
                {
                    SaveNodes(node.Nodes, textWriter);
                }

                textWriter.WriteEndElement();
            }
        }
        #endregion Project

        #region Adding and removing elements

        #region ProjectChannelDevice
        private void ProjectChannelDeviceAdd()
        {
            ProjectChannelDevice projectChannelDevice = new ProjectChannelDevice();
            projectChannelDevice.ChannelID = Guid.NewGuid();
            projectChannelDevice.ChannelName = "Канал связи";
            projectChannelDevice.ChannelDescription = "";
            projectChannelDevice.ChannelEnabled = true;
            projectChannelDevice.GatewayTypeProtocol = 0;
            projectChannelDevice.GatewayPort = 60000;
            projectChannelDevice.GatewayConnectedClientsMax = 10;

            projectChannelDevice.WriteTimeout = 10000;
            projectChannelDevice.ReadTimeout = 10000;
            projectChannelDevice.Timeout = 1000;

            projectChannelDevice.WriteBufferSize = 8192;
            projectChannelDevice.ReadBufferSize = 8192;

            projectChannelDevice.CountError = 3;
            //Добавляем в дерево
            NodeProjectChannelDeviceAdd(projectChannelDevice, cmnuDeviceAppend);
            //Добавляем в проект
            project.Settings.ProjectChannelDevice = projectChannelDevice;
        }

        //Удаление канала
        private void ProjectChannelDeviceDelete()
        {
            TreeNode selectNode = trvProject.SelectedNode;
            string text = selectNode.Text;
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить " + text + " ?", "Удаление", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dr)
            {
                selectNode.Remove();
            }
        }

        //Добавляем в дерево
        public TreeNode NodeProjectChannelDeviceAdd(ProjectChannelDevice cnl, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(cnl.ChannelName);
                tn.ImageKey = tn.SelectedImageKey = cnl.ChannelKeyImage;
                this.trvProject.Nodes.Add(tn);

                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.channel = cnl;
                ProjectNodeData.nodeType = ProjectNodeType.Channel;

                tn.ContextMenuStrip = cms;
                tn.Tag = ProjectNodeData;

                return tn;
            }
            return null;
        }

        #endregion ProjectChannelDevice

        #region ProjectDevice
        //Добавление устройства
        private void ProjectDeviceAdd()
        {
            ProjectDevice projectDevice = new ProjectDevice();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectChannelDevice projectChannelDevice = ((ProjectNodeData)selectNode.Tag).channel;
            Guid ParentID = projectChannelDevice.ChannelID;
            projectDevice.ChannelID = ParentID;

            projectDevice.DeviceName = "Устройство";
            projectDevice.DeviceDescription = "";
            projectDevice.DeviceID = Guid.NewGuid();
            projectDevice.DeviceEnabled = true;
            projectDevice.DeviceStatus = 0; //Статус Неизвестно
            projectDevice.DeviceRegistersBytes = 0; //2-х байтовый //4-х
            projectDevice.DeviceAddress = 1;
            projectDevice.DeviceDateTimeLastSuccessfully = new DateTime(2000, 1, 1, 0, 0, 0);

            //Добавление регистров 65535
            for (ulong index = 0; index < (ulong)65535; ++index)
            {
                bool status = false;
                ulong value = 0;

                projectDevice.SetCoil(Convert.ToUInt64(index), status);
                projectDevice.SetDiscreteInput(Convert.ToUInt64(index), status);
                projectDevice.SetHoldingRegister(Convert.ToUInt64(index), value);
                projectDevice.SetInputRegister(Convert.ToUInt64(index), value);
            }

            //Делаем активно меню добавления канала
            TreeNode deviceNew = NodeProjectDeviceAdd(projectDevice, selectNode, cmnuDeviceDelete);

            //Добавляем группу комманд
            ProjectDeviceGroupCommand projectDeviceGroupCommand = new ProjectDeviceGroupCommand();
            projectDeviceGroupCommand.DeviceID = projectDevice.DeviceID;
            projectDeviceGroupCommand.DeviceGroupCommandID = Guid.NewGuid();
            projectDeviceGroupCommand.DeviceGroupCommandEnabled = true;
            projectDeviceGroupCommand.DeviceGroupCommandName = "Команды";
            projectDevice.DeviceGroupCommands.Add(projectDeviceGroupCommand);
            //Добавляем в дерево
            NodeDeviceGroupCommandAdd(projectDeviceGroupCommand, deviceNew, cmnuDeviceCommandAppend);

            //Добавляем группу тегов
            ProjectDeviceGroupTag projectDeviceGroupTag = new ProjectDeviceGroupTag();
            projectDeviceGroupTag.DeviceID = projectDevice.DeviceID;
            projectDeviceGroupTag.DeviceGroupTagID = Guid.NewGuid();
            projectDeviceGroupTag.DeviceGroupTagEnabled = true;
            projectDeviceGroupTag.DeviceGroupTagName = "Группа тегов";
            projectDeviceGroupTag.DeviceTags = new List<ProjectDeviceTag>();
            projectDevice.DeviceGroupTags.Add(projectDeviceGroupTag);
            //Добавляем в дерево
            NodeDeviceGroupTagAdd(projectDeviceGroupTag, deviceNew, cmnuDeviceTagAppend);

            //Добавляем в проект
            project.Settings.ProjectChannelDevice.Devices.Add(projectDevice);
        }

        //Добавляем в дерево
        public TreeNode NodeProjectDeviceAdd(ProjectDevice dev, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(dev.DeviceName);
                dev.DeviceKeyImage = tn.ImageKey = tn.SelectedImageKey = "device_16.png";
                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.device = ((ProjectNodeData)ptn.Tag).device;
                ProjectNodeData.nodeType = ProjectNodeType.Device;
                ProjectNodeData.device = dev;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        //Удаление устройства
        private void ProjectDeviceDelete()
        {
            TreeNode selectNode = trvProject.SelectedNode;
            ProjectChannelDevice projectChannelDevice = ((ProjectNodeData)selectNode.Parent.Tag).channel;
            ProjectDevice projectDevice = ((ProjectNodeData)selectNode.Tag).device;
            string text = selectNode.Text;
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить " + text + " ?", "Удаление", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dr)
            {
                projectChannelDevice.Devices.Remove(projectDevice);
                selectNode.Remove();
            }
        }

        #endregion ProjectDevice

        #region DeviceGroupCommand
        //Добавление группы команд
        public TreeNode NodeDeviceGroupCommandAdd(ProjectDeviceGroupCommand devGrpCmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(devGrpCmd.DeviceGroupCommandName);
                devGrpCmd.DeviceGroupCommandKeyImage = tn.ImageKey = tn.SelectedImageKey = "group_command_16.png";
                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.deviceGroupCommand = ((ProjectNodeData)ptn.Tag).deviceGroupCommand;
                ProjectNodeData.nodeType = ProjectNodeType.DeviceGroupCommand;
                ProjectNodeData.deviceGroupCommand = devGrpCmd;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        #endregion DeviceGroupCommand

        #region DeviceCommand
        private void ProjectDeviceCommandAdd(ulong command)
        {
            ProjectDeviceCommand projectDeviceCommand = new ProjectDeviceCommand();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectDeviceGroupCommand projectDeviceGroupCommand = ((ProjectNodeData)selectNode.Tag).deviceGroupCommand;
            Guid ParentID = projectDeviceGroupCommand.DeviceGroupCommandID;
            Guid DeviceID = projectDeviceGroupCommand.DeviceID;

            projectDeviceCommand.DeviceID = DeviceID;
            projectDeviceCommand.DeviceGroupCommandID = ParentID;
            projectDeviceCommand.DeviceCommandID = Guid.NewGuid();
            projectDeviceCommand.DeviceCommandKeyImage = ProjectDeviceCommand.KeyImageName(command);
            projectDeviceCommand.DeviceCommandEnabled = true;
            projectDeviceCommand.DeviceCommandFunctionCode = command;
            projectDeviceCommand.DeviceCommandRegisterStartAddress = 0;
            projectDeviceCommand.DeviceCommandRegisterCount = 1;
            projectDeviceCommand.DeviceCommandParametr = 0;
            projectDeviceCommand.DeviceCommandName = projectDeviceCommand.GenerateName();
            projectDeviceCommand.DeviceCommandDescription = "";

            //Добавляем в дерево
            NodeDeviceCommandAdd(projectDeviceCommand, selectNode, cmnuDeviceCommandDelete);

            //Добавляем в проект
            projectDeviceGroupCommand.DeviceCommands.Add(projectDeviceCommand);
        }

        public TreeNode NodeDeviceCommandAdd(ProjectDeviceCommand devCmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(devCmd.DeviceCommandName);
                tn.ImageKey = tn.SelectedImageKey = ProjectDeviceCommand.KeyImageName(devCmd.DeviceCommandFunctionCode);

                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.deviceCommand = ((ProjectNodeData)ptn.Tag).deviceCommand;
                ProjectNodeData.nodeType = ProjectNodeType.DeviceCommand;
                ProjectNodeData.deviceCommand = devCmd;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        private void ProjectDeviceCommandDelete()
        {
            TreeNode selectNode = trvProject.SelectedNode;
            ProjectDeviceGroupCommand projectDeviceGroupCommand = ((ProjectNodeData)selectNode.Parent.Tag).deviceGroupCommand;
            ProjectDeviceCommand projectDeviceCommand = ((ProjectNodeData)selectNode.Tag).deviceCommand;
            string text = selectNode.Text;
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить " + text + " ?", "Удаление", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dr)
            {
                projectDeviceGroupCommand.DeviceCommands.Remove(projectDeviceCommand);
                selectNode.Remove();
            }
        }

        #endregion DeviceCommand

        #region DeviceGroupTag
        public TreeNode NodeDeviceGroupTagAdd(ProjectDeviceGroupTag devGrpTgs, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(devGrpTgs.DeviceGroupTagName);
                devGrpTgs.DeviceGroupTagKeyImage = tn.ImageKey = tn.SelectedImageKey = "group_tag_16.png";
                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.deviceGroupTag = ((ProjectNodeData)ptn.Tag).deviceGroupTag;
                ProjectNodeData.nodeType = ProjectNodeType.DeviceGroupTag;
                ProjectNodeData.deviceGroupTag = devGrpTgs;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        #endregion DeviceGroupTag

        #region DeviceTag

        private void ProjectDeviceTagAdd()
        {
            ProjectDeviceTag projectDeviceTag = new ProjectDeviceTag();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectDeviceGroupTag projectDeviceGroupTag = ((ProjectNodeData)selectNode.Tag).deviceGroupTag;
            Guid ParentID = projectDeviceGroupTag.DeviceGroupTagID;
            Guid DeviceID = projectDeviceGroupTag.DeviceID;

            projectDeviceTag.DeviceID = DeviceID;
            projectDeviceTag.DeviceGroupTagID = ParentID;
            projectDeviceTag.DeviceTagID = Guid.NewGuid();
            projectDeviceTag.DeviceTagEnabled = true;
            projectDeviceTag.DeviceTagAddress = "";
            projectDeviceTag.DeviceTagname = "TAG";
            projectDeviceTag.DeviceTagDescription = "";
            projectDeviceTag.DeviceTagCoefficient = 1;

            projectDeviceTag.DeviceTagScaled = 0;
            projectDeviceTag.DeviceTagScaledHigh = 1000;
            projectDeviceTag.DeviceTagScaledLow = 0;
            projectDeviceTag.DeviceTagRowHigh = 1000;
            projectDeviceTag.DeviceTagRowLow = 0;

            //Добавляем в дерево
            NodeDeviceTagAdd(projectDeviceTag, selectNode, cmnuDeviceTagDelete);

            //Добавляем в проект
            projectDeviceGroupTag.DeviceTags.Add(projectDeviceTag);

        }

        public TreeNode NodeDeviceTagAdd(ProjectDeviceTag devTag, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(devTag.DeviceTagname);
                devTag.DeviceTagKeyImage = tn.ImageKey = tn.SelectedImageKey = "tag_16.png";
                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.deviceTag = ((ProjectNodeData)ptn.Tag).deviceTag;
                ProjectNodeData.nodeType = ProjectNodeType.DeviceTag;
                ProjectNodeData.deviceTag = devTag;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        private void ProjectDeviceTagDelete()
        {
            TreeNode selectNode = trvProject.SelectedNode;
            ProjectDeviceGroupTag projectDeviceGroupTag = ((ProjectNodeData)selectNode.Parent.Tag).deviceGroupTag;
            ProjectDeviceTag projectDeviceTag = ((ProjectNodeData)selectNode.Tag).deviceTag;
            string text = selectNode.Text;
            DialogResult dr = MessageBox.Show("Вы действительно хотите удалить " + text + " ?", "Удаление", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dr)
            {
                projectDeviceGroupTag.DeviceTags.Remove(projectDeviceTag);
                selectNode.Remove();
            }
        }

        #endregion DeviceTag

        #endregion Adding and removing elements

        #region Selection of nodes and elements on the project
        private void trvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = trvProject.SelectedNode;
            mtNodeData = (ProjectNodeData)selectNode.Tag;
            //Грузим окно справа и его свойства
            LoadWindow(mtNodeData);
        }

        private void trvProject_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode selectNode = trvProject.GetNodeAt(new Point(e.X, e.Y));
            selectNode = trvProject.SelectedNode;
            selectNode.SelectedImageKey = selectNode.ImageKey;

            mtNodeData = (ProjectNodeData)selectNode.Tag;

            if (ProjectNodeType.Channel == mtNodeData.nodeType && mtNodeData.channel != null)
            {
                trvProject.ContextMenuStrip = cmnuDeviceAppend;
            }
            else if (ProjectNodeType.Device == mtNodeData.nodeType && mtNodeData.device != null)
            {
                trvProject.ContextMenuStrip = cmnuDeviceDelete;
            }
            else if (ProjectNodeType.DeviceGroupCommand == mtNodeData.nodeType && mtNodeData.deviceGroupCommand != null)
            {
                trvProject.ContextMenuStrip = cmnuDeviceCommandAppend;
            }
            else if (ProjectNodeType.DeviceCommand == mtNodeData.nodeType && mtNodeData.deviceCommand != null)
            {
                trvProject.ContextMenuStrip = cmnuDeviceCommandDelete;
            }
            else if (ProjectNodeType.DeviceGroupTag == mtNodeData.nodeType && mtNodeData.deviceGroupTag != null)
            {
                trvProject.ContextMenuStrip = cmnuDeviceTagAppend;
            }
            else if (ProjectNodeType.DeviceTag == mtNodeData.nodeType && mtNodeData.deviceTag != null)
            {
                trvProject.ContextMenuStrip = cmnuDeviceTagDelete;
            }
        }

        private void trvProject_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TreeViewHitTestInfo htInfo = trvProject.HitTest(e.X, e.Y);
                TreeNode selectNode = htInfo.Node;
                if (selectNode != null)
                {
                    trvProject.SelectedNode = selectNode;
                }
            }
            catch { }
        }

        private void LoadWindow(ProjectNodeData mtNodeData)
        {
            //Проверка вкладок
            ValidateTabPage();

            string keyImage = string.Empty;

            if (ProjectNodeType.Channel == mtNodeData.nodeType && mtNodeData.channel != null)
            {
                uscPropertyControl = new uscChannelDevice(mtNodeData);
                keyImage = mtNodeData.channel.ChannelKeyImage;
            }
            else if (ProjectNodeType.Device == mtNodeData.nodeType && mtNodeData.device != null)
            {
                uscPropertyControl = new uscDevice(mtNodeData);
                keyImage = mtNodeData.device.DeviceKeyImage;
            }
            else if (ProjectNodeType.DeviceGroupCommand == mtNodeData.nodeType && mtNodeData.deviceGroupCommand != null)
            {
                return;
            }
            else if (ProjectNodeType.DeviceCommand == mtNodeData.nodeType && mtNodeData.deviceCommand != null)
            {
                if (mtNodeData.deviceCommand.DeviceCommandFunctionCode <= 4)
                {
                    uscPropertyControl = new uscDeviceCommandRead(mtNodeData);
                    keyImage = mtNodeData.deviceCommand.DeviceCommandKeyImage;
                }
                else if (mtNodeData.deviceCommand.DeviceCommandFunctionCode >= 80 && mtNodeData.deviceCommand.DeviceCommandFunctionCode <= 96)
                {
                    uscPropertyControl = new uscDeviceCommandParametr(mtNodeData);
                    keyImage = mtNodeData.deviceCommand.DeviceCommandKeyImage;
                }
                else
                {

                }
            }
            else if (ProjectNodeType.DeviceGroupTag == mtNodeData.nodeType && mtNodeData.deviceGroupTag != null)
            {
                TreeNode selectNode = trvProject.SelectedNode;
                ProjectDeviceGroupTag projectDeviceGroupTag = mtNodeData.deviceGroupTag;
                if (projectDeviceGroupTag.DeviceTags == null)
                {
                    projectDeviceGroupTag.DeviceTags = new List<ProjectDeviceTag>();
                }
                projectDeviceGroupTag.DeviceTags.Clear();

                foreach (TreeNode tagNode in selectNode.Nodes)
                {
                    ProjectNodeData mtTagNodeData = (ProjectNodeData)tagNode.Tag;
                    ProjectDeviceTag projectDeviceTag = mtTagNodeData.deviceTag;
                    projectDeviceGroupTag.DeviceTags.Add(projectDeviceTag);
                }

                uscPropertyControl = new uscGroupTag(mtNodeData);
                keyImage = mtNodeData.deviceGroupTag.DeviceGroupTagKeyImage;
            }
            else if (ProjectNodeType.DeviceTag == mtNodeData.nodeType && mtNodeData.deviceTag != null)
            {
                uscPropertyControl = new uscTag(mtNodeData);
                keyImage = mtNodeData.deviceTag.DeviceTagKeyImage;
            }

            try
            {
                TabPage tabPageNew = new TabPage(trvProject.SelectedNode.Text);
                tabPageNew.Name = trvProject.SelectedNode.Text;
                tabPageNew.Text = trvProject.SelectedNode.Text;
                tabPageNew.ImageIndex = trvProject.SelectedNode.ImageIndex;
                tabPageNew.Controls.Add(uscPropertyControl);

                tabControl.ImageList = imgList;
                tabControl.TabPages.Add(tabPageNew);
                tabControl.SelectedTab = tabPageNew;
                tabPageNew.ImageKey = keyImage;
                uscPropertyControl.Show();
            }
            catch (System.ObjectDisposedException) { }
        }

        private void ValidateTabPage()
        {
            if (uscPropertyControl != null)
            {
                uscPropertyControl.Dispose();
            }

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabControl.Controls.Remove(tabPage);
            }
        }

        #endregion Selection of nodes and elements on the project 

        #region Timer
        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                tabControl.ImageList = imgList;

                TabPage selectedTab = tabControl.SelectedTab;
                tabControl.SelectedTab = selectedTab;

                TreeNode selectNode = trvProject.SelectedNode;
                if (selectNode == null)
                {
                    return;
                }
                else if (selectNode != null)
                {
                    mtNodeData = (ProjectNodeData)selectNode.Tag;

                    string keyImage = string.Empty;

                    if (ProjectNodeType.Channel == mtNodeData.nodeType)
                    {
                        keyImage = mtNodeData.channel.ChannelKeyImage;
                    }
                    else if (ProjectNodeType.Device == mtNodeData.nodeType)
                    {
                        keyImage = mtNodeData.device.DeviceKeyImage;
                    }
                    else if (ProjectNodeType.DeviceGroupCommand == mtNodeData.nodeType)
                    {
                        keyImage = mtNodeData.deviceGroupCommand.DeviceGroupCommandKeyImage;
                    }
                    else if (ProjectNodeType.DeviceCommand == mtNodeData.nodeType)
                    {
                        keyImage = mtNodeData.deviceCommand.DeviceCommandKeyImage;
                    }
                    else if (ProjectNodeType.DeviceGroupTag == mtNodeData.nodeType)
                    {
                        keyImage = mtNodeData.deviceGroupTag.DeviceGroupTagKeyImage;
                    }
                    else if (ProjectNodeType.DeviceTag == mtNodeData.nodeType)
                    {
                        keyImage = mtNodeData.deviceTag.DeviceTagKeyImage;
                    }

                    if (selectedTab != null)
                    {
                        if (selectedTab.ImageKey != keyImage)
                        {
                            selectedTab.ImageKey = keyImage;
                        }
                    }
                }
            }
            catch { }
        }

        #endregion Timer

    }
}
