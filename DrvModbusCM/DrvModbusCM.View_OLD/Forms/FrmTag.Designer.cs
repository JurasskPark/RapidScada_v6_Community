namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class FrmTag
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
            tabTag = new TabControl();
            tabGeneral = new TabPage();
            btnSave = new Button();
            btnCancel = new Button();
            gpbTagProperty = new GroupBox();
            lblTagCommand = new Label();
            txtTagSorting = new TextBox();
            cmbTagCommand = new ComboBox();
            lblTagSorting = new Label();
            txtTagCode = new TextBox();
            lblTagCode = new Label();
            lblTagEnabled = new Label();
            ckbTagEnabled = new CheckBox();
            txtTagID = new TextBox();
            lblTagID = new Label();
            lblTagType = new Label();
            cmbTagType = new ComboBox();
            lblTagDescription = new Label();
            txtTagDescription = new TextBox();
            txtTagAddress = new TextBox();
            lblTagAddress = new Label();
            txtTagname = new TextBox();
            lblTagName = new Label();
            tabScaling = new TabPage();
            gpbScaled = new GroupBox();
            lblScaled = new Label();
            cmbScaled = new ComboBox();
            gpbLineScaled = new GroupBox();
            lblLineScaledResult = new Label();
            lblResult = new Label();
            lblScaledLowValue_2 = new Label();
            lblPlus = new Label();
            lblBracket_5 = new Label();
            lblBracket_4 = new Label();
            lblRowLowValue_2 = new Label();
            lblLineScaledMinus_3 = new Label();
            lblLineScaledValue = new Label();
            lblBracket_3 = new Label();
            lblLineScalEdincrease = new Label();
            lblBracket_1 = new Label();
            lblBracket_2 = new Label();
            lblLineScaledMinus_4 = new Label();
            lblLineScaledDivision_1 = new Label();
            lblLineScaledMinus_1 = new Label();
            lblRowLowValue = new Label();
            lblRowHighValue = new Label();
            lblScaledLowValue = new Label();
            lblScaledHighValue = new Label();
            btnCalcLineScaled = new Button();
            txtValue = new TextBox();
            lblLineScaledVal = new Label();
            lblLineScaledHigh = new Label();
            txtLineScaledHigh = new TextBox();
            txtLineScaledLow = new TextBox();
            lblLineScaledLow = new Label();
            lblLineScaledRowHigh = new Label();
            txtLineScaledRowHigh = new TextBox();
            txtLineScaledRowLow = new TextBox();
            lblLineScaledRowLow = new Label();
            txtTagCoefficient = new TextBox();
            lblCoefficient = new Label();
            tabTag.SuspendLayout();
            tabGeneral.SuspendLayout();
            gpbTagProperty.SuspendLayout();
            tabScaling.SuspendLayout();
            gpbScaled.SuspendLayout();
            gpbLineScaled.SuspendLayout();
            SuspendLayout();
            // 
            // tabTag
            // 
            tabTag.Controls.Add(tabGeneral);
            tabTag.Controls.Add(tabScaling);
            tabTag.Dock = DockStyle.Fill;
            tabTag.Location = new Point(0, 0);
            tabTag.Margin = new Padding(4, 3, 4, 3);
            tabTag.Name = "tabTag";
            tabTag.SelectedIndex = 0;
            tabTag.Size = new Size(653, 369);
            tabTag.TabIndex = 2;
            // 
            // tabGeneral
            // 
            tabGeneral.Controls.Add(btnSave);
            tabGeneral.Controls.Add(btnCancel);
            tabGeneral.Controls.Add(gpbTagProperty);
            tabGeneral.Location = new Point(4, 24);
            tabGeneral.Margin = new Padding(4, 3, 4, 3);
            tabGeneral.Name = "tabGeneral";
            tabGeneral.Padding = new Padding(4, 3, 4, 3);
            tabGeneral.Size = new Size(645, 341);
            tabGeneral.TabIndex = 0;
            tabGeneral.Text = "General";
            tabGeneral.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(211, 305);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 66;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(326, 305);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(107, 27);
            btnCancel.TabIndex = 55;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // gpbTagProperty
            // 
            gpbTagProperty.Controls.Add(lblTagCommand);
            gpbTagProperty.Controls.Add(txtTagSorting);
            gpbTagProperty.Controls.Add(cmbTagCommand);
            gpbTagProperty.Controls.Add(lblTagSorting);
            gpbTagProperty.Controls.Add(txtTagCode);
            gpbTagProperty.Controls.Add(lblTagCode);
            gpbTagProperty.Controls.Add(lblTagEnabled);
            gpbTagProperty.Controls.Add(ckbTagEnabled);
            gpbTagProperty.Controls.Add(txtTagID);
            gpbTagProperty.Controls.Add(lblTagID);
            gpbTagProperty.Controls.Add(lblTagType);
            gpbTagProperty.Controls.Add(cmbTagType);
            gpbTagProperty.Controls.Add(lblTagDescription);
            gpbTagProperty.Controls.Add(txtTagDescription);
            gpbTagProperty.Controls.Add(txtTagAddress);
            gpbTagProperty.Controls.Add(lblTagAddress);
            gpbTagProperty.Controls.Add(txtTagname);
            gpbTagProperty.Controls.Add(lblTagName);
            gpbTagProperty.Location = new Point(7, 7);
            gpbTagProperty.Margin = new Padding(4, 3, 4, 3);
            gpbTagProperty.Name = "gpbTagProperty";
            gpbTagProperty.Padding = new Padding(4, 3, 4, 3);
            gpbTagProperty.Size = new Size(629, 292);
            gpbTagProperty.TabIndex = 0;
            gpbTagProperty.TabStop = false;
            gpbTagProperty.Text = "Tag Properties";
            // 
            // lblTagCommand
            // 
            lblTagCommand.AutoSize = true;
            lblTagCommand.Location = new Point(12, 54);
            lblTagCommand.Margin = new Padding(4, 0, 4, 0);
            lblTagCommand.Name = "lblTagCommand";
            lblTagCommand.Size = new Size(64, 15);
            lblTagCommand.TabIndex = 57;
            lblTagCommand.Text = "Command";
            // 
            // txtTagSorting
            // 
            txtTagSorting.Location = new Point(124, 256);
            txtTagSorting.Name = "txtTagSorting";
            txtTagSorting.Size = new Size(269, 23);
            txtTagSorting.TabIndex = 58;
            // 
            // cmbTagCommand
            // 
            cmbTagCommand.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTagCommand.FormattingEnabled = true;
            cmbTagCommand.Location = new Point(124, 51);
            cmbTagCommand.Margin = new Padding(4, 3, 4, 3);
            cmbTagCommand.Name = "cmbTagCommand";
            cmbTagCommand.Size = new Size(269, 23);
            cmbTagCommand.TabIndex = 58;
            // 
            // lblTagSorting
            // 
            lblTagSorting.AutoSize = true;
            lblTagSorting.Location = new Point(14, 259);
            lblTagSorting.Margin = new Padding(4, 0, 4, 0);
            lblTagSorting.Name = "lblTagSorting";
            lblTagSorting.Size = new Size(45, 15);
            lblTagSorting.TabIndex = 57;
            lblTagSorting.Text = "Sorting";
            // 
            // txtTagCode
            // 
            txtTagCode.Location = new Point(124, 136);
            txtTagCode.Margin = new Padding(4, 3, 4, 3);
            txtTagCode.Name = "txtTagCode";
            txtTagCode.Size = new Size(269, 23);
            txtTagCode.TabIndex = 58;
            // 
            // lblTagCode
            // 
            lblTagCode.AutoSize = true;
            lblTagCode.Location = new Point(12, 140);
            lblTagCode.Margin = new Padding(4, 0, 4, 0);
            lblTagCode.Name = "lblTagCode";
            lblTagCode.Size = new Size(35, 15);
            lblTagCode.TabIndex = 57;
            lblTagCode.Text = "Code";
            // 
            // lblTagEnabled
            // 
            lblTagEnabled.AutoSize = true;
            lblTagEnabled.Location = new Point(12, 85);
            lblTagEnabled.Margin = new Padding(4, 0, 4, 0);
            lblTagEnabled.Name = "lblTagEnabled";
            lblTagEnabled.Size = new Size(40, 15);
            lblTagEnabled.TabIndex = 10;
            lblTagEnabled.Text = "Active";
            // 
            // ckbTagEnabled
            // 
            ckbTagEnabled.AutoSize = true;
            ckbTagEnabled.Location = new Point(126, 85);
            ckbTagEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbTagEnabled.Name = "ckbTagEnabled";
            ckbTagEnabled.RightToLeft = RightToLeft.Yes;
            ckbTagEnabled.Size = new Size(15, 14);
            ckbTagEnabled.TabIndex = 87;
            ckbTagEnabled.UseVisualStyleBackColor = true;
            // 
            // txtTagID
            // 
            txtTagID.Location = new Point(124, 22);
            txtTagID.Margin = new Padding(4, 3, 4, 3);
            txtTagID.Name = "txtTagID";
            txtTagID.ReadOnly = true;
            txtTagID.Size = new Size(269, 23);
            txtTagID.TabIndex = 10;
            // 
            // lblTagID
            // 
            lblTagID.AutoSize = true;
            lblTagID.Location = new Point(12, 26);
            lblTagID.Margin = new Padding(4, 0, 4, 0);
            lblTagID.Name = "lblTagID";
            lblTagID.Size = new Size(18, 15);
            lblTagID.TabIndex = 9;
            lblTagID.Text = "ID";
            // 
            // lblTagType
            // 
            lblTagType.AutoSize = true;
            lblTagType.Location = new Point(12, 230);
            lblTagType.Margin = new Padding(4, 0, 4, 0);
            lblTagType.Name = "lblTagType";
            lblTagType.Size = new Size(57, 15);
            lblTagType.TabIndex = 6;
            lblTagType.Text = "Data type";
            // 
            // cmbTagType
            // 
            cmbTagType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTagType.FormattingEnabled = true;
            cmbTagType.Location = new Point(124, 227);
            cmbTagType.Margin = new Padding(4, 3, 4, 3);
            cmbTagType.Name = "cmbTagType";
            cmbTagType.Size = new Size(269, 23);
            cmbTagType.TabIndex = 6;
            // 
            // lblTagDescription
            // 
            lblTagDescription.AutoSize = true;
            lblTagDescription.Location = new Point(12, 169);
            lblTagDescription.Margin = new Padding(4, 0, 4, 0);
            lblTagDescription.Name = "lblTagDescription";
            lblTagDescription.Size = new Size(67, 15);
            lblTagDescription.TabIndex = 5;
            lblTagDescription.Text = "Description";
            // 
            // txtTagDescription
            // 
            txtTagDescription.Location = new Point(124, 165);
            txtTagDescription.Margin = new Padding(4, 3, 4, 3);
            txtTagDescription.Name = "txtTagDescription";
            txtTagDescription.Size = new Size(269, 23);
            txtTagDescription.TabIndex = 4;
            // 
            // txtTagAddress
            // 
            txtTagAddress.Location = new Point(124, 197);
            txtTagAddress.Margin = new Padding(4, 3, 4, 3);
            txtTagAddress.Name = "txtTagAddress";
            txtTagAddress.Size = new Size(269, 23);
            txtTagAddress.TabIndex = 3;
            // 
            // lblTagAddress
            // 
            lblTagAddress.AutoSize = true;
            lblTagAddress.Location = new Point(12, 200);
            lblTagAddress.Margin = new Padding(4, 0, 4, 0);
            lblTagAddress.Name = "lblTagAddress";
            lblTagAddress.Size = new Size(49, 15);
            lblTagAddress.TabIndex = 2;
            lblTagAddress.Text = "Address";
            // 
            // txtTagname
            // 
            txtTagname.Location = new Point(124, 107);
            txtTagname.Margin = new Padding(4, 3, 4, 3);
            txtTagname.Name = "txtTagname";
            txtTagname.Size = new Size(269, 23);
            txtTagname.TabIndex = 1;
            // 
            // lblTagName
            // 
            lblTagName.AutoSize = true;
            lblTagName.Location = new Point(12, 111);
            lblTagName.Margin = new Padding(4, 0, 4, 0);
            lblTagName.Name = "lblTagName";
            lblTagName.Size = new Size(39, 15);
            lblTagName.TabIndex = 0;
            lblTagName.Text = "Name";
            // 
            // tabScaling
            // 
            tabScaling.Controls.Add(gpbScaled);
            tabScaling.Location = new Point(4, 24);
            tabScaling.Margin = new Padding(4, 3, 4, 3);
            tabScaling.Name = "tabScaling";
            tabScaling.Padding = new Padding(4, 3, 4, 3);
            tabScaling.Size = new Size(645, 341);
            tabScaling.TabIndex = 1;
            tabScaling.Text = "Scaling";
            tabScaling.UseVisualStyleBackColor = true;
            // 
            // gpbScaled
            // 
            gpbScaled.Controls.Add(lblScaled);
            gpbScaled.Controls.Add(cmbScaled);
            gpbScaled.Controls.Add(gpbLineScaled);
            gpbScaled.Controls.Add(txtTagCoefficient);
            gpbScaled.Controls.Add(lblCoefficient);
            gpbScaled.Location = new Point(7, 7);
            gpbScaled.Margin = new Padding(4, 3, 4, 3);
            gpbScaled.Name = "gpbScaled";
            gpbScaled.Padding = new Padding(4, 3, 4, 3);
            gpbScaled.Size = new Size(628, 246);
            gpbScaled.TabIndex = 1;
            gpbScaled.TabStop = false;
            gpbScaled.Text = "Tag Scaling";
            // 
            // lblScaled
            // 
            lblScaled.AutoSize = true;
            lblScaled.Location = new Point(12, 47);
            lblScaled.Margin = new Padding(4, 0, 4, 0);
            lblScaled.Name = "lblScaled";
            lblScaled.Size = new Size(45, 15);
            lblScaled.TabIndex = 4;
            lblScaled.Text = "Scaling";
            // 
            // cmbScaled
            // 
            cmbScaled.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbScaled.FormattingEnabled = true;
            cmbScaled.Items.AddRange(new object[] { "No", "Linear" });
            cmbScaled.Location = new Point(132, 44);
            cmbScaled.Margin = new Padding(4, 3, 4, 3);
            cmbScaled.Name = "cmbScaled";
            cmbScaled.Size = new Size(202, 23);
            cmbScaled.TabIndex = 3;
            cmbScaled.SelectedIndexChanged += cmbScaled_SelectedIndexChanged;
            // 
            // gpbLineScaled
            // 
            gpbLineScaled.Controls.Add(lblLineScaledResult);
            gpbLineScaled.Controls.Add(lblResult);
            gpbLineScaled.Controls.Add(lblScaledLowValue_2);
            gpbLineScaled.Controls.Add(lblPlus);
            gpbLineScaled.Controls.Add(lblBracket_5);
            gpbLineScaled.Controls.Add(lblBracket_4);
            gpbLineScaled.Controls.Add(lblRowLowValue_2);
            gpbLineScaled.Controls.Add(lblLineScaledMinus_3);
            gpbLineScaled.Controls.Add(lblLineScaledValue);
            gpbLineScaled.Controls.Add(lblBracket_3);
            gpbLineScaled.Controls.Add(lblLineScalEdincrease);
            gpbLineScaled.Controls.Add(lblBracket_1);
            gpbLineScaled.Controls.Add(lblBracket_2);
            gpbLineScaled.Controls.Add(lblLineScaledMinus_4);
            gpbLineScaled.Controls.Add(lblLineScaledDivision_1);
            gpbLineScaled.Controls.Add(lblLineScaledMinus_1);
            gpbLineScaled.Controls.Add(lblRowLowValue);
            gpbLineScaled.Controls.Add(lblRowHighValue);
            gpbLineScaled.Controls.Add(lblScaledLowValue);
            gpbLineScaled.Controls.Add(lblScaledHighValue);
            gpbLineScaled.Controls.Add(btnCalcLineScaled);
            gpbLineScaled.Controls.Add(txtValue);
            gpbLineScaled.Controls.Add(lblLineScaledVal);
            gpbLineScaled.Controls.Add(lblLineScaledHigh);
            gpbLineScaled.Controls.Add(txtLineScaledHigh);
            gpbLineScaled.Controls.Add(txtLineScaledLow);
            gpbLineScaled.Controls.Add(lblLineScaledLow);
            gpbLineScaled.Controls.Add(lblLineScaledRowHigh);
            gpbLineScaled.Controls.Add(txtLineScaledRowHigh);
            gpbLineScaled.Controls.Add(txtLineScaledRowLow);
            gpbLineScaled.Controls.Add(lblLineScaledRowLow);
            gpbLineScaled.Location = new Point(10, 75);
            gpbLineScaled.Margin = new Padding(4, 3, 4, 3);
            gpbLineScaled.Name = "gpbLineScaled";
            gpbLineScaled.Padding = new Padding(4, 3, 4, 3);
            gpbLineScaled.Size = new Size(610, 164);
            gpbLineScaled.TabIndex = 2;
            gpbLineScaled.TabStop = false;
            gpbLineScaled.Text = "Linear scaling";
            // 
            // lblLineScaledResult
            // 
            lblLineScaledResult.AutoSize = true;
            lblLineScaledResult.Location = new Point(541, 108);
            lblLineScaledResult.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledResult.Name = "lblLineScaledResult";
            lblLineScaledResult.Size = new Size(0, 15);
            lblLineScaledResult.TabIndex = 38;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(522, 108);
            lblResult.Margin = new Padding(4, 0, 4, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(15, 15);
            lblResult.TabIndex = 37;
            lblResult.Text = "=";
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblScaledLowValue_2
            // 
            lblScaledLowValue_2.AutoSize = true;
            lblScaledLowValue_2.Location = new Point(446, 108);
            lblScaledLowValue_2.Margin = new Padding(4, 0, 4, 0);
            lblScaledLowValue_2.Name = "lblScaledLowValue_2";
            lblScaledLowValue_2.Size = new Size(63, 15);
            lblScaledLowValue_2.TabIndex = 36;
            lblScaledLowValue_2.Text = "ScaledLow";
            // 
            // lblPlus
            // 
            lblPlus.AutoSize = true;
            lblPlus.Location = new Point(427, 108);
            lblPlus.Margin = new Padding(4, 0, 4, 0);
            lblPlus.Name = "lblPlus";
            lblPlus.Size = new Size(15, 15);
            lblPlus.TabIndex = 35;
            lblPlus.Text = "+";
            lblPlus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBracket_5
            // 
            lblBracket_5.AutoSize = true;
            lblBracket_5.Location = new Point(409, 108);
            lblBracket_5.Margin = new Padding(4, 0, 4, 0);
            lblBracket_5.Name = "lblBracket_5";
            lblBracket_5.Size = new Size(11, 15);
            lblBracket_5.TabIndex = 34;
            lblBracket_5.Text = ")";
            // 
            // lblBracket_4
            // 
            lblBracket_4.AutoSize = true;
            lblBracket_4.Location = new Point(390, 108);
            lblBracket_4.Margin = new Padding(4, 0, 4, 0);
            lblBracket_4.Name = "lblBracket_4";
            lblBracket_4.Size = new Size(11, 15);
            lblBracket_4.TabIndex = 33;
            lblBracket_4.Text = ")";
            // 
            // lblRowLowValue_2
            // 
            lblRowLowValue_2.AutoSize = true;
            lblRowLowValue_2.Location = new Point(326, 108);
            lblRowLowValue_2.Margin = new Padding(4, 0, 4, 0);
            lblRowLowValue_2.Name = "lblRowLowValue_2";
            lblRowLowValue_2.Size = new Size(52, 15);
            lblRowLowValue_2.TabIndex = 32;
            lblRowLowValue_2.Text = "RowLow";
            // 
            // lblLineScaledMinus_3
            // 
            lblLineScaledMinus_3.AutoSize = true;
            lblLineScaledMinus_3.Location = new Point(307, 108);
            lblLineScaledMinus_3.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledMinus_3.Name = "lblLineScaledMinus_3";
            lblLineScaledMinus_3.Size = new Size(12, 15);
            lblLineScaledMinus_3.TabIndex = 31;
            lblLineScaledMinus_3.Text = "-";
            lblLineScaledMinus_3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLineScaledValue
            // 
            lblLineScaledValue.AutoSize = true;
            lblLineScaledValue.Location = new Point(260, 108);
            lblLineScaledValue.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledValue.Name = "lblLineScaledValue";
            lblLineScaledValue.Size = new Size(35, 15);
            lblLineScaledValue.TabIndex = 30;
            lblLineScaledValue.Text = "Value";
            // 
            // lblBracket_3
            // 
            lblBracket_3.AutoSize = true;
            lblBracket_3.Location = new Point(242, 108);
            lblBracket_3.Margin = new Padding(4, 0, 4, 0);
            lblBracket_3.Name = "lblBracket_3";
            lblBracket_3.Size = new Size(11, 15);
            lblBracket_3.TabIndex = 29;
            lblBracket_3.Text = "(";
            // 
            // lblLineScalEdincrease
            // 
            lblLineScalEdincrease.AutoSize = true;
            lblLineScalEdincrease.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblLineScalEdincrease.Location = new Point(222, 108);
            lblLineScalEdincrease.Margin = new Padding(4, 0, 4, 0);
            lblLineScalEdincrease.Name = "lblLineScalEdincrease";
            lblLineScalEdincrease.Size = new Size(15, 20);
            lblLineScalEdincrease.TabIndex = 28;
            lblLineScalEdincrease.Text = "*";
            lblLineScalEdincrease.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBracket_1
            // 
            lblBracket_1.AutoSize = true;
            lblBracket_1.Location = new Point(21, 108);
            lblBracket_1.Margin = new Padding(4, 0, 4, 0);
            lblBracket_1.Name = "lblBracket_1";
            lblBracket_1.Size = new Size(11, 15);
            lblBracket_1.TabIndex = 27;
            lblBracket_1.Text = "(";
            // 
            // lblBracket_2
            // 
            lblBracket_2.AutoSize = true;
            lblBracket_2.Location = new Point(33, 108);
            lblBracket_2.Margin = new Padding(4, 0, 4, 0);
            lblBracket_2.Name = "lblBracket_2";
            lblBracket_2.Size = new Size(11, 15);
            lblBracket_2.TabIndex = 26;
            lblBracket_2.Text = "(";
            // 
            // lblLineScaledMinus_4
            // 
            lblLineScaledMinus_4.AutoSize = true;
            lblLineScaledMinus_4.Location = new Point(125, 127);
            lblLineScaledMinus_4.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledMinus_4.Name = "lblLineScaledMinus_4";
            lblLineScaledMinus_4.Size = new Size(12, 15);
            lblLineScaledMinus_4.TabIndex = 25;
            lblLineScaledMinus_4.Text = "-";
            // 
            // lblLineScaledDivision_1
            // 
            lblLineScaledDivision_1.AutoSize = true;
            lblLineScaledDivision_1.Location = new Point(46, 103);
            lblLineScaledDivision_1.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledDivision_1.Name = "lblLineScaledDivision_1";
            lblLineScaledDivision_1.Size = new Size(122, 15);
            lblLineScaledDivision_1.TabIndex = 24;
            lblLineScaledDivision_1.Text = "_______________________";
            // 
            // lblLineScaledMinus_1
            // 
            lblLineScaledMinus_1.AutoSize = true;
            lblLineScaledMinus_1.Location = new Point(125, 88);
            lblLineScaledMinus_1.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledMinus_1.Name = "lblLineScaledMinus_1";
            lblLineScaledMinus_1.Size = new Size(12, 15);
            lblLineScaledMinus_1.TabIndex = 23;
            lblLineScaledMinus_1.Text = "-";
            // 
            // lblRowLowValue
            // 
            lblRowLowValue.AutoSize = true;
            lblRowLowValue.Location = new Point(144, 127);
            lblRowLowValue.Margin = new Padding(4, 0, 4, 0);
            lblRowLowValue.Name = "lblRowLowValue";
            lblRowLowValue.Size = new Size(52, 15);
            lblRowLowValue.TabIndex = 22;
            lblRowLowValue.Text = "RowLow";
            // 
            // lblRowHighValue
            // 
            lblRowHighValue.AutoSize = true;
            lblRowHighValue.Location = new Point(46, 127);
            lblRowHighValue.Margin = new Padding(4, 0, 4, 0);
            lblRowHighValue.Name = "lblRowHighValue";
            lblRowHighValue.Size = new Size(56, 15);
            lblRowHighValue.TabIndex = 21;
            lblRowHighValue.Text = "RowHigh";
            // 
            // lblScaledLowValue
            // 
            lblScaledLowValue.AutoSize = true;
            lblScaledLowValue.Location = new Point(144, 88);
            lblScaledLowValue.Margin = new Padding(4, 0, 4, 0);
            lblScaledLowValue.Name = "lblScaledLowValue";
            lblScaledLowValue.Size = new Size(63, 15);
            lblScaledLowValue.TabIndex = 20;
            lblScaledLowValue.Text = "ScaledLow";
            // 
            // lblScaledHighValue
            // 
            lblScaledHighValue.AutoSize = true;
            lblScaledHighValue.Location = new Point(46, 88);
            lblScaledHighValue.Margin = new Padding(4, 0, 4, 0);
            lblScaledHighValue.Name = "lblScaledHighValue";
            lblScaledHighValue.Size = new Size(67, 15);
            lblScaledHighValue.TabIndex = 19;
            lblScaledHighValue.Text = "ScaledHigh";
            // 
            // btnCalcLineScaled
            // 
            btnCalcLineScaled.Location = new Point(388, 50);
            btnCalcLineScaled.Margin = new Padding(4, 3, 4, 3);
            btnCalcLineScaled.Name = "btnCalcLineScaled";
            btnCalcLineScaled.Size = new Size(170, 27);
            btnCalcLineScaled.TabIndex = 18;
            btnCalcLineScaled.Text = "Calculate";
            btnCalcLineScaled.UseVisualStyleBackColor = true;
            btnCalcLineScaled.Click += btnCalcLineScaled_Click;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(465, 22);
            txtValue.Margin = new Padding(4, 3, 4, 3);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(93, 23);
            txtValue.TabIndex = 17;
            // 
            // lblLineScaledVal
            // 
            lblLineScaledVal.AutoSize = true;
            lblLineScaledVal.Location = new Point(390, 25);
            lblLineScaledVal.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledVal.Name = "lblLineScaledVal";
            lblLineScaledVal.Size = new Size(35, 15);
            lblLineScaledVal.TabIndex = 16;
            lblLineScaledVal.Text = "Value";
            // 
            // lblLineScaledHigh
            // 
            lblLineScaledHigh.AutoSize = true;
            lblLineScaledHigh.Location = new Point(199, 55);
            lblLineScaledHigh.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledHigh.Name = "lblLineScaledHigh";
            lblLineScaledHigh.Size = new Size(70, 15);
            lblLineScaledHigh.TabIndex = 15;
            lblLineScaledHigh.Text = "Scaled High";
            // 
            // txtLineScaledHigh
            // 
            txtLineScaledHigh.Location = new Point(274, 52);
            txtLineScaledHigh.Margin = new Padding(4, 3, 4, 3);
            txtLineScaledHigh.Name = "txtLineScaledHigh";
            txtLineScaledHigh.Size = new Size(93, 23);
            txtLineScaledHigh.TabIndex = 14;
            txtLineScaledHigh.Text = "1000";
            // 
            // txtLineScaledLow
            // 
            txtLineScaledLow.Location = new Point(274, 22);
            txtLineScaledLow.Margin = new Padding(4, 3, 4, 3);
            txtLineScaledLow.Name = "txtLineScaledLow";
            txtLineScaledLow.Size = new Size(93, 23);
            txtLineScaledLow.TabIndex = 13;
            txtLineScaledLow.Text = "0";
            // 
            // lblLineScaledLow
            // 
            lblLineScaledLow.AutoSize = true;
            lblLineScaledLow.Location = new Point(199, 25);
            lblLineScaledLow.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledLow.Name = "lblLineScaledLow";
            lblLineScaledLow.Size = new Size(66, 15);
            lblLineScaledLow.TabIndex = 12;
            lblLineScaledLow.Text = "Scaled Low";
            // 
            // lblLineScaledRowHigh
            // 
            lblLineScaledRowHigh.AutoSize = true;
            lblLineScaledRowHigh.Location = new Point(21, 55);
            lblLineScaledRowHigh.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledRowHigh.Name = "lblLineScaledRowHigh";
            lblLineScaledRowHigh.Size = new Size(59, 15);
            lblLineScaledRowHigh.TabIndex = 11;
            lblLineScaledRowHigh.Text = "Row High";
            // 
            // txtLineScaledRowHigh
            // 
            txtLineScaledRowHigh.Location = new Point(86, 52);
            txtLineScaledRowHigh.Margin = new Padding(4, 3, 4, 3);
            txtLineScaledRowHigh.Name = "txtLineScaledRowHigh";
            txtLineScaledRowHigh.Size = new Size(93, 23);
            txtLineScaledRowHigh.TabIndex = 10;
            txtLineScaledRowHigh.Text = "1000";
            // 
            // txtLineScaledRowLow
            // 
            txtLineScaledRowLow.Location = new Point(86, 22);
            txtLineScaledRowLow.Margin = new Padding(4, 3, 4, 3);
            txtLineScaledRowLow.Name = "txtLineScaledRowLow";
            txtLineScaledRowLow.Size = new Size(93, 23);
            txtLineScaledRowLow.TabIndex = 7;
            txtLineScaledRowLow.Text = "0";
            // 
            // lblLineScaledRowLow
            // 
            lblLineScaledRowLow.AutoSize = true;
            lblLineScaledRowLow.Location = new Point(21, 25);
            lblLineScaledRowLow.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledRowLow.Name = "lblLineScaledRowLow";
            lblLineScaledRowLow.Size = new Size(55, 15);
            lblLineScaledRowLow.TabIndex = 6;
            lblLineScaledRowLow.Text = "Row Low";
            // 
            // txtTagCoefficient
            // 
            txtTagCoefficient.Location = new Point(132, 18);
            txtTagCoefficient.Margin = new Padding(4, 3, 4, 3);
            txtTagCoefficient.Name = "txtTagCoefficient";
            txtTagCoefficient.Size = new Size(202, 23);
            txtTagCoefficient.TabIndex = 1;
            txtTagCoefficient.Text = "1";
            // 
            // lblCoefficient
            // 
            lblCoefficient.AutoSize = true;
            lblCoefficient.Location = new Point(12, 22);
            lblCoefficient.Margin = new Padding(4, 0, 4, 0);
            lblCoefficient.Name = "lblCoefficient";
            lblCoefficient.Size = new Size(65, 15);
            lblCoefficient.TabIndex = 0;
            lblCoefficient.Text = "Coefficient";
            // 
            // FrmTag
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 369);
            Controls.Add(tabTag);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmTag";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tag";
            Load += FrmTag_Load;
            tabTag.ResumeLayout(false);
            tabGeneral.ResumeLayout(false);
            gpbTagProperty.ResumeLayout(false);
            gpbTagProperty.PerformLayout();
            tabScaling.ResumeLayout(false);
            gpbScaled.ResumeLayout(false);
            gpbScaled.PerformLayout();
            gpbLineScaled.ResumeLayout(false);
            gpbLineScaled.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabTag;
        private TabPage tabGeneral;
        private Button btnCancel;
        private GroupBox gpbTagProperty;
        private Label lblTagCommand;
        private TextBox txtTagSorting;
        private ComboBox cmbTagCommand;
        private Label lblTagSorting;
        private TextBox txtTagCode;
        private Label lblTagCode;
        private Label lblTagEnabled;
        private CheckBox ckbTagEnabled;
        private TextBox txtTagID;
        private Label lblTagID;
        private Label lblTagType;
        private ComboBox cmbTagType;
        private Label lblTagDescription;
        private TextBox txtTagDescription;
        private TextBox txtTagAddress;
        private Label lblTagAddress;
        private TextBox txtTagname;
        private Label lblTagName;
        private TabPage tabScaling;
        private GroupBox gpbScaled;
        private Label lblScaled;
        private ComboBox cmbScaled;
        private GroupBox gpbLineScaled;
        private Label lblLineScaledResult;
        private Label lblResult;
        private Label lblScaledLowValue_2;
        private Label lblPlus;
        private Label lblBracket_5;
        private Label lblBracket_4;
        private Label lblRowLowValue_2;
        private Label lblLineScaledMinus_3;
        private Label lblLineScaledValue;
        private Label lblBracket_3;
        private Label lblLineScalEdincrease;
        private Label lblBracket_1;
        private Label lblBracket_2;
        private Label lblLineScaledMinus_4;
        private Label lblLineScaledDivision_1;
        private Label lblLineScaledMinus_1;
        private Label lblRowLowValue;
        private Label lblRowHighValue;
        private Label lblScaledLowValue;
        private Label lblScaledHighValue;
        private Button btnCalcLineScaled;
        private TextBox txtValue;
        private Label lblLineScaledVal;
        private Label lblLineScaledHigh;
        private TextBox txtLineScaledHigh;
        private TextBox txtLineScaledLow;
        private Label lblLineScaledLow;
        private Label lblLineScaledRowHigh;
        private TextBox txtLineScaledRowHigh;
        private TextBox txtLineScaledRowLow;
        private Label lblLineScaledRowLow;
        private TextBox txtTagCoefficient;
        private Label lblCoefficient;
        private Button btnSave;
    }
}