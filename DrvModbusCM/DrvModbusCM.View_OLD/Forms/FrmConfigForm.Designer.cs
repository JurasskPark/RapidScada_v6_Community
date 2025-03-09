namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class FrmConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigForm));
            trvProject = new TreeView();
            imgList = new ImageList(components);
            cmnuDeviceVTDCommandAddRead82 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead83 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead84 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead85 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead86 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead87 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead88 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead90 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead91 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead95 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddWrite96 = new ToolStripMenuItem();
            cmnuDeviceOther = new ToolStripMenuItem();
            cmnuDeviceOtherCommandAddRead99 = new ToolStripMenuItem();
            cmnuCommandImport = new ToolStripMenuItem();
            cmnuCommandImportSelect = new ToolStripMenuItem();
            cmnuCommandImportAll = new ToolStripMenuItem();
            cmnuCommandGenerate = new ToolStripMenuItem();
            cmnuCommandDelete = new ContextMenuStrip(components);
            cmnuCommandUp = new ToolStripMenuItem();
            cmnuCommandDown = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            cmnuCommandDel = new ToolStripMenuItem();
            cmnuDeviceTagAppend = new ContextMenuStrip(components);
            cmnuDeviceTagAdd = new ToolStripMenuItem();
            cmnuDeviceTagDelete = new ContextMenuStrip(components);
            cmnuDeviceTagDel = new ToolStripMenuItem();
            tmrTimer = new System.Windows.Forms.Timer(components);
            sptContainer = new SplitContainer();
            tabControl = new TabControl();
            cmnuDeviceVTDCommandAddRead81 = new ToolStripMenuItem();
            cmnuDeviceVTDCommandAddRead80 = new ToolStripMenuItem();
            tlsMenu = new ToolStrip();
            tlsProjectNew = new ToolStripButton();
            tlsProjectOpen = new ToolStripButton();
            tlsProjectSave = new ToolStripButton();
            tlsProjectSaveAs = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tlsProjectStartStop = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tlsProjectDataView = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            mnuMenu = new MenuStrip();
            mnuProject = new ToolStripMenuItem();
            mnuProjectNew = new ToolStripMenuItem();
            mnuProjectOpen = new ToolStripMenuItem();
            mnuProjectSave = new ToolStripMenuItem();
            mnuProjectSaveAs = new ToolStripMenuItem();
            mnuUtils = new ToolStripMenuItem();
            mnuConverter = new ToolStripMenuItem();
            mnuSettings = new ToolStripMenuItem();
            cmnuDeviceAppend = new ContextMenuStrip(components);
            cmnuDeviceAdd = new ToolStripMenuItem();
            cmnuDeviceDelete = new ContextMenuStrip(components);
            cmnuDeviceDel = new ToolStripMenuItem();
            cmnuCommandAppend = new ContextMenuStrip(components);
            cmnuCommandAdd = new ToolStripMenuItem();
            cmnuDeviceModbus = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadCoils = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadInputs = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadHoldingRegisters = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadInputRegisters = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteCoil = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteInputRegister = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteCoils = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteInputRegisters = new ToolStripMenuItem();
            cmnuDeviceVTD = new ToolStripMenuItem();
            imgListForm = new ImageList(components);
            cmnuCommandDelete.SuspendLayout();
            cmnuDeviceTagAppend.SuspendLayout();
            cmnuDeviceTagDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sptContainer).BeginInit();
            sptContainer.Panel1.SuspendLayout();
            sptContainer.Panel2.SuspendLayout();
            sptContainer.SuspendLayout();
            tlsMenu.SuspendLayout();
            mnuMenu.SuspendLayout();
            cmnuDeviceAppend.SuspendLayout();
            cmnuDeviceDelete.SuspendLayout();
            cmnuCommandAppend.SuspendLayout();
            SuspendLayout();
            // 
            // trvProject
            // 
            trvProject.Dock = DockStyle.Fill;
            trvProject.ImageIndex = 0;
            trvProject.ImageList = imgList;
            trvProject.Location = new Point(0, 0);
            trvProject.Name = "trvProject";
            trvProject.SelectedImageIndex = 0;
            trvProject.Size = new Size(303, 758);
            trvProject.TabIndex = 0;
            trvProject.AfterSelect += trvProject_AfterSelect;
            trvProject.MouseClick += trvProject_MouseClick;
            trvProject.MouseDown += trvProject_MouseDown;
            // 
            // imgList
            // 
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
            imgList.TransparentColor = Color.Transparent;
            imgList.Images.SetKeyName(0, "channel_empty_16.png");
            imgList.Images.SetKeyName(1, "channel_ethernet_16.png");
            imgList.Images.SetKeyName(2, "channel_serialport_16.png");
            imgList.Images.SetKeyName(3, "device_16.png");
            imgList.Images.SetKeyName(4, "device_off_16.png");
            imgList.Images.SetKeyName(5, "cmd_group_16.png");
            imgList.Images.SetKeyName(6, "cmd_group_off_16.png");
            imgList.Images.SetKeyName(7, "command_00_16.png");
            imgList.Images.SetKeyName(8, "command_01_16.png");
            imgList.Images.SetKeyName(9, "command_02_16.png");
            imgList.Images.SetKeyName(10, "command_03_16.png");
            imgList.Images.SetKeyName(11, "command_04_16.png");
            imgList.Images.SetKeyName(12, "command_05_16.png");
            imgList.Images.SetKeyName(13, "command_06_16.png");
            imgList.Images.SetKeyName(14, "command_07_16.png");
            imgList.Images.SetKeyName(15, "command_08_16.png");
            imgList.Images.SetKeyName(16, "command_11_16.png");
            imgList.Images.SetKeyName(17, "command_12_16.png");
            imgList.Images.SetKeyName(18, "command_15_16.png");
            imgList.Images.SetKeyName(19, "command_16_16.png");
            imgList.Images.SetKeyName(20, "command_17_16.png");
            imgList.Images.SetKeyName(21, "command_20_16.png");
            imgList.Images.SetKeyName(22, "command_21_16.png");
            imgList.Images.SetKeyName(23, "command_22_16.png");
            imgList.Images.SetKeyName(24, "command_24_16.png");
            imgList.Images.SetKeyName(25, "command_43_16.png");
            imgList.Images.SetKeyName(26, "command_99_16.png");
            imgList.Images.SetKeyName(27, "tag_group_16.png");
            imgList.Images.SetKeyName(28, "tag_16.png");
            imgList.Images.SetKeyName(29, "tag_add_16.png");
            imgList.Images.SetKeyName(30, "tag_edit_16.png");
            imgList.Images.SetKeyName(31, "tag_delete_16.png");
            // 
            // cmnuDeviceVTDCommandAddRead82
            // 
            cmnuDeviceVTDCommandAddRead82.Name = "cmnuDeviceVTDCommandAddRead82";
            cmnuDeviceVTDCommandAddRead82.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead82.Tag = "VALUES82";
            cmnuDeviceVTDCommandAddRead82.Text = "Значения, измеренные непосредственно преобразователями (82)";
            cmnuDeviceVTDCommandAddRead82.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead83
            // 
            cmnuDeviceVTDCommandAddRead83.Name = "cmnuDeviceVTDCommandAddRead83";
            cmnuDeviceVTDCommandAddRead83.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead83.Tag = "VALUES83";
            cmnuDeviceVTDCommandAddRead83.Text = "Значения, принятые для вычислений (83)";
            cmnuDeviceVTDCommandAddRead83.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead84
            // 
            cmnuDeviceVTDCommandAddRead84.Name = "cmnuDeviceVTDCommandAddRead84";
            cmnuDeviceVTDCommandAddRead84.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead84.Tag = "ARCHIVEVALUES84";
            cmnuDeviceVTDCommandAddRead84.Text = "Значения, заданного параметра из часового архива (84)";
            cmnuDeviceVTDCommandAddRead84.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead85
            // 
            cmnuDeviceVTDCommandAddRead85.Name = "cmnuDeviceVTDCommandAddRead85";
            cmnuDeviceVTDCommandAddRead85.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead85.Tag = "ARCHIVEVALUES85";
            cmnuDeviceVTDCommandAddRead85.Text = "Значения, заданного параметра из суточного архива (85)";
            cmnuDeviceVTDCommandAddRead85.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead86
            // 
            cmnuDeviceVTDCommandAddRead86.Name = "cmnuDeviceVTDCommandAddRead86";
            cmnuDeviceVTDCommandAddRead86.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead86.Tag = "ARCHIVEVALUES86";
            cmnuDeviceVTDCommandAddRead86.Text = "Значений, заданного параметра из месячного архива (86)";
            cmnuDeviceVTDCommandAddRead86.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead87
            // 
            cmnuDeviceVTDCommandAddRead87.Name = "cmnuDeviceVTDCommandAddRead87";
            cmnuDeviceVTDCommandAddRead87.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead87.Tag = "ARCHIVESITUATIONS";
            cmnuDeviceVTDCommandAddRead87.Text = "Архив нештатных ситуаций за предыдущий и текущий месяцы (87)";
            cmnuDeviceVTDCommandAddRead87.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead88
            // 
            cmnuDeviceVTDCommandAddRead88.Name = "cmnuDeviceVTDCommandAddRead88";
            cmnuDeviceVTDCommandAddRead88.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead88.Tag = "TOTALVOLUME";
            cmnuDeviceVTDCommandAddRead88.Text = "Тотальный объем в рабочих условиях (88)";
            cmnuDeviceVTDCommandAddRead88.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead90
            // 
            cmnuDeviceVTDCommandAddRead90.Name = "cmnuDeviceVTDCommandAddRead90";
            cmnuDeviceVTDCommandAddRead90.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead90.Tag = "ARCHIVE100POWERBREAKS";
            cmnuDeviceVTDCommandAddRead90.Text = "Архив последних 100 перерывов питания (90)";
            cmnuDeviceVTDCommandAddRead90.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead91
            // 
            cmnuDeviceVTDCommandAddRead91.Name = "cmnuDeviceVTDCommandAddRead91";
            cmnuDeviceVTDCommandAddRead91.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead91.Tag = "ARCHIVE450EMERGENCYSITUATIONS";
            cmnuDeviceVTDCommandAddRead91.Text = "Архив последних 450 нештатных ситуаций (91)";
            cmnuDeviceVTDCommandAddRead91.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead95
            // 
            cmnuDeviceVTDCommandAddRead95.Name = "cmnuDeviceVTDCommandAddRead95";
            cmnuDeviceVTDCommandAddRead95.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead95.Tag = "CALCULATORCONFIGURATION95";
            cmnuDeviceVTDCommandAddRead95.Text = "Конфигурация вычислителя (Float) (95)";
            cmnuDeviceVTDCommandAddRead95.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddWrite96
            // 
            cmnuDeviceVTDCommandAddWrite96.Name = "cmnuDeviceVTDCommandAddWrite96";
            cmnuDeviceVTDCommandAddWrite96.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddWrite96.Tag = "ENTERINGPARAMETERS";
            cmnuDeviceVTDCommandAddWrite96.Text = "Ввод параметров конфигурации в вычислитель (96)";
            cmnuDeviceVTDCommandAddWrite96.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceOther
            // 
            cmnuDeviceOther.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceOtherCommandAddRead99 });
            cmnuDeviceOther.Name = "cmnuDeviceOther";
            cmnuDeviceOther.Size = new Size(243, 22);
            cmnuDeviceOther.Text = "Редко используемые команды";
            // 
            // cmnuDeviceOtherCommandAddRead99
            // 
            cmnuDeviceOtherCommandAddRead99.Name = "cmnuDeviceOtherCommandAddRead99";
            cmnuDeviceOtherCommandAddRead99.Size = new Size(177, 22);
            cmnuDeviceOtherCommandAddRead99.Tag = "ARBITRARY";
            cmnuDeviceOtherCommandAddRead99.Text = "Произвольная (99)";
            cmnuDeviceOtherCommandAddRead99.DisplayStyleChanged += cmnuCommandAdd_Click;
            // 
            // cmnuCommandImport
            // 
            cmnuCommandImport.DropDownItems.AddRange(new ToolStripItem[] { cmnuCommandImportSelect, cmnuCommandImportAll });
            cmnuCommandImport.Name = "cmnuCommandImport";
            cmnuCommandImport.Size = new Size(212, 22);
            cmnuCommandImport.Text = "Импротировать команду";
            // 
            // cmnuCommandImportSelect
            // 
            cmnuCommandImportSelect.Name = "cmnuCommandImportSelect";
            cmnuCommandImportSelect.Size = new Size(140, 22);
            cmnuCommandImportSelect.Text = "Выбранную";
            // 
            // cmnuCommandImportAll
            // 
            cmnuCommandImportAll.Name = "cmnuCommandImportAll";
            cmnuCommandImportAll.Size = new Size(140, 22);
            cmnuCommandImportAll.Text = "Все";
            // 
            // cmnuCommandGenerate
            // 
            cmnuCommandGenerate.Name = "cmnuCommandGenerate";
            cmnuCommandGenerate.Size = new Size(212, 22);
            cmnuCommandGenerate.Text = "Сгенерировать команды";
            // 
            // cmnuCommandDelete
            // 
            cmnuCommandDelete.Items.AddRange(new ToolStripItem[] { cmnuCommandUp, cmnuCommandDown, toolStripSeparator2, cmnuCommandDel });
            cmnuCommandDelete.Name = "HMI_contextMenu";
            cmnuCommandDelete.Size = new Size(108, 76);
            // 
            // cmnuCommandUp
            // 
            cmnuCommandUp.Name = "cmnuCommandUp";
            cmnuCommandUp.Size = new Size(107, 22);
            cmnuCommandUp.Text = "Up";
            cmnuCommandUp.Click += cmnuCommandUp_Click;
            // 
            // cmnuCommandDown
            // 
            cmnuCommandDown.Name = "cmnuCommandDown";
            cmnuCommandDown.Size = new Size(107, 22);
            cmnuCommandDown.Text = "Down";
            cmnuCommandDown.Click += cmnuCommandDown_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(104, 6);
            // 
            // cmnuCommandDel
            // 
            cmnuCommandDel.Name = "cmnuCommandDel";
            cmnuCommandDel.Size = new Size(107, 22);
            cmnuCommandDel.Text = "Delete";
            cmnuCommandDel.ToolTipText = "Удалить группу";
            cmnuCommandDel.Click += cmnuCommandDel_Click;
            // 
            // cmnuDeviceTagAppend
            // 
            cmnuDeviceTagAppend.Items.AddRange(new ToolStripItem[] { cmnuDeviceTagAdd });
            cmnuDeviceTagAppend.Name = "HMI_contextMenu";
            cmnuDeviceTagAppend.Size = new Size(149, 26);
            // 
            // cmnuDeviceTagAdd
            // 
            cmnuDeviceTagAdd.Name = "cmnuDeviceTagAdd";
            cmnuDeviceTagAdd.Size = new Size(148, 22);
            cmnuDeviceTagAdd.Text = "Добавить  тег";
            cmnuDeviceTagAdd.Click += cmnuDeviceTagAdd_Click;
            // 
            // cmnuDeviceTagDelete
            // 
            cmnuDeviceTagDelete.Items.AddRange(new ToolStripItem[] { cmnuDeviceTagDel });
            cmnuDeviceTagDelete.Name = "HMI_contextMenu";
            cmnuDeviceTagDelete.Size = new Size(119, 26);
            cmnuDeviceTagDelete.Click += cmnuDeviceTagDel_Click;
            // 
            // cmnuDeviceTagDel
            // 
            cmnuDeviceTagDel.Name = "cmnuDeviceTagDel";
            cmnuDeviceTagDel.Size = new Size(118, 22);
            cmnuDeviceTagDel.Text = "Удалить";
            cmnuDeviceTagDel.Click += cmnuDeviceTagDel_Click;
            // 
            // tmrTimer
            // 
            tmrTimer.Tick += tmrTimer_Tick;
            // 
            // sptContainer
            // 
            sptContainer.Dock = DockStyle.Fill;
            sptContainer.Location = new Point(0, 63);
            sptContainer.Name = "sptContainer";
            // 
            // sptContainer.Panel1
            // 
            sptContainer.Panel1.Controls.Add(trvProject);
            // 
            // sptContainer.Panel2
            // 
            sptContainer.Panel2.Controls.Add(tabControl);
            sptContainer.Size = new Size(1214, 758);
            sptContainer.SplitterDistance = 303;
            sptContainer.TabIndex = 11;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.ImageList = imgList;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(907, 758);
            tabControl.TabIndex = 0;
            // 
            // cmnuDeviceVTDCommandAddRead81
            // 
            cmnuDeviceVTDCommandAddRead81.Name = "cmnuDeviceVTDCommandAddRead81";
            cmnuDeviceVTDCommandAddRead81.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead81.Tag = "VALUES81";
            cmnuDeviceVTDCommandAddRead81.Text = "Текущие значения (81)";
            cmnuDeviceVTDCommandAddRead81.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTDCommandAddRead80
            // 
            cmnuDeviceVTDCommandAddRead80.Name = "cmnuDeviceVTDCommandAddRead80";
            cmnuDeviceVTDCommandAddRead80.Size = new Size(446, 22);
            cmnuDeviceVTDCommandAddRead80.Tag = "CALCULATORCONFIGURATION";
            cmnuDeviceVTDCommandAddRead80.Text = "Конфигурация вычислителя (80)";
            cmnuDeviceVTDCommandAddRead80.Click += cmnuCommandAdd_Click;
            // 
            // tlsMenu
            // 
            tlsMenu.ImageScalingSize = new Size(32, 32);
            tlsMenu.Items.AddRange(new ToolStripItem[] { tlsProjectNew, tlsProjectOpen, tlsProjectSave, tlsProjectSaveAs, toolStripSeparator1, tlsProjectStartStop, toolStripSeparator3, tlsProjectDataView, toolStripButton1 });
            tlsMenu.Location = new Point(0, 24);
            tlsMenu.Name = "tlsMenu";
            tlsMenu.Size = new Size(1214, 39);
            tlsMenu.TabIndex = 10;
            tlsMenu.Text = "toolStrip1";
            // 
            // tlsProjectNew
            // 
            tlsProjectNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectNew.Image = (Image)resources.GetObject("tlsProjectNew.Image");
            tlsProjectNew.ImageTransparentColor = Color.Magenta;
            tlsProjectNew.Name = "tlsProjectNew";
            tlsProjectNew.Size = new Size(36, 36);
            tlsProjectNew.Click += tlsProjectNew_Click;
            // 
            // tlsProjectOpen
            // 
            tlsProjectOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectOpen.Image = (Image)resources.GetObject("tlsProjectOpen.Image");
            tlsProjectOpen.ImageTransparentColor = Color.Magenta;
            tlsProjectOpen.Name = "tlsProjectOpen";
            tlsProjectOpen.Size = new Size(36, 36);
            tlsProjectOpen.Click += tlsProjectOpen_Click;
            // 
            // tlsProjectSave
            // 
            tlsProjectSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectSave.Image = (Image)resources.GetObject("tlsProjectSave.Image");
            tlsProjectSave.ImageTransparentColor = Color.Magenta;
            tlsProjectSave.Name = "tlsProjectSave";
            tlsProjectSave.Size = new Size(36, 36);
            tlsProjectSave.Click += tlsProjectSave_Click;
            // 
            // tlsProjectSaveAs
            // 
            tlsProjectSaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectSaveAs.Image = (Image)resources.GetObject("tlsProjectSaveAs.Image");
            tlsProjectSaveAs.ImageTransparentColor = Color.Magenta;
            tlsProjectSaveAs.Name = "tlsProjectSaveAs";
            tlsProjectSaveAs.Size = new Size(36, 36);
            tlsProjectSaveAs.Click += tlsProjectSaveAs_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 39);
            // 
            // tlsProjectStartStop
            // 
            tlsProjectStartStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectStartStop.Image = (Image)resources.GetObject("tlsProjectStartStop.Image");
            tlsProjectStartStop.ImageTransparentColor = Color.Magenta;
            tlsProjectStartStop.Name = "tlsProjectStartStop";
            tlsProjectStartStop.Size = new Size(36, 36);
            tlsProjectStartStop.Click += tlsProjectStartStop_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 39);
            // 
            // tlsProjectDataView
            // 
            tlsProjectDataView.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectDataView.Image = (Image)resources.GetObject("tlsProjectDataView.Image");
            tlsProjectDataView.ImageTransparentColor = Color.Magenta;
            tlsProjectDataView.Name = "tlsProjectDataView";
            tlsProjectDataView.Size = new Size(36, 36);
            tlsProjectDataView.Text = "toolStripButton1";
            tlsProjectDataView.Click += tlsProjectDataView_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(36, 36);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // mnuMenu
            // 
            mnuMenu.Items.AddRange(new ToolStripItem[] { mnuProject, mnuUtils, mnuSettings });
            mnuMenu.Location = new Point(0, 0);
            mnuMenu.Name = "mnuMenu";
            mnuMenu.Size = new Size(1214, 24);
            mnuMenu.TabIndex = 9;
            mnuMenu.Text = "menuStrip1";
            // 
            // mnuProject
            // 
            mnuProject.DropDownItems.AddRange(new ToolStripItem[] { mnuProjectNew, mnuProjectOpen, mnuProjectSave, mnuProjectSaveAs });
            mnuProject.Name = "mnuProject";
            mnuProject.Size = new Size(56, 20);
            mnuProject.Text = "Project";
            // 
            // mnuProjectNew
            // 
            mnuProjectNew.Name = "mnuProjectNew";
            mnuProjectNew.Size = new Size(121, 22);
            mnuProjectNew.Text = "New";
            // 
            // mnuProjectOpen
            // 
            mnuProjectOpen.Name = "mnuProjectOpen";
            mnuProjectOpen.Size = new Size(121, 22);
            mnuProjectOpen.Text = "Open";
            // 
            // mnuProjectSave
            // 
            mnuProjectSave.Name = "mnuProjectSave";
            mnuProjectSave.Size = new Size(121, 22);
            mnuProjectSave.Text = "Save";
            // 
            // mnuProjectSaveAs
            // 
            mnuProjectSaveAs.Name = "mnuProjectSaveAs";
            mnuProjectSaveAs.Size = new Size(121, 22);
            mnuProjectSaveAs.Text = "Save as...";
            mnuProjectSaveAs.Click += tlsProjectSaveAs_Click;
            // 
            // mnuUtils
            // 
            mnuUtils.DropDownItems.AddRange(new ToolStripItem[] { mnuConverter });
            mnuUtils.Name = "mnuUtils";
            mnuUtils.Size = new Size(42, 20);
            mnuUtils.Text = "Utils";
            // 
            // mnuConverter
            // 
            mnuConverter.Name = "mnuConverter";
            mnuConverter.Size = new Size(126, 22);
            mnuConverter.Text = "Сonverter";
            mnuConverter.Click += mnuConverter_Click;
            // 
            // mnuSettings
            // 
            mnuSettings.Name = "mnuSettings";
            mnuSettings.Size = new Size(61, 20);
            mnuSettings.Text = "Settings";
            mnuSettings.Click += mnuSettings_Click;
            // 
            // cmnuDeviceAppend
            // 
            cmnuDeviceAppend.Items.AddRange(new ToolStripItem[] { cmnuDeviceAdd });
            cmnuDeviceAppend.Name = "HMI_contextMenu";
            cmnuDeviceAppend.Size = new Size(192, 26);
            // 
            // cmnuDeviceAdd
            // 
            cmnuDeviceAdd.Name = "cmnuDeviceAdd";
            cmnuDeviceAdd.Size = new Size(191, 22);
            cmnuDeviceAdd.Text = "Добавить устройство";
            cmnuDeviceAdd.Click += cmnuDeviceAdd_Click;
            // 
            // cmnuDeviceDelete
            // 
            cmnuDeviceDelete.Items.AddRange(new ToolStripItem[] { cmnuDeviceDel });
            cmnuDeviceDelete.Name = "HMI_contextMenu";
            cmnuDeviceDelete.Size = new Size(119, 26);
            // 
            // cmnuDeviceDel
            // 
            cmnuDeviceDel.Name = "cmnuDeviceDel";
            cmnuDeviceDel.Size = new Size(118, 22);
            cmnuDeviceDel.Text = "Удалить";
            cmnuDeviceDel.Click += cmnuDeviceDel_Click;
            // 
            // cmnuCommandAppend
            // 
            cmnuCommandAppend.Items.AddRange(new ToolStripItem[] { cmnuCommandAdd, cmnuCommandImport, cmnuCommandGenerate });
            cmnuCommandAppend.Name = "HMI_contextMenu";
            cmnuCommandAppend.Size = new Size(213, 70);
            // 
            // cmnuCommandAdd
            // 
            cmnuCommandAdd.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceModbus, cmnuDeviceVTD, cmnuDeviceOther });
            cmnuCommandAdd.Name = "cmnuCommandAdd";
            cmnuCommandAdd.Size = new Size(212, 22);
            cmnuCommandAdd.Text = "Создать команду";
            // 
            // cmnuDeviceModbus
            // 
            cmnuDeviceModbus.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceModbusCommandAddReadCoils, cmnuDeviceModbusCommandAddReadInputs, cmnuDeviceModbusCommandAddReadHoldingRegisters, cmnuDeviceModbusCommandAddReadInputRegisters, cmnuDeviceModbusCommandAddWriteCoil, cmnuDeviceModbusCommandAddWriteInputRegister, cmnuDeviceModbusCommandAddWriteCoils, cmnuDeviceModbusCommandAddWriteInputRegisters });
            cmnuDeviceModbus.Name = "cmnuDeviceModbus";
            cmnuDeviceModbus.Size = new Size(243, 22);
            cmnuDeviceModbus.Text = "Modbus";
            // 
            // cmnuDeviceModbusCommandAddReadCoils
            // 
            cmnuDeviceModbusCommandAddReadCoils.Name = "cmnuDeviceModbusCommandAddReadCoils";
            cmnuDeviceModbusCommandAddReadCoils.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddReadCoils.Tag = "READCOILS";
            cmnuDeviceModbusCommandAddReadCoils.Text = "Чтение Coils (1)";
            cmnuDeviceModbusCommandAddReadCoils.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadInputs
            // 
            cmnuDeviceModbusCommandAddReadInputs.Name = "cmnuDeviceModbusCommandAddReadInputs";
            cmnuDeviceModbusCommandAddReadInputs.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddReadInputs.Tag = "READINPUTS";
            cmnuDeviceModbusCommandAddReadInputs.Text = "Чтение Inputs (2)";
            cmnuDeviceModbusCommandAddReadInputs.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadHoldingRegisters
            // 
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Name = "cmnuDeviceModbusCommandAddReadHoldingRegisters";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Tag = "READHOLDINGREGISTERS";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Text = "Чтение HoldingRegisters (3)";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadInputRegisters
            // 
            cmnuDeviceModbusCommandAddReadInputRegisters.Name = "cmnuDeviceModbusCommandAddReadInputRegisters";
            cmnuDeviceModbusCommandAddReadInputRegisters.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddReadInputRegisters.Tag = "READINPUTREGISTERS";
            cmnuDeviceModbusCommandAddReadInputRegisters.Text = "Чтение InputRegisters (4)";
            cmnuDeviceModbusCommandAddReadInputRegisters.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteCoil
            // 
            cmnuDeviceModbusCommandAddWriteCoil.Name = "cmnuDeviceModbusCommandAddWriteCoil";
            cmnuDeviceModbusCommandAddWriteCoil.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddWriteCoil.Tag = "WRITECOIL";
            cmnuDeviceModbusCommandAddWriteCoil.Text = "Запись Coil (5)";
            cmnuDeviceModbusCommandAddWriteCoil.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteInputRegister
            // 
            cmnuDeviceModbusCommandAddWriteInputRegister.Name = "cmnuDeviceModbusCommandAddWriteInputRegister";
            cmnuDeviceModbusCommandAddWriteInputRegister.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddWriteInputRegister.Tag = "WRITEHOLDINGREGISTER";
            cmnuDeviceModbusCommandAddWriteInputRegister.Text = "Запись HoldingRegister (6)";
            cmnuDeviceModbusCommandAddWriteInputRegister.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteCoils
            // 
            cmnuDeviceModbusCommandAddWriteCoils.Name = "cmnuDeviceModbusCommandAddWriteCoils";
            cmnuDeviceModbusCommandAddWriteCoils.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddWriteCoils.Tag = "WRITEMULTIPLECOILS";
            cmnuDeviceModbusCommandAddWriteCoils.Text = "Запись MultipleCoils (15)";
            cmnuDeviceModbusCommandAddWriteCoils.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteInputRegisters
            // 
            cmnuDeviceModbusCommandAddWriteInputRegisters.Name = "cmnuDeviceModbusCommandAddWriteInputRegisters";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Size = new Size(273, 22);
            cmnuDeviceModbusCommandAddWriteInputRegisters.Tag = "WRITEMULTIPLEHOLDINGREGISTERS";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Text = "Запись MultipleHoldingRegisters (16)";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceVTD
            // 
            cmnuDeviceVTD.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceVTDCommandAddRead80, cmnuDeviceVTDCommandAddRead81, cmnuDeviceVTDCommandAddRead82, cmnuDeviceVTDCommandAddRead83, cmnuDeviceVTDCommandAddRead84, cmnuDeviceVTDCommandAddRead85, cmnuDeviceVTDCommandAddRead86, cmnuDeviceVTDCommandAddRead87, cmnuDeviceVTDCommandAddRead88, cmnuDeviceVTDCommandAddRead90, cmnuDeviceVTDCommandAddRead91, cmnuDeviceVTDCommandAddRead95, cmnuDeviceVTDCommandAddWrite96 });
            cmnuDeviceVTD.Name = "cmnuDeviceVTD";
            cmnuDeviceVTD.Size = new Size(243, 22);
            cmnuDeviceVTD.Text = "ВТД";
            // 
            // imgListForm
            // 
            imgListForm.ColorDepth = ColorDepth.Depth32Bit;
            imgListForm.ImageStream = (ImageListStreamer)resources.GetObject("imgListForm.ImageStream");
            imgListForm.TransparentColor = Color.Transparent;
            imgListForm.Images.SetKeyName(0, "new.png");
            imgListForm.Images.SetKeyName(1, "open.png");
            imgListForm.Images.SetKeyName(2, "save.png");
            imgListForm.Images.SetKeyName(3, "save as.png");
            imgListForm.Images.SetKeyName(4, "start.png");
            imgListForm.Images.SetKeyName(5, "stop.png");
            imgListForm.Images.SetKeyName(6, "action_log.png");
            // 
            // FrmConfigForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1214, 821);
            Controls.Add(sptContainer);
            Controls.Add(tlsMenu);
            Controls.Add(mnuMenu);
            MinimumSize = new Size(1230, 860);
            Name = "FrmConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConfigForm";
            Load += FrmConfigForm_Load;
            Shown += FrmConfigForm_Shown;
            cmnuCommandDelete.ResumeLayout(false);
            cmnuDeviceTagAppend.ResumeLayout(false);
            cmnuDeviceTagDelete.ResumeLayout(false);
            sptContainer.Panel1.ResumeLayout(false);
            sptContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sptContainer).EndInit();
            sptContainer.ResumeLayout(false);
            tlsMenu.ResumeLayout(false);
            tlsMenu.PerformLayout();
            mnuMenu.ResumeLayout(false);
            mnuMenu.PerformLayout();
            cmnuDeviceAppend.ResumeLayout(false);
            cmnuDeviceDelete.ResumeLayout(false);
            cmnuCommandAppend.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        public TreeView trvProject;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead82;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead83;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead84;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead85;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead86;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead87;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead88;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead90;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead91;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead95;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddWrite96;
        private ToolStripMenuItem cmnuDeviceOther;
        private ToolStripMenuItem cmnuDeviceOtherCommandAddRead99;
        private ToolStripMenuItem cmnuCommandImport;
        private ToolStripMenuItem cmnuCommandImportSelect;
        private ToolStripMenuItem cmnuCommandImportAll;
        private ToolStripMenuItem cmnuCommandGenerate;
        public ContextMenuStrip cmnuCommandDelete;
        private ToolStripMenuItem cmnuCommandDel;
        public ContextMenuStrip cmnuDeviceTagAppend;
        private ToolStripMenuItem cmnuDeviceTagAdd;
        public ContextMenuStrip cmnuDeviceTagDelete;
        private ToolStripMenuItem cmnuDeviceTagDel;
        private System.Windows.Forms.Timer tmrTimer;
        private SplitContainer sptContainer;
        private TabControl tabControl;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead81;
        private ToolStripMenuItem cmnuDeviceVTDCommandAddRead80;
        private ToolStrip tlsMenu;
        private ToolStripButton tlsProjectNew;
        private ToolStripButton tlsProjectOpen;
        private ToolStripButton tlsProjectSave;
        private ToolStripSeparator toolStripSeparator1;
        private MenuStrip mnuMenu;
        private ToolStripMenuItem mnuProject;
        private ToolStripMenuItem mnuProjectNew;
        private ToolStripMenuItem mnuProjectOpen;
        private ToolStripMenuItem mnuProjectSave;
        private ToolStripMenuItem mnuProjectSaveAs;
        public ContextMenuStrip cmnuDeviceAppend;
        private ToolStripMenuItem cmnuDeviceAdd;
        public ContextMenuStrip cmnuDeviceDelete;
        private ToolStripMenuItem cmnuDeviceDel;
        public ContextMenuStrip cmnuCommandAppend;
        private ToolStripMenuItem cmnuCommandAdd;
        private ToolStripMenuItem cmnuDeviceModbus;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadCoils;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadInputs;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadHoldingRegisters;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadInputRegisters;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteCoil;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteInputRegister;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteCoils;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteInputRegisters;
        private ToolStripMenuItem cmnuDeviceVTD;
        private ToolStripMenuItem mnuUtils;
        private ToolStripMenuItem mnuConverter;
        private ToolStripMenuItem mnuSettings;
        private ToolStripMenuItem cmnuCommandUp;
        private ToolStripMenuItem cmnuCommandDown;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tlsProjectStartStop;
        private ToolStripButton tlsProjectSaveAs;
        private ToolStripSeparator toolStripSeparator3;
        public ImageList imgList;
        public ImageList imgListForm;
        private ToolStripButton tlsProjectDataView;
        private ToolStripButton toolStripButton1;
    }
}