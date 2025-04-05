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
        private void FrmConfig_Load(object sender, EventArgs e)
        {
            LoadLanguage(languageDir, isRussian);
            Translate();

            Text = string.Format(Text, deviceNum, DriverUtils.Version);
        }
        #endregion Form Load

        #region Form Close
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

        #region Config
        /// <summary>
        /// Load data
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

        private void mnuLoadProject_Click(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void tlsProjectOpen_Click(object sender, EventArgs e)
        {
            LoadProject();
        }

        private void LoadProject()
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

        private void ProjectLoad(string fileName)
        {
            if (File.Exists(fileName))
            {
                project = ProjectFile.LoadXml(typeof(Project), fileName) as Project;
                DeserializeTreeView(trvProject, project);
            }
        }

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
                foreach(ProjectChannel projectChannel in projectGroupChannel.Group)
                {
                    TreeNode nodeChannel = NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend, nodeGroupChannel);
                    foreach(ProjectDevice projectDevice in projectChannel.Devices)
                    {
                        TreeNode nodeDevice = NodeProjectDeviceAdd(projectDevice, cmnuDeviceDelete, nodeChannel);
                        
                        ProjectGroupCommand projectGroupCommand = projectDevice.GroupCommand;
                        TreeNode nodeGroupCommand = NodeGroupCommandAdd(projectGroupCommand, cmnuCommandAppend, nodeDevice);
                       
                        foreach(ProjectCommand projectCommand in projectGroupCommand.ListCommands)
                        {
                            TreeNode nodeCommand = NodeCommandAdd(projectCommand, cmnuCommandDelete, nodeGroupCommand);
                        }
                        
                        ProjectGroupTag projectGroupTag = projectDevice.GroupTag;
                        TreeNode nodeGroupTag = NodeGroupTagAdd(projectGroupTag, cmnuTagAppend,nodeDevice);
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

        private void mnuSaveProject_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void tlsProjectSave_Click(object sender, EventArgs e)
        {
            SaveProject();
        }


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
                //SerializeTreeView(trvProject, pathProject);
            }
        }

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
                                    foreach(TreeNode tnLevel03 in tnLevel02.Nodes)
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

        private void tlsProjectSaveAs_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        private void mnuSaveAsProject_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

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

        //Удаление устройства
        //private void ProjectDeviceDelete()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;
        //    ProjectChannel projectChannel = ((ProjectNodeData)selectNode.Parent.Tag).channel;
        //    ProjectDevice projectDevice = ((ProjectNodeData)selectNode.Tag).Device;
        //    string text = selectNode.Text;
        //    DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
        //    if (DialogResult.Yes == dr)
        //    {
        //        projectChannel.Devices.Remove(projectDevice);
        //        selectNode.Remove();
        //    }
        //}

        #endregion Project Device

        #region GroupCommand
        //Добавление группы команд
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

        //Добавление команды Modbus
        //private void CommandAdd(ulong function)
        //{

        //    if (function > 0 && function < 8)
        //    {
        //        //Создали форму
        //        frm_ModbusDeviceCommand frm_modbusdevice_command = new frm_ModbusDeviceCommand(false, function);
        //        //Передали шаблонные параметры
        //        frm_modbusdevice_command.DeviceCommandID = Guid.NewGuid();
        //        frm_modbusdevice_command.DeviceCommandEnabled = true;
        //        //Показываем форму
        //        DialogResult dialog = frm_modbusdevice_command.ShowDialog();

        //        //Если закрыли форму, через кнопку Ок
        //        if (DialogResult.OK == dialog)
        //        {
        //            //В дереве выбран объект
        //            TreeNode selectNode = trvProject.SelectedNode;
        //            Guid ParentID = ((ProjectNodeData)selectNode.Tag).GroupCommand.ID;

        //            //Добавляем ModbusCommand
        //            MODBUS_DEVICE_COMMAND modbus_device_command = new MODBUS_DEVICE_COMMAND();
        //            modbus_device_command.DeviceID = ParentID;
        //            modbus_device_command.DeviceCommandID = Guid.NewGuid();
        //            modbus_device_command.DeviceCommandName = frm_modbusdevice_command.DeviceCommandName;
        //            modbus_device_command.DeviceCommandDescription = frm_modbusdevice_command.DeviceCommandDescription;
        //            modbus_device_command.DeviceCommandEnabled = frm_modbusdevice_command.Enabled;
        //            modbus_device_command.DeviceCommandFunctionCode = frm_modbusdevice_command.DeviceCommandFunctionCode;
        //            modbus_device_command.DeviceCommandRegisterStartAddress = frm_modbusdevice_command.DeviceCommandRegisterStartAddress;
        //            modbus_device_command.DeviceCommandRegisterCount = frm_modbusdevice_command.DeviceCommandRegisterCount;
        //            modbus_device_command.DeviceCommandRegisterNameWriteData = frm_modbusdevice_command.DeviceCommandRegisterNameWriteData;
        //            modbus_device_command.DeviceCommandRegisterWriteData = frm_modbusdevice_command.DeviceCommandRegisterWriteData;

        //            trvProject.NodeCommand(modbus_device_command, selectNode, null);
        //        }
        //    }
        //    else if (function == 99)
        //    {
        //        //Создали форму
        //        frm_ModbusDeviceCommandArbitrary frm_modbusdevice_command_arbitrary = new frm_ModbusDeviceCommandArbitrary(false, function);
        //        //Передали шаблонные параметры
        //        frm_modbusdevice_command_arbitrary.DeviceCommandID = Guid.NewGuid();
        //        frm_modbusdevice_command_arbitrary.DeviceCommandEnabled = true;
        //        //Показываем форму
        //        DialogResult dialog = frm_modbusdevice_command_arbitrary.ShowDialog();

        //        //Если закрыли форму, через кнопку Ок
        //        if (DialogResult.OK == dialog)
        //        {
        //            //В дереве выбран объект
        //            TreeNode selectNode = trv_Project.SelectedNode;
        //            Guid ParentID = ((xGateway.ProjectNodeData)selectNode.Tag).modbus_device_group_command.DeviceID;

        //            //Добавляем ModbusCommand
        //            MODBUS_DEVICE_COMMAND modbus_device_command = new MODBUS_DEVICE_COMMAND();
        //            modbus_device_command.DeviceID = ParentID;
        //            modbus_device_command.DeviceCommandID = Guid.NewGuid();
        //            modbus_device_command.DeviceCommandName = frm_modbusdevice_command_arbitrary.DeviceCommandName;
        //            modbus_device_command.DeviceCommandDescription = frm_modbusdevice_command_arbitrary.DeviceCommandDescription;
        //            modbus_device_command.DeviceCommandEnabled = frm_modbusdevice_command_arbitrary.Enabled;
        //            modbus_device_command.DeviceCommandFunctionCode = frm_modbusdevice_command_arbitrary.DeviceCommandFunctionCode;
        //            modbus_device_command.DeviceCommandRegisterStartAddress = frm_modbusdevice_command_arbitrary.DeviceCommandRegisterStartAddress;
        //            modbus_device_command.DeviceCommandRegisterCount = frm_modbusdevice_command_arbitrary.DeviceCommandRegisterCount;
        //            modbus_device_command.DeviceCommandRegisterNameWriteData = frm_modbusdevice_command_arbitrary.DeviceCommandRegisterNameWriteData;
        //            modbus_device_command.DeviceCommandRegisterWriteData = frm_modbusdevice_command_arbitrary.DeviceCommandRegisterWriteData;

        //            trv_Project.NodeAddModbusDeviceCommand(modbus_device_command, selectNode, null);
        //        }
        //    }
        //    else
        //    {

        //    }
        //}




        #endregion Command

        #region DeviceGroupTag
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

            return null;
        }

        #endregion DeviceGroupTag

        #region DeviceTag

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

        public TreeNode NodeDeviceTagAdd(ProjectTag devTag, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
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
            return null;
        }

        //private void ProjectTagDelete()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;
        //    ProjectGroupTag projectGroupTag = ((ProjectNodeData)selectNode.Parent.Tag).GroupTag;
        //    ProjectTag projectTag = ((ProjectNodeData)selectNode.Tag).Tag;
        //    string text = selectNode.Text;
        //    DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
        //    if (DialogResult.Yes == dr)
        //    {
        //        projectGroupTag.DeviceTags.Remove(projectTag);
        //        selectNode.Remove();
        //    }
        //}

        #endregion DeviceTag

        #region Project NodeDelete

        // delete node
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

        private void trvProject_MouseClick(object sender, MouseEventArgs e)
        {
            //TreeNode selectNode = trvProject.GetNodeAt(new Point(e.X, e.Y));
            //selectNode = trvProject.SelectedNode;
            //mtNodeData = (ProjectNodeData)selectNode.Tag;

            //if (selectNode != null)
            //{
            //    LoadWindow(mtNodeData);
            //}
        }

        private void trvProject_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //System.Windows.Forms.TreeView trvProject = sender as System.Windows.Forms.TreeView;
            //if (trvProject != null)
            //{
            //    TreeNode selectNode = e.Node;
            //    mtNodeData = (ProjectNodeData)selectNode.Tag;

            //    if (selectNode != null)
            //    {
            //        LoadWindow(mtNodeData);
            //    }
            //}
        }

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
                //trvConfig.ContextMenuStrip = new ContextMenuStrip();

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
            else if(mtNodeData.NodeType == ProjectNodeType.GroupTag && mtNodeData.GroupTag != null)
            {
                FrmGroupTag frmGroupTag = new FrmGroupTag(ref mtNodeData, true);
                frmGroupTag.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmGroupTag;
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
        /// Checking for changes that have not been saved, but Control is closed.
        /// </summary>
        private void trvProject_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //TreeNode selectNode = trvProject.SelectedNode;
            //if (selectNode == null)
            //{
            //    return;
            //}

            //if (switchingNewControlLock != true)
            //{
            //    selectNodePrevious = trvProject.SelectedNode;
            //}

            //mtNodeData = (ProjectNodeData)selectNode.Tag;
            //mtNodeDataPrevious = (ProjectNodeData)selectNodePrevious.Tag;

            //if (switchingNewControlLock == true)
            //{
            //    modified = false;
            //}
            //else
            //{
            //if (ProjectNodeType.Device == mtNodeData.NodeType && mtNodeData.Device != null)
            //{
            //    modified = ((FrmDevice)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.CmdRequest == mtNodeData.NodeType && mtNodeData.cmdRequest != null)
            //{
            //    modified = ((FrmCmdRequest)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.SndRequest == mtNodeData.NodeType && mtNodeData.sndRequest != null)
            //{
            //    modified = ((FrmSndRequest)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.Variable == mtNodeData.NodeType && mtNodeData.variableSndRequest != null)
            //{
            //    modified = ((FrmVariable)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.Cmd == mtNodeData.NodeType && mtNodeData.cmd != null)
            //{
            //    modified = ((FrmCommand)frmPropertyForm).modified;
            //}

            //    if (modified)
            //    {
            //        DialogResult dialogResult = MessageBox.Show(DriverPhrases.QuestionAboutChanges, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            switchingNewControlLock = true;
            //            trvProject.SendToBack();
            //        }
            //        else if (dialogResult == DialogResult.No)
            //        {
            //            //none
            //        }
            //    }
            //}
        }

        private void trvProject_AfterSelect(object sender, TreeViewEventArgs e)
        {


            TreeNode selectNode = trvProject.SelectedNode;
            mtNodeData = (ProjectNodeData)selectNode.Tag;

            //// we load the window on the right and its properties
            //if (switchingNewControlLock == false)
            //{
            //    LoadWindow(mtNodeData);
            //}

            //if (switchingNewControlLock == true)
            //{
            //    trvProject.SelectedNode = selectNodePrevious;
            //    switchingNewControlLock = false;
            //}

        }

        private void trvProject_ItemDrag(object sender, ItemDragEventArgs e)
        {

        }

        private void trvProject_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void trvProject_DragDrop(object sender, DragEventArgs e)
        {

        }



        #endregion TreeView trvProject

        #region Menu
        private void cmnuChannelAdd_Click(object sender, EventArgs e)
        {
            ProjectChannelAdd();
        }

        private void cmnuDeviceAdd_Click(object sender, EventArgs e)
        {
            ProjectDeviceAdd();
        }

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

        private void cmnuAddCmdRequest_Click(object sender, EventArgs e)
        {
            //AddCmdRequest();
        }

        private void cmnuAddSndRequest_Click(object sender, EventArgs e)
        {
            //AddSndRequest();
        }

        private void cmnuAddCmd_Click(object sender, EventArgs e)
        {
            //AddCmd();
        }

        private void cmnuTagAdd_Click(object sender, EventArgs e)
        {

        }


        private void cmnuAddVariable_Click(object sender, EventArgs e)
        {
            //VariableConfigAdd();
        }

        private void cmnuDeleteGroup_Click(object sender, EventArgs e)
        {
            ProjectNodeDelete();
        }

        private void cmnuDeleteVariable_Click(object sender, EventArgs e)
        {
            ProjectNodeDelete();
        }


        private void сmnuSelectVariableUp_Click(object sender, EventArgs e)
        {
            ProjectNodeElementUp();
        }

        private void сmnuSelectVariableDown_Click(object sender, EventArgs e)
        {
            ProjectNodeElementDown();
        }

        private void сmnuSelectVariableActionUp_Click(object sender, EventArgs e)
        {
            ProjectNodeElementUp();
        }

        private void сmnuSelectVariableActionDown_Click(object sender, EventArgs e)
        {
            ProjectNodeElementDown();
        }

        #endregion Menu

        #endregion Project

        #region Settings

        private void tlsSettings_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            Settings();
        }

        private void Settings()
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.settings = project.Driver.Settings;
            // showing the form
            DialogResult dialog = frmSettings.ShowDialog();
            // if you have closed the form, click OK
            if (DialogResult.OK == dialog)
            {
                project.Driver.Settings = frmSettings.settings;
                ControlsToConfig();
                SaveProject();

            }
        }

        #endregion Settings

        #region About

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            try
            {
                //FrmAbout frmAbout = new FrmAbout();
                //frmAbout.Text = DriverPhrases.TitleAbout;
                //frmAbout.AppTitle = Utils.Code;
                //frmAbout.AppDescription = GetAutoDescription();
                //frmAbout.AppVersion = Utils.Version;
                //frmAbout.AppCopyright = GetAutoCopyright();
                //frmAbout.AppBuildDate = GetBuildDateTime();
                //frmAbout.AppInfoMore = Utils.Description(isRussian);
                //frmAbout.AppLicense = license;

                //string[] linkInfo = new string[6];
                //linkInfo[0] = "mailto:jurasskpark@yandex.ru";
                //linkInfo[1] = "https://github.com/JurasskPark";
                //linkInfo[2] = "https://www.youtube.com/@JurasskParkChannel";
                //linkInfo[3] = "https://jurasskpark.ru";
                //frmAbout.AppLinkInfo = linkInfo;

                //frmAbout.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        public static string GetAutoCopyright()
        {
            try
            {
                object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
            }
            catch { return string.Empty; }
        }

        public static string GetAutoDescription()
        {
            try
            {
                object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                return ((AssemblyDescriptionAttribute)customAttributes[0]).Description.ToString();
            }
            catch { return string.Empty; }
        }

        public static string GetAutoTitle()
        {
            try
            {
                object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (customAttributes.Length > 0)
                {
                    AssemblyTitleAttribute attribute = (AssemblyTitleAttribute)customAttributes[0];
                    if (attribute.Title != "")
                    {
                        return attribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
            }
            catch (Exception) { return string.Empty; }
        }

        public static string GetAutoVersion()
        {
            try
            {
                return Assembly.GetEntryAssembly().GetName().Version.ToString();
            }
            catch { return string.Empty; }
        }

        public static string GetAutoCompany()
        {
            try
            {
                return ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
            }
            catch { return string.Empty; }
        }

        public static string GetBuildDateTime()
        {
            try
            {
                DateTime buildDate = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
                return buildDate.ToString();
            }
            catch { return string.Empty; }
        }

        #endregion About

        #region Activation

        private void mnuActivation_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion Activation

        #region Timer
        private void tmrTimer_Tick(object sender, EventArgs e)
        {

        }
        #endregion Timer


        private void tlsProjectStartStop_Click(object sender, EventArgs e)
        {
            StartProcess();
        }

        private void StartProcess()
        {
            #region Save Load

            SaveProject();
            LoadProject();

            #endregion Save Load

            #region Port

            //if (project.Driver.Settings.ProjectChannel.GatewayTypeProtocol == 0)
            //{
            //    //Если шлюз не указан т.е. выключен, то генерируем порт 
            //    currentPort = TcpServerPortGenerator.New();
            //}
            //else
            //{
            //    bool checkedPort = TcpServerPortGenerator.CheckAvailableServerPort(Convert.ToInt32(project.Settings.ProjectChannel.GatewayPort));
            //    if (checkedPort == false)
            //    {
            //        //MessageBox.Show("Указанный порт " + project.Settings.ProjectChannel.GatewayPort + " занят! Попробуйте другой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            #endregion Port

            //DriverClient.OnDebug = new DriverClient.DebugData(DebugerLog);
            //driverClient = new DriverClient(project);
            //driverClient.InitializingDriver();

            //FrmViewData.ShowSplashScreen();


        }

        public void DebugerLog(string text)
        {

        }

        //private void Start()
        //{
        //    string errMsg = string.Empty;

        //    // save the configuration
        //    ControlsToConfig();

        //    // load a configuration
        //    ConfigToControls();

        //    int port = 0;
        //    if (project.Settings.ProjectChannel.GatewayTypeProtocol == 0)
        //    {
        //        //Если шлюз не указан т.е. выключен, то генерируем порт 
        //        port = GENERATE_TCP_SERVER_PORT.PORT_NEW();
        //    }
        //    else
        //    {
        //        bool checked_port = GENERATE_TCP_SERVER_PORT.CheckAvailableServerPort(Convert.ToInt32(project.Settings.ProjectChannel.GatewayPort));
        //        if (checked_port == false)
        //        {
        //            MessageBox.Show("Указанный порт " + project.Settings.ProjectChannel.GatewayPort + " занят! Попробуйте другой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }

        //    project.Settings.ProjectChannel.ThreadEnabled = true;

        //    //Получение RxTx 
        //    DriverClient.EventHandlerEventDevicePollTxRx = new DriverClient.EventDevicePollTxRx(PollTxRxGet);
        //    //Получение лога
        //    DriverClient.OnDebug = new DriverClient.DebugData(PollLogGet);
        //    //Получение информации с TCP сервера
        //    DriverClient.OnDebugTCPServer = new DriverClient.DebugDataTCPServer(PollLogGetTCPServer);

        //    DriverClient driverClient = new DriverClient(project);
        //    driverClient.InitializingDriver();

        //    new Thread(new ParameterizedThreadStart(driverClient.ExecuteCycle))
        //    {
        //        IsBackground = true
        //    }.Start((object)driverClient);




        //    if (errMsg != string.Empty)
        //    {
        //        ScadaUiUtils.ShowError(errMsg);
        //    }
        //}


        //private void Stop()
        //{
        //    project.Settings.ProjectChannel.ThreadEnabled = false;
        //}


        void PollLogGet(string text)
        {
            //FrmViewData.SetLog(text);
        }

        void PollLogGetTCPServer(string text)
        {
            //FrmViewData.SetLogTcpServer(text);
        }

        /// <summary>
        /// Receiving and recording logs
        /// <para>Получение и запись логов</para>
        /// </summary>
        //private void ServerMaster_MasterLog(ServerMaster sender, ServerMasterEventArgs e)
        //{
        //    string text = string.Empty;
        //    string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss.fffff");

        //    List<string> parameters = e.Parameters;

        //    #region RichTextBox Log
        //    try
        //    {
        //        if (!IsHandleCreated)
        //        {
        //            this.CreateControl();
        //        }

        //        if (IsHandleCreated)
        //        {
        //            this.Invoke((MethodInvoker)delegate
        //            {
        //                rtbServerLog.AppendText(@$"[{date}]{text}" + Environment.NewLine);
        //                rtbServerLog.ScrollToCaret();
        //                rtbServerLog.Focus();

        //                //Если количество строк, больше 200, то очищаем RichTextBox
        //                //Число 200 беретеся из Настроек
        //                if (rtbServerLog.Lines.Count() > 200)
        //                {
        //                    rtbServerLog.Text = "";
        //                }
        //            });
        //        }
        //        else
        //        {
        //            rtbServerLog.AppendText(@$"[{date}]{text}" + Environment.NewLine);
        //            rtbServerLog.ScrollToCaret();
        //            rtbServerLog.Focus();

        //            //Если количество строк, больше 200, то очищаем RichTextBox
        //            //Число 200 беретеся из Настроек
        //            if (rtbServerLog.Lines.Count() > 200)
        //            {
        //                rtbServerLog.Text = "";
        //            }
        //        }

        //    }
        //    catch { }
        //    #endregion RichTextBox Log


        //}

        #region Sample

        //#region Calcalate
        //private void CalculateData()
        //{
        //    int stream = Convert.ToInt32(nudStream.Value);
        //    int function = Convert.ToInt32(nudFunction.Value);
        //    nowMsg.SetSF(stream, function);
        //    nowMsg.AsPrimaryMessage = true;

        //    string name = txtName.Text.Trim();
        //    //secsItemNow.Name = name;
        //    //secsItemNow.IsUsed = ckbUse.Checked;
        //    bool replyExpected = ckbReplyExpected.Checked;
        //    //secsItemNow.IsWaitBit = replyExpected;
        //    //secsItemNow.Description = txtDescription.Text;

        //    TreeViewSave();
        //    GenerateMessage();

        //    byte[] itemsMsg = SingleLineConverterSECS.ConvertMessage(nowMsg);
        //    txtDataHex.Text = Hex.StringX16.ToStringFormatDot(itemsMsg);

        //}

        //private void TreeViewLoad(string info)
        //{
        //    try
        //    {
        //        if (info == string.Empty)
        //        {
        //            return;
        //        }

        //        trvItems.Nodes.Clear();
        //        trvItems.BeginUpdate();

        //        //Словарь атрибутов объявляем
        //        Dictionary<string, string> attributes = new Dictionary<string, string>();

        //        XmlDocument xmlDocument = new XmlDocument();
        //        xmlDocument.LoadXml(info);

        //        XDocument xDocument = xmlDocument.ToXDocument();

        //        TreeNode root = new TreeNode(xDocument.Root.Name.ToString());
        //        //trvItems.Nodes.Add(root);

        //        ReadNode(xDocument.Root, root);

        //        trvItems.EndUpdate();
        //    }
        //    catch { }
        //}

        //void ReadNode(XElement xElement, TreeNode treeNode)
        //{
        //    foreach (XElement element in xElement.Elements())
        //    {
        //        Dictionary<string, string> attributes = new Dictionary<string, string>();
        //        attributes = DictionaryAttributes(element);

        //        SingleLineSECS nodeLine = new SingleLineSECS();
        //        nodeLine.Type = (FormatIntSECS)Enum.Parse(typeof(FormatIntSECS), attributes["TYPE"]);

        //        #region Value
        //        switch (nodeLine.Type)
        //        {
        //            case FormatIntSECS.Binary:
        //                nodeLine.Value = nodeLine.AsBinary = Convert.ToByte(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.Boolean:
        //                nodeLine.Value = nodeLine.AsBoolean = Convert.ToBoolean(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.ASCII:
        //                nodeLine.Value = nodeLine.AsASCII = attributes["VALUE"];
        //                break;
        //            case FormatIntSECS.JIS8:
        //                nodeLine.Value = nodeLine.AsJIS8 = attributes["VALUE"];
        //                break;
        //            case FormatIntSECS.List:
        //                nodeLine.Value = nodeLine.AsList = Convert.ToInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.I1:
        //                nodeLine.Value = nodeLine.AsI1 = Convert.ToInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.I2:
        //                nodeLine.Value = nodeLine.AsI2 = Convert.ToInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.I4:
        //                nodeLine.Value = nodeLine.AsI4 = Convert.ToInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.I8:
        //                nodeLine.Value = nodeLine.AsI8 = Convert.ToInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.F4:
        //                nodeLine.Value = nodeLine.AsF4 = Convert.ToSingle(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.F8:
        //                nodeLine.Value = nodeLine.AsF8 = Convert.ToSingle(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.U1:
        //                nodeLine.Value = nodeLine.AsU1 = Convert.ToUInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.U2:
        //                nodeLine.Value = nodeLine.AsU2 = Convert.ToUInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.U4:
        //                nodeLine.Value = nodeLine.AsU4 = Convert.ToUInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.U8:
        //                nodeLine.Value = nodeLine.AsU8 = Convert.ToUInt32(attributes["VALUE"]);
        //                break;
        //            case FormatIntSECS.Spare:
        //                break;
        //            default:
        //                break;
        //        }
        //        #endregion Value

        //        //TreeNode node = new TreeNode(element.Value.ToString());
        //        TreeNode node;
        //        if (treeNode.Text == "CONFIG")
        //        {
        //            node = NodeAdd(nodeLine, cmnuMenu, null);
        //            node.Tag = nodeLine;
        //        }
        //        else
        //        {
        //            node = NodeAdd(nodeLine, cmnuMenu, treeNode);
        //            node.Tag = nodeLine;
        //        }

        //        //TreeNode node = NodeAdd(nodeLine, cmnuMenu, treeNode);
        //        //node.Tag = nodeLine;
        //        //treeNode.Nodes.Add(node);

        //        if (element.HasAttributes)
        //        {
        //            TreeNode attributesNode = new TreeNode("Attributes");
        //            ReadAttributes(element, attributesNode);
        //            //node.Nodes.Add(attributesNode);
        //        }

        //        ReadNode(element, node);
        //    }
        //}

        //void ReadAttributes(XElement element, TreeNode treeNode)
        //{
        //    foreach (XAttribute attribute in element.Attributes())
        //    {
        //        TreeNode node = new TreeNode(attribute.ToString());
        //        treeNode.Nodes.Add(node);
        //    }
        //}


        //public Dictionary<string, string> DictionaryAttributes(XElement element)
        //{
        //    try
        //    {
        //        Dictionary<string, string> attributes = new Dictionary<string, string>();
        //        #region Словарь атрибутов                  
        //        foreach (XAttribute attribute in element.Attributes())
        //        {
        //            string name = attribute.Name.LocalName;
        //            string value = attribute.Value;
        //            attributes.Add(name, value);
        //        }
        //        #endregion Словарь атрибутов

        //        return attributes;
        //    }
        //    catch
        //    {
        //        return null;
        //    }


        //}

        //public Dictionary<string, string> DictionaryAttributes(XmlNode Node)
        //{
        //    try
        //    {
        //        Dictionary<string, string> attributes = new Dictionary<string, string>();

        //        #region Словарь атрибутов                  
        //        //Загрузка атрибутов узла

        //        int attributeCount = Node.Attributes.Count;
        //        if (attributeCount > 0)
        //        {
        //            for (int i = 0; i < attributeCount; i++)
        //            {
        //                attributes.Add(Node.Attributes[i].Name, Node.Attributes[i].Value);
        //            }
        //        }
        //        #endregion Словарь атрибутов

        //        return attributes;
        //    }
        //    catch
        //    {
        //        return null;
        //    }


        //}

        //private void TreeViewSave()
        //{
        //    var sb = new StringBuilder();
        //    using (XmlWriter xmlWriter = XmlWriter.Create(sb))
        //    {
        //        // Build Xml with xw.
        //        xmlWriter.WriteStartDocument();
        //        xmlWriter.WriteStartElement("CONFIG");

        //        //Cохраняем ноды
        //        SaveNodes(trvItems.Nodes, xmlWriter);

        //        xmlWriter.WriteEndElement();
        //        xmlWriter.Close();
        //    }
        //    string result = sb.ToString();
        //    rtbItemsXml.Text = result;
        //}

        //private void SaveNodes(TreeNodeCollection nodesCollection, XmlWriter xmlWriter)
        //{
        //    try
        //    {
        //        for (int i = 0; i < nodesCollection.Count; i++)
        //        {
        //            TreeNode node = nodesCollection[i];

        //            xmlWriter.WriteStartElement("NODE");

        //            if (node.Tag != null)
        //            {
        //                SingleLineSECS nodeLine = (SingleLineSECS)node.Tag;

        //                xmlWriter.WriteAttributeString("NAME", node.Text);
        //                xmlWriter.WriteAttributeString("TYPE", nodeLine.Type.ToString());
        //                xmlWriter.WriteAttributeString("VALUE", nodeLine.Value.ToString());
        //            }

        //            if (node.Nodes.Count > 0)
        //            {
        //                SaveNodes(node.Nodes, xmlWriter);
        //            }

        //            xmlWriter.WriteEndElement();
        //        }
        //    }
        //    catch { }
        //}

        //private void GenerateMessage()
        //{
        //    nowMsg = new MessageSECS();
        //    GetMessage(trvItems.Nodes);
        //    rtbItems.Text = nowMsg.ToString();
        //}

        //private void GetMessage(TreeNodeCollection nodesCollection)
        //{
        //    try
        //    {
        //        for (int i = 0; i < nodesCollection.Count; i++)
        //        {
        //            TreeNode node = nodesCollection[i];

        //            if (node.Tag != null)
        //            {
        //                SingleLineSECS nodeLine = (SingleLineSECS)node.Tag;

        //                nowMsg.SetLatestLine(nodeLine);
        //            }

        //            if (node.Nodes.Count > 0)
        //            {
        //                GetMessage(node.Nodes);
        //            }
        //        }
        //    }
        //    catch { }
        //}



        //#endregion  Calcalate

        //#region TreeView

        //#region Menu

        //private void cmnuItemAdd_Click(object sender, EventArgs e)
        //{
        //    ItemAdd();
        //}

        //private void cmnuItemChange_Click(object sender, EventArgs e)
        //{
        //    ItemChange();
        //}

        //private void cmnuItemDelete_Click(object sender, EventArgs e)
        //{
        //    ItemDelete();
        //}

        //#endregion Menu

        //#region TreeView

        //private void trvItems_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    TreeNode selectNode = trvItems.SelectedNode;
        //    nowLine = (SingleLineSECS)selectNode.Tag;
        //}

        //private void trvItems_MouseDown(object sender, MouseEventArgs e)
        //{
        //    TreeNode selectNode = trvItems.GetNodeAt(e.X, e.Y);
        //    if (selectNode == null)
        //    {
        //        trvItems.SelectedNode = null;
        //        trvItems.HideSelection = true;
        //    }
        //    else
        //    {
        //        trvItems.HideSelection = false;
        //    }
        //}
        //#endregion TreeView

        //#region Find Image

        //private string FingImageType(FormatIntSECS type)
        //{
        //    string image = string.Empty;
        //    switch (type)
        //    {
        //        case FormatIntSECS.Binary:
        //            image = "bin_16.png";
        //            break;
        //        case FormatIntSECS.Boolean:
        //            image = "bool_16.png";
        //            break;
        //        case FormatIntSECS.ASCII:
        //            image = "ascii_16.png";
        //            break;
        //        case FormatIntSECS.JIS8:
        //            image = "jis8_16.png";
        //            break;
        //        case FormatIntSECS.List:
        //            image = "list_16.png";
        //            break;
        //        case FormatIntSECS.I1:
        //            image = "i1_16.png";
        //            break;
        //        case FormatIntSECS.I2:
        //            image = "i2_16.png";
        //            break;
        //        case FormatIntSECS.I4:
        //            image = "i4_16.png";
        //            break;
        //        case FormatIntSECS.I8:
        //            image = "i8_16.png";
        //            break;
        //        case FormatIntSECS.F4:
        //            image = "f4_16.png";
        //            break;
        //        case FormatIntSECS.F8:
        //            image = "f8_16.png";
        //            break;
        //        case FormatIntSECS.U1:
        //            image = "u1_16.png";
        //            break;
        //        case FormatIntSECS.U2:
        //            image = "u2_16.png";
        //            break;
        //        case FormatIntSECS.U4:
        //            image = "u4_16.png";
        //            break;
        //        case FormatIntSECS.U8:
        //            image = "u8_16.png";
        //            break;
        //        case FormatIntSECS.Spare:
        //            image = "default_16.png";
        //            break;
        //        default:
        //            image = "default_16.png";
        //            break;
        //    }

        //    return image;
        //}

        //#endregion Find Image

        //#region Item

        //#region Add

        //private void ItemAdd()
        //{
        //    TreeNode selectNode = trvItems.SelectedNode;
        //    TreeNode parentNode = null;
        //    SingleLineSECS parentLine = null;

        //    if (selectNode != null)
        //    {
        //        parentNode = selectNode;
        //        nowLine = (SingleLineSECS)selectNode.Tag;
        //        parentLine = (SingleLineSECS)selectNode.Tag;
        //    }

        //    if (nowLine != null)
        //    {
        //        // create form
        //        FrmValue frmValue = new FrmValue();
        //        frmValue.nowState = FormatIntSECS.List;

        //        // showing the form
        //        DialogResult dialog = frmValue.ShowDialog();

        //        // if you have closed the form, click Save
        //        if (DialogResult.OK == dialog)
        //        {
        //            nowLine = frmValue.nowLine;
        //            if (parentLine != null && parentLine.Type == FormatIntSECS.List && parentLine.AsList <= parentNode.Nodes.Count)
        //            {
        //                return;
        //            }
        //            else if (parentNode != null && parentLine.Type != FormatIntSECS.List)
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                NodeAdd(nowLine, cmnuMenu, parentNode);
        //            }

        //            CalculateData();
        //        }
        //    }
        //}

        //public TreeNode NodeAdd(SingleLineSECS line, ContextMenuStrip cms, TreeNode ptn = null)
        //{
        //    if (null == ptn)
        //    {
        //        TreeNode tn = new TreeNode(line.Type.ToString() + " [" + line.Value.ToString() + "]");
        //        tn.ImageKey = tn.SelectedImageKey = FingImageType(line.Type);
        //        tn.ContextMenuStrip = cms;
        //        tn.Tag = line;
        //        trvItems.Nodes.Add(tn);
        //        tn.Expand();
        //        return tn;
        //    }
        //    else
        //    {
        //        TreeNode tn = new TreeNode(line.Type.ToString() + " [" + line.Value.ToString() + "]");
        //        tn.ImageKey = tn.SelectedImageKey = FingImageType(line.Type);
        //        tn.ContextMenuStrip = cms;
        //        tn.Tag = line;
        //        ptn.Nodes.Add(tn);
        //        ptn.Expand();
        //        return tn;
        //    }
        //    return null;
        //}

        //#endregion Add

        //#region Change

        //private void ItemChange()
        //{
        //    if (trvItems.SelectedNode != null)
        //    {
        //        TreeNode selectNode = trvItems.SelectedNode;
        //        nowLine = (SingleLineSECS)selectNode.Tag;

        //        if (nowLine != null)
        //        {
        //            // create form
        //            FrmValue frmValue = new FrmValue();
        //            frmValue.nowLine = nowLine;
        //            // showing the form
        //            DialogResult dialog = frmValue.ShowDialog();

        //            // if you have closed the form, click Save
        //            if (DialogResult.OK == dialog)
        //            {
        //                selectNode.Tag = frmValue.nowLine;
        //                selectNode.Text = frmValue.nowLine.Type.ToString() + " [" + frmValue.nowLine.Value.ToString() + "]";
        //                selectNode.ImageKey = selectNode.SelectedImageKey = FingImageType(frmValue.nowLine.Type);

        //                CalculateData();
        //            }
        //        }
        //    }
        //}

        //#endregion Change

        //#region Delete

        //private void ItemDelete()
        //{
        //    if (trvItems.SelectedNode != null)
        //    {
        //        trvItems.Nodes.Remove(trvItems.SelectedNode);

        //        CalculateData();
        //    }
        //}

        //#endregion Delete

        //#region Refresh
        //private void ItemRefresh()
        //{
        //    rtbItems.Clear();
        //    rtbItems.AppendText(nowMsg.ToString());

        //    if (nowMsg.IsEnd())
        //    {
        //        lblItemsStatus.Text = string.Format("Message Complete");
        //    }
        //    else
        //    {
        //        lblItemsStatus.Text = string.Empty;
        //    }
        //}

        //#endregion Refresh

        //#endregion Item

        //#endregion TreeView

        #endregion Sample



    }
}
