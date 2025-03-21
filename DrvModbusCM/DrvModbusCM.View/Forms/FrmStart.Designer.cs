﻿namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmStart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStart));
            stsStrip = new StatusStrip();
            mnuMenu = new MenuStrip();
            tolProject = new ToolStripMenuItem();
            tolProjectNew = new ToolStripMenuItem();
            tolProjectOpen = new ToolStripMenuItem();
            tolProjectSave = new ToolStripMenuItem();
            tolProjectSaveAs = new ToolStripMenuItem();
            tolAdministration = new ToolStripMenuItem();
            tolConfiguration = new ToolStripMenuItem();
            tolTables = new ToolStripMenuItem();
            tolServers = new ToolStripMenuItem();
            tolDevices = new ToolStripMenuItem();
            tolCommands = new ToolStripMenuItem();
            tolTemplates = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            tolConverter = new ToolStripMenuItem();
            tolSettings = new ToolStripMenuItem();
            tolWindow = new ToolStripMenuItem();
            tolCascade = new ToolStripMenuItem();
            tolHorizontal = new ToolStripMenuItem();
            tolVertical = new ToolStripMenuItem();
            tolDebug = new ToolStripMenuItem();
            imgListMenu = new ImageList(components);
            mnuMenu.SuspendLayout();
            SuspendLayout();
            // 
            // stsStrip
            // 
            stsStrip.Location = new Point(0, 428);
            stsStrip.Name = "stsStrip";
            stsStrip.Size = new Size(800, 22);
            stsStrip.TabIndex = 0;
            stsStrip.Text = "statusStrip1";
            // 
            // mnuMenu
            // 
            mnuMenu.Items.AddRange(new ToolStripItem[] { tolProject, tolAdministration, toolsToolStripMenuItem, tolSettings, tolWindow, tolDebug });
            mnuMenu.Location = new Point(0, 0);
            mnuMenu.Name = "mnuMenu";
            mnuMenu.Size = new Size(800, 24);
            mnuMenu.TabIndex = 1;
            mnuMenu.Text = "menuStrip1";
            // 
            // tolProject
            // 
            tolProject.DropDownItems.AddRange(new ToolStripItem[] { tolProjectNew, tolProjectOpen, tolProjectSave, tolProjectSaveAs });
            tolProject.Image = (Image)resources.GetObject("tolProject.Image");
            tolProject.Name = "tolProject";
            tolProject.Size = new Size(72, 20);
            tolProject.Text = "Project";
            // 
            // tolProjectNew
            // 
            tolProjectNew.Image = (Image)resources.GetObject("tolProjectNew.Image");
            tolProjectNew.Name = "tolProjectNew";
            tolProjectNew.Size = new Size(123, 22);
            tolProjectNew.Text = "New";
            tolProjectNew.Click += tolApplicationNew_Click;
            // 
            // tolProjectOpen
            // 
            tolProjectOpen.Image = (Image)resources.GetObject("tolProjectOpen.Image");
            tolProjectOpen.Name = "tolProjectOpen";
            tolProjectOpen.Size = new Size(123, 22);
            tolProjectOpen.Text = "Open";
            tolProjectOpen.Click += tolApplicationOpen_Click;
            // 
            // tolProjectSave
            // 
            tolProjectSave.Image = (Image)resources.GetObject("tolProjectSave.Image");
            tolProjectSave.Name = "tolProjectSave";
            tolProjectSave.Size = new Size(123, 22);
            tolProjectSave.Text = "Save";
            tolProjectSave.Click += tolApplicationSave_Click;
            // 
            // tolProjectSaveAs
            // 
            tolProjectSaveAs.Image = (Image)resources.GetObject("tolProjectSaveAs.Image");
            tolProjectSaveAs.Name = "tolProjectSaveAs";
            tolProjectSaveAs.Size = new Size(123, 22);
            tolProjectSaveAs.Text = "Save As...";
            tolProjectSaveAs.Click += tolApplicationSaveAs_Click;
            // 
            // tolAdministration
            // 
            tolAdministration.DropDownItems.AddRange(new ToolStripItem[] { tolConfiguration, tolTables });
            tolAdministration.Image = (Image)resources.GetObject("tolAdministration.Image");
            tolAdministration.Name = "tolAdministration";
            tolAdministration.Size = new Size(114, 20);
            tolAdministration.Text = "Administration";
            // 
            // tolConfiguration
            // 
            tolConfiguration.Name = "tolConfiguration";
            tolConfiguration.Size = new Size(180, 22);
            tolConfiguration.Text = "Configuration";
            tolConfiguration.Click += tolConfiguration_Click;
            // 
            // tolTables
            // 
            tolTables.DropDownItems.AddRange(new ToolStripItem[] { tolServers, tolDevices, tolCommands, tolTemplates });
            tolTables.Image = (Image)resources.GetObject("tolTables.Image");
            tolTables.Name = "tolTables";
            tolTables.Size = new Size(180, 22);
            tolTables.Text = "Tables";
            // 
            // tolServers
            // 
            tolServers.Image = (Image)resources.GetObject("tolServers.Image");
            tolServers.Name = "tolServers";
            tolServers.Size = new Size(180, 22);
            tolServers.Text = "Servers";
            
            // 
            // tolDevices
            // 
            tolDevices.Image = (Image)resources.GetObject("tolDevices.Image");
            tolDevices.Name = "tolDevices";
            tolDevices.Size = new Size(180, 22);
            tolDevices.Text = "Devices";

            // 
            // tolCommands
            // 
            tolCommands.Image = (Image)resources.GetObject("tolCommands.Image");
            tolCommands.Name = "tolCommands";
            tolCommands.Size = new Size(180, 22);
            tolCommands.Text = "Commands";
  
            // 
            // tolTemplates
            // 
            tolTemplates.Image = (Image)resources.GetObject("tolTemplates.Image");
            tolTemplates.Name = "tolTemplates";
            tolTemplates.Size = new Size(180, 22);
            tolTemplates.Text = "Templates";

            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tolConverter });
            toolsToolStripMenuItem.Image = (Image)resources.GetObject("toolsToolStripMenuItem.Image");
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(62, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // tolConverter
            // 
            tolConverter.Image = (Image)resources.GetObject("tolConverter.Image");
            tolConverter.Name = "tolConverter";
            tolConverter.Size = new Size(126, 22);
            tolConverter.Text = "Converter";
            tolConverter.Click += tolConverter_Click;
            // 
            // tolSettings
            // 
            tolSettings.Image = (Image)resources.GetObject("tolSettings.Image");
            tolSettings.Name = "tolSettings";
            tolSettings.Size = new Size(77, 20);
            tolSettings.Text = "Settings";
            tolSettings.Click += tolSettings_Click;
            // 
            // tolWindow
            // 
            tolWindow.DropDownItems.AddRange(new ToolStripItem[] { tolCascade, tolHorizontal, tolVertical });
            tolWindow.Image = (Image)resources.GetObject("tolWindow.Image");
            tolWindow.Name = "tolWindow";
            tolWindow.Size = new Size(84, 20);
            tolWindow.Text = "Windows";
            // 
            // tolCascade
            // 
            tolCascade.Image = (Image)resources.GetObject("tolCascade.Image");
            tolCascade.Name = "tolCascade";
            tolCascade.Size = new Size(129, 22);
            tolCascade.Text = "Cascade";
            tolCascade.Click += tolCascade_Click;
            // 
            // tolHorizontal
            // 
            tolHorizontal.Image = (Image)resources.GetObject("tolHorizontal.Image");
            tolHorizontal.Name = "tolHorizontal";
            tolHorizontal.Size = new Size(129, 22);
            tolHorizontal.Text = "Horizontal";
            tolHorizontal.Click += tolHorizontal_Click;
            // 
            // tolVertical
            // 
            tolVertical.Image = (Image)resources.GetObject("tolVertical.Image");
            tolVertical.Name = "tolVertical";
            tolVertical.Size = new Size(129, 22);
            tolVertical.Text = "Vertical";
            tolVertical.Click += tolVertical_Click;
            // 
            // tolDebug
            // 
            tolDebug.Image = (Image)resources.GetObject("tolDebug.Image");
            tolDebug.Name = "tolDebug";
            tolDebug.Size = new Size(70, 20);
            tolDebug.Text = "Debug";
            // 
            // imgListMenu
            // 
            imgListMenu.ColorDepth = ColorDepth.Depth32Bit;
            imgListMenu.ImageSize = new Size(16, 16);
            imgListMenu.TransparentColor = Color.Transparent;
            // 
            // FrmStart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(stsStrip);
            Controls.Add(mnuMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            KeyPreview = true;
            MainMenuStrip = mnuMenu;
            Name = "FrmStart";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modbus Community";
            WindowState = FormWindowState.Maximized;
            mnuMenu.ResumeLayout(false);
            mnuMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip stsStrip;
        private MenuStrip mnuMenu;
        private ToolStripMenuItem tolSettings;
        private ToolStripMenuItem tolAdministration;
        private ToolStripMenuItem tolTables;
        private ToolStripMenuItem tolDevices;
        private ToolStripMenuItem tolWindow;
        private ToolStripMenuItem tolCascade;
        private ToolStripMenuItem tolHorizontal;
        private ToolStripMenuItem tolVertical;
        private ToolStripMenuItem tolProject;
        private ToolStripMenuItem tolProjectOpen;
        private ToolStripMenuItem tolProjectSave;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem tolServers;
        private ToolStripMenuItem tolCommands;
        private ToolStripMenuItem tolConverter;
        private ToolStripMenuItem tolTemplates;
        private ToolStripMenuItem tolDebug;
        private ImageList imgListMenu;
        private ToolStripMenuItem tolProjectNew;
        private ToolStripMenuItem tolProjectSaveAs;
        private ToolStripMenuItem tolConfiguration;
    }
}