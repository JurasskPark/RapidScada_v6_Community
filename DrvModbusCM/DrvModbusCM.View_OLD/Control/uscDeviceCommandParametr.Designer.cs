namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscCommandParametr
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
            gpbCommand = new GroupBox();
            lblParametrLowByte = new Label();
            lblParametrHighByte = new Label();
            nudParametrLowByte = new NumericUpDown();
            lblRegisterCountLowByte = new Label();
            nudRegisterCountLowByte = new NumericUpDown();
            nudRegisterCount = new NumericUpDown();
            nudParametrHighByte = new NumericUpDown();
            nudRegisterStartAddress = new NumericUpDown();
            lblRegisterStartAddressLowByte = new Label();
            lblRegisterCountHighByte = new Label();
            nudRegisterStartAddressLowByte = new NumericUpDown();
            nudParametr = new NumericUpDown();
            nudRegisterCountHighByte = new NumericUpDown();
            lblRegisterStartAddressHighByte = new Label();
            nudRegisterStartAddressHighByte = new NumericUpDown();
            nudRegisterWriteValue = new NumericUpDown();
            cmbFunctionCode = new ComboBox();
            btnSave = new Button();
            lblNku = new Label();
            lblParameterCode = new Label();
            lblNumberOfParameters = new Label();
            gpbDictionary = new GroupBox();
            lblParameterValue = new Label();
            lblArchiveNumber = new Label();
            lblNumberOfMonths = new Label();
            lblYear = new Label();
            lblNumberOfDays = new Label();
            lblDay = new Label();
            lblTypeOfParameter = new Label();
            lblMonth = new Label();
            gpbInformation = new GroupBox();
            lblInformation = new Label();
            ckbCurrentReadings = new CheckBox();
            gpbGroup = new GroupBox();
            txtDescription = new TextBox();
            lblDescriptionGroup = new Label();
            ckbEnabled = new CheckBox();
            lblNameGroup = new Label();
            txtName = new TextBox();
            gpbCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudParametrLowByte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCountLowByte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudParametrHighByte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddressLowByte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudParametr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCountHighByte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddressHighByte).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterWriteValue).BeginInit();
            gpbDictionary.SuspendLayout();
            gpbInformation.SuspendLayout();
            gpbGroup.SuspendLayout();
            SuspendLayout();
            // 
            // gpbCommand
            // 
            gpbCommand.Controls.Add(ckbCurrentReadings);
            gpbCommand.Controls.Add(lblParametrLowByte);
            gpbCommand.Controls.Add(lblParametrHighByte);
            gpbCommand.Controls.Add(nudParametrLowByte);
            gpbCommand.Controls.Add(lblRegisterCountLowByte);
            gpbCommand.Controls.Add(nudRegisterCountLowByte);
            gpbCommand.Controls.Add(nudRegisterCount);
            gpbCommand.Controls.Add(cmbFunctionCode);
            gpbCommand.Controls.Add(nudParametrHighByte);
            gpbCommand.Controls.Add(nudRegisterStartAddress);
            gpbCommand.Controls.Add(lblRegisterStartAddressLowByte);
            gpbCommand.Controls.Add(lblRegisterCountHighByte);
            gpbCommand.Controls.Add(nudRegisterStartAddressLowByte);
            gpbCommand.Controls.Add(nudParametr);
            gpbCommand.Controls.Add(nudRegisterCountHighByte);
            gpbCommand.Controls.Add(lblRegisterStartAddressHighByte);
            gpbCommand.Controls.Add(nudRegisterStartAddressHighByte);
            gpbCommand.Controls.Add(nudRegisterWriteValue);
            gpbCommand.Location = new Point(7, 200);
            gpbCommand.Margin = new Padding(4, 3, 4, 3);
            gpbCommand.Name = "gpbCommand";
            gpbCommand.Padding = new Padding(4, 3, 4, 3);
            gpbCommand.Size = new Size(704, 145);
            gpbCommand.TabIndex = 26;
            gpbCommand.TabStop = false;
            gpbCommand.Text = "Parameters";
            // 
            // lblParametrLowByte
            // 
            lblParametrLowByte.AutoSize = true;
            lblParametrLowByte.Location = new Point(253, 56);
            lblParametrLowByte.Margin = new Padding(4, 0, 4, 0);
            lblParametrLowByte.Name = "lblParametrLowByte";
            lblParametrLowByte.Size = new Size(70, 15);
            lblParametrLowByte.TabIndex = 38;
            lblParametrLowByte.Text = "Parameter 1";
            // 
            // lblParametrHighByte
            // 
            lblParametrHighByte.AutoSize = true;
            lblParametrHighByte.Location = new Point(8, 56);
            lblParametrHighByte.Margin = new Padding(4, 0, 4, 0);
            lblParametrHighByte.Name = "lblParametrHighByte";
            lblParametrHighByte.Size = new Size(70, 15);
            lblParametrHighByte.TabIndex = 32;
            lblParametrHighByte.Text = "Parameter 1";
            // 
            // nudParametrLowByte
            // 
            nudParametrLowByte.Location = new Point(380, 54);
            nudParametrLowByte.Margin = new Padding(4, 3, 4, 3);
            nudParametrLowByte.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudParametrLowByte.Name = "nudParametrLowByte";
            nudParametrLowByte.Size = new Size(110, 23);
            nudParametrLowByte.TabIndex = 37;
            nudParametrLowByte.TextAlign = HorizontalAlignment.Center;
            nudParametrLowByte.ValueChanged += nudParametrLowByte_ValueChanged;
            // 
            // lblRegisterCountLowByte
            // 
            lblRegisterCountLowByte.AutoSize = true;
            lblRegisterCountLowByte.Location = new Point(253, 116);
            lblRegisterCountLowByte.Margin = new Padding(4, 0, 4, 0);
            lblRegisterCountLowByte.Name = "lblRegisterCountLowByte";
            lblRegisterCountLowByte.Size = new Size(70, 15);
            lblRegisterCountLowByte.TabIndex = 36;
            lblRegisterCountLowByte.Text = "Parameter 3";
            // 
            // nudRegisterCountLowByte
            // 
            nudRegisterCountLowByte.Location = new Point(380, 113);
            nudRegisterCountLowByte.Margin = new Padding(4, 3, 4, 3);
            nudRegisterCountLowByte.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRegisterCountLowByte.Name = "nudRegisterCountLowByte";
            nudRegisterCountLowByte.Size = new Size(110, 23);
            nudRegisterCountLowByte.TabIndex = 34;
            nudRegisterCountLowByte.TextAlign = HorizontalAlignment.Center;
            nudRegisterCountLowByte.ValueChanged += nudRegisterCountLowByte_ValueChanged;
            // 
            // nudRegisterCount
            // 
            nudRegisterCount.Location = new Point(577, 113);
            nudRegisterCount.Margin = new Padding(4, 3, 4, 3);
            nudRegisterCount.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRegisterCount.Name = "nudRegisterCount";
            nudRegisterCount.Size = new Size(110, 23);
            nudRegisterCount.TabIndex = 3;
            nudRegisterCount.TextAlign = HorizontalAlignment.Center;
            nudRegisterCount.ValueChanged += nudRegisterCount_ValueChanged;
            // 
            // nudParametrHighByte
            // 
            nudParametrHighByte.Location = new Point(135, 54);
            nudParametrHighByte.Margin = new Padding(4, 3, 4, 3);
            nudParametrHighByte.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudParametrHighByte.Name = "nudParametrHighByte";
            nudParametrHighByte.Size = new Size(110, 23);
            nudParametrHighByte.TabIndex = 31;
            nudParametrHighByte.TextAlign = HorizontalAlignment.Center;
            nudParametrHighByte.ValueChanged += nudParametrHighByte_ValueChanged;
            // 
            // nudRegisterStartAddress
            // 
            nudRegisterStartAddress.Location = new Point(577, 83);
            nudRegisterStartAddress.Margin = new Padding(4, 3, 4, 3);
            nudRegisterStartAddress.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRegisterStartAddress.Name = "nudRegisterStartAddress";
            nudRegisterStartAddress.Size = new Size(110, 23);
            nudRegisterStartAddress.TabIndex = 2;
            nudRegisterStartAddress.TextAlign = HorizontalAlignment.Center;
            nudRegisterStartAddress.ValueChanged += nudRegisterStartAddress_ValueChanged;
            // 
            // lblRegisterStartAddressLowByte
            // 
            lblRegisterStartAddressLowByte.AutoSize = true;
            lblRegisterStartAddressLowByte.Location = new Point(253, 86);
            lblRegisterStartAddressLowByte.Margin = new Padding(4, 0, 4, 0);
            lblRegisterStartAddressLowByte.Name = "lblRegisterStartAddressLowByte";
            lblRegisterStartAddressLowByte.Size = new Size(70, 15);
            lblRegisterStartAddressLowByte.TabIndex = 35;
            lblRegisterStartAddressLowByte.Text = "Parameter 2";
            // 
            // lblRegisterCountHighByte
            // 
            lblRegisterCountHighByte.AutoSize = true;
            lblRegisterCountHighByte.Location = new Point(8, 116);
            lblRegisterCountHighByte.Margin = new Padding(4, 0, 4, 0);
            lblRegisterCountHighByte.Name = "lblRegisterCountHighByte";
            lblRegisterCountHighByte.Size = new Size(70, 15);
            lblRegisterCountHighByte.TabIndex = 30;
            lblRegisterCountHighByte.Text = "Parameter 3";
            // 
            // nudRegisterStartAddressLowByte
            // 
            nudRegisterStartAddressLowByte.Location = new Point(380, 83);
            nudRegisterStartAddressLowByte.Margin = new Padding(4, 3, 4, 3);
            nudRegisterStartAddressLowByte.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRegisterStartAddressLowByte.Name = "nudRegisterStartAddressLowByte";
            nudRegisterStartAddressLowByte.Size = new Size(110, 23);
            nudRegisterStartAddressLowByte.TabIndex = 33;
            nudRegisterStartAddressLowByte.TextAlign = HorizontalAlignment.Center;
            nudRegisterStartAddressLowByte.ValueChanged += nudRegisterStartAddressLowByte_ValueChanged;
            // 
            // nudParametr
            // 
            nudParametr.Location = new Point(577, 54);
            nudParametr.Margin = new Padding(4, 3, 4, 3);
            nudParametr.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudParametr.Name = "nudParametr";
            nudParametr.Size = new Size(110, 23);
            nudParametr.TabIndex = 23;
            nudParametr.TextAlign = HorizontalAlignment.Center;
            nudParametr.ValueChanged += nudParametr_ValueChanged;
            // 
            // nudRegisterCountHighByte
            // 
            nudRegisterCountHighByte.Location = new Point(135, 113);
            nudRegisterCountHighByte.Margin = new Padding(4, 3, 4, 3);
            nudRegisterCountHighByte.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRegisterCountHighByte.Name = "nudRegisterCountHighByte";
            nudRegisterCountHighByte.Size = new Size(110, 23);
            nudRegisterCountHighByte.TabIndex = 28;
            nudRegisterCountHighByte.TextAlign = HorizontalAlignment.Center;
            nudRegisterCountHighByte.ValueChanged += nudRegisterCountHighByte_ValueChanged;
            // 
            // lblRegisterStartAddressHighByte
            // 
            lblRegisterStartAddressHighByte.AutoSize = true;
            lblRegisterStartAddressHighByte.Location = new Point(8, 86);
            lblRegisterStartAddressHighByte.Margin = new Padding(4, 0, 4, 0);
            lblRegisterStartAddressHighByte.Name = "lblRegisterStartAddressHighByte";
            lblRegisterStartAddressHighByte.Size = new Size(70, 15);
            lblRegisterStartAddressHighByte.TabIndex = 29;
            lblRegisterStartAddressHighByte.Text = "Parameter 2";
            // 
            // nudRegisterStartAddressHighByte
            // 
            nudRegisterStartAddressHighByte.Location = new Point(135, 83);
            nudRegisterStartAddressHighByte.Margin = new Padding(4, 3, 4, 3);
            nudRegisterStartAddressHighByte.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudRegisterStartAddressHighByte.Name = "nudRegisterStartAddressHighByte";
            nudRegisterStartAddressHighByte.Size = new Size(110, 23);
            nudRegisterStartAddressHighByte.TabIndex = 27;
            nudRegisterStartAddressHighByte.TextAlign = HorizontalAlignment.Center;
            nudRegisterStartAddressHighByte.ValueChanged += nudRegisterStartAddressHighByte_ValueChanged;
            // 
            // nudRegisterWriteValue
            // 
            nudRegisterWriteValue.Location = new Point(135, 83);
            nudRegisterWriteValue.Margin = new Padding(4, 3, 4, 3);
            nudRegisterWriteValue.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudRegisterWriteValue.Name = "nudRegisterWriteValue";
            nudRegisterWriteValue.Size = new Size(110, 23);
            nudRegisterWriteValue.TabIndex = 32;
            nudRegisterWriteValue.TextAlign = HorizontalAlignment.Center;
            nudRegisterWriteValue.Visible = false;
            // 
            // cmbFunctionCode
            // 
            cmbFunctionCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionCode.DropDownWidth = 350;
            cmbFunctionCode.FlatStyle = FlatStyle.Flat;
            cmbFunctionCode.FormattingEnabled = true;
            cmbFunctionCode.Items.AddRange(new object[] { "(80) — Конфигурация вычислителя", "(81) — Текущие значения", "(82) — Значения, измеренные непосредственно преобразователями", "(83) — Значения, принятые для вычислений", "(84) — Значения, заданного параметра из часового архива за определенные сутки", "(85) — Значений, заданного параметра из суточного архива начиная с указанной даты", "(86) — Значений, заданного параметра из месячного архива начиная с указанной даты", "(87) — Архив нештатных ситуаций за предыдущий и текущий месяцы", "(88) — Тотальный объем в рабочих условиях", "(90) — Архив последних 100 перерывов питания", "(91) — Архив последних 450 нештатных ситуаций", "(95) — Конфигурация вычислителя (Float)", "(96) — Ввод параметров конфигурации в вычислитель" });
            cmbFunctionCode.Location = new Point(8, 22);
            cmbFunctionCode.Margin = new Padding(4, 3, 4, 3);
            cmbFunctionCode.Name = "cmbFunctionCode";
            cmbFunctionCode.Size = new Size(432, 23);
            cmbFunctionCode.TabIndex = 22;
            cmbFunctionCode.SelectedIndexChanged += cmbFunctionCode_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(441, 13);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 25;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnCommandSave_Click;
            // 
            // lblNku
            // 
            lblNku.AutoSize = true;
            lblNku.Location = new Point(7, 19);
            lblNku.Margin = new Padding(4, 0, 4, 0);
            lblNku.Name = "lblNku";
            lblNku.Size = new Size(119, 15);
            lblNku.TabIndex = 27;
            lblNku.Text = "Номер канала учета";
            // 
            // lblParameterCode
            // 
            lblParameterCode.AutoSize = true;
            lblParameterCode.Location = new Point(7, 19);
            lblParameterCode.Margin = new Padding(4, 0, 4, 0);
            lblParameterCode.Name = "lblParameterCode";
            lblParameterCode.Size = new Size(89, 15);
            lblParameterCode.TabIndex = 28;
            lblParameterCode.Text = "Код параметра";
            // 
            // lblNumberOfParameters
            // 
            lblNumberOfParameters.AutoSize = true;
            lblNumberOfParameters.Location = new Point(7, 19);
            lblNumberOfParameters.Margin = new Padding(4, 0, 4, 0);
            lblNumberOfParameters.Name = "lblNumberOfParameters";
            lblNumberOfParameters.Size = new Size(115, 15);
            lblNumberOfParameters.TabIndex = 29;
            lblNumberOfParameters.Text = "Кол-во параметров";
            // 
            // gpbDictionary
            // 
            gpbDictionary.Controls.Add(lblParameterValue);
            gpbDictionary.Controls.Add(lblArchiveNumber);
            gpbDictionary.Controls.Add(lblNumberOfMonths);
            gpbDictionary.Controls.Add(lblYear);
            gpbDictionary.Controls.Add(lblNumberOfDays);
            gpbDictionary.Controls.Add(lblDay);
            gpbDictionary.Controls.Add(lblTypeOfParameter);
            gpbDictionary.Controls.Add(lblMonth);
            gpbDictionary.Controls.Add(lblNku);
            gpbDictionary.Controls.Add(lblNumberOfParameters);
            gpbDictionary.Controls.Add(lblParameterCode);
            gpbDictionary.Location = new Point(465, 98);
            gpbDictionary.Name = "gpbDictionary";
            gpbDictionary.Size = new Size(153, 75);
            gpbDictionary.TabIndex = 30;
            gpbDictionary.TabStop = false;
            gpbDictionary.Text = "Dictionary";
            // 
            // lblParameterValue
            // 
            lblParameterValue.AutoSize = true;
            lblParameterValue.Location = new Point(7, 19);
            lblParameterValue.Margin = new Padding(4, 0, 4, 0);
            lblParameterValue.Name = "lblParameterValue";
            lblParameterValue.Size = new Size(122, 15);
            lblParameterValue.TabIndex = 37;
            lblParameterValue.Text = "Значение параметра";
            // 
            // lblArchiveNumber
            // 
            lblArchiveNumber.AutoSize = true;
            lblArchiveNumber.Location = new Point(7, 19);
            lblArchiveNumber.Margin = new Padding(4, 0, 4, 0);
            lblArchiveNumber.Name = "lblArchiveNumber";
            lblArchiveNumber.Size = new Size(86, 15);
            lblArchiveNumber.TabIndex = 36;
            lblArchiveNumber.Text = "Номер архива";
            // 
            // lblNumberOfMonths
            // 
            lblNumberOfMonths.AutoSize = true;
            lblNumberOfMonths.Location = new Point(7, 19);
            lblNumberOfMonths.Margin = new Padding(4, 0, 4, 0);
            lblNumberOfMonths.Name = "lblNumberOfMonths";
            lblNumberOfMonths.Size = new Size(95, 15);
            lblNumberOfMonths.TabIndex = 35;
            lblNumberOfMonths.Text = "Кол-во месяцев";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(7, 19);
            lblYear.Margin = new Padding(4, 0, 4, 0);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(26, 15);
            lblYear.TabIndex = 33;
            lblYear.Text = "Год";
            // 
            // lblNumberOfDays
            // 
            lblNumberOfDays.AutoSize = true;
            lblNumberOfDays.Location = new Point(7, 19);
            lblNumberOfDays.Margin = new Padding(4, 0, 4, 0);
            lblNumberOfDays.Name = "lblNumberOfDays";
            lblNumberOfDays.Size = new Size(79, 15);
            lblNumberOfDays.TabIndex = 34;
            lblNumberOfDays.Text = "Кол-во суток";
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Location = new Point(7, 19);
            lblDay.Margin = new Padding(4, 0, 4, 0);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(34, 15);
            lblDay.TabIndex = 33;
            lblDay.Text = "День";
            // 
            // lblTypeOfParameter
            // 
            lblTypeOfParameter.AutoSize = true;
            lblTypeOfParameter.Location = new Point(7, 19);
            lblTypeOfParameter.Margin = new Padding(4, 0, 4, 0);
            lblTypeOfParameter.Name = "lblTypeOfParameter";
            lblTypeOfParameter.Size = new Size(89, 15);
            lblTypeOfParameter.TabIndex = 30;
            lblTypeOfParameter.Text = "Тип параметра";
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(7, 19);
            lblMonth.Margin = new Padding(4, 0, 4, 0);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(43, 15);
            lblMonth.TabIndex = 32;
            lblMonth.Text = "Месяц";
            // 
            // gpbInformation
            // 
            gpbInformation.Controls.Add(lblInformation);
            gpbInformation.Location = new Point(7, 351);
            gpbInformation.Name = "gpbInformation";
            gpbInformation.Size = new Size(704, 309);
            gpbInformation.TabIndex = 31;
            gpbInformation.TabStop = false;
            gpbInformation.Text = "Information";
            // 
            // lblInformation
            // 
            lblInformation.AutoSize = true;
            lblInformation.Location = new Point(7, 19);
            lblInformation.Margin = new Padding(4, 0, 4, 0);
            lblInformation.Name = "lblInformation";
            lblInformation.Size = new Size(16, 15);
            lblInformation.TabIndex = 27;
            lblInformation.Text = "...";
            // 
            // ckbCurrentReadings
            // 
            ckbCurrentReadings.AutoSize = true;
            ckbCurrentReadings.Location = new Point(447, 24);
            ckbCurrentReadings.Name = "ckbCurrentReadings";
            ckbCurrentReadings.Size = new Size(114, 19);
            ckbCurrentReadings.TabIndex = 32;
            ckbCurrentReadings.Text = "Current readings";
            ckbCurrentReadings.UseVisualStyleBackColor = true;
            ckbCurrentReadings.CheckedChanged += ckbCurrentReadings_CheckedChanged;
            // 
            // gpbGroup
            // 
            gpbGroup.Controls.Add(txtDescription);
            gpbGroup.Controls.Add(lblDescriptionGroup);
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblNameGroup);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(7, 6);
            gpbGroup.Margin = new Padding(4, 3, 4, 3);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(4, 3, 4, 3);
            gpbGroup.Size = new Size(425, 188);
            gpbGroup.TabIndex = 32;
            gpbGroup.TabStop = false;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(7, 74);
            txtDescription.Margin = new Padding(4, 3, 4, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(408, 93);
            txtDescription.TabIndex = 88;
            // 
            // lblDescriptionGroup
            // 
            lblDescriptionGroup.AutoSize = true;
            lblDescriptionGroup.Location = new Point(9, 55);
            lblDescriptionGroup.Margin = new Padding(4, 0, 4, 0);
            lblDescriptionGroup.Name = "lblDescriptionGroup";
            lblDescriptionGroup.Size = new Size(67, 15);
            lblDescriptionGroup.TabIndex = 87;
            lblDescriptionGroup.Text = "Description";
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(331, 35);
            ckbEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(68, 19);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Enabled";
            ckbEnabled.UseVisualStyleBackColor = true;
            // 
            // lblNameGroup
            // 
            lblNameGroup.AutoSize = true;
            lblNameGroup.Location = new Point(9, 13);
            lblNameGroup.Margin = new Padding(4, 0, 4, 0);
            lblNameGroup.Name = "lblNameGroup";
            lblNameGroup.Size = new Size(39, 15);
            lblNameGroup.TabIndex = 2;
            lblNameGroup.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(7, 31);
            txtName.Margin = new Padding(4, 3, 4, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(314, 23);
            txtName.TabIndex = 1;
            // 
            // uscCommandParametr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gpbGroup);
            Controls.Add(gpbInformation);
            Controls.Add(gpbDictionary);
            Controls.Add(gpbCommand);
            Controls.Add(btnSave);
            Name = "uscCommandParametr";
            Size = new Size(800, 700);
            Load += uscCommandRead_Load;
            gpbCommand.ResumeLayout(false);
            gpbCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudParametrLowByte).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCountLowByte).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudParametrHighByte).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddress).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddressLowByte).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudParametr).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterCountHighByte).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterStartAddressHighByte).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRegisterWriteValue).EndInit();
            gpbDictionary.ResumeLayout(false);
            gpbDictionary.PerformLayout();
            gpbInformation.ResumeLayout(false);
            gpbInformation.PerformLayout();
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbCommand;
        private ComboBox cmbFunctionCode;
        private NumericUpDown nudRegisterCount;
        private NumericUpDown nudRegisterStartAddress;
        private Button btnSave;
        private NumericUpDown nudParametr;
        private Label lblParametrLowByte;
        private Label lblParametrHighByte;
        private NumericUpDown nudParametrLowByte;
        private Label lblRegisterCountLowByte;
        private NumericUpDown nudRegisterCountLowByte;
        private NumericUpDown nudParametrHighByte;
        private Label lblRegisterStartAddressLowByte;
        private Label lblRegisterCountHighByte;
        private NumericUpDown nudRegisterStartAddressLowByte;
        private NumericUpDown nudRegisterCountHighByte;
        private Label lblRegisterStartAddressHighByte;
        private NumericUpDown nudRegisterStartAddressHighByte;
        private Label lblNku;
        private Label lblParameterCode;
        private Label lblNumberOfParameters;
        private GroupBox gpbDictionary;
        private Label lblTypeOfParameter;
        private GroupBox gpbInformation;
        private Label lblInformation;
        private Label lblDay;
        private Label lblMonth;
        private Label lblNumberOfDays;
        private Label lblNumberOfMonths;
        private Label lblYear;
        private Label lblArchiveNumber;
        private Label lblParameterValue;
        private NumericUpDown nudRegisterWriteValue;
        private CheckBox ckbCurrentReadings;
        private GroupBox gpbGroup;
        private TextBox txtDescription;
        private Label lblDescriptionGroup;
        private CheckBox ckbEnabled;
        private Label lblNameGroup;
        private TextBox txtName;
    }
}
