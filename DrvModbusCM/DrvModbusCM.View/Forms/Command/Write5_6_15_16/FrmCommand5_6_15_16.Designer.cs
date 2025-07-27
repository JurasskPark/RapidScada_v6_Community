
using BrightIdeasSoftware;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    partial class FrmCommand5_6_15_16
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
            ckbEnabled = new CheckBox();
            gpbGroup = new GroupBox();
            txtCode = new TextBox();
            lblCode = new Label();
            lblName = new Label();
            txtName = new TextBox();
            btnSave = new Button();
            gpbOptions = new GroupBox();
            txtRegistersWriteData = new TextBox();
            lblRegistersWriteData = new Label();
            olvRegistersWrite = new ObjectListView();
            olvColumnNumber = new OLVColumn();
            olvColumnRegister = new OLVColumn();
            olvColumnDescription = new OLVColumn();
            olvColumnFormatData = new OLVColumn();
            olvColumnValue = new OLVColumn();
            cmbFunctionCode = new ComboBox();
            lblRegisterCount = new Label();
            nudRegisterCount = new NumericUpDown();
            lblRegisterStartAddress = new Label();
            nudRegisterStartAddress = new NumericUpDown();
            gpbGroup.SuspendLayout();
            gpbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)olvRegistersWrite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddress).BeginInit();
            SuspendLayout();
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(329, 35);
            ckbEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(68, 19);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.UseVisualStyleBackColor = true;
            // 
            // gpbGroup
            // 
            gpbGroup.Controls.Add(txtCode);
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblCode);
            gpbGroup.Controls.Add(lblName);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(14, 14);
            gpbGroup.Margin = new Padding(4, 3, 4, 3);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(4, 3, 4, 3);
            gpbGroup.Size = new Size(439, 109);
            gpbGroup.TabIndex = 18;
            gpbGroup.TabStop = false;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(10, 77);
            txtCode.Margin = new Padding(6, 5, 6, 5);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(314, 23);
            txtCode.TabIndex = 24;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(10, 57);
            lblCode.Margin = new Padding(6, 0, 6, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(93, 15);
            lblCode.TabIndex = 25;
            lblCode.Text = "Command code";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(7, 13);
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
            // btnSave
            // 
            btnSave.Location = new Point(461, 21);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // gpbOptions
            // 
            gpbOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbOptions.Controls.Add(txtRegistersWriteData);
            gpbOptions.Controls.Add(lblRegistersWriteData);
            gpbOptions.Controls.Add(olvRegistersWrite);
            gpbOptions.Controls.Add(cmbFunctionCode);
            gpbOptions.Controls.Add(lblRegisterCount);
            gpbOptions.Controls.Add(nudRegisterCount);
            gpbOptions.Controls.Add(lblRegisterStartAddress);
            gpbOptions.Controls.Add(nudRegisterStartAddress);
            gpbOptions.Location = new Point(13, 129);
            gpbOptions.Margin = new Padding(4, 3, 4, 3);
            gpbOptions.Name = "gpbOptions";
            gpbOptions.Padding = new Padding(4, 3, 4, 3);
            gpbOptions.Size = new Size(816, 413);
            gpbOptions.TabIndex = 21;
            gpbOptions.TabStop = false;
            gpbOptions.Text = "Options";
            // 
            // txtRegistersWriteData
            // 
            txtRegistersWriteData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtRegistersWriteData.Location = new Point(7, 131);
            txtRegistersWriteData.Margin = new Padding(6, 5, 6, 5);
            txtRegistersWriteData.Multiline = true;
            txtRegistersWriteData.Name = "txtRegistersWriteData";
            txtRegistersWriteData.Size = new Size(799, 53);
            txtRegistersWriteData.TabIndex = 27;
            // 
            // lblRegistersWriteData
            // 
            lblRegistersWriteData.AutoSize = true;
            lblRegistersWriteData.Location = new Point(11, 111);
            lblRegistersWriteData.Margin = new Padding(4, 0, 4, 0);
            lblRegistersWriteData.Name = "lblRegistersWriteData";
            lblRegistersWriteData.Size = new Size(112, 15);
            lblRegistersWriteData.TabIndex = 26;
            lblRegistersWriteData.Text = "Registers Write Data";
            // 
            // olvRegistersWrite
            // 
            olvRegistersWrite.AllColumns.Add(olvColumnNumber);
            olvRegistersWrite.AllColumns.Add(olvColumnRegister);
            olvRegistersWrite.AllColumns.Add(olvColumnDescription);
            olvRegistersWrite.AllColumns.Add(olvColumnFormatData);
            olvRegistersWrite.AllColumns.Add(olvColumnValue);
            olvRegistersWrite.AllowColumnReorder = true;
            olvRegistersWrite.AllowDrop = true;
            olvRegistersWrite.AlternateRowBackColor = Color.FromArgb(137, 180, 213);
            olvRegistersWrite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            olvRegistersWrite.CellEditUseWholeCell = false;
            olvRegistersWrite.CheckedAspectName = "";
            olvRegistersWrite.Columns.AddRange(new ColumnHeader[] { olvColumnNumber, olvColumnRegister, olvColumnDescription, olvColumnFormatData, olvColumnValue });
            olvRegistersWrite.EmptyListMsg = "";
            olvRegistersWrite.ForeColor = SystemColors.WindowText;
            olvRegistersWrite.FullRowSelect = true;
            olvRegistersWrite.GridLines = true;
            olvRegistersWrite.GroupWithItemCountFormat = "{0} ({1} people)";
            olvRegistersWrite.GroupWithItemCountSingularFormat = "{0} ({1} person)";
            olvRegistersWrite.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            olvRegistersWrite.Location = new Point(8, 192);
            olvRegistersWrite.Margin = new Padding(7, 3, 4, 3);
            olvRegistersWrite.Name = "olvRegistersWrite";
            olvRegistersWrite.OverlayText.Alignment = ContentAlignment.BottomLeft;
            olvRegistersWrite.OverlayText.Text = "";
            olvRegistersWrite.SelectColumnsOnRightClickBehaviour = ObjectListView.ColumnSelectBehaviour.Submenu;
            olvRegistersWrite.SelectedBackColor = Color.FromArgb(70, 138, 189);
            olvRegistersWrite.SelectedColumnTint = Color.FromArgb(254, 70, 138, 189);
            olvRegistersWrite.SelectedForeColor = Color.White;
            olvRegistersWrite.ShowCommandMenuOnRightClick = true;
            olvRegistersWrite.ShowGroups = false;
            olvRegistersWrite.ShowHeaderInAllViews = false;
            olvRegistersWrite.ShowImagesOnSubItems = true;
            olvRegistersWrite.ShowItemToolTips = true;
            olvRegistersWrite.Size = new Size(798, 215);
            olvRegistersWrite.TabIndex = 25;
            olvRegistersWrite.UnfocusedSelectedBackColor = Color.FromArgb(70, 138, 189);
            olvRegistersWrite.UnfocusedSelectedForeColor = Color.FromArgb(70, 138, 189);
            olvRegistersWrite.UseAlternatingBackColors = true;
            olvRegistersWrite.UseCompatibleStateImageBehavior = false;
            olvRegistersWrite.UseFiltering = true;
            olvRegistersWrite.UseHotItem = true;
            olvRegistersWrite.View = System.Windows.Forms.View.Details;
            // 
            // olvColumnNumber
            // 
            olvColumnNumber.AspectName = "RegAddr";
            olvColumnNumber.MinimumWidth = 80;
            olvColumnNumber.Text = "Number";
            olvColumnNumber.Width = 80;
            // 
            // olvColumnRegister
            // 
            olvColumnRegister.AspectName = "RegName";
            olvColumnRegister.MinimumWidth = 100;
            olvColumnRegister.Text = "Register";
            olvColumnRegister.Width = 100;
            // 
            // olvColumnDescription
            // 
            olvColumnDescription.AspectName = "RegDescription";
            olvColumnDescription.MinimumWidth = 100;
            olvColumnDescription.Text = "Description";
            olvColumnDescription.Width = 250;
            // 
            // olvColumnFormatData
            // 
            olvColumnFormatData.AspectName = "RegFormat";
            olvColumnFormatData.MinimumWidth = 100;
            olvColumnFormatData.Text = "FormatData";
            olvColumnFormatData.Width = 150;
            // 
            // olvColumnValue
            // 
            olvColumnValue.AspectName = "RegValue";
            olvColumnValue.MinimumWidth = 100;
            olvColumnValue.Text = "Value";
            olvColumnValue.Width = 200;
            // 
            // cmbFunctionCode
            // 
            cmbFunctionCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionCode.DropDownWidth = 350;
            cmbFunctionCode.FlatStyle = FlatStyle.Flat;
            cmbFunctionCode.FormattingEnabled = true;
            cmbFunctionCode.Items.AddRange(new object[] { "(05) — Запись одного флага (Force Single Coil)", "(06) — Запись регистр хранения (Preset Single Register)", "(15) — Запись регистров флагов (Write Multiple Coils)", "(16) — Запись регистров хранения (Write Multiple Holding Registers)" });
            cmbFunctionCode.Location = new Point(7, 22);
            cmbFunctionCode.Margin = new Padding(4, 3, 4, 3);
            cmbFunctionCode.Name = "cmbFunctionCode";
            cmbFunctionCode.Size = new Size(424, 23);
            cmbFunctionCode.TabIndex = 22;
            cmbFunctionCode.SelectedIndexChanged += cmbFunctionCode_SelectedIndexChanged;
            // 
            // lblRegisterCount
            // 
            lblRegisterCount.AutoSize = true;
            lblRegisterCount.Location = new Point(124, 88);
            lblRegisterCount.Margin = new Padding(4, 0, 4, 0);
            lblRegisterCount.Name = "lblRegisterCount";
            lblRegisterCount.Size = new Size(112, 15);
            lblRegisterCount.TabIndex = 6;
            lblRegisterCount.Text = "Number of registers";
            // 
            // nudRegisterCount
            // 
            nudRegisterCount.Location = new Point(7, 85);
            nudRegisterCount.Margin = new Padding(4, 3, 4, 3);
            nudRegisterCount.Maximum = new decimal(new int[] { 127, 0, 0, 0 });
            nudRegisterCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudRegisterCount.Name = "nudRegisterCount";
            nudRegisterCount.Size = new Size(110, 23);
            nudRegisterCount.TabIndex = 3;
            nudRegisterCount.TextAlign = HorizontalAlignment.Center;
            nudRegisterCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudRegisterCount.ValueChanged += nudRegisterCount_ValueChanged;
            // 
            // lblRegisterStartAddress
            // 
            lblRegisterStartAddress.AutoSize = true;
            lblRegisterStartAddress.Location = new Point(124, 58);
            lblRegisterStartAddress.Margin = new Padding(4, 0, 4, 0);
            lblRegisterStartAddress.Name = "lblRegisterStartAddress";
            lblRegisterStartAddress.Size = new Size(167, 15);
            lblRegisterStartAddress.TabIndex = 3;
            lblRegisterStartAddress.Text = "Starting address of the register";
            // 
            // nudRegisterStartAddress
            // 
            nudRegisterStartAddress.Location = new Point(7, 55);
            nudRegisterStartAddress.Margin = new Padding(4, 3, 4, 3);
            nudRegisterStartAddress.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRegisterStartAddress.Name = "nudRegisterStartAddress";
            nudRegisterStartAddress.Size = new Size(110, 23);
            nudRegisterStartAddress.TabIndex = 2;
            nudRegisterStartAddress.TextAlign = HorizontalAlignment.Center;
            nudRegisterStartAddress.ValueChanged += nudRegisterStartAddress_ValueChanged;
            // 
            // FrmCommand5_6_15_16
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 530);
            ControlBox = false;
            Controls.Add(gpbOptions);
            Controls.Add(gpbGroup);
            Controls.Add(btnSave);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCommand5_6_15_16";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Command";
            Load += FrmCommand_Load;
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            gpbOptions.ResumeLayout(false);
            gpbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)olvRegistersWrite).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddress).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.CheckBox ckbEnabled;
        private System.Windows.Forms.Button btn_ModbusCommandCancel;
        private System.Windows.Forms.GroupBox gpbGroup;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btn_ModbusCommandAdd;
        private System.Windows.Forms.GroupBox gpbOptions;
        private System.Windows.Forms.Label lblRegisterCount;
        private System.Windows.Forms.NumericUpDown nudRegisterCount;
        private System.Windows.Forms.Label lblRegisterStartAddress;
        private System.Windows.Forms.NumericUpDown nudRegisterStartAddress;
        private System.Windows.Forms.ComboBox cmbFunctionCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private BrightIdeasSoftware.ObjectListView olvRegistersWrite;
        private BrightIdeasSoftware.OLVColumn olvColumnNumber;
        private BrightIdeasSoftware.OLVColumn olvColumnRegister;
        private BrightIdeasSoftware.OLVColumn olvColumnFormatData;
        private BrightIdeasSoftware.OLVColumn olvColumnDescription;
        private BrightIdeasSoftware.OLVColumn olvColumnValue;
        private Label lblRegistersWriteData;
        private TextBox txtRegistersWriteData;
    }
}