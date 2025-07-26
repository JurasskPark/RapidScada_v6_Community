using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{

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

}
