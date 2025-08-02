using Scada.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectTag;

namespace Scada.Comm.Drivers.DrvModbusCM
{

    #region Project Register Write Data

    public class ProjectRegisterWriteData
    {
        public ProjectRegisterWriteData()
        {
            RegAddr = 0;
            RegName = string.Empty;
            RegDescription = string.Empty;
            RegData = string.Empty;
            RegFormat = FormatData.NONE;
            RegValue = new byte[0];
            Sorting = string.Empty;
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

        private string regDescription;
        [XmlAttribute]
        public string RegDescription
        {
            get { return regDescription; }
            set { regDescription = value; }
        }

        private FormatData regFormat;
        [XmlAttribute]
        public FormatData RegFormat
        {
            get { return regFormat; }
            set { regFormat = value; }
        }

        private string regData;
        [XmlAttribute]
        public string RegData
        {
            get { return regData; }
            set { regData = value; }
        }

        private byte[] regValue;
        [XmlAttribute]
        public byte[] RegValue
        {
            get { return regValue; }
            set 
            { 
                regValue = value; 
                regValueString = HEX_STRING.BYTEARRAY_TO_HEXSTRING(regValue);
            }
        }

        private string regValueString;
        [XmlAttribute]
        public string RegValueString
        {
            get { return regValueString; }
            set 
            { 
                regValueString = value;
                regValue = HEX_STRING.HEXSTRING_TO_BYTEARRAY(regValueString);
            }
        }

        private string sorting;
        [XmlAttribute]
        public string Sorting
        {
            set { sorting = value; }
            get { return sorting; }
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
            RegDescription = xmlNode.GetChildAsString("RegDescription");
            RegData = xmlNode.GetChildAsString("RegData");
            RegFormat = (FormatData)Enum.Parse(typeof(FormatData), xmlNode.GetChildAsString("RegFormat"));
            RegValue = HEX_STRING.HEXSTRING_TO_BYTEARRAY(xmlNode.GetChildAsString("RegValue"));
            Sorting = xmlNode.GetChildAsString("RegSorting");
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
            xmlElem.AppendElem("RegDescription", RegDescription);
            xmlElem.AppendElem("RegData", RegData);
            xmlElem.AppendElem("RegFormat", Enum.GetName(typeof(FormatData), RegFormat));
            xmlElem.AppendElem("RegValue", HEX_STRING.BYTEARRAY_TO_HEXSTRING(RegValue));
            xmlElem.AppendElem("RegSorting", Sorting);
        }
        #endregion Save
    }

    #endregion Project Register Write Data

}
