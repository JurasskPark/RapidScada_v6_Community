using DrvModbusCM.Shared.Project.Tag;
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
            RegData = new byte[0];
            regDataString = string.Empty;
            RegFormat = FormatData.NONE;
            RegValue = new object();
            Sorting = string.Empty;
        }

        #region Variables
        private ulong regAddr;
        [XmlAttribute]
        public ulong RegAddr
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

        private byte[] regData;
        [XmlAttribute]
        public byte[] RegData
        {
            get { return regData; }
            set 
            { 
                regData = value;
                regDataString = HEX_STRING.BYTEARRAY_TO_HEXSTRING(regData);
            }
        }

        private string regDataString;
        [XmlAttribute]
        public string RegDataString
        {
            get { return regDataString; }
            set
            {
                regDataString = value;
                regData = HEX_STRING.HEXSTRING_TO_BYTEARRAY(regDataString);
            }
        }

        private object regValue;
        [XmlAttribute]
        public object RegValue
        {
            get { return regValue; }
            set 
            { 
                regValue = value;          
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

            RegAddr = Convert.ToUInt64(xmlNode.GetChildAsString("RegAddr"));
            RegName = xmlNode.GetChildAsString("RegName");
            RegDescription = xmlNode.GetChildAsString("RegDescription");    
            RegFormat = (FormatData)Enum.Parse(typeof(FormatData), xmlNode.GetChildAsString("RegFormat"));
            RegData = HEX_STRING.HEXSTRING_TO_BYTEARRAY(xmlNode.GetChildAsString("RegData"));
            Sorting = xmlNode.GetChildAsString("RegSorting");  
            RegValueString = xmlNode.GetChildAsString("RegValue");
            RegValue = ConverterFormatData.ConvertStringtoObject(RegFormat, RegValueString);
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
            xmlElem.AppendElem("RegFormat", Enum.GetName(typeof(FormatData), RegFormat));
            xmlElem.AppendElem("RegData", HEX_STRING.BYTEARRAY_TO_HEXSTRING(RegData));    
            xmlElem.AppendElem("RegSorting", Sorting);
            xmlElem.AppendElem("RegValue", RegValueString);

        }
        #endregion Save
    }

    #endregion Project Register Write Data

}
