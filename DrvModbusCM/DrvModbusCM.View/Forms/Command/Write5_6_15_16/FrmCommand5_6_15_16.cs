using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Comm.Drivers.DrvModbusCM.View;
using Scada.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmCommand5_6_15_16 : Form
    {
        public FrmCommand5_6_15_16()
        {
            InitializeComponent();
        }

        #region Variables

        #region Form

        public FrmConfig frmParentGloabal;              // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified

        #endregion Form

        #region Command

        ProjectCommand currentCommand;
        //Таблица, где находятся поля DeviceCommandRegisterWriteData
        DataTable dtRegisterWriteData = new DataTable();

        #endregion Command

        #endregion Variables

        #region Load

        public FrmCommand5_6_15_16(ulong function = 0, bool hasParent = true)
        {
            currentCommand = new ProjectCommand();
            currentCommand.FunctionCode = function;
            InitializeComponent();
            FormatWindow(hasParent);
        }

        public FrmCommand5_6_15_16(ProjectNodeData ProjectNodeData)
        {
            currentCommand = ProjectNodeData.command;
            InitializeComponent();
            FormatWindow(true);
        }

        public FrmCommand5_6_15_16(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            currentCommand = ProjectNodeData.command;
            InitializeComponent();
            FormatWindow(hasParent);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                btnSave.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
                TopLevel = false;
            }
        }


        private void FrmCommand_Load(object sender, EventArgs e)
        {
            ConfigToControls();
            this.ActiveControl = txtName;
        }


        private void ConfigToControls()
        {
            txtName.Text = currentCommand.Name;
            ckbEnabled.Checked = currentCommand.Enabled;

            nudRegisterStartAddress.Value = currentCommand.RegisterStartAddress;

            //Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            nudRegisterCount.Minimum = 0;
            nudRegisterCount.Value = currentCommand.RegisterCount;
            //А вот потом говорим, что так делать нельзя :)
            nudRegisterCount.Minimum = 1; 

            //Сначала подставляем значения, а потом делаем поиск по index 
            try
            {
                string find_FunctionCode = "(" + currentCommand.FunctionCode.ToString().PadLeft(2, '0') + ")";
                //Находим индекс        
                int index_combobox = cmbFunctionCode.FindString(find_FunctionCode);
                //Отображаем
                cmbFunctionCode.SelectedIndex = index_combobox;
            }
            catch { }
        }

        #endregion Load

        #region Save

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ControlsToConfig();

            if (txtName.Text == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }

            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
            frmParentGloabal.trvProject.LabelEdit = true;
            frmParentGloabal.trvProject.SelectedNode.BeginEdit();
            TreeNode stn = frmParentGloabal.trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.command = currentCommand;
            stn.Tag = projectNodeData;
            stn.Text = currentCommand.Name;

            string imageKey = stn.ImageKey;
            int imageIndex = stn.ImageIndex;

            imageKey = ProjectCommand.KeyImageName(currentCommand.FunctionCode, currentCommand.Enabled);

            currentCommand.KeyImage = imageKey;
            stn.ImageKey = imageKey;
            stn.SelectedImageKey = imageKey;

            frmParentGloabal.trvProject.SelectedNode.EndEdit(true);
            frmParentGloabal.trvProject.LabelEdit = false;

            Modified = false;
 
        }

        //Сохранение данных
        private void ControlsToConfig()
        {
            currentCommand.Name = txtName.Text;
            currentCommand.Enabled = ckbEnabled.Checked;
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
                    currentCommand.FunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }
            currentCommand.RegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
        }

        #endregion Save

        #region Form
        /// <summary>
        /// Gets or sets a value indicating whether the configuration was modified.
        /// </summary>
        private bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                btnSave.Enabled = modified;
            }
        }

        /// <summary>
        /// Indication of a component change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_Changed(object sender, EventArgs e)
        {
            Modified = true;
        }
        #endregion Form

        #region Изменение Функции
        private void cmb_FunctionCode_SelectedIndexChanged(object sender, EventArgs e)
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
                     currentCommand.FunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }

            //Скрываем\Показываем отображение dgv_RegisterValue для ввода значений
            if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 15 || currentCommand.FunctionCode == 16)
            {
                dgvRegisterValue.Visible = true;

                if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 15)
                {
                    dgvRegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                    dgvRegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец

                }
                else if (currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 16)
                {
                    dgvRegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                    dgvRegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                }
                else
                {
                    dgvRegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                    dgvRegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                    return;
                }
            }
            else
            {
                //Скрываем таблицу
                dgvRegisterValue.Visible = false;
            }

            //Если записывается один регистр, функция 5,6 то заблокируем изменение количества регистров
            if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 6)
            {
                nudRegisterCount.Enabled = false;
                nudRegisterCount.Value = 1;
            }
            else
            {
                nudRegisterCount.Enabled = true;
            }

            currentCommand.RegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt16(nudRegisterCount.Value);

            if (currentCommand.FunctionCode == 5)
            {
                ushort RegisterValue = 0;

                if (dtRegisterWriteData.Rows.Count != 0)
                {
                    RegisterValue = Convert.ToUInt16(dtRegisterWriteData.Rows[0][2]);
                }

                dtRegisterWriteData.Rows.Clear();
                DataTableAddRow();

                for (int i = 0; i < dgvRegisterValue.Rows.Count; i++)
                {
                    dtRegisterWriteData.Rows[i][0] = "Coil";
                    dtRegisterWriteData.Rows[i][1] = currentCommand.RegisterStartAddress + (ulong)i;
                }

                if (dtRegisterWriteData.Rows.Count != 0)
                {
                    dtRegisterWriteData.Rows[0][2] = RegisterValue;
                }
            }
            else if (currentCommand.FunctionCode == 6)
            {
                ushort RegisterValue = 0;

                if (dtRegisterWriteData.Rows.Count != 0)
                {
                    RegisterValue = Convert.ToUInt16(dtRegisterWriteData.Rows[0][2]);
                }

                dtRegisterWriteData.Rows.Clear();
                DataTableAddRow();

                for (int i = 0; i < dgvRegisterValue.Rows.Count; i++)
                {
                    dtRegisterWriteData.Rows[i][0] = "HoldingRegister";
                    dtRegisterWriteData.Rows[i][1] = currentCommand.RegisterStartAddress + (ulong)i;
                }

                if (dtRegisterWriteData.Rows.Count != 0)
                {
                    dtRegisterWriteData.Rows[0][2] = RegisterValue;
                }
            }
            else if (currentCommand.FunctionCode == 15)
            {
                for (int i = 0; i < dgvRegisterValue.Rows.Count; i++)
                {
                    dtRegisterWriteData.Rows[i][0] = "Coil";
                    dtRegisterWriteData.Rows[i][1] = currentCommand.RegisterStartAddress + (ulong)i;
                }
            }
            else if (currentCommand.FunctionCode == 16)
            {
                for (int i = 0; i < dgvRegisterValue.Rows.Count; i++)
                {
                    dtRegisterWriteData.Rows[i][0] = "HoldingRegister";
                    dtRegisterWriteData.Rows[i][1] = currentCommand.RegisterStartAddress + (ulong)i;
                }
            }
            else
            {
                //Обнуляем (очищаем) массивы
                //if (DeviceCommandRegisterNameWriteData != null)
                //{
                //    Array.Clear(DeviceCommandRegisterNameWriteData, 0, DeviceCommandRegisterNameWriteData.Length);
                //    DeviceCommandRegisterNameWriteData = (string[])null;
                //}
                //if (DeviceCommandRegisterWriteData != null)
                //{
                //    Array.Clear(DeviceCommandRegisterWriteData, 0, DeviceCommandRegisterWriteData.Length);
                //    DeviceCommandRegisterWriteData = (ushort[])null;
                //}
            }
            //Генерация имени
            GenerateName();
            //Рассчет
            DataTableCalculate();
        }
        #endregion Изменение Функции

        #region Изменение Начального адреса регистра

        private void nud_RegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            currentCommand.RegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            //UpDownRegisterStartAddressValue = currentCommand.RegisterStartAddress;
            GenerateName();
            DataTableCalculate();
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nud_RegisterCount_ValueChanged(object sender, EventArgs e)
        {
            currentCommand.RegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            //UpDownRegisterCountValue = currentCommand.RegisterCount;
            GenerateName();
            DataTableCalculate();
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        private void GenerateName()
        {
            txtName.Text = currentCommand.GenerateName();
        }

        #endregion Генерация имени команды

        #region Добавление строки в таблицу 
        private void DataTableAddRow()
        {
            try
            {
                string tmp_DataType = string.Empty;

                if (dtRegisterWriteData == null)
                {
                    dtRegisterWriteData = new DataTable();
                }

                if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 15 || currentCommand.FunctionCode == 16)
                {
                    dgvRegisterValue.Visible = true;

                    if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 15)
                    {
                        dgvRegisterValue.Columns[2].Visible = false; //Скрываем третий столбец
                        dgvRegisterValue.Columns[3].Visible = true;  //Показываем четвертый столбец

                    }
                    else if (currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 16)
                    {
                        dgvRegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                        dgvRegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                    }
                    else
                    {
                        dgvRegisterValue.Columns[2].Visible = true;  //Показываем третий столбец
                        dgvRegisterValue.Columns[3].Visible = false; //Скрываем четвертый столбец
                        return;
                    }
                }

                DataColumnCollection columns = dtRegisterWriteData.Columns;

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
                    try { dtRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                    try { dtRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                    try { dtRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                    try { dtRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                }

                string RegisterColumnName = string.Empty;
                if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 15)
                {
                    RegisterColumnName = "Coil";
                }
                if (currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 16)
                {
                    RegisterColumnName = "HoldingRegister";
                }

                dtRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

                dgvRegisterValue.DataSource = dtRegisterWriteData;

                dgv_RegisterValueBlockingColumn();
            }
            catch (Exception ex)
            {
                //Debuger.LogException(ex.ToString());
            }
        }
        #endregion Добавление строки в таблицу 

        #region Удаление строки из таблицы
        private void DataTableDeleteRow()
        {
            try
            {
                if (dtRegisterWriteData == null)
                {
                    dtRegisterWriteData = new DataTable();
                }

                if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 15 || currentCommand.FunctionCode == 16)
                {
                    dgvRegisterValue.Visible = true;
                }

                if (dtRegisterWriteData.Rows.Count <= 1)
                {
                    //Записей 1 шт, не будем удалять
                    return;
                }
                else
                {
                    //Удаляем последнюю запись
                    dtRegisterWriteData.Rows.RemoveAt((int)dtRegisterWriteData.Rows.Count - 1);
                }

                dgvRegisterValue.DataSource = dtRegisterWriteData;

                dgv_RegisterValueBlockingColumn();
            }
            catch (Exception ex)
            {
                //Debuger.LogException(ex.ToString());
            }
        }
        #endregion Удаление строки из таблицы

        #region Пересчет строк в таблицах во время изменения Начального адреса регистра, Количества регистров, Номера функции, Типа данных
        private void DataTableCalculate()
        {
            string RegisterColumnName = string.Empty;
            if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 15)
            {
                RegisterColumnName = "Coil";
            }
            else if (currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 16)
            {
                RegisterColumnName = "HoldingRegister";
            }
            else
            {
                return;
            }

            ulong DifferenceValues = currentCommand.RegisterCount - (ulong)dtRegisterWriteData.Rows.Count;
            if (DifferenceValues > 0)
            {
                //Добавляем записи
                for (ulong i = 0; i < DifferenceValues; i++)
                {
                    DataColumnCollection columns = dtRegisterWriteData.Columns;

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
                        try { dtRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                        try { dtRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                        try { dtRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                        try { dtRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                    }

                    dtRegisterWriteData.Rows.Add(RegisterColumnName, 0, 0);

                    dgv_RegisterValueBlockingColumn();
                }
            }
            else if (DifferenceValues < 0)
            {
                for (ulong i = DifferenceValues; i < 0; i++)
                {
                    if (dtRegisterWriteData.Rows.Count <= 1)
                    {
                        //Записей 1 шт, не будем удалять
                        return;
                    }
                    else
                    {
                        //Удаляем последнюю запись
                        dtRegisterWriteData.Rows.RemoveAt((int)dtRegisterWriteData.Rows.Count - 1);
                        dgv_RegisterValueBlockingColumn();
                    }
                }
            }

            for (int i = 0; i < dtRegisterWriteData.Rows.Count; i++)
            {
                string tmp_RegisterColumnName = (string)dtRegisterWriteData.Rows[i][0];
                if (tmp_RegisterColumnName != "Coil" || tmp_RegisterColumnName != "HoldingRegister")
                {
                    dtRegisterWriteData.Rows[i][0] = tmp_RegisterColumnName;
                }
                else
                {
                    dtRegisterWriteData.Rows[i][0] = RegisterColumnName;
                }

                dtRegisterWriteData.Rows[i][1] = currentCommand.RegisterStartAddress + (ulong)i;
                dtRegisterWriteData.Rows[i][2] = 0;
            }

            dgv_RegisterValueBlockingColumn();
        }

        private void dgv_RegisterValue_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvRegisterValue.CurrentCell.ColumnIndex == 0) //1 Столбец
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(AnyColumnKeyPress0);
                    DataTableValidateValue();
                }
            }


            if (dgvRegisterValue.CurrentCell.ColumnIndex == 2) //3 Столбец
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
            if (dgvRegisterValue.Columns.Count >= 2)
            {
                dgvRegisterValue.Columns[1].ReadOnly = true;
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
                this.dgvRegisterValue.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

            for (int i = 0; i < dtRegisterWriteData.Rows.Count; i++)
            {
                bool tmp_TryParse = int.TryParse(dgvRegisterValue.Rows[i].Cells[2].Value.ToString(), out Validate);

                if (!tmp_TryParse)
                {
                    dgvRegisterValue.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                    dgvRegisterValue.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                    dgvRegisterValue.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                    Validate++;
                }
                else
                {
                    if (Convert.ToInt32(dgvRegisterValue.Rows[i].Cells[2].Value) < 0 || Convert.ToInt32(dgvRegisterValue.Rows[i].Cells[2].Value) > 65535)
                    {
                        dgvRegisterValue.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                        dgvRegisterValue.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                        dgvRegisterValue.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                        Validate++;
                    }
                    else if (Convert.ToInt32(dgvRegisterValue.Rows[i].Cells[2].Value) >= 0 && Convert.ToInt32(dgvRegisterValue.Rows[i].Cells[2].Value) <= 65535)
                    {
                        dgvRegisterValue.Rows[i].Cells[0].Style.BackColor = Color.White;
                        dgvRegisterValue.Rows[i].Cells[1].Style.BackColor = Color.White;
                        dgvRegisterValue.Rows[i].Cells[2].Style.BackColor = Color.White;
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

        private void dgv_RegisterValueLoad()
        {
            if (currentCommand.RegisterNameWriteData != null)
            {
                dtRegisterWriteData.Rows.Clear();

                int CountRegisterValue = currentCommand.RegisterWriteData.Length;
                int tmp_DeviceCommandRegisterStartAddress = Convert.ToInt32(nudRegisterStartAddress.Value);

                for (int i = 0; i < CountRegisterValue; i++)
                {
                    DataColumnCollection columns = dtRegisterWriteData.Columns;

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
                        try { dtRegisterWriteData.Columns.Add(RegisterColumnType); } catch { }
                        try { dtRegisterWriteData.Columns.Add(RegisterColumn); } catch { }
                        try { dtRegisterWriteData.Columns.Add(RegisterColumnValue); } catch { }
                        try { dtRegisterWriteData.Columns.Add(RegisterColumnCheckValue.ColumnName, typeof(bool)); } catch { }
                    }

                    if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 15)
                    {
                        if (currentCommand.RegisterWriteData[i] == 65280)
                        {
                            dtRegisterWriteData.Rows.Add(currentCommand.RegisterNameWriteData[i], tmp_DeviceCommandRegisterStartAddress + i, currentCommand.RegisterWriteData[i], true);
                        }
                        else
                        {
                            dtRegisterWriteData.Rows.Add(currentCommand.RegisterNameWriteData[i], tmp_DeviceCommandRegisterStartAddress + i, currentCommand.RegisterWriteData[i], false);
                        }                 
                    }
                    else
                    {
                        dtRegisterWriteData.Rows.Add(currentCommand.RegisterNameWriteData[i], tmp_DeviceCommandRegisterStartAddress + i, currentCommand.RegisterWriteData[i], true);
                    }                  
                }
                dgvRegisterValue.DataSource = dtRegisterWriteData;
            }            
        }

        #endregion Загрузка данных из DeviceCommandRegisterWriteData

        #region Сохранение данных в DeviceCommandRegisterWriteData
        private void dgv_RegisterValueSave()
        {
            if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 6 || currentCommand.FunctionCode == 15 || currentCommand.FunctionCode == 16)
            {
                int CountRegisterValue = dtRegisterWriteData.Rows.Count;

                currentCommand.RegisterNameWriteData = new string[CountRegisterValue];
                currentCommand.RegisterWriteData = new ulong[CountRegisterValue];
        
                //int tmp_i = 0;
                //ERROR:
                for (int i = 1; i <= dgvRegisterValue.Rows.Count; i++)
                {

                    currentCommand.RegisterNameWriteData[i - 1] = dgvRegisterValue.Rows[i - 1].Cells[0].Value.ToString();
                    currentCommand.RegisterWriteData[i - 1] = Convert.ToUInt16(dgvRegisterValue.Rows[i - 1].Cells[2].Value);

                    if (currentCommand.FunctionCode == 5 || currentCommand.FunctionCode == 15)
                    {
                        if (dgvRegisterValue.Rows[i - 1].Cells[3].Value.ToString() == string.Empty)
                        {
                            currentCommand.RegisterWriteData[i - 1] = 0;
                            //return; 
                        }
                        else if ((bool)dgvRegisterValue.Rows[i - 1].Cells[3].Value == true)
                        {
                            currentCommand.RegisterWriteData[i - 1] = 65280;
                        }
                        else
                        {
                            currentCommand.RegisterWriteData[i - 1] = 0;
                        }
                    }
                }
            }
            else
            {
                //Обнуляем (очищаем) массивы
                if (currentCommand.RegisterNameWriteData != null)
                {
                    Array.Clear(currentCommand.RegisterNameWriteData, 0, currentCommand.RegisterNameWriteData.Length);
                    currentCommand.RegisterNameWriteData = (string[])null;
                }
                if (currentCommand.RegisterWriteData != null)
                {
                    Array.Clear(currentCommand.RegisterWriteData, 0, currentCommand.RegisterWriteData.Length);
                    currentCommand.RegisterWriteData = (ulong[])null;
                }
            }         
        }

        #endregion Сохранение данных в DeviceCommandRegisterWriteData


        
    }

}
