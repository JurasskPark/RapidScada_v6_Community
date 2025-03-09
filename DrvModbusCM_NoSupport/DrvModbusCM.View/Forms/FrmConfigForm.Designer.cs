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
            cmnuModbusCMCommandAddRead82 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead83 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead84 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead85 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead86 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead87 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead88 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead90 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead91 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead95 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddWrite96 = new ToolStripMenuItem();
            cmnuDeviceOther = new ToolStripMenuItem();
            cmnuDeviceOtherCommandAddRead99 = new ToolStripMenuItem();
            cmnuDeviceCommandImport = new ToolStripMenuItem();
            cmnuDeviceCommandImportSelect = new ToolStripMenuItem();
            cmnuDeviceCommandImportAll = new ToolStripMenuItem();
            cmnuDeviceCommandGenerate = new ToolStripMenuItem();
            cmnuDeviceCommandDelete = new ContextMenuStrip(components);
            cmnuDeviceCommandDel = new ToolStripMenuItem();
            cmnuDeviceTagAppend = new ContextMenuStrip(components);
            cmnuDeviceTagAdd = new ToolStripMenuItem();
            cmnuDeviceTagDelete = new ContextMenuStrip(components);
            cmnuDeviceTagDel = new ToolStripMenuItem();
            tmrTimer = new System.Windows.Forms.Timer(components);
            sptContainer = new SplitContainer();
            tabControl = new TabControl();
            cmnuModbusCMCommandAddRead81 = new ToolStripMenuItem();
            cmnuModbusCMCommandAddRead80 = new ToolStripMenuItem();
            tlsMenu = new ToolStrip();
            tlsProjectNew = new ToolStripButton();
            tlsProjectOpen = new ToolStripButton();
            tlsProjectSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuMenu = new MenuStrip();
            mnuProject = new ToolStripMenuItem();
            mnuProjectNew = new ToolStripMenuItem();
            mnuProjectOpen = new ToolStripMenuItem();
            mnuProjectSave = new ToolStripMenuItem();
            mnuProjectSaveAs = new ToolStripMenuItem();
            cmnuDeviceAppend = new ContextMenuStrip(components);
            cmnuDeviceAdd = new ToolStripMenuItem();
            cmnuDeviceDelete = new ContextMenuStrip(components);
            cmnuDeviceDel = new ToolStripMenuItem();
            cmnuDeviceCommandAppend = new ContextMenuStrip(components);
            cmnuDeviceCommandAdd = new ToolStripMenuItem();
            cmnuDeviceModbus = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadCoils = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadInputs = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadHoldingRegisters = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadInputRegisters = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteCoil = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteInputRegister = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteCoils = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteInputRegisters = new ToolStripMenuItem();
            cmnuModbusCM = new ToolStripMenuItem();
            cmnuDeviceCommandDelete.SuspendLayout();
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
            cmnuDeviceCommandAppend.SuspendLayout();
            SuspendLayout();
            // 
            // trvProject
            // 
            trvProject.Dock = DockStyle.Fill;
            trvProject.ImageIndex = 0;
            trvProject.ImageList = imgList;
            trvProject.Location = new Point(0, 0);
            trvProject.Margin = new Padding(4, 5, 4, 5);
            trvProject.Name = "trvProject";
            trvProject.SelectedImageIndex = 0;
            trvProject.Size = new Size(432, 1292);
            trvProject.TabIndex = 0;
            trvProject.AfterSelect += trvProject_AfterSelect;
            trvProject.MouseClick += trvProject_MouseClick;
            trvProject.MouseDown += trvProject_MouseDown;
            // 
            // imgList
            // 
            imgList.ColorDepth = ColorDepth.Depth4Bit;
            imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
            imgList.TransparentColor = Color.Transparent;
            imgList.Images.SetKeyName(0, "channel_empty_16.png");
            imgList.Images.SetKeyName(1, "channel_ethernet_16.png");
            imgList.Images.SetKeyName(2, "channel_serialport_16.png");
            imgList.Images.SetKeyName(3, "device_16.png");
            imgList.Images.SetKeyName(4, "device_buffer_16.png");
            imgList.Images.SetKeyName(5, "group_command_16.png");
            imgList.Images.SetKeyName(6, "command_00_16.png");
            imgList.Images.SetKeyName(7, "command_01_16.png");
            imgList.Images.SetKeyName(8, "command_02_16.png");
            imgList.Images.SetKeyName(9, "command_03_16.png");
            imgList.Images.SetKeyName(10, "command_04_16.png");
            imgList.Images.SetKeyName(11, "command_05_16.png");
            imgList.Images.SetKeyName(12, "command_06_16.png");
            imgList.Images.SetKeyName(13, "command_07_16.png");
            imgList.Images.SetKeyName(14, "command_08_16.png");
            imgList.Images.SetKeyName(15, "command_11_16.png");
            imgList.Images.SetKeyName(16, "command_12_16.png");
            imgList.Images.SetKeyName(17, "command_15_16.png");
            imgList.Images.SetKeyName(18, "command_16_16.png");
            imgList.Images.SetKeyName(19, "command_17_16.png");
            imgList.Images.SetKeyName(20, "command_20_16.png");
            imgList.Images.SetKeyName(21, "command_21_16.png");
            imgList.Images.SetKeyName(22, "command_22_16.png");
            imgList.Images.SetKeyName(23, "command_24_16.png");
            imgList.Images.SetKeyName(24, "command_43_16.png");
            imgList.Images.SetKeyName(25, "command_99_16.png");
            imgList.Images.SetKeyName(26, "group_tag_16.png");
            imgList.Images.SetKeyName(27, "tag_16.png");
            // 
            // cmnuModbusCMCommandAddRead82
            // 
            cmnuModbusCMCommandAddRead82.Name = "cmnuModbusCMCommandAddRead82";
            cmnuModbusCMCommandAddRead82.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead82.Tag = "VALUES82";
            cmnuModbusCMCommandAddRead82.Text = "Значения, измеренные непосредственно преобразователями (82)";
            cmnuModbusCMCommandAddRead82.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead83
            // 
            cmnuModbusCMCommandAddRead83.Name = "cmnuModbusCMCommandAddRead83";
            cmnuModbusCMCommandAddRead83.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead83.Tag = "VALUES83";
            cmnuModbusCMCommandAddRead83.Text = "Значения, принятые для вычислений (83)";
            cmnuModbusCMCommandAddRead83.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead84
            // 
            cmnuModbusCMCommandAddRead84.Name = "cmnuModbusCMCommandAddRead84";
            cmnuModbusCMCommandAddRead84.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead84.Tag = "ARCHIVEVALUES84";
            cmnuModbusCMCommandAddRead84.Text = "Значения, заданного параметра из часового архива (84)";
            cmnuModbusCMCommandAddRead84.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead85
            // 
            cmnuModbusCMCommandAddRead85.Name = "cmnuModbusCMCommandAddRead85";
            cmnuModbusCMCommandAddRead85.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead85.Tag = "ARCHIVEVALUES85";
            cmnuModbusCMCommandAddRead85.Text = "Значения, заданного параметра из суточного архива (85)";
            cmnuModbusCMCommandAddRead85.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead86
            // 
            cmnuModbusCMCommandAddRead86.Name = "cmnuModbusCMCommandAddRead86";
            cmnuModbusCMCommandAddRead86.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead86.Tag = "ARCHIVEVALUES86";
            cmnuModbusCMCommandAddRead86.Text = "Значений, заданного параметра из месячного архива (86)";
            cmnuModbusCMCommandAddRead86.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead87
            // 
            cmnuModbusCMCommandAddRead87.Name = "cmnuModbusCMCommandAddRead87";
            cmnuModbusCMCommandAddRead87.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead87.Tag = "ARCHIVESITUATIONS";
            cmnuModbusCMCommandAddRead87.Text = "Архив нештатных ситуаций за предыдущий и текущий месяцы (87)";
            cmnuModbusCMCommandAddRead87.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead88
            // 
            cmnuModbusCMCommandAddRead88.Name = "cmnuModbusCMCommandAddRead88";
            cmnuModbusCMCommandAddRead88.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead88.Tag = "TOTALVOLUME";
            cmnuModbusCMCommandAddRead88.Text = "Тотальный объем в рабочих условиях (88)";
            cmnuModbusCMCommandAddRead88.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead90
            // 
            cmnuModbusCMCommandAddRead90.Name = "cmnuModbusCMCommandAddRead90";
            cmnuModbusCMCommandAddRead90.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead90.Tag = "ARCHIVE100POWERBREAKS";
            cmnuModbusCMCommandAddRead90.Text = "Архив последних 100 перерывов питания (90)";
            cmnuModbusCMCommandAddRead90.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead91
            // 
            cmnuModbusCMCommandAddRead91.Name = "cmnuModbusCMCommandAddRead91";
            cmnuModbusCMCommandAddRead91.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead91.Tag = "ARCHIVE450EMERGENCYSITUATIONS";
            cmnuModbusCMCommandAddRead91.Text = "Архив последних 450 нештатных ситуаций (91)";
            cmnuModbusCMCommandAddRead91.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead95
            // 
            cmnuModbusCMCommandAddRead95.Name = "cmnuModbusCMCommandAddRead95";
            cmnuModbusCMCommandAddRead95.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead95.Tag = "CALCULATORCONFIGURATION95";
            cmnuModbusCMCommandAddRead95.Text = "Конфигурация вычислителя (Float) (95)";
            cmnuModbusCMCommandAddRead95.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddWrite96
            // 
            cmnuModbusCMCommandAddWrite96.Name = "cmnuModbusCMCommandAddWrite96";
            cmnuModbusCMCommandAddWrite96.Size = new Size(662, 34);
            cmnuModbusCMCommandAddWrite96.Tag = "ENTERINGPARAMETERS";
            cmnuModbusCMCommandAddWrite96.Text = "Ввод параметров конфигурации в вычислитель (96)";
            cmnuModbusCMCommandAddWrite96.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceOther
            // 
            cmnuDeviceOther.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceOtherCommandAddRead99 });
            cmnuDeviceOther.Name = "cmnuDeviceOther";
            cmnuDeviceOther.Size = new Size(366, 34);
            cmnuDeviceOther.Text = "Редко используемые команды";
            // 
            // cmnuDeviceOtherCommandAddRead99
            // 
            cmnuDeviceOtherCommandAddRead99.Name = "cmnuDeviceOtherCommandAddRead99";
            cmnuDeviceOtherCommandAddRead99.Size = new Size(269, 34);
            cmnuDeviceOtherCommandAddRead99.Tag = "ARBITRARY";
            cmnuDeviceOtherCommandAddRead99.Text = "Произвольная (99)";
            cmnuDeviceOtherCommandAddRead99.DisplayStyleChanged += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceCommandImport
            // 
            cmnuDeviceCommandImport.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceCommandImportSelect, cmnuDeviceCommandImportAll });
            cmnuDeviceCommandImport.Name = "cmnuDeviceCommandImport";
            cmnuDeviceCommandImport.Size = new Size(292, 32);
            cmnuDeviceCommandImport.Text = "Импротировать команду";
            // 
            // cmnuDeviceCommandImportSelect
            // 
            cmnuDeviceCommandImportSelect.Name = "cmnuDeviceCommandImportSelect";
            cmnuDeviceCommandImportSelect.Size = new Size(211, 34);
            cmnuDeviceCommandImportSelect.Text = "Выбранную";
            // 
            // cmnuDeviceCommandImportAll
            // 
            cmnuDeviceCommandImportAll.Name = "cmnuDeviceCommandImportAll";
            cmnuDeviceCommandImportAll.Size = new Size(211, 34);
            cmnuDeviceCommandImportAll.Text = "Все";
            // 
            // cmnuDeviceCommandGenerate
            // 
            cmnuDeviceCommandGenerate.Name = "cmnuDeviceCommandGenerate";
            cmnuDeviceCommandGenerate.Size = new Size(292, 32);
            cmnuDeviceCommandGenerate.Text = "Сгенерировать команды";
            // 
            // cmnuDeviceCommandDelete
            // 
            cmnuDeviceCommandDelete.ImageScalingSize = new Size(24, 24);
            cmnuDeviceCommandDelete.Items.AddRange(new ToolStripItem[] { cmnuDeviceCommandDel });
            cmnuDeviceCommandDelete.Name = "HMI_contextMenu";
            cmnuDeviceCommandDelete.Size = new Size(149, 36);
            // 
            // cmnuDeviceCommandDel
            // 
            cmnuDeviceCommandDel.Name = "cmnuDeviceCommandDel";
            cmnuDeviceCommandDel.Size = new Size(148, 32);
            cmnuDeviceCommandDel.Text = "Удалить";
            cmnuDeviceCommandDel.ToolTipText = "Удалить группу";
            cmnuDeviceCommandDel.Click += cmnuDeviceCommandDel_Click;
            // 
            // cmnuDeviceTagAppend
            // 
            cmnuDeviceTagAppend.ImageScalingSize = new Size(24, 24);
            cmnuDeviceTagAppend.Items.AddRange(new ToolStripItem[] { cmnuDeviceTagAdd });
            cmnuDeviceTagAppend.Name = "HMI_contextMenu";
            cmnuDeviceTagAppend.Size = new Size(196, 36);
            // 
            // cmnuDeviceTagAdd
            // 
            cmnuDeviceTagAdd.Name = "cmnuDeviceTagAdd";
            cmnuDeviceTagAdd.Size = new Size(195, 32);
            cmnuDeviceTagAdd.Text = "Добавить  тег";
            cmnuDeviceTagAdd.Click += cmnuDeviceTagAdd_Click;
            // 
            // cmnuDeviceTagDelete
            // 
            cmnuDeviceTagDelete.ImageScalingSize = new Size(24, 24);
            cmnuDeviceTagDelete.Items.AddRange(new ToolStripItem[] { cmnuDeviceTagDel });
            cmnuDeviceTagDelete.Name = "HMI_contextMenu";
            cmnuDeviceTagDelete.Size = new Size(149, 36);
            cmnuDeviceTagDelete.Click += cmnuDeviceTagDel_Click;
            // 
            // cmnuDeviceTagDel
            // 
            cmnuDeviceTagDel.Name = "cmnuDeviceTagDel";
            cmnuDeviceTagDel.Size = new Size(148, 32);
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
            sptContainer.Location = new Point(0, 76);
            sptContainer.Margin = new Padding(4, 5, 4, 5);
            sptContainer.Name = "sptContainer";
            // 
            // sptContainer.Panel1
            // 
            sptContainer.Panel1.Controls.Add(trvProject);
            // 
            // sptContainer.Panel2
            // 
            sptContainer.Panel2.Controls.Add(tabControl);
            sptContainer.Size = new Size(1734, 1292);
            sptContainer.SplitterDistance = 432;
            sptContainer.SplitterWidth = 6;
            sptContainer.TabIndex = 11;
            // 
            // tabControl
            // 
            tabControl.Dock = DockStyle.Fill;
            tabControl.ImageList = imgList;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4, 5, 4, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1296, 1292);
            tabControl.TabIndex = 0;
            // 
            // cmnuModbusCMCommandAddRead81
            // 
            cmnuModbusCMCommandAddRead81.Name = "cmnuModbusCMCommandAddRead81";
            cmnuModbusCMCommandAddRead81.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead81.Tag = "VALUES81";
            cmnuModbusCMCommandAddRead81.Text = "Текущие значения (81)";
            cmnuModbusCMCommandAddRead81.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCMCommandAddRead80
            // 
            cmnuModbusCMCommandAddRead80.Name = "cmnuModbusCMCommandAddRead80";
            cmnuModbusCMCommandAddRead80.Size = new Size(662, 34);
            cmnuModbusCMCommandAddRead80.Tag = "CALCULATORCONFIGURATION";
            cmnuModbusCMCommandAddRead80.Text = "Конфигурация вычислителя (80)";
            cmnuModbusCMCommandAddRead80.Click += cmnuDeviceCommandAdd_Click;
            // 
            // tlsMenu
            // 
            tlsMenu.ImageScalingSize = new Size(32, 32);
            tlsMenu.Items.AddRange(new ToolStripItem[] { tlsProjectNew, tlsProjectOpen, tlsProjectSave, toolStripSeparator1 });
            tlsMenu.Location = new Point(0, 35);
            tlsMenu.Name = "tlsMenu";
            tlsMenu.Padding = new Padding(0, 0, 3, 0);
            tlsMenu.Size = new Size(1734, 41);
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
            tlsProjectNew.Text = "Новый";
            tlsProjectNew.Click += tlsProjectNew_Click;
            // 
            // tlsProjectOpen
            // 
            tlsProjectOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectOpen.Image = (Image)resources.GetObject("tlsProjectOpen.Image");
            tlsProjectOpen.ImageTransparentColor = Color.Magenta;
            tlsProjectOpen.Name = "tlsProjectOpen";
            tlsProjectOpen.Size = new Size(36, 36);
            tlsProjectOpen.Text = "Открыть";
            tlsProjectOpen.Click += tlsProjectOpen_Click;
            // 
            // tlsProjectSave
            // 
            tlsProjectSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectSave.Image = (Image)resources.GetObject("tlsProjectSave.Image");
            tlsProjectSave.ImageTransparentColor = Color.Magenta;
            tlsProjectSave.Name = "tlsProjectSave";
            tlsProjectSave.Size = new Size(36, 36);
            tlsProjectSave.Text = "Сохранить";
            tlsProjectSave.Click += tlsProjectSave_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // mnuMenu
            // 
            mnuMenu.ImageScalingSize = new Size(24, 24);
            mnuMenu.Items.AddRange(new ToolStripItem[] { mnuProject });
            mnuMenu.Location = new Point(0, 0);
            mnuMenu.Name = "mnuMenu";
            mnuMenu.Padding = new Padding(9, 3, 0, 3);
            mnuMenu.Size = new Size(1734, 35);
            mnuMenu.TabIndex = 9;
            mnuMenu.Text = "menuStrip1";
            // 
            // mnuProject
            // 
            mnuProject.DropDownItems.AddRange(new ToolStripItem[] { mnuProjectNew, mnuProjectOpen, mnuProjectSave, mnuProjectSaveAs });
            mnuProject.Name = "mnuProject";
            mnuProject.Size = new Size(88, 29);
            mnuProject.Text = "Проект";
            // 
            // mnuProjectNew
            // 
            mnuProjectNew.Name = "mnuProjectNew";
            mnuProjectNew.Size = new Size(270, 34);
            mnuProjectNew.Text = "Новый";
            // 
            // mnuProjectOpen
            // 
            mnuProjectOpen.Name = "mnuProjectOpen";
            mnuProjectOpen.Size = new Size(270, 34);
            mnuProjectOpen.Text = "Открыть";
            // 
            // mnuProjectSave
            // 
            mnuProjectSave.Name = "mnuProjectSave";
            mnuProjectSave.Size = new Size(270, 34);
            mnuProjectSave.Text = "Сохранить";
            // 
            // mnuProjectSaveAs
            // 
            mnuProjectSaveAs.Name = "mnuProjectSaveAs";
            mnuProjectSaveAs.Size = new Size(270, 34);
            mnuProjectSaveAs.Text = "Сохранить как...";
            // 
            // cmnuDeviceAppend
            // 
            cmnuDeviceAppend.ImageScalingSize = new Size(24, 24);
            cmnuDeviceAppend.Items.AddRange(new ToolStripItem[] { cmnuDeviceAdd });
            cmnuDeviceAppend.Name = "HMI_contextMenu";
            cmnuDeviceAppend.Size = new Size(260, 36);
            // 
            // cmnuDeviceAdd
            // 
            cmnuDeviceAdd.Name = "cmnuDeviceAdd";
            cmnuDeviceAdd.Size = new Size(259, 32);
            cmnuDeviceAdd.Text = "Добавить устройство";
            cmnuDeviceAdd.Click += cmnuDeviceAdd_Click;
            // 
            // cmnuDeviceDelete
            // 
            cmnuDeviceDelete.ImageScalingSize = new Size(24, 24);
            cmnuDeviceDelete.Items.AddRange(new ToolStripItem[] { cmnuDeviceDel });
            cmnuDeviceDelete.Name = "HMI_contextMenu";
            cmnuDeviceDelete.Size = new Size(149, 36);
            // 
            // cmnuDeviceDel
            // 
            cmnuDeviceDel.Name = "cmnuDeviceDel";
            cmnuDeviceDel.Size = new Size(148, 32);
            cmnuDeviceDel.Text = "Удалить";
            cmnuDeviceDel.Click += cmnuDeviceDel_Click;
            // 
            // cmnuDeviceCommandAppend
            // 
            cmnuDeviceCommandAppend.ImageScalingSize = new Size(24, 24);
            cmnuDeviceCommandAppend.Items.AddRange(new ToolStripItem[] { cmnuDeviceCommandAdd, cmnuDeviceCommandImport, cmnuDeviceCommandGenerate });
            cmnuDeviceCommandAppend.Name = "HMI_contextMenu";
            cmnuDeviceCommandAppend.Size = new Size(293, 100);
            // 
            // cmnuDeviceCommandAdd
            // 
            cmnuDeviceCommandAdd.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceModbus, cmnuModbusCM, cmnuDeviceOther });
            cmnuDeviceCommandAdd.Name = "cmnuDeviceCommandAdd";
            cmnuDeviceCommandAdd.Size = new Size(292, 32);
            cmnuDeviceCommandAdd.Text = "Создать команду";
            // 
            // cmnuDeviceModbus
            // 
            cmnuDeviceModbus.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceModbusCommandAddReadCoils, cmnuDeviceModbusCommandAddReadInputs, cmnuDeviceModbusCommandAddReadHoldingRegisters, cmnuDeviceModbusCommandAddReadInputRegisters, cmnuDeviceModbusCommandAddWriteCoil, cmnuDeviceModbusCommandAddWriteInputRegister, cmnuDeviceModbusCommandAddWriteCoils, cmnuDeviceModbusCommandAddWriteInputRegisters });
            cmnuDeviceModbus.Name = "cmnuDeviceModbus";
            cmnuDeviceModbus.Size = new Size(366, 34);
            cmnuDeviceModbus.Text = "Modbus";
            // 
            // cmnuDeviceModbusCommandAddReadCoils
            // 
            cmnuDeviceModbusCommandAddReadCoils.Name = "cmnuDeviceModbusCommandAddReadCoils";
            cmnuDeviceModbusCommandAddReadCoils.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddReadCoils.Tag = "READCOILS";
            cmnuDeviceModbusCommandAddReadCoils.Text = "Чтение Coils (1)";
            cmnuDeviceModbusCommandAddReadCoils.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadInputs
            // 
            cmnuDeviceModbusCommandAddReadInputs.Name = "cmnuDeviceModbusCommandAddReadInputs";
            cmnuDeviceModbusCommandAddReadInputs.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddReadInputs.Tag = "READINPUTS";
            cmnuDeviceModbusCommandAddReadInputs.Text = "Чтение Inputs (2)";
            cmnuDeviceModbusCommandAddReadInputs.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadHoldingRegisters
            // 
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Name = "cmnuDeviceModbusCommandAddReadHoldingRegisters";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Tag = "READHOLDINGREGISTERS";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Text = "Чтение HoldingRegisters (3)";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadInputRegisters
            // 
            cmnuDeviceModbusCommandAddReadInputRegisters.Name = "cmnuDeviceModbusCommandAddReadInputRegisters";
            cmnuDeviceModbusCommandAddReadInputRegisters.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddReadInputRegisters.Tag = "READINPUTREGISTERS";
            cmnuDeviceModbusCommandAddReadInputRegisters.Text = "Чтение InputRegisters (4)";
            cmnuDeviceModbusCommandAddReadInputRegisters.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteCoil
            // 
            cmnuDeviceModbusCommandAddWriteCoil.Name = "cmnuDeviceModbusCommandAddWriteCoil";
            cmnuDeviceModbusCommandAddWriteCoil.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddWriteCoil.Tag = "WRITECOIL";
            cmnuDeviceModbusCommandAddWriteCoil.Text = "Запись Coil (5)";
            cmnuDeviceModbusCommandAddWriteCoil.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteInputRegister
            // 
            cmnuDeviceModbusCommandAddWriteInputRegister.Name = "cmnuDeviceModbusCommandAddWriteInputRegister";
            cmnuDeviceModbusCommandAddWriteInputRegister.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddWriteInputRegister.Tag = "WRITEHOLDINGREGISTER";
            cmnuDeviceModbusCommandAddWriteInputRegister.Text = "Запись HoldingRegister (6)";
            cmnuDeviceModbusCommandAddWriteInputRegister.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteCoils
            // 
            cmnuDeviceModbusCommandAddWriteCoils.Name = "cmnuDeviceModbusCommandAddWriteCoils";
            cmnuDeviceModbusCommandAddWriteCoils.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddWriteCoils.Tag = "WRITEMULTIPLECOILS";
            cmnuDeviceModbusCommandAddWriteCoils.Text = "Запись MultipleCoils (15)";
            cmnuDeviceModbusCommandAddWriteCoils.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteInputRegisters
            // 
            cmnuDeviceModbusCommandAddWriteInputRegisters.Name = "cmnuDeviceModbusCommandAddWriteInputRegisters";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Size = new Size(409, 34);
            cmnuDeviceModbusCommandAddWriteInputRegisters.Tag = "WRITEMULTIPLEHOLDINGREGISTERS";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Text = "Запись MultipleHoldingRegisters (16)";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Click += cmnuDeviceCommandAdd_Click;
            // 
            // cmnuModbusCM
            // 
            cmnuModbusCM.DropDownItems.AddRange(new ToolStripItem[] { cmnuModbusCMCommandAddRead80, cmnuModbusCMCommandAddRead81, cmnuModbusCMCommandAddRead82, cmnuModbusCMCommandAddRead83, cmnuModbusCMCommandAddRead84, cmnuModbusCMCommandAddRead85, cmnuModbusCMCommandAddRead86, cmnuModbusCMCommandAddRead87, cmnuModbusCMCommandAddRead88, cmnuModbusCMCommandAddRead90, cmnuModbusCMCommandAddRead91, cmnuModbusCMCommandAddRead95, cmnuModbusCMCommandAddWrite96 });
            cmnuModbusCM.Name = "cmnuModbusCM";
            cmnuModbusCM.Size = new Size(366, 34);
            cmnuModbusCM.Text = "ВТД";
            // 
            // FrmConfigForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1734, 1368);
            Controls.Add(sptContainer);
            Controls.Add(tlsMenu);
            Controls.Add(mnuMenu);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1748, 1378);
            Name = "FrmConfigForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConfigForm";
            Load += FrmConfigForm_Load;
            cmnuDeviceCommandDelete.ResumeLayout(false);
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
            cmnuDeviceCommandAppend.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        public TreeView trvProject;
        private ImageList imgList;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead82;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead83;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead84;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead85;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead86;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead87;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead88;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead90;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead91;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead95;
        private ToolStripMenuItem cmnuModbusCMCommandAddWrite96;
        private ToolStripMenuItem cmnuDeviceOther;
        private ToolStripMenuItem cmnuDeviceOtherCommandAddRead99;
        private ToolStripMenuItem cmnuDeviceCommandImport;
        private ToolStripMenuItem cmnuDeviceCommandImportSelect;
        private ToolStripMenuItem cmnuDeviceCommandImportAll;
        private ToolStripMenuItem cmnuDeviceCommandGenerate;
        public ContextMenuStrip cmnuDeviceCommandDelete;
        private ToolStripMenuItem cmnuDeviceCommandDel;
        public ContextMenuStrip cmnuDeviceTagAppend;
        private ToolStripMenuItem cmnuDeviceTagAdd;
        public ContextMenuStrip cmnuDeviceTagDelete;
        private ToolStripMenuItem cmnuDeviceTagDel;
        private System.Windows.Forms.Timer tmrTimer;
        private SplitContainer sptContainer;
        private TabControl tabControl;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead81;
        private ToolStripMenuItem cmnuModbusCMCommandAddRead80;
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
        public ContextMenuStrip cmnuDeviceCommandAppend;
        private ToolStripMenuItem cmnuDeviceCommandAdd;
        private ToolStripMenuItem cmnuDeviceModbus;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadCoils;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadInputs;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadHoldingRegisters;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadInputRegisters;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteCoil;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteInputRegister;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteCoils;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteInputRegisters;
        private ToolStripMenuItem cmnuModbusCM;
    }
}