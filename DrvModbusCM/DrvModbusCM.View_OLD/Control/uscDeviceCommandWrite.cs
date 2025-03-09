using System.Data;
using System.Text.RegularExpressions;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscCommandWrite : UserControl
    {
        public uscCommandWrite()
        {
            InitializeComponent();
        }

        #region Комманда

        #region Form

        public bool modified;                          // the configuration was modified

        #endregion Form

        private ProjectNodeData mtNodeData;
        public ProjectNodeData MTNodeData
        {
            get { return mtNodeData; }
            set { mtNodeData = value; }
        }

        //ID устройства
        private Guid deviceID;
        public Guid DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }

        //ID команды
        private Guid commandID;
        public Guid CommandID
        {
            get { return commandID; }
            set { commandID = value; }
        }

        //Название команды
        private string commandName;
        public string CommandName
        {
            get { return commandName; }
            set { commandName = value; }
        }

        //Описание команды
        private string commandDescription;
        public string CommandDescription
        {
            get { return commandDescription; }
            set { commandDescription = value; }
        }

        //Состояние команды. Включено ли команда и отправлять ли её
        private bool commandEnabled;
        public bool CommandEnabled
        {
            get { return commandEnabled; }
            set { commandEnabled = value; }
        }

        //Команда
        private ulong tmp_commandFunctionCode;
        private ulong commandFunctionCode;
        public ulong CommandFunctionCode
        {
            get { return commandFunctionCode; }
            set { commandFunctionCode = value; }
        }

        private ulong tmp_commandRegisterStartAddress;
        private ulong commandRegisterStartAddress;
        public ulong CommandRegisterStartAddress
        {
            get { return commandRegisterStartAddress; }
            set { commandRegisterStartAddress = value; }
        }

        private ulong upDownRegisterStartAddressValue;
        public ulong UpDownRegisterStartAddressValue
        {
            get { return this.upDownRegisterStartAddressValue; }
            set
            {
                if (value > this.upDownRegisterStartAddressValue)
                {
                    //It increased
                    DataTableCalculate();
                }

                if (value < this.upDownRegisterStartAddressValue)
                {
                    //It decreased
                    DataTableCalculate();
                }

                this.upDownRegisterStartAddressValue = value;
            }
        }

        private ulong tmp_commandRegisterCount;
        private ulong commandRegisterCount;
        public ulong CommandRegisterCount
        {
            get { return commandRegisterCount; }
            set { commandRegisterCount = value; }
        }

        private ulong upDownRegisterCountValue;
        public ulong UpDownRegisterCountValue
        {
            get { return this.upDownRegisterCountValue; }
            set
            {
                if (value > this.upDownRegisterCountValue)
                {
                    //Значение стало больше, поэтому добавляем строку
                    DataTableAddRow();
                }

                if (value < this.upDownRegisterCountValue)
                {
                    //Значение стало меньше, поэтому удаляем строку
                    DataTableDeleteRow();
                }

                this.upDownRegisterCountValue = value;
            }
        }

        private string[] commandRegisterNameReadData;
        public string[] CommandRegisterNameReadData
        {
            get { return commandRegisterNameReadData; }
            set { commandRegisterNameReadData = value; }
        }

        private ulong[] commandRegisterReadData;
        public ulong[] CommandRegisterReadData
        {
            get { return commandRegisterReadData; }
            set { commandRegisterReadData = value; }
        }

        private string[] commandRegisterNameWriteData;
        public string[] CommandRegisterNameWriteData
        {
            get { return commandRegisterNameWriteData; }
            set { commandRegisterNameWriteData = value; }
        }

        private ulong[] commandRegisterWriteData;
        public ulong[] CommandRegisterWriteData
        {
            get { return commandRegisterWriteData; }
            set { commandRegisterWriteData = value; }
        }

        private ulong commandParametr;
        public ulong CommandParametr
        {
            get { return commandParametr; }
            set { commandParametr = value; }
        }


        //Таблица, где находятся поля CommandRegisterWriteData
        DataTable dt_CommandRegisterWriteData = new DataTable();

        #endregion Комманда

        public uscCommandWrite(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            //DeviceID = ProjectNodeData.command.DeviceID;
            //CommandID = ProjectNodeData.command.CommandID;
            CommandName = ProjectNodeData.command.CommandName;
            CommandDescription = ProjectNodeData.command.CommandDescription;
            CommandEnabled = ProjectNodeData.command.CommandEnabled;
            CommandFunctionCode = ProjectNodeData.command.CommandFunctionCode;
            tmp_commandFunctionCode = ProjectNodeData.command.CommandFunctionCode;
            CommandRegisterStartAddress = ProjectNodeData.command.CommandRegisterStartAddress;
            CommandRegisterCount = ProjectNodeData.command.CommandRegisterCount;
            CommandRegisterNameReadData = ProjectNodeData.command.CommandRegisterNameReadData;
            CommandRegisterReadData = ProjectNodeData.command.CommandRegisterReadData;
            CommandRegisterNameWriteData = ProjectNodeData.command.CommandRegisterNameWriteData;
            CommandRegisterWriteData = ProjectNodeData.command.CommandRegisterWriteData;
            CommandParametr = ProjectNodeData.command.CommandParametr;

            InitializeComponent();
            FormatWindow(true);
        }

        public uscCommandWrite(ushort function = 0)
        {
            InitializeComponent();
            FormatWindow(true);
            CommandFunctionCode = function;
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.BorderStyle = BorderStyle.None;
                btnCommandSave.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
            }
        }

        private void ConfigToControls()
        {
            txtCommandName.Text = CommandName;
            ckbCommandEnabled.Checked = CommandEnabled;

            nudRegisterStartAddress.Value = CommandRegisterStartAddress;

            //Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            nudRegisterCount.Minimum = 0;
            nudRegisterCount.Value = CommandRegisterCount;
            //А вот потом говорим, что так делать нельзя :)
            nudRegisterCount.Minimum = 1;

            //Сначала подставляем значения, а потом делаем поиск по index 
            try
            {
                string find_FunctionCode = "(" + CommandFunctionCode.ToString().PadLeft(2, '0') + ")";
                //Находим индекс        
                int index_combobox = cmbFunctionCode.FindString(find_FunctionCode);
                //Отображаем
                cmbFunctionCode.SelectedIndex = index_combobox;
            }
            catch { }

            //Загрузка значений
            dgvRegisterValueLoad();
            //После загрузки значений проверяем какая функция от этого скрываем или показываем необходимые столбцы
            if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
            {
                if (dgv_RegisterValue.Rows.Count > 0)
                {
                    dgv_RegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец
                }
            }
            else if (tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 16)
            {
                if (dgv_RegisterValue.Rows.Count > 0)
                {
                    dgv_RegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                }
            }
            else
            {
                if (dgv_RegisterValue.Rows.Count > 0)
                {
                    dgv_RegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец           
                }
                return;
            }
        }

        private void ControlsToConfig()
        {
            CommandName = txtCommandName.Text;
            CommandEnabled = ckbCommandEnabled.Checked;
            //Код функции
            try
            {
                string permennaya = cmbFunctionCode.Items[cmbFunctionCode.SelectedIndex].ToString().Trim();
                //Ищем последовательность в цифрах
                Regex regex = new Regex(@"([A-Fa-f0-9][A-Fa-f0-9])");
                Match match = regex.Match(permennaya);
                if (match.Success)
                {
                    //Получили match.Value со значением
                    CommandFunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }
            CommandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            CommandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            //Сохранение значений
            dgv_RegisterValueSave();
        }


        private void btnCommandSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ConfigToControls();

            if (commandName == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }
            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form

            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            //projectNodeData.command.DeviceID = DeviceID;
            //projectNodeData.command.CommandID = CommandID;
            projectNodeData.command.CommandName = CommandName;
            projectNodeData.command.CommandDescription = CommandDescription;
            projectNodeData.command.CommandEnabled = CommandEnabled;
            projectNodeData.command.CommandFunctionCode = CommandFunctionCode;
            projectNodeData.command.CommandRegisterStartAddress = CommandRegisterStartAddress;
            projectNodeData.command.CommandRegisterCount = CommandRegisterCount;
            projectNodeData.command.CommandRegisterNameReadData = CommandRegisterNameReadData;
            projectNodeData.command.CommandRegisterReadData = CommandRegisterReadData;
            projectNodeData.command.CommandRegisterNameWriteData = CommandRegisterNameWriteData;
            projectNodeData.command.CommandRegisterWriteData = CommandRegisterWriteData;
            projectNodeData.command.CommandParametr = CommandParametr;

            //Условия иконки 
            switch (CommandFunctionCode)
            {
                case 0:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_00_16.png";
                    break;
                case 1:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_01_16.png";
                    break;
                case 2:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_02_16.png";
                    break;
                case 3:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_03_16.png";
                    break;
                case 4:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_04_16.png";
                    break;
                case 5:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_05_16.png";
                    break;
                case 6:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_06_16.png";
                    break;
                case 7:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_07_16.png";
                    break;
                case 8:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_08_16.png";
                    break;
                case 11:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_11_16.png";
                    break;
                case 12:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_12_16.png";
                    break;
                case 15:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_15_16.png";
                    break;
                case 16:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_16_16.png";
                    break;
                case 17:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_17_16.png";
                    break;
                case 20:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_20_16.png";
                    break;
                case 21:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_21_16.png";
                    break;
                case 22:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_22_16.png";
                    break;
                case 24:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_24_16.png";
                    break;
                case 43:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_43_16.png";
                    break;
                case 99:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_99_16.png";
                    break;
                default:
                    projectNodeData.command.KeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_00_16.png";
                    break;
            }

            stn.Text = CommandName;
            stn.Tag = projectNodeData;
        }

        #region Изменение Функции
        private void cmbFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Код функции
            try
            {
                string permennaya = cmbFunctionCode.Items[cmbFunctionCode.SelectedIndex].ToString().Trim();
                //Ищем последовательность в цифрах
                Regex regex = new Regex(@"([A-Fa-f0-9][A-Fa-f0-9])");
                Match match = regex.Match(permennaya);
                if (match.Success)
                {
                    //Получили match.Value со значением
                    tmp_commandFunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }

            //Скрываем\Показываем отображение dgv_RegisterValue для ввода значений
            if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 15 || tmp_commandFunctionCode == 16)
            {
                dgv_RegisterValue.Visible = true;

                if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
                {
                    dgv_RegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец

                }
                else if (tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 16)
                {
                    dgv_RegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                }
                else
                {
                    dgv_RegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                    return;
                }
            }
            else
            {
                //Скрываем таблицу
                dgv_RegisterValue.Visible = false;
            }

            //Если записывается один регистр, функция 5,6 то заблокируем изменение количества регистров
            if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 6)
            {
                nudRegisterCount.Enabled = false;
                nudRegisterCount.Value = 1;
            }
            else
            {
                nudRegisterCount.Enabled = true;
            }

            tmp_commandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_commandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);

            if (tmp_commandFunctionCode == 5)
            {
                ushort RegisterValue = 0;

                if (dt_CommandRegisterWriteData.Rows.Count != 0)
                {
                    RegisterValue = Convert.ToUInt16(dt_CommandRegisterWriteData.Rows[0][2]);
                }

                dt_CommandRegisterWriteData.Rows.Clear();
                DataTableAddRow();

                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_CommandRegisterWriteData.Rows[i][0] = "Coil";
                    dt_CommandRegisterWriteData.Rows[i][1] = (ulong)CommandRegisterStartAddress + (ulong)i;
                }

                if (dt_CommandRegisterWriteData.Rows.Count != 0)
                {
                    dt_CommandRegisterWriteData.Rows[0][2] = RegisterValue;
                }
            }
            else if (tmp_commandFunctionCode == 6)
            {
                ushort RegisterValue = 0;

                if (dt_CommandRegisterWriteData.Rows.Count != 0)
                {
                    RegisterValue = Convert.ToUInt16(dt_CommandRegisterWriteData.Rows[0][2]);
                }

                dt_CommandRegisterWriteData.Rows.Clear();
                DataTableAddRow();

                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_CommandRegisterWriteData.Rows[i][0] = "HoldingRegister";
                    dt_CommandRegisterWriteData.Rows[i][1] = (ulong)CommandRegisterStartAddress + (ulong)i;
                }

                if (dt_CommandRegisterWriteData.Rows.Count != 0)
                {
                    dt_CommandRegisterWriteData.Rows[0][2] = RegisterValue;
                }
            }
            else if (tmp_commandFunctionCode == 15)
            {
                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_CommandRegisterWriteData.Rows[i][0] = "Coil";
                    dt_CommandRegisterWriteData.Rows[i][1] = (ulong)CommandRegisterStartAddress + (ulong)i;
                }
            }
            else if (tmp_commandFunctionCode == 16)
            {
                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_CommandRegisterWriteData.Rows[i][0] = "HoldingRegister";
                    dt_CommandRegisterWriteData.Rows[i][1] = (ulong)CommandRegisterStartAddress + (ulong)i;
                }
            }

            //Генерация имени
            GenerateName(out string nameCommand);
            //Рассчет
            DataTableCalculate();
        }
        #endregion Изменение Функции

        #region Изменение Начального адреса регистра

        private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            tmp_commandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_commandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterStartAddressValue = tmp_commandRegisterStartAddress;
            GenerateName(out string nameCommand);
            DataTableCalculate();
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            tmp_commandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_commandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterCountValue = tmp_commandRegisterCount;
            GenerateName(out string nameCommand);
            DataTableCalculate();
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        public void GenerateName(out string nameCommand)
        {
            nameCommand = "Команда:[" + tmp_commandFunctionCode + "][" + tmp_commandRegisterStartAddress + "][" + tmp_commandRegisterCount + "]";
            txtCommandName.Text = nameCommand;
        }

        #endregion Генерация имени команды

        #region Добавление строки в таблицу 
        private void DataTableAddRow()
        {
            try
            {
                string tmp_DataType = string.Empty;

                if (dt_CommandRegisterWriteData == null)
                {
                    dt_CommandRegisterWriteData = new DataTable();
                }

                if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 15 || tmp_commandFunctionCode == 16)
                {
                    dgv_RegisterValue.Visible = true;

                    if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
                    {
                        dgv_RegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                        dgv_RegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец

                    }
                    else if (tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 16)
                    {
                        dgv_RegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                        dgv_RegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                    }
                    else
                    {
                        dgv_RegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                        dgv_RegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                        return;
                    }
                }

                DataColumnCollection columns = dt_CommandRegisterWriteData.Columns;

                DataColumn RegisterColumnType = new DataColumn();
                RegisterColumnType.ColumnName = "DataType";
                RegisterColumnType.Caption = "Тип данных";

                DataColumn RegisterColumn = new DataColumn();
                RegisterColumn.ColumnName = "Register";
                RegisterColumn.Caption = "Регистр";

                DataColumn RegisterColumnValue = new DataColumn();
                RegisterColumnValue.ColumnName = "Value";
                RegisterColumnValue.Caption = "Значение";

                //Признак того, что функция Coil и тип столбца должен быть
                DataColumn RegisterColumnCheckValue = new DataColumn();
                RegisterColumnCheckValue.ColumnName = "ValueCheck";
                RegisterColumnCheckValue.Caption = "Значение";


                if (!columns.Contains(RegisterColumn.ColumnName) || !columns.Contains(RegisterColumnType.ColumnName) || !columns.Contains(RegisterColumnValue.ColumnName) || !columns.Contains(RegisterColumnCheckValue.ColumnName))
                {
                    try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                    try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                    try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                    try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                }

                string RegisterColumnName = string.Empty;
                if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
                {
                    RegisterColumnName = "Coil";
                }
                if (tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 16)
                {
                    RegisterColumnName = "HoldingRegister";
                }

                dt_CommandRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

                dgv_RegisterValue.DataSource = dt_CommandRegisterWriteData;

                dgv_RegisterValueBlockingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion Добавление строки в таблицу 

        #region Удаление строки из таблицы
        private void DataTableDeleteRow()
        {
            try
            {
                if (dt_CommandRegisterWriteData == null)
                {
                    dt_CommandRegisterWriteData = new DataTable();
                }

                if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 15 || tmp_commandFunctionCode == 16)
                {
                    dgv_RegisterValue.Visible = true;
                }

                if (dt_CommandRegisterWriteData.Rows.Count <= 1)
                {
                    //Записей 1 шт, не будем удалять
                    return;
                }
                else
                {
                    //Удаляем последнюю запись
                    dt_CommandRegisterWriteData.Rows.RemoveAt((int)dt_CommandRegisterWriteData.Rows.Count - 1);
                }

                dgv_RegisterValue.DataSource = dt_CommandRegisterWriteData;

                dgv_RegisterValueBlockingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion Удаление строки из таблицы

        #region Пересчет строк в таблицах во время изменения Начального адреса регистра, Количества регистров, Номера функции, Типа данных
        private void DataTableCalculate()
        {
            string RegisterColumnName = string.Empty;
            if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
            {
                RegisterColumnName = "Coil";
            }
            else if (tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 16)
            {
                RegisterColumnName = "HoldingRegister";
            }
            else
            {
                return;
            }

            ulong DifferenceValues = (ulong)tmp_commandRegisterCount - (ulong)dt_CommandRegisterWriteData.Rows.Count;
            if (DifferenceValues > 0)
            {
                //Добавляем записи
                for (ulong i = 0; i < DifferenceValues; i++)
                {
                    DataColumnCollection columns = dt_CommandRegisterWriteData.Columns;

                    DataColumn RegisterColumnType = new DataColumn();
                    RegisterColumnType.ColumnName = "DataType";
                    RegisterColumnType.Caption = "Тип данных";

                    DataColumn RegisterColumn = new DataColumn();
                    RegisterColumn.ColumnName = "Register";
                    RegisterColumn.Caption = "Регистр";

                    DataColumn RegisterColumnValue = new DataColumn();
                    RegisterColumnValue.ColumnName = "Value";
                    RegisterColumnValue.Caption = "Значение";

                    //Признак того, что функция Coil и тип столбца должен быть
                    DataColumn RegisterColumnCheckValue = new DataColumn();
                    RegisterColumnCheckValue.ColumnName = "ValueCheck";
                    RegisterColumnCheckValue.Caption = "Значение";


                    if (!columns.Contains(RegisterColumn.ColumnName) || !columns.Contains(RegisterColumnType.ColumnName) || !columns.Contains(RegisterColumnValue.ColumnName) || !columns.Contains(RegisterColumnCheckValue.ColumnName))
                    {
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                    }

                    dt_CommandRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

                    dgv_RegisterValueBlockingColumn();
                }
            }
            else if (DifferenceValues < 0)
            {
                for (ulong i = DifferenceValues; i < 0; i++)
                {
                    if (dt_CommandRegisterWriteData.Rows.Count <= 1)
                    {
                        //Записей 1 шт, не будем удалять
                        return;
                    }
                    else
                    {
                        //Удаляем последнюю запись
                        dt_CommandRegisterWriteData.Rows.RemoveAt((int)dt_CommandRegisterWriteData.Rows.Count - 1);
                        dgv_RegisterValueBlockingColumn();
                    }
                }
            }

            for (int i = 0; i < dt_CommandRegisterWriteData.Rows.Count; i++)
            {
                string tmp_RegisterColumnName = (string)dt_CommandRegisterWriteData.Rows[i][0];
                if (tmp_RegisterColumnName != "Coil" || tmp_RegisterColumnName != "HoldingRegister")
                {
                    dt_CommandRegisterWriteData.Rows[i][0] = tmp_RegisterColumnName;
                }
                else
                {
                    dt_CommandRegisterWriteData.Rows[i][0] = RegisterColumnName;
                }

                dt_CommandRegisterWriteData.Rows[i][1] = (ulong)tmp_commandRegisterStartAddress + (ulong)i;
                dt_CommandRegisterWriteData.Rows[i][2] = 0;
            }

            dgv_RegisterValueBlockingColumn();
        }

        private void dgv_RegisterValue_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_RegisterValue.CurrentCell.ColumnIndex == 0) //1 Столбец
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(AnyColumnKeyPress0);
                    DataTableValidateValue();
                }
            }


            if (dgv_RegisterValue.CurrentCell.ColumnIndex == 2) //3 Столбец
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(AnyColumnKeyPress2);
                    DataTableValidateValue();
                }
            }
        }

        private void dgv_RegisterValue_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataTableValidateValue();
        }

        private void dgv_RegisterValueBlockingColumn()
        {
            if (dgv_RegisterValue.Columns.Count >= 2)
            {
                dgv_RegisterValue.Columns[1].ReadOnly = true;
            }
        }

        private void AnyColumnKeyPress0(object sender, KeyPressEventArgs e)
        {
            //Запрещаем вносить в 1 столбец пробел
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar == 32 /*Пробел*/)
            {
                e.Handled = true;
            }
        }

        private void AnyColumnKeyPress2(object sender, KeyPressEventArgs e)
        {
            //Запрещаем вносить в 3 столбец всё кроме цифр и удалять знаки
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 8 /*Удаление*/ &&
                e.KeyChar != 48 /*Цифра 0*/ &&
                e.KeyChar != 49 /*Цифра 1*/ &&
                e.KeyChar != 50 /*Цифра 2*/ &&
                e.KeyChar != 51 /*Цифра 3*/ &&
                e.KeyChar != 52 /*Цифра 4*/ &&
                e.KeyChar != 53 /*Цифра 5*/ &&
                e.KeyChar != 54 /*Цифра 6*/ &&
                e.KeyChar != 55 /*Цифра 7*/ &&
                e.KeyChar != 56 /*Цифра 8*/ &&
                e.KeyChar != 57 /*Цифра 9*/
                )
            {
                e.Handled = true;
            }
        }

        private void dgv_RegisterValue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                this.dgv_RegisterValue.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            var senderGrid = (DataGridView)sender;
            senderGrid.EndEdit();

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {

                var cbxCell = (DataGridViewCheckBoxCell)senderGrid.Rows[e.RowIndex].Cells[3];
                if ((bool)cbxCell.Value)
                {
                    senderGrid.Rows[e.RowIndex].Cells[2].Value = 65280;
                }
                else
                {
                    senderGrid.Rows[e.RowIndex].Cells[2].Value = 0;
                }
            }
        }

        #endregion Пересчет строк в таблицах во время изменения Начального адреса регистра, Количества регистров, Номера функции, Типа данных

        #region Проверка данных на валидность

        private bool DataTableValidateValue()
        {
            int Validate = 0;

            for (int i = 0; i < dt_CommandRegisterWriteData.Rows.Count; i++)
            {
                bool tmp_TryParse = int.TryParse(dgv_RegisterValue.Rows[i].Cells[2].Value.ToString(), out Validate);

                if (!tmp_TryParse)
                {
                    dgv_RegisterValue.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                    dgv_RegisterValue.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    dgv_RegisterValue.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                    Validate++;
                }
                else
                {
                    if (Convert.ToInt32(dgv_RegisterValue.Rows[i].Cells[2].Value) < 0 || Convert.ToInt32(dgv_RegisterValue.Rows[i].Cells[2].Value) > 65535)
                    {
                        dgv_RegisterValue.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                        dgv_RegisterValue.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                        dgv_RegisterValue.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                        Validate++;
                    }
                    else if (Convert.ToInt32(dgv_RegisterValue.Rows[i].Cells[2].Value) >= 0 && Convert.ToInt32(dgv_RegisterValue.Rows[i].Cells[2].Value) <= 65535)
                    {
                        dgv_RegisterValue.Rows[i].Cells[0].Style.BackColor = Color.White;
                        dgv_RegisterValue.Rows[i].Cells[1].Style.BackColor = Color.White;
                        dgv_RegisterValue.Rows[i].Cells[2].Style.BackColor = Color.White;
                    }
                }
            }

            if (Validate > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion Проверка данных на валидность

        #region Загрузка данных из CommandRegisterWriteData

        private void dgvRegisterValueLoad()
        {
            if (CommandRegisterNameWriteData != null)
            {
                dt_CommandRegisterWriteData.Rows.Clear();

                int CountRegisterValue = CommandRegisterWriteData.Length;
                int tmp_CommandRegisterStartAddress = Convert.ToInt32(nudRegisterStartAddress.Value);

                for (int i = 0; i < CountRegisterValue; i++)
                {
                    DataColumnCollection columns = dt_CommandRegisterWriteData.Columns;

                    DataColumn RegisterColumnType = new DataColumn();
                    RegisterColumnType.ColumnName = "DataType";
                    RegisterColumnType.Caption = "Тип данных";

                    DataColumn RegisterColumn = new DataColumn();
                    RegisterColumn.ColumnName = "Register";
                    RegisterColumn.Caption = "Регистр";


                    DataColumn RegisterColumnValue = new DataColumn();
                    RegisterColumnValue.ColumnName = "Value";
                    RegisterColumnValue.Caption = "Значение";

                    //Признак того, что функция Coil и тип столбца должен быть
                    DataColumn RegisterColumnCheckValue = new DataColumn();
                    RegisterColumnCheckValue.ColumnName = "ValueCheck";
                    RegisterColumnCheckValue.Caption = "Значение";


                    if (!columns.Contains(RegisterColumn.ColumnName) || !columns.Contains(RegisterColumnType.ColumnName) || !columns.Contains(RegisterColumnValue.ColumnName) || !columns.Contains(RegisterColumnCheckValue.ColumnName))
                    {
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                        try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                    }

                    if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
                    {
                        if (CommandRegisterWriteData[i] == 65280)
                        {
                            dt_CommandRegisterWriteData.Rows.Add(CommandRegisterNameWriteData[i], tmp_CommandRegisterStartAddress + i, CommandRegisterWriteData[i], true);
                        }
                        else
                        {
                            dt_CommandRegisterWriteData.Rows.Add(CommandRegisterNameWriteData[i], tmp_CommandRegisterStartAddress + i, CommandRegisterWriteData[i], false);
                        }
                    }
                    else
                    {
                        dt_CommandRegisterWriteData.Rows.Add(CommandRegisterNameWriteData[i], tmp_CommandRegisterStartAddress + i, CommandRegisterWriteData[i], true);
                    }
                }
                dgv_RegisterValue.DataSource = dt_CommandRegisterWriteData;
            }
        }

        #endregion Загрузка данных из CommandRegisterWriteData

        #region Сохранение данных в CommandRegisterWriteData
        private void dgv_RegisterValueSave()
        {
            if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 15 || tmp_commandFunctionCode == 16)
            {
                int CountRegisterValue = dt_CommandRegisterWriteData.Rows.Count;

                CommandRegisterNameWriteData = new string[CountRegisterValue];
                CommandRegisterWriteData = new ulong[CountRegisterValue];

                //int tmp_i = 0;
                //ERROR:
                for (int i = 1; i <= dgv_RegisterValue.Rows.Count; i++)
                {

                    CommandRegisterNameWriteData[i - 1] = dgv_RegisterValue.Rows[i - 1].Cells[0].Value.ToString();
                    CommandRegisterWriteData[i - 1] = Convert.ToUInt16(dgv_RegisterValue.Rows[i - 1].Cells[2].Value);

                    if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
                    {
                        if (dgv_RegisterValue.Rows[i - 1].Cells[3].Value.ToString() == string.Empty)
                        {
                            CommandRegisterWriteData[i - 1] = 0;
                            //return; 
                        }
                        else if ((bool)dgv_RegisterValue.Rows[i - 1].Cells[3].Value == true)
                        {
                            CommandRegisterWriteData[i - 1] = 65280;
                        }
                        else
                        {
                            CommandRegisterWriteData[i - 1] = 0;
                        }
                    }
                }
            }
            else
            {
                //Обнуляем (очищаем) массивы
                if (CommandRegisterNameWriteData != null)
                {
                    Array.Clear(CommandRegisterNameWriteData, 0, CommandRegisterNameWriteData.Length);
                    CommandRegisterNameWriteData = (string[])null;
                }
                if (CommandRegisterWriteData != null)
                {
                    Array.Clear(CommandRegisterWriteData, 0, CommandRegisterWriteData.Length);
                    CommandRegisterWriteData = (ulong[])null;
                }
            }
        }

        #endregion Сохранение данных в CommandRegisterWriteData

    }
}
