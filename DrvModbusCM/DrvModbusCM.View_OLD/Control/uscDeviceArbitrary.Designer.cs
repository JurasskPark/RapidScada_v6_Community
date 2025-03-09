namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    partial class uscDeviceArbitrary
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
            txtCommand = new TextBox();
            cmbFunctionCode = new ComboBox();
            gpbGroup = new GroupBox();
            ckbEnabled = new CheckBox();
            lblNameGroup = new Label();
            txtName = new TextBox();
            btnSave = new Button();
            gpbCommand.SuspendLayout();
            gpbGroup.SuspendLayout();
            SuspendLayout();
            // 
            // gpbCommand
            // 
            gpbCommand.Controls.Add(txtCommand);
            gpbCommand.Controls.Add(cmbFunctionCode);
            gpbCommand.Location = new Point(4, 77);
            gpbCommand.Margin = new Padding(4, 3, 4, 3);
            gpbCommand.Name = "gpbCommand";
            gpbCommand.Padding = new Padding(4, 3, 4, 3);
            gpbCommand.Size = new Size(439, 235);
            gpbCommand.TabIndex = 26;
            gpbCommand.TabStop = false;
            gpbCommand.Text = "Параметры";
            // 
            // txtCommand
            // 
            txtCommand.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            txtCommand.Location = new Point(7, 53);
            txtCommand.Margin = new Padding(4, 3, 4, 3);
            txtCommand.Multiline = true;
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(424, 170);
            txtCommand.TabIndex = 23;
            // 
            // cmbFunctionCode
            // 
            cmbFunctionCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFunctionCode.DropDownWidth = 350;
            cmbFunctionCode.Enabled = false;
            cmbFunctionCode.FlatStyle = FlatStyle.Flat;
            cmbFunctionCode.FormattingEnabled = true;
            cmbFunctionCode.Items.AddRange(new object[] { "(01) — Чтение регистров флагов (Read Coils) ", "(02) — Чтение дискретных входов (Read Discrete Inputs)", "(03) — Чтение регистров хранения (Read Holding Registers)", "(04) — Чтение регистров ввода (Read Input Registers)", "(05) — Запись одного флага (Force Single Coil)", "(06) — Запись регистр хранения (Preset Single Register)", "(07) — Чтение сигналов состояния (Read Exception Status)", "(08) — Диагностика (Diagnostic)", "(11) — Чтение счетчика событий (Get Com Event Counter)", "(12) — Чтение журнала событий (Get Com Event Log)", "(15) — Запись регистров флагов (Write Multiple Coils)", "(16) — Запись регистров хранения (Write Multiple Holding Registers)", "(17) — Чтение информации об устройстве (Report Slave ID)", "(20) — Чтение из файла (Read File Record)", "(21) — Запись в файл (Write File Record)", "(22) — Запись в один регистр хранения (Mask Write Register)", "(24) — Чтение данных из очереди (Read FIFO Queue)", "(43) — Encapsulated Interface Transport", "(99) — Произвольная команда" });
            cmbFunctionCode.Location = new Point(7, 22);
            cmbFunctionCode.Margin = new Padding(4, 3, 4, 3);
            cmbFunctionCode.Name = "cmbFunctionCode";
            cmbFunctionCode.Size = new Size(424, 23);
            cmbFunctionCode.TabIndex = 22;
            // 
            // gpbGroup
            // 
            gpbGroup.Controls.Add(ckbEnabled);
            gpbGroup.Controls.Add(lblNameGroup);
            gpbGroup.Controls.Add(txtName);
            gpbGroup.Location = new Point(4, 3);
            gpbGroup.Margin = new Padding(4, 3, 4, 3);
            gpbGroup.Name = "gpbGroup";
            gpbGroup.Padding = new Padding(4, 3, 4, 3);
            gpbGroup.Size = new Size(439, 67);
            gpbGroup.TabIndex = 23;
            gpbGroup.TabStop = false;
            // 
            // ckbEnabled
            // 
            ckbEnabled.AutoSize = true;
            ckbEnabled.Location = new Point(330, 35);
            ckbEnabled.Margin = new Padding(4, 3, 4, 3);
            ckbEnabled.Name = "ckbEnabled";
            ckbEnabled.Size = new Size(78, 19);
            ckbEnabled.TabIndex = 13;
            ckbEnabled.Text = "Активное";
            ckbEnabled.UseVisualStyleBackColor = true;
            // 
            // lblNameGroup
            // 
            lblNameGroup.AutoSize = true;
            lblNameGroup.Location = new Point(8, 13);
            lblNameGroup.Margin = new Padding(4, 0, 4, 0);
            lblNameGroup.Name = "lblNameGroup";
            lblNameGroup.Size = new Size(90, 15);
            lblNameGroup.TabIndex = 2;
            lblNameGroup.Text = "Наименование";
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
            btnSave.Location = new Point(451, 10);
            btnSave.Margin = new Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(107, 27);
            btnSave.TabIndex = 25;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            // 
            // uscDeviceArbitrary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gpbCommand);
            Controls.Add(gpbGroup);
            Controls.Add(btnSave);
            Name = "uscDeviceArbitrary";
            Size = new Size(800, 700);
            gpbCommand.ResumeLayout(false);
            gpbCommand.PerformLayout();
            gpbGroup.ResumeLayout(false);
            gpbGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbCommand;
        private TextBox txtCommand;
        private ComboBox cmbFunctionCode;
        private GroupBox gpbGroup;
        private CheckBox ckbEnabled;
        private Label lblNameGroup;
        private TextBox txtName;
        private Button btnSave;
    }
}
