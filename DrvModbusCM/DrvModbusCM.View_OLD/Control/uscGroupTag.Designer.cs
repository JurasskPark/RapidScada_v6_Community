namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscGroupTag
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tlpPanelGroupTag = new TableLayoutPanel();
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
            tolTagSort = new ToolStripMenuItem();
            tolTagSortDefault = new ToolStripMenuItem();
            tolTagSortTagAddress = new ToolStripMenuItem();
            tolTagSortTagName = new ToolStripMenuItem();
            tolTagSortTagDescription = new ToolStripMenuItem();
            tolTagSortTagType = new ToolStripMenuItem();
            smnuSeparator03 = new ToolStripSeparator();
            tolCSV = new ToolStripMenuItem();
            tolDataLoadAsCSV = new ToolStripMenuItem();
            tolDataSaveAsCSV = new ToolStripMenuItem();
            tabMonitoring = new TabPage();
            lstMonitoring = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            cmnuMonitoring = new ContextMenuStrip(components);
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripMenuItem18 = new ToolStripMenuItem();
            toolStripMenuItem19 = new ToolStripMenuItem();
            toolStripMenuItem20 = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            tolShowLog = new ToolStripMenuItem();
            tabLog = new TabPage();
            rchLog = new RichTextBox();
            pnlPanelGroupTagTop = new Panel();
            btnSave = new Button();
            ckbEnabled = new CheckBox();
            txtNameGroupTag = new TextBox();
            lblNameGroupTag = new Label();
            tmrTimer = new System.Windows.Forms.Timer(components);
            buildGraphToolStripMenuItem = new ToolStripMenuItem();
            smnuSeparator01 = new ToolStripSeparator();
            tlpPanelGroupTag.SuspendLayout();
            tabDeviceTag.SuspendLayout();
            tabTags.SuspendLayout();
            cmnuTag.SuspendLayout();
            tabMonitoring.SuspendLayout();
            cmnuMonitoring.SuspendLayout();
            tabLog.SuspendLayout();
            pnlPanelGroupTagTop.SuspendLayout();
            SuspendLayout();
            // 
            // tlpPanelGroupTag
            // 
            tlpPanelGroupTag.ColumnCount = 1;
            tlpPanelGroupTag.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpPanelGroupTag.Controls.Add(tabDeviceTag, 0, 1);
            tlpPanelGroupTag.Controls.Add(pnlPanelGroupTagTop, 0, 0);
            tlpPanelGroupTag.Dock = DockStyle.Fill;
            tlpPanelGroupTag.Location = new Point(0, 0);
            tlpPanelGroupTag.Name = "tlpPanelGroupTag";
            tlpPanelGroupTag.RowCount = 2;
            tlpPanelGroupTag.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tlpPanelGroupTag.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPanelGroupTag.Size = new Size(900, 700);
            tlpPanelGroupTag.TabIndex = 0;
            // 
            // tabDeviceTag
            // 
            tabDeviceTag.Controls.Add(tabTags);
            tabDeviceTag.Controls.Add(tabMonitoring);
            tabDeviceTag.Controls.Add(tabLog);
            tabDeviceTag.Dock = DockStyle.Fill;
            tabDeviceTag.Location = new Point(4, 51);
            tabDeviceTag.Margin = new Padding(4, 3, 4, 3);
            tabDeviceTag.Name = "tabDeviceTag";
            tabDeviceTag.SelectedIndex = 0;
            tabDeviceTag.Size = new Size(892, 646);
            tabDeviceTag.TabIndex = 25;
            // 
            // tabTags
            // 
            tabTags.Controls.Add(lstTags);
            tabTags.Location = new Point(4, 24);
            tabTags.Margin = new Padding(4, 3, 4, 3);
            tabTags.Name = "tabTags";
            tabTags.Size = new Size(884, 618);
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
            lstTags.Size = new Size(884, 618);
            lstTags.TabIndex = 20;
            lstTags.UseCompatibleStateImageBehavior = false;
            lstTags.View = System.Windows.Forms.View.Details;
            lstTags.KeyDown += lstTags_KeyDown;
            lstTags.MouseDoubleClick += lstTags_MouseDoubleClick;
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
            cmnuTag.Items.AddRange(new ToolStripItem[] { buildGraphToolStripMenuItem, smnuSeparator01, tolTagAdd, tolTagChange, tolTagDelete, tolTagDeleteAll, smnuSeparator02, tolTagUp, tolTagDown, tolTagSort, smnuSeparator03, tolCSV });
            cmnuTag.Name = "contextMenuDeviceEdit";
            cmnuTag.Size = new Size(181, 242);
            // 
            // tolTagAdd
            // 
            tolTagAdd.Name = "tolTagAdd";
            tolTagAdd.Size = new Size(180, 22);
            tolTagAdd.Text = "Add";
            tolTagAdd.Click += tolTagAdd_Click;
            // 
            // tolTagChange
            // 
            tolTagChange.Name = "tolTagChange";
            tolTagChange.Size = new Size(180, 22);
            tolTagChange.Text = "Change";
            tolTagChange.Click += tolTagChange_Click;
            // 
            // tolTagDelete
            // 
            tolTagDelete.Name = "tolTagDelete";
            tolTagDelete.Size = new Size(180, 22);
            tolTagDelete.Text = "Delete";
            tolTagDelete.Click += tolTagDelete_Click;
            // 
            // tolTagDeleteAll
            // 
            tolTagDeleteAll.Name = "tolTagDeleteAll";
            tolTagDeleteAll.Size = new Size(180, 22);
            tolTagDeleteAll.Text = "Delete all tags";
            tolTagDeleteAll.Click += tolTagDeleteAll_Click;
            // 
            // smnuSeparator02
            // 
            smnuSeparator02.Name = "smnuSeparator02";
            smnuSeparator02.Size = new Size(177, 6);
            // 
            // tolTagUp
            // 
            tolTagUp.Name = "tolTagUp";
            tolTagUp.Size = new Size(180, 22);
            tolTagUp.Text = "Tag up";
            tolTagUp.Click += tolTagUp_Click;
            // 
            // tolTagDown
            // 
            tolTagDown.Name = "tolTagDown";
            tolTagDown.Size = new Size(180, 22);
            tolTagDown.Text = "Tag down";
            tolTagDown.Click += tolTagDown_Click;
            // 
            // tolTagSort
            // 
            tolTagSort.DropDownItems.AddRange(new ToolStripItem[] { tolTagSortDefault, tolTagSortTagAddress, tolTagSortTagName, tolTagSortTagDescription, tolTagSortTagType });
            tolTagSort.Name = "tolTagSort";
            tolTagSort.Size = new Size(180, 22);
            tolTagSort.Text = "Sorting";
            // 
            // tolTagSortDefault
            // 
            tolTagSortDefault.Name = "tolTagSortDefault";
            tolTagSortDefault.Size = new Size(210, 22);
            tolTagSortDefault.Text = "Default sorting";
            tolTagSortDefault.Click += tolTagSortDefault_Click;
            // 
            // tolTagSortTagAddress
            // 
            tolTagSortTagAddress.Name = "tolTagSortTagAddress";
            tolTagSortTagAddress.Size = new Size(210, 22);
            tolTagSortTagAddress.Text = "Sorting by tag address";
            tolTagSortTagAddress.Click += tolTagSortTagAddress_Click;
            // 
            // tolTagSortTagName
            // 
            tolTagSortTagName.Name = "tolTagSortTagName";
            tolTagSortTagName.Size = new Size(210, 22);
            tolTagSortTagName.Text = "Sorting by tag name";
            tolTagSortTagName.Click += tolTagSortTagName_Click;
            // 
            // tolTagSortTagDescription
            // 
            tolTagSortTagDescription.Name = "tolTagSortTagDescription";
            tolTagSortTagDescription.Size = new Size(210, 22);
            tolTagSortTagDescription.Text = "Sorting by tag description";
            tolTagSortTagDescription.Click += tolTagSortTagDescription_Click;
            // 
            // tolTagSortTagType
            // 
            tolTagSortTagType.Name = "tolTagSortTagType";
            tolTagSortTagType.Size = new Size(210, 22);
            tolTagSortTagType.Text = "Sorting by tag type";
            tolTagSortTagType.Click += tolTagSortTagType_Click;
            // 
            // smnuSeparator03
            // 
            smnuSeparator03.Name = "smnuSeparator03";
            smnuSeparator03.Size = new Size(177, 6);
            // 
            // tolCSV
            // 
            tolCSV.DropDownItems.AddRange(new ToolStripItem[] { tolDataLoadAsCSV, tolDataSaveAsCSV });
            tolCSV.Name = "tolCSV";
            tolCSV.Size = new Size(180, 22);
            tolCSV.Text = "CSV";
            // 
            // tolDataLoadAsCSV
            // 
            tolDataLoadAsCSV.Name = "tolDataLoadAsCSV";
            tolDataLoadAsCSV.Size = new Size(165, 22);
            tolDataLoadAsCSV.Text = "Upload from CSV";
            tolDataLoadAsCSV.Click += tolDataLoadAsCSV_Click;
            // 
            // tolDataSaveAsCSV
            // 
            tolDataSaveAsCSV.Name = "tolDataSaveAsCSV";
            tolDataSaveAsCSV.Size = new Size(165, 22);
            tolDataSaveAsCSV.Text = "Upload to CSV";
            tolDataSaveAsCSV.Click += tolDataSaveAsCSV_Click;
            // 
            // tabMonitoring
            // 
            tabMonitoring.Controls.Add(lstMonitoring);
            tabMonitoring.Location = new Point(4, 24);
            tabMonitoring.Name = "tabMonitoring";
            tabMonitoring.Size = new Size(884, 618);
            tabMonitoring.TabIndex = 5;
            tabMonitoring.Text = "Monitoring";
            tabMonitoring.UseVisualStyleBackColor = true;
            // 
            // lstMonitoring
            // 
            lstMonitoring.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            lstMonitoring.ContextMenuStrip = cmnuMonitoring;
            lstMonitoring.Dock = DockStyle.Fill;
            lstMonitoring.FullRowSelect = true;
            lstMonitoring.GridLines = true;
            lstMonitoring.Location = new Point(0, 0);
            lstMonitoring.Margin = new Padding(4, 3, 4, 3);
            lstMonitoring.MultiSelect = false;
            lstMonitoring.Name = "lstMonitoring";
            lstMonitoring.Size = new Size(884, 618);
            lstMonitoring.TabIndex = 21;
            lstMonitoring.UseCompatibleStateImageBehavior = false;
            lstMonitoring.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Value";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Datetime";
            columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Quality";
            columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Description";
            columnHeader6.Width = 300;
            // 
            // cmnuMonitoring
            // 
            cmnuMonitoring.Items.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripSeparator4, toolStripMenuItem18, toolStripSeparator3, tolShowLog });
            cmnuMonitoring.Name = "contextMenuDeviceEdit";
            cmnuMonitoring.Size = new Size(203, 104);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(202, 22);
            toolStripMenuItem2.Text = "Reading (synchronous)";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(202, 22);
            toolStripMenuItem3.Text = "Reading (asynchronous)";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(199, 6);
            // 
            // toolStripMenuItem18
            // 
            toolStripMenuItem18.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem19, toolStripMenuItem20 });
            toolStripMenuItem18.Name = "toolStripMenuItem18";
            toolStripMenuItem18.Size = new Size(202, 22);
            toolStripMenuItem18.Text = "CSV";
            // 
            // toolStripMenuItem19
            // 
            toolStripMenuItem19.Name = "toolStripMenuItem19";
            toolStripMenuItem19.Size = new Size(165, 22);
            toolStripMenuItem19.Text = "Upload from CSV";
            // 
            // toolStripMenuItem20
            // 
            toolStripMenuItem20.Name = "toolStripMenuItem20";
            toolStripMenuItem20.Size = new Size(165, 22);
            toolStripMenuItem20.Text = "Upload to CSV";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(199, 6);
            // 
            // tolShowLog
            // 
            tolShowLog.CheckOnClick = true;
            tolShowLog.Name = "tolShowLog";
            tolShowLog.Size = new Size(202, 22);
            tolShowLog.Text = "Show Log";
            // 
            // tabLog
            // 
            tabLog.Controls.Add(rchLog);
            tabLog.Location = new Point(4, 24);
            tabLog.Name = "tabLog";
            tabLog.Size = new Size(884, 618);
            tabLog.TabIndex = 4;
            tabLog.Text = "Log";
            tabLog.UseVisualStyleBackColor = true;
            // 
            // rchLog
            // 
            rchLog.Dock = DockStyle.Fill;
            rchLog.Location = new Point(0, 0);
            rchLog.Name = "rchLog";
            rchLog.Size = new Size(884, 618);
            rchLog.TabIndex = 0;
            rchLog.Text = "";
            // 
            // pnlPanelGroupTagTop
            // 
            pnlPanelGroupTagTop.Controls.Add(btnSave);
            pnlPanelGroupTagTop.Controls.Add(ckbEnabled);
            pnlPanelGroupTagTop.Controls.Add(txtNameGroupTag);
            pnlPanelGroupTagTop.Controls.Add(lblNameGroupTag);
            pnlPanelGroupTagTop.Dock = DockStyle.Fill;
            pnlPanelGroupTagTop.Location = new Point(3, 3);
            pnlPanelGroupTagTop.Name = "pnlPanelGroupTagTop";
            pnlPanelGroupTagTop.Size = new Size(894, 42);
            pnlPanelGroupTagTop.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new Point(492, 5);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 121;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // ckbEnabled
            // 
            ckbEnabled.Location = new Point(389, 7);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(96, 24);
            ckbEnabled.TabIndex = 122;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.CheckedChanged += control_Changed;
            // 
            // txtNameGroupTag
            // 
            txtNameGroupTag.Location = new Point(52, 8);
            txtNameGroupTag.Margin = new Padding(4, 3, 4, 3);
            txtNameGroupTag.Name = "txtNameGroupTag";
            txtNameGroupTag.Size = new Size(330, 23);
            txtNameGroupTag.TabIndex = 119;
            txtNameGroupTag.TextChanged += control_Changed;
            // 
            // lblNameGroupTag
            // 
            lblNameGroupTag.AutoSize = true;
            lblNameGroupTag.Location = new Point(5, 11);
            lblNameGroupTag.Margin = new Padding(4, 0, 4, 0);
            lblNameGroupTag.Name = "lblNameGroupTag";
            lblNameGroupTag.Size = new Size(39, 15);
            lblNameGroupTag.TabIndex = 120;
            lblNameGroupTag.Text = "Name";
            // 
            // tmrTimer
            // 
            tmrTimer.Enabled = true;
            tmrTimer.Tick += tmrTimer_Tick;
            // 
            // buildGraphToolStripMenuItem
            // 
            buildGraphToolStripMenuItem.Name = "buildGraphToolStripMenuItem";
            buildGraphToolStripMenuItem.Size = new Size(180, 22);
            buildGraphToolStripMenuItem.Text = "Build graph";
            // 
            // smnuSeparator01
            // 
            smnuSeparator01.Name = "smnuSeparator01";
            smnuSeparator01.Size = new Size(177, 6);
            // 
            // uscGroupTag
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpPanelGroupTag);
            Name = "uscGroupTag";
            Size = new Size(900, 700);
            Load += uscGroupTag_Load;
            tlpPanelGroupTag.ResumeLayout(false);
            tabDeviceTag.ResumeLayout(false);
            tabTags.ResumeLayout(false);
            cmnuTag.ResumeLayout(false);
            tabMonitoring.ResumeLayout(false);
            cmnuMonitoring.ResumeLayout(false);
            tabLog.ResumeLayout(false);
            pnlPanelGroupTagTop.ResumeLayout(false);
            pnlPanelGroupTagTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPanelGroupTag;
        private Panel pnlPanelGroupTagTop;
        private System.Windows.Forms.Timer tmrTimer;
        private ContextMenuStrip cmnuMonitoring;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem tolShowLog;
        private TabControl tabDeviceTag;
        private TabPage tabTags;
        private ListView lstTags;
        private ColumnHeader clmTagName;
        private ColumnHeader clmTagCode;
        private ColumnHeader clmTagDescription;
        private ColumnHeader clmTagType;
        private ColumnHeader clmTagEnabled;
        private TabPage tabMonitoring;
        private ListView lstMonitoring;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private TabPage tabLog;
        private RichTextBox rchLog;
        private Button btnSave;
        private CheckBox ckbEnabled;
        private TextBox txtNameGroupTag;
        private Label lblNameGroupTag;
        private ColumnHeader clmTagAddress;
        private ContextMenuStrip cmnuTag;
        private ToolStripMenuItem tolRefresh;
        private ToolStripSeparator tolSeparator1;
        private ToolStripMenuItem tolTagAdd;
        private ToolStripMenuItem tolTagChange;
        private ToolStripMenuItem tolTagDelete;
        private ToolStripMenuItem tolTagDeleteAll;
        private ToolStripSeparator smnuSeparator02;
        private ToolStripMenuItem tolTagUp;
        private ToolStripMenuItem tolTagDown;
        private ToolStripMenuItem tolTagSort;
        private ToolStripMenuItem tolTagSortDefault;
        private ToolStripMenuItem tolTagSortTagAddress;
        private ToolStripMenuItem tolTagSortTagName;
        private ToolStripMenuItem tolTagSortTagDescription;
        private ToolStripMenuItem tolTagSortTagType;
        private ToolStripSeparator smnuSeparator03;
        private ToolStripMenuItem tolCSV;
        private ToolStripMenuItem tolDataLoadAsCSV;
        private ToolStripMenuItem tolDataSaveAsCSV;
        private ColumnHeader clmTagCommand;
        private ToolStripMenuItem buildGraphToolStripMenuItem;
        private ToolStripSeparator smnuSeparator01;
    }
}
