using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{

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


}
