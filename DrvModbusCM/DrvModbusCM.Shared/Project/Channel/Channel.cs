using DrvModbusCM.Shared.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{

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


}
