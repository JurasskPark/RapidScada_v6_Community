using Scada.Comm.Drivers.DrvModbusCM;
using System.Diagnostics;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmStart : Form
    {
        public FrmStart()
        {
            InitializeComponent();

            InitializeWindows();

            ProjectOpen();


           
        }

        #region Variables
        public Project project;                                        // the project configuration
        private string configFileName;                                 // the configuration file name

        private int childFormCount = 0;
        #endregion Variables

        private void InitializeWindows()
        {
            this.tolHorizontal.Tag = MdiLayout.TileHorizontal;
            this.tolVertical.Tag = MdiLayout.TileVertical;
            this.tolCascade.Tag = MdiLayout.Cascade;           
        }



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

            Child_AddForm(frmConfig);
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

            Child_AddForm(frmSettings);
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

        private void tolCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
       

        #endregion Windows







    }
}
