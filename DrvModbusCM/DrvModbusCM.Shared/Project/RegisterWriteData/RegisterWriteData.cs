using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{

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
        public int RegAddr
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


}
