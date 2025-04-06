using Scada.Comm.Drivers.DrvModbusCM;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmStart : Form
    {
        #region InitializeComponent
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmStart()
        {
            InitializeComponent();

            InitializeWindows();
            ProjectOpen();         
        }
        #endregion InitializeComponent

        #region Variables
        public Project project;                                        // the project configuration
        private string configFileName;                                 // the configuration file name
        #endregion Variables

        #region Start App
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public void ProjectOpen()
        {
            string errMsg = string.Empty;
            project = new Project();
            configFileName = Path.Combine(Application.StartupPath, DriverUtils.GetFileName());
            project.Load(configFileName, out errMsg);

            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Start App

        #region Save App
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolApplicationSave_Click(object sender, EventArgs e)
        {
            ProjectSave();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        public void ProjectSave()
        {
            string errMsg = string.Empty;
            project.Save(configFileName, out errMsg);
            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Save App

        #region Application
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolApplicationNew_Click(object sender, EventArgs e)
        {
            ProjectNew();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectNew()
        {
            string errMsg = string.Empty;
            configFileName = Path.Combine(Application.StartupPath, DriverUtils.GetFileName());

            project.Driver = new ProjectDriver();

            project.Save(configFileName, out errMsg);
            project.Load(configFileName, out errMsg);

            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolApplicationOpen_Click(object sender, EventArgs e)
        {
            ProjectOpenDialog();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectOpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ofd.FileName = "";
            string errMsg = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                project.Load(ofd.FileName, out errMsg);
            }
            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolApplicationSaveAs_Click(object sender, EventArgs e)
        {
            ProjectSaveDialog();
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ProjectSaveDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            sfd.FileName = "";
            string errMsg = string.Empty;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                project.Save(sfd.FileName, out errMsg);
            }
            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Application

        #region Configuration
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolConfiguration_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.MdiParent = this;
            frmConfig.Text = frmConfig.Text.ToString();
            frmConfig.WindowState = FormWindowState.Maximized;
            frmConfig.formParent = this;
            frmConfig.project = project;
            frmConfig.Show();

            Child_AddForm(frmConfig);
        }
        #endregion Configuration

        #region Setting
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.MdiParent = this;
            frmSettings.Text = frmSettings.Text.ToString();
            frmSettings.WindowState = FormWindowState.Maximized;
            frmSettings.formParent = this;
            frmSettings.project = project;
            frmSettings.Show();

            Child_AddForm(frmSettings);
        }
        #endregion Setting

        #region Tools
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolConverter_Click(object sender, EventArgs e)
        {
            //FrmConverter frmConverter = new FrmConverter();
            //frmConverter.Show();
        }
        #endregion Tools

        #region Windows
        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void InitializeWindows()
        {
            this.tolHorizontal.Tag = MdiLayout.TileHorizontal;
            this.tolVertical.Tag = MdiLayout.TileVertical;
            this.tolCascade.Tag = MdiLayout.Cascade;
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void Child_AddForm(Form child)
        {
            // Capture the event when the child form is closed.
            child.FormClosing += Child_FormClosing;

            // Show the child form.
            child.Show();

            // Create a menu item for the child form.
            var menu = new ToolStripMenuItem(child.Text)
            {
                Tag = child // Link menu to associated form.
            };

            // Capture menu click event.
            menu.Click += ChildFormMenu_Click;

            // Insert the menu above the seperator.
            int index = 0;
            foreach (ToolStripItem item in tolWindows.DropDownItems)
            {
                if (item.GetType() == typeof(ToolStripSeparator))
                {
                    break;
                }
                else
                {
                    index++;
                }
            }
            if (index < tolWindows.DropDownItems.Count)
            {
                tolWindows.DropDownItems.Insert(index, menu);
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void Child_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Find and remove the corresponding menu item.
                var form = sender as Form;
                var menu = tolWindows.DropDownItems.Cast<ToolStripItem>().FirstOrDefault(x => x.Text == form.Text);
                if (menu != null)
                {
                    tolWindows.DropDownItems.Remove(menu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void ChildFormMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var menu = sender as ToolStripMenuItem;
                var form = (Form)menu.Tag;
                form.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// 
        /// <para></para>
        /// </summary>
        private void tolCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion Windows

        #region 
        private void tlsProjectStartStop_Click(object sender, EventArgs e)
        {
            StartProcess();
        }

        private void StartProcess()
        {
            #region Save Load

            //SaveProject();
            //ProjectLoad();

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

        #endregion

    }
}
