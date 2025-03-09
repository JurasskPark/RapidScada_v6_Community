namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscTag
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
            cmnuTag = new ContextMenuStrip(components);
            tolRegisterRefresh = new ToolStripMenuItem();
            tolSeparator1 = new ToolStripSeparator();
            tolTagAdd = new ToolStripMenuItem();
            tolTagChange = new ToolStripMenuItem();
            tolTagDelete = new ToolStripMenuItem();
            tolTagDeleteAll = new ToolStripMenuItem();
            tolSeparator2 = new ToolStripSeparator();
            tolTagUp = new ToolStripMenuItem();
            tolTagDown = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            сортировкаToolStripMenuItem = new ToolStripMenuItem();
            tolTagSortDefault = new ToolStripMenuItem();
            tolTagSortTagAddress = new ToolStripMenuItem();
            tolTagSortTagName = new ToolStripMenuItem();
            tolTagSortTagDescription = new ToolStripMenuItem();
            tolTagSortTagType = new ToolStripMenuItem();
            tolTagSortTagValue = new ToolStripMenuItem();
            tolSeparator3 = new ToolStripSeparator();
            tolCSV = new ToolStripMenuItem();
            tolDataLoadAsCSV = new ToolStripMenuItem();
            tolDataSaveAsCSV = new ToolStripMenuItem();
            tolSeparator4 = new ToolStripSeparator();
            tolTagImport = new ToolStripMenuItem();
            tmrTimer = new System.Windows.Forms.Timer(components);
            tabTag = new TabControl();
            tabSettings = new TabPage();
            btnTagSave = new Button();
            gpbTagProperty = new GroupBox();
            txtTagSorting = new TextBox();
            lblTagSorting = new Label();
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
            txtTagCode = new TextBox();
            lblTagCode = new Label();
            cmnuTag.SuspendLayout();
            tabTag.SuspendLayout();
            tabSettings.SuspendLayout();
            gpbTagProperty.SuspendLayout();
            tabScaling.SuspendLayout();
            gpbScaled.SuspendLayout();
            gpbLineScaled.SuspendLayout();
            SuspendLayout();
            // 
            // cmnuTag
            // 
            cmnuTag.Items.AddRange(new ToolStripItem[] { tolRegisterRefresh, tolSeparator1, tolTagAdd, tolTagChange, tolTagDelete, tolTagDeleteAll, tolSeparator2, tolTagUp, tolTagDown, toolStripSeparator1, сортировкаToolStripMenuItem, tolSeparator3, tolCSV, tolSeparator4, tolTagImport });
            cmnuTag.Name = "contextMenuDeviceEdit";
            cmnuTag.Size = new Size(166, 254);
            // 
            // tolRegisterRefresh
            // 
            tolRegisterRefresh.Name = "tolRegisterRefresh";
            tolRegisterRefresh.Size = new Size(165, 22);
            tolRegisterRefresh.Text = "Обновить";
            // 
            // tolSeparator1
            // 
            tolSeparator1.Name = "tolSeparator1";
            tolSeparator1.Size = new Size(162, 6);
            // 
            // tolTagAdd
            // 
            tolTagAdd.Name = "tolTagAdd";
            tolTagAdd.Size = new Size(165, 22);
            tolTagAdd.Text = "Добавить";
            // 
            // tolTagChange
            // 
            tolTagChange.Name = "tolTagChange";
            tolTagChange.Size = new Size(165, 22);
            tolTagChange.Text = "Изменить";
            // 
            // tolTagDelete
            // 
            tolTagDelete.Name = "tolTagDelete";
            tolTagDelete.Size = new Size(165, 22);
            tolTagDelete.Text = "Удалить";
            // 
            // tolTagDeleteAll
            // 
            tolTagDeleteAll.Name = "tolTagDeleteAll";
            tolTagDeleteAll.Size = new Size(165, 22);
            tolTagDeleteAll.Text = "Удалить все теги";
            // 
            // tolSeparator2
            // 
            tolSeparator2.Name = "tolSeparator2";
            tolSeparator2.Size = new Size(162, 6);
            // 
            // tolTagUp
            // 
            tolTagUp.Name = "tolTagUp";
            tolTagUp.Size = new Size(165, 22);
            tolTagUp.Text = "Поднять вверх";
            // 
            // tolTagDown
            // 
            tolTagDown.Name = "tolTagDown";
            tolTagDown.Size = new Size(165, 22);
            tolTagDown.Text = "Опустить вниз";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(162, 6);
            // 
            // сортировкаToolStripMenuItem
            // 
            сортировкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tolTagSortDefault, tolTagSortTagAddress, tolTagSortTagName, tolTagSortTagDescription, tolTagSortTagType, tolTagSortTagValue });
            сортировкаToolStripMenuItem.Name = "сортировкаToolStripMenuItem";
            сортировкаToolStripMenuItem.Size = new Size(165, 22);
            сортировкаToolStripMenuItem.Text = "Сортировка";
            // 
            // tolTagSortDefault
            // 
            tolTagSortDefault.Name = "tolTagSortDefault";
            tolTagSortDefault.Size = new Size(242, 22);
            tolTagSortDefault.Text = "Сортировка по умолчанию";
            // 
            // tolTagSortTagAddress
            // 
            tolTagSortTagAddress.Name = "tolTagSortTagAddress";
            tolTagSortTagAddress.Size = new Size(242, 22);
            tolTagSortTagAddress.Text = "Сортировка по адресу тега";
            // 
            // tolTagSortTagName
            // 
            tolTagSortTagName.Name = "tolTagSortTagName";
            tolTagSortTagName.Size = new Size(242, 22);
            tolTagSortTagName.Text = "Сортировка по имени тега";
            // 
            // tolTagSortTagDescription
            // 
            tolTagSortTagDescription.Name = "tolTagSortTagDescription";
            tolTagSortTagDescription.Size = new Size(242, 22);
            tolTagSortTagDescription.Text = "Сортировка по описанию тега";
            // 
            // tolTagSortTagType
            // 
            tolTagSortTagType.Name = "tolTagSortTagType";
            tolTagSortTagType.Size = new Size(242, 22);
            tolTagSortTagType.Text = "Сортировка по типу тега";
            // 
            // tolTagSortTagValue
            // 
            tolTagSortTagValue.Name = "tolTagSortTagValue";
            tolTagSortTagValue.Size = new Size(242, 22);
            tolTagSortTagValue.Text = "Сортировка по значению тега";
            // 
            // tolSeparator3
            // 
            tolSeparator3.Name = "tolSeparator3";
            tolSeparator3.Size = new Size(162, 6);
            // 
            // tolCSV
            // 
            tolCSV.DropDownItems.AddRange(new ToolStripItem[] { tolDataLoadAsCSV, tolDataSaveAsCSV });
            tolCSV.Name = "tolCSV";
            tolCSV.Size = new Size(165, 22);
            tolCSV.Text = "CSV";
            // 
            // tolDataLoadAsCSV
            // 
            tolDataLoadAsCSV.Name = "tolDataLoadAsCSV";
            tolDataLoadAsCSV.Size = new Size(167, 22);
            tolDataLoadAsCSV.Text = "Загрузить из CSV";
            // 
            // tolDataSaveAsCSV
            // 
            tolDataSaveAsCSV.Name = "tolDataSaveAsCSV";
            tolDataSaveAsCSV.Size = new Size(167, 22);
            tolDataSaveAsCSV.Text = "Выгрузить в CSV";
            // 
            // tolSeparator4
            // 
            tolSeparator4.Name = "tolSeparator4";
            tolSeparator4.Size = new Size(162, 6);
            // 
            // tolTagImport
            // 
            tolTagImport.Name = "tolTagImport";
            tolTagImport.Size = new Size(165, 22);
            tolTagImport.Text = "Импорт тегов...";
            // 
            // tmrTimer
            // 
            tmrTimer.Enabled = true;
            // 
            // tabTag
            // 
            tabTag.Controls.Add(tabSettings);
            tabTag.Controls.Add(tabScaling);
            tabTag.Dock = DockStyle.Fill;
            tabTag.Location = new Point(0, 0);
            tabTag.Name = "tabTag";
            tabTag.SelectedIndex = 0;
            tabTag.Size = new Size(900, 700);
            tabTag.TabIndex = 1;
            // 
            // tabSettings
            // 
            tabSettings.Controls.Add(btnTagSave);
            tabSettings.Controls.Add(gpbTagProperty);
            tabSettings.Location = new Point(4, 24);
            tabSettings.Name = "tabSettings";
            tabSettings.Padding = new Padding(3);
            tabSettings.Size = new Size(892, 672);
            tabSettings.TabIndex = 0;
            tabSettings.Text = "Настройки";
            tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnTagSave
            // 
            btnTagSave.Location = new Point(465, 13);
            btnTagSave.Margin = new Padding(4, 3, 4, 3);
            btnTagSave.Name = "btnTagSave";
            btnTagSave.Size = new Size(107, 27);
            btnTagSave.TabIndex = 28;
            btnTagSave.Text = "Сохранить";
            btnTagSave.UseVisualStyleBackColor = true;
            btnTagSave.Click += btnTagSave_Click;
            // 
            // gpbTagProperty
            // 
            gpbTagProperty.Controls.Add(txtTagCode);
            gpbTagProperty.Controls.Add(lblTagCode);
            gpbTagProperty.Controls.Add(txtTagSorting);
            gpbTagProperty.Controls.Add(lblTagSorting);
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
            gpbTagProperty.Location = new Point(7, 6);
            gpbTagProperty.Margin = new Padding(4, 3, 4, 3);
            gpbTagProperty.Name = "gpbTagProperty";
            gpbTagProperty.Padding = new Padding(4, 3, 4, 3);
            gpbTagProperty.Size = new Size(450, 275);
            gpbTagProperty.TabIndex = 27;
            gpbTagProperty.TabStop = false;
            gpbTagProperty.Text = "Свойства тега";
            // 
            // txtTagSorting
            // 
            txtTagSorting.Location = new Point(124, 226);
            txtTagSorting.Name = "txtTagSorting";
            txtTagSorting.Size = new Size(318, 23);
            txtTagSorting.TabIndex = 29;
            // 
            // lblTagSorting
            // 
            lblTagSorting.AutoSize = true;
            lblTagSorting.Location = new Point(13, 229);
            lblTagSorting.Margin = new Padding(4, 0, 4, 0);
            lblTagSorting.Name = "lblTagSorting";
            lblTagSorting.Size = new Size(73, 15);
            lblTagSorting.TabIndex = 27;
            lblTagSorting.Text = "Сортировка";
            // 
            // lblTagEnabled
            // 
            lblTagEnabled.AutoSize = true;
            lblTagEnabled.Location = new Point(13, 55);
            lblTagEnabled.Margin = new Padding(4, 0, 4, 0);
            lblTagEnabled.Name = "lblTagEnabled";
            lblTagEnabled.Size = new Size(52, 15);
            lblTagEnabled.TabIndex = 10;
            lblTagEnabled.Text = "Активен";
            // 
            // ckbTagEnabled
            // 
            ckbTagEnabled.AutoSize = true;
            ckbTagEnabled.Location = new Point(127, 55);
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
            txtTagID.Size = new Size(318, 23);
            txtTagID.TabIndex = 10;
            // 
            // lblTagID
            // 
            lblTagID.AutoSize = true;
            lblTagID.Location = new Point(13, 26);
            lblTagID.Margin = new Padding(4, 0, 4, 0);
            lblTagID.Name = "lblTagID";
            lblTagID.Size = new Size(18, 15);
            lblTagID.TabIndex = 9;
            lblTagID.Text = "ID";
            // 
            // lblTagType
            // 
            lblTagType.AutoSize = true;
            lblTagType.Location = new Point(13, 200);
            lblTagType.Margin = new Padding(4, 0, 4, 0);
            lblTagType.Name = "lblTagType";
            lblTagType.Size = new Size(71, 15);
            lblTagType.TabIndex = 6;
            lblTagType.Text = "Тип данных";
            // 
            // cmbTagType
            // 
            cmbTagType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTagType.FormattingEnabled = true;
            cmbTagType.Location = new Point(124, 197);
            cmbTagType.Margin = new Padding(4, 3, 4, 3);
            cmbTagType.Name = "cmbTagType";
            cmbTagType.Size = new Size(318, 23);
            cmbTagType.TabIndex = 6;
            // 
            // lblTagDescription
            // 
            lblTagDescription.AutoSize = true;
            lblTagDescription.Location = new Point(13, 139);
            lblTagDescription.Margin = new Padding(4, 0, 4, 0);
            lblTagDescription.Name = "lblTagDescription";
            lblTagDescription.Size = new Size(62, 15);
            lblTagDescription.TabIndex = 5;
            lblTagDescription.Text = "Описание";
            // 
            // txtTagDescription
            // 
            txtTagDescription.Location = new Point(124, 135);
            txtTagDescription.Margin = new Padding(4, 3, 4, 3);
            txtTagDescription.Name = "txtTagDescription";
            txtTagDescription.Size = new Size(318, 23);
            txtTagDescription.TabIndex = 4;
            // 
            // txtTagAddress
            // 
            txtTagAddress.Location = new Point(124, 167);
            txtTagAddress.Margin = new Padding(4, 3, 4, 3);
            txtTagAddress.Name = "txtTagAddress";
            txtTagAddress.Size = new Size(318, 23);
            txtTagAddress.TabIndex = 3;
            // 
            // lblTagAddress
            // 
            lblTagAddress.AutoSize = true;
            lblTagAddress.Location = new Point(13, 170);
            lblTagAddress.Margin = new Padding(4, 0, 4, 0);
            lblTagAddress.Name = "lblTagAddress";
            lblTagAddress.Size = new Size(40, 15);
            lblTagAddress.TabIndex = 2;
            lblTagAddress.Text = "Адрес";
            // 
            // txtTagname
            // 
            txtTagname.Location = new Point(124, 77);
            txtTagname.Margin = new Padding(4, 3, 4, 3);
            txtTagname.Name = "txtTagname";
            txtTagname.Size = new Size(318, 23);
            txtTagname.TabIndex = 1;
            // 
            // lblTagName
            // 
            lblTagName.AutoSize = true;
            lblTagName.Location = new Point(13, 81);
            lblTagName.Margin = new Padding(4, 0, 4, 0);
            lblTagName.Name = "lblTagName";
            lblTagName.Size = new Size(59, 15);
            lblTagName.TabIndex = 0;
            lblTagName.Text = "Название";
            // 
            // tabScaling
            // 
            tabScaling.Controls.Add(gpbScaled);
            tabScaling.Location = new Point(4, 24);
            tabScaling.Name = "tabScaling";
            tabScaling.Padding = new Padding(3);
            tabScaling.Size = new Size(892, 672);
            tabScaling.TabIndex = 1;
            tabScaling.Text = "Масштабирование";
            tabScaling.UseVisualStyleBackColor = true;
            // 
            // gpbScaled
            // 
            gpbScaled.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbScaled.Controls.Add(lblScaled);
            gpbScaled.Controls.Add(cmbScaled);
            gpbScaled.Controls.Add(gpbLineScaled);
            gpbScaled.Controls.Add(txtTagCoefficient);
            gpbScaled.Controls.Add(lblCoefficient);
            gpbScaled.Location = new Point(10, 9);
            gpbScaled.Margin = new Padding(4, 3, 4, 3);
            gpbScaled.Name = "gpbScaled";
            gpbScaled.Padding = new Padding(4, 3, 4, 3);
            gpbScaled.Size = new Size(1464, 246);
            gpbScaled.TabIndex = 2;
            gpbScaled.TabStop = false;
            gpbScaled.Text = "Масштабирование тега";
            // 
            // lblScaled
            // 
            lblScaled.AutoSize = true;
            lblScaled.Location = new Point(13, 47);
            lblScaled.Margin = new Padding(4, 0, 4, 0);
            lblScaled.Name = "lblScaled";
            lblScaled.Size = new Size(112, 15);
            lblScaled.TabIndex = 4;
            lblScaled.Text = "Масштабирование";
            // 
            // cmbScaled
            // 
            cmbScaled.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbScaled.FormattingEnabled = true;
            cmbScaled.Items.AddRange(new object[] { "Нет", "Линейное" });
            cmbScaled.Location = new Point(132, 44);
            cmbScaled.Margin = new Padding(4, 3, 4, 3);
            cmbScaled.Name = "cmbScaled";
            cmbScaled.Size = new Size(202, 23);
            cmbScaled.TabIndex = 3;
            cmbScaled.SelectedIndexChanged += cmbScaled_SelectedIndexChanged;
            // 
            // gpbLineScaled
            // 
            gpbLineScaled.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            gpbLineScaled.Location = new Point(11, 75);
            gpbLineScaled.Margin = new Padding(4, 3, 4, 3);
            gpbLineScaled.Name = "gpbLineScaled";
            gpbLineScaled.Padding = new Padding(4, 3, 4, 3);
            gpbLineScaled.Size = new Size(2022, 164);
            gpbLineScaled.TabIndex = 2;
            gpbLineScaled.TabStop = false;
            gpbLineScaled.Text = "Линейное масштабирование";
            // 
            // lblLineScaledResult
            // 
            lblLineScaledResult.AutoSize = true;
            lblLineScaledResult.Location = new Point(542, 108);
            lblLineScaledResult.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledResult.Name = "lblLineScaledResult";
            lblLineScaledResult.Size = new Size(0, 15);
            lblLineScaledResult.TabIndex = 38;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(523, 108);
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
            lblScaledLowValue_2.Location = new Point(447, 108);
            lblScaledLowValue_2.Margin = new Padding(4, 0, 4, 0);
            lblScaledLowValue_2.Name = "lblScaledLowValue_2";
            lblScaledLowValue_2.Size = new Size(63, 15);
            lblScaledLowValue_2.TabIndex = 36;
            lblScaledLowValue_2.Text = "ScaledLow";
            // 
            // lblPlus
            // 
            lblPlus.AutoSize = true;
            lblPlus.Location = new Point(428, 108);
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
            lblBracket_5.Location = new Point(410, 108);
            lblBracket_5.Margin = new Padding(4, 0, 4, 0);
            lblBracket_5.Name = "lblBracket_5";
            lblBracket_5.Size = new Size(11, 15);
            lblBracket_5.TabIndex = 34;
            lblBracket_5.Text = ")";
            // 
            // lblBracket_4
            // 
            lblBracket_4.AutoSize = true;
            lblBracket_4.Location = new Point(391, 108);
            lblBracket_4.Margin = new Padding(4, 0, 4, 0);
            lblBracket_4.Name = "lblBracket_4";
            lblBracket_4.Size = new Size(11, 15);
            lblBracket_4.TabIndex = 33;
            lblBracket_4.Text = ")";
            // 
            // lblRowLowValue_2
            // 
            lblRowLowValue_2.AutoSize = true;
            lblRowLowValue_2.Location = new Point(327, 108);
            lblRowLowValue_2.Margin = new Padding(4, 0, 4, 0);
            lblRowLowValue_2.Name = "lblRowLowValue_2";
            lblRowLowValue_2.Size = new Size(52, 15);
            lblRowLowValue_2.TabIndex = 32;
            lblRowLowValue_2.Text = "RowLow";
            // 
            // lblLineScaledMinus_3
            // 
            lblLineScaledMinus_3.AutoSize = true;
            lblLineScaledMinus_3.Location = new Point(308, 108);
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
            lblLineScaledValue.Location = new Point(261, 108);
            lblLineScaledValue.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledValue.Name = "lblLineScaledValue";
            lblLineScaledValue.Size = new Size(35, 15);
            lblLineScaledValue.TabIndex = 30;
            lblLineScaledValue.Text = "Value";
            // 
            // lblBracket_3
            // 
            lblBracket_3.AutoSize = true;
            lblBracket_3.Location = new Point(243, 108);
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
            lblLineScalEdincrease.Location = new Point(223, 108);
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
            lblBracket_1.Location = new Point(22, 108);
            lblBracket_1.Margin = new Padding(4, 0, 4, 0);
            lblBracket_1.Name = "lblBracket_1";
            lblBracket_1.Size = new Size(11, 15);
            lblBracket_1.TabIndex = 27;
            lblBracket_1.Text = "(";
            // 
            // lblBracket_2
            // 
            lblBracket_2.AutoSize = true;
            lblBracket_2.Location = new Point(34, 108);
            lblBracket_2.Margin = new Padding(4, 0, 4, 0);
            lblBracket_2.Name = "lblBracket_2";
            lblBracket_2.Size = new Size(11, 15);
            lblBracket_2.TabIndex = 26;
            lblBracket_2.Text = "(";
            // 
            // lblLineScaledMinus_4
            // 
            lblLineScaledMinus_4.AutoSize = true;
            lblLineScaledMinus_4.Location = new Point(126, 127);
            lblLineScaledMinus_4.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledMinus_4.Name = "lblLineScaledMinus_4";
            lblLineScaledMinus_4.Size = new Size(12, 15);
            lblLineScaledMinus_4.TabIndex = 25;
            lblLineScaledMinus_4.Text = "-";
            // 
            // lblLineScaledDivision_1
            // 
            lblLineScaledDivision_1.AutoSize = true;
            lblLineScaledDivision_1.Location = new Point(47, 103);
            lblLineScaledDivision_1.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledDivision_1.Name = "lblLineScaledDivision_1";
            lblLineScaledDivision_1.Size = new Size(122, 15);
            lblLineScaledDivision_1.TabIndex = 24;
            lblLineScaledDivision_1.Text = "_______________________";
            // 
            // lblLineScaledMinus_1
            // 
            lblLineScaledMinus_1.AutoSize = true;
            lblLineScaledMinus_1.Location = new Point(126, 88);
            lblLineScaledMinus_1.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledMinus_1.Name = "lblLineScaledMinus_1";
            lblLineScaledMinus_1.Size = new Size(12, 15);
            lblLineScaledMinus_1.TabIndex = 23;
            lblLineScaledMinus_1.Text = "-";
            // 
            // lblRowLowValue
            // 
            lblRowLowValue.AutoSize = true;
            lblRowLowValue.Location = new Point(145, 127);
            lblRowLowValue.Margin = new Padding(4, 0, 4, 0);
            lblRowLowValue.Name = "lblRowLowValue";
            lblRowLowValue.Size = new Size(52, 15);
            lblRowLowValue.TabIndex = 22;
            lblRowLowValue.Text = "RowLow";
            // 
            // lblRowHighValue
            // 
            lblRowHighValue.AutoSize = true;
            lblRowHighValue.Location = new Point(47, 127);
            lblRowHighValue.Margin = new Padding(4, 0, 4, 0);
            lblRowHighValue.Name = "lblRowHighValue";
            lblRowHighValue.Size = new Size(56, 15);
            lblRowHighValue.TabIndex = 21;
            lblRowHighValue.Text = "RowHigh";
            // 
            // lblScaledLowValue
            // 
            lblScaledLowValue.AutoSize = true;
            lblScaledLowValue.Location = new Point(145, 88);
            lblScaledLowValue.Margin = new Padding(4, 0, 4, 0);
            lblScaledLowValue.Name = "lblScaledLowValue";
            lblScaledLowValue.Size = new Size(63, 15);
            lblScaledLowValue.TabIndex = 20;
            lblScaledLowValue.Text = "ScaledLow";
            // 
            // lblScaledHighValue
            // 
            lblScaledHighValue.AutoSize = true;
            lblScaledHighValue.Location = new Point(47, 88);
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
            btnCalcLineScaled.Text = "Рассчитать";
            btnCalcLineScaled.UseVisualStyleBackColor = true;
            btnCalcLineScaled.Click += btn_CalcLineScaled_Click;
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
            lblLineScaledVal.Location = new Point(391, 25);
            lblLineScaledVal.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledVal.Name = "lblLineScaledVal";
            lblLineScaledVal.Size = new Size(35, 15);
            lblLineScaledVal.TabIndex = 16;
            lblLineScaledVal.Text = "Value";
            // 
            // lblLineScaledHigh
            // 
            lblLineScaledHigh.AutoSize = true;
            lblLineScaledHigh.Location = new Point(200, 55);
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
            lblLineScaledLow.Location = new Point(200, 25);
            lblLineScaledLow.Margin = new Padding(4, 0, 4, 0);
            lblLineScaledLow.Name = "lblLineScaledLow";
            lblLineScaledLow.Size = new Size(66, 15);
            lblLineScaledLow.TabIndex = 12;
            lblLineScaledLow.Text = "Scaled Low";
            // 
            // lblLineScaledRowHigh
            // 
            lblLineScaledRowHigh.AutoSize = true;
            lblLineScaledRowHigh.Location = new Point(22, 55);
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
            lblLineScaledRowLow.Location = new Point(22, 25);
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
            // 
            // lblCoefficient
            // 
            lblCoefficient.AutoSize = true;
            lblCoefficient.Location = new Point(13, 22);
            lblCoefficient.Margin = new Padding(4, 0, 4, 0);
            lblCoefficient.Name = "lblCoefficient";
            lblCoefficient.Size = new Size(84, 15);
            lblCoefficient.TabIndex = 0;
            lblCoefficient.Text = "Коэффициент";
            // 
            // txtTagCode
            // 
            txtTagCode.Location = new Point(124, 106);
            txtTagCode.Margin = new Padding(4, 3, 4, 3);
            txtTagCode.Name = "txtTagCode";
            txtTagCode.Size = new Size(318, 23);
            txtTagCode.TabIndex = 60;
            // 
            // lblTagCode
            // 
            lblTagCode.AutoSize = true;
            lblTagCode.Location = new Point(13, 109);
            lblTagCode.Margin = new Padding(4, 0, 4, 0);
            lblTagCode.Name = "lblTagCode";
            lblTagCode.Size = new Size(27, 15);
            lblTagCode.TabIndex = 59;
            lblTagCode.Text = "Код";
            // 
            // uscTag
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabTag);
            Name = "uscTag";
            Size = new Size(900, 700);
            Load += uscTag_Load;
            cmnuTag.ResumeLayout(false);
            tabTag.ResumeLayout(false);
            tabSettings.ResumeLayout(false);
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
        private ContextMenuStrip cmnuTag;
        private ToolStripMenuItem tolRegisterRefresh;
        private ToolStripSeparator tolSeparator1;
        private ToolStripMenuItem tolTagAdd;
        private ToolStripMenuItem tolTagChange;
        private ToolStripMenuItem tolTagDelete;
        private ToolStripMenuItem tolTagDeleteAll;
        private ToolStripSeparator tolSeparator2;
        private ToolStripMenuItem сортировкаToolStripMenuItem;
        private ToolStripMenuItem tolTagSortDefault;
        private ToolStripMenuItem tolTagSortTagAddress;
        private ToolStripMenuItem tolTagSortTagName;
        private ToolStripMenuItem tolTagSortTagDescription;
        private ToolStripMenuItem tolTagSortTagType;
        private ToolStripMenuItem tolTagSortTagValue;
        private ToolStripSeparator tolSeparator3;
        private ToolStripSeparator tolSeparator4;
        private ToolStripMenuItem tolTagImport;
        private ToolStripMenuItem tolCSV;
        private ToolStripMenuItem tolDataLoadAsCSV;
        private ToolStripMenuItem tolDataSaveAsCSV;
        private System.Windows.Forms.Timer tmrTimer;
        private ToolStripMenuItem tolTagUp;
        private ToolStripMenuItem tolTagDown;
        private ToolStripSeparator toolStripSeparator1;
        private TabControl tabTag;
        private TabPage tabSettings;
        private Button btnTagSave;
        private GroupBox gpbTagProperty;
        private Label lblTagSorting;
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
        private TextBox txtTagSorting;
        private TextBox txtTagCode;
        private Label lblTagCode;
    }
}
