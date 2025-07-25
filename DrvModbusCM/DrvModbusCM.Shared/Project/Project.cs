﻿using DrvModbusCM.Shared.Communication;
using Master;
using Scada.Data.Entities;
using Scada.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectTag;

namespace Scada.Comm.Drivers.DrvModbusCM
{

    #region Project
    /// <summary>
    /// Represents the configuration of a device driver.
    /// <para>Представляет конфигурацию драйвера устройства.</para>
    /// </summary>
    [Serializable]
    public class Project
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Project()
        {
            Driver = new ProjectDriver();
        }

        private void SetToDefault()
        {
            Driver = new ProjectDriver();
        }

        #region Variables
        // driver
        // драйвер
        private ProjectDriver driver;
        public ProjectDriver Driver
        {
            get { return driver; }
            set { driver = value; }
        }
        #endregion Variables

        #region Load
        /// <summary>
        /// Loads the configuration from the specified file.
        /// <para>Загружает конфигурацию из указанного файла.</para>
        /// </summary>
        public bool Load(string fileName, out string errMsg)
        {
            SetToDefault();

            try
            {
                if (!File.Exists(fileName))
                {
                    try
                    {
                        Save(fileName, out errMsg);
                    }
                    catch
                    {
                        throw new FileNotFoundException(string.Format(CommonPhrases.NamedFileNotFound, fileName));
                    }
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlElement rootElem = xmlDoc.DocumentElement;

                try { Driver.LoadFromXml(rootElem.SelectSingleNode("Driver")); } catch { Driver = new ProjectDriver(); }

                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        #endregion Load

        #region Save
        /// <summary>
        /// Saves the configuration to the specified file.
        /// <para>Сохраняет конфигурацию в указанный файл.</para>
        /// </summary>
        public bool Save(string fileName, out string errMsg)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlDoc.AppendChild(xmlDecl);

                XmlElement rootElem = xmlDoc.CreateElement("Config");
                xmlDoc.AppendChild(rootElem);

                try { Driver.SaveToXml(rootElem.AppendElem("Driver")); } catch { }

                xmlDoc.Save(fileName);
                errMsg = "";
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        #endregion Save

    }
    #endregion Project

    #region ProjectNodeData
    public struct ProjectNodeData
    {
        public ProjectNodeType NodeType;
        public ProjectDriver Driver;
        public ProjectSettings Settings;
        public ProjectGroupChannel GroupChannel;
        public ProjectChannel Channel;
        public ProjectDevice Device;
        public ProjectGroupCommand GroupCommand;
        public ProjectCommand Command;
        public ProjectGroupTag GroupTag;
        public ProjectTag Tag;
    }

    #endregion ProjectNodeData

    #region ProjectNodeType
    public enum ProjectNodeType
    {
        Driver,
        Settings,
        GroupChannel,
        Channel,
        Device,
        GroupCommand,
        Command,
        GroupTag,
        Tag,
    };

    #endregion ProjectNodeType

    #region ProjectDriver

    public class ProjectDriver
    {
        public ProjectDriver()
        {
            Settings = new ProjectSettings();
            GroupChannel= new ProjectGroupChannel();
        }

        #region Variables
        // 
        // название драйвера
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // driver settings
        // настройки драйвера
        private ProjectSettings settings;
        public ProjectSettings Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        // driver channels
        // каналы драйвера
        private ProjectGroupChannel groupChannel;
        public ProjectGroupChannel GroupChannel
        {
            get { return groupChannel; }
            set { groupChannel = value; }
        }
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

            Name = xmlNode.GetChildAsString("Name");
            Settings.LoadFromXml(xmlNode.SelectSingleNode("Settings"));
            GroupChannel.LoadFromXml(xmlNode.SelectSingleNode("GroupChannel"));
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

            xmlElem.AppendElem("Name", Name);
            Settings.SaveToXml(xmlElem.AppendElem("Settings"));
            GroupChannel.SaveToXml(xmlElem.AppendElem("GroupChannel"));
        }
        #endregion Save
    }

    #endregion ProjectDriver

    #region ProjectSettings
    [Serializable]
    public class ProjectSettings
    {
        public ProjectSettings()
        {
            Name = "";
            AutoRun = false;
            Debug = false;
            SaveRegisters = false;
            LanguageIsRussian = false;
        }

        #region Variables
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool autoRun;
        public bool AutoRun
        {
            get { return autoRun; }
            set { autoRun = value; }
        }

        private bool debug;
        public bool Debug
        {
            get { return debug; }
            set { debug = value; }
        }

        private bool saveRegisters;
        public bool SaveRegisters
        {
            get { return saveRegisters; }
            set { saveRegisters = value; }
        }

        private bool languageIsRussian;
        public bool LanguageIsRussian 
        {
            get { return languageIsRussian; }
            set { languageIsRussian = value; }
        }
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

            Name = xmlNode.GetChildAsString("Name");
            AutoRun = xmlNode.GetChildAsBool("AutoRun");
            Debug = xmlNode.GetChildAsBool("Debug");
            SaveRegisters = xmlNode.GetChildAsBool("SaveRegisters");
            LanguageIsRussian = xmlNode.GetChildAsBool("LanguageIsRussian");
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

            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("AutoRun", AutoRun);
            xmlElem.AppendElem("Debug", Debug);
            xmlElem.AppendElem("SaveRegisters", SaveRegisters);
            xmlElem.AppendElem("LanguageIsRussian", LanguageIsRussian);
        }
        #endregion Save

    }

    #endregion ProjectSettings

    #region ProjectGroupChannel

    [Serializable]
    public class ProjectGroupChannel
    {
        public ProjectGroupChannel()
        {
            ID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;

            Group = new List<ProjectChannel>();
        }

        #region Variables

        #region Group
        // id
        private Guid id;
        [XmlAttribute]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        // иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        // название группы каналов
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion Group

        #region Group Command
        private List<ProjectChannel> group;
        public List<ProjectChannel> Group
        {
            get { return group; }
            set { group = value; }
        }
        #endregion Group Command

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
            Name = xmlNode.GetChildAsString("Name");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
          
            try
            {
                if (xmlNode.SelectSingleNode("ListChannels") is XmlNode groupChannelNode)
                {
                    Group = new List<ProjectChannel>();
                    foreach (XmlNode channelNode in groupChannelNode.SelectNodes("Channel"))
                    {
                        ProjectChannel channel = new ProjectChannel();
                        channel.LoadFromXml(channelNode);
                        Group.Add(channel);
                    }
                }
            }
            catch { Group = new List<ProjectChannel>(); }
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
            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("KeyImage", KeyImage);

            try
            {
                XmlElement groupChannelElem = xmlElem.AppendElem("ListChannels");
                foreach (ProjectChannel channel in Group)
                {
                    channel.SaveToXml(groupChannelElem.AppendElem("Channel"));
                }
            }
            catch { }

        }
        #endregion Save
    }

    #endregion ProjectGroupChannel

    #region ProjectChannel
    [Serializable]
    public class ProjectChannel
    {
        public ProjectChannel()
        {
            ID = new Guid();
            Name = string.Empty;
            Description = string.Empty;
            KeyImage = string.Empty;
            Enabled = false;
            ThreadEnabled = false;
            TypeClient = CommunicationClient.None;
            Behavior = OperationMode.Master;
            WriteTimeout = 1000;
            ReadTimeout = 1000;
            Timeout = 100;
            WriteBufferSize = 8192;
            ReadBufferSize = 8192;
            CountError = 3;
            Debug = false;

            TcpServerSettings = new ProjectTcpServer();
            SerialPortSettings = new ProjectSerialPort();
            EthernetClientSettings = new ProjectEthernetClient();
            Devices = new List<ProjectDevice>();
        }

        #region Variables

        #region Channel

        // id канала
        private Guid id;
        [XmlAttribute]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        // название канала
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // описание канала
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        public static string KeyImageName(int Type)
        {
            string KeyImage = string.Empty;
            //Условия иконки 
            switch (Type)
            {
                case 0: //Пусто
                    KeyImage = "channel_empty_16.png";
                    break;
                case 1: //Последовательный порт
                    KeyImage = "channel_serialport_16.png";
                    break;
                case 2: //TCP клиент
                    KeyImage = "channel_ethernet_16.png";
                    break;
                case 3: //TCP UDP клиент
                    KeyImage = "channel_ethernet_16.png";
                    break;
                default:
                    KeyImage = "channel_empty_16.png";
                    break;
            }
            return KeyImage;
        }

        // состояние канала
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        // для запуска канала в потоке
        private bool threadEnabled;
        [XmlAttribute]
        public bool ThreadEnabled
        {
            get { return threadEnabled; }
            set { threadEnabled = value; }
        }

        // тип канала
        private CommunicationClient typeClient;
        [XmlAttribute]
        public CommunicationClient TypeClient
        {
            get { return typeClient; }
            set { typeClient = value; }
        }

        // время записи
        private int writeTimeout;
        [XmlAttribute]
        public int WriteTimeout
        {
            get { return writeTimeout; }
            set { writeTimeout = value; }
        }

        // время чтения
        private int readTimeout;
        [XmlAttribute]
        public int ReadTimeout
        {
            get { return readTimeout; }
            set { readTimeout = value; }
        }

        //Буфер запись
        private int writeBufferSize;
        [XmlAttribute]
        public int WriteBufferSize
        {
            get { return writeBufferSize; }
            set { writeBufferSize = value; }
        }

        // буфер чтения
        private int readBufferSize;
        [XmlAttribute]
        public int ReadBufferSize
        {
            get { return readBufferSize; }
            set { readBufferSize = value; }
        }

        // таймаут между пакетами
        private int timeout;
        [XmlAttribute]
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        // режим поведения
        private OperationMode behavior;
        [XmlAttribute]
        public OperationMode Behavior
        {
            get { return behavior; }
            set { behavior = value; }
        }

        // количество ошибок
        private int countError;
        [XmlAttribute]
        public int CountError
        {
            get { return countError; }
            set { countError = value; }
        }

        // отладка
        private bool debug;
        [XmlAttribute]
        public bool Debug
        {
            get { return debug; }
            set { debug = value; }
        }

        #endregion Channel

        #region Gateway (TcpServer)

        private ProjectTcpServer tcpServerSettings;
        public ProjectTcpServer TcpServerSettings
        {
            get { return tcpServerSettings; }
            set { tcpServerSettings = value; }
        }

        #endregion Gateway (TcpServer)

        #region SerialPort

        private ProjectSerialPort serialPortSettings;
        public ProjectSerialPort SerialPortSettings
        {
            get { return serialPortSettings; }
            set { serialPortSettings = value; }
        }

        #endregion SerialPort

        #region Ethernet Client
        private ProjectEthernetClient ethernetClientSettings;
        public ProjectEthernetClient EthernetClientSettings
        {
            get { return ethernetClientSettings; }
            set { ethernetClientSettings = value; }
        }

        #endregion Ethernet Client

        #region Devices
        private List<ProjectDevice> devices;
        public List<ProjectDevice> Devices
        {
            get { return devices; }
            set { devices = value; }
        }
        #endregion Devices   

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
            Name = xmlNode.GetChildAsString("Name");
            Description = xmlNode.GetChildAsString("Description");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
            Enabled = xmlNode.GetChildAsBool("Enabled");
            ThreadEnabled = xmlNode.GetChildAsBool("ThreadEnabled");
            TypeClient = (CommunicationClient)Enum.Parse(typeof(CommunicationClient), xmlNode.GetChildAsString("TypeClient"));
            Behavior = (OperationMode)Enum.Parse(typeof(OperationMode), xmlNode.GetChildAsString("Behavior"));
            WriteTimeout = xmlNode.GetChildAsInt("WriteTimeout");
            ReadTimeout = xmlNode.GetChildAsInt("ReadTimeout");
            Timeout = xmlNode.GetChildAsInt("Timeout");
            WriteBufferSize = xmlNode.GetChildAsInt("WriteBufferSize");
            ReadBufferSize = xmlNode.GetChildAsInt("ReadBufferSize");
            CountError = xmlNode.GetChildAsInt("CountError");
            Debug = xmlNode.GetChildAsBool("Debug");

            TcpServerSettings.LoadFromXml(xmlNode.SelectSingleNode("TcpServerSettings"));
            SerialPortSettings.LoadFromXml(xmlNode.SelectSingleNode("SerialPortSettings"));
            EthernetClientSettings.LoadFromXml(xmlNode.SelectSingleNode("EthernetClientSettings"));

            try
            {
                if (xmlNode.SelectSingleNode("ListDevices") is XmlNode listDevicesNode)
                {
                    Devices = new List<ProjectDevice>();
                    foreach (XmlNode deviceNode in listDevicesNode.SelectNodes("Device"))
                    {
                        ProjectDevice device = new ProjectDevice();
                        device.LoadFromXml(deviceNode);
                        Devices.Add(device);
                    }
                }
            }
            catch { Devices = new List<ProjectDevice>(); }
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
            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Description", Description);
            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("Enabled", Enabled);
            xmlElem.AppendElem("ThreadEnabled", ThreadEnabled);
            xmlElem.AppendElem("TypeClient", Enum.GetName(typeof(CommunicationClient), TypeClient));
            xmlElem.AppendElem("Behavior", Enum.GetName(typeof(OperationMode), Behavior));
            xmlElem.AppendElem("WriteTimeout", WriteTimeout);
            xmlElem.AppendElem("ReadTimeout", ReadTimeout);
            xmlElem.AppendElem("Timeout", Timeout);
            xmlElem.AppendElem("WriteBufferSize", WriteBufferSize);
            xmlElem.AppendElem("ReadBufferSize", ReadBufferSize);
            xmlElem.AppendElem("CountError", CountError);
            xmlElem.AppendElem("Debug", Debug);

            TcpServerSettings.SaveToXml(xmlElem.AppendElem("TcpServerSettings"));
            SerialPortSettings.SaveToXml(xmlElem.AppendElem("SerialPortSettings"));
            EthernetClientSettings.SaveToXml(xmlElem.AppendElem("EthernetClientSettings"));

            try
            {
                XmlElement listDevicesElem = xmlElem.AppendElem("ListDevices");
                foreach (ProjectDevice device in Devices)
                {
                    device.SaveToXml(listDevicesElem.AppendElem("Device"));
                }
            }
            catch { }

        }
        #endregion Save

    }

    #endregion ProjectChannel

    #region ProjectTcpServer

    public class ProjectTcpServer
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ProjectTcpServer()
        {
            ID = Guid.NewGuid();
            Name = "";
            Ip = IPAddress.Parse("0.0.0.0");
            Port = 0;
            Protocol = DriverProtocol.None;
            ConnectedClientsMax = 100;
        }

        #region Variables
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        public IPAddress Ip { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the protocol.
        /// </summary>
        public DriverProtocol Protocol { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of clients.
        /// </summary>
        public int ConnectedClientsMax { get; set; }

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

            ID = Guid.Parse(xmlNode.GetChildAsString("ID"));
            Name = xmlNode.GetChildAsString("Name");
            Ip = IPAddress.Parse(xmlNode.GetChildAsString("Ip"));
            Port = xmlNode.GetChildAsInt("Port");
            Protocol = (DriverProtocol)Enum.Parse(typeof(DriverProtocol), xmlNode.GetChildAsString("Protocol"));
            ConnectedClientsMax = xmlNode.GetChildAsInt("ConnectedClientsMax");
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

            xmlElem.AppendElem("ID", ID);
            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Ip", Ip);
            xmlElem.AppendElem("Port", Port);
            xmlElem.AppendElem("Protocol", Enum.GetName(typeof(DriverProtocol), Protocol));
            xmlElem.AppendElem("ConnectedClientsMax", ConnectedClientsMax);
        }
        #endregion Save
    }

    #endregion ProjectTcpServer

    #region ProjectSerialPort

    public class ProjectSerialPort
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ProjectSerialPort()
        {
            SerialPortName = string.Empty;
            SerialPortBaudRate = 9600;
            SerialPortDataBits = 8;
            SerialPortParity = Parity.None;
            SerialPortStopBits = StopBits.One;
            SerialPortHandshake = Handshake.None;
            SerialPortDtrEnable = false;
            SerialPortRtsEnable = false;
            SerialPortReceivedBytesThreshold = 1;
        }

        #region Variables

        private string serialPortName;
        public string SerialPortName
        {
            get { return serialPortName; }
            set { serialPortName = value; }
        }

        private int serialPortBaudRate;
        public int SerialPortBaudRate
        {
            get { return serialPortBaudRate; }
            set { serialPortBaudRate = value; }
        }

        private int serialPortDataBits;
        public int SerialPortDataBits
        {
            get { return serialPortDataBits; }
            set { serialPortDataBits = value; }
        }

        private Parity serialPortParity;
        public Parity SerialPortParity
        {
            get { return serialPortParity; }
            set { serialPortParity = value; }
        }

        private StopBits serialPortStopBits;
        public StopBits SerialPortStopBits
        {
            get { return serialPortStopBits; }
            set { serialPortStopBits = value; }
        }

        private Handshake serialPortHandshake;
        public Handshake SerialPortHandshake
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

            SerialPortName = xmlNode.GetChildAsString("Name");
            SerialPortBaudRate = xmlNode.GetChildAsInt("BaudRate");
            SerialPortDataBits = xmlNode.GetChildAsInt("DataBits");
            SerialPortParity = (Parity)Enum.Parse(typeof(Parity), xmlNode.GetChildAsString("Parity"));
            SerialPortStopBits = (StopBits)Enum.Parse(typeof(StopBits), xmlNode.GetChildAsString("StopBits"));
            SerialPortHandshake = (Handshake)Enum.Parse(typeof(Handshake), xmlNode.GetChildAsString("Handshake"));
            SerialPortDtrEnable = xmlNode.GetChildAsBool("DtrEnable");
            SerialPortRtsEnable = xmlNode.GetChildAsBool("RtsEnable");
            SerialPortReceivedBytesThreshold = xmlNode.GetChildAsInt("ReceivedBytesThreshold");
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

            xmlElem.AppendElem("Name", SerialPortName);
            xmlElem.AppendElem("BaudRate", SerialPortBaudRate);
            xmlElem.AppendElem("DataBits", SerialPortDataBits);
            xmlElem.AppendElem("Parity", Enum.GetName(typeof(Parity), SerialPortParity));
            xmlElem.AppendElem("StopBits", Enum.GetName(typeof(StopBits), SerialPortStopBits));
            xmlElem.AppendElem("Handshake", Enum.GetName(typeof(Handshake), SerialPortHandshake));
            xmlElem.AppendElem("DtrEnable", SerialPortDtrEnable);
            xmlElem.AppendElem("RtsEnable", SerialPortRtsEnable);
            xmlElem.AppendElem("ReceivedBytesThreshold", SerialPortReceivedBytesThreshold);
        }
        #endregion Save

    }

    #endregion ProjectSerialPort

    #region ProjectEthernetClient

    public class ProjectEthernetClient
    {
        public ProjectEthernetClient()
        {
            ClientHost = IPAddress.Parse("127.0.0.1");
            ClientPort = 502;
        }

        #region Variables
        private IPAddress clientHost;
        [XmlAttribute]
        public IPAddress ClientHost
        {
            get { return clientHost; }
            set { clientHost = value; }
        }

        private int clientPort;
        [XmlAttribute]
        public int ClientPort
        {
            get { return clientPort; }
            set { clientPort = value; }
        }
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

            ClientHost = IPAddress.Parse(xmlNode.GetChildAsString("ClientHost"));
            ClientPort = xmlNode.GetChildAsInt("ClientPort");
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

            xmlElem.AppendElem("ClientHost", ClientHost.ToString());
            xmlElem.AppendElem("ClientPort", ClientPort);
        }
        #endregion Save
    }

    #endregion ProjectEthernetClient

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
            xmlElem.AppendElem("Protocol", Enum.GetName(typeof(CommunicationClient), Protocol));

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

    #region ProjectRegister
    public class ProjectRegister
    {
        public ProjectRegister() 
        {
            RegAddr = string.Empty;
            RegValue = string.Empty;
        }

        #region Variables
        private string regAddr;
        public string RegAddr
        {
            get { return regAddr; }
            set { regAddr = value; }
        }

        private string regValue;
        public string RegValue
        {
            get { return regValue; }
            set { regValue = value; }
        }
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

            RegAddr = xmlNode.GetChildAsString("RegAddr");
            RegValue = xmlNode.GetChildAsString("RegValue");
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

            xmlElem.AppendElem("RegAddr", RegAddr);
            xmlElem.AppendElem("RegValue", RegValue);
        }
        #endregion Save
    }
    #endregion ProjectRegister

    #region ProjectGroupCommand
    [Serializable]
    public class ProjectGroupCommand
    {
        public ProjectGroupCommand()
        {
            ID = new Guid();
            ParentID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;
            Description = string.Empty;

            Enabled = true;

            ListCommands = new List<ProjectCommand>();
        }

        #region Variables

        #region Group
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

        // название группы команд
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // описание группы команд
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // состояние группы команд
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        #endregion Group

        #region List Commands
        private List<ProjectCommand> listCommands;
        public List<ProjectCommand> ListCommands
        {
            get { return listCommands; }
            set { listCommands = value; }
        }
        #endregion List Commands

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
            Name = xmlNode.GetChildAsString("Name");
            Description = xmlNode.GetChildAsString("Description");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
            Enabled = xmlNode.GetChildAsBool("Enabled");

            try
            {
                if (xmlNode.SelectSingleNode("ListCommands") is XmlNode listCommandsNode)
                {
                    ListCommands = new List<ProjectCommand>();
                    foreach (XmlNode commandNode in listCommandsNode.SelectNodes("Command"))
                    {
                        ProjectCommand command = new ProjectCommand();
                        command.LoadFromXml(commandNode);
                        ListCommands.Add(command);
                    }
                }
            }
            catch { ListCommands = new List<ProjectCommand>(); }
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
            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Description", Description);
            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("Enabled", Enabled);

            try
            {
                XmlElement listCommandsElem = xmlElem.AppendElem("ListCommands");
                foreach (ProjectCommand command in ListCommands)
                {
                    command.SaveToXml(listCommandsElem.AppendElem("Command"));
                }
            }
            catch { }

        }
        #endregion Save
    }

    #endregion ProjectGroupCommand

    #region ProjectCommand
    [Serializable]
    public class ProjectCommand
    {
        public ProjectCommand()
        {
            ID = new Guid();
            ParentID = new Guid();
            KeyImage = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            CmdCode = string.Empty;
            Enabled = true;

            FunctionCode = 1;
            FunctionCodeWrite = 1;

            RegisterStartAddress = 0;
            RegisterStartAddressWrite = 0;

            RegisterCount = 1;
            RegisterCountWrite = 1;

            RegisterNameWriteData = new string[1];
            RegisterWriteData = new ulong[1];

            WriteDataOther = false;
        }

        #region Command
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

        public static string KeyImageName(ulong functionCode, bool enabled = true)
        {
            string KeyImage = string.Empty;
            int indexImage = 0;

            switch (enabled)
            {
                case true:

                    //Условия иконки 
                    switch (functionCode)
                    {
                        case 0:
                            KeyImage = "cmd_00_16.png";
                            break;
                        case 1:
                            KeyImage = "cmd_01_16.png";
                            break;
                        case 2:
                            KeyImage = "cmd_02_16.png";
                            break;
                        case 3:
                            KeyImage = "cmd_03_16.png";
                            break;
                        case 4:
                            KeyImage = "cmd_04_16.png";
                            break;
                        case 5:
                            KeyImage = "cmd_05_16.png";
                            break;
                        case 6:
                            KeyImage = "cmd_06_16.png";
                            break;
                        case 7:
                            KeyImage = "cmd_07_16.png";
                            break;
                        case 8:
                            KeyImage = "cmd_08_16.png";
                            break;
                        case 11:
                            KeyImage = "cmd_11_16.png";
                            break;
                        case 12:
                            KeyImage = "cmd_12_16.png";
                            break;
                        case 15:
                            KeyImage = "cmd_15_16.png";
                            break;
                        case 16:
                            KeyImage = "cmd_16_16.png";
                            break;
                        case 17:
                            KeyImage = "cmd_17_16.png";
                            break;
                        case 20:
                            KeyImage = "cmd_20_16.png";
                            break;
                        case 21:
                            KeyImage = "cmd_21_16.png";
                            break;
                        case 22:
                            KeyImage = "cmd_22_16.png";
                            break;
                        case 24:
                            KeyImage = "cmd_24_16.png";
                            break;
                        case 43:
                            KeyImage = "cmd_43_16.png";
                            break;
                        case 99:
                            KeyImage = "cmd_99_16.png";
                            break;
                        default:
                            KeyImage = "cmd_00_16.png";
                            break;
                    }

                    break;

                case false:

                    //Условия иконки 
                    switch (functionCode)
                    {
                        case 0:
                            KeyImage = "cmd_00_off_16.png";
                            break;
                        case 1:
                            KeyImage = "cmd_01_off_16.png";
                            break;
                        case 2:
                            KeyImage = "cmd_02_off_16.png";
                            break;
                        case 3:
                            KeyImage = "cmd_03_off_16.png";
                            break;
                        case 4:
                            KeyImage = "cmd_04_off_16.png";
                            break;
                        case 5:
                            KeyImage = "cmd_05_off_16.png";
                            break;
                        case 6:
                            KeyImage = "cmd_06_off_16.png";
                            break;
                        case 7:
                            KeyImage = "cmd_07_off_16.png";
                            break;
                        case 8:
                            KeyImage = "cmd_08_off_16.png";
                            break;
                        case 11:
                            KeyImage = "cmd_11_off_16.png";
                            break;
                        case 12:
                            KeyImage = "cmd_12_off_16.png";
                            break;
                        case 15:
                            KeyImage = "cmd_15_off_16.png";
                            break;
                        case 16:
                            KeyImage = "cmd_16_off_16.png";
                            break;
                        case 17:
                            KeyImage = "cmd_17_off_16.png";
                            break;
                        case 20:
                            KeyImage = "cmd_20_off_16.png";
                            break;
                        case 21:
                            KeyImage = "cmd_21_off_16.png";
                            break;
                        case 22:
                            KeyImage = "cmd_22_off_16.png";
                            break;
                        case 24:
                            KeyImage = "cmd_24_off_16.png";
                            break;
                        case 43:
                            KeyImage = "cmd_43_off_16.png";
                            break;
                        case 99:
                            KeyImage = "cmd_99_off_16.png";
                            break;
                        default:
                            KeyImage = "cmd_00_off_16.png";
                            break;
                    }
                    break;
            }

            return KeyImage;
        }

        // название команды
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // описание команды
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // код команды
        private string cmdCode;
        [XmlAttribute]
        public string CmdCode
        {
            get { return cmdCode; }
            set { cmdCode = value; }
        }

        // состояние команды. Включено ли команда и отправлять ли её
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        // Записывать данные в другие регистры, если это необходимо
        private bool writeDataOther;
        [XmlAttribute]
        public bool WriteDataOther
        {
            get { return writeDataOther; }
            set { writeDataOther = value; }
        }

        // функция (чтения)
        private ulong functionCode;
        [XmlAttribute]
        public ulong FunctionCode
        {
            get { return functionCode; }
            set { functionCode = value; }
        }

        // функция (если надо сохранить в другое место)
        private ulong functionCodeWrite;
        [XmlAttribute]
        public ulong FunctionCodeWrite
        {
            get { return functionCodeWrite; }
            set { functionCodeWrite = value; }
        }

        // начальный регистр
        private ulong registerStartAddress;
        [XmlAttribute]
        public ulong RegisterStartAddress
        {
            get { return registerStartAddress; }
            set { registerStartAddress = value; }
        }

        // начальный регистр (если надо сохранить в другое место)
        private ulong registerStartAddressWrite;
        [XmlAttribute]
        public ulong RegisterStartAddressWrite
        {
            get { return registerStartAddressWrite; }
            set { registerStartAddressWrite = value; }
        }

        // количество регистров
        private ulong registerCount;
        [XmlAttribute]
        public ulong RegisterCount
        {
            get { return registerCount; }
            set { registerCount = value; }
        }

        // количество регистров (если надо сохранить в другое место)
        private ulong registerCountWrite;
        [XmlAttribute]
        public ulong RegisterCountWrite
        {
            get { return registerCountWrite; }
            set { registerCountWrite = value; }
        }

        private string[] registerNameWriteData;
        [XmlAttribute]
        public string[] RegisterNameWriteData
        {
            get { return registerNameWriteData; }
            set { registerNameWriteData = value; }
        }

        private ulong[] registerWriteData;
        [XmlAttribute]
        public ulong[] RegisterWriteData
        {
            get { return registerWriteData; }
            set { registerWriteData = value; }
        }


        #endregion Command

        public string GenerateName()
        {
            string name = string.Empty;
            return name = DriverPhrases.CommandName + ":[" + FunctionCode.ToString().PadLeft(2, '0') + "][" + RegisterStartAddress.ToString().PadLeft(5, '0') + "][" + RegisterCount.ToString().PadLeft(2, '0') + "]";
        }

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
            Name = xmlNode.GetChildAsString("Name");
            Description = xmlNode.GetChildAsString("Description");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
            Enabled = xmlNode.GetChildAsBool("Enabled");

            FunctionCode = Convert.ToUInt64(xmlNode.GetChildAsString("FunctionCode"));
            FunctionCodeWrite = Convert.ToUInt64(xmlNode.GetChildAsString("FunctionCodeWrite"));

            RegisterStartAddress = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterStartAddress"));
            RegisterStartAddressWrite = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterStartAddressWrite"));

            RegisterCount = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterCount"));
            RegisterCountWrite = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterCountWrite"));

            try
            {
                if (xmlNode.SelectSingleNode("ListRegistersWriteData") is XmlNode listRegistersWriteDataNode)
                {
                    List<ProjectRegisterWriteData> ListRegistersWriteData = new List<ProjectRegisterWriteData>();
                    foreach (XmlNode registerWriteDataNode in listRegistersWriteDataNode.SelectNodes("RegisterWriteData"))
                    {
                        ProjectRegisterWriteData registerWriteData = new ProjectRegisterWriteData();
                        registerWriteData.LoadFromXml(registerWriteDataNode);
                        ListRegistersWriteData.Add(registerWriteData);
                    }

                    RegisterNameWriteData = new string[ListRegistersWriteData.Count];
                    RegisterWriteData = new ulong[ListRegistersWriteData.Count];
                    for (int i = 0; i < ListRegistersWriteData.Count; i++)
                    {
                        int regAddr = ListRegistersWriteData[i].RegAddr;
                        RegisterNameWriteData[regAddr] = ListRegistersWriteData[i].RegName;
                        RegisterWriteData[regAddr] = ListRegistersWriteData[i].RegValue;
                    }
                }
            }
            catch 
            {
                RegisterNameWriteData = new string[1];
                RegisterWriteData = new ulong[1];
            }

            for (ulong i = 0; i < RegisterCount; i++)
            {
                RegisterNameWriteData = new string[1];
                RegisterWriteData = new ulong[1];
            }

            WriteDataOther = xmlNode.GetChildAsBool("WriteDataOther");
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
            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Description", Description);
            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("Enabled", Enabled);

            xmlElem.AppendElem("FunctionCode", FunctionCode);
            xmlElem.AppendElem("RegisterStartAddress", RegisterStartAddress);
            xmlElem.AppendElem("RegisterCount", RegisterCount);

            try
            {
                if (RegisterCount == Convert.ToUInt64(RegisterWriteData.Length))
                {
                    XmlElement listRegistersWriteDataElem = xmlElem.AppendElem("ListRegistersWriteData");
                    for (int i = 0; i < Convert.ToInt32(RegisterCount); i++)
                    {
                        ProjectRegisterWriteData projectRegisterWriteData = new ProjectRegisterWriteData();
                        projectRegisterWriteData.RegAddr = i;
                        projectRegisterWriteData.RegName = RegisterNameWriteData[i];
                        projectRegisterWriteData.RegValue = RegisterWriteData[i];
                        projectRegisterWriteData.SaveToXml(listRegistersWriteDataElem.AppendElem("RegisterWriteData"));
                    }
                }
            }
            catch { }

            xmlElem.AppendElem("WriteDataOther", WriteDataOther);
            xmlElem.AppendElem("FunctionCodeWrite", FunctionCodeWrite);
            xmlElem.AppendElem("RegisterStartAddressWrite", RegisterStartAddressWrite);
            xmlElem.AppendElem("RegisterCountWrite", RegisterCountWrite);
        }
        #endregion Save
    }
    #endregion ProjectCommand

    #region Project Register Write Data

    public class ProjectRegisterWriteData
    {
        public ProjectRegisterWriteData()
        {
            RegAddr = 0;
            RegName = string.Empty;
            RegValue = 0;
        }

        #region Variables
        private int regAddr;
        [XmlAttribute]
        public int  RegAddr 
        {
            get { return regAddr; } 
            set { regAddr = value; }
        }

        private string regName;
        [XmlAttribute] 
        public string RegName
        {
            get { return regName; }
            set { regName = value; }
        }

        private ulong regValue;
        [XmlAttribute]
        public ulong RegValue
        {
            get { return regValue; }
            set { regValue = value; }
        }
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

            RegAddr = xmlNode.GetChildAsInt("RegAddr");
            RegName = xmlNode.GetChildAsString("RegName");
            RegValue = Convert.ToUInt64(xmlNode.GetChildAsString("RegValue"));
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

            xmlElem.AppendElem("RegAddr", RegAddr);
            xmlElem.AppendElem("RegName", RegName);
            xmlElem.AppendElem("RegValue", RegValue);
        }
        #endregion Save
    }

    #endregion Project Register Write Data

    #region ProjectGroupTag
    [Serializable]
    public class ProjectGroupTag
    {
        public ProjectGroupTag()
        {
            ID = new Guid();
            ParentID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;
            Description = string.Empty;

            Enabled = true;

            ListTags = new List<ProjectTag>();
        }

        #region Variables

        #region Group
        //ID
        private Guid id;
        [XmlAttribute]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        //ID родителя
        private Guid parentID;
        [XmlAttribute]
        public Guid ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        //Иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        //Название группы тегов
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Описание группы тегов
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //Состояние группы тегов
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        #endregion Group

        #region List Tags

        private List<ProjectTag> listTags;
        public List<ProjectTag> ListTags
        {
            get { return listTags; }
            set { listTags = value; }
        }

        #endregion List Tags

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
            Name = xmlNode.GetChildAsString("Name");
            Description = xmlNode.GetChildAsString("Description");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
            Enabled = xmlNode.GetChildAsBool("Enabled");

            try
            {
                if (xmlNode.SelectSingleNode("ListTags") is XmlNode listTagsNode)
                {
                    ListTags = new List<ProjectTag>();
                    foreach (XmlNode tagNode in listTagsNode.SelectNodes("Tag"))
                    {
                        ProjectTag tag = new ProjectTag();
                        tag.LoadFromXml(tagNode);
                        ListTags.Add(tag);
                    }
                }
            }
            catch { ListTags = new List<ProjectTag>(); }
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
            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Description", Description);
            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("Enabled", Enabled);

            try
            {
                XmlElement listTagsElem = xmlElem.AppendElem("ListTags");
                foreach (ProjectTag tag in ListTags)
                {
                    tag.SaveToXml(listTagsElem.AppendElem("Tag"));
                }
            }
            catch { }

        }
        #endregion Save

        #region Конвертирование
        public DataTable ConvertListTagsToDataTable(List<ProjectTag> listTags)
        {
            DataTable tmpDataTable = new DataTable();

            tmpDataTable.Columns.Add("Enabled", typeof(string));
            tmpDataTable.Columns.Add("Address", typeof(string));
            tmpDataTable.Columns.Add("Name", typeof(string));
            tmpDataTable.Columns.Add("Description", typeof(string));
            tmpDataTable.Columns.Add("Type", typeof(string));
            tmpDataTable.Columns.Add("Coefficient", typeof(string));
            tmpDataTable.Columns.Add("Scaled", typeof(string));
            tmpDataTable.Columns.Add("ScaledHigh", typeof(string));
            tmpDataTable.Columns.Add("ScaledLow", typeof(string));
            tmpDataTable.Columns.Add("RowHigh", typeof(string));
            tmpDataTable.Columns.Add("RowLow", typeof(string));

            for (int i = 0; i < listTags.Count; i++)
            {
                ProjectTag tmpTag = listTags[i];
                tmpDataTable.Rows.Add(tmpTag.Enabled.ToString(), tmpTag.Address.ToString(), tmpTag.Name, tmpTag.Description, tmpTag.Format.ToString(), tmpTag.Coefficient, tmpTag.Scaled, tmpTag.ScaledHigh, tmpTag.ScaledLow, tmpTag.RowHigh, tmpTag.RowLow);
            }
            return tmpDataTable;
        }

        public List<ProjectTag> ConvertDataTableToListTags(DataTable table)
        {
            List<ProjectTag> tmpListTags = new List<ProjectTag>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow tmpDataRow = table.Rows[i];

                ProjectTag newTag = new ProjectTag();

                //newTag.ID = DriverUtils.StringToGuid("00000000-0000-0000-0000-000000000000");
                newTag.ParentID = DriverUtils.StringToGuid("00000000-0000-0000-0000-000000000000");
                newTag.ID = Guid.NewGuid();
                newTag.Enabled = Convert.ToBoolean(tmpDataRow.ItemArray[0]);
                newTag.Address = tmpDataRow.ItemArray[1].ToString();
                newTag.Name = tmpDataRow.ItemArray[2].ToString();
                newTag.Description = tmpDataRow.ItemArray[3].ToString();
                newTag.Format = (ProjectTag.FormatData)Enum.Parse(typeof(ProjectTag.FormatData), tmpDataRow.ItemArray[4].ToString());

                newTag.Coefficient = Convert.ToDouble(tmpDataRow.ItemArray[5]);
                newTag.Scaled = (FormatScaled)Enum.Parse(typeof(FormatScaled), tmpDataRow.ItemArray[6].ToString());
                newTag.ScaledHigh = Convert.ToDouble(tmpDataRow.ItemArray[7]);
                newTag.ScaledLow = Convert.ToDouble(tmpDataRow.ItemArray[8]);
                newTag.RowHigh = Convert.ToDouble(tmpDataRow.ItemArray[9]);
                newTag.RowLow = Convert.ToDouble(tmpDataRow.ItemArray[10]);

                newTag.TagDateTime = DateTime.MinValue;
                newTag.DataValue = 0;
                newTag.Quality = 0;

                tmpListTags.Add(newTag);
            }

            return tmpListTags;
        }

        #endregion Конвертирование
    }

    #endregion ProjectGroupTag

    #region ProjectTag
    [Serializable]
    public class ProjectTag
    {
        public ProjectTag()
        {
            ID = new Guid();
            ParentID = new Guid();
            CommandID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;
            Description = string.Empty;
            Code = string.Empty;
            Address = string.Empty;
            Format = FormatData.NONE;
            Sorting = string.Empty;

            Enabled = true;

            Scaled = FormatScaled.NONE;
            Coefficient = 1d;     
            ScaledHigh = 0;
            ScaledLow = 0;
            RowHigh = 0;
            RowLow = 0;
        }

        #region Variables

        //ID
        private Guid id;
        [XmlAttribute]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        //ID родителя
        private Guid parentID;
        [XmlAttribute]
        public Guid ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        //ID команды
        private Guid commandID;
        [XmlAttribute]
        public Guid CommandID
        {
            get { return commandID; }
            set { commandID = value; }
        }

        //Иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        [XmlAttribute]
        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        private string code;
        [XmlAttribute]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string address;
        [XmlAttribute]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private FormatData format;
        [XmlIgnore]
        public FormatData Format
        {
            set { format = value; }
            get { return format; }
        }

        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            set { enabled = value; }
            get { return enabled; }
        }

        private string sorting;
        [XmlAttribute]
        public string Sorting
        {
            set { sorting = value; }
            get { return sorting; }
        }

        private object dataValue;
        [XmlIgnore]
        public object DataValue
        {
            set { dataValue = value; }
            get { return dataValue; }
        }

        private DateTime tagDateTime;
        [XmlAttribute]
        public DateTime TagDateTime
        {
            set { tagDateTime = value; }
            get { return tagDateTime; }
        }

        private ushort quality;
        [XmlAttribute]
        public ushort Quality
        {
            set { quality = value; }
            get { return quality; }
        }

        private double coefficient;
        [XmlAttribute]
        public double Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

        private FormatScaled scaled;
        [XmlAttribute]
        public FormatScaled Scaled
        {
            set { scaled = value; }
            get { return scaled; }
        }

        private double scaledHigh;
        [XmlAttribute]
        public double ScaledHigh
        {
            get { return scaledHigh; }
            set { scaledHigh = value; }
        }

        private double scaledLow;
        [XmlAttribute]
        public double ScaledLow
        {
            get { return scaledLow; }
            set { scaledLow = value; }
        }

        private double rowHigh;
        [XmlAttribute]
        public double RowHigh
        {
            get { return rowHigh; }
            set { rowHigh = value; }
        }

        private double rowLow;
        [XmlAttribute]
        public double RowLow
        {
            get { return rowLow; }
            set { rowLow = value; }
        }

        public enum FormatData
        {
            NONE,
            BIT,
            BIT32,
            BIT64,
            BYTE,
            DATETIME,
            DOUBLE,
            FLOAT,
            HEX,
            INT,
            INT_HI,
            INT_LO,
            LONG,
            SBYTE,
            SHORT,
            UINT,
            ULONG,
            USHORT,
        }

        public enum FormatScaled : int
        {
            NONE = 0,
            LINEAR = 1,
        }

        #endregion #region Variables

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
            CommandID = DriverUtils.StringToGuid(xmlNode.GetChildAsString("CommandID"));

            Name = xmlNode.GetChildAsString("Name");
            Description = xmlNode.GetChildAsString("Description");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
            Enabled = xmlNode.GetChildAsBool("Enabled");

            Code = xmlNode.GetChildAsString("Code");
            Address = xmlNode.GetChildAsString("Address");
            Format = (FormatData)Enum.Parse(typeof(FormatData), xmlNode.GetChildAsString("Format"));
            Sorting = xmlNode.GetChildAsString("Sorting");

            Scaled = (FormatScaled)Enum.Parse(typeof(FormatScaled), xmlNode.GetChildAsString("Scaled"));
            Coefficient = xmlNode.GetChildAsDouble("Coefficient");
            ScaledHigh = xmlNode.GetChildAsDouble("ScaledHigh");
            ScaledLow = xmlNode.GetChildAsDouble("ScaledLow");
            RowHigh = xmlNode.GetChildAsDouble("RowHigh");
            RowLow = xmlNode.GetChildAsDouble("RowLow");

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
            xmlElem.AppendElem("CommandID", CommandID.ToString());

            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Description", Description);
            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("Enabled", Enabled);

            xmlElem.AppendElem("Code", Code);
            xmlElem.AppendElem("Address", Address);
            xmlElem.AppendElem("Format", Enum.GetName(typeof(FormatData), Format));
            xmlElem.AppendElem("Sorting", Sorting);

            xmlElem.AppendElem("Scaled", Enum.GetName(typeof(FormatScaled), Scaled));
            xmlElem.AppendElem("Coefficient", Coefficient);
            xmlElem.AppendElem("ScaledHigh", ScaledHigh);
            xmlElem.AppendElem("ScaledLow", ScaledLow);
            xmlElem.AppendElem("RowHigh", RowHigh);
            xmlElem.AppendElem("RowLow", RowLow);
        }
        #endregion Save

        #region Action
        public static int DeviceTagFormatDataRegisterCount(ProjectTag tag, int deviceRegistersBytes = 0)
        {
            int count = 0;
            FormatData format = (FormatData)Enum.Parse(typeof(FormatData), tag.Format.ToString());
            int startBit = 0;
            int endBit = 0;
            int countBit = 0;
            int address = DriverUtils.FloatToFractionalNumber(tag.address, out startBit, out endBit, out countBit);

            switch (format)
            {
                case ProjectTag.FormatData.BIT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.BIT32:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.BIT64:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.BYTE:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.DATETIME:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 6;
                        case 2: return 3;
                        case 3: return 2;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.DOUBLE:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.FLOAT:
                    if (startBit > 0 && endBit > 0)
                    {
                        return 4;
                    }
                    else
                    {
                        switch (deviceRegistersBytes)
                        {
                            case 1: return 4;
                            case 2: return 2;
                            case 3: return 2;
                            case 4: return 1;
                        }
                    }
                    break;
                case ProjectTag.FormatData.HEX:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.INT:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.INT_HI:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.INT_LO:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.LONG:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.SBYTE:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.SHORT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.UINT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.ULONG:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.USHORT:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
            }
            return count;
        }

        public static object GetValue(ProjectTag tag, byte[] bytes)
        {
            object value = new object();
            FormatData format = tag.Format;
            int startBit = 0;
            int endBit = 0;
            int countBit = 0;
            int address = DriverUtils.FloatToFractionalNumber(tag.address, out startBit, out endBit, out countBit);

            switch (format)
            {
                case ProjectTag.FormatData.BIT:
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
                case ProjectTag.FormatData.BIT32:
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
                case ProjectTag.FormatData.BIT64:
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
                case ProjectTag.FormatData.BYTE:
                    sbyte[] byteValue = Array.ConvertAll(bytes, b => unchecked((sbyte)b));
                    value = byteValue[0];
                    break;
                case ProjectTag.FormatData.DATETIME:
                    if (bytes.Length == 6)
                    {
                        value = HEX_DATETIME.DateTimeFromByteArray6(bytes);
                    }
                    else if (bytes.Length == 8)
                    {
                        value = HEX_DATETIME.DateTimeFromByteArray8(bytes);
                    }
                    break;
                case ProjectTag.FormatData.DOUBLE:
                    value = BitConverter.ToDouble(bytes, 0);
                    break;
                case ProjectTag.FormatData.FLOAT:
                    if (countBit == 0)
                    {
                        value = BitConverter.ToSingle(bytes, 0);
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
                case ProjectTag.FormatData.HEX:
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
                case ProjectTag.FormatData.INT:
                    value = HEX_INT.FromByteArray(bytes);
                    break;
                case ProjectTag.FormatData.INT_HI:
                    value = HEX_INT.FromByteArrayHI(bytes);
                    break;
                case ProjectTag.FormatData.INT_LO:
                    value = HEX_INT.FromByteArrayLO(bytes);
                    break;
                case ProjectTag.FormatData.LONG:
                    value = BitConverter.ToInt64(bytes, 0);
                    break;
                case ProjectTag.FormatData.SBYTE:
                    sbyte[] sbyteValue = Array.ConvertAll(bytes, b => unchecked((sbyte)b));
                    value = sbyteValue[0];
                    break;
                case ProjectTag.FormatData.SHORT:
                    value = BitConverter.ToInt16(bytes, 0);
                    break;
                case ProjectTag.FormatData.UINT:
                    value = BitConverter.ToUInt32(bytes, 0);
                    break;
                case ProjectTag.FormatData.ULONG:
                    value = BitConverter.ToUInt64(bytes, 0);
                    break;
                case ProjectTag.FormatData.USHORT:
                    value = BitConverter.ToUInt16(bytes, 0);
                    break;
            }

            if (value is string strVal || value is byte[] byteVal || value is DateTime dtmVal)
            {
                return value;
            }

            try
            {
                value = tag.Coefficient * Convert.ToDouble(value);
            }
            catch
            {
                value = "<bad>";
            }

            try
            {
                if (tag.Scaled == FormatScaled.LINEAR)
                {
                    value = (((tag.ScaledHigh - tag.ScaledLow) / (tag.RowHigh - tag.RowLow)) * (Convert.ToSingle(value) - tag.RowLow)) + tag.ScaledLow;
                }
            }
            catch
            {
                value = "<bad>";
            }

            return value;
        }

        #region Scaled

        public static double CalcLineScaled(string Value, float DeviceTagCoefficient, int Scaled, double ScaledHigh, double ScaledLow, double RowHigh, double RowLow)
        {
            try
            {
                double ScaledValue = DriverUtils.DoubleAsDouble(Value);
                if (DriverUtils.DoubleIsNaN(ScaledValue))
                {
                    return ScaledValue;
                }
                if (Scaled == 0 && DeviceTagCoefficient == 1f)
                {
                    return ScaledValue;
                }
                else if (Scaled == 0 && DeviceTagCoefficient != 1f)
                {
                    ScaledValue = ScaledValue * DeviceTagCoefficient;
                    return ScaledValue;
                }
                else if (Scaled == 1)
                {
                    double Result = (((ScaledHigh - ScaledLow) / (RowHigh - RowLow)) * (ScaledValue - RowLow)) + ScaledLow;
                    Result = Result * DeviceTagCoefficient;
                    return Result;
                }

                return double.NaN;
            }
            catch
            {
                return double.NaN;
            }
        }

        #endregion Scaled

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

        #endregion Action

    }

    #endregion ProjectTag

}