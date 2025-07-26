using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    #region ProjectDevice
    [Serializable]
    public class ProjectDevice
    {
        public ProjectDevice()
        {
            ID = new Guid();
            ParentID = new Guid();
            KeyImage = string.Empty;
            BufferKeyImage = string.Empty;

            Name = string.Empty;
            Description = string.Empty;

            Address = 0;
            Protocol = DriverProtocol.None;

            Enabled = true;
            PollingOnScheduleStatus = false;
            IntervalPool = 100;
            Status = 0;

            DateTimeCommandLast = DateTime.MinValue;
            DateTimeCommandLastGood = DateTime.MinValue;
            DateTimeLastSuccessfully = DateTime.MinValue;

            CountCommandsSend = 0;
            CountCommandsAnswerGood = 0;
            PriorityCommand = 0;

            GatewayAddress = 0;
            GatewayPort = 60000;

            DeviceRegistersBytes = 2;
            DeviceGatewayRegistersBytes = 2;

            try
            {
                // adding Registers 65535
                for (ulong index = 0; index < (ulong)65535; ++index)
                {
                    bool status = false;
                    ulong value = 0;
                    string s = string.Empty;

                    SetCoil(Convert.ToUInt64(index), status);
                    SetDiscreteInput(Convert.ToUInt64(index), status);
                    SetHoldingRegister(Convert.ToUInt64(index), value);
                    SetInputRegister(Convert.ToUInt64(index), value);
                    SetDataBuffer(Convert.ToUInt64(index), s);
                }
            }
            catch { }

            GroupCommand = new ProjectGroupCommand();
            GroupTag = new ProjectGroupTag();
        }

        #region Variables

        #region Device
        // id 
        private Guid id;
        [XmlAttribute]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        // id родителя
        private Guid parentID;
        [XmlAttribute]
        public Guid ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        // иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        // иконка буфера
        private string bufferKeyImage;
        [XmlAttribute]
        public string BufferKeyImage
        {
            get { return bufferKeyImage; }
            set { bufferKeyImage = value; }
        }

        // адрес устройства       
        private ushort address;
        [XmlAttribute]
        public ushort Address
        {
            get { return address; }
            set { address = value; }
        }

        // протокол
        private DriverProtocol protocol;
        [XmlAttribute]
        public DriverProtocol Protocol
        {
            get { return protocol; }
            set { protocol = value; }
        }

        // название устройства
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // описание устройства
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // состояние устройства (включено ли устройство и производить ли его опрос)
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        // признак опроса по расписанию
        private bool pollingOnScheduleStatus;
        [XmlAttribute]
        public bool PollingOnScheduleStatus
        {
            get { return pollingOnScheduleStatus; }
            set { pollingOnScheduleStatus = value; }
        }

        // дата последнего успешного опроса устройства    
        private DateTime dateTimeLastSuccessfully;
        [XmlAttribute]
        public DateTime DateTimeLastSuccessfully
        {
            get { return dateTimeLastSuccessfully; }
            set { dateTimeLastSuccessfully = value; }
        }

        // период опроса устройства                                    
        private int intervalPool;
        [XmlAttribute]
        public int IntervalPool
        {
            get { return intervalPool; }
            set { intervalPool = value; }
        }

        // статус устройства
        private int status;
        [XmlAttribute]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion Device

        #region Commands
        // количество всего отправленных комманд
        private int countCommandsSend;
        [XmlAttribute]
        public int CountCommandsSend
        {
            get { return countCommandsSend; }
            set { countCommandsSend = value; }
        }

        // количество комманд с успешным ответом
        private int countCommandsAnswerGood;
        [XmlAttribute]
        public int CountCommandsAnswerGood
        {
            get { return countCommandsAnswerGood; }
            set { countCommandsAnswerGood = value; }
        }

        // дата последней команды
        private DateTime dateTimeCommandLast;
        [XmlAttribute]
        public DateTime DateTimeCommandLast
        {
            get { return dateTimeCommandLast; }
            set { dateTimeCommandLast = value; }
        }

        // дата последней успешной команды
        private DateTime dateTimeCommandLastGood;
        [XmlAttribute]
        public DateTime DateTimeCommandLastGood
        {
            get { return dateTimeCommandLastGood; }
            set { dateTimeCommandLastGood = value; }
        }

        // приоритет комманд
        private int priorityCommand;
        [XmlAttribute]
        public int PriorityCommand
        {
            get { return priorityCommand; }
            set { priorityCommand = value; }
        }
        #endregion Commands

        #region Gateway                                  
        // адрес устройства в шлюзе
        private int gatewayAddress;
        [XmlAttribute]
        public int GatewayAddress
        {
            get { return gatewayAddress; }
            set { gatewayAddress = value; }
        }

        // порт устройства в шлюзе
        private int gatewayPort;
        [XmlAttribute]
        public int GatewayPort
        {
            get { return gatewayPort; }
            set { gatewayPort = value; }
        }

        #endregion Gateway        

        #region Group Command
        private ProjectGroupCommand groupCommand;
        public ProjectGroupCommand GroupCommand
        {
            get { return groupCommand; }
            set { groupCommand = value; }
        }
        #endregion Group Command

        #region Group Tags
        private ProjectGroupTag groupTag;
        public ProjectGroupTag GroupTag
        {
            get { return groupTag; }
            set { groupTag = value; }
        }
        #endregion Group Tags

        #region Registers
        // сохранять регистры или нет
        private bool saveRegisters;
        public bool SaveRegisters
        {
            get { return saveRegisters; }
            set { saveRegisters = value; }
        }

        // регистры                                 
        private int deviceRegistersBytes;
        [XmlAttribute]
        public int DeviceRegistersBytes
        {
            get { return deviceRegistersBytes; }
            set { deviceRegistersBytes = value; }
        }

        private int deviceGatewayRegistersBytes;
        [XmlAttribute]
        public int DeviceGatewayRegistersBytes
        {
            get { return deviceGatewayRegistersBytes; }
            set { deviceGatewayRegistersBytes = value; }
        }

        [XmlIgnore]
        public bool[] DataCoils = new bool[65535];                              //Coils устройства           (Функция 1)
        [XmlIgnore]
        public bool[] DataDiscreteInputs = new bool[65535];                     //DiscreteInputs устройства  (Функция 2)
        [XmlIgnore]
        public ulong[] DataHoldingRegisters = new ulong[65535];                 //HoldingRegister устройства (Функция 3) 
        [XmlIgnore]
        public ulong[] DataInputRegisters = new ulong[65535];                   //InputRegister устройства   (Функция 4) 
        [XmlIgnore]
        public string[] DataBuffers = new string[65535];                        //Буфер устройства           (Фунция с 80 по 99)


        [XmlIgnore]
        public bool[] ExistCoils = new bool[65535];                             //Coils устройства           (Функция 1)
        [XmlIgnore]
        public bool[] ExistDiscreteInputs = new bool[65535];                    //DiscreteInputs устройства  (Функция 2)
        [XmlIgnore]
        public bool[] ExistHoldingRegisters = new bool[65535];                  //HoldingRegister устройства (Функция 3)
        [XmlIgnore]
        public bool[] ExistInputRegisters = new bool[65535];                    //InputRegister устройства   (Функция 4)
        [XmlIgnore]
        public bool[] ExistDataBuffers = new bool[65535];                       //Буфер устройства           (Фунция с 80 по 99)


        #region Coils
        public bool[] DeviceIDDataCoil()
        {
            return DataCoils;
        }

        public void SetCoil(ulong RegAddr, bool Value)
        {
            ExistCoils[(ulong)RegAddr] = true;
            DataCoils[(ulong)RegAddr] = Value;
        }

        public bool CoilsExists(ulong RegAddr)
        {
            return ExistCoils[(ulong)RegAddr];
        }

        public bool CoilsExists(ulong RegAddr, ulong Count)
        {
            for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
            {
                if (!ExistCoils[index])
                {
                    return false;
                }
            }
            return true;
        }

        public bool GetBooleanCoil(ulong RegAddr)
        {
            return DataCoils[(ulong)RegAddr];
        }

        #endregion Coils

        #region DiscreteInputs

        public bool[] DeviceIDDataDiscreteInput()
        {
            return DataDiscreteInputs;
        }

        public void SetDiscreteInput(ulong RegAddr, bool Value)
        {
            ExistDiscreteInputs[(ulong)RegAddr] = true;
            DataDiscreteInputs[(ulong)RegAddr] = Value;
        }

        public bool DiscreteInputsExists(ulong RegAddr)
        {
            return ExistDiscreteInputs[(ulong)RegAddr];
        }

        public bool DiscreteInputsExists(ulong RegAddr, ulong Count)
        {
            for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
            {
                if (!ExistDiscreteInputs[index])
                {
                    return false;
                }
            }
            return true;
        }

        public bool GetBooleanDiscreteInput(ulong RegAddr)
        {
            return DataDiscreteInputs[(ulong)RegAddr];
        }

        #endregion DiscreteInputs

        #region HoldingRegisters

        public ulong[] DeviceIDDataHoldingRegisters()
        {
            return DataHoldingRegisters;
        }

        public bool HoldingRegistersExists(ulong RegAddr)
        {
            return this.ExistHoldingRegisters[(int)RegAddr];
        }

        public bool HoldingRegistersExists(ulong RegAddr, ulong Count)
        {
            for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
            {
                if (!this.ExistHoldingRegisters[index])
                {
                    return false;
                }
            }
            return true;
        }

        public void SetHoldingRegister(byte[] ArrData, ulong RegAddr, ulong RegisterBytes)
        {
            ulong value = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(ArrData);
            SetHoldingRegister(RegAddr, value);
        }

        public void SetHoldingRegister(ulong RegAddr, ulong Value)
        {
            this.ExistHoldingRegisters[(ulong)RegAddr] = true;
            this.DataHoldingRegisters[(ulong)RegAddr] = Value;
        }

        public void SetHoldingRegister(ulong RegAddr, int Bit, bool Value)
        {
            try
            {
                this.ExistHoldingRegisters[(ulong)RegAddr] = true;
                if (Value)
                {
                    this.DataHoldingRegisters[(ulong)RegAddr] = Convert.ToUInt64(DataHoldingRegisters[RegAddr] | ((ulong)1 << Bit));
                }
                else
                {
                    this.DataHoldingRegisters[(ulong)RegAddr] = Convert.ToUInt64(DataHoldingRegisters[RegAddr] & (ulong)~Convert.ToUInt64(1 << Bit));
                }

            }
            catch { }
        }

        public void FillHoldingRegister(ulong RegAddr, ulong Value, ulong Count)
        {
            try
            {
                for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
                {
                    this.SetHoldingRegister(Convert.ToUInt64(index), Value);
                }
            }
            catch { }
        }

        public ushort GetUshortHoldingRegister(ulong RegAddr)
        {
            ushort value = Convert.ToUInt16(this.DataHoldingRegisters[(int)RegAddr]);
            return value;
        }

        public uint GetUintHoldingRegister(ulong RegAddr)
        {
            uint value = Convert.ToUInt32(this.DataHoldingRegisters[(int)RegAddr]);
            return value;
        }

        public ulong GetUlongHoldingRegister(ulong RegAddr)
        {
            return this.DataHoldingRegisters[(int)RegAddr];
        }

        public byte[] GetUlongHoldingRegister(ulong RegAddr, ulong Count)
        {
            byte[] bytes = (byte[])null;
            ulong value = 0;
            for (int index = (int)RegAddr; index < (int)RegAddr + (int)Count; ++index)
            {
                value = this.DataHoldingRegisters[(int)RegAddr];
                byte[] curBytes = HEX_ULONG.HEXARRAYULONG_TO_HEXARRAY(value);
                bytes = HEX_OPERATION.BYTEARRAY_COMBINE(bytes, curBytes);
            }

            return bytes;
        }

        public bool GetBoolHoldingRegister(ulong RegAddr, int Bit)
        {
            return Convert.ToBoolean((ulong)this.DataHoldingRegisters[(ulong)RegAddr] & (ulong)1 << Bit);
        }

        #endregion HoldingRegisters

        #region InputRegisters

        public ulong[] DeviceIDDataInputRegister()
        {
            return DataInputRegisters;
        }

        public bool InputRegistersExists(ulong RegAddr, ulong Count)
        {
            for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
            {
                if (!this.ExistHoldingRegisters[index])
                {
                    return false;
                }
            }
            return true;
        }

        public bool InputRegistersExists(ulong RegAddr)
        {
            return this.ExistInputRegisters[(ulong)RegAddr];
        }

        public void SetInputRegister(ulong RegAddr, ulong Value)
        {
            this.ExistInputRegisters[(ulong)RegAddr] = true;
            this.DataInputRegisters[(ulong)RegAddr] = Value;
        }

        public void SetInputRegister(byte[] ArrData, ulong RegAddr, ulong RegisterBytes)
        {
            ulong value = HEX_ULONG.HEXARRAY_TO_HEXARRAYULONG(ArrData);
            SetInputRegister(RegAddr, value);
        }

        public void SetInputRegister(ulong RegAddr, int Bit, bool Value)
        {
            try
            {
                this.ExistInputRegisters[(ulong)RegAddr] = true;
                if (Value)
                {
                    this.DataInputRegisters[(ulong)RegAddr] = Convert.ToUInt64((ulong)this.DataInputRegisters[(ulong)RegAddr] | (ulong)1 << Bit);
                }

                else
                {
                    this.DataInputRegisters[(ulong)RegAddr] = Convert.ToUInt64((int)this.DataInputRegisters[(int)RegAddr] & (int)~Convert.ToUInt64(1 << Bit));
                }
            }
            catch { }
        }

        public void FillInputRegister(ulong RegAddr, ulong Value, ulong Count)
        {
            try
            {
                for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
                {
                    this.SetInputRegister(Convert.ToUInt64(index), Value);
                }
            }
            catch { }
        }

        public ushort GetUshortInputRegister(ulong RegAddr)
        {
            ushort value = Convert.ToUInt16(this.DataInputRegisters[(int)RegAddr]);
            return value;
        }

        public uint GetUintInputRegister(ulong RegAddr)
        {
            uint value = Convert.ToUInt32(this.DataInputRegisters[(int)RegAddr]);
            return value;
        }

        public ulong GetUlongInputRegister(ulong RegAddr)
        {
            return this.DataInputRegisters[(int)RegAddr];
        }

        public byte[] GetUlongInputRegister(ulong RegAddr, ulong Count)
        {
            byte[] bytes = (byte[])null;
            ulong value = 0;
            for (int index = (int)RegAddr; index < (int)RegAddr + (int)Count; ++index)
            {
                value = this.DataInputRegisters[(int)RegAddr];
                byte[] curBytes = HEX_ULONG.HEXARRAYULONG_TO_HEXARRAY(value);
                bytes = HEX_OPERATION.BYTEARRAY_COMBINE(bytes, curBytes);
            }

            return bytes;
        }


        public bool GetBoolInputRegister(ulong RegAddr, int Bit)
        {
            return Convert.ToBoolean((ulong)this.DataInputRegisters[(ulong)RegAddr] & (ulong)1 << Bit);
        }

        #endregion InputRegisters

        #region DataBuffers

        public string[] DeviceIDDataDataBuffer()
        {
            return DataBuffers;
        }

        public void SetDataBuffer(string ArrData, ulong RegAddr, ulong RegisterBytes)
        {
            string[] arrData = ArrData.Split('.');
            arrData = arrData.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            ulong n = 0;
            for (ulong i = n; i < (ulong)arrData.Length / (ulong)RegisterBytes; ++i)
            {
                ulong Address = RegAddr + i;
                string Value = string.Empty;

                for (ulong j = 0; j < (ulong)RegisterBytes; ++j)
                {
                    n = i * (ulong)RegisterBytes + j;
                    Value = Value + arrData[n] + '.';
                }

                SetDataBuffer(Address, Value);
            }
        }

        public void SetDataBuffer(ulong RegAddr, string Value)
        {
            this.ExistDataBuffers[(ulong)RegAddr] = true;
            this.DataBuffers[(ulong)RegAddr] = Value;
        }

        public byte[] GetByteDataBuffer(ulong RegAddr, ulong Count)
        {
            byte[] bytes = (byte[])null;
            string value = string.Empty;
            for (int index = (int)RegAddr; index < (int)RegAddr + (int)Count; ++index)
            {
                value += DataBuffers[index];
            }
            bytes = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value);
            return bytes;
        }


        public bool DataBuffersExists(ulong RegAddr, ulong Count)
        {
            for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
            {
                if (!this.ExistHoldingRegisters[index])
                {
                    return false;
                }
            }
            return true;
        }

        public bool DataBuffersExists(ulong RegAddr)
        {
            return this.ExistDataBuffers[(ulong)RegAddr];
        }

        public ushort GetUshortDataBuffer(ulong RegAddr)
        {
            ushort value = Convert.ToUInt16(this.DataBuffers[(int)RegAddr]);
            return value;
        }

        public uint GetUintDataBuffer(ulong RegAddr)
        {
            uint value = Convert.ToUInt32(this.DataBuffers[(int)RegAddr]);
            return value;
        }

        public ulong GetUlongDataBuffer(ulong RegAddr)
        {
            ulong value = Convert.ToUInt64(this.DataBuffers[(int)RegAddr]);
            return value;
        }

        #endregion DataBuffers

        #endregion Registers

        #endregion Variables

        #region Load
        /// <summary>
        /// Loads the settings from the XML node.
        /// <para>Загружает настройки из узла XML.</para>
        /// </summary>
        public void LoadFromXml(XmlNode xmlNode)
        {
            if (xmlNode == null)
            {
                throw new ArgumentNullException("xmlNode");
            }

            ID = DriverUtils.StringToGuid(xmlNode.GetChildAsString("ID"));
            ParentID = DriverUtils.StringToGuid(xmlNode.GetChildAsString("ParentID"));

            KeyImage = xmlNode.GetChildAsString("KeyImage");
            BufferKeyImage = xmlNode.GetChildAsString("BufferKeyImage");

            Address = Convert.ToUInt16(xmlNode.GetChildAsInt("Address"));
            Protocol = (DriverProtocol)Enum.Parse(typeof(DriverProtocol), xmlNode.GetChildAsString("Protocol"));

            Name = xmlNode.GetChildAsString("Name");
            Description = xmlNode.GetChildAsString("Description");

            Enabled = xmlNode.GetChildAsBool("Enabled");
            PollingOnScheduleStatus = xmlNode.GetChildAsBool("PollingOnScheduleStatus");
            IntervalPool = xmlNode.GetChildAsInt("IntervalPool");
            Status = xmlNode.GetChildAsInt("Status");

            DeviceRegistersBytes = xmlNode.GetChildAsInt("DeviceRegistersBytes");
            DeviceGatewayRegistersBytes = xmlNode.GetChildAsInt("DeviceGatewayRegistersBytes");

            GatewayAddress = xmlNode.GetChildAsInt("GatewayAddress");
            GatewayPort = xmlNode.GetChildAsInt("GatewayPort");

            #region Load Registers
            if (SaveRegisters)
            {
                try
                {
                    //if (xmlNode.SelectSingleNode("ListCoilRegisters") is XmlNode listDevicesNode)
                    //{
                    //    Devices = new List<ProjectDevice>();
                    //    foreach (XmlNode deviceNode in listDevicesNode.SelectNodes("Device"))
                    //    {
                    //        ProjectDevice device = new ProjectDevice);
                    //        device.LoadFromXml(deviceNode);
                    //        Devices.Add(device);
                    //    }
                    //}

                    //// fill in the registers by the name of the attribute and its value from the dictionary of Attribute registers 65535
                    //foreach (string key in attributes.Keys)
                    //{
                    //    if (key.Contains("COILREGISTER"))
                    //    {
                    //        try
                    //        {
                    //            bool Coil = Convert.ToBoolean(attributes[key]);
                    //            ulong RegAddr = Convert.ToUInt64(key.Replace("COILREGISTER", ""));
                    //            projectDevice.SetCoil(RegAddr, Coil);
                    //        }
                    //        catch { }
                    //    }
                    //    else if (key.Contains("DISCRETEINPUT"))
                    //    {
                    //        try
                    //        {
                    //            bool DiscreteInput = Convert.ToBoolean(attributes[key]);
                    //            ulong RegAddr = Convert.ToUInt64(key.Replace("DISCRETEINPUT", ""));
                    //            projectDevice.SetDiscreteInput(RegAddr, DiscreteInput);
                    //        }
                    //        catch { }
                    //    }
                    //    else if (key.Contains("HOLDINGREGISTER"))
                    //    {
                    //        try
                    //        {
                    //            ulong HoldingRegister = Convert.ToUInt64(attributes[key]);
                    //            ulong RegAddr = Convert.ToUInt64(key.Replace("HOLDINGREGISTER", ""));
                    //            projectDevice.SetHoldingRegister(RegAddr, HoldingRegister);
                    //        }
                    //        catch { }
                    //    }
                    //    else if (key.Contains("INPUTREGISTER"))
                    //    {
                    //        try
                    //        {
                    //            ulong InputRegister = Convert.ToUInt16(Convert.ToInt64(attributes[key]));
                    //            ulong RegAddr = Convert.ToUInt64(key.Replace("INPUTREGISTER", ""));
                    //            projectDevice.SetInputRegister(RegAddr, InputRegister);
                    //        }
                    //        catch { }
                    //    }
                    //}

                }
                catch { }
            }
            #endregion Load Registers

            GroupCommand.LoadFromXml(xmlNode.SelectSingleNode("GroupCommand"));
            GroupTag.LoadFromXml(xmlNode.SelectSingleNode("GroupTag"));
        }
        #endregion Load

        #region Save
        /// <summary>
        /// Saves the settings into the XML node.
        /// <para>Сохраняет настройки в узле XML.</para>
        /// </summary>
        public void SaveToXml(XmlElement xmlElem)
        {
            if (xmlElem == null)
            {
                throw new ArgumentNullException("xmlElem");
            }

            xmlElem.AppendElem("ID", ID.ToString());
            xmlElem.AppendElem("ParentID", ParentID.ToString());

            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("BufferKeyImage", BufferKeyImage);

            xmlElem.AppendElem("Address", Address);
            xmlElem.AppendElem("Protocol", Enum.GetName(typeof(DriverProtocol), Protocol));

            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Description", Description);

            xmlElem.AppendElem("Enabled", Enabled);
            xmlElem.AppendElem("PollingOnScheduleStatus", PollingOnScheduleStatus);
            xmlElem.AppendElem("IntervalPool", IntervalPool);
            xmlElem.AppendElem("Status", Status);

            xmlElem.AppendElem("DeviceRegistersBytes", DeviceRegistersBytes);
            xmlElem.AppendElem("DeviceGatewayRegistersBytes", DeviceGatewayRegistersBytes);

            xmlElem.AppendElem("GatewayAddress", GatewayAddress);
            xmlElem.AppendElem("GatewayPort", GatewayPort);

            #region Save Registers
            if (SaveRegisters)
            {
                try
                {
                    XmlElement listRegistersCoilElem = xmlElem.AppendElem("ListRegistersCoil");
                    XmlElement listRegistersDiscreteInputElem = xmlElem.AppendElem("ListRegistersDiscreteInput");
                    XmlElement listRegistersHoldingElem = xmlElem.AppendElem("ListRegistersHolding");
                    XmlElement listRegistersInputElem = xmlElem.AppendElem("ListRegistersInput");
                    XmlElement listRegistersDataBufferElem = xmlElem.AppendElem("ListRegistersDataBuffer");

                    for (int i = 0; i < 65535; i++)
                    {
                        #region Coils
                        // coils
                        if (CoilsExists(Convert.ToUInt64(i)))
                        {
                            string TextCoilAddr = (i).ToString();
                            string TextCoilValue = GetBooleanCoil(Convert.ToUInt64(i)).ToString();

                            if (TextCoilValue != "False")
                            {
                                ProjectRegister registerCoil = new ProjectRegister();
                                registerCoil.RegAddr = TextCoilAddr;
                                registerCoil.RegValue = TextCoilValue;
                                listRegistersCoilElem.AppendElem("RegisterCoil", registerCoil);
                            }
                        }
                        #endregion Coils

                        #region DiscreteInput
                        // discreteInput
                        if (DiscreteInputsExists(Convert.ToUInt64(i)))
                        {
                            string TextDiscreteInputAddr = (i).ToString();
                            string TextDiscreteInputValue = GetBooleanDiscreteInput(Convert.ToUInt64(i)).ToString();

                            if (TextDiscreteInputValue != "False")
                            {
                                ProjectRegister registerDiscreteInput = new ProjectRegister();
                                registerDiscreteInput.RegAddr = TextDiscreteInputAddr;
                                registerDiscreteInput.RegValue = TextDiscreteInputValue;
                                listRegistersDiscreteInputElem.AppendElem("RegistersDiscreteInput", registerDiscreteInput);
                            }
                        }
                        #endregion DiscreteInput

                        #region Holding
                        // holding
                        if (HoldingRegistersExists(Convert.ToUInt64(i)))
                        {
                            string TextHoldingAddr = (i).ToString();
                            string TextHoldingValue = GetUlongHoldingRegister(Convert.ToUInt64(i)).ToString();

                            if (TextHoldingValue != "0")
                            {
                                ProjectRegister registerHolding = new ProjectRegister();
                                registerHolding.RegAddr = TextHoldingAddr;
                                registerHolding.RegValue = TextHoldingValue;
                                listRegistersHoldingElem.AppendElem("RegistersHolding", registerHolding);
                            }
                        }
                        #endregion Holding

                        #region Input
                        // input
                        if (InputRegistersExists(Convert.ToUInt64(i)))
                        {
                            string TextInputAddr = (i).ToString();
                            string TextInputValue = GetUlongHoldingRegister(Convert.ToUInt64(i)).ToString();

                            if (TextInputValue != "0")
                            {
                                ProjectRegister registerInput = new ProjectRegister();
                                registerInput.RegAddr = TextInputAddr;
                                registerInput.RegValue = TextInputValue;
                                listRegistersHoldingElem.AppendElem("RegistersInput", registerInput);
                            }
                        }
                        #endregion Input

                        #region DataBuffer
                        // databuffer
                        if (DataBuffersExists(Convert.ToUInt64(i)))
                        {
                            string TextDataBufferAddr = (i).ToString();
                            string TextDataBufferValue = GetUlongDataBuffer(Convert.ToUInt64(i)).ToString();

                            if (TextDataBufferValue != "0")
                            {
                                ProjectRegister registerDataBuffer = new ProjectRegister();
                                registerDataBuffer.RegAddr = TextDataBufferAddr;
                                registerDataBuffer.RegValue = TextDataBufferValue;
                                listRegistersHoldingElem.AppendElem("RegistersDataBuffer", registerDataBuffer);
                            }
                        }
                        #endregion DataBuffer
                    }
                }
                catch { }
            }
            #endregion Save Registers

            GroupCommand.SaveToXml(xmlElem.AppendElem("GroupCommand"));
            GroupTag.SaveToXml(xmlElem.AppendElem("GroupTag"));

        }
        #endregion Save
    }

    #endregion ProjectDevice

}
