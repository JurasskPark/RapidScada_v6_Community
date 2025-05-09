﻿namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmGroupTag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupTag));
            btnSave = new Button();
            gpbGroup = new GroupBox();
            ckbEnabled = new CheckBox();
            lblName = new Label();
            txtName = new TextBox();
            tabDeviceTag = new TabControl();
            tabTags = new TabPage();
            lstTags = new ListView();
            clmTagName = new ColumnHeader();
            clmTagCode = new ColumnHeader();
            clmTagAddress = new ColumnHeader();
            clmTagDescription = new ColumnHeader();
            clmTagType = new ColumnHeader();
            clmTagCommand = new ColumnHeader();
            clmTagEnabled = new ColumnHeader();
            cmnuTag = new ContextMenuStrip(components);
            tolTagAdd = new ToolStripMenuItem();
            tolTagChange = new ToolStripMenuItem();
            tolTagDelete = new ToolStripMenuItem();
            tolTagDeleteAll = new ToolStripMenuItem();
            smnuSeparator02 = new ToolStripSeparator();
            tolTagUp = new ToolStripMenuItem();
            tolTagDown = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tolCSV = new ToolStripMenuItem();
            tolDataLoadAsCSV = new ToolStripMenuItem();
            tolDataSaveAsCSV = new ToolStripMenuItem();
            gpbGroup.SuspendLayout();
            tabDeviceTag.SuspendLayout();
            tabTags.SuspendLayout();
            cmnuTag.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(447, 19);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 27;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // gpbGroup
            // 
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblName);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(13, 12);
            gpbGroup.Margin = new Padding(4, 3, 4, 3);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(4, 3, 4, 3);
            gpbGroup.Size = new Size(425, 65);
            gpbGroup.TabIndex = 26;
            gpbGroup.TabStop = false;
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(332, 35);
            ckbEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(68, 19);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(10, 13);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(7, 31);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(314, 23);
            txtName.TabIndex = 1;
            // 
            // tabDeviceTag
            // 
            tabDeviceTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabDeviceTag.Controls.Add(tabTags);
            tabDeviceTag.Location = new Point(13, 83);
            tabDeviceTag.Margin = new Padding(4, 3, 4, 3);
            tabDeviceTag.Name = "tabDeviceTag";
            tabDeviceTag.SelectedIndex = 0;
            tabDeviceTag.Size = new Size(897, 452);
            tabDeviceTag.TabIndex = 28;
            // 
            // tabTags
            // 
            tabTags.Controls.Add(lstTags);
            tabTags.Location = new Point(4, 24);
            tabTags.Margin = new Padding(4, 3, 4, 3);
            tabTags.Name = "tabTags";
            tabTags.Size = new Size(889, 424);
            tabTags.TabIndex = 2;
            tabTags.Text = "Tags";
            tabTags.UseVisualStyleBackColor = true;
            // 
            // lstTags
            // 
            lstTags.Columns.AddRange(new ColumnHeader[] { clmTagName, clmTagCode, clmTagAddress, clmTagDescription, clmTagType, clmTagCommand, clmTagEnabled });
            lstTags.ContextMenuStrip = cmnuTag;
            lstTags.Dock = DockStyle.Fill;
            lstTags.FullRowSelect = true;
            lstTags.GridLines = true;
            lstTags.Location = new Point(0, 0);
            lstTags.Margin = new Padding(4, 3, 4, 3);
            lstTags.MultiSelect = false;
            lstTags.Name = "lstTags";
            lstTags.Size = new Size(889, 424);
            lstTags.TabIndex = 20;
            lstTags.UseCompatibleStateImageBehavior = false;
            lstTags.View = System.Windows.Forms.View.Details;
            // 
            // clmTagName
            // 
            clmTagName.Text = "Name";
            clmTagName.Width = 180;
            // 
            // clmTagCode
            // 
            clmTagCode.Text = "Code";
            clmTagCode.Width = 180;
            // 
            // clmTagAddress
            // 
            clmTagAddress.Text = "Address";
            clmTagAddress.Width = 80;
            // 
            // clmTagDescription
            // 
            clmTagDescription.Text = "Description";
            clmTagDescription.Width = 180;
            // 
            // clmTagType
            // 
            clmTagType.Text = "Type";
            clmTagType.Width = 100;
            // 
            // clmTagCommand
            // 
            clmTagCommand.Text = "Command";
            clmTagCommand.Width = 80;
            // 
            // clmTagEnabled
            // 
            clmTagEnabled.Text = "Enabled";
            clmTagEnabled.Width = 80;
            // 
            // cmnuTag
            // 
            cmnuTag.Items.AddRange(new ToolStripItem[] { tolTagAdd, tolTagChange, tolTagDelete, tolTagDeleteAll, smnuSeparator02, tolTagUp, tolTagDown, toolStripSeparator1, tolCSV });
            cmnuTag.Name = "contextMenuDeviceEdit";
            cmnuTag.Size = new Size(148, 170);
            // 
            // tolTagAdd
            // 
            tolTagAdd.Image = (Image)resources.GetObject("tolTagAdd.Image");
            tolTagAdd.Name = "tolTagAdd";
            tolTagAdd.Size = new Size(147, 22);
            tolTagAdd.Text = "Add";
            tolTagAdd.Click += tolTagAdd_Click;
            // 
            // tolTagChange
            // 
            tolTagChange.Image = (Image)resources.GetObject("tolTagChange.Image");
            tolTagChange.Name = "tolTagChange";
            tolTagChange.Size = new Size(147, 22);
            tolTagChange.Text = "Change";
            tolTagChange.Click += tolTagChange_Click;
            // 
            // tolTagDelete
            // 
            tolTagDelete.Image = (Image)resources.GetObject("tolTagDelete.Image");
            tolTagDelete.Name = "tolTagDelete";
            tolTagDelete.Size = new Size(147, 22);
            tolTagDelete.Text = "Delete";
            tolTagDelete.Click += tolTagDelete_Click;
            // 
            // tolTagDeleteAll
            // 
            tolTagDeleteAll.Image = (Image)resources.GetObject("tolTagDeleteAll.Image");
            tolTagDeleteAll.Name = "tolTagDeleteAll";
            tolTagDeleteAll.Size = new Size(147, 22);
            tolTagDeleteAll.Text = "Delete all tags";
            tolTagDeleteAll.Click += tolTagDeleteAll_Click;
            // 
            // smnuSeparator02
            // 
            smnuSeparator02.Name = "smnuSeparator02";
            smnuSeparator02.Size = new Size(144, 6);
            // 
            // tolTagUp
            // 
            tolTagUp.Image = (Image)resources.GetObject("tolTagUp.Image");
            tolTagUp.Name = "tolTagUp";
            tolTagUp.Size = new Size(147, 22);
            tolTagUp.Text = "Tag up";
            tolTagUp.Click += tolTagUp_Click;
            // 
            // tolTagDown
            // 
            tolTagDown.Image = (Image)resources.GetObject("tolTagDown.Image");
            tolTagDown.Name = "tolTagDown";
            tolTagDown.Size = new Size(147, 22);
            tolTagDown.Text = "Tag down";
            tolTagDown.Click += tolTagDown_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(144, 6);
            // 
            // tolCSV
            // 
            tolCSV.DropDownItems.AddRange(new ToolStripItem[] { tolDataLoadAsCSV, tolDataSaveAsCSV });
            tolCSV.Image = (Image)resources.GetObject("tolCSV.Image");
            tolCSV.Name = "tolCSV";
            tolCSV.Size = new Size(147, 22);
            tolCSV.Text = "CSV";
            // 
            // tolDataLoadAsCSV
            // 
            tolDataLoadAsCSV.Image = (Image)resources.GetObject("tolDataLoadAsCSV.Image");
            tolDataLoadAsCSV.Name = "tolDataLoadAsCSV";
            tolDataLoadAsCSV.Size = new Size(165, 22);
            tolDataLoadAsCSV.Text = "Upload from CSV";
            // 
            // tolDataSaveAsCSV
            // 
            tolDataSaveAsCSV.Image = (Image)resources.GetObject("tolDataSaveAsCSV.Image");
            tolDataSaveAsCSV.Name = "tolDataSaveAsCSV";
            tolDataSaveAsCSV.Size = new Size(165, 22);
            tolDataSaveAsCSV.Text = "Upload to CSV";
            // 
            // FrmGroupTag
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 547);
            Controls.Add(tabDeviceTag);
            Controls.Add(btnSave);
            Controls.Add(gpbGroup);
            Name = "FrmGroupTag";
            Text = "Tags";
            Load += FrmGroupTag_Load;
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            tabDeviceTag.ResumeLayout(false);
            tabTags.ResumeLayout(false);
            cmnuTag.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnSave;
        private GroupBox gpbGroup;
        private CheckBox ckbEnabled;
        private Label lblName;
        private TextBox txtName;
        private TabControl tabDeviceTag;
        private TabPage tabTags;
        private ListView lstTags;
        private ColumnHeader clmTagName;
        private ColumnHeader clmTagCode;
        private ColumnHeader clmTagAddress;
        private ColumnHeader clmTagDescription;
        private ColumnHeader clmTagType;
        private ColumnHeader clmTagCommand;
        private ColumnHeader clmTagEnabled;
        private ContextMenuStrip cmnuTag;
        private ToolStripMenuItem tolTagAdd;
        private ToolStripMenuItem tolTagChange;
        private ToolStripMenuItem tolTagDelete;
        private ToolStripMenuItem tolTagDeleteAll;
        private ToolStripSeparator smnuSeparator02;
        private ToolStripMenuItem tolTagUp;
        private ToolStripMenuItem tolTagDown;
        private ToolStripMenuItem tolCSV;
        private ToolStripMenuItem tolDataLoadAsCSV;
        private ToolStripMenuItem tolDataSaveAsCSV;
        private ToolStripSeparator toolStripSeparator1;
    }
}