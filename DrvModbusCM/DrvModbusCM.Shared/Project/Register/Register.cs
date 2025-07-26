using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{
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


}
