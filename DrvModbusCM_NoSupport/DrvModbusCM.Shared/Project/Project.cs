using Scada.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    #region ProjectNodeData
    public struct ProjectNodeData
    {
        public ProjectNodeType nodeType;
        public ProjectChannelDevice channel;
        public ProjectDevice device;
        public ProjectDeviceGroupCommand deviceGroupCommand;
        public ProjectDeviceCommand deviceCommand;
        public ProjectDeviceGroupTag deviceGroupTag;
        public ProjectDeviceTag deviceTag;
    }

    #endregion ProjectNodeData

    #region ProjectNodeType
    public enum ProjectNodeType
    {
        Channel,
        Device,
        DeviceBuffer,
        DeviceGroupCommand,
        DeviceCommand,
        DeviceGroupTag,
        DeviceTag,
    };

    #endregion ProjectNodeType

    #region ProjectChannelDevice

    public class ProjectChannelDevice
    {
        public ProjectChannelDevice()
        {
            Devices = new List<ProjectDevice>();
        }

        #region Канал

        //ID канала
        private Guid channelID;
        public Guid ChannelID
        {
            get { return channelID; }
            set { channelID = value; }
        }

        //Название канала
        private string channelName;
        public string ChannelName
        {
            get { return channelName; }
            set { channelName = value; }
        }

        //Описание канала
        private string channelDescription;
        public string ChannelDescription
        {
            get { return channelDescription; }
            set { channelDescription = value; }
        }

        //Иконка
        private string channelKeyImage;
        public string ChannelKeyImage
        {
            get { return channelKeyImage; }
            set { channelKeyImage = value; }
        }

        public static string KeyImageName(int ChannelType)
        {
            string ChannelKeyImage = string.Empty;
            //Условия иконки 
            switch (ChannelType)
            {
                case 0: //Пусто
                    ChannelKeyImage = "channel_empty_16.png";
                    break;
                case 1: //Последовательный порт
                    ChannelKeyImage = "channel_serialport_16.png";
                    break;
                case 2: //TCP клиент
                    ChannelKeyImage = "channel_ethernet_16.png";
                    break;
                case 3: //TCP UDP клиент
                    ChannelKeyImage = "channel_ethernet_16.png";
                    break;
                default:
                    ChannelKeyImage = "channel_empty_16.png";
                    break;
            }
            return ChannelKeyImage;
        }

        //Состояние канала
        private bool channelEnabled;
        public bool ChannelEnabled
        {
            get { return channelEnabled; }
            set { channelEnabled = value; }
        }

        //Для запуска канала в потоке
        private bool channelThreadEnabled;
        public bool ChannelThreadEnabled
        {
            get { return channelThreadEnabled; }
            set { channelThreadEnabled = value; }
        }

        //Тип канала
        private int channelType;
        public int ChannelType
        {
            get { return channelType; }
            set { channelType = value; }
        }

        //Время записи
        private int writeTimeout;
        public int WriteTimeout
        {
            get { return writeTimeout; }
            set { writeTimeout = value; }
        }

        //Время чтения
        private int readTimeout;
        public int ReadTimeout
        {
            get { return readTimeout; }
            set { readTimeout = value; }
        }

        //Буфер запись
        private int writeBufferSize;
        public int WriteBufferSize
        {
            get { return writeBufferSize; }
            set { writeBufferSize = value; }
        }

        //Буфер чтения
        private int readBufferSize;
        public int ReadBufferSize
        {
            get { return readBufferSize; }
            set { readBufferSize = value; }
        }

        //Таймаут между пакетами
        private int timeout;
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        //Количество ошибок
        private int countError;
        public int CountError
        {
            get { return countError; }
            set { countError = value; }
        }

        #endregion Канал

        #region Шлюз

        //Протокол
        private int gatewayTypeProtocol;
        public int GatewayTypeProtocol
        {
            get { return gatewayTypeProtocol; }
            set { gatewayTypeProtocol = value; }
        }

        //Порт
        private int gatewayPort;
        public int GatewayPort
        {
            get { return gatewayPort; }
            set { gatewayPort = value; }
        }

        //Максимальное количество клиентов
        private int gatewayConnectedClientsMax;
        public int GatewayConnectedClientsMax
        {
            get { return gatewayConnectedClientsMax; }
            set { gatewayConnectedClientsMax = value; }
        }
        #endregion Шлюз

        #region Последовательный порт

        private string serialPortName;
        public string SerialPortName
        {
            get { return serialPortName; }
            set { serialPortName = value; }
        }

        private string serialPortBaudRate;
        public string SerialPortBaudRate
        {
            get { return serialPortBaudRate; }
            set { serialPortBaudRate = value; }
        }

        private string serialPortDataBits;
        public string SerialPortDataBits
        {
            get { return serialPortDataBits; }
            set { serialPortDataBits = value; }
        }

        private string serialPortParity;
        public string SerialPortParity
        {
            get { return serialPortParity; }
            set { serialPortParity = value; }
        }

        private string serialPortStopBits;
        public string SerialPortStopBits
        {
            get { return serialPortStopBits; }
            set { serialPortStopBits = value; }
        }

        private string serialPortHandshake;
        public string SerialPortHandshake
        {
            get { return serialPortHandshake; }
            set { serialPortHandshake = value; }
        }

        private bool serialPortDtrEnable;
        public bool SerialPortDtrEnable
        {
            get { return serialPortDtrEnable; }
            set { serialPortDtrEnable = value; }
        }

        private bool serialPortRtsEnable;
        public bool SerialPortRtsEnable
        {
            get { return serialPortRtsEnable; }
            set { serialPortRtsEnable = value; }
        }

        private int serialPortReceivedBytesThreshold;
        public int SerialPortReceivedBytesThreshold
        {
            get { return serialPortReceivedBytesThreshold; }
            set { serialPortReceivedBytesThreshold = value; }
        }

        #endregion Последовательный порт

        #region TCP, UDP клиент

        private string clientHost;
        public string ClientHost
        {
            get { return clientHost; }
            set { clientHost = value; }
        }

        private int clientPort;
        public int ClientPort
        {
            get { return clientPort; }
            set { clientPort = value; }
        }

        #endregion TCP, UDP клиент

        #region Список типов устройств
        private List<ProjectDevice> devices;
        public List<ProjectDevice> Devices
        {
            get { return devices; }
            set { devices = value; }
        }
        #endregion Список типов устройств    
    }

    #endregion ProjectChannelDevice

    #region ProjectDevice

    public class ProjectDevice
    {
        public ProjectDevice()
        {
            DeviceGroupCommands = new List<ProjectDeviceGroupCommand>();
            DeviceGroupTags = new List<ProjectDeviceGroupTag>();
        }

        #region Устройство
        //ID канала
        private Guid channelID;
        public Guid ChannelID
        {
            get { return channelID; }
            set { channelID = value; }
        }

        //ID устройства
        private Guid deviceID;
        public Guid DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }

        //Иконка устройства
        private string deviceKeyImage;
        public string DeviceKeyImage
        {
            get { return deviceKeyImage; }
            set { deviceKeyImage = value; }
        }

        //Иконка буфера
        private string deviceBufferKeyImage;
        public string DeviceBufferKeyImage
        {
            get { return deviceBufferKeyImage; }
            set { deviceBufferKeyImage = value; }
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

        #endregion Устройство

        #region Формат Float
        private int deviceFloatFormat;
        public int DeviceFloatFormat
        {
            get { return deviceFloatFormat; }
            set { deviceFloatFormat = value; }
        }
        #endregion Формат Float

        #region Команды
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
        #endregion Команды

        #region Шлюз                                   
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

        #endregion Шлюз             

        #region Группа команд
        private List<ProjectDeviceGroupCommand> deviceGroupCommands;
        public List<ProjectDeviceGroupCommand> DeviceGroupCommands
        {
            get { return deviceGroupCommands; }
            set { deviceGroupCommands = value; }
        }
        #endregion Группа команд

        #region Теги
        private List<ProjectDeviceGroupTag> deviceGroupTags;
        public List<ProjectDeviceGroupTag> DeviceGroupTags
        {
            get { return deviceGroupTags; }
            set { deviceGroupTags = value; }
        }
        //public static List<TAG> ModbusDevicesTags { get; set; }
        #endregion Теги

        #region Регистры
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
        public ulong[] DataBuffers = new ulong[9999999];                        //Буфер устройства           (Фунция с 80 по 99)

        public bool[] ExistCoils = new bool[65535];                             //Coils устройства           (Функция 1)
        public bool[] ExistDiscreteInputs = new bool[65535];                    //DiscreteInputs устройства  (Функция 2)
        public bool[] ExistHoldingRegisters = new bool[65535];                  //HoldingRegister устройства (Функция 3)
        public bool[] ExistInputRegisters = new bool[65535];                    //InputRegister устройства   (Функция 4)
        public bool[] ExistDataBuffers = new bool[9999999];                     //Буфер устройства           (Фунция с 80 по 99)

        #endregion Регистры

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

        //public byte[] GetBooleanCoil(ushort RegAddr, ushort Count)
        //{
        //    byte[] result = (byte[])null;

        //    bool[] Coils = new bool[(int)Count];
        //    for (int index = 0; index < Coils.Length; ++index)
        //    {
        //        Coils[index] = GetBooleanDiscreteInput((ushort)(RegAddr + (uint)index));
        //    }
        //    result = HEX_BOOLEAN.ToByteArray(Coils);
        //    return result;
        //}

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

        //public byte[] GetBooleanDiscreteInput(ushort RegAddr, ushort Count)
        //{
        //    byte[] result = (byte[])null;

        //    bool[] DiscreteInput = new bool[(int)Count];
        //    for (int index = 0; index < DiscreteInput.Length; ++index)
        //    {
        //        DiscreteInput[index] = GetBooleanDiscreteInput((ushort)(RegAddr + (uint)index));
        //    }
        //    result = HEX_BOOLEAN.ToByteArray(DiscreteInput);
        //    return result;
        //}

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

        public bool GetBoolHoldingRegister(ulong RegAddr, int Bit)
        {
            return Convert.ToBoolean((ulong)this.DataHoldingRegisters[(ulong)RegAddr] & (ulong)1 << Bit);
        }

        //public byte[] GetByteHoldingRegister(ulong RegAddr, ulong Count)
        //{
        //    byte[] result = (byte[])null;

        //    for (int index = (int)RegAddr; index < (int)RegAddr + (int)Count; ++index)
        //    {
        //        ulong tmp_value = DataHoldingRegisters[index];
        //        byte[] bytes = BitConverter.GetBytes(tmp_value);
        //        result = HEX_OPERATION.BYTEARRAY_COMBINE(result, bytes);
        //    }

        //    return result;
        //}



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

        //public byte[] GetByteInputRegister(ulong RegAddr, ulong Count)
        //{
        //    byte[] result = (byte[])null;

        //    for (int index = (int)RegAddr; index < (int)RegAddr + (int)Count; ++index)
        //    {
        //        ulong tmp_value = DataInputRegisters[index];
        //        byte[] bytes = BitConverter.GetBytes(tmp_value);
        //        result = HEX_OPERATION.BYTEARRAY_COMBINE(result, bytes);
        //    }

        //    return result;
        //}

        public bool GetBoolInputRegister(ulong RegAddr, int Bit)
        {
            return Convert.ToBoolean((ulong)this.DataInputRegisters[(ulong)RegAddr] & (ulong)1 << Bit);
        }

        #endregion InputRegisters

        #region DataBuffers

        public ulong[] DeviceIDDataDataBuffer()
        {
            return DataBuffers;
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

        public void SetDataBuffer(ulong RegAddr, ulong Value)
        {
            this.ExistDataBuffers[(ulong)RegAddr] = true;
            this.DataBuffers[(ulong)RegAddr] = Value;
        }

        public void SetDataBuffer(ulong RegAddr, int Bit, bool Value)
        {
            try
            {
                this.ExistDataBuffers[(ulong)RegAddr] = true;
                if (Value)
                {
                    this.DataBuffers[(ulong)RegAddr] = Convert.ToUInt64((ulong)this.DataBuffers[(ulong)RegAddr] | (ulong)1 << Bit);
                }

                else
                {
                    this.DataBuffers[(ulong)RegAddr] = Convert.ToUInt64((int)this.DataBuffers[(int)RegAddr] & (int)~Convert.ToUInt64(1 << Bit));
                }
            }
            catch { }
        }

        public void FillDataBuffer(ulong RegAddr, ulong Value, ulong Count)
        {
            try
            {
                for (ulong index = (ulong)RegAddr; index < (ulong)RegAddr + (ulong)Count; ++index)
                {
                    this.SetDataBuffer(Convert.ToUInt64(index), Value);
                }
            }
            catch { }
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
            return this.DataBuffers[(int)RegAddr];
        }

        public byte[] GetByteDataBuffer(ulong RegAddr, ulong Count, int deviceRegistersBytes)
        {
            byte[] value = (byte[])null;

            switch (deviceRegistersBytes)
            {
                case 2: //2 байт
                    for (int index = (int)RegAddr; index < (int)RegAddr + (int)Count; ++index)
                    {
                        ushort tmpValue = Convert.ToUInt16(DataBuffers[index]);
                        byte[] bytes = BitConverter.GetBytes(tmpValue);
                        bytes = HEX_ARRAY.ArrayReverse(bytes);
                        value = HEX_OPERATION.BYTEARRAY_COMBINE(value, bytes);
                    }
                    break;
                case 4: //4 байт
                    for (int index = (int)RegAddr; index < (int)RegAddr + (int)Count; ++index)
                    {
                        uint tmpValue = Convert.ToUInt32(DataBuffers[index]);
                        byte[] bytes = BitConverter.GetBytes(tmpValue);
                        bytes = HEX_ARRAY.ArrayReverse(bytes);
                        value = HEX_OPERATION.BYTEARRAY_COMBINE(value, bytes);    
                    }
                    break;
            }
            return value;
        }

        public bool GetBoolDataBuffer(ulong RegAddr, int Bit)
        {
            return Convert.ToBoolean((ulong)this.DataBuffers[(ulong)RegAddr] & (ulong)1 << Bit);
        }

        #endregion DataBuffers

    }

    #endregion ProjectDevice

    #region ProjectDeviceGroupCommand

    public class ProjectDeviceGroupCommand
    {
        public ProjectDeviceGroupCommand()
        {
            DeviceCommands = new List<ProjectDeviceCommand>();
        }

        #region Группа  
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

        //Иконка устройства
        private string deviceGroupCommandKeyImage;
        public string DeviceGroupCommandKeyImage
        {
            get { return deviceGroupCommandKeyImage; }
            set { deviceGroupCommandKeyImage = value; }
        }

        //Название группы команд
        private string deviceGroupCommandName;
        public string DeviceGroupCommandName
        {
            get { return deviceGroupCommandName; }
            set { deviceGroupCommandName = value; }
        }

        //Описание группы команд
        private string deviceGroupCommandDescription;
        public string DeviceGroupCommandDescription
        {
            get { return deviceGroupCommandDescription; }
            set { deviceGroupCommandDescription = value; }
        }

        //Состояние группы команд
        private bool deviceGroupCommandEnabled;
        public bool DeviceGroupCommandEnabled
        {
            get { return deviceGroupCommandEnabled; }
            set { deviceGroupCommandEnabled = value; }
        }

        #endregion Группа

        #region List Commands
        private List<ProjectDeviceCommand> deviceCommands;
        public List<ProjectDeviceCommand> DeviceCommands
        {
            get { return deviceCommands; }
            set { deviceCommands = value; }
        }
        #endregion List Commands
    }

    #endregion ProjectDeviceGroupCommand

    #region ProjectDeviceCommand
    public class ProjectDeviceCommand
    {
        public ProjectDeviceCommand()
        {

        }

        public ProjectDeviceCommand(string deviceCommandName, string deviceCommandDescription, bool deviceCommandEnabled, ushort deviceCommandFunctionCode, ushort deviceCommandRegisterStartAddress, ushort deviceCommandRegisterCount, ulong[] deviceCommandRegisterWriteData)
        {
            this.DeviceCommandName = deviceCommandName;
            this.DeviceCommandDescription = deviceCommandDescription;
            this.DeviceCommandEnabled = deviceCommandEnabled;
            this.DeviceCommandFunctionCode = deviceCommandFunctionCode;
            this.DeviceCommandRegisterStartAddress = deviceCommandRegisterStartAddress;
            this.DeviceCommandRegisterCount = deviceCommandRegisterCount;
            this.DeviceCommandRegisterWriteData = deviceCommandRegisterWriteData;
        }

        public ProjectDeviceCommand(string deviceCommandName, string deviceCommandDescription, bool deviceCommandEnabled, ushort deviceCommandFunctionCode, ushort deviceCommandRegisterStartAddress, ushort deviceCommandRegisterCount, ulong[] deviceCommandRegisterReadData, ulong[] deviceCommandRegisterWriteData)
        {
            this.DeviceCommandName = deviceCommandName;
            this.DeviceCommandDescription = deviceCommandDescription;
            this.DeviceCommandEnabled = deviceCommandEnabled;
            this.DeviceCommandFunctionCode = deviceCommandFunctionCode;
            this.DeviceCommandRegisterStartAddress = deviceCommandRegisterStartAddress;
            this.DeviceCommandRegisterCount = deviceCommandRegisterCount;
            this.DeviceCommandRegisterReadData = deviceCommandRegisterReadData;
            this.DeviceCommandRegisterWriteData = deviceCommandRegisterWriteData;
        }

        public ProjectDeviceCommand(string deviceCommandName, string deviceCommandDescription, bool deviceCommandEnabled, ushort deviceCommandFunctionCode, ushort deviceCommandRegisterStartAddress, ushort deviceCommandRegisterCount, ulong[] deviceCommandRegisterReadData, ulong[] deviceCommandRegisterWriteData, ulong deviceCommandParametr)
        {
            this.DeviceCommandName = deviceCommandName;
            this.DeviceCommandDescription = deviceCommandDescription;
            this.DeviceCommandEnabled = deviceCommandEnabled;
            this.DeviceCommandFunctionCode = deviceCommandFunctionCode;
            this.DeviceCommandRegisterStartAddress = deviceCommandRegisterStartAddress;
            this.DeviceCommandRegisterCount = deviceCommandRegisterCount;
            this.DeviceCommandRegisterReadData = deviceCommandRegisterReadData;
            this.DeviceCommandRegisterWriteData = deviceCommandRegisterWriteData;
            this.DeviceCommandParametr = deviceCommandParametr;
        }

        #region Command
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

        public static string KeyImageName(ulong DeviceCommandFunctionCode)
        {
            string DeviceCommandKeyImage = string.Empty;
            //Условия иконки 
            switch (DeviceCommandFunctionCode)
            {
                case 0:
                    DeviceCommandKeyImage = "command_00_16.png";
                    break;
                case 1:
                    DeviceCommandKeyImage = "command_01_16.png";
                    break;
                case 2:
                    DeviceCommandKeyImage = "command_02_16.png";
                    break;
                case 3:
                    DeviceCommandKeyImage = "command_03_16.png";
                    break;
                case 4:
                    DeviceCommandKeyImage = "command_04_16.png";
                    break;
                case 5:
                    DeviceCommandKeyImage = "command_05_16.png";
                    break;
                case 6:
                    DeviceCommandKeyImage = "command_06_16.png";
                    break;
                case 7:
                    DeviceCommandKeyImage = "command_07_16.png";
                    break;
                case 8:
                    DeviceCommandKeyImage = "command_08_16.png";
                    break;
                case 11:
                    DeviceCommandKeyImage = "command_11_16.png";
                    break;
                case 12:
                    DeviceCommandKeyImage = "command_12_16.png";
                    break;
                case 15:
                    DeviceCommandKeyImage = "command_15_16.png";
                    break;
                case 16:
                    DeviceCommandKeyImage = "command_16_16.png";
                    break;
                case 17:
                    DeviceCommandKeyImage = "command_17_16.png";
                    break;
                case 20:
                    DeviceCommandKeyImage = "command_20_16.png";
                    break;
                case 21:
                    DeviceCommandKeyImage = "command_21_16.png";
                    break;
                case 22:
                    DeviceCommandKeyImage = "command_22_16.png";
                    break;
                case 24:
                    DeviceCommandKeyImage = "command_24_16.png";
                    break;
                case 43:
                    DeviceCommandKeyImage = "command_43_16.png";
                    break;
                case 99:
                    DeviceCommandKeyImage = "command_99_16.png";
                    break;
                default:
                    DeviceCommandKeyImage = "command_00_16.png";
                    break;
            }
            return DeviceCommandKeyImage;
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
        private ulong deviceCommandFunctionCode;
        public ulong DeviceCommandFunctionCode
        {
            get { return deviceCommandFunctionCode; }
            set { deviceCommandFunctionCode = value; }
        }

        private ulong deviceCommandRegisterStartAddress;
        public ulong DeviceCommandRegisterStartAddress
        {
            get { return deviceCommandRegisterStartAddress; }
            set { deviceCommandRegisterStartAddress = value; }
        }

        private ulong deviceCommandRegisterCount;
        public ulong DeviceCommandRegisterCount
        {
            get { return deviceCommandRegisterCount; }
            set { deviceCommandRegisterCount = value; }
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

        #endregion Command

        public string GenerateName()
        {
            string nameCommand = string.Empty;
            return nameCommand = "Команда:[" + DeviceCommandFunctionCode + "][" + DeviceCommandRegisterStartAddress + "][" + DeviceCommandRegisterCount + "]";
        }

    }

    #endregion ProjectDeviceCommand

    #region ProjectDeviceGroupTag

    public class ProjectDeviceGroupTag
    {
        public ProjectDeviceGroupTag()
        {
            DeviceTags = new List<ProjectDeviceTag>();
        }

        #region Группа тегов
        //ID устройства
        private Guid deviceID;
        public Guid DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }

        //ID группы тегов
        private Guid deviceGroupTagID;
        public Guid DeviceGroupTagID
        {
            get { return deviceGroupTagID; }
            set { deviceGroupTagID = value; }
        }

        //Иконка устройства
        private string deviceGroupTagKeyImage;
        public string DeviceGroupTagKeyImage
        {
            get { return deviceGroupTagKeyImage; }
            set { deviceGroupTagKeyImage = value; }
        }

        //Название группы тегов
        private string deviceGroupTagName;
        public string DeviceGroupTagName
        {
            get { return deviceGroupTagName; }
            set { deviceGroupTagName = value; }
        }

        //Описание группы тегов
        private string deviceGroupTagDescription;
        public string DeviceGroupTagDescription
        {
            get { return deviceGroupTagDescription; }
            set { deviceGroupTagDescription = value; }
        }

        //Состояние группы тегов
        private bool deviceGroupTagEnabled;
        public bool DeviceGroupTagEnabled
        {
            get { return deviceGroupTagEnabled; }
            set { deviceGroupTagEnabled = value; }
        }

        #endregion Группа тегов

        #region Список тегов

        private List<ProjectDeviceTag> deviceTags;
        public List<ProjectDeviceTag> DeviceTags
        {
            get { return deviceTags; }
            set { deviceTags = value; }
        }

        public static List<ProjectDeviceTag> Tags { get; set; }

        #endregion Список тегов

        #region Конвертирование
        public DataTable ConvertListTagsToDataTable(List<ProjectDeviceTag> listTags)
        {
            DataTable tmpDataTable = new DataTable();

            tmpDataTable.Columns.Add("TagEnabled", typeof(string));
            tmpDataTable.Columns.Add("TagAddress", typeof(string));
            tmpDataTable.Columns.Add("TagName", typeof(string));
            tmpDataTable.Columns.Add("TagDescription", typeof(string));
            tmpDataTable.Columns.Add("TagType", typeof(string));
            tmpDataTable.Columns.Add("TagCoefficient", typeof(string));
            tmpDataTable.Columns.Add("TagScaled", typeof(string));
            tmpDataTable.Columns.Add("TagScaledHigh", typeof(string));
            tmpDataTable.Columns.Add("TagScaledLow", typeof(string));
            tmpDataTable.Columns.Add("TagRowHigh", typeof(string));
            tmpDataTable.Columns.Add("TagRowLow", typeof(string));

            for (int i = 0; i < listTags.Count; i++)
            {
                ProjectDeviceTag tmpTag = listTags[i];
                tmpDataTable.Rows.Add(tmpTag.DeviceTagEnabled.ToString(), tmpTag.DeviceTagAddress.ToString(), tmpTag.DeviceTagname, tmpTag.DeviceTagDescription, tmpTag.DeviceTagType.ToString(), tmpTag.DeviceTagCoefficient, tmpTag.DeviceTagScaled, tmpTag.DeviceTagScaledHigh, tmpTag.DeviceTagScaledLow, tmpTag.DeviceTagRowHigh, tmpTag.DeviceTagRowLow);
            }
            return tmpDataTable;
        }

        public List<ProjectDeviceTag> ConvertDataTableToListTags(DataTable table)
        {
            List<ProjectDeviceTag> tmpListTags = new List<ProjectDeviceTag>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow tmpDataRow = table.Rows[i];

                ProjectDeviceTag newTag = new ProjectDeviceTag();

                newTag.DeviceID = DriverUtils.StringToGuid("00000000-0000-0000-0000-000000000000");
                newTag.DeviceGroupTagID = DriverUtils.StringToGuid("00000000-0000-0000-0000-000000000000");
                newTag.DeviceTagID = Guid.NewGuid();
                newTag.DeviceTagEnabled = Convert.ToBoolean(tmpDataRow.ItemArray[0]);
                newTag.DeviceTagAddress = tmpDataRow.ItemArray[1].ToString();
                newTag.DeviceTagname = tmpDataRow.ItemArray[2].ToString();
                newTag.DeviceTagDescription = tmpDataRow.ItemArray[3].ToString();
                newTag.DeviceTagType = (ProjectDeviceTag.DeviceTagFormatData)Enum.Parse(typeof(ProjectDeviceTag.DeviceTagFormatData), tmpDataRow.ItemArray[4].ToString());

                newTag.DeviceTagCoefficient = Convert.ToSingle(tmpDataRow.ItemArray[5]);
                newTag.DeviceTagScaled = Convert.ToInt32(tmpDataRow.ItemArray[6]);
                newTag.DeviceTagScaledHigh = Convert.ToSingle(tmpDataRow.ItemArray[7]);
                newTag.DeviceTagScaledLow = Convert.ToSingle(tmpDataRow.ItemArray[8]);
                newTag.DeviceTagRowHigh = Convert.ToSingle(tmpDataRow.ItemArray[9]);
                newTag.DeviceTagRowLow = Convert.ToSingle(tmpDataRow.ItemArray[10]);

                newTag.DeviceTagDateTime = DateTime.MinValue;
                newTag.DeviceTagDataValue = 0;
                newTag.DeviceTagQuality = 0;

                tmpListTags.Add(newTag);
            }

            return tmpListTags;
        }

        #endregion Конвертирование
    }

    #endregion ProjectDeviceGroupTag

    #region ProjectDeviceTag

    public class ProjectDeviceTag
    {
        public ProjectDeviceTag()
        {

        }

        public ProjectDeviceTag(string tagAddress, string tagName, string tagCode, string tagDescription, object tagType, bool tagEnabled, float tagCoefficient, float tagScaledHigh, float tagScaledLow, float tagRowHigh, float tagRowLow)
        {
            this.DeviceTagAddress = tagAddress;
            this.DeviceTagname = tagName;
            this.DeviceTagCode = tagCode;
            this.DeviceTagDescription = tagDescription;
            this.DeviceTagType = tagType;
            this.DeviceTagEnabled = tagEnabled;
            this.DeviceTagCoefficient = tagCoefficient;
            this.DeviceTagScaledHigh = tagScaledHigh;
            this.DeviceTagScaledLow = tagScaledLow;
            this.DeviceTagRowHigh = tagRowHigh;
            this.DeviceTagRowLow = tagRowLow;
        }

        #region Тег

        //ID устройства
        private Guid deviceID;
        public Guid DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }

        //ID группы тегов
        private Guid deviceGroupTagID;
        public Guid DeviceGroupTagID
        {
            get { return deviceGroupTagID; }
            set { deviceGroupTagID = value; }
        }

        private Guid deviceTagID;
        public Guid DeviceTagID
        {
            get { return deviceTagID; }
            set { deviceTagID = value; }
        }

        private string deviceTagCode;
        public string DeviceTagCode
        {
            get { return deviceTagCode; }
            set { deviceTagCode = value; }
        }

        //Иконка устройства
        private string deviceTagKeyImage;
        public string DeviceTagKeyImage
        {
            get { return deviceTagKeyImage; }
            set { deviceTagKeyImage = value; }
        }

        private string deviceTagAddress;
        public string DeviceTagAddress
        {
            get { return deviceTagAddress; }
            set { deviceTagAddress = value; }
        }

        private string deviceTagname;
        public string DeviceTagname
        {
            get { return deviceTagname; }
            set { deviceTagname = value; }
        }

        private string deviceTagDescription;
        public string DeviceTagDescription
        {
            set { deviceTagDescription = value; }
            get { return deviceTagDescription; }
        }

        private object deviceTagType;
        public object DeviceTagType
        {
            set { deviceTagType = value; }
            get { return deviceTagType; }
        }

        private bool deviceTagEnabled;
        public bool DeviceTagEnabled
        {
            set { deviceTagEnabled = value; }
            get { return deviceTagEnabled; }
        }

        private string deviceTagSorting;
        public string DeviceTagSorting
        {
            set { deviceTagSorting = value; }
            get { return deviceTagSorting; }
        }

        private object deviceTagDataValue;
        public object DeviceTagDataValue
        {
            set { deviceTagDataValue = value; }
            get { return deviceTagDataValue; }
        }

        private DateTime deviceTagDateTime;
        public DateTime DeviceTagDateTime
        {
            set { deviceTagDateTime = value; }
            get { return deviceTagDateTime; }
        }

        private ushort deviceTagQuality;
        public ushort DeviceTagQuality
        {
            set { deviceTagQuality = value; }
            get { return deviceTagQuality; }
        }

        private float deviceTagCoefficient;
        public float DeviceTagCoefficient
        {
            get { return deviceTagCoefficient; }
            set { deviceTagCoefficient = value; }
        }

        private int deviceTagScaled;
        public int DeviceTagScaled
        {
            set { deviceTagScaled = value; }
            get { return deviceTagScaled; }
        }

        private float deviceTagScaledHigh;
        public float DeviceTagScaledHigh
        {
            get { return deviceTagScaledHigh; }
            set { deviceTagScaledHigh = value; }
        }

        private float deviceTagScaledLow;
        public float DeviceTagScaledLow
        {
            get { return deviceTagScaledLow; }
            set { deviceTagScaledLow = value; }
        }

        private float deviceTagRowHigh;
        public float DeviceTagRowHigh
        {
            get { return deviceTagRowHigh; }
            set { deviceTagRowHigh = value; }
        }

        private float deviceTagRowLow;
        public float DeviceTagRowLow
        {
            get { return deviceTagRowLow; }
            set { deviceTagRowLow = value; }
        }

        //string[] names = Enum.GetNames(typeof (Dimension));
        //Dimension d = (Dimension)Enum.Parse(typeof (Dimension), names[x]);

        public enum DeviceTagFormatData
        {
            BIT,
            BIT32,
            BIT64,
            DATETIME,
            DOUBLE,
            FLOAT,
            HEX,
            INT,
            LONG,
            SHORT,
            UINT,
            ULONG,
            USHORT,
        }

        public static int DeviceTagFormatDataRegisterCount(ProjectDeviceTag tag, int deviceRegistersBytes = 0)
        {
            int count = 0;
            DeviceTagFormatData format = (DeviceTagFormatData)Enum.Parse(typeof(DeviceTagFormatData), tag.DeviceTagType.ToString());

            switch (format)
            {
                case ProjectDeviceTag.DeviceTagFormatData.BIT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 1; 
                        case 4: return 1;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.BIT32:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.BIT64:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.DATETIME:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.DOUBLE:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.FLOAT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.HEX:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.INT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.LONG:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.SHORT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.UINT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.ULONG:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.USHORT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 1;
                        case 4: return 1;
                    }
                    break;
            }
            return count;
        }

        #endregion Тег

        public static object GetValue(ProjectDeviceTag tag, byte[] bytes)
        {
            object value = new object();
            DeviceTagFormatData format = (DeviceTagFormatData)Enum.Parse(typeof(DeviceTagFormatData), tag.DeviceTagType.ToString());
            int startBit = 0;
            int endBit = 0; 
            int countBit = 0;
            int address = DriverUtils.FloatToFractionalNumber(tag.deviceTagAddress, out startBit, out endBit, out countBit);

            switch (format)
            {
                case ProjectDeviceTag.DeviceTagFormatData.BIT:
                    if (countBit == 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_STRINGBIN(bytes);
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit);
                    }
                    else if (endBit > 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit, countBit);
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.BIT32:
                    if (countBit == 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_STRINGBIN(bytes);
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit);
                    }
                    else if (endBit > 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit, countBit);
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.BIT64:
                    if (countBit == 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_STRINGBIN(bytes);
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit);
                    }
                    else if (endBit > 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit, countBit);
                    }
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.DATETIME:
                    value = HEX_DATETIME.DateTimeFromByteArray(bytes);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.DOUBLE:
                    value = BitConverter.ToDouble(bytes, 0);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.FLOAT:
                    value = BitConverter.ToSingle(bytes, 0);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.HEX:
                    if (countBit == 0)
                    {
                        value = BitConverter.ToString(bytes, 0).ToString().Replace("-", "");
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        byte[] tmpByte = new byte[2];
                        if (bytes.Length - 1 <= startBit)
                        {
                            tmpByte[0] = bytes[0];
                            tmpByte[1] = bytes[1];
                        }
                        else
                        {
                            tmpByte[0] = bytes[bytes.Length - 2 - startBit];
                            tmpByte[1] = bytes[bytes.Length - 1 - startBit];
                        }
                        value = BitConverter.ToString(tmpByte, 0).ToString().Replace("-", "");
                    }            
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.INT:
                    value = BitConverter.ToInt32(bytes, 0);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.LONG:
                    value = BitConverter.ToInt64(bytes, 0);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.SHORT:
                    value = BitConverter.ToInt16(bytes, 0);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.UINT:
                    value = BitConverter.ToUInt32(bytes, 0);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.ULONG:
                    value = BitConverter.ToUInt64(bytes, 0);
                    break;
                case ProjectDeviceTag.DeviceTagFormatData.USHORT:
                    value = BitConverter.ToUInt16(bytes, 0);
                    break;
            }

            if (value is string strVal || value is byte[] byteVal || value is DateTime dtmVal)
            {
                return value;
            }

            try
            {
                value = tag.DeviceTagCoefficient * Convert.ToDouble(value);
            }
            catch
            {
                value = "<bad>";
            }

            try
            {
                if (tag.DeviceTagScaled == 1)
                {
                    value = (((tag.DeviceTagScaledHigh - tag.DeviceTagScaledLow) / (tag.DeviceTagRowHigh - tag.DeviceTagRowLow)) * (Convert.ToSingle(value) - tag.DeviceTagRowLow)) + tag.DeviceTagScaledLow;
                }
            }
            catch
            {
                value = "<bad>";
            }

            return value;
        }

        #region Качество

        //OPC_QUALITY_BAD = 0; //Значение плохое, но конкретная причина неизвестна
        //OPC_QUALITY_CONFIG_ERROR = 4; //Существует специфическая для сервера проблема с конфигурацией
        //OPC_QUALITY_NOT_CONNECTED = 8; //Вход должен быть логически связан с чем-то, но не является
        //OPC_QUALITY_DEVICE_FAILURE = 12; //Обнаружен сбой устройства
        //OPC_QUALITY_SENSOR_FAILURE = 16; //Обнаружен сбой датчика
        //OPC_QUALITY_LAST_KNOWN = 20; //Связь прервалась. Однако доступно последнее известное значение.
        //OPC_QUALITY_COMM_FAILURE = 24; //Связь прервалась. Последнее известное значение недоступно.
        //OPC_QUALITY_OUT_OF_SERVICE = 28; //Блок отключен от сканирования или иным образом заблокирован.
        //OPC_QUALITY_SENSOR_CAL = 32; //Либо значение достигло одного из пределов датчика (в этом случае поле предела должно быть установлено равным 1 или 2), либо в противном случае известно, что датчик не откалиброван.
        //OPC_QUALITY_UNCERTAIN = 64; //Нет никакой конкретной причины, по которой значение является неопределенным.
        //OPC_QUALITY_LAST_USABLE = 68; //Последнее полезное значение
        //OPC_QUALITY_EGU_EXCEEDED = 84; //Возвращаемое значение выходит за пределы, определенные для этого параметра. Обратите внимание, что в этом случае флаг ограничения указывает, какой предел был превышен.
        //OPC_QUALITY_SUB_NORMAL = 88; //Значение получено из нескольких источников и содержит меньше требуемого количества хороших источников.
        //OPC_QUALITY_GOOD = 192; //Качество хорошая
        //OPC_QUALITY_LOCAL_OVERRIDE = 216; //Значение было переопределено. Как правило, это означает, что вход был отключен и заданное вручную значение было принудительно введено.

        #endregion Качество

    }

    #endregion ProjectDeviceTag

    #region Project

    /// <summary>
    /// Represents a device configuration.
    /// <para>Представляет конфигурацию КП.</para>
    /// </summary>
    [Serializable]
    public class ProjectSettings
    {
        public ProjectChannelDevice ProjectChannelDevice = new ProjectChannelDevice();
        public List<ProjectDevice> ProjectDevice = new List<ProjectDevice>();
        public List<ProjectDeviceGroupCommand> ProjectDeviceGroupCommand = new List<ProjectDeviceGroupCommand>();
        public List<ProjectDeviceCommand> ProjectDeviceCommand = new List<ProjectDeviceCommand>();
        public List<ProjectDeviceGroupTag> ProjectDeviceGroupTag = new List<ProjectDeviceGroupTag>();
        public List<ProjectDeviceTag> ProjectDeviceTag = new List<ProjectDeviceTag>();
    }

    [Serializable]
    public class Project
    {

        public ProjectSettings Settings;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Project()
        {
            Settings = new ProjectSettings();
        }

        private void SetToDefault()
        {
            Settings = new ProjectSettings();
        }

        #region Project Xml
        private const string XmlNodeTag = "NODE";
        private const string XmlNodeTextAtt = "TEXT";
        private const string XmlNodeTagAtt = "TAG";
        private const string XmlNodeImageIndexAtt = "IMAGEKEY";
        #endregion Project Xml

        public bool Load(string fileName, out string errMsg)
        {
            SetToDefault();
            errMsg = "";

            ProjectSettings project = new ProjectSettings();
            ProjectChannelDevice tmpProjectChannel = new ProjectChannelDevice();
            List<ProjectDevice> tmpProjectDevice = new List<ProjectDevice>();
            List<ProjectDeviceGroupCommand> tmpProjectDeviceGroupCommand = new List<ProjectDeviceGroupCommand>();
            List<ProjectDeviceCommand> tmpProjectDeviceCommand = new List<ProjectDeviceCommand>();
            List<ProjectDeviceGroupTag> tmpProjectDeviceGroupTag = new List<ProjectDeviceGroupTag>();
            List<ProjectDeviceTag> tmpProjectDeviceTag = new List<ProjectDeviceTag>();

            XmlTextReader reader = null;
            try
            {
                // disabling re-drawing of treeview till all nodes are added
                reader = new XmlTextReader(fileName);

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            bool isEmptyElement = reader.IsEmptyElement;

                            // loading node attributes
                            int attributeCount = reader.AttributeCount;

                            if (attributeCount > 0)
                            {
                                Dictionary<string, string> attributes = new Dictionary<string, string>();
                                string newNodeName = string.Empty;
                                string newNodeImageKey = string.Empty;
                                string newNodeType = string.Empty;

                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    attributes.Add(reader.Name, reader.Value);
                                }

                                newNodeName = attributes[XmlNodeTextAtt];
                                if (attributes.TryGetValue(XmlNodeTextAtt, out string attributesValue1))
                                {
                                    newNodeName = attributes[XmlNodeTextAtt];
                                }

                                newNodeImageKey = attributes[XmlNodeImageIndexAtt];
                                if (attributes.TryGetValue(XmlNodeImageIndexAtt, out string attributesValue2))
                                {
                                    newNodeImageKey = attributes[XmlNodeImageIndexAtt];
                                }

                                if (attributes.TryGetValue(XmlNodeTagAtt, out string attributesValue3))
                                {
                                    newNodeType = attributes[XmlNodeTagAtt];
                                }

                                ProjectNodeData projectNodeData = new ProjectNodeData();

                                switch (newNodeType)
                                {
                                    case "CHANNEL":
                                        #region Channel
                                        ProjectChannelDevice projectChannelDevice = new ProjectChannelDevice();

                                        try { projectChannelDevice.ChannelKeyImage = attributes["NAME"]; } catch { }
                                        try { projectChannelDevice.ChannelID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectChannelDevice.ChannelName = attributes["NAME"]; } catch { }
                                        try { projectChannelDevice.ChannelDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectChannelDevice.ChannelEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
                                        try { projectChannelDevice.ChannelType = Convert.ToInt32(attributes["TYPE"]); } catch { }
                                        try { projectChannelDevice.GatewayTypeProtocol = Convert.ToInt32(attributes["GATEWAY"]); } catch { }
                                        try { projectChannelDevice.GatewayPort = Convert.ToInt32(attributes["GATEWAYPORT"]); } catch { }
                                        try { projectChannelDevice.GatewayConnectedClientsMax = Convert.ToInt32(attributes["CONNECTEDCLIENTSMAX"]); } catch { }

                                        try { projectChannelDevice.WriteTimeout = Convert.ToInt32(attributes["WRITETIMEOUT"]); } catch { }
                                        try { projectChannelDevice.ReadTimeout = Convert.ToInt32(attributes["READTIMEOUT"]); } catch { }
                                        try { projectChannelDevice.Timeout = Convert.ToInt32(attributes["TIMEOUT"]); } catch { }

                                        try { projectChannelDevice.WriteBufferSize = Convert.ToInt32(attributes["WRITEBUFFERSIZE"]); } catch { }
                                        try { projectChannelDevice.ReadBufferSize = Convert.ToInt32(attributes["READBUFFERSIZE"]); } catch { }

                                        try { projectChannelDevice.CountError = Convert.ToInt32(attributes["COUNTERROR"]); } catch { }

                                        if (Convert.ToInt32(attributes["TYPE"]) == 1) //Последовательный порт
                                        {
                                            try { projectChannelDevice.SerialPortName = attributes["SERIALPORTNAME"]; } catch { }
                                            try { projectChannelDevice.SerialPortBaudRate = attributes["SERIALPORTBAUDRATE"]; } catch { }
                                            try { projectChannelDevice.SerialPortDataBits = attributes["SERIALPORTDATABITS"]; } catch { }
                                            try { projectChannelDevice.SerialPortParity = attributes["SERIALPORTPARITY"]; } catch { }
                                            try { projectChannelDevice.SerialPortStopBits = attributes["SERIALPORTSTOPBITS"]; } catch { }

                                            try { projectChannelDevice.SerialPortHandshake = attributes["HANDSHAKE"]; } catch { }
                                            try { projectChannelDevice.SerialPortDtrEnable = Convert.ToBoolean(attributes["DTR"]); } catch { }
                                            try { projectChannelDevice.SerialPortRtsEnable = Convert.ToBoolean(attributes["RTS"]); } catch { }
                                            try { projectChannelDevice.SerialPortReceivedBytesThreshold = Convert.ToInt32(attributes["RECEIVEDBYTESTHRESHOLD"]); } catch { }
                                        }

                                        if (Convert.ToInt32(attributes["TYPE"]) == 2 || Convert.ToInt32(attributes["TYPE"]) == 3) // TCP UDP клиент
                                        {
                                            try { projectChannelDevice.ClientHost = attributes["CLIENTHOST"]; } catch { }
                                            try { projectChannelDevice.ClientPort = Convert.ToInt32(attributes["CLIENTPORT"]); } catch { }
                                        }

                                        projectNodeData.channel = projectChannelDevice;
                                        projectNodeData.nodeType = ProjectNodeType.Channel;

                                        tmpProjectChannel = projectChannelDevice;
                                        #endregion Channel
                                        break;
                                    case "DEVICE":
                                        #region Device
                                        ProjectDevice projectDevice = new ProjectDevice();

                                        try { projectDevice.ChannelID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDevice.DeviceID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDevice.DeviceAddress = Convert.ToUInt16(attributes["ADDRESS"]); } catch { }
                                        try { projectDevice.DeviceName = attributes["NAME"]; } catch { }
                                        try { projectDevice.DeviceDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDevice.DeviceEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

                                        try
                                        {
                                            // 2x 4x byte device
                                            projectDevice.DeviceRegistersBytes = 0;
                                            foreach (string key in attributes.Keys)
                                            {
                                                if (key.Contains("REGISTERSBYTES"))
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(attributes["REGISTERSBYTES"]) == 2)
                                                        {
                                                            projectDevice.DeviceRegistersBytes = 0;
                                                        }
                                                        else if (Convert.ToInt32(attributes["REGISTERSBYTES"]) == 4)
                                                        {
                                                            projectDevice.DeviceRegistersBytes = 1;
                                                        }
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        catch { }

                                        try
                                        {
                                            // 2x 4x byte device (gateway)
                                            projectDevice.DeviceGatewayRegistersBytes = 0;
                                            foreach (string key in attributes.Keys)
                                            {
                                                if (key.Contains("GATEWAYREGISTERSBYTES"))
                                                {
                                                    try
                                                    {
                                                        if (Convert.ToInt32(attributes["GATEWAYREGISTERSBYTES"]) == 2)
                                                        {
                                                            projectDevice.DeviceGatewayRegistersBytes = 0;
                                                        }
                                                        else if (Convert.ToInt32(attributes["GATEWAYREGISTERSBYTES"]) == 4)
                                                        {
                                                            projectDevice.DeviceGatewayRegistersBytes = 1;
                                                        }
                                                    }
                                                    catch { }
                                                }
                                            }
                                        }
                                        catch { }

                                        // format float
                                        try { projectDevice.DeviceFloatFormat = Convert.ToInt32(attributes["FLOATFORMAT"]); } catch { }

                                        try { projectDevice.DeviceStatus = Convert.ToInt32(attributes["STATUS"]); } catch { }
                                        try { projectDevice.DevicePollingOnScheduleStatus = Convert.ToBoolean(attributes["POLLINGONSCHEDULESTATUS"]); } catch { }
                                        try { projectDevice.DeviceIntervalPool = Convert.ToInt32(attributes["INTERVALPOOL"]); } catch { }
                                        try { projectDevice.DeviceTypeProtocol = Convert.ToInt32(attributes["TYPEPROTOCOL"]); } catch { }

                                        try { projectDevice.DeviceDateTimeLastSuccessfully = DateTime.Parse(attributes["DATETIMELASTSUCCESSFULLY"]); } catch { }
                                        try
                                        {
                                            // creating a buffer
                                            // adding Registers 65535
                                            for (ulong index = 0; index < (ulong)65535; ++index)
                                            {
                                                bool status = false;
                                                ulong value = 0;

                                                projectDevice.SetCoil(Convert.ToUInt64(index), status);
                                                projectDevice.SetDiscreteInput(Convert.ToUInt64(index), status);
                                                projectDevice.SetHoldingRegister(Convert.ToUInt64(index), value);
                                                projectDevice.SetInputRegister(Convert.ToUInt64(index), value);
                                            }

                                            for (ulong index = 0; index < (ulong)9999999; ++index)
                                            {
                                                ulong value = 0;
                                                projectDevice.SetDataBuffer(Convert.ToUInt64(index), value);
                                            }
                                        }
                                        catch { }

                                        // fill in the registers by the name of the attribute and its value from the dictionary of Attribute registers 65535
                                        foreach (string key in attributes.Keys)
                                        {
                                            if (key.Contains("COILREGISTER"))
                                            {
                                                try
                                                {
                                                    bool Coil = Convert.ToBoolean(attributes[key]);
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("COILREGISTER", ""));
                                                    projectDevice.SetCoil(RegAddr, Coil);
                                                }
                                                catch { }
                                            }
                                            else if (key.Contains("DISCRETEINPUT"))
                                            {
                                                try
                                                {
                                                    bool DiscreteInput = Convert.ToBoolean(attributes[key]);
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("DISCRETEINPUT", ""));
                                                    projectDevice.SetDiscreteInput(RegAddr, DiscreteInput);
                                                }
                                                catch { }
                                            }
                                            else if (key.Contains("HOLDINGREGISTER"))
                                            {
                                                try
                                                {
                                                    ulong HoldingRegister = Convert.ToUInt64(attributes[key]);
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("HOLDINGREGISTER", ""));
                                                    projectDevice.SetHoldingRegister(RegAddr, HoldingRegister);
                                                }
                                                catch { }
                                            }
                                            else if (key.Contains("INPUTREGISTER"))
                                            {
                                                try
                                                {
                                                    ulong InputRegister = Convert.ToUInt16(Convert.ToInt64(attributes[key]));
                                                    ulong RegAddr = Convert.ToUInt64(key.Replace("INPUTREGISTER", ""));
                                                    projectDevice.SetInputRegister(RegAddr, InputRegister);
                                                }
                                                catch { }
                                            }
                                        }

                                        projectNodeData.device = projectDevice;
                                        projectNodeData.nodeType = ProjectNodeType.Device;

                                        tmpProjectDevice.Add(projectDevice);
                                        #endregion Device
                                        break;
                                    case "DEVICEGROUPCOMMAND":
                                        #region Device Group Command
                                        ProjectDeviceGroupCommand projectDeviceGroupCommand = new ProjectDeviceGroupCommand();

                                        try { projectDeviceGroupCommand.DeviceID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandName = attributes["NAME"]; } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupCommand.DeviceGroupCommandEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

                                        projectNodeData.deviceGroupCommand = projectDeviceGroupCommand;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceGroupCommand;

                                        tmpProjectDeviceGroupCommand.Add(projectDeviceGroupCommand);
                                        #endregion Device Group Command
                                        break;
                                    case "DEVICECOMMAND":
                                        #region Device
                                        ProjectDeviceCommand projectDeviceCommand = new ProjectDeviceCommand();

                                        try { projectDeviceCommand.DeviceID = DriverUtils.StringToGuid(attributes["IDDEVICE"]); } catch { }
                                        try { projectDeviceCommand.DeviceGroupCommandID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandName = attributes["NAME"]; } catch { }
                                        try { projectDeviceCommand.DeviceCommandDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceCommand.DeviceCommandEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandFunctionCode = Convert.ToUInt16(attributes["FUNCTION"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterStartAddress = Convert.ToUInt16(attributes["REGISTERSTARTADDRESS"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterCount = Convert.ToUInt16(attributes["REGISTERCOUNT"]); } catch { }
                                        try { projectDeviceCommand.DeviceCommandParametr = Convert.ToUInt16(attributes["REGISTERPARAMETR"]); } catch { }

                                        try { projectDeviceCommand.DeviceCommandRegisterNameReadData = attributes["REGISTERNAMEREADDATA"].Split(' '); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterReadData = Array.ConvertAll(attributes["REGISTERREADDATA"].Split(' '), x => { ulong res = Convert.ToUInt64(x); return res; }); } catch { }

                                        try { projectDeviceCommand.DeviceCommandRegisterNameWriteData = attributes["REGISTERNAMEWRITEDATA"].Split(' '); } catch { }
                                        try { projectDeviceCommand.DeviceCommandRegisterWriteData = Array.ConvertAll(attributes["REGISTERWRITEDATA"].Split(' '), x => { ulong res = Convert.ToUInt64(x); return res; }); } catch { }

                                        projectNodeData.deviceCommand = projectDeviceCommand;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceCommand;

                                        tmpProjectDeviceCommand.Add(projectDeviceCommand);

                                        #endregion Device
                                        break;
                                    case "DEVICEGROUPTAG":
                                        #region Device Group Tag
                                        ProjectDeviceGroupTag projectDeviceGroupTag = new ProjectDeviceGroupTag();

                                        try { projectDeviceGroupTag.DeviceID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagName = attributes["NAME"]; } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceGroupTag.DeviceGroupTagEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }

                                        projectNodeData.deviceGroupTag = projectDeviceGroupTag;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceGroupTag;

                                        tmpProjectDeviceGroupTag.Add(projectDeviceGroupTag);  

                                        #endregion Device Group Tag
                                        break;
                                    case "DEVICETAG":
                                        #region Device Tag
                                        ProjectDeviceTag projectDeviceTag = new ProjectDeviceTag();

                                        try { projectDeviceTag.DeviceID = DriverUtils.StringToGuid(attributes["DEVICEID"]); } catch { }
                                        try { projectDeviceTag.DeviceGroupTagID = DriverUtils.StringToGuid(attributes["IDPARENT"]); } catch { }
                                        try { projectDeviceTag.DeviceTagID = DriverUtils.StringToGuid(attributes["ID"]); } catch { }
                                        try { projectDeviceTag.DeviceTagEnabled = Convert.ToBoolean(attributes["ENABLED"]); } catch { }
                                        try { projectDeviceTag.DeviceTagAddress = attributes["ADDRESS"]; } catch { }
                                        try { projectDeviceTag.DeviceTagname = attributes["NAME"]; } catch { }
                                        try { projectDeviceTag.DeviceTagCode = attributes["CODE"]; } catch { }
                                        try { projectDeviceTag.DeviceTagDescription = attributes["DESCRIPTION"]; } catch { }
                                        try { projectDeviceTag.DeviceTagCoefficient = Convert.ToSingle(attributes["COEFFICIENT"]); } catch { }
                                        try { projectDeviceTag.DeviceTagSorting = attributes["SORTING"]; } catch { }

                                        try { projectDeviceTag.DeviceTagScaled = Convert.ToInt32(attributes["SCALED"]); } catch { }
                                        try { projectDeviceTag.DeviceTagScaledHigh = Convert.ToSingle(attributes["SCALEDHIGH"]); } catch { }
                                        try { projectDeviceTag.DeviceTagScaledLow = Convert.ToSingle(attributes["SCALEDLOW"]); } catch { }
                                        try { projectDeviceTag.DeviceTagRowHigh = Convert.ToSingle(attributes["ROWHIGH"]); } catch { }
                                        try { projectDeviceTag.DeviceTagRowLow = Convert.ToSingle(attributes["ROWLOW"]); } catch { }

                                        try
                                        {
                                            ProjectDeviceTag.DeviceTagFormatData Type = (ProjectDeviceTag.DeviceTagFormatData)Enum.Parse(typeof(ProjectDeviceTag.DeviceTagFormatData), attributes["TYPE"]);
                                            projectDeviceTag.DeviceTagType = Type;
                                        }
                                        catch { }

                                        projectNodeData.deviceTag = projectDeviceTag;
                                        projectNodeData.nodeType = ProjectNodeType.DeviceTag;

                                        tmpProjectDeviceTag.Add(projectDeviceTag);
                                        #endregion Device Tag
                                        break;
                                    default:
  
                                        break;
                                }
                            }

                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    {
                        //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        //Ignore Xml Declaration  
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        //Ignore Xml Declaration  
                    }

                }
            }
            finally
            {
                // enabling redrawing of treeview after all nodes are added
                reader.Close();
            }

            Settings.ProjectChannelDevice = tmpProjectChannel;
            Settings.ProjectDevice = tmpProjectDevice;
            Settings.ProjectDeviceGroupCommand = tmpProjectDeviceGroupCommand;
            Settings.ProjectDeviceCommand = tmpProjectDeviceCommand;
            Settings.ProjectDeviceGroupTag = tmpProjectDeviceGroupTag;
            Settings.ProjectDeviceTag = tmpProjectDeviceTag;

            errMsg = "";
            return true;
        }

        
    }
    #endregion Project
}