using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using static Scada.Comm.Drivers.DrvModbusCM.ProjectTag;

namespace Scada.Comm.Drivers.DrvModbusCM
{

    #region ProjectGroupTag
    [Serializable]
    public class ProjectGroupTag
    {
        public ProjectGroupTag()
        {
            ID = new Guid();
            ParentID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;
            Description = string.Empty;

            Enabled = true;

            ListTags = new List<ProjectTag>();
        }

        #region Variables

        #region Group
        //ID
        private Guid id;
        [XmlAttribute]
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }

        //ID родителя
        private Guid parentID;
        [XmlAttribute]
        public Guid ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }

        //Иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        //Название группы тегов
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Описание группы тегов
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //Состояние группы тегов
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        #endregion Group

        #region List Tags

        private List<ProjectTag> listTags;
        public List<ProjectTag> ListTags
        {
            get { return listTags; }
            set { listTags = value; }
        }

        #endregion List Tags

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
                if (xmlNode.SelectSingleNode("ListTags") is XmlNode listTagsNode)
                {
                    ListTags = new List<ProjectTag>();
                    foreach (XmlNode tagNode in listTagsNode.SelectNodes("Tag"))
                    {
                        ProjectTag tag = new ProjectTag();
                        tag.LoadFromXml(tagNode);
                        ListTags.Add(tag);
                    }
                }
            }
            catch { ListTags = new List<ProjectTag>(); }
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
                XmlElement listTagsElem = xmlElem.AppendElem("ListTags");
                foreach (ProjectTag tag in ListTags)
                {
                    tag.SaveToXml(listTagsElem.AppendElem("Tag"));
                }
            }
            catch { }

        }
        #endregion Save

        #region Конвертирование
        public DataTable ConvertListTagsToDataTable(List<ProjectTag> listTags)
        {
            DataTable tmpDataTable = new DataTable();

            tmpDataTable.Columns.Add("Enabled", typeof(string));
            tmpDataTable.Columns.Add("Address", typeof(string));
            tmpDataTable.Columns.Add("Name", typeof(string));
            tmpDataTable.Columns.Add("Description", typeof(string));
            tmpDataTable.Columns.Add("Type", typeof(string));
            tmpDataTable.Columns.Add("Coefficient", typeof(string));
            tmpDataTable.Columns.Add("Scaled", typeof(string));
            tmpDataTable.Columns.Add("ScaledHigh", typeof(string));
            tmpDataTable.Columns.Add("ScaledLow", typeof(string));
            tmpDataTable.Columns.Add("RowHigh", typeof(string));
            tmpDataTable.Columns.Add("RowLow", typeof(string));

            for (int i = 0; i < listTags.Count; i++)
            {
                ProjectTag tmpTag = listTags[i];
                tmpDataTable.Rows.Add(tmpTag.Enabled.ToString(), tmpTag.Address.ToString(), tmpTag.Name, tmpTag.Description, tmpTag.Format.ToString(), tmpTag.Coefficient, tmpTag.Scaled, tmpTag.ScaledHigh, tmpTag.ScaledLow, tmpTag.RowHigh, tmpTag.RowLow);
            }
            return tmpDataTable;
        }

        public List<ProjectTag> ConvertDataTableToListTags(DataTable table)
        {
            List<ProjectTag> tmpListTags = new List<ProjectTag>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow tmpDataRow = table.Rows[i];

                ProjectTag newTag = new ProjectTag();

                //newTag.ID = DriverUtils.StringToGuid("00000000-0000-0000-0000-000000000000");
                newTag.ParentID = DriverUtils.StringToGuid("00000000-0000-0000-0000-000000000000");
                newTag.ID = Guid.NewGuid();
                newTag.Enabled = Convert.ToBoolean(tmpDataRow.ItemArray[0]);
                newTag.Address = tmpDataRow.ItemArray[1].ToString();
                newTag.Name = tmpDataRow.ItemArray[2].ToString();
                newTag.Description = tmpDataRow.ItemArray[3].ToString();
                newTag.Format = (ProjectTag.FormatData)Enum.Parse(typeof(ProjectTag.FormatData), tmpDataRow.ItemArray[4].ToString());

                newTag.Coefficient = Convert.ToDouble(tmpDataRow.ItemArray[5]);
                newTag.Scaled = (FormatScaled)Enum.Parse(typeof(FormatScaled), tmpDataRow.ItemArray[6].ToString());
                newTag.ScaledHigh = Convert.ToDouble(tmpDataRow.ItemArray[7]);
                newTag.ScaledLow = Convert.ToDouble(tmpDataRow.ItemArray[8]);
                newTag.RowHigh = Convert.ToDouble(tmpDataRow.ItemArray[9]);
                newTag.RowLow = Convert.ToDouble(tmpDataRow.ItemArray[10]);

                newTag.TagDateTime = DateTime.MinValue;
                newTag.DataValue = 0;
                newTag.Quality = 0;

                tmpListTags.Add(newTag);
            }

            return tmpListTags;
        }

        #endregion Конвертирование
    }

    #endregion ProjectGroupTag


}
