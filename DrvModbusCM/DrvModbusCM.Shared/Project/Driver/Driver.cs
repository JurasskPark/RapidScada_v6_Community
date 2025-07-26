using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    #region ProjectDriver

    public class ProjectDriver
    {
        public ProjectDriver()
        {
            Settings = new ProjectSettings();
            GroupChannel = new ProjectGroupChannel();
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
}
