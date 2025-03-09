using Scada.Comm.Drivers.DrvModbusCM;
using System.Data;
using System.Text.RegularExpressions;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscDeviceCommandRead : UserControl
    {
        public uscDeviceCommandRead()
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

        //ID группы
        private Guid deviceGroupCommandID;
        public Guid DeviceGroupCommandID
        {
            get { return deviceGroupCommandID; }
            set { deviceGroupCommandID = value; }
        }

        //ID команды
        private Guid deviceCommandID;
        public Guid DeviceCommandID
        {
            get { return deviceCommandID; }
            set { deviceCommandID = value; }
        }

        //Иконка устройства
        private string deviceCommandKeyImage;
        public string DeviceCommandKeyImage
        {
            get { return deviceCommandKeyImage; }
            set { deviceCommandKeyImage = value; }
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
            set { this.upDownRegisterStartAddressValue = value; }
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
            set { this.upDownRegisterCountValue = value; }
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

        public uscDeviceCommandRead(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            DeviceID = ProjectNodeData.deviceCommand.DeviceID;
            DeviceGroupCommandID = ProjectNodeData.deviceCommand.DeviceGroupCommandID;
            DeviceCommandID = ProjectNodeData.deviceCommand.DeviceCommandID;
            DeviceCommandKeyImage = ProjectNodeData.deviceCommand.DeviceCommandKeyImage;
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

        public uscDeviceCommandRead(ushort function = 0)
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

        private void uscDeviceCommandRead_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();
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
                string findFunctionCode = "(" + DeviceCommandFunctionCode.ToString().PadLeft(2, '0') + ")";
                //Находим индекс        
                int indexCombobox = cmbFunctionCode.FindString(findFunctionCode);
                //Отображаем
                cmbFunctionCode.SelectedIndex = indexCombobox;
            }
            catch { }          
        }

        private void btnCommandSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ControlsToConfig();

            if (deviceCommandName == "")
            {
                MessageBox.Show("Поле Наименование не может быть пустым");
                return;
            }
            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form

            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.deviceCommand.DeviceID = DeviceID;
            projectNodeData.deviceCommand.DeviceGroupCommandID = DeviceGroupCommandID;
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
            projectNodeData.deviceCommand.DeviceCommandKeyImage = stn.ImageKey = stn.SelectedImageKey = ProjectDeviceCommand.KeyImageName(DeviceCommandFunctionCode);

            stn.Text = DeviceCommandName;
            stn.Tag = projectNodeData;
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

            //Генерация имени
            GenerateName(out string nameCommand);
        }
        #endregion Изменение Функции

        #region Изменение Начального адреса регистра

        private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            tmp_deviceCommandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_deviceCommandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterStartAddressValue = tmp_deviceCommandRegisterStartAddress;
            GenerateName(out string nameCommand);
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            tmp_deviceCommandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_deviceCommandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterCountValue = tmp_deviceCommandRegisterCount;
            GenerateName(out string nameCommand);
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        public void GenerateName(out string nameCommand)
        {
            nameCommand = "Команда:[" + tmp_deviceCommandFunctionCode + "][" + tmp_deviceCommandRegisterStartAddress + "][" + tmp_deviceCommandRegisterCount + "]";
            txtDeviceCommandName.Text = nameCommand;
        }

        #endregion Генерация имени команды

    }
}
