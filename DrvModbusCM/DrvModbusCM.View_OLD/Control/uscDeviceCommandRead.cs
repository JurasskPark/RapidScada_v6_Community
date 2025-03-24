using Scada.Comm.Drivers.DrvModbusCM;
using System.Data;
using System.Text.RegularExpressions;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscCommandRead : UserControl
    {
        public uscCommandRead()
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

        //ID группы
        private Guid deviceGroupCommandID;
        public Guid GroupCommandID
        {
            get { return deviceGroupCommandID; }
            set { deviceGroupCommandID = value; }
        }

        //ID команды
        private Guid commandID;
        public Guid CommandID
        {
            get { return commandID; }
            set { commandID = value; }
        }

        //Иконка устройства
        private string commandKeyImage;
        public string KeyImage
        {
            get { return commandKeyImage; }
            set { commandKeyImage = value; }
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
            set { this.upDownRegisterStartAddressValue = value; }
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
            set { this.upDownRegisterCountValue = value; }
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

        public uscCommandRead(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            //DeviceID = ProjectNodeData.Command.DeviceID;
            GroupCommandID = ProjectNodeData.Command.ParentID;
            CommandID = ProjectNodeData.Command.ID;
            KeyImage = ProjectNodeData.Command.KeyImage;
            CommandName = ProjectNodeData.Command.CommandName;
            CommandDescription = ProjectNodeData.Command.CommandDescription;
            CommandEnabled = ProjectNodeData.Command.CommandEnabled;
            CommandFunctionCode = ProjectNodeData.Command.CommandFunctionCode;
            tmp_commandFunctionCode = ProjectNodeData.Command.CommandFunctionCode;
            CommandRegisterStartAddress = ProjectNodeData.Command.CommandRegisterStartAddress;
            CommandRegisterCount = ProjectNodeData.Command.CommandRegisterCount;
            CommandRegisterNameReadData = ProjectNodeData.Command.CommandRegisterNameReadData;
            CommandRegisterReadData = ProjectNodeData.Command.CommandRegisterReadData;
            CommandRegisterNameWriteData = ProjectNodeData.Command.CommandRegisterNameWriteData;
            CommandRegisterWriteData = ProjectNodeData.Command.CommandRegisterWriteData;
            CommandParametr = ProjectNodeData.Command.CommandParametr;

            InitializeComponent();
            FormatWindow(true);
        }

        public uscCommandRead(ushort function = 0)
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

        private void uscCommandRead_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();
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
                string findFunctionCode = "(" + CommandFunctionCode.ToString().PadLeft(2, '0') + ")";
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

            if (commandName == "")
            {
                MessageBox.Show(DriverDictonary.WarningEmpty);
                return;
            }
            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form

            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
           // projectNodeData.Command.DeviceID = DeviceID;
            projectNodeData.Command.ParentID = GroupCommandID;
            projectNodeData.Command.ID = CommandID;
            projectNodeData.Command.CommandName = CommandName;
            projectNodeData.Command.CommandDescription = CommandDescription;
            projectNodeData.Command.CommandEnabled = CommandEnabled;
            projectNodeData.Command.CommandFunctionCode = CommandFunctionCode;
            projectNodeData.Command.CommandRegisterStartAddress = CommandRegisterStartAddress;
            projectNodeData.Command.CommandRegisterCount = CommandRegisterCount;
            projectNodeData.Command.CommandRegisterNameReadData = CommandRegisterNameReadData;
            projectNodeData.Command.CommandRegisterReadData = CommandRegisterReadData;
            projectNodeData.Command.CommandRegisterNameWriteData = CommandRegisterNameWriteData;
            projectNodeData.Command.CommandRegisterWriteData = CommandRegisterWriteData;
            projectNodeData.Command.CommandParametr = CommandParametr;
            projectNodeData.Command.KeyImage = stn.ImageKey = stn.SelectedImageKey = ProjectCommand.KeyImageName(CommandFunctionCode);

            stn.Text = CommandName;
            stn.Tag = projectNodeData;
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

            //Генерация имени
            GenerateName(out string nameCommand);
        }
        #endregion Изменение Функции

        #region Изменение Начального адреса регистра

        private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            tmp_commandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_commandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterStartAddressValue = tmp_commandRegisterStartAddress;
            GenerateName(out string nameCommand);
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            tmp_commandRegisterStartAddress = Convert.ToUInt16(nudRegisterStartAddress.Value);
            tmp_commandRegisterCount = Convert.ToUInt16(nudRegisterCount.Value);
            UpDownRegisterCountValue = tmp_commandRegisterCount;
            GenerateName(out string nameCommand);
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        public void GenerateName(out string nameCommand)
        {
            nameCommand = "Команда:[" + tmp_commandFunctionCode + "][" + tmp_commandRegisterStartAddress + "][" + tmp_commandRegisterCount + "]";
            txtCommandName.Text = nameCommand;
        }

        #endregion Генерация имени команды

    }
}
