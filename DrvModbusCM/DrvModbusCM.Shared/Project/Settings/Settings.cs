using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{
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

}
