using Scada.Agent;
using Scada.Comm.Devices;
using Scada.Data.Entities;
using Scada.Forms;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscCommandParametr : UserControl
    {
        public uscCommandParametr()
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
        private ulong tmpCommandFunctionCode;
        private ulong commandFunctionCode;
        public ulong CommandFunctionCode
        {
            get { return commandFunctionCode; }
            set { commandFunctionCode = value; }
        }

        private ulong tmpCommandRegisterStartAddress;
        private ulong tmpCommandRegisterStartAddressHighByte;
        private ulong tmpCommandRegisterStartAddressLowByte;
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

        private ulong tmpCommandRegisterCount;
        private ulong tmpCommandRegisterCountHighByte;
        private ulong tmpCommandRegisterCountLowByte;
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

        private ulong tmpCommandParametr;
        private ulong tmpCommandParametrHighByte;
        private ulong tmpCommandParametrLowByte;
        private ulong commandParametr;
        public ulong CommandParametr
        {
            get { return commandParametr; }
            set { commandParametr = value; }
        }

        private bool commandCurrentValue;
        public bool CommandCurrentValue
        {
            get { return commandCurrentValue; }
            set { commandCurrentValue = value; }
        }

        //Отключение выполнения
        bool dontRunHandler = false;

        //Таблица, где находятся поля CommandRegisterWriteData
        DataTable dt_CommandRegisterWriteData = new DataTable();

        #endregion Комманда

        public uscCommandParametr(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            //DeviceID = ProjectNodeData.Command.ID;
            CommandID = ProjectNodeData.Command.ID;
            GroupCommandID = ProjectNodeData.Command.ParentID;

            KeyImage = ProjectNodeData.Command.KeyImage;
            CommandName = ProjectNodeData.Command.CommandName;
            CommandDescription = ProjectNodeData.Command.CommandDescription;
            CommandEnabled = ProjectNodeData.Command.CommandEnabled;
            CommandFunctionCode = ProjectNodeData.Command.CommandFunctionCode;
            tmpCommandFunctionCode = ProjectNodeData.Command.CommandFunctionCode;
            CommandRegisterStartAddress = ProjectNodeData.Command.CommandRegisterStartAddress;
            CommandRegisterCount = ProjectNodeData.Command.CommandRegisterCount;
            CommandRegisterNameReadData = ProjectNodeData.Command.CommandRegisterNameReadData;
            CommandRegisterReadData = ProjectNodeData.Command.CommandRegisterReadData;
            CommandRegisterNameWriteData = ProjectNodeData.Command.CommandRegisterNameWriteData;
            CommandRegisterWriteData = ProjectNodeData.Command.CommandRegisterWriteData;
            CommandParametr = ProjectNodeData.Command.CommandParametr;
            CommandCurrentValue = ProjectNodeData.Command.CommandCurrentValue;

            InitializeComponent();
            FormatWindow(true);
        }

        public uscCommandParametr(ushort function = 0)
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
                btnSave.Visible = true;
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
            txtName.Text = CommandName;
            ckbEnabled.Checked = CommandEnabled;

            nudParametr.Value = CommandParametr;
            nudRegisterStartAddress.Value = CommandRegisterStartAddress;
            nudRegisterCount.Value = CommandRegisterCount;


            if (CommandRegisterWriteData != null && CommandRegisterWriteData.Length >= 1)
            {
                nudRegisterWriteValue.Value = CommandRegisterWriteData[0];
            }

            //Сначала подставляем значения, а потом делаем поиск по index 
            try
            {
                string findFunctionCode = "(" + CommandFunctionCode.ToString().PadLeft(2, '0') + ")";
                cmbFunctionCode.SelectedIndex = cmbFunctionCode.FindString(findFunctionCode);
            }
            catch { }

            ckbCurrentReadings.Checked = CommandCurrentValue;
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
            //projectNodeData.Command.DeviceID = DeviceID;
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
            projectNodeData.Command.CommandCurrentValue = CommandCurrentValue;
            projectNodeData.Command.KeyImage = stn.ImageKey = stn.SelectedImageKey = ProjectCommand.KeyImageName(CommandFunctionCode);

            stn.Text = CommandName;
            stn.Tag = projectNodeData;
        }

        private void ControlsToConfig()
        {
            CommandName = txtName.Text;
            CommandEnabled = ckbEnabled.Checked;
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
            CommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            CommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            CommandParametr = Convert.ToUInt64(nudParametr.Value);
            CommandRegisterWriteData = new ulong[1];
            CommandRegisterWriteData[0] = Convert.ToUInt64((ulong)nudRegisterWriteValue.Value);
            CommandCurrentValue = ckbCurrentReadings.Checked;
        }

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
                    tmpCommandFunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }

            switch (tmpCommandFunctionCode)
            {
                case 80:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;
                    lblParametrLowByte.Visible = true;
                    lblRegisterStartAddressHighByte.Visible = true;

                    lblParametrHighByte.Text = lblNku.Text;
                    lblParametrLowByte.Text = lblParameterCode.Text;
                    lblRegisterStartAddressHighByte.Text = lblNumberOfParameters.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrLowByte.Visible = true;
                    nudRegisterStartAddressHighByte.Visible = true;

                    nudRegisterStartAddressHighByte.Maximum = 63;
                    nudRegisterStartAddressHighByte.Minimum = 1;

                    nudRegisterStartAddressLowByte.Value = 0;
                    nudRegisterCount.Value = 0;

                    lblInformation.Text = @$"
Номер канала учета – номер канала учета (трубопровода) или узла учета (потребителя);
Код параметра – двухзначный код параметра (в соответствии с руководством по эксплуатации вычислителя);
Кол-во параметров – количество последовательно передаваемых значений параметров (от 1 до 63).
";

                    break;
                case 81:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;

                    lblParametrHighByte.Text = lblTypeOfParameter.Text;

                    nudParametrHighByte.Visible = true;

                    nudParametrHighByte.Maximum = 4;

                    nudParametrLowByte.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    lblInformation.Text = @$"
Тип параметра = 0…4 – это параметр, определяющий, какой набор текущих значений будут
передан в ответе при различных значениях Тип параметра.
";

                    break;
                case 82:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;

                    lblParametrHighByte.Text = lblTypeOfParameter.Text;

                    nudParametrHighByte.Visible = true;

                    nudParametrHighByte.Maximum = 1;

                    nudParametrLowByte.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    lblInformation.Text = @$"
Тип параметра = 0…1 – это параметр, определяющий, какой набор текущих значений будут
передан в ответе при различных значениях Тип параметра.
";

                    break;
                case 83:

                    ElementsDefault();

                    nudParametr.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
                case 84:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;
                    lblParametrLowByte.Visible = true;
                    lblRegisterStartAddressHighByte.Visible = true;
                    lblRegisterStartAddressLowByte.Visible = true;

                    lblParametrHighByte.Text = lblNku.Text;
                    lblParametrLowByte.Text = lblParameterCode.Text;
                    lblRegisterStartAddressHighByte.Text = lblDay.Text;
                    lblRegisterStartAddressLowByte.Text = lblMonth.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrLowByte.Visible = true;
                    nudRegisterStartAddressHighByte.Visible = true;
                    nudRegisterStartAddressHighByte.Minimum = 1;
                    nudRegisterStartAddressHighByte.Maximum = 45;
                    nudRegisterStartAddressLowByte.Visible = true;
                    nudRegisterStartAddressLowByte.Minimum = 1;
                    nudRegisterStartAddressLowByte.Maximum = 24;

                    nudRegisterCount.Value = 0;
                    ckbCurrentReadings.Visible = true;

                    lblInformation.Text = @$"
Код параметра:
Тепловая энергия или электроэнергия - 10
Объем в рабочих условиях - 35
Масса воды, пара или объем газа, приведенный к стандартным условиям, или электроэнергия по каналу учета - 40
Давление - 43
Температура - 46
";

                    break;
                case 85:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;
                    lblParametrLowByte.Visible = true;
                    lblRegisterStartAddressHighByte.Visible = true;
                    lblRegisterStartAddressLowByte.Visible = true;
                    lblRegisterCountHighByte.Visible = true;

                    lblParametrHighByte.Text = lblNku.Text;
                    lblParametrLowByte.Text = lblParameterCode.Text;
                    lblRegisterStartAddressHighByte.Text = lblDay.Text;
                    lblRegisterStartAddressLowByte.Text = lblMonth.Text;
                    lblRegisterCountHighByte.Text = lblNumberOfDays.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrLowByte.Visible = true;
                    nudRegisterStartAddressHighByte.Visible = true;
                    nudRegisterStartAddressHighByte.Minimum = 1;
                    nudRegisterStartAddressHighByte.Maximum = 45;
                    nudRegisterStartAddressLowByte.Visible = true;
                    nudRegisterStartAddressLowByte.Minimum = 1;
                    nudRegisterStartAddressLowByte.Maximum = 24;
                    nudRegisterCountHighByte.Visible = true;
                    nudRegisterCountHighByte.Maximum = 63;
                    nudRegisterCountHighByte.Minimum = 1;

                    nudRegisterCountLowByte.Value = 0;
                    ckbCurrentReadings.Visible = true;

                    lblInformation.Text = @$"
Код параметра:
Тепловая энергия или электроэнергия - 9 
Масса утечек или суммарный объем газа, приведенный к стандартным условиям - 14 
Электроэнергия по основному тарифу - 20 
Электроэнергия по льготному тарифу - 23 
Суммарное время перерывов питания за сутки - 14 
Договорная температура холодной воды - 19 
Барометрическое давление - 22 
Температура наружного воздуха - 25 
Объем в рабочих условиях - 34 
Масса воды, пара или объем газа, приведенный к стандартным условиям, или электроэнергия по каналу учета - 39 
Давление - 42 
Температура - 45 
Удельная теплота сгорания газа - 57 
Плотность природного газа в стандартных условиях - 59 
Концентрация азота в природном газе - 61 
Концентрация диоксида углерода в природном газе - 63 
";

                    break;
                case 86:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;
                    lblParametrLowByte.Visible = true;
                    lblRegisterStartAddressHighByte.Visible = true;
                    lblRegisterStartAddressLowByte.Visible = true;
                    lblRegisterCountHighByte.Visible = true;

                    lblParametrHighByte.Text = lblNku.Text;
                    lblParametrLowByte.Text = lblParameterCode.Text;
                    lblRegisterStartAddressHighByte.Text = lblMonth.Text;
                    lblRegisterStartAddressLowByte.Text = lblYear.Text;
                    lblRegisterCountHighByte.Text = lblNumberOfMonths.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrLowByte.Visible = true;
                    nudRegisterStartAddressHighByte.Visible = true;
                    nudRegisterStartAddressHighByte.Maximum = 12;
                    nudRegisterStartAddressLowByte.Visible = true;
                    nudRegisterStartAddressLowByte.Maximum = 50;
                    nudRegisterCountHighByte.Visible = true;
                    nudRegisterCountHighByte.Maximum = 49;
                    nudRegisterCountHighByte.Minimum = 1;

                    nudRegisterCountLowByte.Value = 0;
                    ckbCurrentReadings.Visible = true;

                    lblInformation.Text = @$"
Код параметра:
Тепловая энергия или электроэнергия - 7
Суммарное время перерывов питания за месяц - 12 
Масса воды, пара или объем газа, приведенный к стандартным условиям, или электроэнергия по каналу учета - 37 
";

                    break;
                case 87:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;

                    lblParametrHighByte.Text = lblNku.Text;

                    nudParametrHighByte.Visible = true;

                    nudParametrLowByte.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
                case 88:

                    ElementsDefault();

                    nudParametr.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
                case 90:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;

                    lblParametrHighByte.Text = lblArchiveNumber.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrHighByte.Maximum = 100;
                    nudParametrLowByte.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
                case 91:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;

                    lblParametrHighByte.Text = lblArchiveNumber.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrHighByte.Maximum = 449;
                    nudParametrLowByte.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
                case 92:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;

                    lblParametrHighByte.Text = lblArchiveNumber.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrHighByte.Maximum = 30;
                    nudParametrLowByte.Value = 0;
                    nudRegisterStartAddress.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
                case 95:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;
                    lblParametrLowByte.Visible = true;
                    lblRegisterStartAddressHighByte.Visible = true;

                    lblParametrHighByte.Text = lblNku.Text;
                    lblParametrLowByte.Text = lblParameterCode.Text;
                    lblRegisterStartAddressHighByte.Text = lblNumberOfParameters.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrLowByte.Visible = true;
                    nudRegisterWriteValue.Visible = true;

                    nudRegisterStartAddressLowByte.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
                case 96:

                    ElementsDefault();

                    lblParametrHighByte.Visible = true;
                    lblParametrLowByte.Visible = true;
                    lblRegisterStartAddressHighByte.Visible = true;

                    lblParametrHighByte.Text = lblNku.Text;
                    lblParametrLowByte.Text = lblParameterCode.Text;
                    lblRegisterStartAddressHighByte.Text = lblParameterValue.Text;

                    nudParametrHighByte.Visible = true;
                    nudParametrLowByte.Visible = true;
                    nudRegisterWriteValue.Visible = true;

                    nudRegisterStartAddressLowByte.Value = 0;
                    nudRegisterCount.Value = 0;

                    break;
            }

            //Генерация имени
            GenerateName(out string nameCommand);
        }

        private void ElementsDefault()
        {
            #region Hide
            lblParametrHighByte.Visible = false;
            lblParametrLowByte.Visible = false;

            nudParametrHighByte.Visible = false;
            nudParametrLowByte.Visible = false;
            nudParametr.Visible = false;

            lblRegisterStartAddressHighByte.Visible = false;
            lblRegisterStartAddressLowByte.Visible = false;

            nudRegisterStartAddressHighByte.Visible = false;
            nudRegisterStartAddressLowByte.Visible = false;
            nudRegisterStartAddress.Visible = false;

            lblRegisterCountHighByte.Visible = false;
            lblRegisterCountLowByte.Visible = false;

            nudRegisterCountHighByte.Visible = false;
            nudRegisterCountLowByte.Visible = false;
            nudRegisterCount.Visible = false;

            nudRegisterWriteValue.Visible = false;
            ckbCurrentReadings.Visible = false;
            #endregion Hide

            #region Min Max

            nudParametrHighByte.Maximum = 255;
            nudParametrHighByte.Minimum = 0;
            nudParametrLowByte.Maximum = 255;
            nudParametrLowByte.Minimum = 0;
            nudParametr.Maximum = 65535;
            nudParametr.Minimum = 0;

            nudRegisterStartAddressHighByte.Maximum = 255;
            nudRegisterStartAddressHighByte.Minimum = 0;
            nudRegisterStartAddressLowByte.Maximum = 255;
            nudRegisterStartAddressLowByte.Minimum = 0;
            nudRegisterStartAddress.Maximum = 65535;
            nudRegisterStartAddress.Minimum = 0;

            nudRegisterCountHighByte.Maximum = 255;
            nudRegisterCountHighByte.Minimum = 0;
            nudRegisterCountLowByte.Maximum = 255;
            nudRegisterCountLowByte.Minimum = 0;
            nudRegisterCount.Maximum = 65535;
            nudRegisterCount.Minimum = 0;

            #endregion Min Max

            #region Information

            lblInformation.Text = String.Empty;

            #endregion Information
        }

        #endregion Изменение Функции

        #region Изменение параметра
        private void nudParametr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tmpCommandParametr = Convert.ToUInt64(nudParametr.Value);

                tmpCommandParametrHighByte = HEX_WORD.FromByteArrayHighByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpCommandParametr)));
                tmpCommandParametrLowByte = HEX_WORD.FromByteArrayLowByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpCommandParametr)));

                dontRunHandler = true;
                nudParametrLowByte.Value = tmpCommandParametrLowByte;
                nudParametrHighByte.Value = tmpCommandParametrHighByte;
                dontRunHandler = false;

                tmpCommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
                tmpCommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);

                GenerateName(out string nameCommand);
            }
            catch { }
        }

        private void nudParametrHighByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dontRunHandler == true)
                {
                    return;
                }

                tmpCommandParametrHighByte = Convert.ToUInt64(nudParametrHighByte.Value);
                tmpCommandParametrLowByte = Convert.ToUInt64(nudParametrLowByte.Value);
                nudParametr.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpCommandParametrLowByte), Convert.ToByte(tmpCommandParametrHighByte));
            }
            catch { }
        }

        private void nudParametrLowByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dontRunHandler == true)
                {
                    return;
                }

                tmpCommandParametrHighByte = Convert.ToUInt64(nudParametrHighByte.Value);
                tmpCommandParametrLowByte = Convert.ToUInt64(nudParametrLowByte.Value);
                nudParametr.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpCommandParametrLowByte), Convert.ToByte(tmpCommandParametrHighByte));
            }
            catch { }
        }
        #endregion Изменение параметра

        #region Изменение Начального адреса регистра

        private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            tmpCommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);

            tmpCommandRegisterStartAddressHighByte = HEX_WORD.FromByteArrayHighByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpCommandRegisterStartAddress)));
            tmpCommandRegisterStartAddressLowByte = HEX_WORD.FromByteArrayLowByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpCommandRegisterStartAddress)));

            dontRunHandler = true;
            nudRegisterStartAddressHighByte.Value = tmpCommandRegisterStartAddressHighByte;
            nudRegisterStartAddressLowByte.Value = tmpCommandRegisterStartAddressLowByte;
            dontRunHandler = false;

            tmpCommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            tmpCommandParametr = Convert.ToUInt64(nudParametr.Value);

            GenerateName(out string nameCommand);
        }

        private void nudRegisterStartAddressHighByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dontRunHandler == true)
                {
                    return;
                }

                tmpCommandRegisterStartAddressHighByte = Convert.ToUInt64(nudRegisterStartAddressHighByte.Value);
                tmpCommandRegisterStartAddressLowByte = Convert.ToUInt64(nudRegisterStartAddressLowByte.Value);
                nudRegisterStartAddress.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpCommandRegisterStartAddressLowByte), Convert.ToByte(tmpCommandRegisterStartAddressHighByte));
            }
            catch { }
        }

        private void nudRegisterStartAddressLowByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dontRunHandler == true)
                {
                    return;
                }

                tmpCommandRegisterStartAddressHighByte = Convert.ToUInt64(nudRegisterStartAddressHighByte.Value);
                tmpCommandRegisterStartAddressLowByte = Convert.ToUInt64(nudRegisterStartAddressLowByte.Value);
                nudRegisterStartAddress.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpCommandRegisterStartAddressLowByte), Convert.ToByte(tmpCommandRegisterStartAddressHighByte));
            }
            catch { }
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            tmpCommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);

            tmpCommandRegisterCountHighByte = HEX_WORD.FromByteArrayHighByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpCommandRegisterCount)));
            tmpCommandRegisterCountLowByte = HEX_WORD.FromByteArrayLowByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpCommandRegisterCount)));

            dontRunHandler = true;
            nudRegisterCountHighByte.Value = tmpCommandRegisterCountHighByte;
            nudRegisterCountLowByte.Value = tmpCommandRegisterCountLowByte;
            dontRunHandler = false;

            tmpCommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            tmpCommandParametr = Convert.ToUInt64(nudParametr.Value);

            GenerateName(out string nameCommand);
        }

        private void nudRegisterCountHighByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dontRunHandler == true)
                {
                    return;
                }

                tmpCommandRegisterCountHighByte = Convert.ToUInt64(nudRegisterCountHighByte.Value);
                tmpCommandRegisterCountLowByte = Convert.ToUInt64(nudRegisterCountLowByte.Value);
                nudRegisterCount.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpCommandRegisterCountLowByte), Convert.ToByte(tmpCommandRegisterCountHighByte));
            }
            catch { }
        }

        private void nudRegisterCountLowByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dontRunHandler == true)
                {
                    return;
                }

                tmpCommandRegisterCountHighByte = Convert.ToUInt64(nudRegisterCountHighByte.Value);
                tmpCommandRegisterCountLowByte = Convert.ToUInt64(nudRegisterCountLowByte.Value);
                nudRegisterCount.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpCommandRegisterCountLowByte), Convert.ToByte(tmpCommandRegisterCountHighByte));
            }
            catch { }
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        public void GenerateName(out string nameCommand)
        {
            nameCommand = "Команда:[" + tmpCommandFunctionCode + "][" + tmpCommandParametr + "][" + tmpCommandRegisterStartAddress + "][" + tmpCommandRegisterCount + "]";
            txtName.Text = nameCommand;
        }
        #endregion Генерация имени команды

        #region Текущие показания
        private void ckbCurrentReadings_CheckedChanged(object sender, EventArgs e)
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
                    tmpCommandFunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }

            if (ckbCurrentReadings.Checked == true)
            {
                lblRegisterStartAddressHighByte.Visible = false;
                nudRegisterStartAddressHighByte.Visible = false;

                lblRegisterStartAddressLowByte.Visible = false;
                nudRegisterStartAddressLowByte.Visible = false;

                if (tmpCommandFunctionCode != 84)
                {
                    lblRegisterCountHighByte.Visible = false;
                    nudRegisterCountHighByte.Visible = false;
                }
            }
            else
            {
                lblRegisterStartAddressHighByte.Visible = true;
                nudRegisterStartAddressHighByte.Visible = true;

                lblRegisterStartAddressLowByte.Visible = true;
                nudRegisterStartAddressLowByte.Visible = true;

                if (tmpCommandFunctionCode != 84)
                {
                    lblRegisterCountHighByte.Visible = true;
                    nudRegisterCountHighByte.Visible = true;
                }
            }
        }

        #endregion Текущие показания


    }
}
