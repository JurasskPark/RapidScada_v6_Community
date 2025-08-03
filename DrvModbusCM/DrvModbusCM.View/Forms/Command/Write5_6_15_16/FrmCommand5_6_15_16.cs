using BrightIdeasSoftware;
using DrvModbusCM.Shared.Project.Tag;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Xml;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectTag;

namespace Scada.Comm.Drivers.DrvModbusCM.View
{
    public partial class FrmCommand5_6_15_16 : Form
    {
        public FrmCommand5_6_15_16()
        {
            InitializeComponent();
            InitializeObjectListView();
        }

        #region Variables

        private void InitializeObjectListView()
        {
            // Инициализация OLV
            olvRegistersWrite.OwnerDraw = true;

            // Обработка изменения размера
            olvRegistersWrite.Resize += (sender, e) =>
            {
                olvRegistersWrite.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            };
        }

        #region Form

        public FrmConfig frmParentGloabal;              // global general form
        public bool boolParent = false;                 // сhild startup flag
        public bool modified;                           // the configuration was modified

        #endregion Form

        #region Command

        ProjectCommand currentCommand = new ProjectCommand();

        Decimal RegisterCountOldValue = new Decimal(0);

        #endregion Command

        #region Controls

        private ComboBox currentCombobox;

        #endregion Controls

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
            currentCommand = ProjectNodeData.Command;
            InitializeComponent();
            FormatWindow(true);
        }

        public FrmCommand5_6_15_16(ref ProjectNodeData ProjectNodeData, bool hasParent = true)
        {
            currentCommand = ProjectNodeData.Command;
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
            txtCode.Text = currentCommand.Code;

            nudRegisterStartAddress.Value = currentCommand.RegisterStartAddress;

            //Костыль, т.к. сначала по умолчанию принимаем, что есть т.е. с 0
            nudRegisterCount.Minimum = 0;
            nudRegisterCount.Value = currentCommand.RegisterCount;
            //А вот потом говорим, что так делать нельзя :)
            nudRegisterCount.Minimum = 1;

            //Сначала подставляем значения, а потом делаем поиск по index 
            try
            {
                cmbFunctionCode.SelectedIndex = cmbFunctionCode.FindString("(" + currentCommand.FunctionCode.ToString().PadLeft(2, '0') + ")");
            }
            catch
            {
                cmbFunctionCode.SelectedIndex = 0;
            }

            txtRegistersWriteData.Text = HEX_STRING.BYTEARRAY_TO_HEXSTRING(currentCommand.RegisterWriteData);

            this.olvRegistersWrite.ClearObjects();
            if (currentCommand.ListRegistersWriteData != null && currentCommand.ListRegistersWriteData.Count > 0)
            {
                this.olvRegistersWrite.AddObjects(currentCommand.ListRegistersWriteData);
                this.olvRegistersWrite.AutoResizeColumns();
            }

            GenerateRegistersWriteData();
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
            projectNodeData.Command = currentCommand;
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

            currentCommand.FunctionCode = FunctionCode();

            currentCommand.RegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt16(nudRegisterCount.Value);

            currentCommand.RegisterWriteData = HEX_STRING.HEXSTRINGFORMAT_TO_BYTEARRAY(txtRegistersWriteData.Text.Trim());
            currentCommand.ListRegistersWriteData = (List<ProjectRegisterWriteData>)olvRegistersWrite.Objects;
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
        private void cmbFunctionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCommand.FunctionCode = FunctionCode();

            GenerateName();
            GenerateRegistersWriteData();
        }

        private ulong FunctionCode()
        {
            ulong result = 0;
            try
            {
                Regex regex = new Regex(@"([A-Fa-f0-9][A-Fa-f0-9])");
                Match match = regex.Match(cmbFunctionCode.Items[cmbFunctionCode.SelectedIndex].ToString().Trim());
                if (match.Success)
                {
                    switch (Convert.ToUInt16(match.Value))
                    {
                        case 5:
                        case 6:
                            nudRegisterCount.Value = Convert.ToUInt64(1);
                            nudRegisterCount.Enabled = false;
                            return Convert.ToUInt16(match.Value);
                        case 15:
                        case 16:
                            nudRegisterCount.Enabled = true;
                            return Convert.ToUInt16(match.Value);
                    }

                    return Convert.ToUInt16(match.Value);
                }

                return result;
            }
            catch 
            {
                return result;
            }
        }

        #endregion Изменение Функции

        #region Изменение Начального адреса регистра

        private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            currentCommand.RegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            GenerateName();
            GenerateRegistersWriteData();
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            // Получаем текущее значение
            decimal newValue = nudRegisterCount.Value;

            // Сравниваем значения
            if (RegisterCountOldValue > newValue)
            {
                // Значение уменьшилось (нажата стрелка вниз)
                RegistersWriteDataDelete();
            }
            else if (RegisterCountOldValue < newValue)
            {
                // Значение увеличилось (нажата стрелка вверх)
                RegistersWriteDataAdd();
            }

            // Сохраняем текущее значение для следующей проверки
            RegisterCountOldValue = newValue;

            currentCommand.RegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            currentCommand.RegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            GenerateName();
            GenerateRegistersWriteData();
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        private void GenerateName()
        {
            txtName.Text = currentCommand.GenerateName();
        }

        #endregion Генерация имени команды

        private void GenerateRegistersWriteData()
        {
            if ((ulong)currentCommand.ListRegistersWriteData.Count() != currentCommand.RegisterCount)
            {
                if (currentCommand.RegisterCount > (ulong)currentCommand.ListRegistersWriteData.Count())
                {
                    ulong difference = currentCommand.RegisterCount - (ulong)currentCommand.ListRegistersWriteData.Count();
                    for (ulong i = 0; i < difference; i++)
                    {
                        RegistersWriteDataAdd();
                    }
                }
                else if (currentCommand.RegisterCount < (ulong)currentCommand.ListRegistersWriteData.Count())
                {
                    ulong difference = (ulong)currentCommand.ListRegistersWriteData.Count() - (ulong)currentCommand.RegisterCount;
                    for (ulong i = 0; i < difference; i++)
                    {
                        RegistersWriteDataDelete();
                    }
                }
                
            }
            else if (currentCommand.RegisterCount == (ulong)currentCommand.ListRegistersWriteData.Count())
            {
                byte[] bytes = new byte[0];
                currentCommand.FunctionCode = FunctionCode();
                for (ulong i = 0; i < (ulong)currentCommand.ListRegistersWriteData.Count(); i++)
                {
                    ProjectRegisterWriteData register = currentCommand.ListRegistersWriteData[(int)i];
                    
                    switch (currentCommand.FunctionCode)
                    {
                        case 5:
                            register.RegAddr = ((ulong)100000 + Convert.ToUInt64(nudRegisterStartAddress.Value)) + Convert.ToUInt64((ulong)i);
                            register.RegName = "Coil";
                            register.RegFormat = FormatData.BOOL;
                            register.RegValue = ConverterFormatData.ConvertStringtoObject(register.RegFormat, register.RegValueString);
                            register.RegData = ProjectTag.GetBytes(ProjectTag.ConvertRegisterToTag(register), register.RegValue);
                            break;
                        case 6:
                            register.RegAddr = ((ulong)300000 + Convert.ToUInt64(nudRegisterStartAddress.Value)) + Convert.ToUInt64((ulong)i);
                            register.RegName = "Holding";
                            break;
                        case 15:
                            register.RegAddr = ((ulong)100000 + Convert.ToUInt64(nudRegisterStartAddress.Value)) + Convert.ToUInt64((ulong)i);
                            register.RegName = "Coil";
                            register.RegFormat = FormatData.BOOL;
                            break;
                        case 16:
                            register.RegAddr = ((ulong)300000 + Convert.ToUInt64(nudRegisterStartAddress.Value)) + Convert.ToUInt64((ulong)i);
                            register.RegName = "Holding";
                            break;
                    }

                    bytes = HEX_OPERATION.BYTEARRAY_COMBINE(bytes, register.RegData);
                }

                olvRegistersWrite.Objects = this.currentCommand.ListRegistersWriteData;
                olvRegistersWrite.BuildList();
                olvRegistersWrite.AutoResizeColumns();

                txtRegistersWriteData.Text = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bytes);
            }
        }

        private void RegistersWriteDataAdd()
        {
            if (this.currentCommand.ListRegistersWriteData != null)
            {
                ProjectRegisterWriteData register = new ProjectRegisterWriteData();
                currentCommand.FunctionCode = FunctionCode();
                switch (currentCommand.FunctionCode)
                {
                    case 5:
                        register.RegAddr = ((ulong)100000 + Convert.ToUInt64(nudRegisterStartAddress.Value)) + Convert.ToUInt64(this.currentCommand.ListRegistersWriteData.Count());
                        register.RegName = "Coil";
                        break;
                    case 6:
                        register.RegName = "Holding";
                        break;
                    case 15:
                        register.RegName = "Coil";
                        break;
                    case 16:
                        register.RegName = "Holding";
                        break;
                }

                this.currentCommand.ListRegistersWriteData.Add(register);
            }

            olvRegistersWrite.Objects = this.currentCommand.ListRegistersWriteData;         
            olvRegistersWrite.BuildList();
            olvRegistersWrite.AutoResizeColumns();
        }

        private void RegistersWriteDataDelete()
        {
            if (this.currentCommand.ListRegistersWriteData != null && this.currentCommand.ListRegistersWriteData.Count() > 0)
            {
                this.currentCommand.ListRegistersWriteData.RemoveAt(this.currentCommand.ListRegistersWriteData.Count() - 1);
            }

            olvRegistersWrite.Objects = this.currentCommand.ListRegistersWriteData;       
            olvRegistersWrite.BuildList();
            olvRegistersWrite.AutoResizeColumns();
        }

        private void olvRegistersWrite_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Column == olvColumnFormatData)
            {
                // Создаем ComboBox
                ComboBox comboBox = new ComboBox();
                comboBox.Bounds = e.CellBounds;
                comboBox.Font = ((ObjectListView)sender).Font;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Items.AddRange(Enum.GetNames(typeof(FormatData)));

                ProjectRegisterWriteData register = (ProjectRegisterWriteData)e.RowObject;
                comboBox.SelectedIndex = comboBox.FindString(Enum.GetName(typeof(FormatData), register.RegFormat));

                // Подписываемся на событие, чтобы обновить значение
                comboBox.SelectedIndexChanged += (s, args) =>
                {
                    if (comboBox.SelectedItem != null)
                    {
                        FormatData selectedValue = (FormatData)Enum.Parse(typeof(FormatData), comboBox.SelectedItem.ToString());
                        register.RegFormat = selectedValue; // Обновляем значение в объекте
                        olvRegistersWrite.SelectedObject = register;
                        olvRegistersWrite.BuildList();
                        e.NewValue = selectedValue;
                    }
                };

                e.Control = comboBox;

                // Одновременно гарантируем, что ComboBox будет уничтожен после закрытия
                comboBox.LostFocus += (s, args) =>
                {
                    comboBox.Dispose();
                };
            }
        }

        private void olvRegistersWrite_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column == olvColumnFormatData)
            {
                ProjectRegisterWriteData register = (ProjectRegisterWriteData)e.RowObject;

                // Убедитесь, что значение было изменено и требуется сохранение
                if (e.NewValue != e.Control.Text)
                {
                    // Здесь можно добавить дополнительную логику, если это необходимо
                    FormatData selectedValue = (FormatData)Enum.Parse(typeof(FormatData), e.Control.Text);
                    register.RegFormat = selectedValue; // Обновляем значение в объекте
                    olvRegistersWrite.SelectedObject = register;
                    olvRegistersWrite.BuildList();
                    e.NewValue = selectedValue;
                }

                olvRegistersWrite.RefreshObject(e.RowObject);
            }
        }

        private void olvRegistersWrite_CellEditFinished(object sender, CellEditEventArgs e)
        {
            if (e.Column == olvColumnFormatData)
            {

            }
        }



    }

}
