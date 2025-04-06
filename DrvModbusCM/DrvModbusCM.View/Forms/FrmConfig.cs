using DrvModbusCM.Shared.Communication;
using Scada.Comm.Channels;
using Scada.Comm.Config;
using Scada.Data.Entities;
using Scada.Forms;
using Scada.Lang;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;
using System.Xml;


namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmConfig : Form
    {
        #region InitializeComponent
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmConfig()
        {
            InitializeComponent();

            this.isDll = false;

            this.driverCode = DriverUtils.DriverCode;

            this.appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.languageDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Lang");
            this.pathProject = AppDomain.CurrentDomain.BaseDirectory;
            this.project = new Project();
            this.configFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DriverUtils.GetFileName(deviceNum));

            ConfigToControls();

            this.modified = false;
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmConfig(AppDirs appDirs, LineConfig lineConfig, DeviceConfig deviceConfig)
            : this()
        {
            this.isDll = true;

            this.appDirs = appDirs ?? throw new ArgumentNullException(nameof(appDirs));
            this.lineConfig = lineConfig ?? throw new ArgumentNullException(nameof(lineConfig));
            this.deviceConfig = deviceConfig ?? throw new ArgumentNullException(nameof(deviceConfig));

            this.appDirectory = appDirs.ConfigDir;
            this.languageDir = appDirs.LangDir;
            this.pathProject = appDirs.ConfigDir;
            this.project = new Project();
            this.configFileName = Path.Combine(appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));

            ConfigToControls();

            this.isRussian = Locale.IsRussian;
        }
        #endregion InitializeComponent

        #region Variables
        public FrmStart formParent;                     // parent form
        public readonly bool isDll;                     // application or dll

        private readonly AppDirs appDirs;               // the application directories
        private readonly LineConfig lineConfig;         // the communication line configuration
        private readonly DeviceConfig deviceConfig;     // the device configuration
        private readonly int deviceNum;                 // the device number
        private readonly string driverCode;             // the driver code

        private string appDirectory;                    // the applications directory
        public Project project;                         // the project configuration
        public string pathProject;                      // path project
        public string configFileName;                   // the configuration file name

        public ProjectDriver projectDriver;             // the project driver

        private bool modified;                          // the configuration was modified

        private string languageDir;                     // the language directory
        private string culture = "en-GB";               // the culture
        private bool isRussian;							// the language

        System.Windows.Forms.TreeView trvConfig = new System.Windows.Forms.TreeView();  // config treeview
        ProjectNodeData mtNodeData = new ProjectNodeData();                             // project node type
        private Form frmPropertyForm = new Form();                                      // child form properties
        #endregion Variables

        #region Form Load
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            LoadLanguage(languageDir, isRussian);
            Translate();

            Text = string.Format(Text, deviceNum, DriverUtils.Version);
        }
        #endregion Form Load

        #region Form Close
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void FrmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlsToConfig();
        }
        #endregion Form Close

        #region Lang
        /// <summary>
        /// Loading from the translation catalog by language.
        /// <para>Загрузка из каталога перевода по признаку языка</para>
        /// </summary>
        public void LoadLanguage(string languageDir, bool IsRussian = false)
        {
            // load translate
            this.isRussian = IsRussian;

            string culture = "en-GB";
            string EnglishCultureName = "en-GB";
            string RussianCultureName = "ru-RU";
            if (!IsRussian)
            {
                culture = EnglishCultureName;
            }
            else
            {
                culture = RussianCultureName;
            }

            string languageFile = Path.Combine(languageDir, DriverUtils.DriverCode + "." + culture + ".xml");
            if (!File.Exists(languageFile))
            {
                MessageBox.Show(languageFile, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Locale.LoadDictionaries(languageFile, out string errMsg);
            // load translate the form
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmConfig");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmCmdRequest");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmCommand");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmDevice");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmError");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmInputBox");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmSndRequest");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmVariable");

            DriverPhrases.Init();

            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Translation of the form.
        /// <para>Перевод формы.</para>
        /// </summary>
        private void Translate()
        {
            // translate the form
            FormTranslator.Translate(this, GetType().FullName);
            // tranlaste the menu
            //FormTranslator.Translate(cmnuMenu, GetType().FullName);
        }

        #endregion Lang

        #region Control
        private void splContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            LoadWindow(mtNodeData);
            this.Refresh();
        }
        #endregion Control

        #region Config
        /// <summary>
        /// Sets the controls according to the configuration.
        /// <para>Устанавливает элементы управления в соответствии с конфигурацией.</para>
        /// </summary>
        public void ConfigToControls()
        {
            try
            {
                ProjectDefaultNew(DialogResult.No);

                project.Load(configFileName, out string errMsg);
                if (errMsg != string.Empty)
                {
                    MessageBox.Show(errMsg);
                }

                // language 
                this.isRussian = project.Driver.Settings.LanguageIsRussian;

                if (project.Driver != null)
                {
                    projectDriver = project.Driver;
                }
                else
                {
                    projectDriver = new ProjectDriver();
                }

                DeserializeTreeView(trvProject, project);
            }
            catch { }
        }

        /// <summary>
        /// Sets the configuration parameters according to the controls.
        /// <para>Устанавливает параметры конфигурации в соответствии с элементами управления.</para>
        /// </summary>
        private void ControlsToConfig()
        {
            if (!File.Exists(pathProject))
            {
                if (this.appDirs != null)
                {
                    pathProject = Path.Combine(this.appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
                }
                else
                {
                    pathProject = DriverUtils.GetFileName(deviceNum);
                }
            }

            //SerializeTreeView(trvProject, pathProject);
        }

        #endregion Config 

        #region Driver Config





        #endregion Driver Config

        #region Project

        #region Project New

        private void mnuNewProject_Click(object sender, EventArgs e)
        {
            ProjectDefaultNew(DialogResult.Yes);
        }

        private void tlsProjectNew_Click(object sender, EventArgs e)
        {
            ProjectDefaultNew(DialogResult.Yes);
        }

        private void ProjectNew()
        {
            // checking tabs
            ValidateTabPage();

            // remove the project name and path to it
            pathProject = "";

            // create a new project with default settings
            project = new Project();

            // cleaning up the trvProject project
            trvProject.Nodes.Clear();

            // add default nodes
            GetDefaultTreeNodes();
        }

        #endregion Project New

        #region Project Default

        private void ProjectDefaultNew(DialogResult dialog)
        {
            if (dialog == DialogResult.Yes)
            {
                DialogResult dialogResult = MessageBox.Show(DriverPhrases.QuestionNewProjectMsg, DriverPhrases.QuestionNewProjectTitle, MessageBoxButtons.YesNo);
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

        #endregion Project Default

        #region Project Load
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tlsProjectOpen_Click(object sender, EventArgs e)
        {
            ProjectLoad();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectLoad()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Title = DriverPhrases.TitleLoadProject;
            OFD.Filter = DriverPhrases.FilterProject;
            OFD.InitialDirectory = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath);

            if (OFD.ShowDialog() == DialogResult.OK && OFD.FileName != "")
            {
                pathProject = OFD.FileName;
                ProjectLoad(pathProject);
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectLoad(string fileName)
        {
            if (File.Exists(fileName))
            {
                project = ProjectFile.LoadXml(typeof(Project), fileName) as Project;
                DeserializeTreeView(trvProject, project);
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public void DeserializeTreeView(System.Windows.Forms.TreeView treeView, Project project)
        {
            try
            {
                treeView.Nodes.Clear();
                treeView.BeginUpdate();

                ProjectDriver projectDriver = project.Driver;
                TreeNode nodeDriver = NodeProjectDriverAdd(projectDriver, null);

                ProjectSettings projectSettings = projectDriver.Settings;
                TreeNode nodeSettings = NodeProjectSettingsAdd(projectSettings, null, nodeDriver);

                ProjectGroupChannel projectGroupChannel = projectDriver.GroupChannel;
                TreeNode nodeGroupChannel = NodeProjectGroupChannelAdd(projectGroupChannel, cmnuChannelAppend, nodeDriver);
                foreach (ProjectChannel projectChannel in projectGroupChannel.Group)
                {
                    TreeNode nodeChannel = NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend, nodeGroupChannel);
                    foreach (ProjectDevice projectDevice in projectChannel.Devices)
                    {
                        TreeNode nodeDevice = NodeProjectDeviceAdd(projectDevice, cmnuDeviceDelete, nodeChannel);

                        ProjectGroupCommand projectGroupCommand = projectDevice.GroupCommand;
                        TreeNode nodeGroupCommand = NodeGroupCommandAdd(projectGroupCommand, cmnuCommandAppend, nodeDevice);

                        foreach (ProjectCommand projectCommand in projectGroupCommand.ListCommands)
                        {
                            TreeNode nodeCommand = NodeCommandAdd(projectCommand, cmnuCommandDelete, nodeGroupCommand);
                        }

                        ProjectGroupTag projectGroupTag = projectDevice.GroupTag;
                        TreeNode nodeGroupTag = NodeGroupTagAdd(projectGroupTag, cmnuTagAppend, nodeDevice);
                    }
                }

                treeView.EndUpdate();
            }
            catch { }

            treeView.Refresh();
            treeView.ExpandAll();
        }

        #endregion Project Load

        #region Project Save
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tlsProjectSave_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void SaveProject()
        {
            if (String.IsNullOrEmpty(pathProject))
            {
                if (appDirs != null)
                {
                    pathProject = Path.Combine(appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
                }
                else
                {
                    pathProject = Path.Combine(DriverUtils.GetFileName(deviceNum));
                }

                project = SerializeTreeView(trvProject);
                project.Save(pathProject, out string errMsg);
                if (!String.IsNullOrEmpty(errMsg))
                {
                    MessageBox.Show(errMsg);
                }
            }
            else
            {
                project = SerializeTreeView(trvProject);
                project.Save(pathProject, out string errMsg);
                if (!String.IsNullOrEmpty(errMsg))
                {
                    MessageBox.Show(errMsg);
                }
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public Project SerializeTreeView(System.Windows.Forms.TreeView treeView)
        {
            project = new Project();

            // save the nodes, recursive method
            foreach (TreeNode tnLevel00 in treeView.Nodes)
            {
                ProjectNodeData prLevel00Node = (ProjectNodeData)tnLevel00.Tag;

                #region Driver
                if (prLevel00Node.NodeType == ProjectNodeType.Driver)
                {
                    ProjectDriver projectDriver = (ProjectDriver)prLevel00Node.Driver;
                    project.Driver = projectDriver;

                    foreach (TreeNode tnLevel01 in tnLevel00.Nodes)
                    {
                        ProjectNodeData prLevel01Node = (ProjectNodeData)tnLevel01.Tag;

                        #region Settings
                        if (prLevel01Node.NodeType == ProjectNodeType.Settings)
                        {
                            ProjectSettings settings = (ProjectSettings)prLevel01Node.Settings;
                            project.Driver.Settings = settings;
                        }
                        #endregion Settings

                        #region Group Channel
                        if (prLevel01Node.NodeType == ProjectNodeType.GroupChannel)
                        {
                            ProjectGroupChannel groupChannel = (ProjectGroupChannel)prLevel01Node.GroupChannel;

                            #region Channel
                            foreach (TreeNode tnLevel02 in tnLevel01.Nodes)
                            {
                                ProjectNodeData prLevel02Node = (ProjectNodeData)tnLevel02.Tag;

                                if (prLevel02Node.NodeType == ProjectNodeType.Channel)
                                {
                                    ProjectChannel channel = (ProjectChannel)prLevel02Node.Channel;
                                    List<ProjectDevice> listDevices = new List<ProjectDevice>();
                                    foreach (TreeNode tnLevel03 in tnLevel02.Nodes)
                                    {
                                        ProjectNodeData prLevel03Node = (ProjectNodeData)tnLevel03.Tag;

                                        if (prLevel03Node.NodeType == ProjectNodeType.Device)
                                        {
                                            ProjectDevice device = (ProjectDevice)prLevel03Node.Device;

                                            foreach (TreeNode tnLevel04 in tnLevel03.Nodes)
                                            {
                                                ProjectNodeData prLevel04Node = (ProjectNodeData)tnLevel04.Tag;

                                                if (prLevel04Node.NodeType == ProjectNodeType.GroupCommand)
                                                {
                                                    ProjectGroupCommand groupCommand = (ProjectGroupCommand)prLevel04Node.GroupCommand;

                                                    foreach (TreeNode tnLevel05 in tnLevel04.Nodes)
                                                    {
                                                        ProjectNodeData prLevel05Node = (ProjectNodeData)tnLevel05.Tag;

                                                        if (prLevel05Node.NodeType == ProjectNodeType.Command)
                                                        {
                                                            ProjectCommand command = (ProjectCommand)prLevel05Node.Command;
                                                            groupCommand.ListCommands.Add(command);
                                                        }
                                                    }

                                                    device.GroupCommand = groupCommand;
                                                }

                                                if (prLevel04Node.NodeType == ProjectNodeType.GroupTag)
                                                {
                                                    ProjectGroupTag groupTag = (ProjectGroupTag)prLevel04Node.GroupTag;

                                                    device.GroupTag = groupTag;
                                                }
                                            }
                                            listDevices.Add(device);

                                        }
                                        channel.Devices = listDevices;
                                    }

                                    groupChannel.Group.Add(channel);
                                }
                            }
                            #endregion Channel

                            project.Driver.GroupChannel = groupChannel;
                        }

                        #endregion Group Channel
                    }
                }

                #endregion Driver

            }

            return project;

        }
        #endregion Project Save

        #region Save As
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tlsProjectSaveAs_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void SaveProjectAs()
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Title = DriverPhrases.TitleLoadProject;
            SFD.Filter = DriverPhrases.FilterProject;

            if (String.IsNullOrEmpty(pathProject))
            {
                if (appDirs != null)
                {
                    pathProject = Path.Combine(appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
                }
            }

            SFD.InitialDirectory = pathProject;

            if (SFD.ShowDialog() == DialogResult.OK && SFD.FileName != "")
            {
                pathProject = SFD.FileName;

                //SerializeTreeView(trvProject, pathProject);
            }
        }

        #endregion Save As

        #region Project Default
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public void GetDefaultTreeNodes()
        {
            #region Driver
            ProjectDriver projectDriver = new ProjectDriver();
            projectDriver.Name = DriverPhrases.DriverName;
            projectDriver.Settings = new ProjectSettings();
            projectDriver.GroupChannel = new ProjectGroupChannel();
            //Добавляем в дерево
            TreeNode driverNode = NodeProjectDriverAdd(projectDriver, null);
            //Добавляем в проект
            project.Driver = projectDriver;
            #endregion Driver

            #region Settings
            ProjectSettings settings = new ProjectSettings();
            settings.Name = DriverPhrases.SettingsName;
            settings.AutoRun = false;
            settings.Debug = false;
            settings.SaveRegisters = false;

            //Добавляем в дерево
            TreeNode settingsNode = NodeProjectSettingsAdd(settings, null, driverNode);
            //Добавляем в проект
            project.Driver.Settings = settings;
            #endregion Settings

            #region Group Channel
            ProjectGroupChannel groupChannel = new ProjectGroupChannel();
            groupChannel.Name = DriverPhrases.GroupChannelName;
            groupChannel.ID = Guid.NewGuid();

            TreeNode groupChannelNode = NodeProjectGroupChannelAdd(groupChannel, cmnuChannelAppend, driverNode);

            #endregion Group Channel

            #region Channel
            ProjectChannel projectChannel = new ProjectChannel();
            projectChannel.KeyImage = ListImages.ImageKey.ChannelEmpty;
            projectChannel.ID = Guid.NewGuid();
            projectChannel.Name = DriverPhrases.ChannelName;
            projectChannel.Description = "";
            projectChannel.Enabled = true;

            projectChannel.TcpServerSettings.Protocol = 0;
            projectChannel.TcpServerSettings.Port = 60000;
            projectChannel.TcpServerSettings.ConnectedClientsMax = 10;

            projectChannel.WriteTimeout = 1000;
            projectChannel.ReadTimeout = 1000;
            projectChannel.Timeout = 1000;

            projectChannel.WriteBufferSize = 8192;
            projectChannel.ReadBufferSize = 8192;

            projectChannel.CountError = 3;
            //Добавляем в дерево
            TreeNode channelNode = NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend, groupChannelNode);
            //Добавляем в проект
            project.Driver.GroupChannel.Group.Add(projectChannel);
            #endregion Channel

            #region Device
            ProjectDevice projectDevice = new ProjectDevice();
            projectDevice.ParentID = projectChannel.ID;
            projectDevice.ID = Guid.NewGuid();
            projectDevice.Name = DriverPhrases.DeviceName;
            projectDevice.Description = "";
            projectDevice.Enabled = true;
            projectDevice.Status = 0;                           // статус Неизвестно
            projectDevice.DeviceRegistersBytes = 2;             // 2 регистра по умолчанию
            projectDevice.DeviceGatewayRegistersBytes = 2;      // 2 регистра по умолчанию (шлюз)
            projectDevice.Address = 1;
            projectDevice.DateTimeLastSuccessfully = new DateTime(2000, 1, 1, 0, 0, 0);

            //Добавление регистров 65535
            for (ulong index = 0; index < (ulong)65535; ++index)
            {
                bool status = false;
                ulong value = 0;

                projectDevice.SetCoil(Convert.ToUInt64(index), status);
                projectDevice.SetDiscreteInput(Convert.ToUInt64(index), status);
                projectDevice.SetHoldingRegister(Convert.ToUInt64(index), value);
                projectDevice.SetInputRegister(Convert.ToUInt64(index), value);
                projectDevice.SetDataBuffer(Convert.ToUInt64(index), string.Empty);
            }

            //Иницилизация групп
            projectDevice.GroupCommand = new ProjectGroupCommand();
            projectDevice.GroupTag = new ProjectGroupTag();

            //Делаем активно меню 
            TreeNode deviceNode = NodeProjectDeviceAdd(projectDevice, cmnuDeleteAction, channelNode);

            //Добавляем группу комманд
            ProjectGroupCommand projectGroupCommand = new ProjectGroupCommand();
            projectGroupCommand.ParentID = projectDevice.ID;
            projectGroupCommand.ID = Guid.NewGuid();
            projectGroupCommand.Enabled = true;
            projectGroupCommand.Name = DriverPhrases.GroupCommandName;
            projectGroupCommand.ListCommands = new List<ProjectCommand>();

            projectDevice.GroupCommand = projectGroupCommand;
            //Добавляем в дерево
            TreeNode groupCommandNode = NodeGroupCommandAdd(projectGroupCommand, cmnuCommandAppend, deviceNode);

            //Добавляем группу тегов
            ProjectGroupTag projectGroupTag = new ProjectGroupTag();
            projectGroupTag.ParentID = projectDevice.ID;
            projectGroupTag.ID = Guid.NewGuid();
            projectGroupTag.Enabled = true;
            projectGroupTag.Name = DriverPhrases.GroupTagName;
            projectGroupTag.ListTags = new List<ProjectTag>();

            projectDevice.GroupTag = projectGroupTag;
            //Добавляем в дерево
            TreeNode groupTagNode = NodeGroupTagAdd(projectGroupTag, null, deviceNode);

            //Добавляем в проект
            projectChannel.Devices.Add(projectDevice);

            deviceNode.ExpandAll();
            #endregion Device

        }
        #endregion Project Default

        #region Project Driver
        // adding to the tree
        // добавляем в дерево
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeProjectDriverAdd(ProjectDriver drv, ContextMenuStrip cms)
        {
            TreeNode tn = new TreeNode(drv.Name);
            tn.Text = drv.Name;

            string imageKey = ListImages.ImageKey.Driver;

            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

            this.trvProject.Nodes.Add(tn);

            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.Driver = drv;
            ProjectNodeData.NodeType = ProjectNodeType.Driver;

            tn.ContextMenuStrip = cms;
            tn.Tag = ProjectNodeData;

            return tn;
        }
        #endregion Project Driver

        #region Project Settings
        // adding to the tree
        // добавляем в дерево
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeProjectSettingsAdd(ProjectSettings stg, ContextMenuStrip cms, TreeNode ptn = null)
        {
            TreeNode tn = new TreeNode(stg.Name);
            tn.Text = stg.Name;

            string imageKey = ListImages.ImageKey.Settings;

            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.Settings = stg;
            ProjectNodeData.NodeType = ProjectNodeType.Settings;

            tn.ContextMenuStrip = cms;
            tn.Tag = ProjectNodeData;

            ptn.Nodes.Add(tn);
            ptn.Expand();

            return tn;
        }
        #endregion Project Settings

        #region Project Group Channel
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public void ProjectGroupChannelsAdd()
        {
            ProjectGroupChannel projectGroupChannel = new ProjectGroupChannel();
            projectGroupChannel.KeyImage = ListImages.ImageKey.GroupChannel;
            projectGroupChannel.ID = Guid.NewGuid();
            projectGroupChannel.Name = DriverPhrases.GroupChannelName;

            // Добавляем в дерево
            NodeProjectGroupChannelAdd(projectGroupChannel, cmnuDeviceAppend);
        }

        // add tree
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeProjectGroupChannelAdd(ProjectGroupChannel pgc, ContextMenuStrip cms, TreeNode ptn = null)
        {
            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.GroupChannel = pgc;
            ProjectNodeData.NodeType = ProjectNodeType.GroupChannel;

            TreeNode tn = new TreeNode(DriverPhrases.GroupChannelName);
            tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.GroupChannel;
            tn.ContextMenuStrip = cms;
            tn.Tag = ProjectNodeData;

            ptn.Nodes.Add(tn);
            ptn.Expand();

            return tn;
        }

        #endregion Project List Channels

        #region Project Channel
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public void ProjectChannelAdd()
        {
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;
            TreeNode parentNode = null;
            ProjectGroupChannel projectGroupChannel = new ProjectGroupChannel();

            if (selectNode != null)
            {
                parentNode = selectNode;
                ProjectNodeData nodeData = (ProjectNodeData)parentNode.Tag;
                projectGroupChannel = nodeData.GroupChannel;
            }
            else
            {
                return;
            }

            ProjectChannel projectChannel = new ProjectChannel();
            projectChannel.KeyImage = ListImages.ImageKey.ChannelEmpty;
            projectChannel.ID = Guid.NewGuid();
            projectChannel.Name = DriverPhrases.ChannelName;
            projectChannel.Description = "";
            projectChannel.Enabled = true;
            //projectChannel.GatewayTypeProtocol = 0;
            //projectChannel.GatewayPort = 60000;
            //projectChannel.GatewayConnectedClientsMax = 10;

            projectChannel.WriteTimeout = 1000;
            projectChannel.ReadTimeout = 1000;
            projectChannel.Timeout = 1000;

            projectChannel.WriteBufferSize = 8192;
            projectChannel.ReadBufferSize = 8192;

            projectChannel.CountError = 3;
            // добавляем в дерево
            NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend, parentNode);
        }

        //Добавляем в дерево
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeProjectChannelAdd(ProjectChannel cnl, ContextMenuStrip cms, TreeNode ptn = null)
        {
            TreeNode tn = new TreeNode(cnl.Name);
            tn.Text = cnl.Name;

            string imageKey = string.Empty;
            switch (cnl.TypeClient)
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

            cnl.KeyImage = imageKey;
            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

            ProjectNodeData nodeData = new ProjectNodeData();
            nodeData.Channel = cnl;
            nodeData.NodeType = ProjectNodeType.Channel;

            tn.ContextMenuStrip = cms;
            tn.Tag = nodeData;

            ptn.Nodes.Add(tn);
            ptn.Expand();

            return tn;
        }
        #endregion Project Channel

        #region Project Device
        //Добавление устройства
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public void ProjectDeviceAdd()
        {
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;
            TreeNode parentNode = null;
            ProjectChannel projectChannel = new ProjectChannel();

            if (selectNode != null)
            {
                parentNode = selectNode;
                ProjectNodeData nodeData = (ProjectNodeData)parentNode.Tag;
                projectChannel = nodeData.Channel;
            }
            else
            {
                return;
            }

            ProjectDevice projectDevice = new ProjectDevice();
            projectDevice.ParentID = projectChannel.ID;

            projectDevice.Name = DriverPhrases.DeviceName;
            projectDevice.Description = "";
            projectDevice.ID = Guid.NewGuid();
            projectDevice.Enabled = true;
            projectDevice.Status = 0;                           // статус Неизвестно
            projectDevice.DeviceRegistersBytes = 2;             // 2 регистра по умолчанию
            projectDevice.DeviceGatewayRegistersBytes = 2;      // 2 регистра по умолчанию (шлюз)
            projectDevice.Address = 1;
            projectDevice.DateTimeLastSuccessfully = new DateTime(2000, 1, 1, 0, 0, 0);

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

            projectDevice.GroupCommand = new ProjectGroupCommand();
            projectDevice.GroupTag = new ProjectGroupTag();

            //Делаем активно меню 
            TreeNode deviceNode = NodeProjectDeviceAdd(projectDevice, cmnuDeviceDelete, parentNode);

            //Добавляем группу комманд
            ProjectGroupCommand projectGroupCommand = new ProjectGroupCommand();
            projectGroupCommand.ParentID = projectDevice.ID;
            projectGroupCommand.ID = Guid.NewGuid();
            projectGroupCommand.Enabled = true;
            projectGroupCommand.Name = DriverPhrases.GroupCommandName;
            projectGroupCommand.ListCommands = new List<ProjectCommand>();

            projectDevice.GroupCommand = projectGroupCommand;
            //Добавляем в дерево
            TreeNode groupCommandNode = NodeGroupCommandAdd(projectGroupCommand, cmnuCommandAppend, deviceNode);

            //Добавляем группу тегов
            ProjectGroupTag projectGroupTag = new ProjectGroupTag();
            projectGroupTag.ParentID = projectDevice.ID;
            projectGroupTag.ID = Guid.NewGuid();
            projectGroupTag.Enabled = true;
            projectGroupTag.Name = DriverPhrases.GroupTagName;
            projectGroupTag.ListTags = new List<ProjectTag>();

            projectDevice.GroupTag = projectGroupTag;
            //Добавляем в дерево
            TreeNode groupTagNode = NodeGroupTagAdd(projectGroupTag, null, deviceNode);
        }

        //Добавляем в дерево
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeProjectDeviceAdd(ProjectDevice dev, ContextMenuStrip cms, TreeNode ptn = null)
        {
            TreeNode tn = new TreeNode(dev.Name);

            string imageKey = ListImages.ImageKey.Device;
            dev.KeyImage = imageKey;
            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);
            tn.ContextMenuStrip = cms;

            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.Device = ((ProjectNodeData)ptn.Tag).Device;
            ProjectNodeData.NodeType = ProjectNodeType.Device;
            ProjectNodeData.Device = dev;
            tn.Tag = ProjectNodeData;

            ptn.Nodes.Add(tn);
            ptn.Expand();

            return tn;
        }
        #endregion Project Device

        #region GroupCommand
        //Добавление группы команд
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeGroupCommandAdd(ProjectGroupCommand grpCmd, ContextMenuStrip cms, TreeNode ptn = null)
        {
            TreeNode tn = new TreeNode(grpCmd.Name);

            string imageKey = ListImages.ImageKey.GroupCmd;
            grpCmd.KeyImage = imageKey;
            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

            tn.ContextMenuStrip = cms;
            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.GroupCommand = ((ProjectNodeData)ptn.Tag).GroupCommand;
            ProjectNodeData.NodeType = ProjectNodeType.GroupCommand;
            ProjectNodeData.GroupCommand = grpCmd;
            tn.Tag = ProjectNodeData;

            ptn.Nodes.Add(tn);
            ptn.Expand();

            return tn;
        }
        #endregion GroupCommand

        #region Command
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectCommandAdd(ulong command)
        {
            ProjectCommand projectCommand = new ProjectCommand();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectGroupCommand projectGroupCommand = ((ProjectNodeData)selectNode.Tag).GroupCommand;
            Guid ParentID = projectGroupCommand.ID;

            projectCommand.ParentID = ParentID;
            projectCommand.ID = Guid.NewGuid();
            projectCommand.KeyImage = ProjectCommand.KeyImageName(command);
            projectCommand.Enabled = true;
            projectCommand.FunctionCode = command;
            projectCommand.RegisterStartAddress = 0;
            projectCommand.RegisterCount = 1;
            projectCommand.Name = projectCommand.GenerateName();
            projectCommand.Description = "";

            //Добавляем в дерево
            NodeCommandAdd(projectCommand, cmnuCommandDelete, selectNode);
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeCommandAdd(ProjectCommand devCmd, ContextMenuStrip cms, TreeNode ptn = null)
        {
            TreeNode tn = new TreeNode(devCmd.Name);

            tn.ImageKey = tn.SelectedImageKey = ProjectCommand.KeyImageName(devCmd.FunctionCode);

            ptn.Nodes.Add(tn);
            tn.ContextMenuStrip = cms;
            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.Command = ((ProjectNodeData)ptn.Tag).Command;
            ProjectNodeData.NodeType = ProjectNodeType.Command;
            ProjectNodeData.Command = devCmd;
            tn.Tag = ProjectNodeData;
            ptn.Expand();
            return tn;
        }
        #endregion Command

        #region Group Tag
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeGroupTagAdd(ProjectGroupTag grpTgs, ContextMenuStrip cms, TreeNode ptn = null)
        {
            TreeNode tn = new TreeNode(grpTgs.Name);

            string imageKey = ListImages.ImageKey.GroupTag;
            grpTgs.KeyImage = imageKey;
            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

            ptn.Nodes.Add(tn);
            tn.ContextMenuStrip = cms;

            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.GroupTag = ((ProjectNodeData)ptn.Tag).GroupTag;
            ProjectNodeData.NodeType = ProjectNodeType.GroupTag;
            ProjectNodeData.GroupTag = grpTgs;
            tn.Tag = ProjectNodeData;
            ptn.Expand();
            return tn;
        }

        #endregion Group Tag

        #region Tag
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectTagAdd()
        {
            ProjectTag projectTag = new ProjectTag();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectGroupTag projectGroupTag = ((ProjectNodeData)selectNode.Tag).GroupTag;
            Guid ParentID = projectGroupTag.ParentID;
            Guid DeviceID = projectGroupTag.ID;

            //projectTag.DeviceID = DeviceID;
            projectTag.ParentID = ParentID;
            projectTag.ID = Guid.NewGuid();
            projectTag.Enabled = true;
            projectTag.Address = "";
            projectTag.Name = DriverPhrases.TagName;
            projectTag.Description = "";
            projectTag.Coefficient = 1;

            projectTag.Scaled = 0;
            projectTag.ScaledHigh = 1000;
            projectTag.ScaledLow = 0;
            projectTag.RowHigh = 1000;
            projectTag.RowLow = 0;

            //Добавляем в дерево
            NodeDeviceTagAdd(projectTag, selectNode, null);
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public TreeNode NodeDeviceTagAdd(ProjectTag devTag, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
                TreeNode tn = new TreeNode(devTag.Name);
                devTag.KeyImage = tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.Tag;
                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.Tag = ((ProjectNodeData)ptn.Tag).Tag;
                ProjectNodeData.NodeType = ProjectNodeType.Tag;
                ProjectNodeData.Tag = devTag;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
        }
        #endregion Tag

        #region Project NodeDelete
        // delete node
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectNodeDelete()
        {
            TreeNode selectNode = trvProject.SelectedNode;
            string text = selectNode.Text;
            DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", "", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == dr)
            {
                selectNode.Remove();
            }
        }
        #endregion Project NodeDelete

        #region Project Moving elements
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectNodeElementUp()
        {
            try
            {
                TreeNode selectedNode = trvProject.SelectedNode;
                if (selectedNode == null)
                {
                    return;
                }
                TreeNode treeNode = selectedNode.PrevNode;
                if (treeNode == null)
                {
                    return;
                }
                TreeNode parent = selectedNode.Parent;
                if (parent == null)
                {
                    return;
                }
                parent.Nodes.Remove(selectedNode);
                parent.Nodes.Insert(treeNode.Index, selectedNode);
                trvProject.SelectedNode = selectedNode;
            }
            catch { }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectNodeElementDown()
        {
            try
            {
                TreeNode selectedNode = trvProject.SelectedNode;
                if (selectedNode == null)
                {
                    return;
                }
                TreeNode nextNode = selectedNode.NextNode;
                if (nextNode == null)
                {
                    return;
                }
                TreeNode parent = selectedNode.Parent;
                if (parent == null)
                {
                    return;
                }
                parent.Nodes.Remove(selectedNode);
                parent.Nodes.Insert(nextNode.Index + 1, selectedNode);
                trvProject.SelectedNode = selectedNode;
            }
            catch { }
        }

        #endregion Project Moving elements

        #region TreeView trvProject. Selection of nodes and elements on the project
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void trvProject_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TreeViewHitTestInfo htInfo = trvProject.HitTest(e.X, e.Y);
                TreeNode selectNode = htInfo.Node;

                if (selectNode == null)
                {
                    trvProject.SelectedNode = null;
                    trvProject.HideSelection = true;
                }
                else
                {
                    trvProject.SelectedNode = selectNode;

                    // the ban on the transition
                    mtNodeData = (ProjectNodeData)selectNode.Tag;

                    if (selectNode != null)
                    {
                        LoadWindow(mtNodeData);
                    }

                    trvProject.HideSelection = false;
                }
            }
            catch { }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void LoadWindow(ProjectNodeData mtNodeData)
        {
            if (trvProject.SelectedNode == null)
            {
                return;
            }

            // checking tabs
            ValidateTabPage();

            // form
            if (mtNodeData.NodeType == ProjectNodeType.Driver && mtNodeData.Driver != null)
            {
                FrmEmpty frmEmpty = new FrmEmpty();
                frmPropertyForm = new Form();
                frmPropertyForm = frmEmpty;
            }
            else if (mtNodeData.NodeType == ProjectNodeType.Settings && mtNodeData.Settings != null)
            {
                FrmSettings frmSettings = new FrmSettings(ref mtNodeData, true);
                frmSettings.formParent = formParent;
                frmSettings.project = project;

                frmPropertyForm = new Form();
                frmPropertyForm = frmSettings;
            }
            else if (mtNodeData.NodeType == ProjectNodeType.Channel && mtNodeData.Channel != null)
            {
                FrmChannel frmChannel = new FrmChannel(ref mtNodeData, true);
                frmChannel.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmChannel;
            }
            else if (mtNodeData.NodeType == ProjectNodeType.Device && mtNodeData.Device != null)
            {
                FrmDevice frmDevice = new FrmDevice(ref mtNodeData, true);
                frmDevice.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmDevice;
            }
            else if (mtNodeData.NodeType == ProjectNodeType.GroupCommand && mtNodeData.GroupCommand != null)
            {

            }
            else if (mtNodeData.NodeType == ProjectNodeType.Command && mtNodeData.Command != null)
            {
                switch (mtNodeData.Command.FunctionCode)
                {
                    case ulong n when (n >= 1 && n <= 4):
                        FrmCommand1_2_3_4 frmCommand = new FrmCommand1_2_3_4(ref mtNodeData, true);
                        frmCommand.frmParentGloabal = this;
                        frmPropertyForm = new Form();
                        frmPropertyForm = frmCommand;
                        break;
                }
            }
            else if (mtNodeData.NodeType == ProjectNodeType.GroupTag && mtNodeData.GroupTag != null)
            {
                FrmGroupTag frmGroupTag = new FrmGroupTag(ref mtNodeData, true);
                frmGroupTag.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmGroupTag;
                frmPropertyForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                FrmEmpty frmEmpty = new FrmEmpty();
                frmEmpty.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmEmpty;
            }

            try
            {
                tabControl.ImageList = imgList;

                TabPage tabPageNew = new TabPage(trvProject.SelectedNode.Text);
                tabPageNew.Name = trvProject.SelectedNode.Text;
                tabPageNew.Text = trvProject.SelectedNode.Text;
                tabPageNew.ImageKey = trvProject.SelectedNode.SelectedImageKey;
                tabPageNew.ImageIndex = imgList.Images.IndexOfKey(trvProject.SelectedNode.SelectedImageKey);
                tabPageNew.Controls.Add(frmPropertyForm);

                tabControl.TabPages.Add(tabPageNew);
                tabControl.SelectedTab = tabPageNew;

                frmPropertyForm.Dock = DockStyle.Fill;
                frmPropertyForm.Show();
            }
            catch (System.ObjectDisposedException) { }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ValidateTabPage()
        {
            if (frmPropertyForm != null)
            {
                frmPropertyForm.Close();
                frmPropertyForm.Dispose();
            }

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabControl.Controls.Remove(tabPage);
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void trvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectNode = trvProject.SelectedNode;
            mtNodeData = (ProjectNodeData)selectNode.Tag;
        }

        #endregion TreeView trvProject

        #region Menu
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void cmnuChannelAdd_Click(object sender, EventArgs e)
        {
            ProjectChannelAdd();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void cmnuDeviceAdd_Click(object sender, EventArgs e)
        {
            ProjectDeviceAdd();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void cmnuCommandAdd_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Tag.ToString())
            {
                case "READCOILS":
                    {
                        ProjectCommandAdd(1);
                        break;
                    }
                case "READINPUTS":
                    {
                        ProjectCommandAdd(2);
                        break;
                    }
                case "READHOLDINGREGISTERS":
                    {
                        ProjectCommandAdd(3);
                        break;
                    }
                case "READINPUTREGISTERS":
                    {
                        ProjectCommandAdd(4);
                        break;
                    }
                case "WRITECOIL":
                    {
                        ProjectCommandAdd(5);
                        break;
                    }
                case "WRITEHOLDINGREGISTER":
                    {
                        ProjectCommandAdd(6);
                        break;
                    }
                case "WRITEMULTIPLECOILS":
                    {
                        ProjectCommandAdd(15);
                        break;
                    }
                case "WRITEMULTIPLEHOLDINGREGISTERS":
                    {
                        ProjectCommandAdd(16);
                        break;
                    }
                case "ARBITRARY":
                    {
                        ProjectCommandAdd(99);
                        break;
                    }
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void cmnuDeleteGroup_Click(object sender, EventArgs e)
        {
            ProjectNodeDelete();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void cmnuDeleteVariable_Click(object sender, EventArgs e)
        {
            ProjectNodeDelete();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void сmnuSelectVariableUp_Click(object sender, EventArgs e)
        {
            ProjectNodeElementUp();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void сmnuSelectVariableDown_Click(object sender, EventArgs e)
        {
            ProjectNodeElementDown();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void сmnuSelectVariableActionUp_Click(object sender, EventArgs e)
        {
            ProjectNodeElementUp();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void сmnuSelectVariableActionDown_Click(object sender, EventArgs e)
        {
            ProjectNodeElementDown();
        }
        #endregion Menu

        #endregion Project


       




    }
}
