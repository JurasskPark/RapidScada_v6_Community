﻿using Scada.Lang;
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
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FrmSettings(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            settings = ProjectNodeData.Settings;
            boolParent = hasParent;
            InitializeComponent();
            FormatWindow(boolParent);
        }

        /// <summary>
        /// The format of the window to display on the TabControl.
        /// </summary>
        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                btnSave.Visible = true;
                btnCancel.Enabled = false;
                Dock = DockStyle.Left | DockStyle.Top;
                TopLevel = false;
            }
        }

        #region Variables
        public FrmStart formParent;                     // parent form
        public Project project;                         // the project configuration
        public ProjectSettings settings;                // settings project
        public bool boolParent = false;                 // сhild startup flag
        private bool modified;                          // the configuration was modified
        #endregion Variables

        #region Form Load
        /// <summary>
        /// 
        /// </summary>
        private void FrmSettings_Load(object sender, EventArgs e)
        {
            ConfigToControls();
        }
        #endregion Form Load

        #region Config 

        /// <summary>
        /// Sets the controls according to the configuration.
        /// </summary>
        private void ConfigToControls()
        {
            // set the control values
            settings = project.Driver.Settings;

            ckbAutoRun.Checked = settings.AutoRun;
            ckbDebug.Checked = settings.Debug;
        }

        /// <summary>
        /// Sets the controls according to the configuration.
        /// </summary>
        private void ControlsToConfig()
        {
            // get the control values
            settings.AutoRun = ckbAutoRun.Checked;
            settings.Debug = ckbDebug.Checked;

            project.Driver.Settings = settings;
        }


        #endregion Config 

        #region Modified
        /// <summary>
        /// Gets or sets a value indicating whether the configuration was modified.
        /// </summary>
        private bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                btnSave.Enabled = modified;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the configuration was modified.
        /// </summary>
        private void control_Changed(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion Modified

        #region Control
        /// <summary>
        /// Close the form and save the settings.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ControlsToConfig();
            formParent.ProjectSave();
            Modified = false;
            if (boolParent == false)
            {
                Close();
            }
        }

        /// <summary>
        /// Closing the form without saving settings.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion Control


    }
}
