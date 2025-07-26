using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    #region ProjectGroupCommand
    [Serializable]
    public class ProjectGroupCommand
    {
        public ProjectGroupCommand()
        {
            ID = new Guid();
            ParentID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;
            Description = string.Empty;

            Enabled = true;

            ListCommands = new List<ProjectCommand>();
        }

        #region Variables

        #region Group
        // id
        private Guid id;
        [XmlAttribute]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        // id родителя
        private Guid parentID;
        [XmlAttribute]
        public Guid ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        // иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        // название группы команд
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // описание группы команд
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // состояние группы команд
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        #endregion Group

        #region List Commands
        private List<ProjectCommand> listCommands;
        public List<ProjectCommand> ListCommands
        {
            get { return listCommands; }
            set { listCommands = value; }
        }
        #endregion List Commands

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

            try
            {
                if (xmlNode.SelectSingleNode("ListCommands") is XmlNode listCommandsNode)
                {
                    ListCommands = new List<ProjectCommand>();
                    foreach (XmlNode commandNode in listCommandsNode.SelectNodes("Command"))
                    {
                        ProjectCommand command = new ProjectCommand();
                        command.LoadFromXml(commandNode);
                        ListCommands.Add(command);
                    }
                }
            }
            catch { ListCommands = new List<ProjectCommand>(); }
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

            try
            {
                XmlElement listCommandsElem = xmlElem.AppendElem("ListCommands");
                foreach (ProjectCommand command in ListCommands)
                {
                    command.SaveToXml(listCommandsElem.AppendElem("Command"));
                }
            }
            catch { }

        }
        #endregion Save
    }

    #endregion ProjectGroupCommand

}
