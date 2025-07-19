namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            trvProject = new TreeView();
            imgList = new ImageList(components);
            tabControl = new TabControl();
            cmnuTagAppend = new ContextMenuStrip(components);
            cmnuAddTag = new ToolStripMenuItem();
            cmnuSeparator1 = new ToolStripSeparator();
            cmnuDeleteGroup = new ToolStripMenuItem();
            cmnuSeparator2 = new ToolStripSeparator();
            сmnuSelectVariableUp = new ToolStripMenuItem();
            сmnuSelectVariableDown = new ToolStripMenuItem();
            cmnuDeleteAction = new ContextMenuStrip(components);
            cmnuDeleteVariable = new ToolStripMenuItem();
            cmnuSeparator3 = new ToolStripSeparator();
            сmnuSelectVariableActionUp = new ToolStripMenuItem();
            сmnuSelectVariableActionDown = new ToolStripMenuItem();
            splContainer = new SplitContainer();
            tlsMenu = new ToolStrip();
            tlsProjectNew = new ToolStripButton();
            tlsProjectOpen = new ToolStripButton();
            tlsProjectSave = new ToolStripButton();
            tlsProjectSaveAs = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            imgListForm = new ImageList(components);
            cmnuDeviceAppend = new ContextMenuStrip(components);
            cmnuDeviceAdd = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            cmnuChannelDel = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            upToolStripMenuItem1 = new ToolStripMenuItem();
            downToolStripMenuItem1 = new ToolStripMenuItem();
            cmnuDeviceDelete = new ContextMenuStrip(components);
            cmnuDeviceDel = new ToolStripMenuItem();
            cmnuCommandAppend = new ContextMenuStrip(components);
            cmnuCommandAdd = new ToolStripMenuItem();
            cmnuTypeStandard = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadCoils = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadInputs = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadHoldingRegisters = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddReadInputRegisters = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteCoil = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteInputRegister = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteCoils = new ToolStripMenuItem();
            cmnuDeviceModbusCommandAddWriteInputRegisters = new ToolStripMenuItem();
            cmnuTypeOther = new ToolStripMenuItem();
            cmnuDeviceOtherCommandAddRead99 = new ToolStripMenuItem();
            cmnuCommandImport = new ToolStripMenuItem();
            cmnuCommandImportSelect = new ToolStripMenuItem();
            cmnuCommandImportAll = new ToolStripMenuItem();
            cmnuCommandGenerate = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            upToolStripMenuItem2 = new ToolStripMenuItem();
            downToolStripMenuItem2 = new ToolStripMenuItem();
            cmnuCommandDelete = new ContextMenuStrip(components);
            cmnuCommandDel = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cmnuCommandUp = new ToolStripMenuItem();
            cmnuCommandDown = new ToolStripMenuItem();
            cmnuChannelAppend = new ContextMenuStrip(components);
            cmnuChannelAdd = new ToolStripMenuItem();
            cmnuTagAppend.SuspendLayout();
            cmnuDeleteAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splContainer).BeginInit();
            splContainer.Panel1.SuspendLayout();
            splContainer.Panel2.SuspendLayout();
            splContainer.SuspendLayout();
            tlsMenu.SuspendLayout();
            cmnuDeviceAppend.SuspendLayout();
            cmnuDeviceDelete.SuspendLayout();
            cmnuCommandAppend.SuspendLayout();
            cmnuCommandDelete.SuspendLayout();
            cmnuChannelAppend.SuspendLayout();
            SuspendLayout();
            // 
            // trvProject
            // 
            trvProject.AllowDrop = true;
            trvProject.Dock = DockStyle.Fill;
            trvProject.ImageIndex = 0;
            trvProject.ImageList = imgList;
            trvProject.Location = new Point(0, 0);
            trvProject.Name = "trvProject";
            trvProject.SelectedImageIndex = 0;
            trvProject.Size = new Size(172, 446);
            trvProject.TabIndex = 0;
            trvProject.AfterSelect += trvProject_AfterSelect;
            trvProject.MouseDown += trvProject_MouseDown;
            // 
            // imgList
            // 
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.ImageStream = (ImageListStreamer)resources.GetObject("imgList.ImageStream");
            imgList.TransparentColor = Color.Transparent;
            imgList.Images.SetKeyName(0, "default_16.png");
            imgList.Images.SetKeyName(1, "driver_16.png");
            imgList.Images.SetKeyName(2, "setting_tools_16.png");
            imgList.Images.SetKeyName(3, "group_channel_16.png");
            imgList.Images.SetKeyName(4, "channel_empty_16.png");
            imgList.Images.SetKeyName(5, "channel_ethernet_16.png");
            imgList.Images.SetKeyName(6, "channel_serialport_16.png");
            imgList.Images.SetKeyName(7, "device_16.png");
            imgList.Images.SetKeyName(8, "device_off_16.png");
            imgList.Images.SetKeyName(9, "cmd_group_16.png");
            imgList.Images.SetKeyName(10, "cmd_group_off_16.png");
            imgList.Images.SetKeyName(11, "cmd_00_16.png");
            imgList.Images.SetKeyName(12, "cmd_00_off_16.png");
            imgList.Images.SetKeyName(13, "cmd_01_16.png");
            imgList.Images.SetKeyName(14, "cmd_01_off_16.png");
            imgList.Images.SetKeyName(15, "cmd_02_16.png");
            imgList.Images.SetKeyName(16, "cmd_02_off_16.png");
            imgList.Images.SetKeyName(17, "cmd_03_16.png");
            imgList.Images.SetKeyName(18, "cmd_03_off_16.png");
            imgList.Images.SetKeyName(19, "cmd_04_16.png");
            imgList.Images.SetKeyName(20, "cmd_04_off_16.png");
            imgList.Images.SetKeyName(21, "tag_group_16.png");
            imgList.Images.SetKeyName(22, "tag_group_off_16.png");
            imgList.Images.SetKeyName(23, "tag_16.png");
            imgList.Images.SetKeyName(24, "tag_add_16.png");
            imgList.Images.SetKeyName(25, "tag_edit_16.png");
            imgList.Images.SetKeyName(26, "tag_delete_16.png");
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.ImageList = imgList;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(643, 446);
            tabControl.TabIndex = 1;
            // 
            // cmnuTagAppend
            // 
            cmnuTagAppend.ImageScalingSize = new Size(24, 24);
            cmnuTagAppend.Items.AddRange(new ToolStripItem[] { cmnuAddTag, cmnuSeparator1, cmnuDeleteGroup, cmnuSeparator2, сmnuSelectVariableUp, сmnuSelectVariableDown });
            cmnuTagAppend.Name = "cmnu";
            cmnuTagAppend.Size = new Size(108, 104);
            // 
            // cmnuAddTag
            // 
            cmnuAddTag.Name = "cmnuAddTag";
            cmnuAddTag.Size = new Size(107, 22);
            // 
            // cmnuSeparator1
            // 
            cmnuSeparator1.Name = "cmnuSeparator1";
            cmnuSeparator1.Size = new Size(104, 6);
            // 
            // cmnuDeleteGroup
            // 
            cmnuDeleteGroup.Name = "cmnuDeleteGroup";
            cmnuDeleteGroup.Size = new Size(107, 22);
            cmnuDeleteGroup.Text = "Delete";
            cmnuDeleteGroup.Click += cmnuDeleteGroup_Click;
            // 
            // cmnuSeparator2
            // 
            cmnuSeparator2.Name = "cmnuSeparator2";
            cmnuSeparator2.Size = new Size(104, 6);
            // 
            // сmnuSelectVariableUp
            // 
            сmnuSelectVariableUp.Name = "сmnuSelectVariableUp";
            сmnuSelectVariableUp.Size = new Size(107, 22);
            сmnuSelectVariableUp.Text = "Up";
            сmnuSelectVariableUp.Click += сmnuSelectVariableUp_Click;
            // 
            // сmnuSelectVariableDown
            // 
            сmnuSelectVariableDown.Name = "сmnuSelectVariableDown";
            сmnuSelectVariableDown.Size = new Size(107, 22);
            сmnuSelectVariableDown.Text = "Down";
            сmnuSelectVariableDown.Click += сmnuSelectVariableDown_Click;
            // 
            // cmnuDeleteAction
            // 
            cmnuDeleteAction.ImageScalingSize = new Size(24, 24);
            cmnuDeleteAction.Items.AddRange(new ToolStripItem[] { cmnuDeleteVariable, cmnuSeparator3, сmnuSelectVariableActionUp, сmnuSelectVariableActionDown });
            cmnuDeleteAction.Name = "cmnu";
            cmnuDeleteAction.Size = new Size(108, 76);
            // 
            // cmnuDeleteVariable
            // 
            cmnuDeleteVariable.Name = "cmnuDeleteVariable";
            cmnuDeleteVariable.Size = new Size(107, 22);
            cmnuDeleteVariable.Text = "Delete";
            cmnuDeleteVariable.Click += cmnuDeleteVariable_Click;
            // 
            // cmnuSeparator3
            // 
            cmnuSeparator3.Name = "cmnuSeparator3";
            cmnuSeparator3.Size = new Size(104, 6);
            // 
            // сmnuSelectVariableActionUp
            // 
            сmnuSelectVariableActionUp.Name = "сmnuSelectVariableActionUp";
            сmnuSelectVariableActionUp.Size = new Size(107, 22);
            сmnuSelectVariableActionUp.Text = "Up";
            сmnuSelectVariableActionUp.Click += сmnuSelectVariableActionUp_Click;
            // 
            // сmnuSelectVariableActionDown
            // 
            сmnuSelectVariableActionDown.Name = "сmnuSelectVariableActionDown";
            сmnuSelectVariableActionDown.Size = new Size(107, 22);
            сmnuSelectVariableActionDown.Text = "Down";
            сmnuSelectVariableActionDown.Click += сmnuSelectVariableActionDown_Click;
            // 
            // splContainer
            // 
            splContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splContainer.Location = new Point(0, 42);
            splContainer.Name = "splContainer";
            // 
            // splContainer.Panel1
            // 
            splContainer.Panel1.Controls.Add(trvProject);
            // 
            // splContainer.Panel2
            // 
            splContainer.Panel2.Controls.Add(tabControl);
            splContainer.Size = new Size(819, 446);
            splContainer.SplitterDistance = 172;
            splContainer.TabIndex = 5;
            splContainer.SplitterMoved += splContainer_SplitterMoved;
            // 
            // tlsMenu
            // 
            tlsMenu.ImageScalingSize = new Size(32, 32);
            tlsMenu.Items.AddRange(new ToolStripItem[] { tlsProjectNew, tlsProjectOpen, tlsProjectSave, tlsProjectSaveAs, toolStripSeparator2 });
            tlsMenu.Location = new Point(0, 0);
            tlsMenu.Name = "tlsMenu";
            tlsMenu.Padding = new Padding(0, 0, 2, 0);
            tlsMenu.Size = new Size(819, 39);
            tlsMenu.TabIndex = 11;
            tlsMenu.Text = "Menu";
            // 
            // tlsProjectNew
            // 
            tlsProjectNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectNew.Image = (Image)resources.GetObject("tlsProjectNew.Image");
            tlsProjectNew.ImageTransparentColor = Color.Magenta;
            tlsProjectNew.Name = "tlsProjectNew";
            tlsProjectNew.Size = new Size(36, 36);
            tlsProjectNew.Text = "New";
            tlsProjectNew.Click += tlsProjectNew_Click;
            // 
            // tlsProjectOpen
            // 
            tlsProjectOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectOpen.Image = (Image)resources.GetObject("tlsProjectOpen.Image");
            tlsProjectOpen.ImageTransparentColor = Color.Magenta;
            tlsProjectOpen.Name = "tlsProjectOpen";
            tlsProjectOpen.Size = new Size(36, 36);
            tlsProjectOpen.Text = "Open";
            tlsProjectOpen.Click += tlsProjectOpen_Click;
            // 
            // tlsProjectSave
            // 
            tlsProjectSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectSave.Image = (Image)resources.GetObject("tlsProjectSave.Image");
            tlsProjectSave.ImageTransparentColor = Color.Magenta;
            tlsProjectSave.Name = "tlsProjectSave";
            tlsProjectSave.Size = new Size(36, 36);
            tlsProjectSave.Text = "Save";
            tlsProjectSave.Click += tlsProjectSave_Click;
            // 
            // tlsProjectSaveAs
            // 
            tlsProjectSaveAs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tlsProjectSaveAs.Image = (Image)resources.GetObject("tlsProjectSaveAs.Image");
            tlsProjectSaveAs.ImageTransparentColor = Color.Magenta;
            tlsProjectSaveAs.Name = "tlsProjectSaveAs";
            tlsProjectSaveAs.Size = new Size(36, 36);
            tlsProjectSaveAs.Text = "Save As...";
            tlsProjectSaveAs.Click += tlsProjectSaveAs_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 39);
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
            // cmnuDeviceAppend
            // 
            cmnuDeviceAppend.ImageScalingSize = new Size(24, 24);
            cmnuDeviceAppend.Items.AddRange(new ToolStripItem[] { cmnuDeviceAdd, toolStripSeparator5, cmnuChannelDel, toolStripSeparator3, upToolStripMenuItem1, downToolStripMenuItem1 });
            cmnuDeviceAppend.Name = "HMI_contextMenu";
            cmnuDeviceAppend.Size = new Size(142, 136);
            // 
            // cmnuDeviceAdd
            // 
            cmnuDeviceAdd.Image = (Image)resources.GetObject("cmnuDeviceAdd.Image");
            cmnuDeviceAdd.Name = "cmnuDeviceAdd";
            cmnuDeviceAdd.Size = new Size(141, 30);
            cmnuDeviceAdd.Text = "Add device";
            cmnuDeviceAdd.Click += cmnuDeviceAdd_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(138, 6);
            // 
            // cmnuChannelDel
            // 
            cmnuChannelDel.Image = (Image)resources.GetObject("cmnuChannelDel.Image");
            cmnuChannelDel.Name = "cmnuChannelDel";
            cmnuChannelDel.Size = new Size(141, 30);
            cmnuChannelDel.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(138, 6);
            // 
            // upToolStripMenuItem1
            // 
            upToolStripMenuItem1.Image = (Image)resources.GetObject("upToolStripMenuItem1.Image");
            upToolStripMenuItem1.Name = "upToolStripMenuItem1";
            upToolStripMenuItem1.Size = new Size(141, 30);
            upToolStripMenuItem1.Text = "Up";
            // 
            // downToolStripMenuItem1
            // 
            downToolStripMenuItem1.Image = (Image)resources.GetObject("downToolStripMenuItem1.Image");
            downToolStripMenuItem1.Name = "downToolStripMenuItem1";
            downToolStripMenuItem1.Size = new Size(141, 30);
            downToolStripMenuItem1.Text = "Down";
            // 
            // cmnuDeviceDelete
            // 
            cmnuDeviceDelete.ImageScalingSize = new Size(24, 24);
            cmnuDeviceDelete.Items.AddRange(new ToolStripItem[] { cmnuDeviceDel });
            cmnuDeviceDelete.Name = "HMI_contextMenu";
            cmnuDeviceDelete.Size = new Size(189, 56);
            // 
            // cmnuDeviceDel
            // 
            cmnuDeviceDel.Image = (Image)resources.GetObject("cmnuDeviceDel.Image");
            cmnuDeviceDel.Name = "cmnuDeviceDel";
            cmnuDeviceDel.Size = new Size(188, 30);
            cmnuDeviceDel.Text = "Delete";
            cmnuDeviceDel.Click += cmnuDeviceDel_Click;
            // 
            // cmnuCommandAppend
            // 
            cmnuCommandAppend.ImageScalingSize = new Size(24, 24);
            cmnuCommandAppend.Items.AddRange(new ToolStripItem[] { cmnuCommandAdd, cmnuCommandImport, cmnuCommandGenerate, toolStripSeparator6, upToolStripMenuItem2, downToolStripMenuItem2 });
            cmnuCommandAppend.Name = "HMI_contextMenu";
            cmnuCommandAppend.Size = new Size(185, 120);
            // 
            // cmnuCommandAdd
            // 
            cmnuCommandAdd.DropDownItems.AddRange(new ToolStripItem[] { cmnuTypeStandard, cmnuTypeOther });
            cmnuCommandAdd.Name = "cmnuCommandAdd";
            cmnuCommandAdd.Size = new Size(184, 22);
            cmnuCommandAdd.Text = "Create command";
            // 
            // cmnuTypeStandard
            // 
            cmnuTypeStandard.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceModbusCommandAddReadCoils, cmnuDeviceModbusCommandAddReadInputs, cmnuDeviceModbusCommandAddReadHoldingRegisters, cmnuDeviceModbusCommandAddReadInputRegisters, cmnuDeviceModbusCommandAddWriteCoil, cmnuDeviceModbusCommandAddWriteInputRegister, cmnuDeviceModbusCommandAddWriteCoils, cmnuDeviceModbusCommandAddWriteInputRegisters });
            cmnuTypeStandard.Name = "cmnuTypeStandard";
            cmnuTypeStandard.Size = new Size(197, 22);
            cmnuTypeStandard.Text = "Standard";
            // 
            // cmnuDeviceModbusCommandAddReadCoils
            // 
            cmnuDeviceModbusCommandAddReadCoils.Name = "cmnuDeviceModbusCommandAddReadCoils";
            cmnuDeviceModbusCommandAddReadCoils.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddReadCoils.Tag = "READCOILS";
            cmnuDeviceModbusCommandAddReadCoils.Text = "Read Coils (1)";
            cmnuDeviceModbusCommandAddReadCoils.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadInputs
            // 
            cmnuDeviceModbusCommandAddReadInputs.Name = "cmnuDeviceModbusCommandAddReadInputs";
            cmnuDeviceModbusCommandAddReadInputs.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddReadInputs.Tag = "READINPUTS";
            cmnuDeviceModbusCommandAddReadInputs.Text = "Read Inputs (2)";
            cmnuDeviceModbusCommandAddReadInputs.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadHoldingRegisters
            // 
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Name = "cmnuDeviceModbusCommandAddReadHoldingRegisters";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Tag = "READHOLDINGREGISTERS";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Text = "Read HoldingRegisters (3)";
            cmnuDeviceModbusCommandAddReadHoldingRegisters.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddReadInputRegisters
            // 
            cmnuDeviceModbusCommandAddReadInputRegisters.Name = "cmnuDeviceModbusCommandAddReadInputRegisters";
            cmnuDeviceModbusCommandAddReadInputRegisters.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddReadInputRegisters.Tag = "READINPUTREGISTERS";
            cmnuDeviceModbusCommandAddReadInputRegisters.Text = "Read InputRegisters (4)";
            cmnuDeviceModbusCommandAddReadInputRegisters.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteCoil
            // 
            cmnuDeviceModbusCommandAddWriteCoil.Name = "cmnuDeviceModbusCommandAddWriteCoil";
            cmnuDeviceModbusCommandAddWriteCoil.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddWriteCoil.Tag = "WRITECOIL";
            cmnuDeviceModbusCommandAddWriteCoil.Text = "Write Coil (5)";
            cmnuDeviceModbusCommandAddWriteCoil.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteInputRegister
            // 
            cmnuDeviceModbusCommandAddWriteInputRegister.Name = "cmnuDeviceModbusCommandAddWriteInputRegister";
            cmnuDeviceModbusCommandAddWriteInputRegister.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddWriteInputRegister.Tag = "WRITEHOLDINGREGISTER";
            cmnuDeviceModbusCommandAddWriteInputRegister.Text = "Write HoldingRegister (6)";
            cmnuDeviceModbusCommandAddWriteInputRegister.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteCoils
            // 
            cmnuDeviceModbusCommandAddWriteCoils.Name = "cmnuDeviceModbusCommandAddWriteCoils";
            cmnuDeviceModbusCommandAddWriteCoils.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddWriteCoils.Tag = "WRITEMULTIPLECOILS";
            cmnuDeviceModbusCommandAddWriteCoils.Text = "Write MultipleCoils (15)";
            cmnuDeviceModbusCommandAddWriteCoils.Click += cmnuCommandAdd_Click;
            // 
            // cmnuDeviceModbusCommandAddWriteInputRegisters
            // 
            cmnuDeviceModbusCommandAddWriteInputRegisters.Name = "cmnuDeviceModbusCommandAddWriteInputRegisters";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Size = new Size(262, 22);
            cmnuDeviceModbusCommandAddWriteInputRegisters.Tag = "WRITEMULTIPLEHOLDINGREGISTERS";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Text = "Write MultipleHoldingRegisters (16)";
            cmnuDeviceModbusCommandAddWriteInputRegisters.Click += cmnuCommandAdd_Click;
            // 
            // cmnuTypeOther
            // 
            cmnuTypeOther.DropDownItems.AddRange(new ToolStripItem[] { cmnuDeviceOtherCommandAddRead99 });
            cmnuTypeOther.Name = "cmnuTypeOther";
            cmnuTypeOther.Size = new Size(197, 22);
            cmnuTypeOther.Text = "Rarely used commands";
            // 
            // cmnuDeviceOtherCommandAddRead99
            // 
            cmnuDeviceOtherCommandAddRead99.Name = "cmnuDeviceOtherCommandAddRead99";
            cmnuDeviceOtherCommandAddRead99.Size = new Size(143, 22);
            cmnuDeviceOtherCommandAddRead99.Tag = "ARBITRARY";
            cmnuDeviceOtherCommandAddRead99.Text = "Arbitrary (99)";
            // 
            // cmnuCommandImport
            // 
            cmnuCommandImport.DropDownItems.AddRange(new ToolStripItem[] { cmnuCommandImportSelect, cmnuCommandImportAll });
            cmnuCommandImport.Name = "cmnuCommandImport";
            cmnuCommandImport.Size = new Size(184, 22);
            cmnuCommandImport.Text = "Import command";
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
            cmnuCommandGenerate.Size = new Size(184, 22);
            cmnuCommandGenerate.Text = "Generate commands";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(181, 6);
            // 
            // upToolStripMenuItem2
            // 
            upToolStripMenuItem2.Name = "upToolStripMenuItem2";
            upToolStripMenuItem2.Size = new Size(184, 22);
            upToolStripMenuItem2.Text = "Up";
            // 
            // downToolStripMenuItem2
            // 
            downToolStripMenuItem2.Name = "downToolStripMenuItem2";
            downToolStripMenuItem2.Size = new Size(184, 22);
            downToolStripMenuItem2.Text = "Down";
            // 
            // cmnuCommandDelete
            // 
            cmnuCommandDelete.ImageScalingSize = new Size(24, 24);
            cmnuCommandDelete.Items.AddRange(new ToolStripItem[] { cmnuCommandDel, toolStripSeparator1, cmnuCommandUp, cmnuCommandDown });
            cmnuCommandDelete.Name = "HMI_contextMenu";
            cmnuCommandDelete.Size = new Size(116, 100);
            cmnuCommandDelete.Click += cmnuCommandDelete_Click;
            // 
            // cmnuCommandDel
            // 
            cmnuCommandDel.Image = (Image)resources.GetObject("cmnuCommandDel.Image");
            cmnuCommandDel.Name = "cmnuCommandDel";
            cmnuCommandDel.Size = new Size(115, 30);
            cmnuCommandDel.Text = "Delete";
            cmnuCommandDel.ToolTipText = "Удалить группу";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(112, 6);
            // 
            // cmnuCommandUp
            // 
            cmnuCommandUp.Image = (Image)resources.GetObject("cmnuCommandUp.Image");
            cmnuCommandUp.Name = "cmnuCommandUp";
            cmnuCommandUp.Size = new Size(115, 30);
            cmnuCommandUp.Text = "Up";
            // 
            // cmnuCommandDown
            // 
            cmnuCommandDown.Image = (Image)resources.GetObject("cmnuCommandDown.Image");
            cmnuCommandDown.Name = "cmnuCommandDown";
            cmnuCommandDown.Size = new Size(115, 30);
            cmnuCommandDown.Text = "Down";
            // 
            // cmnuChannelAppend
            // 
            cmnuChannelAppend.ImageScalingSize = new Size(24, 24);
            cmnuChannelAppend.Items.AddRange(new ToolStripItem[] { cmnuChannelAdd });
            cmnuChannelAppend.Name = "HMI_contextMenu";
            cmnuChannelAppend.Size = new Size(150, 34);
            // 
            // cmnuChannelAdd
            // 
            cmnuChannelAdd.Image = (Image)resources.GetObject("cmnuChannelAdd.Image");
            cmnuChannelAdd.Name = "cmnuChannelAdd";
            cmnuChannelAdd.Size = new Size(149, 30);
            cmnuChannelAdd.Text = "Add channel";
            cmnuChannelAdd.Click += cmnuChannelAdd_Click;
            // 
            // FrmConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 488);
            Controls.Add(tlsMenu);
            Controls.Add(splContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmConfig";
            Text = "Config";
            FormClosing += FrmConfig_FormClosing;
            Load += FrmConfig_Load;
            cmnuTagAppend.ResumeLayout(false);
            cmnuDeleteAction.ResumeLayout(false);
            splContainer.Panel1.ResumeLayout(false);
            splContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splContainer).EndInit();
            splContainer.ResumeLayout(false);
            tlsMenu.ResumeLayout(false);
            tlsMenu.PerformLayout();
            cmnuDeviceAppend.ResumeLayout(false);
            cmnuDeviceDelete.ResumeLayout(false);
            cmnuCommandAppend.ResumeLayout(false);
            cmnuCommandDelete.ResumeLayout(false);
            cmnuChannelAppend.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl;
        public TreeView trvProject;
        private ToolStripMenuItem cmnuAddTag;
        private ToolStripSeparator cmnuSeparator1;
        private ToolStripMenuItem сmnuSelectVariableUp;
        private ToolStripMenuItem сmnuSelectVariableDown;
        private ContextMenuStrip cmnuDeleteAction;
        private ToolStripMenuItem cmnuDeleteVariable;
        private ToolStripSeparator cmnuSeparator3;
        private ToolStripMenuItem сmnuSelectVariableActionUp;
        private ToolStripMenuItem сmnuSelectVariableActionDown;
        private ToolStripMenuItem cmnuDeleteGroup;
        private ToolStripSeparator cmnuSeparator2;
        private SplitContainer splContainer;
        private ToolStrip tlsMenu;
        private ToolStripButton tlsProjectNew;
        private ToolStripButton tlsProjectOpen;
        private ToolStripButton tlsProjectSave;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tlsProjectSaveAs;
        public ImageList imgListForm;
        public ImageList imgList;
        public ContextMenuStrip cmnuDeviceAppend;
        private ToolStripMenuItem cmnuDeviceAdd;
        public ContextMenuStrip cmnuTagAppend;
        public ContextMenuStrip cmnuDeviceDelete;
        private ToolStripMenuItem cmnuDeviceDel;
        public ContextMenuStrip cmnuCommandAppend;
        private ToolStripMenuItem cmnuCommandAdd;
        private ToolStripMenuItem cmnuTypeStandard;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadCoils;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadInputs;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadHoldingRegisters;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddReadInputRegisters;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteCoil;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteInputRegister;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteCoils;
        private ToolStripMenuItem cmnuDeviceModbusCommandAddWriteInputRegisters;
        private ToolStripMenuItem cmnuTypeOther;
        private ToolStripMenuItem cmnuDeviceOtherCommandAddRead99;
        private ToolStripMenuItem cmnuCommandImport;
        private ToolStripMenuItem cmnuCommandImportSelect;
        private ToolStripMenuItem cmnuCommandImportAll;
        private ToolStripMenuItem cmnuCommandGenerate;
        public ContextMenuStrip cmnuCommandDelete;
        private ToolStripMenuItem cmnuCommandUp;
        private ToolStripMenuItem cmnuCommandDown;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cmnuCommandDel;
        public ContextMenuStrip cmnuChannelAppend;
        private ToolStripMenuItem cmnuChannelAdd;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem upToolStripMenuItem1;
        private ToolStripMenuItem downToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem upToolStripMenuItem2;
        private ToolStripMenuItem downToolStripMenuItem2;
        private ToolStripMenuItem cmnuChannelDel;
        private ToolStripSeparator toolStripSeparator3;
    }
}