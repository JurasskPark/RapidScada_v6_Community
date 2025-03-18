//using CommunicationMethods;
//using Scada.Comm.Config;
//using Scada.Comm.Devices;
//using Scada.Comm.Drivers.DrvIEC61107.View;
//using Scada.Forms;
//using Scada.Lang;
//using System.CodeDom.Compiler;
//using System.ComponentModel;
//using System.Globalization;
//using System.IO;
//using System.Threading.Channels;
//using System.Windows.Forms;
//using System.Xml;
//using DrvModbusCMForm.Control;
////using DrvModbusCM.ViewData;
//using static Scada.Comm.Drivers.DrvIEC61107.View.ListImages;
//using Scada.Data.Entities;
//using System.Xml.Linq;



//namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
//{
//    public partial class FrmConfigForm : Form
//    {

//        #region Project

//        /// <summary>
//        /// Project Node Data
//        /// </summary>
//        ProjectNodeData mtNodeData = new ProjectNodeData();
//        ProjectNodeData mtNodeDataPrevious = new ProjectNodeData();

//        TreeNode selectNodePrevious;
//        private bool SwitchingNewControlLock = false;
//        private bool modified = false;

//        /// <summary>
//        /// The application directories
//        /// </summary>
//        private AppDirs appDirs;
//        public AppDirs AppDirs
//        {
//            get { return appDirs; }
//            set { appDirs = value; }
//        }

//        /// <summary>
//        /// The directory with configuration files
//        /// </summary>
//        private string configDir;
//        public string ConfigDir
//        {
//            get { return configDir; }
//            set { configDir = value; }
//        }

//        /// <summary>
//        /// The communication line configuration
//        /// </summary>
//        private LineConfig lineConfig;
//        public LineConfig LineConfig
//        {
//            get { return lineConfig; }
//            set { lineConfig = value; }
//        }

//        /// <summary>
//        /// The device configuration
//        /// </summary>
//        private DeviceConfig deviceConfig;
//        public DeviceConfig DeviceConfig
//        {
//            get { return deviceConfig; }
//            set { deviceConfig = value; }
//        }


//        /// <summary>
//        /// The driver code
//        /// </summary>
//        private string driverCode;
//        public string DriverCode
//        {
//            get { return driverCode; }
//            set { driverCode = value; }
//        }

//        /// <summary>
//        /// The device number
//        /// </summary>
//        private int deviceNum;
//        public int DeviceNum
//        {
//            get { return deviceNum; }
//            set { deviceNum = value; }
//        }

//        private string projectPath;
//        public string ProjectPath
//        {
//            get { return projectPath; }
//            set { projectPath = value; }
//        }

//        private string projectFileName;
//        public string ProjectFileName
//        {
//            get { return projectFileName; }
//            set { projectFileName = value; }
//        }

//        private string projectFileNameFull;
//        public string ProjectFileNameFull
//        {
//            get { return projectFileNameFull; }
//            set { projectFileNameFull = value; }
//        }

//        #endregion Project

//        #region ProjectRuntime

//        /// <summary>
//        /// Project configuration
//        /// <para>Конфигурация проекта</para>
//        /// </summary>
//        public Project project = new Project();

//        /// <summary>
//        /// Channel
//        /// <para>Канал</para>
//        /// </summary>
//        private readonly ProjectChannel channel;
//        /// <summary>
//        /// Devices
//        /// <para>Устройства</para>
//        /// </summary>
//        public readonly List<ProjectDevice> devices;
//        /// <summary>
//        /// Commands Group
//        /// <para>Группа команд</para>
//        /// </summary>
//        private readonly List<ProjectGroupCommand> deviceGroupCommands;
//        /// <summary>
//        /// Command
//        /// <para>Команда</para>
//        /// </summary>
//        private readonly List<ProjectCommand> commands;
//        /// <summary>
//        /// Tags Group
//        /// <para>Группа тегов</para>
//        /// </summary>
//        private readonly List<ProjectGroupTag> groupTags;
//        /// <summary>
//        /// Tag
//        /// <para>Тег</para>
//        /// </summary>
//        private readonly List<ProjectTag> tags;
//        /// <summary>
//        /// Driver Tag
//        /// <para>Тег драйвера</para>
//        /// </summary>
//        private List<CnlPrototypeGroup> driverTags;
//        /// <summary>
//        /// List driver сlient
//        /// <para>Список клиентов</para>
//        /// </summary>
//        private readonly List<DriverClient> lstClient = new List<DriverClient>();
//        /// <summary>
//        /// Error counter
//        /// <para>Счетчик ошибок</para>
//        /// </summary>
//        private ushort countError;

//        #endregion

//        #region Project Xml
//        private const string XmlNodeTag = "NODE";
//        private const string XmlNodeTextAtt = "TEXT";
//        private const string XmlNodeTagAtt = "TAG";
//        private const string XmlNodeImageIndexAtt = "KEYIMAGE";
//        #endregion Project Xml

//        #region Displayed window
//        private UserControl uscPropertyControl = new UserControl();
//        private Form frmPropertyForm = new Form();
//        #endregion Displayed window

//        #region Variables
//        DriverClient driverClient;                                  // driver client
//        string errMsg;                                              // error message
//        string projectPath = string.Empty;                     // driver config path
//        string pathProject = string.Empty;                           // config path
//        bool isRussian;                                             // language
//        bool buttonStatus = false;                                  // status button
//        #endregion Variables

//        #region Form

//        //FrmViewData frmViewData = new FrmViewData();


//        #endregion Form

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public FrmConfigForm()
//        {
//            InitializeComponent();

//            try
//            {
//                this.AppDirs = appDirs ?? throw new ArgumentNullException(nameof(appDirs));
//                this.ConfigDir = appDirs.ConfigDir;
//                this.DeviceNum = deviceNum;

//                if (this.ConfigDir == null) { this.ConfigDir = Application.StartupPath; }

//                this.DriverCode = DriverUtils.DriverCode;
//                this.Text = DriverUtils.GetFileName(deviceNum);

//            }
//            catch { }
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public FrmConfigForm(AppDirs appDirs, int deviceNum, bool languageRussian = false)
//            : this()
//        {
//            try
//            {
//                this.AppDirs = appDirs ?? throw new ArgumentNullException(nameof(appDirs));
//                this.ConfigDir = appDirs.ConfigDir;
//                this.DeviceNum = deviceNum;
//                this.DriverCode = DriverUtils.DriverCode;
//                this.Text = DriverUtils.GetFileName(deviceNum);
//                this.isRussian = languageRussian;

//                FormProperties(appDirs.ConfigDir, deviceNum);
//            }
//            catch { }
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public FrmConfigForm(AppDirs appDirs, LineConfig lineConfig, DeviceConfig deviceConfig, int deviceNum, bool languageRussian = false) : this()
//        {
//            try
//            {
//                this.AppDirs = appDirs ?? throw new ArgumentNullException(nameof(appDirs));
//                this.LineConfig = lineConfig ?? throw new ArgumentNullException(nameof(lineConfig));
//                this.ConfigDir = appDirs.ConfigDir;
//                this.DeviceNum = deviceNum;
//                this.DriverCode = DriverUtils.DriverCode;
//                this.Text = DriverUtils.GetFileName(deviceNum);
//                this.isRussian = languageRussian;

//                FormProperties(appDirs.ConfigDir, deviceNum);
//            }
//            catch { }
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public FrmConfigForm(string configDriver, bool languageRussian = false) : this()
//        {
//            try
//            {
//                this.Opacity = 0.0;
//                this.Visible = false;
//                this.ShowInTaskbar = false;
//                this.isRussian = languageRussian;

//                this.projectPath = configDir;

//                FormProperties(configDriver, 0);
//            }
//            catch { }
//        }

//        #region Load Programm
//        private void FormProperties(string configDir, int deviceNum)
//        {
//            project = new Project();

//            // load configuration
//            if (deviceNum == 0)
//            {
//                this.projectPath = configDir;
//                if (!File.Exists(projectPath))
//                {
//                    ProjectSaveAs(projectPath);
//                    ProjectLoad(projectPath);
//                }
//                else
//                {
//                    ProjectLoad(projectPath);
//                }
//            }
//            else
//            {
//                this.projectPath = Path.Combine(configDir, DriverUtils.GetFileName(deviceNum));
//                if (!File.Exists(projectPath))
//                {
//                    ProjectSaveAs(projectPath);
//                    ProjectLoad(projectPath);
//                }
//                else
//                {
//                    ProjectLoad(projectPath);
//                }
//            }
//        }

//        public void LoadLanguage(string languageDir, bool IsRussian = false)
//        {
//            // load translate
//            this.isRussian = IsRussian;

//            string culture = "en-GB";
//            string EnglishCultureName = "en-GB";
//            string RussianCultureName = "ru-RU";
//            if (!IsRussian)
//            {
//                culture = EnglishCultureName;
//            }
//            else
//            {
//                culture = RussianCultureName;
//            }

//            string languageFile = Path.Combine(languageDir + $@"Lang\", DriverUtils.DriverCode + "." + culture + ".xml");
//            if (!File.Exists(languageFile))
//            {
//                MessageBox.Show(languageFile, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }

//            Locale.LoadDictionaries(languageFile, out string errMsg);
//            // load translate the form
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmConfig");
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmCmdRequest");
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmCommand");
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmDevice");
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmError");
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmInputBox");
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmSndRequest");
//            Locale.GetDictionary("Scada.Comm.Drivers.DrvIEC61107.View.FrmVariable");

//            DriverPhrases.Init();

//            if (errMsg != string.Empty)
//            {
//                MessageBox.Show(errMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void FrmConfigForm_Shown(object sender, EventArgs e)
//        {
//            ValidateLicense();

//            this.Opacity = 100.0;
//            this.Visible = true;
//            this.ShowInTaskbar = true;

//            // acrivate form
//            this.Activate();

//            trvProject.ExpandAll();
//        }

//        private void ValidateLicense()
//        {

//        }

//        private void FrmConfigForm_Load(object sender, EventArgs e)
//        {
//            // translate the form
//            FormTranslator.Translate(this, GetType().FullName);

//            // translate menu
//            //FormTranslator.Translate(cmnuGroupCmdRequestNode, GetType().FullName);
//            //FormTranslator.Translate(cmnuGroupSndRequestNode, GetType().FullName);
//            //FormTranslator.Translate(cmnuGroupCmdNode, GetType().FullName);
//            //FormTranslator.Translate(cmnuVariableNode, GetType().FullName);
//            //FormTranslator.Translate(cmnuVariableAction, GetType().FullName);

//            // phrases
//            DriverPhrases.Init();

//            // we give the default project configuration to treeview
//            #region config

//            if (trvProject.Nodes.Count == 0)
//            {
//                ProjectDefaultNew(DialogResult.No);
//            }

//            #endregion config

//            ConfigToControls();
//        }

//        #region Driver Config

//        /// <summary>
//        /// Sets the controls according to the configuration.
//        /// </summary>
//        private void ConfigToControls()
//        {
//            if (!File.Exists(projectPath))
//            {
//                if (this.appDirs != null)
//                {
//                    projectPath = Path.Combine(this.appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
//                }
//                else
//                {
//                    projectPath = DriverUtils.GetFileName(deviceNum);
//                }
//            }

//            ProjectLoad(projectPath);
//            project.Load(projectPath, out string errMsg);

//            if (errMsg != string.Empty)
//            {
//                MessageBox.Show(errMsg);
//            }

//        }

//        /// <summary>
//        /// Sets the configuration parameters according to the controls.
//        /// </summary>
//        private void ControlsToConfig()
//        {
//            if (!File.Exists(projectPath))
//            {
//                if (this.appDirs != null)
//                {
//                    projectPath = Path.Combine(this.appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
//                }
//                else
//                {
//                    projectPath = DriverUtils.GetFileName(deviceNum);
//                }
//            }

//            ProjectSaveAs(projectPath);
//        }

//        #endregion Driver Config

//        public void LoadProgramm(string fileName)
//        {
//            ProjectLoad(fileName);
//        }

//        #endregion Load Programm

//        #region ToolStrip Menu
//        private void tlsProjectNew_Click(object sender, EventArgs e)
//        {
//            ProjectDefaultNew(DialogResult.Yes);
//        }

//        private void tlsProjectOpen_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog openfileproject = new OpenFileDialog();
//            openfileproject.Filter = DriverPhrases.FilterProject;
//            if (openfileproject.ShowDialog() == DialogResult.OK)
//            {
//                ProjectFileNameFull = openfileproject.FileName;
//                ProjectLoad(ProjectFileNameFull);
//            }
//        }

//        private void tlsProjectSave_Click(object sender, EventArgs e)
//        {
//            ProjectSave();
//        }

//        private void tlsProjectSaveAs_Click(object sender, EventArgs e)
//        {
//            SaveFileDialog savefileproject = new SaveFileDialog();
//            savefileproject.Filter = DriverPhrases.FilterProject;
//            if (savefileproject.ShowDialog() == DialogResult.OK)
//            {
//                ProjectFileNameFull = savefileproject.FileName;
//                ProjectSaveAs(ProjectFileNameFull);
//            }
//        }

//        #endregion ToolStrip Menu

//        #region Context Menu
//        private void cmnuDeviceAdd_Click(object sender, EventArgs e)
//        {
//            ProjectDeviceAdd();
//        }

//        private void cmnuDeviceDel_Click(object sender, EventArgs e)
//        {
//            ProjectDeviceDelete();
//        }

//        private void cmnuCommandAdd_Click(object sender, EventArgs e)
//        {
//            switch (((ToolStripMenuItem)sender).Tag.ToString())
//            {
//                case "READCOILS":
//                    {
//                        ProjectCommandAdd(1);
//                        break;
//                    }
//                case "READINPUTS":
//                    {
//                        ProjectCommandAdd(2);
//                        break;
//                    }
//                case "READHOLDINGREGISTERS":
//                    {
//                        ProjectCommandAdd(3);
//                        break;
//                    }
//                case "READINPUTREGISTERS":
//                    {
//                        ProjectCommandAdd(4);
//                        break;
//                    }
//                case "WRITECOIL":
//                    {
//                        ProjectCommandAdd(5);
//                        break;
//                    }
//                case "WRITEHOLDINGREGISTER":
//                    {
//                        ProjectCommandAdd(6);
//                        break;
//                    }
//                case "WRITEMULTIPLECOILS":
//                    {
//                        ProjectCommandAdd(15);
//                        break;
//                    }
//                case "WRITEMULTIPLEHOLDINGREGISTERS":
//                    {
//                        ProjectCommandAdd(16);
//                        break;
//                    }
//                case "ARBITRARY":
//                    {
//                        ProjectCommandAdd(99);
//                        break;
//                    }
//                case "CALCULATORCONFIGURATION":
//                    {
//                        ProjectCommandAdd(80);
//                        break;
//                    }
//                case "VALUES81":
//                    {
//                        ProjectCommandAdd(81);
//                        break;
//                    }
//                case "VALUES82":
//                    {
//                        ProjectCommandAdd(82);
//                        break;
//                    }
//                case "VALUES83":
//                    {
//                        ProjectCommandAdd(83);
//                        break;
//                    }
//                case "ARCHIVEVALUES84":
//                    {
//                        ProjectCommandAdd(84);
//                        break;
//                    }
//                case "ARCHIVEVALUES85":
//                    {
//                        ProjectCommandAdd(85);
//                        break;
//                    }
//                case "ARCHIVEVALUES86":
//                    {
//                        ProjectCommandAdd(86);
//                        break;
//                    }
//                case "ARCHIVESITUATIONS":
//                    {
//                        ProjectCommandAdd(87);
//                        break;
//                    }
//                case "TOTALVOLUME":
//                    {
//                        ProjectCommandAdd(88);
//                        break;
//                    }
//                case "ARCHIVE100POWERBREAKS":
//                    {
//                        ProjectCommandAdd(90);
//                        break;
//                    }
//                case "ARCHIVE450EMERGENCYSITUATIONS":
//                    {
//                        ProjectCommandAdd(91);
//                        break;
//                    }
//                case "CALCULATORCONFIGURATION95":
//                    {
//                        ProjectCommandAdd(95);
//                        break;
//                    }
//                case "ENTERINGPARAMETERS":
//                    {
//                        ProjectCommandAdd(96);
//                        break;
//                    }
//            }
//        }

//        private void cmnuCommandUp_Click(object sender, EventArgs e)
//        {
//            ProjectNodeElementUp();
//        }

//        private void cmnuCommandDown_Click(object sender, EventArgs e)
//        {
//            ProjectNodeElementDown();
//        }


//        private void cmnuCommandDel_Click(object sender, EventArgs e)
//        {
//            ProjectCommandDelete();
//        }

//        private void cmnuDeviceTagAdd_Click(object sender, EventArgs e)
//        {
//            ProjectTagAdd();
//        }

//        private void cmnuDeviceTagDel_Click(object sender, EventArgs e)
//        {
//            ProjectTagDelete();
//        }

//        #endregion Context Menu

//        #region Project

//        private void ProjectDefaultNew(DialogResult dialog)
//        {
//            if (dialog == DialogResult.Yes)
//            {
//                DialogResult dialogResult = MessageBox.Show(DriverPhrases.QuestionNewProjectMsg, DriverPhrases.QuestionNewProjectTitle, MessageBoxButtons.YesNo);
//                if (dialogResult == DialogResult.Yes)
//                {
//                    ProjectNew();
//                }
//            }

//            if (dialog == DialogResult.No)
//            {
//                ProjectNew();
//            }
//        }

//        private void ProjectNew()
//        {
//            //Проверка вкладок
//            //ValidateTabPage();
//            //Убираем имя проекта и путь до него
//            ProjectFileName = "";
//            ProjectPath = "";
//            //Создаем новый проект с настройками по умолчанию
//            project = new Project();
//            //Очищаем проект
//            trvProject.Nodes.Clear();
//            //Добавляем ноды по умолчанию
//            GetDefaultTreeNodes();
//        }

//        private void ProjectLoad(string fileName)
//        {
//            if (File.Exists(fileName))
//            {
//                DeserializeTreeView(trvProject, fileName);
//            }
//        }

//        public void DeserializeTreeView(System.Windows.Forms.TreeView treeView, string fileName)
//        {
//            treeView.Nodes.Clear();


//            #region

//            //XmlTextReader reader = null;
//            //try
//            //{
//            //    // disabling re-drawing of treeview till all nodes are added
//            //    treeView.BeginUpdate();
//            //    reader = new XmlTextReader(fileName);
//            //    TreeNode parentNode = null;
//            //    while (reader.Read())
//            //    {
//            //        if (reader.NodeType == XmlNodeType.Element)
//            //        {
//            //            if (reader.Name == XmlNodeTag)
//            //            {
//            //                TreeNode newNode = new TreeNode();
//            //                bool isEmptyElement = reader.IsEmptyElement;

//            //                // loading node attributes
//            //                int attributeCount = reader.AttributeCount;

//            //                if (attributeCount > 0)
//            //                {
//            //                    Dictionary<string, string> attributes = new Dictionary<string, string>();
//            //                    string newNodeName = string.Empty;
//            //                    string newNodeImageKey = string.Empty;
//            //                    string newNodeType = string.Empty;

//            //                    for (int i = 0; i < attributeCount; i++)
//            //                    {
//            //                        reader.MoveToAttribute(i);
//            //                        attributes.Add(reader.Name, reader.Value);
//            //                    }

//            //                    newNodeName = attributes[XmlNodeTextAtt];
//            //                    if (attributes.TryGetValue(XmlNodeTextAtt, out string attributesValue1))
//            //                    {
//            //                        newNodeName = attributes[XmlNodeTextAtt];
//            //                    }

//            //                    newNodeImageKey = attributes[XmlNodeImageIndexAtt];
//            //                    if (attributes.TryGetValue(XmlNodeImageIndexAtt, out string attributesValue2))
//            //                    {
//            //                        newNodeImageKey = attributes[XmlNodeImageIndexAtt];
//            //                    }

//            //                    if (attributes.TryGetValue(XmlNodeTagAtt, out string attributesValue3))
//            //                    {
//            //                        newNodeType = attributes[XmlNodeTagAtt];
//            //                    }

//            //                    ProjectNodeData projectNodeData = new ProjectNodeData();

//            //                    switch (newNodeType)
//            //                    {
//            //                        case "CHANNEL":
//            //                            #region Channel
//            //                            ProjectChannel projectChannel = new ProjectChannel();

//            //                            try { projectChannel.KeyImage = attributes["KEYIMAGE"]; } catch { }
//            //                            try { projectChannel.ID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
//            //                            try { projectChannel.Name = attributes["NAME"]; } catch { }
//            //                            try { projectChannel.Description = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectChannel.Enabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
//            //                            try { projectChannel.Type = Convert.ToInt32(attributes["TYPE"]); } catch { }
//            //                            try { projectChannel.GatewayTypeProtocol = Convert.ToInt32(attributes["GATEWAY"]); } catch { }
//            //                            try { projectChannel.GatewayPort = Convert.ToInt32(attributes["GATEWAYPORT"]); } catch { }
//            //                            try { projectChannel.GatewayConnectedClientsMax = Convert.ToInt32(attributes["CONNECTEDCLIENTSMAX"]); } catch { }

//            //                            try { projectChannel.WriteTimeout = Convert.ToInt32(attributes["WRITETIMEOUT"]); } catch { }
//            //                            try { projectChannel.ReadTimeout = Convert.ToInt32(attributes["READTIMEOUT"]); } catch { }
//            //                            try { projectChannel.Timeout = Convert.ToInt32(attributes["TIMEOUT"]); } catch { }

//            //                            try { projectChannel.WriteBufferSize = Convert.ToInt32(attributes["WRITEBUFFERSIZE"]); } catch { }
//            //                            try { projectChannel.ReadBufferSize = Convert.ToInt32(attributes["READBUFFERSIZE"]); } catch { }

//            //                            try { projectChannel.CountError = Convert.ToInt32(attributes["COUNTERROR"]); } catch { }

//            //                            if (Convert.ToInt32(attributes["TYPE"]) == 1) //Последовательный порт
//            //                            {
//            //                                try { projectChannel.SerialPortName = attributes["SERIALPORTNAME"]; } catch { }
//            //                                try { projectChannel.SerialPortBaudRate = attributes["SERIALPORTBAUDRATE"]; } catch { }
//            //                                try { projectChannel.SerialPortDataBits = attributes["SERIALPORTDATABITS"]; } catch { }
//            //                                try { projectChannel.SerialPortParity = attributes["SERIALPORTPARITY"]; } catch { }
//            //                                try { projectChannel.SerialPortStopBits = attributes["SERIALPORTSTOPBITS"]; } catch { }

//            //                                try { projectChannel.SerialPortHandshake = attributes["HANDSHAKE"]; } catch { }
//            //                                try { projectChannel.SerialPortDtrEnable = Convert.ToBoolean(attributes["DTR"]); } catch { }
//            //                                try { projectChannel.SerialPortRtsEnable = Convert.ToBoolean(attributes["RTS"]); } catch { }
//            //                                try { projectChannel.SerialPortReceivedBytesThreshold = Convert.ToInt32(attributes["RECEIVEDBYTESTHRESHOLD"]); } catch { }
//            //                            }

//            //                            if (Convert.ToInt32(attributes["TYPE"]) == 2 || Convert.ToInt32(attributes["TYPE"]) == 3) // TCP UDP клиент
//            //                            {
//            //                                try { projectChannel.ClientHost = attributes["CLIENTHOST"]; } catch { }
//            //                                try { projectChannel.ClientPort = Convert.ToInt32(attributes["CLIENTPORT"]); } catch { }
//            //                            }

//            //                            try { projectChannel.Debug = Convert.ToBoolean(attributes["DEBUG"]); } catch { }

//            //                            projectNodeData.channel = projectChannel;
//            //                            projectNodeData.nodeType = ProjectNodeType.Channel;

//            //                            newNode.Tag = projectNodeData;
//            //                            #endregion Channel
//            //                            break;
//            //                        case "DEVICE":
//            //                            #region Device
//            //                            ProjectDevice projectDevice = new ProjectDevice();

//            //                            try { projectDevice.KeyImage = attributes["KEYIMAGE"]; } catch { }
//            //                            try { projectDevice.ParentID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
//            //                            try { projectDevice.ID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
//            //                            try { projectDevice.Address = Convert.ToUInt16(attributes["ADDRESS"]); } catch { }
//            //                            try { projectDevice.Name = attributes["NAME"]; } catch { }
//            //                            try { projectDevice.Description = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectDevice.Enabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
//            //                            try { projectDevice.DeviceRegistersBytes = Convert.ToInt32(attributes["REGISTERSBYTES"]); } catch { }
//            //                            try { projectDevice.DeviceGatewayRegistersBytes = Convert.ToInt32(attributes["GATEWAYREGISTERSBYTES"]); } catch { }

//            //                            try { projectDevice.Status = Convert.ToInt32(attributes["STATUS"]); } catch { }
//            //                            try { projectDevice.PollingOnScheduleStatus = Convert.ToBoolean(attributes["POLLINGONSCHEDULESTATUS"]); } catch { }
//            //                            try { projectDevice.IntervalPool = Convert.ToInt32(attributes["INTERVALPOOL"]); } catch { }
//            //                            try { projectDevice.TypeProtocol = Convert.ToInt32(attributes["TYPEPROTOCOL"]); } catch { }

//            //                            try { projectDevice.DateTimeLastSuccessfully = DateTime.Parse(attributes["DATETIMELASTSUCCESSFULLY"]); } catch { }
//            //                            try
//            //                            {
//            //                                // creating a buffer
//            //                                // adding Registers 65535
//            //                                for (ulong index = 0; index < (ulong)65535; ++index)
//            //                                {
//            //                                    bool status = false;
//            //                                    ulong value = 0;

//            //                                    projectDevice.SetCoil(Convert.ToUInt64(index), status);
//            //                                    projectDevice.SetDiscreteInput(Convert.ToUInt64(index), status);
//            //                                    projectDevice.SetHoldingRegister(Convert.ToUInt64(index), value);
//            //                                    projectDevice.SetInputRegister(Convert.ToUInt64(index), value);
//            //                                }

//            //                                for (ulong index = 0; index < (ulong)9999999; ++index)
//            //                                {
//            //                                    string value = string.Empty;
//            //                                    projectDevice.SetDataBuffer(Convert.ToUInt64(index), value);
//            //                                }
//            //                            }
//            //                            catch { }

//            //                            // fill in the registers by the name of the attribute and its value from the dictionary of Attribute registers 65535
//            //                            foreach (string key in attributes.Keys)
//            //                            {
//            //                                if (key.Contains("COILREGISTER"))
//            //                                {
//            //                                    try
//            //                                    {
//            //                                        bool Coil = Convert.ToBoolean(attributes[key]);
//            //                                        ulong RegAddr = Convert.ToUInt64(key.Replace("COILREGISTER", ""));
//            //                                        projectDevice.SetCoil(RegAddr, Coil);
//            //                                    }
//            //                                    catch { }
//            //                                }
//            //                                else if (key.Contains("DISCRETEINPUT"))
//            //                                {
//            //                                    try
//            //                                    {
//            //                                        bool DiscreteInput = Convert.ToBoolean(attributes[key]);
//            //                                        ulong RegAddr = Convert.ToUInt64(key.Replace("DISCRETEINPUT", ""));
//            //                                        projectDevice.SetDiscreteInput(RegAddr, DiscreteInput);
//            //                                    }
//            //                                    catch { }
//            //                                }
//            //                                else if (key.Contains("HOLDINGREGISTER"))
//            //                                {
//            //                                    try
//            //                                    {
//            //                                        ulong HoldingRegister = Convert.ToUInt64(attributes[key]);
//            //                                        ulong RegAddr = Convert.ToUInt64(key.Replace("HOLDINGREGISTER", ""));
//            //                                        projectDevice.SetHoldingRegister(RegAddr, HoldingRegister);
//            //                                    }
//            //                                    catch { }
//            //                                }
//            //                                else if (key.Contains("INPUTREGISTER"))
//            //                                {
//            //                                    try
//            //                                    {
//            //                                        ulong InputRegister = Convert.ToUInt16(Convert.ToInt64(attributes[key]));
//            //                                        ulong RegAddr = Convert.ToUInt64(key.Replace("INPUTREGISTER", ""));
//            //                                        projectDevice.SetInputRegister(RegAddr, InputRegister);
//            //                                    }
//            //                                    catch { }
//            //                                }
//            //                            }

//            //                            projectNodeData.device = projectDevice;
//            //                            projectNodeData.nodeType = ProjectNodeType.Device;

//            //                            newNode.Tag = projectNodeData;
//            //                            #endregion Device
//            //                            break;
//            //                        case "GROUPCOMMAND":
//            //                            #region Device Group Command
//            //                            ProjectGroupCommand projectGroupCommand = new ProjectGroupCommand();

//            //                            try { projectGroupCommand.KeyImage = attributes["KEYIMAGE"]; } catch { }
//            //                            try { projectGroupCommand.ParentID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
//            //                            try { projectGroupCommand.ID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
//            //                            try { projectGroupCommand.GroupCommandName = attributes["NAME"]; } catch { }
//            //                            try { projectGroupCommand.GroupCommandDescription = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectGroupCommand.GroupCommandDescription = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectGroupCommand.GroupCommandEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

//            //                            projectNodeData.groupCommand = projectGroupCommand;
//            //                            projectNodeData.nodeType = ProjectNodeType.GroupCommand;

//            //                            newNode.Tag = projectNodeData;
//            //                            #endregion Device Group Command
//            //                            break;
//            //                        case "COMMAND":
//            //                            #region Device
//            //                            ProjectCommand projectCommand = new ProjectCommand();

//            //                            //try { projectCommand.DeviceID = DriverUtils.StringToGuid(attributes["IDDEVICE"]); } catch { }
//            //                            try { projectCommand.KeyImage = attributes["KEYIMAGE"]; } catch { }
//            //                            try { projectCommand.ParentID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
//            //                            try { projectCommand.ID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
//            //                            try { projectCommand.CommandName = attributes["NAME"]; } catch { }
//            //                            try { projectCommand.CommandDescription = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectCommand.CommandEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
//            //                            try { projectCommand.CommandFunctionCode = Convert.ToUInt16(attributes["FUNCTION"]); } catch { }
//            //                            try { projectCommand.CommandRegisterStartAddress = Convert.ToUInt16(attributes["REGISTERSTARTADDRESS"]); } catch { }
//            //                            try { projectCommand.CommandRegisterCount = Convert.ToUInt16(attributes["REGISTERCOUNT"]); } catch { }
//            //                            try { projectCommand.CommandParametr = Convert.ToUInt16(attributes["REGISTERPARAMETR"]); } catch { }
//            //                            try { projectCommand.CommandCurrentValue = Convert.ToBoolean(attributes["CURRENTVALUE"]); } catch { }

//            //                            try { projectCommand.CommandRegisterNameReadData = attributes["REGISTERNAMEREADDATA"].Split(' '); } catch { }
//            //                            try { projectCommand.CommandRegisterReadData = Array.ConvertAll(attributes["REGISTERREADDATA"].Split(' '), x => { ulong res = Convert.ToUInt64(x); return res; }); } catch { }

//            //                            try { projectCommand.CommandRegisterNameWriteData = attributes["REGISTERNAMEWRITEDATA"].Split(' '); } catch { }
//            //                            try { projectCommand.CommandRegisterWriteData = Array.ConvertAll(attributes["REGISTERWRITEDATA"].Split(' '), x => { ulong res = Convert.ToUInt64(x); return res; }); } catch { }

//            //                            projectNodeData.command = projectCommand;
//            //                            projectNodeData.nodeType = ProjectNodeType.Command;

//            //                            newNode.Tag = projectNodeData;

//            //                            #endregion Device
//            //                            break;
//            //                        case "GROUPTAG":
//            //                            #region Device Group Tag
//            //                            ProjectGroupTag projectGroupTag = new ProjectGroupTag();

//            //                            try { projectGroupTag.KeyImage = attributes["KEYIMAGE"]; } catch { }
//            //                            try { projectGroupTag.ParentID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
//            //                            try { projectGroupTag.ID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
//            //                            try { projectGroupTag.GroupTagName = attributes["NAME"]; } catch { }
//            //                            try { projectGroupTag.DeviceGroupTagDescription = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectGroupTag.DeviceGroupTagDescription = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectGroupTag.DeviceGroupTagEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

//            //                            projectNodeData.groupTag = projectGroupTag;
//            //                            projectNodeData.nodeType = ProjectNodeType.DeviceGroupTag;

//            //                            newNode.Tag = projectNodeData;

//            //                            #endregion Device Group Tag
//            //                            break;
//            //                        case "TAG":
//            //                            #region Device Tag
//            //                            ProjectTag projectTag = new ProjectTag();

//            //                            try { projectTag.KeyImage = attributes["KEYIMAGE"]; } catch { }
//            //                            try { projectTag.DeviceID = DriverUtils.StringToGuid(attributes["DEVICEID"]); } catch { }
//            //                            try { projectTag.DeviceGroupTagID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
//            //                            try { projectTag.DeviceTagID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
//            //                            try { projectTag.DeviceTagCommandID = DriverUtils.StringToGuid(attributes["COMMANDID"]); } catch { }
//            //                            try { projectTag.DeviceTagEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
//            //                            try { projectTag.DeviceTagAddress = attributes["ADDRESS"]; } catch { }
//            //                            try { projectTag.DeviceTagName = attributes["NAME"]; } catch { }
//            //                            try { projectTag.DeviceTagCode = attributes["CODE"]; } catch { }
//            //                            try { projectTag.DeviceTagDescription = attributes["DESCRIPTION"]; } catch { }
//            //                            try { projectTag.DeviceTagCoefficient = Convert.ToSingle(attributes["COEFFICIENT"]); } catch { }
//            //                            try { projectTag.DeviceTagSorting = attributes["SORTING"]; } catch { }

//            //                            try { projectTag.DeviceTagScaled = Convert.ToInt32(attributes["SCALED"]); } catch { }
//            //                            try { projectTag.DeviceTagScaledHigh = Convert.ToSingle(attributes["SCALEDHIGH"]); } catch { }
//            //                            try { projectTag.DeviceTagScaledLow = Convert.ToSingle(attributes["SCALEDLOW"]); } catch { }
//            //                            try { projectTag.DeviceTagRowHigh = Convert.ToSingle(attributes["ROWHIGH"]); } catch { }
//            //                            try { projectTag.DeviceTagRowLow = Convert.ToSingle(attributes["ROWLOW"]); } catch { }

//            //                            try
//            //                            {
//            //                                ProjectTag.DeviceTagFormatData Type = (ProjectTag.DeviceTagFormatData)Enum.Parse(typeof(ProjectTag.DeviceTagFormatData), attributes["TYPE"]);
//            //                                projectTag.DeviceTagType = Type;
//            //                            }
//            //                            catch { }

//            //                            projectNodeData.tag = projectTag;
//            //                            projectNodeData.nodeType = ProjectNodeType.DeviceTag;

//            //                            newNode.Tag = projectNodeData;
//            //                            #endregion Device Tag
//            //                            break;
//            //                        default:
//            //                            newNode.Tag = projectNodeData;
//            //                            break;
//            //                    }

//            //                    newNode.Text = newNodeName;
//            //                    newNode.ImageKey = newNodeImageKey;
                                
//            //                }

//            //                // add new node to Parent Node or TreeView
//            //                if (parentNode != null)
//            //                {
//            //                    parentNode.Nodes.Add(newNode);
//            //                }
//            //                else
//            //                {
//            //                    treeView.Nodes.Add(newNode);
//            //                }

//            //                // making current node 'ParentNode' if its not empty
//            //                if (!isEmptyElement)
//            //                {
//            //                    parentNode = newNode;
//            //                }
//            //            }
//            //        }
//            //        // moving up to in TreeView if end tag is encountered
//            //        else if (reader.NodeType == XmlNodeType.EndElement)
//            //        {
//            //            if (reader.Name == XmlNodeTag)
//            //            {
//            //                parentNode = parentNode.Parent;
//            //            }
//            //        }
//            //        else if (reader.NodeType == XmlNodeType.XmlDeclaration)
//            //        {
//            //            //Ignore Xml Declaration                    
//            //        }
//            //        else if (reader.NodeType == XmlNodeType.None)
//            //        {
//            //            return;
//            //        }
//            //        else if (reader.NodeType == XmlNodeType.Text)
//            //        {
//            //            parentNode.Nodes.Add(reader.Value);
//            //        }

//            //    }
//            //}
//            //finally
//            //{
//            //    // enabling redrawing of treeview after all nodes are added
//            //    treeView.EndUpdate();
//            //    reader.Close();
//            //}

//            #endregion
//        }

//        private void ProjectSave()
//        {
//            if (String.IsNullOrEmpty(projectPath))
//            {
//                if (appDirs != null)
//                {
//                    projectPath = Path.Combine(appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
//                }
//                else
//                {
//                    projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DriverUtils.GetFileName(deviceNum));
//                }
//            }

//            SerializeTreeView(trvProject, projectPath);

//            SaveDebug(projectPath);
//        }

//        public void ProjectSaveAs(string projectPath)
//        {
//            if (String.IsNullOrEmpty(projectPath))
//            {
//                if (appDirs != null)
//                {
//                    projectPath = Path.Combine(appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
//                }
//                else
//                {
//                    projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DriverUtils.GetFileName(deviceNum));
//                }
//            }

//            SerializeTreeView(trvProject, projectPath);

//            SaveDebug(projectPath);
//        }

//        public void SerializeTreeView(System.Windows.Forms.TreeView treeView, string fileName)
//        {
//            //XmlTextWriter textWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
//            //// writing the xml declaration tag
//            //textWriter.WriteStartDocument();
//            ////textWriter.WriteRaw("\r\n");
//            //// writing the main tag that encloses all node tags
//            //textWriter.WriteStartElement(DriverUtils.DriverCode);

//            //// save the nodes, recursive method
//            //SaveNodes(treeView.Nodes, textWriter);

//            //textWriter.WriteEndElement();
//            //textWriter.Close();
//        }

//        //private void SaveNodes(TreeNodeCollection nodesCollection, XmlTextWriter textWriter)
//        //{
//        //    for (int i = 0; i < nodesCollection.Count; i++)
//        //    {
//        //        TreeNode node = nodesCollection[i];
//        //        ProjectNodeData prNodeData = (ProjectNodeData)node.Tag;

//        //        textWriter.WriteStartElement(XmlNodeTag);
//        //        textWriter.WriteAttributeString(XmlNodeTextAtt, node.Text);
//        //        textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageKey.ToString());


//        //        if (node.Tag != null)
//        //        {
//        //            #region Channel
//        //            // channel
//        //            if (prNodeData.nodeType == ProjectNodeType.Channel)
//        //            {
//        //                try { textWriter.WriteAttributeString(XmlNodeTagAtt, "CHANNEL"); } catch { }

//        //                try { textWriter.WriteAttributeString("ID", prNodeData.channel.ID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("NAME", prNodeData.channel.Name); } catch { }
//        //                try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.channel.Description); } catch { }
//        //                try { textWriter.WriteAttributeString("ENABLED", prNodeData.channel.Enabled.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("TYPE", prNodeData.channel.Type.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("GATEWAY", prNodeData.channel.GatewayTypeProtocol.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("GATEWAYPORT", prNodeData.channel.GatewayPort.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("CONNECTEDCLIENTSMAX", prNodeData.channel.GatewayConnectedClientsMax.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("WRITETIMEOUT", prNodeData.channel.WriteTimeout.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("READTIMEOUT", prNodeData.channel.ReadTimeout.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("TIMEOUT", prNodeData.channel.Timeout.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("WRITEBUFFERSIZE", prNodeData.channel.WriteBufferSize.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("READBUFFERSIZE", prNodeData.channel.ReadBufferSize.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("COUNTERROR", prNodeData.channel.CountError.ToString()); } catch { }

//        //                if (prNodeData.channel.Type == 1) //Последовательный порт
//        //                {
//        //                    try { textWriter.WriteAttributeString("SERIALPORTNAME", prNodeData.channel.SerialPortName); } catch { }
//        //                    try { textWriter.WriteAttributeString("SERIALPORTBAUDRATE", prNodeData.channel.SerialPortBaudRate); } catch { }
//        //                    try { textWriter.WriteAttributeString("SERIALPORTDATABITS", prNodeData.channel.SerialPortDataBits); } catch { }
//        //                    try { textWriter.WriteAttributeString("SERIALPORTPARITY", prNodeData.channel.SerialPortParity); } catch { }
//        //                    try { textWriter.WriteAttributeString("SERIALPORTSTOPBITS", prNodeData.channel.SerialPortStopBits); } catch { }

//        //                    try { textWriter.WriteAttributeString("HANDSHAKE", prNodeData.channel.SerialPortHandshake); } catch { }
//        //                    try { textWriter.WriteAttributeString("DTR", prNodeData.channel.SerialPortDtrEnable.ToString()); } catch { }
//        //                    try { textWriter.WriteAttributeString("RTS", prNodeData.channel.SerialPortRtsEnable.ToString()); } catch { }
//        //                    try { textWriter.WriteAttributeString("RECEIVEDBYTESTHRESHOLD", prNodeData.channel.SerialPortReceivedBytesThreshold.ToString()); } catch { }
//        //                }

//        //                if (prNodeData.channel.Type == 2 || prNodeData.channel.Type == 3) //TCP UDP клиент
//        //                {
//        //                    try { textWriter.WriteAttributeString("CLIENTHOST", prNodeData.channel.ClientHost); } catch { }
//        //                    try { textWriter.WriteAttributeString("CLIENTPORT", prNodeData.channel.ClientPort.ToString()); } catch { }
//        //                }

//        //                try { textWriter.WriteAttributeString("DEBUG", prNodeData.channel.Debug.ToString()); } catch { }
//        //            }
//        //            #endregion Channel

//        //            #region Device
//        //            // device
//        //            if (prNodeData.nodeType == ProjectNodeType.Device)
//        //            {
//        //                try { textWriter.WriteAttributeString(XmlNodeTagAtt, "DEVICE"); } catch { }

//        //                try { textWriter.WriteAttributeString("IDPARENT", prNodeData.device.ID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ID", prNodeData.device.ID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ADDRESS", prNodeData.device.Address.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("NAME", prNodeData.device.Name); } catch { }
//        //                try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.device.Description); } catch { }
//        //                try { textWriter.WriteAttributeString("ENABLED", prNodeData.device.Enabled.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("REGISTERSBYTES", prNodeData.device.DeviceRegistersBytes.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("GATEWAYREGISTERSBYTES", prNodeData.device.DeviceGatewayRegistersBytes.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("STATUS", prNodeData.device.Status.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("POLLINGONSCHEDULESTATUS", prNodeData.device.PollingOnScheduleStatus.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("INTERVALPOOL", prNodeData.device.IntervalPool.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("TYPEPROTOCOL", prNodeData.device.TypeProtocol.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("DATETIMELASTSUCCESSFULLY", prNodeData.device.DateTimeLastSuccessfully.ToString()); } catch { }

//        //                #region Buffer
//        //                for (int index = 0; index < 65535; ++index)
//        //                {
//        //                    //Coils
//        //                    if (prNodeData.device.CoilsExists(Convert.ToUInt16(index)))
//        //                    {
//        //                        string TextCoilsID = (index).ToString();
//        //                        string TextCoilsWord = prNodeData.device.GetBooleanCoil(Convert.ToUInt64(index)).ToString();

//        //                        if (TextCoilsWord != "False")
//        //                        {
//        //                            try { textWriter.WriteAttributeString("COILREGISTER" + TextCoilsID, TextCoilsWord); } catch { }
//        //                        }
//        //                    }

//        //                    //DiscreteInputs
//        //                    if (prNodeData.device.DiscreteInputsExists(Convert.ToUInt16(index)))
//        //                    {
//        //                        string TextDiscreteInputsID = (index).ToString();
//        //                        string TextDiscreteInputsWord = prNodeData.device.GetBooleanDiscreteInput(Convert.ToUInt64(index)).ToString();

//        //                        if (TextDiscreteInputsWord != "False")
//        //                        {
//        //                            try { textWriter.WriteAttributeString("DISCRETEINPUT" + TextDiscreteInputsID, TextDiscreteInputsWord); } catch { }
//        //                        }
//        //                    }

//        //                    //HoldingRegisters
//        //                    if (prNodeData.device.HoldingRegistersExists(Convert.ToUInt16(index)))
//        //                    {
//        //                        string TextHoldingID = (index).ToString();
//        //                        string TextHoldingWord = prNodeData.device.GetUlongHoldingRegister(Convert.ToUInt64(index)).ToString();

//        //                        if (TextHoldingWord != "0")
//        //                        {
//        //                            try { textWriter.WriteAttributeString("HOLDINGREGISTER" + TextHoldingID, TextHoldingWord); } catch { }
//        //                        }
//        //                    }

//        //                    //InputRegisters
//        //                    if (prNodeData.device.InputRegistersExists(Convert.ToUInt16(index)))
//        //                    {
//        //                        string TextInputID = (index).ToString();
//        //                        string TextInputWord = prNodeData.device.GetUlongInputRegister(Convert.ToUInt64(index)).ToString();

//        //                        if (TextInputWord != "0")
//        //                        {
//        //                            try { textWriter.WriteAttributeString("INPUTREGISTER" + TextInputID, TextInputWord); } catch { }
//        //                        }
//        //                    }
//        //                }
//        //                #endregion Buffer

//        //            }
//        //            #endregion Device

//        //            #region Device Group Command

//        //            if (prNodeData.nodeType == ProjectNodeType.GroupCommand)
//        //            {
//        //                try { textWriter.WriteAttributeString(XmlNodeTagAtt, "GROUPCOMMAND"); } catch { }

//        //                try { textWriter.WriteAttributeString("IDPARENT", prNodeData.groupCommand.ParentID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ID", prNodeData.groupCommand.ID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("NAME", prNodeData.groupCommand.GroupCommandName); } catch { }
//        //                try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.groupCommand.GroupCommandDescription); } catch { }
//        //                try { textWriter.WriteAttributeString("ENABLED", prNodeData.groupCommand.GroupCommandEnabled.ToString()); } catch { }
//        //            }

//        //            #endregion Device Group Command

//        //            #region Device Command

//        //            if (prNodeData.nodeType == ProjectNodeType.Command)
//        //            {
//        //                try { textWriter.WriteAttributeString(XmlNodeTagAtt, "COMMAND"); } catch { }

//        //                //try { textWriter.WriteAttributeString("IDDEVICE", prNodeData.command.DeviceID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("IDPARENT", prNodeData.command.ParentID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ID", prNodeData.command.ID.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("NAME", prNodeData.command.CommandName); } catch { }
//        //                try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.command.CommandDescription); } catch { }
//        //                try { textWriter.WriteAttributeString("ENABLED", prNodeData.command.CommandEnabled.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("FUNCTION", prNodeData.command.CommandFunctionCode.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("REGISTERSTARTADDRESS", prNodeData.command.CommandRegisterStartAddress.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("REGISTERCOUNT", prNodeData.command.CommandRegisterCount.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("REGISTERPARAMETR", prNodeData.command.CommandParametr.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("CURRENTVALUE", prNodeData.command.CommandCurrentValue.ToString()); } catch { }

//        //                try
//        //                {
//        //                    string[] commandRegisterReadName = prNodeData.command.CommandRegisterNameReadData;
//        //                    textWriter.WriteAttributeString("REGISTERNAMEREADDATA", String.Join(" ", commandRegisterReadName));
//        //                }
//        //                catch { }

//        //                try
//        //                {
//        //                    ulong[] commandRegisterReadData = prNodeData.command.CommandRegisterReadData;
//        //                    string[] strCommandRegisterReadData = Array.ConvertAll(commandRegisterReadData, x => { string res = x.ToString(); return res; });
//        //                    textWriter.WriteAttributeString("REGISTERREADDATA", String.Join(" ", strCommandRegisterReadData));
//        //                }
//        //                catch { }

//        //                try
//        //                {
//        //                    string[] CommandRegisterWriteName = prNodeData.command.CommandRegisterNameWriteData;
//        //                    textWriter.WriteAttributeString("REGISTERNAMEWRITEDATA", String.Join(" ", CommandRegisterWriteName));
//        //                }
//        //                catch { }

//        //                try
//        //                {
//        //                    ulong[] CommandRegisterWriteData = prNodeData.command.CommandRegisterWriteData;
//        //                    string[] str_tmp_CommandRegisterWriteData = Array.ConvertAll(CommandRegisterWriteData, x => { string res = x.ToString(); return res; });
//        //                    textWriter.WriteAttributeString("REGISTERWRITEDATA", String.Join(" ", str_tmp_CommandRegisterWriteData));
//        //                }
//        //                catch { }
//        //            }

//        //            #endregion Device Command

//        //            #region Device Group Tag

//        //            if (prNodeData.nodeType == ProjectNodeType.DeviceGroupTag)
//        //            {
//        //                try { textWriter.WriteAttributeString(XmlNodeTagAtt, "GROUPTAG"); } catch { }

//        //                try { textWriter.WriteAttributeString("IDPARENT", prNodeData.groupTag.ParentID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ID", prNodeData.groupTag.ID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("NAME", prNodeData.groupTag.GroupTagName); } catch { }
//        //                try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.groupTag.DeviceGroupTagDescription); } catch { }
//        //                try { textWriter.WriteAttributeString("ENABLED", prNodeData.groupTag.DeviceGroupTagEnabled.ToString()); } catch { }

//        //            }

//        //            #endregion Device Group Tag

//        //            #region Device Tag
//        //            if (prNodeData.nodeType == ProjectNodeType.DeviceTag)
//        //            {
//        //                try { textWriter.WriteAttributeString(XmlNodeTagAtt, "TAG"); } catch { }

//        //                try { textWriter.WriteAttributeString("DEVICEID", prNodeData.tag.DeviceID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("IDPARENT", prNodeData.tag.DeviceGroupTagID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ID", prNodeData.tag.DeviceTagID.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("COMMANDID", prNodeData.tag.DeviceTagCommandID.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("ENABLED", prNodeData.tag.DeviceTagEnabled.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ADDRESS", prNodeData.tag.DeviceTagAddress.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("NAME", prNodeData.tag.DeviceTagName.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("CODE", prNodeData.tag.DeviceTagCode.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("TYPE", DriverUtils.NullToString(prNodeData.tag.DeviceTagType)); } catch { }
//        //                try { textWriter.WriteAttributeString("SORTING", prNodeData.tag.DeviceTagSorting.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("COEFFICIENT", prNodeData.tag.DeviceTagCoefficient.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("DESCRIPTION", prNodeData.tag.DeviceTagDescription.ToString()); } catch { }

//        //                try { textWriter.WriteAttributeString("SCALED", prNodeData.tag.DeviceTagScaled.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("SCALEDHIGH", prNodeData.tag.DeviceTagScaledHigh.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("SCALEDLOW", prNodeData.tag.DeviceTagScaledLow.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ROWHIGH", prNodeData.tag.DeviceTagRowHigh.ToString()); } catch { }
//        //                try { textWriter.WriteAttributeString("ROWLOW", prNodeData.tag.DeviceTagRowLow.ToString()); } catch { }
//        //            }
//        //            #endregion Device Tag

//        //        }

//        //        // add other node properties to serialize here  
//        //        if (node.Nodes.Count > 0)
//        //        {
//        //            SaveNodes(node.Nodes, textWriter);
//        //        }

//        //        textWriter.WriteEndElement();
//        //    }
//        //}

//        public void SaveDebug(string fileName)
//        {
//            String result = String.Empty;

//            if (File.Exists(fileName))
//            {
//                XDocument xdoc = XDocument.Load(fileName);
//                var settings = new XmlWriterSettings { Indent = true, IndentChars = "  " };
//                using (var writer = XmlWriter.Create(fileName, settings))
//                {
//                    xdoc.WriteTo(writer);
//                }
//            }
//        }
//        #endregion Project

//        #region Adding and removing elements

//        #region ProjectDefault

//        public void GetDefaultTreeNodes()
//        {
//            //ProjectChannel projectChannel = new ProjectChannel();
//            //projectChannel.KeyImage = ListImages.ImageKey.ChannelEmpty;
//            //projectChannel.ID = Guid.NewGuid();
//            //projectChannel.Name = DriverPhrases.ChannelName;
//            //projectChannel.Description = "";
//            //projectChannel.Enabled = true;
//            ////projectChannel.GatewayTypeProtocol = 0;
//            ////projectChannel.GatewayPort = 60000;
//            ////projectChannel.GatewayConnectedClientsMax = 10;

//            //projectChannel.WriteTimeout = 1000;
//            //projectChannel.ReadTimeout = 1000;
//            //projectChannel.Timeout = 1000;

//            //projectChannel.WriteBufferSize = 8192;
//            //projectChannel.ReadBufferSize = 8192;

//            //projectChannel.CountError = 3;
//            ////Добавляем в дерево
//            //TreeNode channelNode = NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend);
//            ////Добавляем в проект
//            ////project.Settings.ProjectChannel = projectChannel;

//            ////////////////////////////////////////////////////////////////////////

//            //ProjectDevice projectDevice = new ProjectDevice();
//            //projectDevice.ParentID = projectChannel.ID;
//            //projectDevice.ID = Guid.NewGuid();
//            //projectDevice.Name = DriverPhrases.DeviceName;
//            //projectDevice.Description = "";
//            //projectDevice.Enabled = true;
//            //projectDevice.Status = 0;                     // статус Неизвестно
//            //projectDevice.DeviceRegistersBytes = 2;             // 2 регистра по умолчанию
//            //projectDevice.DeviceGatewayRegistersBytes = 2;      // 2 регистра по умолчанию (шлюз)
//            //projectDevice.Address = 1;
//            //projectDevice.DateTimeLastSuccessfully = new DateTime(2000, 1, 1, 0, 0, 0);

//            ////Добавление регистров 65535
//            //for (ulong index = 0; index < (ulong)65535; ++index)
//            //{
//            //    bool status = false;
//            //    ulong value = 0;

//            //    projectDevice.SetCoil(Convert.ToUInt64(index), status);
//            //    projectDevice.SetDiscreteInput(Convert.ToUInt64(index), status);
//            //    projectDevice.SetHoldingRegister(Convert.ToUInt64(index), value);
//            //    projectDevice.SetInputRegister(Convert.ToUInt64(index), value);
//            //}

//            ////Иницилизация групп
//            //projectDevice.GroupCommands = new List<ProjectGroupCommand>();
//            //projectDevice.GroupTags = new List<ProjectGroupTag>();

//            ////Делаем активно меню 
//            //TreeNode deviceNode = NodeProjectDeviceAdd(projectDevice, channelNode, cmnuDeviceDelete);

//            ////Добавляем группу комманд
//            //ProjectGroupCommand projectGroupCommand = new ProjectGroupCommand();
//            //projectGroupCommand.ParentID = projectDevice.ID;
//            //projectGroupCommand.ID = Guid.NewGuid();
//            //projectGroupCommand.GroupCommandEnabled = true;
//            //projectGroupCommand.GroupCommandName = DriverPhrases.GroupCommandName;
//            //projectGroupCommand.Commands = new List<ProjectCommand>();
//            //projectDevice.GroupCommands.Add(projectGroupCommand);
//            ////Добавляем в дерево
//            //TreeNode groupCommandNode = NodeGroupCommandAdd(projectGroupCommand, deviceNode, cmnuCommandAppend);

//            ////Добавляем группу тегов
//            //ProjectGroupTag projectGroupTag = new ProjectGroupTag();
//            //projectGroupTag.ParentID = projectDevice.ID;
//            //projectGroupTag.ID = Guid.NewGuid();
//            //projectGroupTag.DeviceGroupTagEnabled = true;
//            //projectGroupTag.GroupTagName = DriverPhrases.GroupTagName;
//            //projectGroupTag.DeviceTags = new List<ProjectTag>();
//            //projectDevice.GroupTags.Add(projectGroupTag);
//            ////Добавляем в дерево
//            //TreeNode groupTagNode = NodeGroupTagAdd(projectGroupTag, deviceNode, cmnuDeviceTagAppend);

//            ////Добавляем в проект
//            //project.Settings.ProjectChannel.Devices.Add(projectDevice);
//        }

//        #endregion ProjectDefault

//        #region ProjectChannel
//        private void ProjectChannelAdd()
//        {
//            //ProjectChannel projectChannel = new ProjectChannel();
//            //projectChannel.KeyImage = ListImages.ImageKey.ChannelEmpty;
//            //projectChannel.ID = Guid.NewGuid();
//            //projectChannel.Name = DriverPhrases.ChannelName;
//            //projectChannel.Description = "";
//            //projectChannel.Enabled = true;
//            //projectChannel.GatewayTypeProtocol = 0;
//            //projectChannel.GatewayPort = 60000;
//            //projectChannel.GatewayConnectedClientsMax = 10;

//            //projectChannel.WriteTimeout = 1000;
//            //projectChannel.ReadTimeout = 1000;
//            //projectChannel.Timeout = 1000;

//            //projectChannel.WriteBufferSize = 8192;
//            //projectChannel.ReadBufferSize = 8192;

//            //projectChannel.CountError = 3;
//            ////Добавляем в дерево
//            //NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend);
//            ////Добавляем в проект
//            //project.Settings.ProjectChannel = projectChannel;


//        }

//        //Удаление канала
//        private void ProjectChannelDelete()
//        {
//            TreeNode selectNode = trvProject.SelectedNode;
//            string text = selectNode.Text;
//            DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
//            if (DialogResult.Yes == dr)
//            {
//                selectNode.Remove();
//            }
//        }

//        //Добавляем в дерево
//        public TreeNode NodeProjectChannelAdd(ProjectChannel cnl, ContextMenuStrip cms, TreeNode stn = null)
//        {
//            if (null == stn)
//            {
//                TreeNode tn = new TreeNode(cnl.Name);
//                //    tn.Text = cnl.Name;

//                //    string imageKey = string.Empty;
//                //    switch (cnl.Type)
//                //    {
//                //        case 0:
//                //            imageKey = ListImages.ImageKey.ChannelEmpty;
//                //            break;
//                //        case 1:
//                //            imageKey = ListImages.ImageKey.ChannelSerialPort;
//                //            break;
//                //        case 2:
//                //            imageKey = ListImages.ImageKey.ChannelEthernet;
//                //            break;
//                //        case 3:
//                //            imageKey = ListImages.ImageKey.ChannelEthernet;
//                //            break;
//                //        default:
//                //            imageKey = ListImages.ImageKey.ChannelEmpty;
//                //            break;
//                //    }

//                //    cnl.KeyImage = imageKey;
//                //    tn.ImageKey = imageKey;
//                //    tn.SelectedImageKey = imageKey;
//                //    //tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);


//                //    this.trvProject.Nodes.Add(tn);

//                //    ProjectNodeData ProjectNodeData = new ProjectNodeData();
//                //    ProjectNodeData.channel = cnl;
//                //    ProjectNodeData.nodeType = ProjectNodeType.Channel;

//                //    tn.ContextMenuStrip = cms;
//                //    tn.Tag = ProjectNodeData;

//                return tn;
//            }
//            return null;
//        }

//        #endregion ProjectChannel

//        #region ProjectDevice
//        //Добавление устройства
//        private void ProjectDeviceAdd()
//        {
//            ProjectDevice projectDevice = new ProjectDevice();
//            //В дереве выбран объект
//            TreeNode selectNode = trvProject.SelectedNode;

//            ProjectChannel projectChannel = ((ProjectNodeData)selectNode.Tag).channel;
//            projectDevice.ParentID = projectChannel.ID;

//            projectDevice.Name = DriverPhrases.DeviceName;
//            projectDevice.Description = "";
//            projectDevice.ID = Guid.NewGuid();
//            projectDevice.Enabled = true;
//            projectDevice.Status = 0;                     // статус Неизвестно
//            projectDevice.DeviceRegistersBytes = 2;             // 2 регистра по умолчанию
//            projectDevice.DeviceGatewayRegistersBytes = 2;      // 2 регистра по умолчанию (шлюз)
//            projectDevice.Address = 1;
//            projectDevice.DateTimeLastSuccessfully = new DateTime(2000, 1, 1, 0, 0, 0);

//            //Добавление регистров 65535
//            for (ulong index = 0; index < (ulong)65535; ++index)
//            {
//                bool status = false;
//                ulong value = 0;

//                projectDevice.SetCoil(Convert.ToUInt64(index), status);
//                projectDevice.SetDiscreteInput(Convert.ToUInt64(index), status);
//                projectDevice.SetHoldingRegister(Convert.ToUInt64(index), value);
//                projectDevice.SetInputRegister(Convert.ToUInt64(index), value);
//            }


//            projectDevice.GroupCommands = new List<ProjectGroupCommand>();
//            projectDevice.GroupTags = new List<ProjectGroupTag>();

//            //Делаем активно меню 
//            TreeNode deviceNode = NodeProjectDeviceAdd(projectDevice, selectNode, cmnuDeviceDelete);

//            ////Добавляем группу комманд
//            //ProjectGroupCommand projectGroupCommand = new ProjectGroupCommand();
//            //projectGroupCommand.ParentID = projectDevice.ID;
//            //projectGroupCommand.ID = Guid.NewGuid();
//            //projectGroupCommand.GroupCommandEnabled = true;
//            //projectGroupCommand.GroupCommandName = DriverPhrases.GroupCommandName;
//            //projectGroupCommand.Commands = new List<ProjectCommand>();
//            //projectDevice.GroupCommands.Add(projectGroupCommand);
//            ////Добавляем в дерево
//            //TreeNode groupCommandNode = NodeGroupCommandAdd(projectGroupCommand, deviceNode, cmnuCommandAppend);

//            ////Добавляем группу тегов
//            //ProjectGroupTag projectGroupTag = new ProjectGroupTag();
//            //projectGroupTag.ParentID = projectDevice.ID;
//            //projectGroupTag.ID = Guid.NewGuid();
//            //projectGroupTag.DeviceGroupTagEnabled = true;
//            //projectGroupTag.GroupTagName = DriverPhrases.GroupTagName;
//            //projectGroupTag.DeviceTags = new List<ProjectTag>();
//            //projectDevice.GroupTags.Add(projectGroupTag);
//            ////Добавляем в дерево
//            //TreeNode groupTagNode = NodeGroupTagAdd(projectGroupTag, deviceNode, cmnuDeviceTagAppend);

//            ////Добавляем в проект
//            //project.Settings.ProjectChannel.Devices.Add(projectDevice);
//        }

//        //Добавляем в дерево
//        public TreeNode NodeProjectDeviceAdd(ProjectDevice dev, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
//        {
//            if (null == stn)
//            {
//                TreeNode tn = new TreeNode(dev.Name);

//                string imageKey = ListImages.ImageKey.Device;
//                dev.KeyImage = imageKey;
//                tn.ImageKey = imageKey;
//                tn.SelectedImageKey = imageKey;
//                //tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

//                ptn.Nodes.Add(tn);
//                tn.ContextMenuStrip = cms;
//                ProjectNodeData ProjectNodeData = new ProjectNodeData();
//                ProjectNodeData.device = ((ProjectNodeData)ptn.Tag).device;
//                ProjectNodeData.nodeType = ProjectNodeType.Device;
//                ProjectNodeData.device = dev;
//                tn.Tag = ProjectNodeData;
//                ptn.Expand();
//                return tn;
//            }
//            return null;
//        }

//        //Удаление устройства
//        private void ProjectDeviceDelete()
//        {
//            TreeNode selectNode = trvProject.SelectedNode;
//            ProjectChannel projectChannel = ((ProjectNodeData)selectNode.Parent.Tag).channel;
//            ProjectDevice projectDevice = ((ProjectNodeData)selectNode.Tag).device;
//            string text = selectNode.Text;
//            DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
//            if (DialogResult.Yes == dr)
//            {
//                projectChannel.Devices.Remove(projectDevice);
//                selectNode.Remove();
//            }
//        }

//        #endregion ProjectDevice

//        #region GroupCommand
//        //Добавление группы команд
//        public TreeNode NodeGroupCommandAdd(ProjectGroupCommand grpCmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
//        {
//            if (null == stn)
//            {
//                TreeNode tn = new TreeNode();
//                //TreeNode tn = new TreeNode(grpCmd.GroupCommandName);

//                //string imageKey = ListImages.ImageKey.GroupCmd;
//                //grpCmd.KeyImage = imageKey;
//                //tn.ImageKey = imageKey;
//                //tn.SelectedImageKey = imageKey;
//                ////tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

//                //ptn.Nodes.Add(tn);
//                //tn.ContextMenuStrip = cms;
//                //ProjectNodeData ProjectNodeData = new ProjectNodeData();
//                //ProjectNodeData.groupCommand = ((ProjectNodeData)ptn.Tag).groupCommand;
//                //ProjectNodeData.nodeType = ProjectNodeType.GroupCommand;
//                //ProjectNodeData.groupCommand = grpCmd;
//                //tn.Tag = ProjectNodeData;
//                //ptn.Expand();
//                return tn;
//            }
//            return null;
//        }

//        #endregion GroupCommand

//        #region Command
//        private void ProjectCommandAdd(ulong command)
//        {
//            //ProjectCommand projectCommand = new ProjectCommand();
//            ////В дереве выбран объект
//            //TreeNode selectNode = trvProject.SelectedNode;

//            //ProjectGroupCommand projectGroupCommand = ((ProjectNodeData)selectNode.Tag).groupCommand;
//            //Guid ParentID = projectGroupCommand.ID;
//            ////Guid DeviceID = projectGroupCommand.DeviceID;

//            ////projectCommand.DeviceID = DeviceID;
//            //projectCommand.ParentID = ParentID;
//            //projectCommand.ID = Guid.NewGuid();
//            //projectCommand.KeyImage = ProjectCommand.KeyImageName(command);
//            //projectCommand.CommandEnabled = true;
//            //projectCommand.CommandFunctionCode = command;
//            //projectCommand.CommandRegisterStartAddress = 0;
//            //projectCommand.CommandRegisterCount = 1;
//            //projectCommand.CommandParametr = 0;
//            //projectCommand.CommandName = projectCommand.GenerateName();
//            //projectCommand.CommandDescription = "";

//            ////Добавляем в дерево
//            //NodeCommandAdd(projectCommand, selectNode, cmnuCommandDelete);

//            ////Добавляем в проект
//            //projectGroupCommand.Commands.Add(projectCommand);
//        }

//        public TreeNode NodeCommandAdd(ProjectCommand devCmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
//        {
//            if (null == stn)
//            {
//                TreeNode tn = new TreeNode();
//                //    TreeNode tn = new TreeNode(devCmd.CommandName);

//                //    tn.ImageKey = tn.SelectedImageKey = ProjectCommand.KeyImageName(devCmd.CommandFunctionCode);

//                //    ptn.Nodes.Add(tn);
//                //    tn.ContextMenuStrip = cms;
//                //    ProjectNodeData ProjectNodeData = new ProjectNodeData();
//                //    ProjectNodeData.command = ((ProjectNodeData)ptn.Tag).command;
//                //    ProjectNodeData.nodeType = ProjectNodeType.Command;
//                //    ProjectNodeData.command = devCmd;
//                //    tn.Tag = ProjectNodeData;
//                //    ptn.Expand();
//                return tn;
//            }
//            return null;
//        }

//        private void ProjectCommandDelete()
//        {
//            //TreeNode selectNode = trvProject.SelectedNode;
//            //ProjectGroupCommand projectGroupCommand = ((ProjectNodeData)selectNode.Parent.Tag).groupCommand;
//            //ProjectCommand projectCommand = ((ProjectNodeData)selectNode.Tag).command;
//            //string text = selectNode.Text;
//            //DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
//            //if (DialogResult.Yes == dr)
//            //{
//            //    projectGroupCommand.Commands.Remove(projectCommand);
//            //    selectNode.Remove();
//            //}
//        }

//        #endregion Command

//        #region DeviceGroupTag
//        public TreeNode NodeGroupTagAdd(ProjectGroupTag grpTgs, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
//        {
//            if (null == stn)
//            {
//                TreeNode tn = new TreeNode();
//                //TreeNode tn = new TreeNode(grpTgs.GroupTagName);

//                //string imageKey = ListImages.ImageKey.GroupTag;
//                //grpTgs.KeyImage = imageKey;
//                //tn.ImageKey = imageKey;
//                //tn.SelectedImageKey = imageKey;
//                ////tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

//                //ptn.Nodes.Add(tn);
//                //tn.ContextMenuStrip = cms;
//                //ProjectNodeData ProjectNodeData = new ProjectNodeData();
//                //ProjectNodeData.groupTag = ((ProjectNodeData)ptn.Tag).groupTag;
//                //ProjectNodeData.nodeType = ProjectNodeType.DeviceGroupTag;
//                //ProjectNodeData.groupTag = grpTgs;
//                //tn.Tag = ProjectNodeData;
//                //ptn.Expand();
//                return tn;
//            }
//            return null;
//        }

//        #endregion DeviceGroupTag

//        #region DeviceTag

//        private void ProjectTagAdd()
//        {
//            //ProjectTag projectTag = new ProjectTag();
//            ////В дереве выбран объект
//            //TreeNode selectNode = trvProject.SelectedNode;

//            //ProjectGroupTag projectGroupTag = ((ProjectNodeData)selectNode.Tag).groupTag;
//            //Guid ParentID = projectGroupTag.ParentID;
//            //Guid DeviceID = projectGroupTag.ID;

//            //projectTag.DeviceID = DeviceID;
//            //projectTag.DeviceGroupTagID = ParentID;
//            //projectTag.DeviceTagID = Guid.NewGuid();
//            //projectTag.DeviceTagEnabled = true;
//            //projectTag.DeviceTagAddress = "";
//            //projectTag.DeviceTagName = DriverPhrases.TagName;
//            //projectTag.DeviceTagDescription = "";
//            //projectTag.DeviceTagCoefficient = 1;

//            //projectTag.DeviceTagScaled = 0;
//            //projectTag.DeviceTagScaledHigh = 1000;
//            //projectTag.DeviceTagScaledLow = 0;
//            //projectTag.DeviceTagRowHigh = 1000;
//            //projectTag.DeviceTagRowLow = 0;

//            ////Добавляем в дерево
//            //NodeDeviceTagAdd(projectTag, selectNode, cmnuDeviceTagDelete);

//            ////Добавляем в проект
//            //projectGroupTag.DeviceTags.Add(projectTag);

//        }

//        public TreeNode NodeDeviceTagAdd(ProjectTag devTag, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
//        {
//            if (null == stn)
//            {
//                TreeNode tn = new TreeNode();
//                //TreeNode tn = new TreeNode(devTag.DeviceTagName);
//                //devTag.KeyImage = tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.Tag;
//                //ptn.Nodes.Add(tn);
//                //tn.ContextMenuStrip = cms;
//                //ProjectNodeData ProjectNodeData = new ProjectNodeData();
//                //ProjectNodeData.tag = ((ProjectNodeData)ptn.Tag).tag;
//                //ProjectNodeData.nodeType = ProjectNodeType.DeviceTag;
//                //ProjectNodeData.tag = devTag;
//                //tn.Tag = ProjectNodeData;
//                //ptn.Expand();
//                return tn;
//            }
//            return null;
//        }

//        private void ProjectTagDelete()
//        {
//            //TreeNode selectNode = trvProject.SelectedNode;
//            //ProjectGroupTag projectGroupTag = ((ProjectNodeData)selectNode.Parent.Tag).groupTag;
//            //ProjectTag projectTag = ((ProjectNodeData)selectNode.Tag).tag;
//            //string text = selectNode.Text;
//            //DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
//            //if (DialogResult.Yes == dr)
//            //{
//            //    projectGroupTag.DeviceTags.Remove(projectTag);
//            //    selectNode.Remove();
//            //}
//        }

//        #endregion DeviceTag

//        #endregion Adding and removing elements

//        #region Moving elements

//        private void ProjectNodeElementUp()
//        {
//            try
//            {
//                TreeNode selectedNode = trvProject.SelectedNode;
//                if (selectedNode == null)
//                {
//                    return;
//                }
//                TreeNode treeNode = selectedNode.PrevNode;
//                if (treeNode == null)
//                {
//                    return;
//                }
//                TreeNode parent = selectedNode.Parent;
//                if (parent == null)
//                {
//                    return;
//                }
//                parent.Nodes.Remove(selectedNode);
//                parent.Nodes.Insert(treeNode.Index, selectedNode);
//                trvProject.SelectedNode = selectedNode;
//            }
//            catch { }
//        }

//        private void ProjectNodeElementDown()
//        {
//            try
//            {
//                TreeNode selectedNode = trvProject.SelectedNode;
//                if (selectedNode == null)
//                {
//                    return;
//                }
//                TreeNode nextNode = selectedNode.NextNode;
//                if (nextNode == null)
//                {
//                    return;
//                }
//                TreeNode parent = selectedNode.Parent;
//                if (parent == null)
//                {
//                    return;
//                }
//                parent.Nodes.Remove(selectedNode);
//                parent.Nodes.Insert(nextNode.Index + 1, selectedNode);
//                trvProject.SelectedNode = selectedNode;
//            }
//            catch { }
//        }

//        #endregion Moving elements

//        #region Selection of nodes and elements on the project

//        /// <summary>
//        /// Checking for changes that have not been saved, but Control is closed.
//        /// </summary>
//        /// <param name="sender"></param>
//        /// <param name="e"></param>
//        private void trvProject_BeforeSelect(object sender, TreeViewCancelEventArgs e)
//        {
//            //bool status = false;

//            //TreeNode selectNode = trvProject.SelectedNode;

//            //if (SwitchingNewControlLock != true)
//            //{
//            //    selectNodePrevious = trvProject.SelectedNode;
//            //}

//            //if (selectNode == null)
//            //{
//            //    return;
//            //}

//            //mtNodeData = (ProjectNodeData)selectNode.Tag;
//            //mtNodeDataPrevious = (ProjectNodeData)selectNodePrevious.Tag;

//            //if (SwitchingNewControlLock == true)
//            //{
//            //    modified = false;
//            //}
//            //else
//            //{
//            //    if (ProjectNodeType.Channel == mtNodeData.nodeType && mtNodeData.channel != null)
//            //    {
//            //        modified = status = ((uscChannel)uscPropertyControl).modified;
//            //    }

//            //    if (ProjectNodeType.Device == mtNodeData.nodeType && mtNodeData.device != null)
//            //    {
//            //        modified = status = ((uscDevice)uscPropertyControl).modified;
//            //    }

//            //    if (ProjectNodeType.Command == mtNodeData.nodeType && mtNodeData.command != null)
//            //    {
//            //        modified = status = ((uscCommandParametr)uscPropertyControl).modified;
//            //        modified = status = ((uscCommandRead)uscPropertyControl).modified;
//            //        modified = status = ((uscCommandWrite)uscPropertyControl).modified;
//            //    }

//            //    if (ProjectNodeType.DeviceGroupTag == mtNodeData.nodeType && mtNodeData.groupTag != null)
//            //    {
//            //        modified = status = ((uscGroupTag)uscPropertyControl).modified;
//            //    }

//            //    if (ProjectNodeType.DeviceTag == mtNodeData.nodeType && mtNodeData.tag != null)
//            //    {
//            //        modified = status = ((FrmTag)frmPropertyForm).modified;
//            //    }

//            //    if (status)
//            //    {
//            //        DialogResult dialogResult = MessageBox.Show(DriverDictonary.QuestionAboutChanges, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//            //        if (dialogResult == DialogResult.Yes)
//            //        {
//            //            SwitchingNewControlLock = true;
//            //            trvProject.SendToBack();
//            //        }
//            //        else if (dialogResult == DialogResult.No)
//            //        {
//            //            //none
//            //        }
//            //    }
//            //}
//        }

//        private void trvProject_AfterSelect(object sender, TreeViewEventArgs e)
//        {
//            // the ban on the transition
//            if (SwitchingNewControlLock == true && modified == true)
//            {
//                return;
//            }

//            TreeNode selectNode = trvProject.SelectedNode;
//            mtNodeData = (ProjectNodeData)selectNode.Tag;

//            selectNode.SelectedImageIndex = imgList.Images.IndexOfKey(selectNode.ImageKey);

//            // we load the window on the right and its properties
//            if (SwitchingNewControlLock == false)
//            {
//                LoadWindow(mtNodeData);
//            }

//            if (SwitchingNewControlLock == true)
//            {
//                trvProject.SelectedNode = selectNodePrevious;

//                SwitchingNewControlLock = false;
//            }
//        }

//        private void trvProject_MouseClick(object sender, MouseEventArgs e)
//        {
//            //TreeNode selectNode = trvProject.GetNodeAt(new Point(e.X, e.Y));
//            //selectNode = trvProject.SelectedNode;

//            //mtNodeData = (ProjectNodeData)selectNode.Tag;

//            //if (ProjectNodeType.Channel == mtNodeData.nodeType && mtNodeData.channel != null)
//            //{
//            //    trvProject.ContextMenuStrip = cmnuDeviceAppend;
//            //}
//            //else if (ProjectNodeType.Device == mtNodeData.nodeType && mtNodeData.device != null)
//            //{
//            //    trvProject.ContextMenuStrip = cmnuDeviceDelete;
//            //}
//            //else if (ProjectNodeType.GroupCommand == mtNodeData.nodeType && mtNodeData.groupCommand != null)
//            //{
//            //    trvProject.ContextMenuStrip = cmnuCommandAppend;
//            //}
//            //else if (ProjectNodeType.Command == mtNodeData.nodeType && mtNodeData.command != null)
//            //{
//            //    trvProject.ContextMenuStrip = cmnuCommandDelete;
//            //}
//            //else if (ProjectNodeType.DeviceGroupTag == mtNodeData.nodeType && mtNodeData.groupTag != null)
//            //{
//            //    trvProject.ContextMenuStrip = cmnuDeviceTagAppend;
//            //}
//            //else if (ProjectNodeType.DeviceTag == mtNodeData.nodeType && mtNodeData.tag != null)
//            //{
//            //    trvProject.ContextMenuStrip = cmnuDeviceTagDelete;
//            //}
//        }

//        private void trvProject_MouseDown(object sender, MouseEventArgs e)
//        {
//            try
//            {
//                TreeViewHitTestInfo htInfo = trvProject.HitTest(e.X, e.Y);
//                TreeNode selectNode = htInfo.Node;
//                if (selectNode != null)
//                {
//                    trvProject.SelectedNode = selectNode;

//                    // the ban on the transition
//                    if (SwitchingNewControlLock == true)
//                    {
//                        trvProject.SelectedNode = null;
//                        trvProject.SelectedNode = selectNodePrevious;
//                    }
//                }
//            }
//            catch { }
//        }

//        private void LoadWindow(ProjectNodeData mtNodeData)
//        {
//        //    // checking tabs
//        //    ValidateTabPage();

//        //    if (SwitchingNewControlLock == true)
//        //    {
//        //        return;
//        //    }

//        //    bool showForm = false;
//        //    string keyImage = string.Empty;
//        //    int indexImage = 0;

//        //    if (ProjectNodeType.Channel == mtNodeData.nodeType && mtNodeData.channel != null)
//        //    {
//        //        keyImage = mtNodeData.channel.KeyImage;
//        //        indexImage = imgList.Images.IndexOfKey(keyImage);

//        //        uscChannel uscChannelControl = new uscChannel(mtNodeData);
//        //        uscChannelControl.frmParentGloabal = this;
//        //        uscPropertyControl = uscChannelControl;
//        //    }
//        //    else if (ProjectNodeType.Device == mtNodeData.nodeType && mtNodeData.device != null)
//        //    {
//        //        keyImage = mtNodeData.device.KeyImage;
//        //        indexImage = imgList.Images.IndexOfKey(keyImage);

//        //        uscDevice uscDeviceControl = new uscDevice(mtNodeData);
//        //        uscDeviceControl.frmParentGloabal = this;
//        //        uscPropertyControl = uscDeviceControl;
//        //    }
//        //    else if (ProjectNodeType.GroupCommand == mtNodeData.nodeType && mtNodeData.groupCommand != null)
//        //    {
//        //        keyImage = mtNodeData.groupCommand.KeyImage;
//        //        indexImage = imgList.Images.IndexOfKey(keyImage);

//        //        uscEmpty uscEmptyControl = new uscEmpty();
//        //        uscPropertyControl = uscEmptyControl;
//        //    }
//        //    else if (ProjectNodeType.Command == mtNodeData.nodeType && mtNodeData.command != null)
//        //    {
//        //        if (mtNodeData.command.CommandFunctionCode <= 4)
//        //        {
//        //            uscPropertyControl = new uscCommandRead(mtNodeData);
//        //            keyImage = mtNodeData.command.KeyImage;
//        //        }
//        //        else if (mtNodeData.command.CommandFunctionCode >= 80 && mtNodeData.command.CommandFunctionCode <= 96)
//        //        {
//        //            uscPropertyControl = new uscCommandParametr(mtNodeData);
//        //            keyImage = mtNodeData.command.KeyImage;
//        //        }
//        //        else
//        //        {

//        //        }
//        //    }
//        //    else if (ProjectNodeType.DeviceGroupTag == mtNodeData.nodeType && mtNodeData.groupTag != null)
//        //    {
//        //        keyImage = mtNodeData.groupTag.KeyImage;
//        //        indexImage = imgList.Images.IndexOfKey(keyImage);

//        //        TreeNode selectNode = trvProject.SelectedNode;
//        //        ProjectGroupTag projectGroupTag = mtNodeData.groupTag;

//        //        if (projectGroupTag.DeviceTags == null)
//        //        {
//        //            projectGroupTag.DeviceTags = new List<ProjectTag>();
//        //        }
//        //        projectGroupTag.DeviceTags.Clear();

//        //        foreach (TreeNode tagNode in selectNode.Nodes)
//        //        {
//        //            ProjectNodeData mtTagNodeData = (ProjectNodeData)tagNode.Tag;
//        //            ProjectTag projectTag = mtTagNodeData.tag;
//        //            projectGroupTag.DeviceTags.Add(projectTag);
//        //        }

//        //        uscGroupTag uscGroupTag = new uscGroupTag(mtNodeData);
//        //        uscGroupTag.frmParentGloabal = this;
//        //        uscPropertyControl = uscGroupTag;

//        //    }
//        //    else if (ProjectNodeType.DeviceTag == mtNodeData.nodeType && mtNodeData.tag != null)
//        //    {

//        //        keyImage = mtNodeData.tag.KeyImage;
//        //        indexImage = imgList.Images.IndexOfKey(keyImage);

//        //        showForm = true;
//        //        FrmTag frmTag = new FrmTag(mtNodeData);
//        //        frmTag.frmParentGloabal = this;
//        //        frmPropertyForm = frmTag;
//        //    }

//        //    try
//        //    {
//        //        tabControl.ImageList = imgList;

//        //        TabPage tabPageNew = new TabPage(trvProject.SelectedNode.Text);
//        //        tabPageNew.Name = trvProject.SelectedNode.Text;
//        //        tabPageNew.Text = trvProject.SelectedNode.Text;
//        //        tabPageNew.ImageIndex = indexImage;

//        //        if (showForm == false)
//        //        {
//        //            tabPageNew.Controls.Add(uscPropertyControl);
//        //        }
//        //        else
//        //        {
//        //            tabPageNew.Controls.Add(frmPropertyForm);
//        //        }


//        //        tabControl.TabPages.Add(tabPageNew);
//        //        tabControl.SelectedTab = tabPageNew;

//        //        if (showForm == false)
//        //        {
//        //            uscPropertyControl.Dock = DockStyle.Fill;
//        //            uscPropertyControl.Show();
//        //        }
//        //        else
//        //        {
//        //            frmPropertyForm.Dock = DockStyle.Fill;
//        //            frmPropertyForm.Show();
//        //        }
//        //    }
//        //    catch (System.ObjectDisposedException) { }
//        //}

//        //private void ValidateTabPage()
//        //{
//        //    if (uscPropertyControl != null)
//        //    {
//        //        uscPropertyControl.Dispose();
//        //    }

//        //    if (frmPropertyForm != null)
//        //    {
//        //        frmPropertyForm.Close();
//        //        frmPropertyForm.Dispose();
//        //    }

//        //    foreach (TabPage tabPage in tabControl.TabPages)
//        //    {
//        //        tabControl.Controls.Remove(tabPage);
//        //    }
//        }

//        #endregion Selection of nodes and elements on the project 

//        #region Timer
//        private void tmrTimer_Tick(object sender, EventArgs e)
//        {
//            //List<ProjectDevice> tmpDevices = project.Settings.ProjectDevice;
//            //foreach (ProjectDevice device in tmpDevices)
//            //{

//            //}
//        }

//        #endregion Timer

//        private void mnuConverter_Click(object sender, EventArgs e)
//        {
//            FrmConverter frmConverter = new FrmConverter();
//            frmConverter.ShowDialog();
//        }

//        private void mnuSettings_Click(object sender, EventArgs e)
//        {
//            ProjectChannel projectChannelSettings = new ProjectChannel();

//            TreeNodeCollection nodesCollection = trvProject.Nodes;

//            for (int i = 0; i < nodesCollection.Count; i++)
//            {
//                TreeNode node = nodesCollection[i];
//                ProjectNodeData prNodeData = (ProjectNodeData)node.Tag;

//                if (node.Tag != null)
//                {
//                    #region Channel
//                    // channel
//                    if (prNodeData.nodeType == ProjectNodeType.Channel)
//                    {
//                        projectChannelSettings = prNodeData.channel;
//                    }
//                    #endregion Channel
//                }
//            }

//            FrmSettings frmSettings = new FrmSettings();
//            frmSettings.settings = projectChannelSettings;
//            // showing the form
//            DialogResult dialog = frmSettings.ShowDialog();
//            // if you have closed the form, click OK
//            if (DialogResult.OK == dialog)
//            {
//                projectChannelSettings = frmSettings.settings;
//                ProjectSave();
//            }
//        }


//        private void tlsProjectStartStop_Click(object sender, EventArgs e)
//        {
//            if (buttonStatus == false)
//            {
//                tlsProjectStartStop.Image = ListImages.GetFormImages().FirstOrDefault(x => x.Key == ListImages.ImageKeyForm.Stop).Value;
//                buttonStatus = true;

//                Start();
//            }
//            else
//            {
//                tlsProjectStartStop.Image = ListImages.GetFormImages().FirstOrDefault(x => x.Key == ListImages.ImageKeyForm.Start).Value;
//                buttonStatus = false;

//                Stop();
//            }
//        }

//        private void Start()
//        {
//            //string errMsg = string.Empty;

//            //// save the configuration
//            //ControlsToConfig();

//            //// load a configuration
//            //ConfigToControls();

//            //int port = 0;
//            //if (project.Settings.ProjectChannel.GatewayTypeProtocol == 0)
//            //{
//            //    //Если шлюз не указан т.е. выключен, то генерируем порт 
//            //    port = GENERATE_TCP_SERVER_PORT.PORT_NEW();
//            //}
//            //else
//            //{
//            //    bool checked_port = GENERATE_TCP_SERVER_PORT.CheckAvailableServerPort(Convert.ToInt32(project.Settings.ProjectChannel.GatewayPort));
//            //    if (checked_port == false)
//            //    {
//            //        MessageBox.Show("Указанный порт " + project.Settings.ProjectChannel.GatewayPort + " занят! Попробуйте другой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            //        return;
//            //    }
//            //}

//            //project.Settings.ProjectChannel.ThreadEnabled = true;

//            ////Получение RxTx 
//            //DriverClient.EventHandlerEventDevicePollTxRx = new DriverClient.EventDevicePollTxRx(PollTxRxGet);
//            ////Получение лога
//            //DriverClient.OnDebug = new DriverClient.DebugData(PollLogGet);
//            ////Получение информации с TCP сервера
//            //DriverClient.OnDebugTCPServer = new DriverClient.DebugDataTCPServer(PollLogGetTCPServer);

//            //DriverClient driverClient = new DriverClient(project);
//            //driverClient.InitializingDriver();

//            //new Thread(new ParameterizedThreadStart(driverClient.ExecuteCycle))
//            //{
//            //    IsBackground = true
//            //}.Start((object)driverClient);




//            //if (errMsg != string.Empty)
//            //{
//            //    ScadaUiUtils.ShowError(errMsg);
//            //}
//        }


//        private void Stop()
//        {
//            //project.Settings.ProjectChannel.ThreadEnabled = false;
//        }


//        void PollLogGet(string text)
//        {
//            //FrmViewData.SetLog(text);
//        }

//        void PollLogGetTCPServer(string text)
//        {
//            //FrmViewData.SetLogTcpServer(text);
//        }

//        void PollTxRxGet(string type, int data)
//        {

//        }

//        private void tlsProjectDataView_Click(object sender, EventArgs e)
//        {
//            //FrmViewData.CloseForm();
//            //FrmViewData.ShowSplashScreen();
//        }

//        private void toolStripButton1_Click(object sender, EventArgs e)
//        {
//            ulong gggg = 10;
//            byte[] h = BitConverter.GetBytes(gggg);


//            byte[] test = new byte[8];
//            ulong value = 0;

//            test[0] = 85;
//            test[1] = 0;
//            test[2] = 0;
//            test[3] = 0;
//            test[4] = 0;
//            test[5] = 0;
//            test[6] = 0;
//            test[7] = 0;

//            value = BitConverter.ToUInt64(test);

//            test[0] = 1;
//            test[1] = 2;
//            test[2] = 0;
//            test[3] = 0;
//            test[4] = 0;
//            test[5] = 0;
//            test[6] = 0;
//            test[7] = 0;

//            value = BitConverter.ToUInt64(test);

//            test[0] = 1;
//            test[1] = 2;
//            test[2] = 3;
//            test[3] = 0;
//            test[4] = 0;
//            test[5] = 0;
//            test[6] = 0;
//            test[7] = 0;

//            value = BitConverter.ToUInt64(test);

//            test[0] = 1;
//            test[1] = 2;
//            test[2] = 3;
//            test[3] = 4;
//            test[4] = 0;
//            test[5] = 0;
//            test[6] = 0;
//            test[7] = 0;

//            value = BitConverter.ToUInt64(test);

//            test[0] = 1;
//            test[1] = 2;
//            test[2] = 3;
//            test[3] = 4;
//            test[4] = 5;
//            test[5] = 0;
//            test[6] = 0;
//            test[7] = 0;

//            value = BitConverter.ToUInt64(test);

//            test[0] = 1;
//            test[1] = 2;
//            test[2] = 3;
//            test[3] = 4;
//            test[4] = 5;
//            test[5] = 6;
//            test[6] = 0;
//            test[7] = 0;

//            value = BitConverter.ToUInt64(test);

//            test[0] = 1;
//            test[1] = 2;
//            test[2] = 3;
//            test[3] = 4;
//            test[4] = 5;
//            test[5] = 6;
//            test[6] = 7;
//            test[7] = 0;

//            value = BitConverter.ToUInt64(test);

//            test[0] = 1;
//            test[1] = 2;
//            test[2] = 3;
//            test[3] = 4;
//            test[4] = 5;
//            test[5] = 6;
//            test[6] = 7;
//            test[7] = 8;

//            value = BitConverter.ToUInt64(test);

//            byte[] bytes1 = new byte[1];
//            bytes1[0] = 1;

//            byte[] bytes2 = new byte[2];
//            bytes2[0] = 85;
//            bytes2[1] = 86;

//            byte[] bytes3 = new byte[3];
//            bytes3[0] = 85;
//            bytes3[1] = 86;
//            bytes3[2] = 87;

//            byte[] bytes4 = new byte[4];
//            bytes4[0] = 85;
//            bytes4[1] = 86;
//            bytes4[2] = 87;
//            bytes4[3] = 88;

//            byte[] bytes5 = new byte[5];
//            bytes5[0] = 1;
//            bytes5[1] = 2;
//            bytes5[2] = 3;
//            bytes5[3] = 4;
//            bytes5[4] = 5;

//            byte[] bytes6 = new byte[6];
//            bytes6[0] = 1;
//            bytes6[1] = 2;
//            bytes6[2] = 3;
//            bytes6[3] = 4;
//            bytes6[4] = 5;
//            bytes6[5] = 6;

//            byte[] bytes7 = new byte[7];
//            bytes7[0] = 1;
//            bytes7[1] = 2;
//            bytes7[2] = 3;
//            bytes7[3] = 4;
//            bytes7[4] = 5;
//            bytes7[5] = 6;
//            bytes7[6] = 7;

//            byte[] bytes8 = new byte[8];
//            bytes8[0] = 1;
//            bytes8[1] = 2;
//            bytes8[2] = 3;
//            bytes8[3] = 4;
//            bytes8[4] = 5;
//            bytes8[5] = 6;
//            bytes8[6] = 7;
//            bytes8[7] = 8;

//            ulong value1 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes1);
//            ulong value2 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes2);
//            ulong value3 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes3);
//            ulong value4 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes4);
//            ulong value5 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes5);
//            ulong value6 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes6);
//            ulong value7 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes7);
//            ulong value8 = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(bytes8);



//            //ulong t = 21846;
//            //byte[] g = BitConverter.GetBytes(t);

//            //int f = 67305985;
//            //byte[] h = BitConverter.GetBytes(f);
//            //h[0] = 1;
//            //h[1] = 2;
//            //h[2] = 3;
//            //h[3] = 4;    

//            //ulong s = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(h);
//        }

//        private void tlsProjectSaveAs_Click_1(object sender, EventArgs e)
//        {

//        }

//        //public void Start()
//        //{
//        //    try
//        //    {
//        //        CancellationToken token = cancelTokenSource.Token;

//        //        while (project.Settings.ProjectChannel.ThreadEnabled == true)
//        //        {

//        //            new Thread(new ParameterizedThreadStart(Execute))
//        //            {
//        //                IsBackground = true
//        //            }.Start();

//        //            if (token.IsCancellationRequested)
//        //            {
//        //                token.ThrowIfCancellationRequested(); // генерируем исключение
//        //            }
//        //        }

//        //        //try
//        //        //{
//        //        //    CancellationToken token = cancelTokenSource.Token;

//        //        //    while (project.Settings.ProjectChannel.ThreadEnabled == true)
//        //        //    {
//        //        //        Execute(project);

//        //        //        if (token.IsCancellationRequested)
//        //        //        {
//        //        //            token.ThrowIfCancellationRequested(); // генерируем исключение
//        //        //        }
//        //        //    }
//        //        //}
//        //        //catch { }
//        //    }
//        //    catch
//        //    { }
//        //}

//        //public void Stop()
//        //{
//        //    try
//        //    {
//        //        Thread.Sleep(100);
//        //        // after a time delay, we cancel the task
//        //        cancelTokenSource.Cancel();

//        //        // we are waiting for the completion of the task
//        //        Thread.Sleep(100);
//        //    }
//        //    finally
//        //    {
//        //        cancelTokenSource.Dispose();
//        //    }
//        //}




//    }
//}
