namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscDeviceArbitrary : UserControl
    {
        public uscDeviceArbitrary()
        {
            InitializeComponent();
        }
    }

    ////Загрузка данных
    //private void SetModbusCommandConfig()
    //{
    //    txtCommandName.Text = CommandName;
    //    if (txtCommandName.Text == string.Empty)
    //    {
    //        txtCommandName.Text = "Команда:[99][0][0]";
    //    }

    //    ckbCommandEnabled.Checked = CommandEnabled;

    //    //Сначала подставляем значения, а потом делаем поиск по index 
    //    try
    //    {
    //        string find_FunctionCode = "(" + CommandFunctionCode.ToString().PadLeft(2, '0') + ")";
    //        //Находим индекс        
    //        int index_combobox = cmbFunctionCode.FindString(find_FunctionCode);
    //        //Отображаем
    //        cmbFunctionCode.SelectedIndex = index_combobox;
    //    }
    //    catch { }

    //    try
    //    {
    //        if (CommandRegisterWriteData != null)
    //        {
    //            txtCommand.Text = HEX_STRING.BYTEARRAY_TO_HEXSTRING(HEX_WORD.ToByteArray(CommandRegisterWriteData));
    //        }
    //    }
    //    catch { }
    //}

    ////Сохранение данных
    //private void GetModbusCommandConfig()
    //{
    //    try
    //    {
    //        CommandRegisterWriteData = HEX_WORD.ToArray(HEX_STRING.HEXSTRING_TO_BYTEARRAY(txtCommand.Text.Trim()));
    //    }
    //    catch { }

    //    //Код функции
    //    try
    //    {
    //        string permennaya = cmbFunctionCode.Items[cmbFunctionCode.SelectedIndex].ToString().Trim();
    //        //Ищем последовательность в цифрах
    //        Regex regex = new Regex(@"([A-Fa-f0-9][A-Fa-f0-9])");
    //        Match match = regex.Match(permennaya);
    //        if (match.Success)
    //        {
    //            //Получили match.Value со значением
    //            CommandFunctionCode = Convert.ToUInt16(match.Value);
    //        }
    //    }
    //    catch { }

    //    CommandName = txtCommandName.Text;
    //    CommandEnabled = ckbCommandEnabled.Checked;
    //}

    //private void btnModbusCommandAdd_Click(object sender, EventArgs e)
    //{
    //    Add();
    //}

    //private void Add()
    //{
    //    GetModbusCommandConfig();
    //    if (commandName == "")
    //    {
    //        MessageBox.Show("Поле Наименование не может быть пустым");
    //        return;
    //    }
    //    this.DialogResult = DialogResult.OK;
    //    this.Close();
    //}

    //private void btnModbusCommandSave_Click(object sender, EventArgs e)
    //{
    //    Save();
    //}

    //private void Save()
    //{
    //    GetModbusCommandConfig();

    //    if (commandName == "")
    //    {
    //        MessageBox.Show("Поле Наименование не может быть пустым");
    //        return;
    //    }
    //    //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form

    //    TreeNode stn = ((frm_MainForm)this.Parent.Parent.Parent.Parent.Parent).trv_Project.SelectedNode;
    //    ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
    //    projectNodeData.modbus_device_command.DeviceID = DeviceID;
    //    projectNodeData.modbus_device_command.CommandID = CommandID;
    //    projectNodeData.modbus_device_command.CommandName = CommandName;
    //    projectNodeData.modbus_device_command.CommandDescription = CommandDescription;
    //    projectNodeData.modbus_device_command.CommandEnabled = CommandEnabled;
    //    projectNodeData.modbus_device_command.CommandFunctionCode = CommandFunctionCode;
    //    projectNodeData.modbus_device_command.CommandRegisterStartAddress = CommandRegisterStartAddress;
    //    projectNodeData.modbus_device_command.CommandRegisterCount = CommandRegisterCount;
    //    projectNodeData.modbus_device_command.CommandRegisterNameWriteData = CommandRegisterNameWriteData;
    //    projectNodeData.modbus_device_command.CommandRegisterWriteData = CommandRegisterWriteData;

    //    stn.Text = CommandName;
    //    stn.Tag = projectNodeData;
    //}



    //private void btnModbusCommandCancel_Click(object sender, EventArgs e)
    //{
    //    this.DialogResult = DialogResult.Cancel;
    //    Close();
    //}

    //#region Изменение Функции
    //private void cmbFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //Код функции
    //    try
    //    {
    //        string permennaya = cmbFunctionCode.Items[cmbFunctionCode.SelectedIndex].ToString().Trim();
    //        //Ищем последовательность в цифрах
    //        Regex regex = new Regex(@"([A-Fa-f0-9][A-Fa-f0-9])");
    //        Match match = regex.Match(permennaya);
    //        if (match.Success)
    //        {
    //            //Получили match.Value со значением
    //            tmp_commandFunctionCode = Convert.ToUInt16(match.Value);
    //        }
    //    }
    //    catch { }

    //    if (tmp_commandFunctionCode == 5)
    //    {
    //        ushort RegisterValue = 0;

    //        if (dt_CommandRegisterWriteData.Rows.Count != 0)
    //        {
    //            RegisterValue = Convert.ToUInt16(dt_CommandRegisterWriteData.Rows[0][2]);
    //        }

    //        dt_CommandRegisterWriteData.Rows.Clear();
    //        DataTableAddRow();

    //        if (dt_CommandRegisterWriteData.Rows.Count != 0)
    //        {
    //            dt_CommandRegisterWriteData.Rows[0][2] = RegisterValue;
    //        }
    //    }
    //    else if (tmp_commandFunctionCode == 6)
    //    {
    //        ushort RegisterValue = 0;

    //        if (dt_CommandRegisterWriteData.Rows.Count != 0)
    //        {
    //            RegisterValue = Convert.ToUInt16(dt_CommandRegisterWriteData.Rows[0][2]);
    //        }

    //        dt_CommandRegisterWriteData.Rows.Clear();
    //        DataTableAddRow();

    //        if (dt_CommandRegisterWriteData.Rows.Count != 0)
    //        {
    //            dt_CommandRegisterWriteData.Rows[0][2] = RegisterValue;
    //        }
    //    }

    //    //Генерация имени
    //    GenerateName();
    //    //Рассчет
    //    DataTableCalculate();
    //}
    //#endregion Изменение Функции

    //#region Изменение Начального адреса регистра

    //private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
    //{
    //    UpDownRegisterStartAddressValue = tmp_commandRegisterStartAddress;
    //    GenerateName();
    //    DataTableCalculate();
    //}

    //#endregion Изменение Начального адреса регистра

    //#region Изменение количества регистров
    //private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
    //{
    //    UpDownRegisterCountValue = tmp_commandRegisterCount;
    //    GenerateName();
    //    DataTableCalculate();
    //}
    //#endregion Изменение количества регистров

    //#region Генерация имени команды
    //private void GenerateName()
    //{
    //    if (txtCommandName == null || commandRegisterWriteData == null)
    //    {
    //        return;
    //    }

    //    txtCommandName.Text = "Команда:[" + tmp_commandFunctionCode + "][" + tmp_commandRegisterStartAddress + "][" + commandRegisterWriteData.Length + "]";
    //}

    //#endregion Генерация имени команды

    //#region Добавление строки в таблицу 
    //private void DataTableAddRow()
    //{
    //    try
    //    {
    //        string tmp_DataType = string.Empty;

    //        if (dt_CommandRegisterWriteData == null)
    //        {
    //            dt_CommandRegisterWriteData = new DataTable();
    //        }

    //        if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 15 || tmp_commandFunctionCode == 16)
    //        {

    //        }

    //        DataColumnCollection columns = dt_CommandRegisterWriteData.Columns;

    //        DataColumn RegisterColumnType = new DataColumn();
    //        RegisterColumnType.ColumnName = "DataType";
    //        RegisterColumnType.Caption = "Тип данных";

    //        DataColumn RegisterColumn = new DataColumn();
    //        RegisterColumn.ColumnName = "Register";
    //        RegisterColumn.Caption = "Регистр";

    //        DataColumn RegisterColumnValue = new DataColumn();
    //        RegisterColumnValue.ColumnName = "Value";
    //        RegisterColumnValue.Caption = "Значение";

    //        //Признак того, что функция Coil и тип столбца должен быть
    //        DataColumn RegisterColumnCheckValue = new DataColumn();
    //        RegisterColumnCheckValue.ColumnName = "ValueCheck";
    //        RegisterColumnCheckValue.Caption = "Значение";


    //        if (!columns.Contains(RegisterColumn.ColumnName) || !columns.Contains(RegisterColumnType.ColumnName) || !columns.Contains(RegisterColumnValue.ColumnName) || !columns.Contains(RegisterColumnCheckValue.ColumnName))
    //        {
    //            try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
    //            try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
    //            try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
    //            try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
    //        }

    //        string RegisterColumnName = string.Empty;
    //        if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
    //        {
    //            RegisterColumnName = "Coil";
    //        }
    //        if (tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 16)
    //        {
    //            RegisterColumnName = "HoldingRegister";
    //        }

    //        dt_CommandRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

    //        //ВООООТ
    //        txtCommand.Text = dt_CommandRegisterWriteData.ToString();


    //    }
    //    catch (Exception ex)
    //    {
    //        Debuger.LogException(ex.ToString());
    //    }
    //}
    //#endregion Добавление строки в таблицу 

    //#region Удаление строки из таблицы
    //private void DataTableDeleteRow()
    //{
    //    try
    //    {
    //        if (dt_CommandRegisterWriteData == null)
    //        {
    //            dt_CommandRegisterWriteData = new DataTable();
    //        }

    //        if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 15 || tmp_commandFunctionCode == 16)
    //        {

    //        }

    //        if (dt_CommandRegisterWriteData.Rows.Count <= 1)
    //        {
    //            //Записей 1 шт, не будем удалять
    //            return;
    //        }
    //        else
    //        {
    //            //Удаляем последнюю запись
    //            dt_CommandRegisterWriteData.Rows.RemoveAt((int)dt_CommandRegisterWriteData.Rows.Count - 1);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Debuger.LogException(ex.ToString());
    //    }
    //}
    //#endregion Удаление строки из таблицы

    //#region Пересчет строк в таблицах во время изменения Начального адреса регистра, Количества регистров, Номера функции, Типа данных
    //private void DataTableCalculate()
    //{
    //    string RegisterColumnName = string.Empty;
    //    if (tmp_commandFunctionCode == 5 || tmp_commandFunctionCode == 15)
    //    {
    //        RegisterColumnName = "Coil";
    //    }
    //    else if (tmp_commandFunctionCode == 6 || tmp_commandFunctionCode == 16)
    //    {
    //        RegisterColumnName = "HoldingRegister";
    //    }
    //    else
    //    {
    //        return;
    //    }

    //    int DifferenceValues = tmp_commandRegisterCount - dt_CommandRegisterWriteData.Rows.Count;
    //    if (DifferenceValues > 0)
    //    {
    //        //Добавляем записи
    //        for (int i = 0; i < DifferenceValues; i++)
    //        {
    //            DataColumnCollection columns = dt_CommandRegisterWriteData.Columns;

    //            DataColumn RegisterColumnType = new DataColumn();
    //            RegisterColumnType.ColumnName = "DataType";
    //            RegisterColumnType.Caption = "Тип данных";

    //            DataColumn RegisterColumn = new DataColumn();
    //            RegisterColumn.ColumnName = "Register";
    //            RegisterColumn.Caption = "Регистр";

    //            DataColumn RegisterColumnValue = new DataColumn();
    //            RegisterColumnValue.ColumnName = "Value";
    //            RegisterColumnValue.Caption = "Значение";

    //            //Признак того, что функция Coil и тип столбца должен быть
    //            DataColumn RegisterColumnCheckValue = new DataColumn();
    //            RegisterColumnCheckValue.ColumnName = "ValueCheck";
    //            RegisterColumnCheckValue.Caption = "Значение";


    //            if (!columns.Contains(RegisterColumn.ColumnName) || !columns.Contains(RegisterColumnType.ColumnName) || !columns.Contains(RegisterColumnValue.ColumnName) || !columns.Contains(RegisterColumnCheckValue.ColumnName))
    //            {
    //                try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
    //                try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
    //                try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
    //                try { dt_CommandRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
    //            }

    //            dt_CommandRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

    //        }
    //    }
    //    else if (DifferenceValues < 0)
    //    {
    //        for (int i = DifferenceValues; i < 0; i++)
    //        {
    //            if (dt_CommandRegisterWriteData.Rows.Count <= 1)
    //            {
    //                //Записей 1 шт, не будем удалять
    //                return;
    //            }
    //            else
    //            {
    //                //Удаляем последнюю запись
    //                dt_CommandRegisterWriteData.Rows.RemoveAt((int)dt_CommandRegisterWriteData.Rows.Count - 1);
    //            }
    //        }
    //    }

    //    for (int i = 0; i < dt_CommandRegisterWriteData.Rows.Count; i++)
    //    {
    //        string tmp_RegisterColumnName = (string)dt_CommandRegisterWriteData.Rows[i][0];
    //        if (tmp_RegisterColumnName != "Coil" || tmp_RegisterColumnName != "HoldingRegister")
    //        {
    //            dt_CommandRegisterWriteData.Rows[i][0] = tmp_RegisterColumnName;
    //        }
    //        else
    //        {
    //            dt_CommandRegisterWriteData.Rows[i][0] = RegisterColumnName;
    //        }

    //        dt_CommandRegisterWriteData.Rows[i][1] = tmp_commandRegisterStartAddress + i;
    //        dt_CommandRegisterWriteData.Rows[i][2] = 0;
    //    }
    //}

    //private void txtCommand_KeyPress(object sender, KeyPressEventArgs e)
    //{
    //    TextBox textbox = (TextBox)sender;
    //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && (char.ToLower(e.KeyChar) != 'a' && char.ToLower(e.KeyChar) != 'b') && (char.ToLower(e.KeyChar) != 'c' && char.ToLower(e.KeyChar) != 'd' && (char.ToLower(e.KeyChar) != 'e' && char.ToLower(e.KeyChar) != 'f')))
    //    {
    //        e.Handled = true;
    //    }
    //    else
    //    {
    //        if (e.KeyChar == '\b')
    //        {
    //            return;
    //        }

    //        int selectionStart = textbox.SelectionStart;
    //        if (textbox.SelectionLength > 0)
    //        {
    //            textbox.Text = textbox.Text.Remove(textbox.SelectionStart, textbox.SelectionLength);
    //        }

    //        string stroka_1 = textbox.Text.Insert(selectionStart, "W").Replace(".", string.Empty);
    //        for (int startIndex = 2; startIndex < stroka_1.Length; startIndex += 3)
    //        {
    //            stroka_1 = stroka_1.Insert(startIndex, ".");
    //        }
    //        if (selectionStart % 3 == 2)
    //        {
    //            ++selectionStart;
    //        }
    //        string stroka_2 = stroka_1.Remove(selectionStart, 1);
    //        textbox.Text = stroka_2;
    //        textbox.Select(selectionStart, 0);
    //    }

    //    CommandRegisterWriteData = HEX_WORD.ToArray(HEX_STRING.HEXSTRING_TO_BYTEARRAY(txtCommand.Text.Trim()));

    //    GenerateName();
    //}

    //private void txtCommand_TextChanged(object sender, EventArgs e)
    //{
    //    GenerateName();
    //}








    //#endregion Пересчет строк в таблицах во время изменения Начального адреса регистра, Количества регистров, Номера функции, Типа данных


}
