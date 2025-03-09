namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscDeviceCommandParametr
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
            this.gpbCommand = new System.Windows.Forms.GroupBox();
            this.nudRegisterWriteValue = new System.Windows.Forms.NumericUpDown();
            this.lblParametrLowByte = new System.Windows.Forms.Label();
            this.lblParametrHighByte = new System.Windows.Forms.Label();
            this.nudParametrLowByte = new System.Windows.Forms.NumericUpDown();
            this.lblRegisterCountLowByte = new System.Windows.Forms.Label();
            this.nudRegisterCountLowByte = new System.Windows.Forms.NumericUpDown();
            this.nudRegisterCount = new System.Windows.Forms.NumericUpDown();
            this.nudParametrHighByte = new System.Windows.Forms.NumericUpDown();
            this.nudRegisterStartAddress = new System.Windows.Forms.NumericUpDown();
            this.lblRegisterStartAddressLowByte = new System.Windows.Forms.Label();
            this.lblRegisterCountHighByte = new System.Windows.Forms.Label();
            this.nudRegisterStartAddressLowByte = new System.Windows.Forms.NumericUpDown();
            this.nudParametr = new System.Windows.Forms.NumericUpDown();
            this.nudRegisterCountHighByte = new System.Windows.Forms.NumericUpDown();
            this.lblRegisterStartAddressHighByte = new System.Windows.Forms.Label();
            this.nudRegisterStartAddressHighByte = new System.Windows.Forms.NumericUpDown();
            this.cmbFunctionCode = new System.Windows.Forms.ComboBox();
            this.gpbGroup = new System.Windows.Forms.GroupBox();
            this.ckbDeviceCommandEnabled = new System.Windows.Forms.CheckBox();
            this.lblNameGroup = new System.Windows.Forms.Label();
            this.txtDeviceCommandName = new System.Windows.Forms.TextBox();
            this.btnCommandSave = new System.Windows.Forms.Button();
            this.lblNku = new System.Windows.Forms.Label();
            this.lblParameterCode = new System.Windows.Forms.Label();
            this.lblNumberOfParameters = new System.Windows.Forms.Label();
            this.gpbDictionary = new System.Windows.Forms.GroupBox();
            this.lblParameterValue = new System.Windows.Forms.Label();
            this.lblArchiveNumber = new System.Windows.Forms.Label();
            this.lblNumberOfMonths = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblNumberOfDays = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTypeOfParameter = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.gpbInformation = new System.Windows.Forms.GroupBox();
            this.lblInformation = new System.Windows.Forms.Label();
            this.gpbCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterWriteValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParametrLowByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCountLowByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParametrHighByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddressLowByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParametr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCountHighByte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddressHighByte)).BeginInit();
            this.gpbGroup.SuspendLayout();
            this.gpbDictionary.SuspendLayout();
            this.gpbInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCommand
            // 
            this.gpbCommand.Controls.Add(this.nudRegisterWriteValue);
            this.gpbCommand.Controls.Add(this.lblParametrLowByte);
            this.gpbCommand.Controls.Add(this.lblParametrHighByte);
            this.gpbCommand.Controls.Add(this.nudParametrLowByte);
            this.gpbCommand.Controls.Add(this.lblRegisterCountLowByte);
            this.gpbCommand.Controls.Add(this.nudRegisterCountLowByte);
            this.gpbCommand.Controls.Add(this.nudRegisterCount);
            this.gpbCommand.Controls.Add(this.nudParametrHighByte);
            this.gpbCommand.Controls.Add(this.nudRegisterStartAddress);
            this.gpbCommand.Controls.Add(this.lblRegisterStartAddressLowByte);
            this.gpbCommand.Controls.Add(this.lblRegisterCountHighByte);
            this.gpbCommand.Controls.Add(this.nudRegisterStartAddressLowByte);
            this.gpbCommand.Controls.Add(this.nudParametr);
            this.gpbCommand.Controls.Add(this.nudRegisterCountHighByte);
            this.gpbCommand.Controls.Add(this.lblRegisterStartAddressHighByte);
            this.gpbCommand.Controls.Add(this.nudRegisterStartAddressHighByte);
            this.gpbCommand.Location = new System.Drawing.Point(12, 114);
            this.gpbCommand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbCommand.Name = "gpbCommand";
            this.gpbCommand.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbCommand.Size = new System.Drawing.Size(704, 117);
            this.gpbCommand.TabIndex = 26;
            this.gpbCommand.TabStop = false;
            this.gpbCommand.Text = "Параметры";
            // 
            // nudRegisterWriteValue
            // 
            this.nudRegisterWriteValue.Location = new System.Drawing.Point(135, 46);
            this.nudRegisterWriteValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterWriteValue.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudRegisterWriteValue.Name = "nudRegisterWriteValue";
            this.nudRegisterWriteValue.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterWriteValue.TabIndex = 32;
            this.nudRegisterWriteValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterWriteValue.Visible = false;
            // 
            // lblParametrLowByte
            // 
            this.lblParametrLowByte.AutoSize = true;
            this.lblParametrLowByte.Location = new System.Drawing.Point(253, 19);
            this.lblParametrLowByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParametrLowByte.Name = "lblParametrLowByte";
            this.lblParametrLowByte.Size = new System.Drawing.Size(71, 15);
            this.lblParametrLowByte.TabIndex = 38;
            this.lblParametrLowByte.Text = "Параметр 1";
            // 
            // lblParametrHighByte
            // 
            this.lblParametrHighByte.AutoSize = true;
            this.lblParametrHighByte.Location = new System.Drawing.Point(8, 19);
            this.lblParametrHighByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParametrHighByte.Name = "lblParametrHighByte";
            this.lblParametrHighByte.Size = new System.Drawing.Size(71, 15);
            this.lblParametrHighByte.TabIndex = 32;
            this.lblParametrHighByte.Text = "Параметр 1";
            // 
            // nudParametrLowByte
            // 
            this.nudParametrLowByte.Location = new System.Drawing.Point(380, 17);
            this.nudParametrLowByte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudParametrLowByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudParametrLowByte.Name = "nudParametrLowByte";
            this.nudParametrLowByte.Size = new System.Drawing.Size(110, 23);
            this.nudParametrLowByte.TabIndex = 37;
            this.nudParametrLowByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudParametrLowByte.ValueChanged += new System.EventHandler(this.nudParametrLowByte_ValueChanged);
            // 
            // lblRegisterCountLowByte
            // 
            this.lblRegisterCountLowByte.AutoSize = true;
            this.lblRegisterCountLowByte.Location = new System.Drawing.Point(253, 79);
            this.lblRegisterCountLowByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterCountLowByte.Name = "lblRegisterCountLowByte";
            this.lblRegisterCountLowByte.Size = new System.Drawing.Size(71, 15);
            this.lblRegisterCountLowByte.TabIndex = 36;
            this.lblRegisterCountLowByte.Text = "Параметр 3";
            // 
            // nudRegisterCountLowByte
            // 
            this.nudRegisterCountLowByte.Location = new System.Drawing.Point(380, 76);
            this.nudRegisterCountLowByte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterCountLowByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRegisterCountLowByte.Name = "nudRegisterCountLowByte";
            this.nudRegisterCountLowByte.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterCountLowByte.TabIndex = 34;
            this.nudRegisterCountLowByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterCountLowByte.ValueChanged += new System.EventHandler(this.nudRegisterCountLowByte_ValueChanged);
            // 
            // nudRegisterCount
            // 
            this.nudRegisterCount.Location = new System.Drawing.Point(577, 76);
            this.nudRegisterCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterCount.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudRegisterCount.Name = "nudRegisterCount";
            this.nudRegisterCount.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterCount.TabIndex = 3;
            this.nudRegisterCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterCount.ValueChanged += new System.EventHandler(this.nudRegisterCount_ValueChanged);
            // 
            // nudParametrHighByte
            // 
            this.nudParametrHighByte.Location = new System.Drawing.Point(135, 17);
            this.nudParametrHighByte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudParametrHighByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudParametrHighByte.Name = "nudParametrHighByte";
            this.nudParametrHighByte.Size = new System.Drawing.Size(110, 23);
            this.nudParametrHighByte.TabIndex = 31;
            this.nudParametrHighByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudParametrHighByte.ValueChanged += new System.EventHandler(this.nudParametrHighByte_ValueChanged);
            // 
            // nudRegisterStartAddress
            // 
            this.nudRegisterStartAddress.Location = new System.Drawing.Point(577, 46);
            this.nudRegisterStartAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterStartAddress.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudRegisterStartAddress.Name = "nudRegisterStartAddress";
            this.nudRegisterStartAddress.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterStartAddress.TabIndex = 2;
            this.nudRegisterStartAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterStartAddress.ValueChanged += new System.EventHandler(this.nudRegisterStartAddress_ValueChanged);
            // 
            // lblRegisterStartAddressLowByte
            // 
            this.lblRegisterStartAddressLowByte.AutoSize = true;
            this.lblRegisterStartAddressLowByte.Location = new System.Drawing.Point(253, 49);
            this.lblRegisterStartAddressLowByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterStartAddressLowByte.Name = "lblRegisterStartAddressLowByte";
            this.lblRegisterStartAddressLowByte.Size = new System.Drawing.Size(71, 15);
            this.lblRegisterStartAddressLowByte.TabIndex = 35;
            this.lblRegisterStartAddressLowByte.Text = "Параметр 2";
            // 
            // lblRegisterCountHighByte
            // 
            this.lblRegisterCountHighByte.AutoSize = true;
            this.lblRegisterCountHighByte.Location = new System.Drawing.Point(8, 79);
            this.lblRegisterCountHighByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterCountHighByte.Name = "lblRegisterCountHighByte";
            this.lblRegisterCountHighByte.Size = new System.Drawing.Size(71, 15);
            this.lblRegisterCountHighByte.TabIndex = 30;
            this.lblRegisterCountHighByte.Text = "Параметр 3";
            // 
            // nudRegisterStartAddressLowByte
            // 
            this.nudRegisterStartAddressLowByte.Location = new System.Drawing.Point(380, 46);
            this.nudRegisterStartAddressLowByte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterStartAddressLowByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRegisterStartAddressLowByte.Name = "nudRegisterStartAddressLowByte";
            this.nudRegisterStartAddressLowByte.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterStartAddressLowByte.TabIndex = 33;
            this.nudRegisterStartAddressLowByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterStartAddressLowByte.ValueChanged += new System.EventHandler(this.nudRegisterStartAddressLowByte_ValueChanged);
            // 
            // nudParametr
            // 
            this.nudParametr.Location = new System.Drawing.Point(577, 17);
            this.nudParametr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudParametr.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudParametr.Name = "nudParametr";
            this.nudParametr.Size = new System.Drawing.Size(110, 23);
            this.nudParametr.TabIndex = 23;
            this.nudParametr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudParametr.ValueChanged += new System.EventHandler(this.nudParametr_ValueChanged);
            // 
            // nudRegisterCountHighByte
            // 
            this.nudRegisterCountHighByte.Location = new System.Drawing.Point(135, 76);
            this.nudRegisterCountHighByte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterCountHighByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRegisterCountHighByte.Name = "nudRegisterCountHighByte";
            this.nudRegisterCountHighByte.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterCountHighByte.TabIndex = 28;
            this.nudRegisterCountHighByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterCountHighByte.ValueChanged += new System.EventHandler(this.nudRegisterCountHighByte_ValueChanged);
            // 
            // lblRegisterStartAddressHighByte
            // 
            this.lblRegisterStartAddressHighByte.AutoSize = true;
            this.lblRegisterStartAddressHighByte.Location = new System.Drawing.Point(8, 49);
            this.lblRegisterStartAddressHighByte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegisterStartAddressHighByte.Name = "lblRegisterStartAddressHighByte";
            this.lblRegisterStartAddressHighByte.Size = new System.Drawing.Size(71, 15);
            this.lblRegisterStartAddressHighByte.TabIndex = 29;
            this.lblRegisterStartAddressHighByte.Text = "Параметр 2";
            // 
            // nudRegisterStartAddressHighByte
            // 
            this.nudRegisterStartAddressHighByte.Location = new System.Drawing.Point(135, 46);
            this.nudRegisterStartAddressHighByte.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nudRegisterStartAddressHighByte.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudRegisterStartAddressHighByte.Name = "nudRegisterStartAddressHighByte";
            this.nudRegisterStartAddressHighByte.Size = new System.Drawing.Size(110, 23);
            this.nudRegisterStartAddressHighByte.TabIndex = 27;
            this.nudRegisterStartAddressHighByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRegisterStartAddressHighByte.ValueChanged += new System.EventHandler(this.nudRegisterStartAddressHighByte_ValueChanged);
            // 
            // cmbFunctionCode
            // 
            this.cmbFunctionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFunctionCode.DropDownWidth = 350;
            this.cmbFunctionCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFunctionCode.FormattingEnabled = true;
            this.cmbFunctionCode.Items.AddRange(new object[] {
            "(80) — Конфигурация вычислителя",
            "(81) — Текущие значения",
            "(82) — Значения, измеренные непосредственно преобразователями",
            "(83) — Значения, принятые для вычислений",
            "(84) — Значения, заданного параметра из часового архива за определенные сутки",
            "(85) — Значений, заданного параметра из суточного архива начиная с указанной даты" +
                "",
            "(86) — Значений, заданного параметра из месячного архива начиная с указанной даты" +
                "",
            "(87) — Архив нештатных ситуаций за предыдущий и текущий месяцы",
            "(88) — Тотальный объем в рабочих условиях",
            "(90) — Архив последних 100 перерывов питания",
            "(91) — Архив последних 450 нештатных ситуаций",
            "(95) — Конфигурация вычислителя (Float)",
            "(96) — Ввод параметров конфигурации в вычислитель"});
            this.cmbFunctionCode.Location = new System.Drawing.Point(12, 85);
            this.cmbFunctionCode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbFunctionCode.Name = "cmbFunctionCode";
            this.cmbFunctionCode.Size = new System.Drawing.Size(432, 23);
            this.cmbFunctionCode.TabIndex = 22;
            this.cmbFunctionCode.SelectedIndexChanged += new System.EventHandler(this.cmbFunctionCode_SelectedIndexChanged);
            // 
            // gpbGroup
            // 
            this.gpbGroup.Controls.Add(this.ckbDeviceCommandEnabled);
            this.gpbGroup.Controls.Add(this.lblNameGroup);
            this.gpbGroup.Controls.Add(this.txtDeviceCommandName);
            this.gpbGroup.Location = new System.Drawing.Point(4, 3);
            this.gpbGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbGroup.Name = "gpbGroup";
            this.gpbGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpbGroup.Size = new System.Drawing.Size(439, 67);
            this.gpbGroup.TabIndex = 23;
            this.gpbGroup.TabStop = false;
            // 
            // ckbDeviceCommandEnabled
            // 
            this.ckbDeviceCommandEnabled.AutoSize = true;
            this.ckbDeviceCommandEnabled.Location = new System.Drawing.Point(329, 33);
            this.ckbDeviceCommandEnabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckbDeviceCommandEnabled.Name = "ckbDeviceCommandEnabled";
            this.ckbDeviceCommandEnabled.Size = new System.Drawing.Size(78, 19);
            this.ckbDeviceCommandEnabled.TabIndex = 13;
            this.ckbDeviceCommandEnabled.Text = "Активное";
            this.ckbDeviceCommandEnabled.UseVisualStyleBackColor = true;
            // 
            // lblNameGroup
            // 
            this.lblNameGroup.AutoSize = true;
            this.lblNameGroup.Location = new System.Drawing.Point(8, 13);
            this.lblNameGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameGroup.Name = "lblNameGroup";
            this.lblNameGroup.Size = new System.Drawing.Size(90, 15);
            this.lblNameGroup.TabIndex = 2;
            this.lblNameGroup.Text = "Наименование";
            // 
            // txtDeviceCommandName
            // 
            this.txtDeviceCommandName.Location = new System.Drawing.Point(7, 31);
            this.txtDeviceCommandName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDeviceCommandName.Name = "txtDeviceCommandName";
            this.txtDeviceCommandName.Size = new System.Drawing.Size(314, 23);
            this.txtDeviceCommandName.TabIndex = 1;
            // 
            // btnCommandSave
            // 
            this.btnCommandSave.Location = new System.Drawing.Point(609, 10);
            this.btnCommandSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCommandSave.Name = "btnCommandSave";
            this.btnCommandSave.Size = new System.Drawing.Size(107, 27);
            this.btnCommandSave.TabIndex = 25;
            this.btnCommandSave.Text = "Сохранить";
            this.btnCommandSave.UseVisualStyleBackColor = true;
            this.btnCommandSave.Visible = false;
            this.btnCommandSave.Click += new System.EventHandler(this.btnCommandSave_Click);
            // 
            // lblNku
            // 
            this.lblNku.AutoSize = true;
            this.lblNku.Location = new System.Drawing.Point(7, 19);
            this.lblNku.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNku.Name = "lblNku";
            this.lblNku.Size = new System.Drawing.Size(119, 15);
            this.lblNku.TabIndex = 27;
            this.lblNku.Text = "Номер канала учета";
            // 
            // lblParameterCode
            // 
            this.lblParameterCode.AutoSize = true;
            this.lblParameterCode.Location = new System.Drawing.Point(7, 19);
            this.lblParameterCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParameterCode.Name = "lblParameterCode";
            this.lblParameterCode.Size = new System.Drawing.Size(89, 15);
            this.lblParameterCode.TabIndex = 28;
            this.lblParameterCode.Text = "Код параметра";
            // 
            // lblNumberOfParameters
            // 
            this.lblNumberOfParameters.AutoSize = true;
            this.lblNumberOfParameters.Location = new System.Drawing.Point(7, 19);
            this.lblNumberOfParameters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfParameters.Name = "lblNumberOfParameters";
            this.lblNumberOfParameters.Size = new System.Drawing.Size(115, 15);
            this.lblNumberOfParameters.TabIndex = 29;
            this.lblNumberOfParameters.Text = "Кол-во параметров";
            // 
            // gpbDictionary
            // 
            this.gpbDictionary.Controls.Add(this.lblParameterValue);
            this.gpbDictionary.Controls.Add(this.lblArchiveNumber);
            this.gpbDictionary.Controls.Add(this.lblNumberOfMonths);
            this.gpbDictionary.Controls.Add(this.lblYear);
            this.gpbDictionary.Controls.Add(this.lblNumberOfDays);
            this.gpbDictionary.Controls.Add(this.lblDay);
            this.gpbDictionary.Controls.Add(this.lblTypeOfParameter);
            this.gpbDictionary.Controls.Add(this.lblMonth);
            this.gpbDictionary.Controls.Add(this.lblNku);
            this.gpbDictionary.Controls.Add(this.lblNumberOfParameters);
            this.gpbDictionary.Controls.Add(this.lblParameterCode);
            this.gpbDictionary.Location = new System.Drawing.Point(445, 3);
            this.gpbDictionary.Name = "gpbDictionary";
            this.gpbDictionary.Size = new System.Drawing.Size(157, 42);
            this.gpbDictionary.TabIndex = 30;
            this.gpbDictionary.TabStop = false;
            this.gpbDictionary.Text = "Словарь";
            // 
            // lblParameterValue
            // 
            this.lblParameterValue.AutoSize = true;
            this.lblParameterValue.Location = new System.Drawing.Point(7, 19);
            this.lblParameterValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParameterValue.Name = "lblParameterValue";
            this.lblParameterValue.Size = new System.Drawing.Size(122, 15);
            this.lblParameterValue.TabIndex = 37;
            this.lblParameterValue.Text = "Значение параметра";
            // 
            // lblArchiveNumber
            // 
            this.lblArchiveNumber.AutoSize = true;
            this.lblArchiveNumber.Location = new System.Drawing.Point(7, 19);
            this.lblArchiveNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArchiveNumber.Name = "lblArchiveNumber";
            this.lblArchiveNumber.Size = new System.Drawing.Size(86, 15);
            this.lblArchiveNumber.TabIndex = 36;
            this.lblArchiveNumber.Text = "Номер архива";
            // 
            // lblNumberOfMonths
            // 
            this.lblNumberOfMonths.AutoSize = true;
            this.lblNumberOfMonths.Location = new System.Drawing.Point(7, 19);
            this.lblNumberOfMonths.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfMonths.Name = "lblNumberOfMonths";
            this.lblNumberOfMonths.Size = new System.Drawing.Size(95, 15);
            this.lblNumberOfMonths.TabIndex = 35;
            this.lblNumberOfMonths.Text = "Кол-во месяцев";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(7, 19);
            this.lblYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(26, 15);
            this.lblYear.TabIndex = 33;
            this.lblYear.Text = "Год";
            // 
            // lblNumberOfDays
            // 
            this.lblNumberOfDays.AutoSize = true;
            this.lblNumberOfDays.Location = new System.Drawing.Point(7, 19);
            this.lblNumberOfDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumberOfDays.Name = "lblNumberOfDays";
            this.lblNumberOfDays.Size = new System.Drawing.Size(79, 15);
            this.lblNumberOfDays.TabIndex = 34;
            this.lblNumberOfDays.Text = "Кол-во суток";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(7, 19);
            this.lblDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(34, 15);
            this.lblDay.TabIndex = 33;
            this.lblDay.Text = "День";
            // 
            // lblTypeOfParameter
            // 
            this.lblTypeOfParameter.AutoSize = true;
            this.lblTypeOfParameter.Location = new System.Drawing.Point(7, 19);
            this.lblTypeOfParameter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeOfParameter.Name = "lblTypeOfParameter";
            this.lblTypeOfParameter.Size = new System.Drawing.Size(89, 15);
            this.lblTypeOfParameter.TabIndex = 30;
            this.lblTypeOfParameter.Text = "Тип параметра";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(7, 19);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 32;
            this.lblMonth.Text = "Месяц";
            // 
            // gpbInformation
            // 
            this.gpbInformation.Controls.Add(this.lblInformation);
            this.gpbInformation.Location = new System.Drawing.Point(12, 237);
            this.gpbInformation.Name = "gpbInformation";
            this.gpbInformation.Size = new System.Drawing.Size(704, 309);
            this.gpbInformation.TabIndex = 31;
            this.gpbInformation.TabStop = false;
            this.gpbInformation.Text = "Информация";
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(7, 19);
            this.lblInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(16, 15);
            this.lblInformation.TabIndex = 27;
            this.lblInformation.Text = "...";
            // 
            // uscDeviceCommandReadParametr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpbInformation);
            this.Controls.Add(this.gpbDictionary);
            this.Controls.Add(this.gpbCommand);
            this.Controls.Add(this.gpbGroup);
            this.Controls.Add(this.btnCommandSave);
            this.Controls.Add(this.cmbFunctionCode);
            this.Name = "uscDeviceCommandReadParametr";
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.uscDeviceCommandRead_Load);
            this.gpbCommand.ResumeLayout(false);
            this.gpbCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterWriteValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParametrLowByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCountLowByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParametrHighByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddressLowByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudParametr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterCountHighByte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegisterStartAddressHighByte)).EndInit();
            this.gpbGroup.ResumeLayout(false);
            this.gpbGroup.PerformLayout();
            this.gpbDictionary.ResumeLayout(false);
            this.gpbDictionary.PerformLayout();
            this.gpbInformation.ResumeLayout(false);
            this.gpbInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gpbCommand;
        private ComboBox cmbFunctionCode;
        private NumericUpDown nudRegisterCount;
        private NumericUpDown nudRegisterStartAddress;
        private GroupBox gpbGroup;
        private CheckBox ckbDeviceCommandEnabled;
        private Label lblNameGroup;
        private TextBox txtDeviceCommandName;
        private Button btnCommandSave;
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
    }
}
