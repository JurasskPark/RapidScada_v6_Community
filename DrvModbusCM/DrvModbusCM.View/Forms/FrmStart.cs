using DrvModbusCM.View.Forms.Log;
using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Forms;
using Scada.Lang;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmStart : Form
    {
        #region InitializeComponent
        /// <summary>
        /// Initializes a new instance of the class.
        /// <para>Инициализирует новый экземпляр класса.</para>
        /// </summary>
        public FrmStart()
        {
            InitializeComponent();

            InitializeWindows();
            this.appDirectory = ApplicationPath.StartPath;
            this.languageDir = ApplicationPath.LangDir;
            ProjectOpen();
            LoadLanguage(languageDir, project.Driver.Settings.LanguageIsRussian);
            Translate();
        }
        #endregion InitializeComponent

        #region Variables
        string appDirectory;                                           // the applications directory
        string languageDir;                                            // the language directory
        private string culture = "en-GB";                              // the culture
        bool isRussian;												   // the language

        public Project project;                                        // the project configuration
        private string configFileName;                                 // the configuration file name

        DriverThread driverThread;                                     // the driver thread
        #endregion Variables

        #region Application
        /// <summary>
        /// Create a new project.
        /// <para>Создать новый проект.</para>
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
        /// Open project.
        /// <para>Открыть проект.</para>
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

        /// <summary>
        /// Open the project via the dialog form.
        /// <para>Открыть проект через диалоговую форму.</para>
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
        /// Save the project.
        /// <para>Сохранить проект.</para>
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

        /// <summary>
        /// Save the project via the dialog form.
        /// <para>Сохранить проект через диалоговую форму.</para>
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

        #region Menu
        /// <summary>
        /// A menu item. Create a new project.
        /// <para>Пункт меню. Создать новый проект.</para>
        /// </summary>
        private void tolApplicationNew_Click(object sender, EventArgs e)
        {
            ProjectNew();
        }

        /// <summary>
        /// A menu item. Open the project via the dialog form.
        /// <para>Пункт меню. Открыть проект через диалоговую форму.</para>
        /// </summary>
        private void tolApplicationOpen_Click(object sender, EventArgs e)
        {
            ProjectOpenDialog();
        }

        /// <summary>
        /// A menu item. Save the project.
        /// <para>Пункт меню. Сохранить проект.</para>
        /// </summary>
        private void tolApplicationSave_Click(object sender, EventArgs e)
        {
            ProjectSave();
        }

        /// <summary>
        /// A menu item. Save the project via the dialog form.
        /// <para>Пункт меню. Сохранить проект через диалоговую форму.</para>
        /// </summary>
        private void tolApplicationSaveAs_Click(object sender, EventArgs e)
        {
            ProjectSaveDialog();
        }

        /// <summary>
        /// A menu item. Change the language and save the parameter to the project.
        /// <para>Пункт меню. Изменение языка и сохранение параметра в проект.</para>
        /// </summary>
        private void tolLang_Click(object sender, EventArgs e)
        {
            ChangeLanguage();
        }
        #endregion Menu

        #region Lang
        /// <summary>
        /// Change the language and save the parameter to the project.
        /// <para>Изменение языка и сохранение параметра в проект.</para>
        /// </summary>
        public void ChangeLanguage()
        {
            isRussian = !isRussian;
            if (isRussian)
            {
                tolLang.Image = imgListMenu.Images[1];
            }
            else
            {
                tolLang.Image = imgListMenu.Images[0];
            }
            LoadLanguage(languageDir, isRussian);
            Translate();

            project.Driver.Settings.LanguageIsRussian = isRussian;
            ProjectSave();
        }

        /// <summary>
        /// Loading from the translation catalog by language.
        /// <para>Загрузка из каталога перевода по признаку языка</para>
        /// </summary>
        public void LoadLanguage(string languageDir, bool IsRussian = false)
        {
            this.languageDir = languageDir;
            // load translate
            this.isRussian = IsRussian;

            culture = "en-GB";
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
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.FrmStart");
            Locale.GetDictionary("Scada.Comm.Drivers.DrvModbusCM.View.Config");
            CommonPhrases.Init();

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
        }
        #endregion Lang

        #region Configuration
        /// <summary>
        /// Open the form with the basic settings of the application.
        /// <para>Открыть форму с основными настройками приложения.</para>
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

        /// <summary>
        /// Open the form with the application logs.
        /// <para>Открыть форму с логами приложения.</para>
        /// </summary>
        private void tolLogs_Click(object sender, EventArgs e)
        {
            FrmLogs frmLogs = new FrmLogs();
            frmLogs.MdiParent = this;
            frmLogs.Text = frmLogs.Text.ToString();
            frmLogs.WindowState = FormWindowState.Maximized;
            frmLogs.formParent = this;
            frmLogs.project = project;
            frmLogs.Show();

            Child_AddForm(frmLogs);
        }
        #endregion Configuration

        #region Setting
        /// <summary>
        /// Open the form with additional application settings.
        /// <para>Открыть форму с дополнительными настройками приложения.</para>
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
        /// Open the form with the converter.
        /// <para>Открыть форму с конвертером.</para>
        /// </summary>
        private void tolConverter_Click(object sender, EventArgs e)
        {
            //FrmConverter frmConverter = new FrmConverter();
            //frmConverter.Show();
        }
        #endregion Tools

        #region Windows
        /// <summary>
        /// Initialization of form window settings.
        /// <para>Инициализация настроек окон форм.</para>
        /// </summary>
        private void InitializeWindows()
        {
            this.tolHorizontal.Tag = MdiLayout.TileHorizontal;
            this.tolVertical.Tag = MdiLayout.TileVertical;
            this.tolCascade.Tag = MdiLayout.Cascade;
        }

        /// <summary>
        /// Adding an open child form to the list of windows.
        /// <para>Добавление открытой дочерней формы в список окон.</para>
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
        /// Closing a child form.
        /// <para>Закрытие дочерней формы.</para>
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
        /// Adding information about a child form to a menu item.
        /// <para>Добавлению информации о дочерней формы в пункт меню.</para>
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
        /// Building child forms in the form of a cascade.
        /// <para>Выстраивание дочерних форм в виде каскада.</para>
        /// </summary>
        private void tolCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Building child forms horizontal.
        /// <para>Выстраивание дочерних форм по горизонтали.</para>
        /// </summary>
        private void tolHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Building child forms vertically.
        /// <para>Выстраивание дочерних форм по вертикали.</para>
        /// </summary>
        private void tolVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Close all open child forms.
        /// <para>Закрыть все открытые дочерние формы.</para>
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

        }



        public void DebugerLog(string text)
        {

        }

        void PollLogGet(string text)
        {
            //FrmViewData.SetLog(text);
        }

        void PollLogGetTCPServer(string text)
        {
            //FrmViewData.SetLogTcpServer(text);
        }


        #endregion

        private void tolDebug_Click(object sender, EventArgs e)
        {
            driverThread = new DriverThread(project);
            driverThread.ThreadsStart();
        }

        private void tolDebugStop_Click(object sender, EventArgs e)
        {
            if(driverThread != null)
            {
                driverThread.ThreadsStop();
            }
        }
    }
}
