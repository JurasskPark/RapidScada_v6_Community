using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        public ProjectSettings settings;

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            #region Debug
            ckbAutoRun.Checked = settings.AutoRun;
            ckbDebug.Checked = settings.Debug;

            #endregion Debug
        }

        private void SaveSettings()
        {
            #region Debug
            settings.AutoRun = ckbAutoRun.Checked;
            settings.Debug = ckbDebug.Checked;
            #endregion Debug
        }

        private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
            Close();
        }


    }
}
