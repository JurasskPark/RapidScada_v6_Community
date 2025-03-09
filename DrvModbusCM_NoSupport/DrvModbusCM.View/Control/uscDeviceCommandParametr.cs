using Scada.Comm.Drivers.DrvModbusCM;
using System.Data;
using System.Text.RegularExpressions;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscDeviceCommandParametr : UserControl
    {
        public uscDeviceCommandParametr()
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
        private ulong tmpDeviceCommandFunctionCode;
        private ulong deviceCommandFunctionCode;
        public ulong DeviceCommandFunctionCode
        {
            get { return deviceCommandFunctionCode; }
            set { deviceCommandFunctionCode = value; }
        }

        private ulong tmpDeviceCommandRegisterStartAddress;
        private ulong tmpDeviceCommandRegisterStartAddressHighByte;
        private ulong tmpDeviceCommandRegisterStartAddressLowByte;
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

        private ulong tmpDeviceCommandRegisterCount;
        private ulong tmpDeviceCommandRegisterCountHighByte;
        private ulong tmpDeviceCommandRegisterCountLowByte;
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

        private ulong tmpDeviceCommandParametr;
        private ulong tmpDeviceCommandParametrHighByte;
        private ulong tmpDeviceCommandParametrLowByte;
        private ulong deviceCommandParametr;
        public ulong DeviceCommandParametr
        {
            get { return deviceCommandParametr; }
            set { deviceCommandParametr = value; }
        }


        //Таблица, где находятся поля DeviceCommandRegisterWriteData
        DataTable dt_DeviceCommandRegisterWriteData = new DataTable();

        #endregion Комманда

        public uscDeviceCommandParametr(ProjectNodeData ProjectNodeData)
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
            tmpDeviceCommandFunctionCode = ProjectNodeData.deviceCommand.DeviceCommandFunctionCode;
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

        public uscDeviceCommandParametr(ushort function = 0)
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
            nudRegisterCount.Value = DeviceCommandRegisterCount;
            nudParametr.Value = DeviceCommandParametr;

            if (DeviceCommandRegisterWriteData != null && DeviceCommandRegisterWriteData.Length >= 1)
            {
                nudRegisterWriteValue.Value = DeviceCommandRegisterWriteData[0];
            }
            
            //Сначала подставляем значения, а потом делаем поиск по index 
            try
            {
                string findFunctionCode = "(" + DeviceCommandFunctionCode.ToString().PadLeft(2, '0') + ")";
                cmbFunctionCode.SelectedIndex = cmbFunctionCode.FindString(findFunctionCode);
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
            DeviceCommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            DeviceCommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            DeviceCommandParametr = Convert.ToUInt64(nudParametr.Value);
            DeviceCommandRegisterWriteData = new ulong[1];
            DeviceCommandRegisterWriteData[0] = Convert.ToUInt64((ulong)nudRegisterWriteValue.Value);
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
                    tmpDeviceCommandFunctionCode = Convert.ToUInt16(match.Value);
                }
            }
            catch { }

            switch(tmpDeviceCommandFunctionCode)
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
                    nudRegisterStartAddressHighByte.Maximum = 45;
                    nudRegisterStartAddressLowByte.Visible = true;
                    nudRegisterStartAddressLowByte.Maximum = 24;

                    nudRegisterCount.Value = 0;

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
                    nudRegisterStartAddressHighByte.Maximum = 45;
                    nudRegisterStartAddressLowByte.Visible = true;
                    nudRegisterStartAddressLowByte.Maximum = 24;
                    nudRegisterCountHighByte.Visible = true;
                    nudRegisterCountHighByte.Maximum = 63;
                    nudRegisterCountHighByte.Minimum = 1;

                    nudRegisterCountLowByte.Value = 0;

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
                tmpDeviceCommandParametr = Convert.ToUInt64(nudParametr.Value);

                nudParametrHighByte.Value = HEX_WORD.FromByteArrayHighByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpDeviceCommandParametr)));
                nudParametrLowByte.Value = HEX_WORD.FromByteArrayLowByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpDeviceCommandParametr)));

                tmpDeviceCommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
                tmpDeviceCommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);

                GenerateName(out string nameCommand);
            }
            catch { }
        }

        private void nudParametrHighByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tmpDeviceCommandParametrHighByte = Convert.ToUInt64(nudParametrHighByte.Value);
                tmpDeviceCommandParametrLowByte = Convert.ToUInt64(nudParametrLowByte.Value);
                nudParametr.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpDeviceCommandParametrLowByte), Convert.ToByte(tmpDeviceCommandParametrHighByte));
            }
            catch { }
        }

        private void nudParametrLowByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tmpDeviceCommandParametrHighByte = Convert.ToUInt64(nudParametrHighByte.Value);
                tmpDeviceCommandParametrLowByte = Convert.ToUInt64(nudParametrLowByte.Value);
                nudParametr.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpDeviceCommandParametrLowByte), Convert.ToByte(tmpDeviceCommandParametrHighByte));
            }
            catch { }
        }
        #endregion Изменение параметра

        #region Изменение Начального адреса регистра

        private void nudRegisterStartAddress_ValueChanged(object sender, EventArgs e)
        {
            tmpDeviceCommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);

            nudRegisterStartAddressHighByte.Value = HEX_WORD.FromByteArrayHighByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpDeviceCommandRegisterStartAddress)));
            nudRegisterStartAddressLowByte.Value = HEX_WORD.FromByteArrayLowByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpDeviceCommandRegisterStartAddress)));

            tmpDeviceCommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);
            tmpDeviceCommandParametr = Convert.ToUInt64(nudParametr.Value);
            UpDownRegisterStartAddressValue = tmpDeviceCommandRegisterStartAddress;

            GenerateName(out string nameCommand);
        }

        private void nudRegisterStartAddressHighByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tmpDeviceCommandRegisterStartAddressHighByte = Convert.ToUInt64(nudRegisterStartAddressHighByte.Value);
                tmpDeviceCommandRegisterStartAddressLowByte = Convert.ToUInt64(nudRegisterStartAddressLowByte.Value);
                nudRegisterStartAddress.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpDeviceCommandRegisterStartAddressLowByte), Convert.ToByte(tmpDeviceCommandRegisterStartAddressHighByte));
            }
            catch { }
        }

        private void nudRegisterStartAddressLowByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tmpDeviceCommandRegisterStartAddressHighByte = Convert.ToUInt64(nudRegisterStartAddressHighByte.Value);
                tmpDeviceCommandRegisterStartAddressLowByte = Convert.ToUInt64(nudRegisterStartAddressLowByte.Value);
                nudRegisterStartAddress.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpDeviceCommandRegisterStartAddressLowByte), Convert.ToByte(tmpDeviceCommandRegisterStartAddressHighByte));
            }
            catch { }
        }

        #endregion Изменение Начального адреса регистра

        #region Изменение количества регистров
        private void nudRegisterCount_ValueChanged(object sender, EventArgs e)
        {
            tmpDeviceCommandRegisterCount = Convert.ToUInt64(nudRegisterCount.Value);

            nudRegisterCountHighByte.Value = HEX_WORD.FromByteArrayHighByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpDeviceCommandRegisterCount)));
            nudRegisterCountLowByte.Value = HEX_WORD.FromByteArrayLowByte(HEX_WORD.ToByteArray(Convert.ToUInt16(tmpDeviceCommandRegisterCount)));

            tmpDeviceCommandRegisterStartAddress = Convert.ToUInt64(nudRegisterStartAddress.Value);
            tmpDeviceCommandParametr = Convert.ToUInt64(nudParametr.Value);
            UpDownRegisterCountValue = tmpDeviceCommandRegisterCount;

            GenerateName(out string nameCommand);
        }

        private void nudRegisterCountHighByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tmpDeviceCommandRegisterCountHighByte = Convert.ToUInt64(nudRegisterCountHighByte.Value);
                tmpDeviceCommandRegisterCountLowByte = Convert.ToUInt64(nudRegisterCountLowByte.Value);
                nudRegisterCount.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpDeviceCommandRegisterCountLowByte), Convert.ToByte(tmpDeviceCommandRegisterCountHighByte));
            }
            catch { }
        }

        private void nudRegisterCountLowByte_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tmpDeviceCommandRegisterCountHighByte = Convert.ToUInt64(nudRegisterCountHighByte.Value);
                tmpDeviceCommandRegisterCountLowByte = Convert.ToUInt64(nudRegisterCountLowByte.Value);
                nudRegisterCount.Value = HEX_WORD.FromBytes(Convert.ToByte(tmpDeviceCommandRegisterCountLowByte), Convert.ToByte(tmpDeviceCommandRegisterCountHighByte));
            }
            catch { }
        }
        #endregion Изменение количества регистров

        #region Генерация имени команды
        public void GenerateName(out string nameCommand)
        {
            nameCommand = "Команда:[" + tmpDeviceCommandFunctionCode + "][" + tmpDeviceCommandParametr +"][" + tmpDeviceCommandRegisterStartAddress + "][" + tmpDeviceCommandRegisterCount + "]";
            txtDeviceCommandName.Text = nameCommand;
        }
        #endregion Генерация имени команды

    }
}
