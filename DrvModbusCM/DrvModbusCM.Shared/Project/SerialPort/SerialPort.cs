using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{

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


}
