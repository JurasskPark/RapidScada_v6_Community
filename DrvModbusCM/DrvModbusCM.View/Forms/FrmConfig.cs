using CommunicationMethods;
using Scada.Comm.Config;
using Scada.Comm.Devices;
using Scada.Data.Entities;
using Scada.Forms;
using Scada.Lang;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Channels;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using MethodInvoker = System.Windows.Forms.MethodInvoker;


namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmConfig : Form
    {
        #region Variables
        private readonly AppDirs appDirs;                           // the application directories
        private readonly LineConfig lineConfig;                     // the communication line configuration
        private readonly DeviceConfig deviceConfig;                 // the device configuration
        private readonly int deviceNum;                             // the device number
        private readonly string driverCode;                         // the driver code

        DriverClient driverClient;                                  // the driver client
        string errMsg;                                              // error message
        string driverConfigPath = string.Empty;                     // driver config path
        Project driverConfig = new Project();                       // driver config
        string configPath = string.Empty;                           // config path

        System.Windows.Forms.TreeView trvConfig = new System.Windows.Forms.TreeView();  // config treeview

        private Form frmPropertyForm = new Form();                  // child form properties
        TreeNode selectNodePrevious;                                // node previous
        ProjectNodeData mtNodeData = new ProjectNodeData();         //
        ProjectNodeData mtNodeDataPrevious = new ProjectNodeData(); //
        private bool switchingNewControlLock = false;               //
        private bool modified = false;                              // modified
        int indexData = 0;                                          // index data

        bool isRussian;


        int currentPort = 0;                                        // current port
        #endregion Variables

        #region Form
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmConfig()
        {
            DriverPhrases.Init();
            driverClient = new DriverClient();

            this.Opacity = 0.0;
            this.Visible = false;
            this.ShowInTaskbar = false;

            InitializeComponent();
        }


        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmConfig(AppDirs appDirs, LineConfig lineConfig, DeviceConfig deviceConfig, int deviceNum, bool languageRussian = false)
            : this()
        {
            this.appDirs = appDirs ?? throw new ArgumentNullException(nameof(appDirs));
            this.lineConfig = lineConfig ?? throw new ArgumentNullException(nameof(lineConfig));
            this.deviceConfig = deviceConfig ?? throw new ArgumentNullException(nameof(deviceConfig));
            this.deviceNum = deviceNum;

            DriverPhrases.Init();
            driverClient = new DriverClient();

            this.Opacity = 0.0;
            this.Visible = false;
            this.ShowInTaskbar = false;

            this.isRussian = languageRussian;

            FormProperties(appDirs.ConfigDir, deviceNum);
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmConfig(string configDriver, bool languageRussian = false) : this()
        {
            DriverPhrases.Init();
            driverClient = new DriverClient();

            this.Opacity = 0.0;
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.isRussian = languageRussian;

            FormProperties(configDriver, 0);
        }

        private void FormProperties(string configDir, int deviceNum)
        {
            string errMsg = string.Empty;
            driverConfig = new Project();

            // load configuration
            if (deviceNum == 0)
            {
                this.driverConfigPath = configDir;
                if (!File.Exists(driverConfigPath))
                {
                    ProjectFile.SaveXml(driverConfig, driverConfigPath);
                    driverConfig = ProjectFile.LoadXml(typeof(Project), driverConfigPath) as Project;
                }
                else
                {
                    driverConfig = ProjectFile.LoadXml(typeof(Project), driverConfigPath) as Project;
                }
            }
            else
            {
                this.driverConfigPath = Path.Combine(configDir, DriverUtils.GetFileName(deviceNum));
                if (!File.Exists(driverConfigPath))
                {
                    ProjectFile.SaveXml(driverConfig, driverConfigPath);
                    driverConfig = ProjectFile.LoadXml(typeof(Project), driverConfigPath) as Project;
                }
                else
                {
                    driverConfig = ProjectFile.LoadXml(typeof(Project), driverConfigPath) as Project;
                }
            }
        }

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

            string languageFile = Path.Combine(languageDir + $@"Lang\", DriverUtils.DriverCode + "." + culture + ".xml");
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

        private void FrmConfig_Shown(object sender, EventArgs e)
        {
            ValidateLicense();

            this.Opacity = 100.0;
            this.Visible = true;
            this.ShowInTaskbar = true;

            // acrivate form
            this.Activate();
        }

        private void ValidateLicense()
        {

        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            // translate the form
            FormTranslator.Translate(this, GetType().FullName);

            // translate menu
            //FormTranslator.Translate(cmnuGroupCmdRequestNode, GetType().FullName);
            //FormTranslator.Translate(cmnuGroupSndRequestNode, GetType().FullName);
            //FormTranslator.Translate(cmnuGroupCmdNode, GetType().FullName);
            FormTranslator.Translate(cmnuTagAppend, GetType().FullName);
            FormTranslator.Translate(cmnuDeleteAction, GetType().FullName);

            // phrases
            DriverPhrases.Init();

            // we give the default project configuration to treeview
            #region config
            ProjectLoad(driverConfigPath);

            if (trvProject.Nodes.Count == 0)
            {
                ProjectDefaultNew(DialogResult.No);
            }
            #endregion config

            ConfigToControls();
        }

        private void FrmConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlsToConfig();
        }
        #endregion Form

        #region Driver Config

        /// <summary>
        /// Sets the controls according to the configuration.
        /// </summary>
        private void ConfigToControls()
        {

        }

        /// <summary>
        /// Sets the configuration parameters according to the controls.
        /// </summary>
        private void ControlsToConfig()
        {
            if (!File.Exists(driverConfigPath))
            {
                if (this.appDirs != null)
                {
                    driverConfigPath = Path.Combine(this.appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
                }
                else
                {
                    driverConfigPath = DriverUtils.GetFileName(deviceNum);
                }
            }

            ProjectFile.SaveXml(driverConfig, driverConfigPath);
        }

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
            configPath = "";

            // create a new project with default settings
            driverConfig = new Project();

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

        public void GetDefaultTreeNodes()
        {
            #region Settings
            ProjectSettings settings = new ProjectSettings();
            settings.Name = DriverPhrases.SettingsName;
            settings.AutoRun = false;
            settings.Debug = false;

            //Добавляем в дерево
            TreeNode settingsNode = NodeProjectSettingsAdd(settings, cmnuDeviceAppend);
            //Добавляем в проект
            driverConfig.Driver.Settings = settings;
            #endregion Settings

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
            TreeNode channelNode = NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend);
            //Добавляем в проект
            driverConfig.Driver.Channels.Add(projectChannel);
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
            projectDevice.GroupCommands = new List<ProjectGroupCommand>();
            projectDevice.GroupTags = new List<ProjectGroupTag>();

            //Делаем активно меню 
            TreeNode deviceNode = NodeProjectDeviceAdd(projectDevice, channelNode, cmnuDeleteAction);

            //Добавляем группу комманд
            ProjectGroupCommand projectGroupCommand = new ProjectGroupCommand();
            projectGroupCommand.ParentID = projectDevice.ID;
            projectGroupCommand.ID = Guid.NewGuid();
            projectGroupCommand.Enabled = true;
            projectGroupCommand.Name = DriverPhrases.GroupCommandName;
            projectGroupCommand.ListCommands = new List<ProjectCommand>();
            projectDevice.GroupCommands.Add(projectGroupCommand);
            //Добавляем в дерево
            TreeNode groupCommandNode = NodeGroupCommandAdd(projectGroupCommand, deviceNode, cmnuCommandAppend);

            //Добавляем группу тегов
            ProjectGroupTag projectGroupTag = new ProjectGroupTag();
            projectGroupTag.ParentID = projectDevice.ID;
            projectGroupTag.ID = Guid.NewGuid();
            projectGroupTag.Enabled = true;
            projectGroupTag.Name = DriverPhrases.GroupTagName;
            projectGroupTag.ListTags = new List<ProjectTag>();
            projectDevice.GroupTags.Add(projectGroupTag);
            //Добавляем в дерево
            TreeNode groupTagNode = NodeGroupTagAdd(projectGroupTag, deviceNode, cmnuTagAppend);

            //Добавляем в проект
            projectChannel.Devices.Add(projectDevice);

            deviceNode.ExpandAll();
            #endregion Device

        }

        //// add to tree
        //public TreeNode NodeDeviceOptionsAdd(IEC61107Options opt, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData projectNodeData = new ProjectNodeData();
        //        projectNodeData.deviceOptions = opt;
        //        projectNodeData.nodeType = ProjectNodeType.Options;

        //        TreeNode tn = new TreeNode(DriverPhrases.OptionsNode);
        //        tn.ImageKey = ListImages.ImageKey.Options;
        //        tn.SelectedImageKey = ListImages.ImageKey.Options;
        //        tn.ContextMenuStrip = cms;
        //        tn.Tag = projectNodeData;

        //        this.trvProject.Nodes.Add(tn);

        //        return tn;
        //    }
        //    return null;
        //}

        //// add to tree
        //public TreeNode NodeDeviceAdd(Project dtp, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData projectNodeData = new ProjectNodeData();
        //        projectNodeData.device = dtp;
        //        projectNodeData.nodeType = ProjectNodeType.Device;

        //        TreeNode tn = new TreeNode(dtp.Name);
        //        tn.ImageKey = ListImages.ImageKey.Device;
        //        tn.SelectedImageKey = ListImages.ImageKey.Device;
        //        tn.ContextMenuStrip = cms;
        //        tn.Tag = projectNodeData;

        //        this.trvProject.Nodes.Add(tn);

        //        return tn;
        //    }
        //    return null;
        //}

        //// add tree
        //public TreeNode NodeListGroupsCmdRequestAdd(List<Project.CmdRequest> cmr, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData ProjectNodeData = new ProjectNodeData();
        //        ProjectNodeData.groupCmdRequest = cmr;
        //        ProjectNodeData.nodeType = ProjectNodeType.GroupCmdRequest;

        //        TreeNode tn = new TreeNode(DriverPhrases.GroupCmdRequest);
        //        tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.GroupCmdRequest;
        //        ptn.Nodes.Add(tn);
        //        tn.ContextMenuStrip = cms;

        //        tn.Tag = ProjectNodeData;
        //        ptn.Expand();
        //        return tn;
        //    }
        //    return null;
        //}

        //// add tree
        //public TreeNode NodeListGroupsSndRequestAdd(List<Project.SndRequest> snr, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData ProjectNodeData = new ProjectNodeData();
        //        ProjectNodeData.groupSndRequest = snr;
        //        ProjectNodeData.nodeType = ProjectNodeType.GroupSndRequest;

        //        TreeNode tn = new TreeNode(DriverPhrases.GroupSndRequest);
        //        tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.GroupSndRequest;
        //        ptn.Nodes.Add(tn);
        //        tn.ContextMenuStrip = cms;

        //        tn.Tag = ProjectNodeData;
        //        ptn.Expand();
        //        return tn;
        //    }
        //    return null;
        //}

        //// add tree
        //public TreeNode NodeListGroupsCmdAdd(List<Project.Command> cmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData ProjectNodeData = new ProjectNodeData();
        //        ProjectNodeData.groupCmd = cmd;
        //        ProjectNodeData.nodeType = ProjectNodeType.GroupCmd;

        //        TreeNode tn = new TreeNode(DriverPhrases.GroupCmd);
        //        tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.GroupCmd;
        //        ptn.Nodes.Add(tn);
        //        tn.ContextMenuStrip = cms;

        //        tn.Tag = ProjectNodeData;
        //        ptn.Expand();
        //        return tn;
        //    }
        //    return null;
        //}

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
                configPath = OFD.FileName;
                ProjectLoad(configPath);
            }
        }

        private void ProjectLoad(string fileName)
        {
            if (File.Exists(fileName))
            {
                driverConfig = ProjectFile.LoadXml(typeof(Project), fileName) as Project;
                DeserializeTreeView(trvProject, fileName, driverConfig);
            }
        }

        public void DeserializeTreeView(System.Windows.Forms.TreeView treeView, string fileName, Project driverConfig)
        {
            treeView.Nodes.Clear();

            //// add to tree
            //TreeNode channelNode = NodeProjectChannelAdd(driverConfig.Settings.ProjectChannel, cmnuDeviceAppend);

            //for (int d = 0; d < driverConfig.Settings.ProjectDevice.Count; d++)
            //{
            //    ProjectDevice projectDevice = driverConfig.Settings.ProjectDevice[d];
            //    // add to tree
            //    TreeNode deviceNode = NodeProjectDeviceAdd(projectDevice, channelNode, cmnuDeleteAction);

            //    #region Group Command

            //    List<ProjectGroupCommand> lstGroupCommandSearch = new List<ProjectGroupCommand>();
            //    if (driverConfig.Settings.ProjectGroupCommand != null && driverConfig.Settings.ProjectGroupCommand.Count > 0)
            //    {
            //        lstGroupCommandSearch = driverConfig.Settings.ProjectGroupCommand.Where(r => r.ParentID == projectDevice.ID).ToList();

            //        for (int gc = 0; gc < lstGroupCommandSearch.Count; gc++)
            //        {
            //            ProjectGroupCommand groupCommand = lstGroupCommandSearch[gc];
            //            // add to tree
            //            TreeNode groupCommandNode = NodeGroupCommandAdd(groupCommand, deviceNode, cmnuCommandAppend);

            //            List<ProjectCommand> lstCommandSearch = new List<ProjectCommand>();
            //            lstCommandSearch = driverConfig.Settings.ProjectCommand.Where(r => r.ParentID == groupCommand.ID).ToList();

            //            for (int c = 0; c < lstCommandSearch.Count; c++)
            //            {
            //                ProjectCommand command = lstCommandSearch[c];
            //                // add to tree
            //                TreeNode commandNode = NodeCommandAdd(command, groupCommandNode, cmnuDeleteAction);
            //            }
            //        }
            //    }

            //    #endregion Group Command

            //    #region Group Tag

            //    List<ProjectGroupTag> lstGroupTagSearch = new List<ProjectGroupTag>();
            //    if (driverConfig.Settings.ProjectGroupTag != null && driverConfig.Settings.ProjectGroupTag.Count > 0)
            //    {
            //        lstGroupTagSearch = driverConfig.Settings.ProjectGroupTag.Where(r => r.ParentID == projectDevice.ID).ToList();

            //        for (int gt = 0; gt < lstGroupCommandSearch.Count; gt++)
            //        {
            //            ProjectGroupTag groupTag = lstGroupTagSearch[gt];
            //            // add to tree
            //            TreeNode groupTagNode = NodeGroupTagAdd(groupTag, deviceNode, cmnuTagAppend);
            //        }
            //    }

            //    #endregion Group Tag

            //}

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
            if (String.IsNullOrEmpty(configPath))
            {
                if (appDirs != null)
                {
                    configPath = Path.Combine(appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
                }
                else
                {
                    configPath = Path.Combine(DriverUtils.GetFileName(deviceNum));
                }
                SerializeTreeView(trvProject, configPath);
            }
            else
            {
                SerializeTreeView(trvProject, configPath);
            }
        }

        public void SerializeTreeView(System.Windows.Forms.TreeView treeView, string fileName)
        {
            driverConfig = new Project();

            // save the nodes, recursive method
            foreach (TreeNode tnNode in treeView.Nodes)
            {
                ProjectNodeData prNode = (ProjectNodeData)tnNode.Tag;
                #region Settings

                if (prNode.nodeType == ProjectNodeType.Settings)
                {
                    ProjectSettings settings = prNode.settings;
                    driverConfig.Driver.Settings = settings;
                }
                #endregion Settings

                #region Channel

                if (prNode.nodeType == ProjectNodeType.Channel)
                {
                    ProjectChannel channel = prNode.channel;
                    List<ProjectDevice> devices = new List<ProjectDevice>();

                    #region Device
                    ProjectDevice device = new ProjectDevice();
                    foreach (TreeNode tnDevice in tnNode.Nodes)
                    {
                        device = ((ProjectNodeData)tnDevice.Tag).device;
                        List<ProjectGroupCommand> GroupCommands = new List<ProjectGroupCommand>();
                        List<ProjectGroupTag> GroupTags = new List<ProjectGroupTag>();

                        foreach (TreeNode tnGrp in tnDevice.Nodes)
                        {
                            ProjectNodeData prGrp = (ProjectNodeData)tnGrp.Tag;

                            #region Group Command

                            if (prGrp.nodeType == ProjectNodeType.GroupCommand)
                            {
                                ProjectGroupCommand groupCommands = ((ProjectNodeData)tnGrp.Tag).groupCommand;
                                foreach(TreeNode tnCommand in tnGrp.Nodes)
                                {
                                    ProjectCommand command = ((ProjectNodeData)tnCommand.Tag).command;
                                    groupCommands.ListCommands.Add(command);
                                }
                                GroupCommands.Add(groupCommands);
                            }

                            #endregion Group Command

                            #region Group Tag

                            if (prGrp.nodeType == ProjectNodeType.GroupTag)
                            {
                                ProjectGroupTag groupTag = ((ProjectNodeData)tnGrp.Tag).groupTag;
                                foreach (TreeNode tnTag in tnGrp.Nodes)
                                {
                                    ProjectTag tag = ((ProjectNodeData)tnTag.Tag).tag;
                                    groupTag.ListTags.Add(tag);
                                }
                                GroupTags.Add(groupTag);
                            }

                            #endregion Group Tag

                        }

                        device.GroupCommands = GroupCommands;
                        device.GroupTags = GroupTags;

                    }

                    #endregion Device

                    devices.Add(device);
                    channel.Devices = devices;
                    driverConfig.Driver.Channels.Add(channel);
                }
                #endregion Channel

                
            }

            ProjectFile.SaveXml(driverConfig, fileName);
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

            if (String.IsNullOrEmpty(configPath))
            {
                if (appDirs != null)
                {
                    configPath = Path.Combine(appDirs.ConfigDir, DriverUtils.GetFileName(deviceNum));
                }
            }

            SFD.InitialDirectory = configPath;

            if (SFD.ShowDialog() == DialogResult.OK && SFD.FileName != "")
            {
                configPath = SFD.FileName;

                SerializeTreeView(trvProject, configPath);
            }
        }

        #endregion Save As

        #region Project Settings

        //Добавляем в дерево
        public TreeNode NodeProjectSettingsAdd(ProjectSettings stg, ContextMenuStrip cms)
        {
            TreeNode tn = new TreeNode(stg.Name);
            tn.Text = stg.Name;

            string imageKey = ListImages.ImageKey.Settings;

            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

            this.trvProject.Nodes.Add(tn);

            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.settings = stg;
            ProjectNodeData.nodeType = ProjectNodeType.Settings;

            tn.ContextMenuStrip = cms;
            tn.Tag = ProjectNodeData;

            return tn;
        }

        #endregion Project Settings

        #region Project Channel
        public void ProjectChannelAdd()
        {
            ProjectChannel projectChannel = new ProjectChannel();
            projectChannel.KeyImage = ListImages.ImageKey.ChannelEmpty;
            projectChannel.ID = Guid.NewGuid();
            projectChannel.Name = DriverPhrases.ChannelName;
            projectChannel.Description = "";
            projectChannel.Enabled = true;
            projectChannel.GatewayTypeProtocol = 0;
            projectChannel.GatewayPort = 60000;
            projectChannel.GatewayConnectedClientsMax = 10;

            projectChannel.WriteTimeout = 1000;
            projectChannel.ReadTimeout = 1000;
            projectChannel.Timeout = 1000;

            projectChannel.WriteBufferSize = 8192;
            projectChannel.ReadBufferSize = 8192;

            projectChannel.CountError = 3;
            //Добавляем в дерево
            NodeProjectChannelAdd(projectChannel, cmnuDeviceAppend);
        }

        //Добавляем в дерево
        public TreeNode NodeProjectChannelAdd(ProjectChannel cnl, ContextMenuStrip cms)
        {
            TreeNode tn = new TreeNode(cnl.Name);
            tn.Text = cnl.Name;

            string imageKey = string.Empty;
            switch (cnl.Type)
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

            cnl.KeyImage = imageKey;
            tn.ImageKey = imageKey;
            tn.SelectedImageKey = imageKey;
            tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

            this.trvProject.Nodes.Add(tn);

            ProjectNodeData ProjectNodeData = new ProjectNodeData();
            ProjectNodeData.channel = cnl;
            ProjectNodeData.nodeType = ProjectNodeType.Channel;

            tn.ContextMenuStrip = cms;
            tn.Tag = ProjectNodeData;

            return tn;
        }

        //Удаление канала
        //private void ProjectChannelDelete()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;
        //    string text = selectNode.Text;
        //    DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
        //    if (DialogResult.Yes == dr)
        //    {
        //        selectNode.Remove();
        //    }
        //}

        #endregion Project Channel

        #region Project Device

        //Добавление устройства
        public void ProjectDeviceAdd()
        {
            ProjectDevice projectDevice = new ProjectDevice();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectChannel projectChannel = ((ProjectNodeData)selectNode.Tag).channel;
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


            projectDevice.GroupCommands = new List<ProjectGroupCommand>();
            projectDevice.GroupTags = new List<ProjectGroupTag>();

            //Делаем активно меню 
            TreeNode deviceNode = NodeProjectDeviceAdd(projectDevice, selectNode, cmnuDeviceDelete);

            //Добавляем группу комманд
            ProjectGroupCommand projectGroupCommand = new ProjectGroupCommand();
            projectGroupCommand.ParentID = projectDevice.ID;
            projectGroupCommand.ID = Guid.NewGuid();
            projectGroupCommand.Enabled = true;
            projectGroupCommand.Name = DriverPhrases.GroupCommandName;
            projectGroupCommand.ListCommands = new List<ProjectCommand>();
            projectDevice.GroupCommands.Add(projectGroupCommand);
            //Добавляем в дерево
            TreeNode groupCommandNode = NodeGroupCommandAdd(projectGroupCommand, deviceNode, cmnuCommandAppend);

            //Добавляем группу тегов
            ProjectGroupTag projectGroupTag = new ProjectGroupTag();
            projectGroupTag.ParentID = projectDevice.ID;
            projectGroupTag.ID = Guid.NewGuid();
            projectGroupTag.Enabled = true;
            projectGroupTag.Name = DriverPhrases.GroupTagName;
            projectGroupTag.ListTags = new List<ProjectTag>();
            projectDevice.GroupTags.Add(projectGroupTag);
            //Добавляем в дерево
            TreeNode groupTagNode = NodeGroupTagAdd(projectGroupTag, deviceNode, cmnuTagAppend);
        }

        //Добавляем в дерево
        public TreeNode NodeProjectDeviceAdd(ProjectDevice dev, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(dev.Name);

                string imageKey = ListImages.ImageKey.Device;
                dev.KeyImage = imageKey;
                tn.ImageKey = imageKey;
                tn.SelectedImageKey = imageKey;
                tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

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
        //private void ProjectDeviceDelete()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;
        //    ProjectChannel projectChannel = ((ProjectNodeData)selectNode.Parent.Tag).channel;
        //    ProjectDevice projectDevice = ((ProjectNodeData)selectNode.Tag).device;
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
        public TreeNode NodeGroupCommandAdd(ProjectGroupCommand grpCmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(grpCmd.Name);

                string imageKey = ListImages.ImageKey.GroupCmd;
                grpCmd.KeyImage = imageKey;
                tn.ImageKey = imageKey;
                tn.SelectedImageKey = imageKey;
                tn.ImageIndex = imgList.Images.IndexOfKey(imageKey);

                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.groupCommand = ((ProjectNodeData)ptn.Tag).groupCommand;
                ProjectNodeData.nodeType = ProjectNodeType.GroupCommand;
                ProjectNodeData.groupCommand = grpCmd;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        #endregion GroupCommand

        #region Command
        private void ProjectCommandAdd(ulong command)
        {
            ProjectCommand projectCommand = new ProjectCommand();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectGroupCommand projectGroupCommand = ((ProjectNodeData)selectNode.Tag).groupCommand;
            Guid ParentID = projectGroupCommand.ID;

            projectCommand.ParentID = ParentID;
            projectCommand.ID = Guid.NewGuid();
            projectCommand.KeyImage = ProjectCommand.KeyImageName(command);
            projectCommand.Enabled = true;
            projectCommand.FunctionCode = command;
            projectCommand.RegisterStartAddress = 0;
            projectCommand.RegisterCount = 1;
            projectCommand.Parametr = 0;
            projectCommand.Name = projectCommand.GenerateName();
            projectCommand.Description = "";

            //Добавляем в дерево
            NodeCommandAdd(projectCommand, selectNode, cmnuCommandDelete);
        }

        public TreeNode NodeCommandAdd(ProjectCommand devCmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
            {
                TreeNode tn = new TreeNode(devCmd.Name);

                tn.ImageKey = tn.SelectedImageKey = ProjectCommand.KeyImageName(devCmd.FunctionCode);

                ptn.Nodes.Add(tn);
                tn.ContextMenuStrip = cms;
                ProjectNodeData ProjectNodeData = new ProjectNodeData();
                ProjectNodeData.command = ((ProjectNodeData)ptn.Tag).command;
                ProjectNodeData.nodeType = ProjectNodeType.Command;
                ProjectNodeData.command = devCmd;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
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
        //            Guid ParentID = ((ProjectNodeData)selectNode.Tag).groupCommand.ID;

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


        //private void ProjectCommandDelete()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;
        //    ProjectGroupCommand projectGroupCommand = ((ProjectNodeData)selectNode.Parent.Tag).groupCommand;
        //    ProjectCommand projectCommand = ((ProjectNodeData)selectNode.Tag).command;
        //    string text = selectNode.Text;
        //    DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
        //    if (DialogResult.Yes == dr)
        //    {
        //        projectGroupCommand.Commands.Remove(projectCommand);
        //        selectNode.Remove();
        //    }
        //}

        #endregion Command

        #region DeviceGroupTag
        public TreeNode NodeGroupTagAdd(ProjectGroupTag grpTgs, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        {
            if (null == stn)
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
                ProjectNodeData.groupTag = ((ProjectNodeData)ptn.Tag).groupTag;
                ProjectNodeData.nodeType = ProjectNodeType.GroupTag;
                ProjectNodeData.groupTag = grpTgs;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        #endregion DeviceGroupTag

        #region DeviceTag

        private void ProjectTagAdd()
        {
            ProjectTag projectTag = new ProjectTag();
            //В дереве выбран объект
            TreeNode selectNode = trvProject.SelectedNode;

            ProjectGroupTag projectGroupTag = ((ProjectNodeData)selectNode.Tag).groupTag;
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
                ProjectNodeData.tag = ((ProjectNodeData)ptn.Tag).tag;
                ProjectNodeData.nodeType = ProjectNodeType.Tag;
                ProjectNodeData.tag = devTag;
                tn.Tag = ProjectNodeData;
                ptn.Expand();
                return tn;
            }
            return null;
        }

        //private void ProjectTagDelete()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;
        //    ProjectGroupTag projectGroupTag = ((ProjectNodeData)selectNode.Parent.Tag).groupTag;
        //    ProjectTag projectTag = ((ProjectNodeData)selectNode.Tag).tag;
        //    string text = selectNode.Text;
        //    DialogResult dr = MessageBox.Show(DriverPhrases.DeleteQuestion + text + " ?", DriverPhrases.Delete, MessageBoxButtons.YesNo);
        //    if (DialogResult.Yes == dr)
        //    {
        //        projectGroupTag.DeviceTags.Remove(projectTag);
        //        selectNode.Remove();
        //    }
        //}

        #endregion DeviceTag

        #region Project Cmd Request

        //public void AddCmdRequest()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;

        //    Project.CmdRequest cmdRequest = new Project.CmdRequest();
        //    // add to tree
        //    NodeCmdRequestAdd(cmdRequest, selectNode, null);
        //    // expand node
        //    selectNode.Expand();
        //}

        //// add tree
        //public TreeNode NodeCmdRequestAdd(Project.CmdRequest cmr, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData ProjectNodeData = new ProjectNodeData();
        //        ProjectNodeData.cmdRequest = cmr;
        //        ProjectNodeData.nodeType = ProjectNodeType.CmdRequest;

        //        TreeNode tn = new TreeNode(DriverPhrases.CmdRequest);
        //        tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.CmdRequest;
        //        ptn.Nodes.Add(tn);
        //        tn.ContextMenuStrip = cms;

        //        tn.Tag = ProjectNodeData;
        //        ptn.Expand();
        //        return tn;
        //    }
        //    return null;
        //}

        #endregion Project Cmd Request

        #region Project Snd Request

        //public void AddSndRequest()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;

        //    Project.SndRequest sndRequest = new Project.SndRequest();
        //    sndRequest.SndName = DriverPhrases.SndRequest;
        //    sndRequest.Signal = "0";

        //    // add to tree
        //    NodeSndRequestAdd(sndRequest, selectNode, cmnuVariableNode);
        //    // expand node
        //    selectNode.Expand();
        //}

        //// add tree
        //public TreeNode NodeSndRequestAdd(Project.SndRequest snr, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData ProjectNodeData = new ProjectNodeData();
        //        ProjectNodeData.sndRequest = snr;
        //        ProjectNodeData.nodeType = ProjectNodeType.SndRequest;

        //        TreeNode tn = new TreeNode(snr.Signal + " (" + snr.SndName + ")");
        //        tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.SndRequest;
        //        ptn.Nodes.Add(tn);
        //        tn.ContextMenuStrip = cms;

        //        tn.Tag = ProjectNodeData;
        //        ptn.Expand();
        //        return tn;
        //    }
        //    return null;
        //}

        #endregion Project  Snd Request

        #region Project Cmd

        //public void AddCmd()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;

        //    Project.Command cmd = new Project.Command();
        //    cmd.commName = DriverPhrases.Cmd;
        //    // add to tree
        //    NodeCmdAdd(cmd, selectNode, null);
        //    // expand node
        //    selectNode.Expand();
        //}

        //// add tree
        //public TreeNode NodeCmdAdd(Project.Command cmd, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData ProjectNodeData = new ProjectNodeData();
        //        ProjectNodeData.cmd = cmd;
        //        ProjectNodeData.nodeType = ProjectNodeType.Cmd;

        //        TreeNode tn = new TreeNode(cmd.commSignal + " (" + cmd.commName + ")");
        //        tn.ImageKey = tn.SelectedImageKey = ListImages.ImageKey.Cmd;
        //        ptn.Nodes.Add(tn);
        //        tn.ContextMenuStrip = cms;

        //        tn.Tag = ProjectNodeData;
        //        ptn.Expand();
        //        return tn;
        //    }
        //    return null;
        //}

        #endregion Project Cmd

        #region Project VariableConfig

        //public void VariableConfigAdd()
        //{
        //    TreeNode selectNode = trvProject.SelectedNode;

        //    SndRequest.Vals variableConfig = new SndRequest.Vals();
        //    variableConfig.Name = DriverPhrases.UnnamedVariable;
        //    // add to tree
        //    NodeVariableConfigAdd(variableConfig, selectNode, cmnuVariableAction);
        //    // expand node
        //    selectNode.Expand();
        //}

        //// add to tree
        //public TreeNode NodeVariableConfigAdd(SndRequest.Vals vc, TreeNode ptn, ContextMenuStrip cms, TreeNode stn = null)
        //{
        //    if (null == stn)
        //    {
        //        ProjectNodeData projectNodeData = new ProjectNodeData();
        //        projectNodeData.variableSndRequest = vc;
        //        projectNodeData.nodeType = ProjectNodeType.Variable;

        //        TreeNode tn = new TreeNode(vc.Signal + " (" + vc.Name + ")");
        //        tn.ImageKey = ListImages.ImageKey.Elem;
        //        tn.SelectedImageKey = ListImages.ImageKey.Elem;
        //        tn.ContextMenuStrip = cms;
        //        tn.Tag = projectNodeData;

        //        ptn.Nodes.Add(tn);

        //        return tn;
        //    }
        //    return null;
        //}

        #endregion Project VariableConfig

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
                if (selectNode != null)
                {
                    trvProject.SelectedNode = selectNode;

                    // the ban on the transition
                    if (switchingNewControlLock == true)
                    {
                        trvProject.SelectedNode = null;
                        trvProject.SelectedNode = selectNodePrevious;
                    }
                    else
                    {
                        mtNodeData = (ProjectNodeData)selectNode.Tag;

                        if (selectNode != null)
                        {
                            LoadWindow(mtNodeData);
                        }
                    }
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

            if (switchingNewControlLock == true)
            {
                return;
            }

            // form
            if (mtNodeData.nodeType == ProjectNodeType.Channel && mtNodeData.channel != null)
            {
                //trvProject.ContextMenuStrip = new ContextMenuStrip();

                FrmChannel frmChannel = new FrmChannel(ref mtNodeData, true);
                frmChannel.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmChannel;
            }
            else if (mtNodeData.nodeType == ProjectNodeType.Device && mtNodeData.device != null)
            {
                //trvProject.ContextMenuStrip = new ContextMenuStrip();

                FrmDevice frmDevice = new FrmDevice(ref mtNodeData, true);
                frmDevice.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmDevice;
            }
            else if (mtNodeData.nodeType == ProjectNodeType.GroupCommand && mtNodeData.groupCommand != null)
            {

            }
            else if (mtNodeData.nodeType == ProjectNodeType.Command && mtNodeData.command != null)
            {
                //trvConfig.ContextMenuStrip = new ContextMenuStrip();

                switch (mtNodeData.command.FunctionCode)
                {
                    case ulong n when (n >= 1 && n <= 4):
                        FrmCommand1_2_3_4 frmCommand = new FrmCommand1_2_3_4(ref mtNodeData, true);
                        frmCommand.frmParentGloabal = this;
                        frmPropertyForm = new Form();
                        frmPropertyForm = frmCommand;
                        break;
                }
            }
            else
            {
                FrmEmpty frmEmpty = new FrmEmpty();
                frmEmpty.frmParentGloabal = this;
                frmPropertyForm = new Form();
                frmPropertyForm = frmEmpty;
            }

            //else if (mtNodeData.nodeType == ProjectNodeType.GroupCmdRequest && mtNodeData.groupCmdRequest != null)
            //{
            //    trvProject.ContextMenuStrip = cmnuGroupCmdRequestNode;
            //    cmnuAddCmdRequest.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.CmdRequest).Value;
            //}
            //else if (mtNodeData.nodeType == ProjectNodeType.CmdRequest && mtNodeData.cmdRequest != null)
            //{
            //    trvProject.ContextMenuStrip = cmnuVariableAction;
            //    cmnuDeleteVariable.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Delete).Value;
            //    сmnuSelectVariableActionUp.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Up).Value;
            //    сmnuSelectVariableActionDown.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Down).Value;
            //    if (mtNodeData.cmdRequest.CmdMode == "prog" || mtNodeData.cmdRequest.CmdMode == "LockA")
            //    {
            //        cmnuDeleteVariable.Enabled = false;
            //        сmnuSelectVariableActionUp.Enabled = false;
            //        сmnuSelectVariableActionDown.Enabled = false;
            //    }
            //    else
            //    {
            //        cmnuDeleteVariable.Enabled = true;
            //        сmnuSelectVariableActionUp.Enabled = true;
            //        сmnuSelectVariableActionDown.Enabled = true;
            //    }

            //    FrmCmdRequest frmCmdRequest = new FrmCmdRequest(ref mtNodeData, true);
            //    frmCmdRequest.frmParentGloabal = this;
            //    frmPropertyForm = new Form();
            //    frmPropertyForm = frmCmdRequest;
            //}
            //else if (mtNodeData.nodeType == ProjectNodeType.GroupSndRequest && mtNodeData.groupSndRequest != null)
            //{
            //    trvProject.ContextMenuStrip = cmnuGroupSndRequestNode;
            //    cmnuAddSndRequest.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.SndRequest).Value;
            //}
            //else if (mtNodeData.nodeType == ProjectNodeType.SndRequest && mtNodeData.sndRequest != null)
            //{
            //    TreeNode selectNode = trvProject.SelectedNode;

            //    trvProject.ContextMenuStrip = cmnuVariableNode;
            //    cmnuAddVariable.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Elem).Value;
            //    cmnuDeleteGroup.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Delete).Value;
            //    сmnuSelectVariableUp.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Up).Value;
            //    сmnuSelectVariableDown.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Down).Value;

            //    SndRequest projectSndRequst = mtNodeData.sndRequest;

            //    if (projectSndRequst.Values == null)
            //    {
            //        projectSndRequst.Values = new List<SndRequest.Vals>();
            //    }

            //    projectSndRequst.Values.Clear();

            //    foreach (TreeNode tagNode in selectNode.Nodes)
            //    {
            //        ProjectNodeData mtTagNodeData = (ProjectNodeData)tagNode.Tag;
            //        SndRequest.Vals projectVal = mtTagNodeData.variableSndRequest;
            //        projectSndRequst.Values.Add(projectVal);
            //    }

            //    FrmSndRequest frmSndRequest = new FrmSndRequest(ref mtNodeData, true);
            //    frmSndRequest.frmParentGloabal = this;
            //    frmPropertyForm = new Form();
            //    frmPropertyForm = frmSndRequest;
            //}
            //else if (mtNodeData.nodeType == ProjectNodeType.Variable && mtNodeData.variableSndRequest != null)
            //{
            //    trvProject.ContextMenuStrip = cmnuVariableAction;
            //    cmnuDeleteVariable.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Delete).Value;
            //    сmnuSelectVariableActionUp.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Up).Value;
            //    сmnuSelectVariableActionDown.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Down).Value;

            //    FrmVariable frmVariable = new FrmVariable(ref mtNodeData, true);
            //    frmVariable.frmParentGloabal = this;
            //    frmPropertyForm = new Form();
            //    frmPropertyForm = frmVariable;
            //}
            //else if (mtNodeData.nodeType == ProjectNodeType.GroupCmd && mtNodeData.groupCmd != null)
            //{
            //    trvProject.ContextMenuStrip = cmnuGroupCmdNode;
            //    cmnuAddCmd.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Cmd).Value;
            //}
            //else if (mtNodeData.nodeType == ProjectNodeType.Cmd && mtNodeData.cmd != null)
            //{
            //    trvProject.ContextMenuStrip = cmnuVariableAction;
            //    cmnuDeleteVariable.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Delete).Value;
            //    сmnuSelectVariableActionUp.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Up).Value;
            //    сmnuSelectVariableActionDown.Image = ListImages.GetTreeViewImages().FirstOrDefault(x => x.Key == ListImages.ImageKey.Down).Value;

            //    FrmCommand frmCommand = new FrmCommand(ref mtNodeData, true);
            //    frmCommand.frmParentGloabal = this;
            //    frmPropertyForm = new Form();
            //    frmPropertyForm = frmCommand;
            //}


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
            //if (ProjectNodeType.Device == mtNodeData.nodeType && mtNodeData.device != null)
            //{
            //    modified = ((FrmDevice)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.CmdRequest == mtNodeData.nodeType && mtNodeData.cmdRequest != null)
            //{
            //    modified = ((FrmCmdRequest)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.SndRequest == mtNodeData.nodeType && mtNodeData.sndRequest != null)
            //{
            //    modified = ((FrmSndRequest)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.Variable == mtNodeData.nodeType && mtNodeData.variableSndRequest != null)
            //{
            //    modified = ((FrmVariable)frmPropertyForm).modified;
            //}

            //if (ProjectNodeType.Cmd == mtNodeData.nodeType && mtNodeData.cmd != null)
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
            // the ban on the transition
            if (switchingNewControlLock == true && modified == true)
            {
                return;
            }

            TreeNode selectNode = trvProject.SelectedNode;
            mtNodeData = (ProjectNodeData)selectNode.Tag;

            // we load the window on the right and its properties
            if (switchingNewControlLock == false)
            {
                LoadWindow(mtNodeData);
            }

            if (switchingNewControlLock == true)
            {
                trvProject.SelectedNode = selectNodePrevious;
                switchingNewControlLock = false;
            }

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
            frmSettings.settings = driverConfig.Settings;
            // showing the form
            DialogResult dialog = frmSettings.ShowDialog();
            // if you have closed the form, click OK
            if (DialogResult.OK == dialog)
            {
                driverConfig.Settings = frmSettings.settings;
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

            if (driverConfig.Settings.ProjectChannel.GatewayTypeProtocol == 0)
            {
                //Если шлюз не указан т.е. выключен, то генерируем порт 
                currentPort = TcpServerPortGenerator.New();
            }
            else
            {
                bool checkedPort = TcpServerPortGenerator.CheckAvailableServerPort(Convert.ToInt32(driverConfig.Settings.ProjectChannel.GatewayPort));
                if (checkedPort == false)
                {
                    //MessageBox.Show("Указанный порт " + project.Settings.ProjectChannel.GatewayPort + " занят! Попробуйте другой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            #endregion Port

            DriverClient.OnDebug = new DriverClient.DebugData(DebugerLog);
            driverClient = new DriverClient(driverConfig);
            driverClient.InitializingDriver();

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
    }
}
