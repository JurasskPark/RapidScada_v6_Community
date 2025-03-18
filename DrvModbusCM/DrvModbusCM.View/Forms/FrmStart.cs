using Scada.Comm.Drivers.DrvModbusCM;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();

            ProjectOpen();
        }

        #region Variables
        public Project project;                                        // the project configuration
        private string configFileName;                                 // the configuration file name
        #endregion Variables

        #region Start App
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
        private void tolApplicationSave_Click(object sender, EventArgs e)
        {
            ProjectSave();
        }

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

        private void tolApplicationNew_Click(object sender, EventArgs e)
        {
            ProjectNew();
        }

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

        private void tolApplicationOpen_Click(object sender, EventArgs e)
        {
            ProjectOpenDialog();
        }

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

        private void tolApplicationSaveAs_Click(object sender, EventArgs e)
        {
            ProjectSaveDialog();
        }

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
        private void tolConfiguration_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.MdiParent = this;
            frmConfig.Text = frmConfig.Text.ToString();
            frmConfig.WindowState = FormWindowState.Maximized;
            frmConfig.formParent = this;
            frmConfig.project = project;
            frmConfig.Show();
        }

        #endregion Configuration

        #region Setting
        private void tolSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.MdiParent = this;
            frmSettings.Text = frmSettings.Text.ToString();
            frmSettings.WindowState = FormWindowState.Maximized;
            frmSettings.formParent = this;
            frmSettings.project = project;
            frmSettings.Show();
        }
        #endregion Setting

        #region Tools
        private void tolConverter_Click(object sender, EventArgs e)
        {
            //FrmConverter frmConverter = new FrmConverter();
            //frmConverter.Show();
        }
        #endregion Tools

        #region Windows

        private void tolCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tolHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tolVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        #endregion Windows





    }
}
