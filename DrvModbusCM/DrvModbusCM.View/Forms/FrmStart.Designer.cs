namespace Scada.Comm.Drivers.DrvModbusCM.View
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
            tolTools = new ToolStripMenuItem();
            tolConverter = new ToolStripMenuItem();
            tolSettings = new ToolStripMenuItem();
            tolWindows = new ToolStripMenuItem();
            tolSeparator1 = new ToolStripSeparator();
            tolCascade = new ToolStripMenuItem();
            tolHorizontal = new ToolStripMenuItem();
            tolVertical = new ToolStripMenuItem();
            tolSeparator2 = new ToolStripSeparator();
            tolCloseAll = new ToolStripMenuItem();
            tolDebug = new ToolStripMenuItem();
            tolEmptySpace = new ToolStripMenuItem();
            tolLang = new ToolStripMenuItem();
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
            // 
            // mnuMenu
            // 
            mnuMenu.Items.AddRange(new ToolStripItem[] { tolProject, tolAdministration, tolTools, tolSettings, tolWindows, tolDebug, tolEmptySpace, tolLang });
            mnuMenu.Location = new Point(0, 0);
            mnuMenu.Name = "mnuMenu";
            mnuMenu.Size = new Size(800, 24);
            mnuMenu.TabIndex = 1;
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
            tolAdministration.DropDownItems.AddRange(new ToolStripItem[] { tolConfiguration });
            tolAdministration.Image = (Image)resources.GetObject("tolAdministration.Image");
            tolAdministration.Name = "tolAdministration";
            tolAdministration.Size = new Size(114, 20);
            tolAdministration.Text = "Administration";
            // 
            // tolConfiguration
            // 
            tolConfiguration.Image = (Image)resources.GetObject("tolConfiguration.Image");
            tolConfiguration.Name = "tolConfiguration";
            tolConfiguration.Size = new Size(180, 22);
            tolConfiguration.Text = "Configuration";
            tolConfiguration.Click += tolConfiguration_Click;
            // 
            // tolTools
            // 
            tolTools.DropDownItems.AddRange(new ToolStripItem[] { tolConverter });
            tolTools.Image = (Image)resources.GetObject("tolTools.Image");
            tolTools.Name = "tolTools";
            tolTools.Size = new Size(62, 20);
            tolTools.Text = "Tools";
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
            // tolWindows
            // 
            tolWindows.DropDownItems.AddRange(new ToolStripItem[] { tolSeparator1, tolCascade, tolHorizontal, tolVertical, tolSeparator2, tolCloseAll });
            tolWindows.Image = (Image)resources.GetObject("tolWindows.Image");
            tolWindows.Name = "tolWindows";
            tolWindows.Size = new Size(84, 20);
            tolWindows.Text = "Windows";
            // 
            // tolSeparator1
            // 
            tolSeparator1.Name = "tolSeparator1";
            tolSeparator1.Size = new Size(126, 6);
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
            // tolSeparator2
            // 
            tolSeparator2.Name = "tolSeparator2";
            tolSeparator2.Size = new Size(126, 6);
            // 
            // tolCloseAll
            // 
            tolCloseAll.Name = "tolCloseAll";
            tolCloseAll.Size = new Size(129, 22);
            tolCloseAll.Text = "Close All";
            tolCloseAll.Click += tolCloseAll_Click;
            // 
            // tolDebug
            // 
            tolDebug.Image = (Image)resources.GetObject("tolDebug.Image");
            tolDebug.Name = "tolDebug";
            tolDebug.Size = new Size(70, 20);
            tolDebug.Text = "Debug";
            tolDebug.Click += tolDebug_Click;
            // 
            // tolEmptySpace
            // 
            tolEmptySpace.Alignment = ToolStripItemAlignment.Right;
            tolEmptySpace.Name = "tolEmptySpace";
            tolEmptySpace.Size = new Size(37, 20);
            tolEmptySpace.Text = "      ";
            // 
            // tolLang
            // 
            tolLang.Alignment = ToolStripItemAlignment.Right;
            tolLang.Image = (Image)resources.GetObject("tolLang.Image");
            tolLang.Name = "tolLang";
            tolLang.Size = new Size(87, 20);
            tolLang.Text = "Language";
            tolLang.Click += tolLang_Click;
            // 
            // imgListMenu
            // 
            imgListMenu.ColorDepth = ColorDepth.Depth32Bit;
            imgListMenu.ImageStream = (ImageListStreamer)resources.GetObject("imgListMenu.ImageStream");
            imgListMenu.TransparentColor = Color.Transparent;
            imgListMenu.Images.SetKeyName(0, "flag_russia.png");
            imgListMenu.Images.SetKeyName(1, "flag_usa.png");
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
            Text = "Rapid Scada Community Modbus Driver";
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
        private ToolStripMenuItem tolWindows;
        private ToolStripMenuItem tolCascade;
        private ToolStripMenuItem tolHorizontal;
        private ToolStripMenuItem tolVertical;
        private ToolStripMenuItem tolProject;
        private ToolStripMenuItem tolProjectOpen;
        private ToolStripMenuItem tolProjectSave;
        private ToolStripMenuItem tolTools;
        private ToolStripMenuItem tolConverter;
        private ToolStripMenuItem tolDebug;
        private ToolStripMenuItem tolProjectNew;
        private ToolStripMenuItem tolProjectSaveAs;
        private ToolStripMenuItem tolConfiguration;
        private ToolStripMenuItem tolCloseAll;
        private ToolStripSeparator tolSeparator1;
        private ToolStripSeparator tolSeparator2;
        private ToolStripMenuItem tolLang;
        private ToolStripMenuItem tolEmptySpace;
        public ImageList imgListMenu;
    }
}