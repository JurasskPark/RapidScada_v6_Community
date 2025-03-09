using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scada.Comm.Drivers.DrvModbusCM.View.Forms
{
    public partial class uscDevice : UserControl
    {
        public uscDevice()
        {
            InitializeComponent();
        }

        #region Variables

        #region Device
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

        //Иконка
        private string deviceKeyImage;
        public string DeviceKeyImage
        {
            get { return deviceKeyImage; }
            set { deviceKeyImage = value; }
        }

        //Адрес устройства       
        private ushort deviceAddress;
        public ushort DeviceAddress
        {
            get { return deviceAddress; }
            set { deviceAddress = value; }
        }

        //Протокол
        private int deviceTypeProtocol;
        public int DeviceTypeProtocol
        {
            get { return deviceTypeProtocol; }
            set { deviceTypeProtocol = value; }
        }

        //Название устройства
        private string deviceName;
        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }

        //Описание устройства
        private string deviceDescription;
        public string DeviceDescription
        {
            get { return deviceDescription; }
            set { deviceDescription = value; }
        }

        //Состояние устройства. Включено ли устройство и производить ли его опрос
        private bool deviceEnabled;
        public bool DeviceEnabled
        {
            get { return deviceEnabled; }
            set { deviceEnabled = value; }
        }

        //Признак опроса по расписанию
        private bool devicePollingOnScheduleStatus;
        public bool DevicePollingOnScheduleStatus
        {
            get { return devicePollingOnScheduleStatus; }
            set { devicePollingOnScheduleStatus = value; }
        }

        //Дата последнего успешного опроса устройства
        //DateTime.MinValue;     
        private DateTime deviceDateTimeLastSuccessfully;
        public DateTime DeviceDateTimeLastSuccessfully
        {
            get { return deviceDateTimeLastSuccessfully; }
            set { deviceDateTimeLastSuccessfully = value; }
        }

        //Период опроса устройства                                    
        private int deviceIntervalPool;
        public int DeviceIntervalPool
        {
            get { return deviceIntervalPool; }
            set { deviceIntervalPool = value; }
        }

        //Статус устройства
        private int deviceStatus;
        public int DeviceStatus
        {
            get { return deviceStatus; }
            set { deviceStatus = value; }
        }

        #endregion Device

        #region Commands
        //Количество всего отправленных комманд
        private int deviceCountCommands;
        public int DeviceCountCommands
        {
            get { return deviceCountCommands; }
            set { deviceCountCommands = value; }
        }

        //Количество комманд с успешным ответом
        private int deviceCountCommandsGood;
        public int DeviceCountCommandsGood
        {
            get { return deviceCountCommandsGood; }
            set { deviceCountCommandsGood = value; }
        }

        //Дата последней команды
        private DateTime deviceDateTimeCommandLast;
        public DateTime DeviceDateTimeCommandLast
        {
            get { return deviceDateTimeCommandLast; }
            set { deviceDateTimeCommandLast = value; }
        }

        //Дата последней успешной команды
        private DateTime deviceDateTimeCommandLastGood;
        public DateTime DeviceDateTimeCommandLastGood
        {
            get { return deviceDateTimeCommandLastGood; }
            set { deviceDateTimeCommandLastGood = value; }
        }

        //Приоритет комманд
        private int devicePriorityCommand;
        public int DevicePriorityCommand
        {
            get { return devicePriorityCommand; }
            set { devicePriorityCommand = value; }
        }
        #endregion Commands

        #region Gateway   
        //Протокол
        private int gatewayTypeProtocol;
        public int GatewayTypeProtocol
        {
            get { return gatewayTypeProtocol; }
            set { gatewayTypeProtocol = value; }
        }

        //Адрес устройства в шлюзе
        private int deviceAliesAddress;
        public int DeviceAliesAddress
        {
            get { return deviceAliesAddress; }
            set { deviceAliesAddress = value; }
        }

        //Порт устройства в шлюзе
        private int deviceAliesPort;
        public int DeviceAliesPort
        {
            get { return deviceAliesPort; }
            set { deviceAliesPort = value; }
        }

        #endregion Gateway           

        #region Registers
        //Регистры 0 = 2 байтовые, 1 = 4 байтовые                                   
        private int deviceRegistersBytes;
        public int DeviceRegistersBytes
        {
            get { return deviceRegistersBytes; }
            set { deviceRegistersBytes = value; }
        }

        //Регистры 0 = 2 байтовые, 1 = 4 байтовые                                   
        private int deviceGatewayRegistersBytes;
        public int DeviceGatewayRegistersBytes
        {
            get { return deviceGatewayRegistersBytes; }
            set { deviceGatewayRegistersBytes = value; }
        }

        public bool[] DataCoils = new bool[65535];                              //Coils устройства           (Функция 1)
        public bool[] DataDiscreteInputs = new bool[65535];                     //DiscreteInputs устройства  (Функция 2)
        public ulong[] DataHoldingRegisters = new ulong[65535];                 //HoldingRegister устройства (Функция 3) 
        public ulong[] DataInputRegisters = new ulong[65535];                   //InputRegister устройства   (Функция 4) 

        public bool[] ExistCoils = new bool[65535];                             //Coils устройства           (Функция 1)
        public bool[] ExistDiscreteInputs = new bool[65535];                    //DiscreteInputs устройства  (Функция 2)
        public bool[] ExistHoldingRegisters = new bool[65535];                  //HoldingRegister устройства (Функция 3)
        public bool[] ExistInputRegisters = new bool[65535];                    //InputRegister устройства   (Функция 4)
        #endregion Registers

        #region Format Float
        private int deviceFloatFormat;
        public int DeviceFloatFormat
        {
            get { return deviceFloatFormat; }
            set { deviceFloatFormat = value; }
        }
        #endregion Format Float

        #region InputBox
        public ushort value = 0;
        #endregion InputBox

        #endregion Variables

        #region Load

        public uscDevice(ProjectNodeData ProjectNodeData)
        {
            MTNodeData = ProjectNodeData;

            DeviceID = ProjectNodeData.device.DeviceID;
            DeviceAddress = ProjectNodeData.device.DeviceAddress;
            DeviceName = ProjectNodeData.device.DeviceName;
            DeviceDescription = ProjectNodeData.device.DeviceDescription;
            DeviceEnabled = ProjectNodeData.device.DeviceEnabled;

            DeviceRegistersBytes = ProjectNodeData.device.DeviceRegistersBytes;
            DeviceGatewayRegistersBytes = ProjectNodeData.device.DeviceGatewayRegistersBytes;
            DeviceFloatFormat = ProjectNodeData.device.DeviceFloatFormat;

            DeviceStatus = ProjectNodeData.device.DeviceStatus;
            DevicePollingOnScheduleStatus = ProjectNodeData.device.DevicePollingOnScheduleStatus;
            DeviceIntervalPool = ProjectNodeData.device.DeviceIntervalPool;
            DeviceTypeProtocol = ProjectNodeData.device.DeviceTypeProtocol;

            DeviceDateTimeLastSuccessfully = ProjectNodeData.device.DeviceDateTimeLastSuccessfully;

            DataCoils = MTNodeData.device.DataCoils;                           
            DataDiscreteInputs = MTNodeData.device.DataDiscreteInputs;         
            DataHoldingRegisters = MTNodeData.device.DataHoldingRegisters;     
            DataInputRegisters = MTNodeData.device.DataInputRegisters;         

            ExistCoils = MTNodeData.device.ExistCoils;                      
            ExistDiscreteInputs = MTNodeData.device.ExistDiscreteInputs;    
            ExistHoldingRegisters = MTNodeData.device.ExistHoldingRegisters;
            ExistInputRegisters = MTNodeData.device.ExistInputRegisters;  

            InitializeComponent();
            FormatWindow(true);
        }

        private void FormatWindow(bool hasParent)
        {
            if (hasParent)
            {
                this.BorderStyle = BorderStyle.None;
                btnDeviceSave.Visible = true;
                Dock = DockStyle.Left | DockStyle.Top;
            }
        }

        private void uscDevice_Load(object sender, EventArgs e)
        {
            // set the control values
            ConfigToControls();

            // enable timer
            ckbAutoRefreshListRegisters.Checked = true;
        }

        private void ConfigToControls()
        {
            txtDeviceID.Text = DeviceID.ToString();
            numDeviceAddress.Value = DeviceAddress;
            txtDeviceName.Text = DeviceName;
            txtDeviceDescription.Text = DeviceDescription;
            ckbDeviceEnabled.Checked = DeviceEnabled;

            cmbDeviceRegistersBytes.SelectedIndex = DeviceRegistersBytes;
            cmbDeviceGatewayRegistersBytes.SelectedIndex = DeviceGatewayRegistersBytes;
            cmbDeviceFloatFormat.SelectedIndex = DeviceFloatFormat;

            cmbDeviceStatus.SelectedIndex = DeviceStatus;
            ckbDevicePollingOnScheduleStatus.Checked = DevicePollingOnScheduleStatus;
            
            //DevicePollingOnScheduleStatusChecked();

            numDeviceIntervalPool.Value = DeviceIntervalPool;
            cmbDeviceTypeProtocol.SelectedIndex = DeviceTypeProtocol;

            txtDeviceDateTimeLastSuccessfully.Text = DeviceDateTimeLastSuccessfully.ToString();
        }

        #endregion Load

        #region Save

        private void btnDeviceSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            ControlsToConfig();

            if (deviceName == "")
            {
                MessageBox.Show("Поле Наименование не может быть пустым");
                return;
            }
            //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form

            TreeNode stn = ((FrmConfigForm)this.Parent.Parent.Parent.Parent.Parent).trvProject.SelectedNode;
            ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
            projectNodeData.device.DeviceID = DeviceID;
            projectNodeData.device.DeviceAddress = Convert.ToUInt16(DeviceAddress);
            projectNodeData.device.DeviceName = DeviceName;
            projectNodeData.device.DeviceDescription = DeviceDescription;
            projectNodeData.device.DeviceEnabled = DeviceEnabled;

            projectNodeData.device.DeviceRegistersBytes = DeviceRegistersBytes;
            projectNodeData.device.DeviceGatewayRegistersBytes = DeviceGatewayRegistersBytes;
            projectNodeData.device.DeviceFloatFormat = DeviceFloatFormat;

            projectNodeData.device.DeviceStatus = DeviceStatus;
            projectNodeData.device.DevicePollingOnScheduleStatus = DevicePollingOnScheduleStatus;
            projectNodeData.device.DeviceIntervalPool = DeviceIntervalPool;
            projectNodeData.device.DeviceTypeProtocol = DeviceTypeProtocol;

            projectNodeData.device.DeviceDateTimeLastSuccessfully = DeviceDateTimeLastSuccessfully;

            stn.Text = DeviceName;
            stn.Tag = projectNodeData;
        }

        private void ControlsToConfig()
        {
            DeviceName = txtDeviceName.Text;

            DeviceID = DriverUtils.StringToGuid(txtDeviceID.Text);
            DeviceAddress = Convert.ToUInt16(numDeviceAddress.Value);
            DeviceName = txtDeviceName.Text;
            DeviceDescription = txtDeviceDescription.Text;
            DeviceEnabled = ckbDeviceEnabled.Checked;

            DeviceRegistersBytes = cmbDeviceRegistersBytes.SelectedIndex;
            DeviceGatewayRegistersBytes = cmbDeviceGatewayRegistersBytes.SelectedIndex;
            DeviceFloatFormat = cmbDeviceFloatFormat.SelectedIndex;

            DeviceStatus = cmbDeviceStatus.SelectedIndex;
            DevicePollingOnScheduleStatus = ckbDevicePollingOnScheduleStatus.Checked;
            DeviceIntervalPool = Convert.ToInt32(numDeviceIntervalPool.Value);
            DeviceTypeProtocol = cmbDeviceTypeProtocol.SelectedIndex;

            DeviceDateTimeLastSuccessfully = DateTime.Parse(txtDeviceDateTimeLastSuccessfully.Text.Trim());
        }

        #endregion Save

        #region Component

        private void DevicePollingOnScheduleStatusChecked()
        {
            if (ckbDevicePollingOnScheduleStatus.Checked == true)
            {
                numDeviceIntervalPool.Enabled = true;
            }
            else if (ckbDevicePollingOnScheduleStatus.Checked == false)
            {
                numDeviceIntervalPool.Enabled = false;
            }
        }

        private void ckbDevicePollingOnScheduleStatus_CheckedChanged(object sender, EventArgs e)
        {
            DevicePollingOnScheduleStatusChecked();
        }

        private void lblDeviceStatus_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (cmbDeviceStatus.Enabled == false)
            {
                cmbDeviceStatus.Enabled = true;
            }
            else
            {
                cmbDeviceStatus.Enabled = false;
            }
        }

        private void cmbDeviceRegistersBytes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeviceRegistersBytes.SelectedIndex == 0)
            {
                cmbDeviceGatewayRegistersBytes.SelectedIndex = 0;
                cmbDeviceGatewayRegistersBytes.Enabled = false;
            }
            else
            {
                cmbDeviceGatewayRegistersBytes.Enabled = true;
            }
        }

        #endregion Component

        //#region Локальные переменные

        //private ushort register_start;
        //private ushort register_count;

        //#endregion Локальные переменные



        //public frm_ModbusDeviceBuffer(ProjectNodeData ProjectNodeData)
        //{
        //    MTNodeData = ProjectNodeData;
        //    ModbusDevice = MTNodeData.modbus_device;
        //    DeviceID = MTNodeData.modbus_device.DeviceID;



        //    InitializeComponent();
        //    FormatWindow(true);
        //}

        //private void GetConfig()
        //{

        //}

        //private void SetConfig()
        //{
        //    register_start = (ushort)(Convert.ToUInt16(numRegisterStart.Value));

        //    //Coils
        //    if (DeviceID != null)
        //    {
        //        //Обновление без мерцания
        //        Type type = lstCoils.GetType();
        //        PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //        propertyInfo.SetValue(lstCoils, true, null);

        //        this.lstCoils.BeginUpdate();
        //        this.lstCoils.Items.Clear();
        //        for (int index = 0; index < 1000; ++index)
        //        {
        //            if (ModbusDevice.CoilsExists(Convert.ToUInt16(register_start * 1000 + index)))
        //            {
        //                this.lstCoils.Items.Add(new ListViewItem()
        //                {
        //                    Text = (register_start * 1000 + index + 100000).ToString(),
        //                    SubItems = {
        //                                    ModbusDevice.GetBooleanCoil(Convert.ToUInt16(register_start * 1000 + index)).ToString()
        //                }
        //                });
        //            }
        //        }
        //        this.lstCoils.EndUpdate();
        //    }

        //    //DiscreteInputs
        //    if (DeviceID != null)
        //    {
        //        //Обновление без мерцания
        //        Type type = lstDiscreteInputs.GetType();
        //        PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //        propertyInfo.SetValue(lstDiscreteInputs, true, null);

        //        this.lstDiscreteInputs.BeginUpdate();
        //        this.lstDiscreteInputs.Items.Clear();
        //        for (int index = 0; index < 1000; ++index)
        //        {
        //            if (ModbusDevice.DiscreteInputsExists(Convert.ToUInt16(register_start * 1000 + index)))
        //            {
        //                this.lstDiscreteInputs.Items.Add(new ListViewItem()
        //                {
        //                    Text = (register_start * 1000 + index + 200000).ToString(),
        //                    SubItems = {
        //                                    ModbusDevice.GetBooleanDiscreteInput(Convert.ToUInt16(register_start * 1000 + index)).ToString()
        //                }
        //                });
        //            }
        //        }
        //        this.lstDiscreteInputs.EndUpdate();
        //    }

        //    //HoldingRegisters
        //    if (DeviceID != null)
        //    {
        //        //Обновление без мерцания
        //        Type type = lstHoldingRegisters.GetType();
        //        PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //        propertyInfo.SetValue(lstHoldingRegisters, true, null);

        //        this.lstHoldingRegisters.BeginUpdate();
        //        this.lstHoldingRegisters.Items.Clear();
        //        for (int index = 0; index < 1000; ++index)
        //        {
        //            if (ModbusDevice.HoldingRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
        //            {
        //                if (ModbusDevice.DeviceRegistersBytes == 0)
        //                {
        //                    this.lstHoldingRegisters.Items.Add(new ListViewItem()
        //                    {
        //                        Text = (register_start * 1000 + index + 300000).ToString(),
        //                        SubItems = {
        //                                    Convert.ToString((int) ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(16, '0').ToUpper(),
        //                                    ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString("x4").ToUpper(),
        //                                    ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString(),
        //                        }
        //                    });
        //                }
        //                else if (ModbusDevice.DeviceRegistersBytes == 1)
        //                {
        //                    this.lstHoldingRegisters.Items.Add(new ListViewItem()
        //                    {
        //                        Text = (register_start * 1000 + index + 300000).ToString(),
        //                        SubItems = {
        //                                    Convert.ToString((int) ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper(),
        //                                    ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString("x8").ToUpper(),
        //                                    ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString()
        //                        }
        //                    });
        //                }
        //            }
        //        }
        //        this.lstHoldingRegisters.EndUpdate();
        //    }

        //    //InputRegisters
        //    if (DeviceID != null)
        //    {
        //        //Обновление без мерцания
        //        Type type = lstInputRegisters.GetType();
        //        PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //        propertyInfo.SetValue(lstInputRegisters, true, null);

        //        this.lstInputRegisters.BeginUpdate();
        //        this.lstInputRegisters.Items.Clear();
        //        for (int index = 0; index < 1000; ++index)
        //        {
        //            if (ModbusDevice.InputRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
        //            {
        //                if (ModbusDevice.DeviceRegistersBytes == 0)
        //                {
        //                    this.lstInputRegisters.Items.Add(new ListViewItem()
        //                    {
        //                        Text = (register_start * 1000 + index + 400000).ToString(),
        //                        SubItems = {
        //                                    Convert.ToString((int) ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(16, '0').ToUpper(),
        //                                    ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString("x4").ToUpper(),
        //                                    ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString(),
        //                                    ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString(),
        //                        }
        //                    });
        //                }
        //                else if (ModbusDevice.DeviceRegistersBytes == 1)
        //                {
        //                    this.lstInputRegisters.Items.Add(new ListViewItem()
        //                    {
        //                        Text = (register_start * 1000 + index + 400000).ToString(),
        //                        SubItems = {
        //                                    Convert.ToString((int) ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper(),
        //                                    ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString("x8").ToUpper(),
        //                                    ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString(),
        //                        }
        //                    });
        //                }
        //            }
        //        }
        //        this.lstInputRegisters.EndUpdate();
        //    }
        //}

        //private void numRegisterStart_ValueChanged(object sender, EventArgs e)
        //{
        //    tmr_Timer.Enabled = false;
        //    tmr_Status = false;
        //    lstCoils.Items.Clear();
        //    lstDiscreteInputs.Items.Clear();
        //    lstHoldingRegisters.Items.Clear();
        //    lstInputRegisters.Items.Clear();

        //    register_start = Convert.ToUInt16(numRegisterStart.Value);

        //    SetConfig();

        //    tmr_Timer.Enabled = true;
        //    tmr_Status = true;
        //}


        //private void btnAddСhannel_Click(object sender, EventArgs e)
        //{
        //    Add();
        //}

        //private void Add()
        //{
        //    GetConfig();
        //    if (deviceName == "")
        //    {
        //        MessageBox.Show("Поле Наименование не может быть пустым");
        //        return;
        //    }
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnSaveСhannel_Click(object sender, EventArgs e)
        //{
        //    Save();
        //}

        //private void Save()
        //{
        //    GetConfig();
        //    if (deviceName == "")
        //    {
        //        MessageBox.Show("Поле Наименование не может быть пустым");
        //        return;
        //    }
        //    //Такая партянка из Parent:  TabPage, TabControl, SplitterPanel, SplitConteiner, Form
        //    TreeNode stn = ((frm_MainForm)this.Parent.Parent.Parent.Parent.Parent).trv_Project.SelectedNode;
        //    ProjectNodeData projectNodeData = (ProjectNodeData)stn.Tag;
        //    projectNodeData.modbus_device.DeviceID = DeviceID;
        //    projectNodeData.modbus_device.DeviceAddress = DeviceAddress;
        //    projectNodeData.modbus_device.DeviceName = DeviceName;
        //    projectNodeData.modbus_device.DeviceDescription = DeviceDescription;
        //    projectNodeData.modbus_device.DeviceEnabled = DeviceEnabled;

        //    projectNodeData.modbus_device.DevicePollingOnScheduleStatus = DevicePollingOnScheduleStatus;
        //    projectNodeData.modbus_device.DeviceIntervalPool = DeviceIntervalPool;
        //    projectNodeData.modbus_device.DeviceTypeProtocol = DeviceTypeProtocol;

        //    projectNodeData.modbus_device.DeviceDateTimeLastSuccessfully = DeviceDateTimeLastSuccessfully;

        //    stn.Text = DeviceName;
        //    stn.Tag = projectNodeData;
        //}

        //private void btnCancelСhannel_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Cancel;
        //    Close();
        //}

        //#region Изменение буфера
        //private void Coils_Change()
        //{
        //    ListView lstcoils = this.lstCoils;
        //    if (lstcoils.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstcoils.SelectedItems[0];

        //        int index = selectedIndex.Index;
        //        ushort index_RegAddr = (ushort)(register_start * 1000 + index);
        //        uint RegAddr_Value = Convert.ToUInt32(Convert.ToBoolean(selectedIndex.SubItems[1].Text));

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 0;
        //        InputBox.value = RegAddr_Value;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            //Записываем
        //            bool bool_Value = Convert.ToBoolean(InputBox.value);
        //            ModbusDevice.SetCoil(index_RegAddr, bool_Value);
        //            //Обновляем информацию
        //            SetConfig();
        //            //Прокручиваем
        //            lstCoils.EnsureVisible(index);
        //            lstCoils.TopItem = lstCoils.Items[index];
        //            //Делаем область активной
        //            lstCoils.Focus();
        //            //Делаю нужный элемент выбранным
        //            lstCoils.Items[index].Selected = true;
        //            lstCoils.Select();
        //        }
        //    }
        //}

        //private void Coils_Refresh()
        //{
        //    ListView lstcoils = this.lstCoils;
        //    if (lstcoils.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstcoils.SelectedItems[0];
        //        int index = selectedIndex.Index;

        //        //Обновляем информацию
        //        SetConfig();
        //        //Прокручиваем
        //        lstCoils.EnsureVisible(index);
        //        lstCoils.TopItem = lstCoils.Items[index];
        //        //Делаем область активной
        //        lstCoils.Focus();
        //        //Делаю нужный элемент выбранным
        //        lstCoils.Items[index].Selected = true;
        //        lstCoils.Select();
        //    }
        //}

        //private void DiscreteInputs_Change()
        //{
        //    ListView lstdiscreteinputs = this.lstDiscreteInputs;
        //    if (lstdiscreteinputs.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstdiscreteinputs.SelectedItems[0];

        //        int index = selectedIndex.Index;
        //        ushort index_RegAddr = (ushort)(register_start * 1000 + index);
        //        uint RegAddr_Value = Convert.ToUInt32(Convert.ToBoolean(selectedIndex.SubItems[1].Text));

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 0;
        //        InputBox.value = RegAddr_Value;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            //Записываем
        //            bool bool_Value = Convert.ToBoolean(InputBox.value);
        //            ModbusDevice.SetDiscreteInput(index_RegAddr, bool_Value);
        //            //Обновляем информацию
        //            SetConfig();
        //            //Прокручиваем
        //            lstDiscreteInputs.EnsureVisible(index);
        //            lstDiscreteInputs.TopItem = lstDiscreteInputs.Items[index];
        //            //Делаем область активной
        //            lstDiscreteInputs.Focus();
        //            //Делаю нужный элемент выбранным
        //            lstDiscreteInputs.Items[index].Selected = true;
        //            lstDiscreteInputs.Select();
        //        }
        //    }
        //}

        //private void DiscreteInputs_Refresh()
        //{
        //    ListView lstdiscreteinputs = this.lstDiscreteInputs;
        //    if (lstdiscreteinputs.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstdiscreteinputs.SelectedItems[0];
        //        int index = selectedIndex.Index;

        //        //Обновляем информацию
        //        SetConfig();
        //        //Прокручиваем
        //        lstDiscreteInputs.EnsureVisible(index);
        //        lstDiscreteInputs.TopItem = lstDiscreteInputs.Items[index];
        //        //Делаем область активной
        //        lstDiscreteInputs.Focus();
        //        //Делаю нужный элемент выбранным
        //        lstDiscreteInputs.Items[index].Selected = true;
        //        lstDiscreteInputs.Select();
        //    }
        //}

        //private void HoldingRegisters_Change()
        //{
        //    ListView lstholdingregisters = this.lstHoldingRegisters;
        //    if (lstholdingregisters.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstholdingregisters.SelectedItems[0];

        //        int index = selectedIndex.Index;
        //        ushort index_RegAddr = (ushort)(register_start * 1000 + index);
        //        uint RegAddr_Value = Convert.ToUInt32(selectedIndex.SubItems[3].Text);

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 1;
        //        InputBox.value = RegAddr_Value;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            //Записываем
        //            if (InputBox.value > 65535)
        //            {
        //                ModbusDevice.SetHoldingRegister_4(index_RegAddr, InputBox.value);
        //            }
        //            else if (InputBox.value <= 65535)
        //            {
        //                ModbusDevice.SetHoldingRegister(index_RegAddr, Convert.ToUInt16(InputBox.value));
        //                ModbusDevice.SetHoldingRegister_4(index_RegAddr, InputBox.value);
        //            }

        //            //Обновляем информацию
        //            SetConfig();
        //            //Прокручиваем
        //            lstHoldingRegisters.EnsureVisible(index);
        //            lstHoldingRegisters.TopItem = lstHoldingRegisters.Items[index];
        //            //Делаем область активной
        //            lstHoldingRegisters.Focus();
        //            //Делаю нужный элемент выбранным
        //            lstHoldingRegisters.Items[index].Selected = true;
        //            lstHoldingRegisters.Select();
        //        }
        //    }
        //}

        //private void HoldingRegisters_Refresh()
        //{
        //    ListView lstholdingregisters = this.lstHoldingRegisters;
        //    if (lstholdingregisters.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstholdingregisters.SelectedItems[0];
        //        int index = selectedIndex.Index;

        //        //Обновляем информацию
        //        SetConfig();
        //        //Прокручиваем
        //        lstHoldingRegisters.EnsureVisible(index);
        //        lstHoldingRegisters.TopItem = lstHoldingRegisters.Items[index];
        //        //Делаем область активной
        //        lstHoldingRegisters.Focus();
        //        //Делаю нужный элемент выбранным
        //        lstHoldingRegisters.Items[index].Selected = true;
        //        lstHoldingRegisters.Select();
        //    }
        //}

        //private void InputRegisters_Change()
        //{
        //    ListView lstinputregisters = this.lstInputRegisters;
        //    if (lstinputregisters.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstinputregisters.SelectedItems[0];

        //        int index = selectedIndex.Index;
        //        ushort index_RegAddr = (ushort)(register_start * 1000 + index);
        //        uint RegAddr_Value = Convert.ToUInt32(selectedIndex.SubItems[3].Text);

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 1;
        //        InputBox.value = RegAddr_Value;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            //Записываем
        //            if (InputBox.value > 65535)
        //            {
        //                ModbusDevice.SetInputRegister_4(index_RegAddr, InputBox.value);
        //            }
        //            else if (InputBox.value <= 65535)
        //            {
        //                ModbusDevice.SetInputRegister(index_RegAddr, Convert.ToUInt16(InputBox.value));
        //                ModbusDevice.SetInputRegister_4(index_RegAddr, InputBox.value);
        //            }
        //            //Обновляем информацию
        //            SetConfig();
        //            //Прокручиваем
        //            lstInputRegisters.EnsureVisible(index);
        //            lstInputRegisters.TopItem = lstInputRegisters.Items[index];
        //            //Делаем область активной
        //            lstInputRegisters.Focus();
        //            //Делаю нужный элемент выбранным
        //            lstInputRegisters.Items[index].Selected = true;
        //            lstInputRegisters.Select();
        //        }
        //    }
        //}

        //private void InputRegisters_Refresh()
        //{
        //    ListView lstinputregisters = this.lstInputRegisters;
        //    if (lstinputregisters.SelectedItems.Count <= 0)
        //    {
        //        return;
        //    }

        //    if (DeviceID != null)
        //    {
        //        ListViewItem selectedIndex = lstinputregisters.SelectedItems[0];
        //        int index = selectedIndex.Index;

        //        //Обновляем информацию
        //        SetConfig();
        //        //Прокручиваем
        //        lstInputRegisters.EnsureVisible(index);
        //        lstInputRegisters.TopItem = lstInputRegisters.Items[index];
        //        //Делаем область активной
        //        lstInputRegisters.Focus();
        //        //Делаю нужный элемент выбранным
        //        lstInputRegisters.Items[index].Selected = true;
        //        lstInputRegisters.Select();
        //    }
        //}

        //private void lstCoils_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Coils_Change();
        //}

        //private void lstDiscreteInputs_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    DiscreteInputs_Change();
        //}

        //private void lstHoldingRegisters_DoubleClick(object sender, EventArgs e)
        //{
        //    HoldingRegisters_Change();
        //}

        //private void lstInputRegisters_DoubleClick(object sender, EventArgs e)
        //{
        //    InputRegisters_Change();
        //}

        //#endregion Изменение буфера

        //#region Меню изменения буфера
        //private void tolRegisterChange_Click(object sender, EventArgs e)
        //{
        //    string tabname = tabDeviceBuffer.SelectedTab.Text;
        //    if (tabname == "Coils")
        //    {
        //        Coils_Change();
        //    }
        //    else if (tabname == "Discrete Inputs")
        //    {
        //        DiscreteInputs_Change();
        //    }
        //    else if (tabname == "Holding Registers")
        //    {
        //        HoldingRegisters_Change();
        //    }
        //    else if (tabname == "Input Registers")
        //    {
        //        InputRegisters_Change();
        //    }
        //}

        //private void tolRegisterRefresh_Click(object sender, EventArgs e)
        //{
        //    string tabname = tabDeviceBuffer.SelectedTab.Text;
        //    if (tabname == "Coils")
        //    {
        //        Coils_Refresh();
        //    }
        //    else if (tabname == "Discrete Inputs")
        //    {
        //        DiscreteInputs_Refresh();
        //    }
        //    else if (tabname == "Holding Registers")
        //    {
        //        HoldingRegisters_Refresh();
        //    }
        //    else if (tabname == "Input Registers")
        //    {
        //        InputRegisters_Refresh();
        //    }
        //}

        //#endregion Меню изменения буфера

        //#region Поиск по буферу значений

        //static IEnumerable<bool> GenerateListBool(List<bool> array, int index)
        //{
        //    yield return array[index];
        //}

        //static IEnumerable<ushort> GenerateListUshort(List<ushort> array, int index)
        //{
        //    yield return array[index];
        //}

        //private void btnSearchValue_Click(object sender, EventArgs e)
        //{
        //    if (cmbTypeData.Text == "Coils")
        //    {
        //        //Делаем активной вкладкой
        //        tabDeviceBuffer.SelectedTab = tabCoils;

        //        int index = 0;
        //        List<bool> array = new List<bool>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataCoils[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListBool(array, index))
        //            {
        //                var item = lstCoils.Items[i];
        //                if (item.SubItems[1].Text.ToLower().Contains("True".ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstCoils.EnsureVisible(i);
        //                    lstCoils.TopItem = lstCoils.Items[i];
        //                    //Делаем область активной
        //                    lstCoils.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstCoils.Items[i].Selected = true;
        //                    lstCoils.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[1].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }
        //    else if (cmbTypeData.Text == "Discrete Inputs")
        //    {
        //        tabDeviceBuffer.SelectedTab = tabDiscreteInputs;

        //        int index = 0;
        //        List<bool> array = new List<bool>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataDiscreteInputs[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListBool(array, index))
        //            {
        //                var item = lstDiscreteInputs.Items[i];
        //                if (item.SubItems[1].Text.ToLower().Contains("True".ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstDiscreteInputs.EnsureVisible(i);
        //                    lstDiscreteInputs.TopItem = lstDiscreteInputs.Items[i];
        //                    //Делаем область активной
        //                    lstDiscreteInputs.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstDiscreteInputs.Items[i].Selected = true;
        //                    lstDiscreteInputs.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[1].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }
        //    else if (cmbTypeData.Text == "Holding Registers")
        //    {
        //        tabDeviceBuffer.SelectedTab = tabHoldingRegisters;

        //        string search_holdingregisters_value = string.Empty;

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 1;
        //        InputBox.value = 0;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            uint tmp_uint = InputBox.value;
        //            search_holdingregisters_value = tmp_uint.ToString();
        //        }

        //        int index = 0;
        //        List<ushort> array = new List<ushort>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataHoldingRegisters[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListUshort(array, index))
        //            {
        //                var item = lstHoldingRegisters.Items[i];
        //                if (item.SubItems[3].Text.ToLower().Equals(search_holdingregisters_value.ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstHoldingRegisters.EnsureVisible(i);
        //                    lstHoldingRegisters.TopItem = lstHoldingRegisters.Items[i];
        //                    //Делаем область активной
        //                    lstHoldingRegisters.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstHoldingRegisters.Items[i].Selected = true;
        //                    lstHoldingRegisters.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[3].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }
        //    else if (cmbTypeData.Text == "Input Registers")
        //    {
        //        tabDeviceBuffer.SelectedTab = tabInputRegisters;

        //        string search_inputregisters_value = string.Empty;

        //        frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //        InputBox.mode = 1;
        //        InputBox.value = 0;
        //        InputBox.FormParent = this;
        //        InputBox.ShowDialog();

        //        if (InputBox.DialogResult == DialogResult.OK)
        //        {
        //            uint tmp_uint = InputBox.value;
        //            search_inputregisters_value = tmp_uint.ToString();
        //        }

        //        int index = 0;
        //        List<ushort> array = new List<ushort>();

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            array.Add(DataInputRegisters[i]);
        //        }

        //        for (int i = register_start; i < 1000; i++)
        //        {
        //            foreach (var elem in GenerateListUshort(array, index))
        //            {
        //                var item = lstInputRegisters.Items[i];
        //                if (item.SubItems[3].Text.ToLower().Equals(search_inputregisters_value.ToLower()))
        //                {
        //                    //Прокручиваем
        //                    lstInputRegisters.EnsureVisible(i);
        //                    lstInputRegisters.TopItem = lstInputRegisters.Items[i];
        //                    //Делаем область активной
        //                    lstInputRegisters.Focus();
        //                    //Делаю нужный элемент выбранным
        //                    lstInputRegisters.Items[i].Selected = true;
        //                    lstInputRegisters.Select();

        //                    DialogResult result = MessageBox.Show("Нашли на адресе " + item.SubItems[0].Text + " значение " + item.SubItems[3].Text + ". Ищем дальше?", "Поиск", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //                    if (result == DialogResult.Yes)
        //                    {

        //                    }
        //                    else if (result == DialogResult.No)
        //                    {
        //                        goto END;
        //                    }
        //                }

        //                if (array.Count - 1 == index)
        //                {
        //                    index = 0;
        //                    MessageBox.Show("Ничего не найдено!");
        //                }

        //                index++;
        //            }
        //        }
        //    }

        //END: try { } catch { }

        //}

        //#endregion Поиск по буферу значений

        //#region CSV
        ////Загрузка данных из CSV
        //private void tolDataLoadAsCSV_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Вы действительно хотите загрузить\r\nданные из файла?", "Вопрос", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //    {
        //        DataLoadAsCSV();
        //    }
        //}

        //private void DataLoadAsCSV()
        //{
        //    OpenFileDialog OFD = new OpenFileDialog();
        //    OFD.Title = "Загрузить данные...";
        //    OFD.Filter = "CSV (*.csv)|*.csv|Все файлы (*.*)|*.*";
        //    OFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

        //    if (OFD.ShowDialog() == DialogResult.OK && OFD.FileName != "")
        //    {
        //        try
        //        {
        //            //Открываем
        //            string FileName = OFD.FileName;
        //            MODBUS_DEVICE_BUFFER buffer = new MODBUS_DEVICE_BUFFER();

        //            #region Загрузка
        //            Thread splashthread = new Thread(new ThreadStart(SplashScreen.ShowSplashScreen));
        //            splashthread.IsBackground = true;
        //            splashthread.Start();

        //            Application.DoEvents();
        //            SplashScreen.UdpateStatusText(1, "Загрузка...");
        //            SplashScreen.UdpateStatusText(2, "Считывание данных из файла:");
        //            SplashScreen.UdpateStatusText(3, "");
        //            Application.DoEvents();

        //            DataTable data = CSV.Import(FileName, true, ";", "UTF8");

        //            for (int i = 0; i < data.Rows.Count; i++)
        //            {
        //                DataRow tmp_DataRow = data.Rows[i];

        //                string RegisterType = tmp_DataRow.ItemArray[1].ToString();

        //                if (RegisterType == "CoilRegister")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        bool Value = (bool)Convert.ToBoolean(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetCoil(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "DiscreteInput")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        bool Value = (bool)Convert.ToBoolean(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetDiscreteInput(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "HoldingRegister")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        ushort Value = Convert.ToUInt16(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetHoldingRegister(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "InputRegister")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        ushort Value = Convert.ToUInt16(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetInputRegister(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "HoldingRegister4")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        uint Value = Convert.ToUInt32(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetHoldingRegister_4(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }

        //                if (RegisterType == "InputRegister4")
        //                {
        //                    try
        //                    {
        //                        ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(tmp_DataRow.ItemArray[0].ToString()));
        //                        uint Value = Convert.ToUInt32(tmp_DataRow.ItemArray[2].ToString());
        //                        ModbusDevice.SetInputRegister_4(RegAdres, Value);
        //                    }
        //                    catch
        //                    {

        //                    }
        //                }
        //            }

        //            Application.DoEvents();
        //            SplashScreen.CloseSplashScreen();
        //            this.Show();
        //            this.Activate();
        //            #endregion Загрузка

        //            SetConfig();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Не удалось загрузить данные по причине:\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            goto END_VOID;
        //        }
        //    END_VOID:
        //        try { } catch { }
        //    }
        //}

        ////Сохранить данные как CSV
        //private void tolDataSaveAsCSV_Click(object sender, EventArgs e)
        //{
        //    DataSaveAsCSV();
        //}

        //private void DataSaveAsCSV()
        //{
        //    SaveFileDialog SFD = new SaveFileDialog();
        //    SFD.Title = "Выгрузить данные...";
        //    SFD.Filter = "CSV (*.csv)|*.csv|Все файлы (*.*)|*.*";
        //    SFD.InitialDirectory = System.IO.Path.Combine(Application.StartupPath);

        //    if (SFD.ShowDialog() == DialogResult.OK && SFD.FileName != "")
        //    {
        //        //Сохраняем
        //        string FileName = SFD.FileName;

        //        MODBUS_DEVICE_BUFFER buffer = new MODBUS_DEVICE_BUFFER();
        //        DataTable data = buffer.ConvertRegistersToDataTable(ModbusDevice);

        //        CSV.Export(FileName, data, true, ";", "UTF8");
        //    }
        //}

        //#endregion CSV

        //#region Таймер
        ////Таймер
        //DateTime tmr_EndTime = new DateTime();
        //private bool tmr_Status = false;
        //private string CountDownTimerString = string.Empty;
        //private double TimeRefresh = 3000d;

        //private void lblTimerInfo_Click(object sender, EventArgs e)
        //{
        //    frm_RegisterInputValue InputBox = new frm_RegisterInputValue();
        //    InputBox.mode = 1;
        //    InputBox.value = Convert.ToUInt16(TimeRefresh);
        //    InputBox.ShowDialog();

        //    if (InputBox.DialogResult == DialogResult.OK)
        //    {
        //        //Записываем
        //        TimeRefresh = Convert.ToDouble(InputBox.value);
        //    }
        //}

        ////Включаем и выключаем таймер
        //private void ckbAutoRefreshListRegisters_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ckbAutoRefreshListRegisters.Checked == true)
        //    {
        //        tmr_EndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
        //        tmr_Timer.Enabled = true;
        //        tmr_Status = true;
        //    }
        //    else if (ckbAutoRefreshListRegisters.Checked == false)
        //    {
        //        tmr_Timer.Enabled = false;
        //        tmr_Status = false;
        //    }
        //}

        //private void tmr_Timer_Tick(object sender, EventArgs e)
        //{
        //    TimeSpan leftTime = tmr_EndTime.Subtract(DateTime.Now);
        //    if (leftTime.TotalSeconds < 0)
        //    {
        //        CountDownTimerString = "00:00:00";
        //        lblTimerInfo.Text = CountDownTimerString;
        //        Refresh();
        //        tmr_Timer.Stop();
        //        //Обновляем информацию
        //        tmr_Timer_InfoDevice();

        //        if (tmr_Status == true)
        //        {
        //            tmr_EndTime = DateTime.Now.AddMilliseconds(TimeRefresh);
        //            tmr_Timer.Enabled = true;
        //        }
        //    }
        //    else
        //    {
        //        CountDownTimerString = leftTime.Hours.ToString("00") + ":" + leftTime.Minutes.ToString("00") + ":" + leftTime.Seconds.ToString("00") + "." + leftTime.Milliseconds.ToString("000");
        //        lblTimerInfo.Text = CountDownTimerString;
        //        Refresh();
        //    }
        //}

        //void tmr_Timer_InfoDevice()
        //{
        //    //Очищаем таблицу
        //    try
        //    {
        //        //register_start = Convert.ToUInt16(numRegisterStart.Value);
        //        //register_count = (ushort)(Convert.ToUInt16(numRegisterStop.Value) - Convert.ToInt16(numRegisterStart.Value));

        //        //Находим устройство
        //        MODBUS_DEVICE tmp_Device = CHANNEL.ModbusDevices.Find((Predicate<MODBUS_DEVICE>)(r => r.DeviceID.ToString() == DeviceID.ToString()));
        //        if (tmp_Device != null)
        //        {
        //            ModbusDevice.DataCoils = tmp_Device.DataCoils;
        //            ModbusDevice.DataDiscreteInputs = tmp_Device.DataDiscreteInputs;
        //            ModbusDevice.DataHoldingRegisters = tmp_Device.DataHoldingRegisters;
        //            ModbusDevice.DataInputRegisters = tmp_Device.DataInputRegisters;

        //            //Coils
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstcoils = this.lstCoils;

        //                    //Обновление без мерцания
        //                    Type type = lstCoils.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstCoils, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstcoils.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.CoilsExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            RegisterItem.Text = (register_start * 1000 + index + 100000).ToString();
        //                            RegisterItem.Tag = RegisterItem.Tag;
        //                            RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 100000).ToString());
        //                            RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(ModbusDevice.GetBooleanCoil(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }

        //            //DiscreteInputs
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstdiscreteinputs = this.lstDiscreteInputs;

        //                    //Обновление без мерцания
        //                    Type type = lstDiscreteInputs.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstDiscreteInputs, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstdiscreteinputs.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.CoilsExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            RegisterItem.Text = (register_start * 1000 + index + 200000).ToString();
        //                            RegisterItem.Tag = RegisterItem.Tag;
        //                            RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 200000).ToString());
        //                            RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(ModbusDevice.GetBooleanDiscreteInput(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }

        //            //HoldingRegisters
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstholdingregisters = this.lstHoldingRegisters;

        //                    //Обновление без мерцания
        //                    Type type = lstHoldingRegisters.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstHoldingRegisters, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstholdingregisters.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.HoldingRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            if (ModbusDevice.DeviceRegistersBytes == 0)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 300000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 300000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(16, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString("x4").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetIntHoldingRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                            else if (ModbusDevice.DeviceRegistersBytes == 1)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 300000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 300000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString("x8").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntHoldingRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }

        //            //InputRegisters
        //            if (tmp_Device != null)
        //            {
        //                try
        //                {
        //                    ListView lstinputregisters = this.lstInputRegisters;

        //                    //Обновление без мерцания
        //                    Type type = lstInputRegisters.GetType();
        //                    PropertyInfo propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance);
        //                    propertyInfo.SetValue(lstInputRegisters, true, null);

        //                    //ushort tmp_register_start = register_start;
        //                    for (int index = 0; index < 1000; ++index)
        //                    {
        //                        Application.DoEvents();
        //                        ListViewItem RegisterItem = lstinputregisters.Items[index];

        //                        //Обновили инфорамцию
        //                        if (ModbusDevice.InputRegistersExists(Convert.ToUInt16(register_start * 1000 + index)))
        //                        {
        //                            if (ModbusDevice.DeviceRegistersBytes == 0)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 400000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 400000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(16, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString("x4").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetIntInputRegister(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                            else if (ModbusDevice.DeviceRegistersBytes == 1)
        //                            {
        //                                RegisterItem.Text = (register_start * 1000 + index + 400000).ToString();
        //                                RegisterItem.Tag = RegisterItem.Tag;
        //                                RegisterItem.SubItems[0].Text = NULLSTRING.NullToString((register_start * 1000 + index + 400000).ToString());
        //                                RegisterItem.SubItems[1].Text = NULLSTRING.NullToString(Convert.ToString((int)ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)), 2).PadLeft(32, '0').ToUpper());
        //                                RegisterItem.SubItems[2].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString("x8").ToUpper());
        //                                RegisterItem.SubItems[3].Text = NULLSTRING.NullToString(ModbusDevice.GetUIntInputRegister_4(Convert.ToUInt16(register_start * 1000 + index)).ToString());
        //                            }
        //                        }
        //                        Application.DoEvents();
        //                    }
        //                }
        //                catch (Exception ex) { Debuger.LogException(ex.ToString()); }
        //            }
        //        }
        //    }
        //    catch
        //    { }
        //}

        //#endregion Таймер

        //#region Обнуление регистров
        //private void tolRegistersResetToZero_Click(object sender, EventArgs e)
        //{
        //    RegistersResetToZero();
        //}

        //private void RegistersResetToZero()
        //{
        //    for (int index = 0; index <= 65535; ++index)
        //    {
        //        ModbusDevice.SetCoil(Convert.ToUInt16(index), false);
        //        ModbusDevice.SetDiscreteInput(Convert.ToUInt16(index), false);
        //        ModbusDevice.SetHoldingRegister(Convert.ToUInt16(index), (ushort)0);
        //        ModbusDevice.SetInputRegister(Convert.ToUInt16(index), (ushort)0);
        //        ModbusDevice.SetHoldingRegister_4(Convert.ToUInt16(index), (uint)0);
        //        ModbusDevice.SetInputRegister_4(Convert.ToUInt16(index), (uint)0);
        //    }

        //    GetConfig();
        //    SetConfig();
        //}
        //#endregion Обнуление регистров
    }
}
