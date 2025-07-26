using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    #region ProjectGroupChannel

    [Serializable]
    public class ProjectGroupChannel
    {
        public ProjectGroupChannel()
        {
            ID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;

            Group = new List<ProjectChannel>();
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

        // иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        // название группы каналов
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion Group

        #region Group Command
        private List<ProjectChannel> group;
        public List<ProjectChannel> Group
        {
            get { return group; }
            set { group = value; }
        }
        #endregion Group Command

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
            KeyImage = xmlNode.GetChildAsString("KeyImage");

            try
            {
                if (xmlNode.SelectSingleNode("ListChannels") is XmlNode groupChannelNode)
                {
                    Group = new List<ProjectChannel>();
                    foreach (XmlNode channelNode in groupChannelNode.SelectNodes("Channel"))
                    {
                        ProjectChannel channel = new ProjectChannel();
                        channel.LoadFromXml(channelNode);
                        Group.Add(channel);
                    }
                }
            }
            catch { Group = new List<ProjectChannel>(); }
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
            xmlElem.AppendElem("KeyImage", KeyImage);

            try
            {
                XmlElement groupChannelElem = xmlElem.AppendElem("ListChannels");
                foreach (ProjectChannel channel in Group)
                {
                    channel.SaveToXml(groupChannelElem.AppendElem("Channel"));
                }
            }
            catch { }

        }
        #endregion Save
    }

    #endregion ProjectGroupChannel
}
