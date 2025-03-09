using Scada.Comm.Drivers.DrvModbusCM;
using System.Data;
using System.Text.RegularExpressions;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscDeviceCommandWrite : UserControl
    {
        public uscDeviceCommandWrite()
        {
            InitializeComponent();
        }

        #region Комманда
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
        private Guid deviceCommandID;
        public Guid DeviceCommandID
        {
            get { return deviceCommandID; }
            set { deviceCommandID = value; }
        }

        //Название команды
        private string deviceCommandName;
        public string DeviceCommandName
        {
            get { return deviceCommandName; }
            set { deviceCommandName = value; }
        }

        //Описание команды
        private string deviceCommandDescription;
        public string DeviceCommandDescription
        {
            get { return deviceCommandDescription; }
            set { deviceCommandDescription = value; }
        }

        //Состояние команды. Включено ли команда и отправлять ли её
        private bool deviceCommandEnabled;
        public bool DeviceCommandEnabled
        {
            get { return deviceCommandEnabled; }
            set { deviceCommandEnabled = value; }
        }

        //Команда
        private ulong tmp_deviceCommandFunctionCode;
        private ulong deviceCommandFunctionCode;
        public ulong DeviceCommandFunctionCode
        {
            get { return deviceCommandFunctionCode; }
            set { deviceCommandFunctionCode = value; }
        }

        private ulong tmp_deviceCommandRegisterStartAddress;
        private ulong deviceCommandRegisterStartAddress;
        public ulong DeviceCommandRegisterStartAddress
        {
            get { return deviceCommandRegisterStartAddress; }
            set { deviceCommandRegisterStartAddress = value; }
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

        private ulong tmp_deviceCommandRegisterCount;
        private ulong deviceCommandRegisterCount;
        public ulong DeviceCommandRegisterCount
        {
            get { return deviceCommandRegisterCount; }
            set { deviceCommandRegisterCount = value; }
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

        private string[] deviceCommandRegisterNameReadData;
        public string[] DeviceCommandRegisterNameReadData
        {
            get { return deviceCommandRegisterNameReadData; }
            set { deviceCommandRegisterNameReadData = value; }
        }

        private ulong[] deviceCommandRegisterReadData;
        public ulong[] DeviceCommandRegisterReadData
        {
            get { return deviceCommandRegisterReadData; }
            set { deviceCommandRegisterReadData = value; }
        }

        private string[] deviceCommandRegisterNameWriteData;
        public string[] DeviceCommandRegisterNameWriteData
        {
            get { return deviceCommandRegisterNameWriteData; }
            set { deviceCommandRegisterNameWriteData = value; }
        }

        private ulong[] deviceCommandRegisterWriteData;
        public ulong[] DeviceCommandRegisterWriteData
        {
            get { return deviceCommandRegisterWriteData; }
            set { deviceCommandRegisterWriteData = value; }
        }

        private ulong deviceCommandParametr;
        public ulong DeviceCommandParametr
        {
            get { return deviceCommandParametr; }
            set { deviceCommandParametr = value; }
        }


        //Таблица, где находятся поля DeviceCommandRegisterWriteData
        DataTable dt_DeviceCommandRegisterWriteData = new DataTable();

        #endregion Комманда

        public uscDeviceCommandWrite(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            DeviceID = ProjectNodeData.deviceCommand.DeviceID;
            DeviceCommandID = ProjectNodeData.deviceCommand.DeviceCommandID;
            DeviceCommandName = ProjectNodeData.deviceCommand.DeviceCommandName;
            DeviceCommandDescription = ProjectNodeData.deviceCommand.DeviceCommandDescription;
            DeviceCommandEnabled = ProjectNodeData.deviceCommand.DeviceCommandEnabled;
            DeviceCommandFunctionCode = ProjectNodeData.deviceCommand.DeviceCommandFunctionCode;
            tmp_deviceCommandFunctionCode = ProjectNodeData.deviceCommand.DeviceCommandFunctionCode;
            DeviceCommandRegisterStartAddress = ProjectNodeData.deviceCommand.DeviceCommandRegisterStartAddress;
            DeviceCommandRegisterCount = ProjectNodeData.deviceCommand.DeviceCommandRegisterCount;
            DeviceCommandRegisterNameReadData = ProjectNodeData.deviceCommand.DeviceCommandRegisterNameReadData;
            DeviceCommandRegisterReadData = ProjectNodeData.deviceCommand.DeviceCommandRegisterReadData;
            DeviceCommandRegisterNameWriteData = ProjectNodeData.deviceCommand.DeviceCommandRegisterNameWriteData;
            DeviceCommandRegisterWriteData = ProjectNodeData.deviceCommand.DeviceCommandRegisterWriteData;
            DeviceCommandParametr = ProjectNodeData.deviceCommand.DeviceCommandParametr;

            InitializeComponent();
            FormatWindow(true);
        }

        public uscDeviceCommandWrite(ushort function = 0)
        {
            InitializeComponent();
            FormatWindow(true);
            DeviceCommandFunctionCode = function;
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
            txtDeviceCommandName.Text = DeviceCommandName;
            ckbDeviceCommandEnabled.Checked = DeviceCommandEnabled;

            nudRegisterStartAddress.Value = DeviceCommandRegisterStartAddress;

            //Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            nudRegisterCount.Minimum = 0;
            nudRegisterCount.Value = DeviceCommandRegisterCount;
            //А вот потом говорим, что так делать нельзя :)
            nudRegisterCount.Minimum = 1;

            //Сначала подставляем значения, а потом делаем поиск по index 
            try
            {
                string find_FunctionCode = "(" + DeviceCommandFunctionCode.ToString().PadLeft(2, '0') + ")";
                //Находим индекс        
                int index_combobox = cmbFunctionCode.FindString(find_FunctionCode);
                //Отображаем
                cmbFunctionCode.SelectedIndex = index_combobox;
            }
            catch { }

            //Загрузка значений
            dgvRegisterValueLoad();
            //После загрузки значений проверяем какая функция от этого скрываем или показываем необходимые столбцы
            if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 15)
            {
                if (dgv_RegisterValue.Rows.Count > 0)
                {
                    dgv_RegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец
                }
            }
            else if (tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 16)
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
            DeviceCommandName = txtDeviceCommandName.Text;
            DeviceCommandEnabled = ckbDeviceCommandEnabled.Checked;
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
                    DeviceCommandFunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }
            DeviceCommandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            DeviceCommandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
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

            if (deviceCommandName == "")
            {
                MessageBox.Show("Поле Наименование не может быть пустым");
                return;
            }
            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form

            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.deviceCommand.DeviceID = DeviceID;
            projectNodeData.deviceCommand.DeviceCommandID = DeviceCommandID;
            projectNodeData.deviceCommand.DeviceCommandName = DeviceCommandName;
            projectNodeData.deviceCommand.DeviceCommandDescription = DeviceCommandDescription;
            projectNodeData.deviceCommand.DeviceCommandEnabled = DeviceCommandEnabled;
            projectNodeData.deviceCommand.DeviceCommandFunctionCode = DeviceCommandFunctionCode;
            projectNodeData.deviceCommand.DeviceCommandRegisterStartAddress = DeviceCommandRegisterStartAddress;
            projectNodeData.deviceCommand.DeviceCommandRegisterCount = DeviceCommandRegisterCount;
            projectNodeData.deviceCommand.DeviceCommandRegisterNameReadData = DeviceCommandRegisterNameReadData;
            projectNodeData.deviceCommand.DeviceCommandRegisterReadData = DeviceCommandRegisterReadData;
            projectNodeData.deviceCommand.DeviceCommandRegisterNameWriteData = DeviceCommandRegisterNameWriteData;
            projectNodeData.deviceCommand.DeviceCommandRegisterWriteData = DeviceCommandRegisterWriteData;
            projectNodeData.deviceCommand.DeviceCommandParametr = DeviceCommandParametr;

            //Условия иконки 
            switch (DeviceCommandFunctionCode)
            {
                case 0:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_00_16.png";
                    break;
                case 1:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_01_16.png";
                    break;
                case 2:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_02_16.png";
                    break;
                case 3:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_03_16.png";
                    break;
                case 4:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_04_16.png";
                    break;
                case 5:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_05_16.png";
                    break;
                case 6:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_06_16.png";
                    break;
                case 7:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_07_16.png";
                    break;
                case 8:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_08_16.png";
                    break;
                case 11:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_11_16.png";
                    break;
                case 12:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_12_16.png";
                    break;
                case 15:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_15_16.png";
                    break;
                case 16:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_16_16.png";
                    break;
                case 17:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_17_16.png";
                    break;
                case 20:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_20_16.png";
                    break;
                case 21:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_21_16.png";
                    break;
                case 22:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_22_16.png";
                    break;
                case 24:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_24_16.png";
                    break;
                case 43:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_43_16.png";
                    break;
                case 99:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_99_16.png";
                    break;
                default:
                    projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = "modbus_command_00_16.png";
                    break;
            }

            stn.Text = DeviceCommandName;
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
                    tmp_deviceCommandFunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }

            //Скрываем\Показываем отображение dgv_RegisterValue для ввода значений
            if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 15 || tmp_deviceCommandFunctionCode == 16)
            {
                dgv_RegisterValue.Visible = true;

                if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 15)
                {
                    dgv_RegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                    dgv_RegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец

                }
                else if (tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 16)
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
            if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 6)
            {
                nudRegisterCount.Enabled = false;
                nudRegisterCount.Value = 1;
            }
            else
            {
                nudRegisterCount.Enabled = true;
            }

            tmp_deviceCommandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_deviceCommandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);

            if (tmp_deviceCommandFunctionCode == 5)
            {
                ushort RegisterValue = 0;

                if (dt_DeviceCommandRegisterWriteData.Rows.Count != 0)
                {
                    RegisterValue = Convert.ToUInt16(dt_DeviceCommandRegisterWriteData.Rows[0][2]);
                }

                dt_DeviceCommandRegisterWriteData.Rows.Clear();
                DataTableAddRow();

                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_DeviceCommandRegisterWriteData.Rows[i][0] = "Coil";
                    dt_DeviceCommandRegisterWriteData.Rows[i][1] = (ulong)DeviceCommandRegisterStartAddress + (ulong)i;
                }

                if (dt_DeviceCommandRegisterWriteData.Rows.Count != 0)
                {
                    dt_DeviceCommandRegisterWriteData.Rows[0][2] = RegisterValue;
                }
            }
            else if (tmp_deviceCommandFunctionCode == 6)
            {
                ushort RegisterValue = 0;

                if (dt_DeviceCommandRegisterWriteData.Rows.Count != 0)
                {
                    RegisterValue = Convert.ToUInt16(dt_DeviceCommandRegisterWriteData.Rows[0][2]);
                }

                dt_DeviceCommandRegisterWriteData.Rows.Clear();
                DataTableAddRow();

                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_DeviceCommandRegisterWriteData.Rows[i][0] = "HoldingRegister";
                    dt_DeviceCommandRegisterWriteData.Rows[i][1] = (ulong)DeviceCommandRegisterStartAddress + (ulong)i;
                }

                if (dt_DeviceCommandRegisterWriteData.Rows.Count != 0)
                {
                    dt_DeviceCommandRegisterWriteData.Rows[0][2] = RegisterValue;
                }
            }
            else if (tmp_deviceCommandFunctionCode == 15)
            {
                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_DeviceCommandRegisterWriteData.Rows[i][0] = "Coil";
                    dt_DeviceCommandRegisterWriteData.Rows[i][1] = (ulong)DeviceCommandRegisterStartAddress + (ulong)i;
                }
            }
            else if (tmp_deviceCommandFunctionCode == 16)
            {
                for (int i = 0; i < dgv_RegisterValue.Rows.Count; i++)
                {
                    dt_DeviceCommandRegisterWriteData.Rows[i][0] = "HoldingRegister";
                    dt_DeviceCommandRegisterWriteData.Rows[i][1] = (ulong)DeviceCommandRegisterStartAddress + (ulong)i;
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
            tmp_deviceCommandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_deviceCommandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterStartAddressValue = tmp_deviceCommandRegisterStartAddress;
            GenerateName(out string nameCommand);
            DataTableCalculate();
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            tmp_deviceCommandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_deviceCommandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterCountValue = tmp_deviceCommandRegisterCount;
            GenerateName(out string nameCommand);
            DataTableCalculate();
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        public void GenerateName(out string nameCommand)
        {
            nameCommand = "Команда:[" + tmp_deviceCommandFunctionCode + "][" + tmp_deviceCommandRegisterStartAddress + "][" + tmp_deviceCommandRegisterCount + "]";
            txtDeviceCommandName.Text = nameCommand;
        }

        #endregion Генерация имени команды

        #region Добавление строки в таблицу 
        private void DataTableAddRow()
        {
            try
            {
                string tmp_DataType = string.Empty;

                if (dt_DeviceCommandRegisterWriteData == null)
                {
                    dt_DeviceCommandRegisterWriteData = new DataTable();
                }

                if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 15 || tmp_deviceCommandFunctionCode == 16)
                {
                    dgv_RegisterValue.Visible = true;

                    if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 15)
                    {
                        dgv_RegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                        dgv_RegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец

                    }
                    else if (tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 16)
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

                DataColumnCollection columns = dt_DeviceCommandRegisterWriteData.Columns;

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
                    try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                    try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                    try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                    try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                }

                string RegisterColumnName = string.Empty;
                if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 15)
                {
                    RegisterColumnName = "Coil";
                }
                if (tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 16)
                {
                    RegisterColumnName = "HoldingRegister";
                }

                dt_DeviceCommandRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

                dgv_RegisterValue.DataSource = dt_DeviceCommandRegisterWriteData;

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
                if (dt_DeviceCommandRegisterWriteData == null)
                {
                    dt_DeviceCommandRegisterWriteData = new DataTable();
                }

                if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 15 || tmp_deviceCommandFunctionCode == 16)
                {
                    dgv_RegisterValue.Visible = true;
                }

                if (dt_DeviceCommandRegisterWriteData.Rows.Count <= 1)
                {
                    //Записей 1 шт, не будем удалять
                    return;
                }
                else
                {
                    //Удаляем последнюю запись
                    dt_DeviceCommandRegisterWriteData.Rows.RemoveAt((int)dt_DeviceCommandRegisterWriteData.Rows.Count - 1);
                }

                dgv_RegisterValue.DataSource = dt_DeviceCommandRegisterWriteData;

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
            if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 15)
            {
                RegisterColumnName = "Coil";
            }
            else if (tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 16)
            {
                RegisterColumnName = "HoldingRegister";
            }
            else
            {
                return;
            }

            ulong DifferenceValues = (ulong)tmp_deviceCommandRegisterCount - (ulong)dt_DeviceCommandRegisterWriteData.Rows.Count;
            if (DifferenceValues > 0)
            {
                //Добавляем записи
                for (ulong i = 0; i < DifferenceValues; i++)
                {
                    DataColumnCollection columns = dt_DeviceCommandRegisterWriteData.Columns;

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
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                    }

                    dt_DeviceCommandRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

                    dgv_RegisterValueBlockingColumn();
                }
            }
            else if (DifferenceValues < 0)
            {
                for (ulong i = DifferenceValues; i < 0; i++)
                {
                    if (dt_DeviceCommandRegisterWriteData.Rows.Count <= 1)
                    {
                        //Записей 1 шт, не будем удалять
                        return;
                    }
                    else
                    {
                        //Удаляем последнюю запись
                        dt_DeviceCommandRegisterWriteData.Rows.RemoveAt((int)dt_DeviceCommandRegisterWriteData.Rows.Count - 1);
                        dgv_RegisterValueBlockingColumn();
                    }
                }
            }

            for (int i = 0; i < dt_DeviceCommandRegisterWriteData.Rows.Count; i++)
            {
                string tmp_RegisterColumnName = (string)dt_DeviceCommandRegisterWriteData.Rows[i][0];
                if (tmp_RegisterColumnName != "Coil" || tmp_RegisterColumnName != "HoldingRegister")
                {
                    dt_DeviceCommandRegisterWriteData.Rows[i][0] = tmp_RegisterColumnName;
                }
                else
                {
                    dt_DeviceCommandRegisterWriteData.Rows[i][0] = RegisterColumnName;
                }

                dt_DeviceCommandRegisterWriteData.Rows[i][1] = (ulong)tmp_deviceCommandRegisterStartAddress + (ulong)i;
                dt_DeviceCommandRegisterWriteData.Rows[i][2] = 0;
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

            for (int i = 0; i < dt_DeviceCommandRegisterWriteData.Rows.Count; i++)
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

        #region Загрузка данных из DeviceCommandRegisterWriteData

        private void dgvRegisterValueLoad()
        {
            if (DeviceCommandRegisterNameWriteData != null)
            {
                dt_DeviceCommandRegisterWriteData.Rows.Clear();

                int CountRegisterValue = DeviceCommandRegisterWriteData.Length;
                int tmp_DeviceCommandRegisterStartAddress = Convert.ToInt32(nudRegisterStartAddress.Value);

                for (int i = 0; i < CountRegisterValue; i++)
                {
                    DataColumnCollection columns = dt_DeviceCommandRegisterWriteData.Columns;

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
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                        try { dt_DeviceCommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                    }

                    if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 15)
                    {
                        if (DeviceCommandRegisterWriteData[i] == 65280)
                        {
                            dt_DeviceCommandRegisterWriteData.Rows.Add(DeviceCommandRegisterNameWriteData[i], tmp_DeviceCommandRegisterStartAddress + i, DeviceCommandRegisterWriteData[i], true);
                        }
                        else
                        {
                            dt_DeviceCommandRegisterWriteData.Rows.Add(DeviceCommandRegisterNameWriteData[i], tmp_DeviceCommandRegisterStartAddress + i, DeviceCommandRegisterWriteData[i], false);
                        }
                    }
                    else
                    {
                        dt_DeviceCommandRegisterWriteData.Rows.Add(DeviceCommandRegisterNameWriteData[i], tmp_DeviceCommandRegisterStartAddress + i, DeviceCommandRegisterWriteData[i], true);
                    }
                }
                dgv_RegisterValue.DataSource = dt_DeviceCommandRegisterWriteData;
            }
        }

        #endregion Загрузка данных из DeviceCommandRegisterWriteData

        #region Сохранение данных в DeviceCommandRegisterWriteData
        private void dgv_RegisterValueSave()
        {
            if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 6 || tmp_deviceCommandFunctionCode == 15 || tmp_deviceCommandFunctionCode == 16)
            {
                int CountRegisterValue = dt_DeviceCommandRegisterWriteData.Rows.Count;

                DeviceCommandRegisterNameWriteData = new string[CountRegisterValue];
                DeviceCommandRegisterWriteData = new ulong[CountRegisterValue];

                //int tmp_i = 0;
                //ERROR:
                for (int i = 1; i <= dgv_RegisterValue.Rows.Count; i++)
                {

                    DeviceCommandRegisterNameWriteData[i - 1] = dgv_RegisterValue.Rows[i - 1].Cells[0].Value.ToString();
                    DeviceCommandRegisterWriteData[i - 1] = Convert.ToUInt16(dgv_RegisterValue.Rows[i - 1].Cells[2].Value);

                    if (tmp_deviceCommandFunctionCode == 5 || tmp_deviceCommandFunctionCode == 15)
                    {
                        if (dgv_RegisterValue.Rows[i - 1].Cells[3].Value.ToString() == string.Empty)
                        {
                            DeviceCommandRegisterWriteData[i - 1] = 0;
                            //return; 
                        }
                        else if ((bool)dgv_RegisterValue.Rows[i - 1].Cells[3].Value == true)
                        {
                            DeviceCommandRegisterWriteData[i - 1] = 65280;
                        }
                        else
                        {
                            DeviceCommandRegisterWriteData[i - 1] = 0;
                        }
                    }
                }
            }
            else
            {
                //Обнуляем (очищаем) массивы
                if (DeviceCommandRegisterNameWriteData != null)
                {
                    Array.Clear(DeviceCommandRegisterNameWriteData, 0, DeviceCommandRegisterNameWriteData.Length);
                    DeviceCommandRegisterNameWriteData = (string[])null;
                }
                if (DeviceCommandRegisterWriteData != null)
                {
                    Array.Clear(DeviceCommandRegisterWriteData, 0, DeviceCommandRegisterWriteData.Length);
                    DeviceCommandRegisterWriteData = (ulong[])null;
                }
            }
        }

        #endregion Сохранение данных в DeviceCommandRegisterWriteData

    }
}
