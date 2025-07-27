using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    #region ProjectCommand
    [Serializable]
    public class ProjectCommand
    {
        public ProjectCommand()
        {
            ID = new Guid();
            ParentID = new Guid();
            KeyImage = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Code = string.Empty;
            Enabled = true;

            FunctionCode = 1;
            FunctionCodeWrite = 1;

            RegisterStartAddress = 0;
            RegisterStartAddressWrite = 0;

            RegisterCount = 1;
            RegisterCountWrite = 1;

            ListRegistersWriteData = new List<ProjectRegisterWriteData>();
            RegisterWriteData = new byte[0];

            WriteDataOther = false;
        }

        #region Command
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

        public static string KeyImageName(ulong functionCode, bool enabled = true)
        {
            string KeyImage = string.Empty;
            int indexImage = 0;

            switch (enabled)
            {
                case true:

                    //Условия иконки 
                    switch (functionCode)
                    {
                        case 0:
                            KeyImage = "cmd_00_16.png";
                            break;
                        case 1:
                            KeyImage = "cmd_01_16.png";
                            break;
                        case 2:
                            KeyImage = "cmd_02_16.png";
                            break;
                        case 3:
                            KeyImage = "cmd_03_16.png";
                            break;
                        case 4:
                            KeyImage = "cmd_04_16.png";
                            break;
                        case 5:
                            KeyImage = "cmd_05_16.png";
                            break;
                        case 6:
                            KeyImage = "cmd_06_16.png";
                            break;
                        case 7:
                            KeyImage = "cmd_07_16.png";
                            break;
                        case 8:
                            KeyImage = "cmd_08_16.png";
                            break;
                        case 11:
                            KeyImage = "cmd_11_16.png";
                            break;
                        case 12:
                            KeyImage = "cmd_12_16.png";
                            break;
                        case 15:
                            KeyImage = "cmd_15_16.png";
                            break;
                        case 16:
                            KeyImage = "cmd_16_16.png";
                            break;
                        case 17:
                            KeyImage = "cmd_17_16.png";
                            break;
                        case 20:
                            KeyImage = "cmd_20_16.png";
                            break;
                        case 21:
                            KeyImage = "cmd_21_16.png";
                            break;
                        case 22:
                            KeyImage = "cmd_22_16.png";
                            break;
                        case 24:
                            KeyImage = "cmd_24_16.png";
                            break;
                        case 43:
                            KeyImage = "cmd_43_16.png";
                            break;
                        case 99:
                            KeyImage = "cmd_99_16.png";
                            break;
                        default:
                            KeyImage = "cmd_00_16.png";
                            break;
                    }

                    break;

                case false:

                    //Условия иконки 
                    switch (functionCode)
                    {
                        case 0:
                            KeyImage = "cmd_00_off_16.png";
                            break;
                        case 1:
                            KeyImage = "cmd_01_off_16.png";
                            break;
                        case 2:
                            KeyImage = "cmd_02_off_16.png";
                            break;
                        case 3:
                            KeyImage = "cmd_03_off_16.png";
                            break;
                        case 4:
                            KeyImage = "cmd_04_off_16.png";
                            break;
                        case 5:
                            KeyImage = "cmd_05_off_16.png";
                            break;
                        case 6:
                            KeyImage = "cmd_06_off_16.png";
                            break;
                        case 7:
                            KeyImage = "cmd_07_off_16.png";
                            break;
                        case 8:
                            KeyImage = "cmd_08_off_16.png";
                            break;
                        case 11:
                            KeyImage = "cmd_11_off_16.png";
                            break;
                        case 12:
                            KeyImage = "cmd_12_off_16.png";
                            break;
                        case 15:
                            KeyImage = "cmd_15_off_16.png";
                            break;
                        case 16:
                            KeyImage = "cmd_16_off_16.png";
                            break;
                        case 17:
                            KeyImage = "cmd_17_off_16.png";
                            break;
                        case 20:
                            KeyImage = "cmd_20_off_16.png";
                            break;
                        case 21:
                            KeyImage = "cmd_21_off_16.png";
                            break;
                        case 22:
                            KeyImage = "cmd_22_off_16.png";
                            break;
                        case 24:
                            KeyImage = "cmd_24_off_16.png";
                            break;
                        case 43:
                            KeyImage = "cmd_43_off_16.png";
                            break;
                        case 99:
                            KeyImage = "cmd_99_off_16.png";
                            break;
                        default:
                            KeyImage = "cmd_00_off_16.png";
                            break;
                    }
                    break;
            }

            return KeyImage;
        }

        // название команды
        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // описание команды
        private string description;
        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // код команды
        private string code;
        [XmlAttribute]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        // состояние команды. Включено ли команда и отправлять ли её
        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        // Записывать данные в другие регистры, если это необходимо
        private bool writeDataOther;
        [XmlAttribute]
        public bool WriteDataOther
        {
            get { return writeDataOther; }
            set { writeDataOther = value; }
        }

        // функция (чтения)
        private ulong functionCode;
        [XmlAttribute]
        public ulong FunctionCode
        {
            get { return functionCode; }
            set { functionCode = value; }
        }

        // функция (если надо сохранить в другое место)
        private ulong functionCodeWrite;
        [XmlAttribute]
        public ulong FunctionCodeWrite
        {
            get { return functionCodeWrite; }
            set { functionCodeWrite = value; }
        }

        // начальный регистр
        private ulong registerStartAddress;
        [XmlAttribute]
        public ulong RegisterStartAddress
        {
            get { return registerStartAddress; }
            set { registerStartAddress = value; }
        }

        // начальный регистр (если надо сохранить в другое место)
        private ulong registerStartAddressWrite;
        [XmlAttribute]
        public ulong RegisterStartAddressWrite
        {
            get { return registerStartAddressWrite; }
            set { registerStartAddressWrite = value; }
        }

        // количество регистров
        private ulong registerCount;
        [XmlAttribute]
        public ulong RegisterCount
        {
            get { return registerCount; }
            set { registerCount = value; }
        }

        // количество регистров (если надо сохранить в другое место)
        private ulong registerCountWrite;
        [XmlAttribute]
        public ulong RegisterCountWrite
        {
            get { return registerCountWrite; }
            set { registerCountWrite = value; }
        }

        private List<ProjectRegisterWriteData> listRegistersWriteData;
        [XmlAttribute]
        public List<ProjectRegisterWriteData> ListRegistersWriteData
        {
            get { return listRegistersWriteData; }
            set { listRegistersWriteData = value; }
        }

        private byte[] registerWriteData;
        [XmlAttribute]
        public byte[] RegisterWriteData
        {
            get { return registerWriteData; }
            set { registerWriteData = value; }
        }


        #endregion Command

        public string GenerateName()
        {
            string name = string.Empty;
            return name = DriverPhrases.CommandName + ":[" + FunctionCode.ToString().PadLeft(2, '0') + "][" + RegisterStartAddress.ToString().PadLeft(5, '0') + "][" + RegisterCount.ToString().PadLeft(2, '0') + "]";
        }

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
            Code = xmlNode.GetChildAsString("Code");
            Description = xmlNode.GetChildAsString("Description");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
            Enabled = xmlNode.GetChildAsBool("Enabled");

            FunctionCode = Convert.ToUInt64(xmlNode.GetChildAsString("FunctionCode"));
            RegisterStartAddress = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterStartAddress"));
            RegisterCount = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterCount"));
            
            WriteDataOther = xmlNode.GetChildAsBool("WriteDataOther");
            if (WriteDataOther)
            {
                FunctionCodeWrite = Convert.ToUInt64(xmlNode.GetChildAsString("FunctionCodeWrite"));
                RegisterStartAddressWrite = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterStartAddressWrite"));
                RegisterCountWrite = Convert.ToUInt64(xmlNode.GetChildAsString("RegisterCountWrite"));
            }

            try
            {
                if (xmlNode.SelectSingleNode("ListRegistersWriteData") is XmlNode listRegistersWriteDataNode)
                {
                    ListRegistersWriteData = new List<ProjectRegisterWriteData>();
                    foreach (XmlNode registerWriteDataNode in listRegistersWriteDataNode.SelectNodes("RegisterWriteData"))
                    {
                        ProjectRegisterWriteData registerWriteData = new ProjectRegisterWriteData();
                        registerWriteData.LoadFromXml(registerWriteDataNode);
                        ListRegistersWriteData.Add(registerWriteData);
                    }
                }
            }
            catch { }

            RegisterWriteData = HEX_STRING.HEXSTRING_TO_BYTEARRAY(xmlNode.GetChildAsString("RegisterWriteData"));
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
            xmlElem.AppendElem("Code", Code);
            xmlElem.AppendElem("Description", Description);
            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("Enabled", Enabled);

            xmlElem.AppendElem("FunctionCode", FunctionCode);
            xmlElem.AppendElem("RegisterStartAddress", RegisterStartAddress);
            xmlElem.AppendElem("RegisterCount", RegisterCount);

            xmlElem.AppendElem("WriteDataOther", WriteDataOther);
            if(WriteDataOther)
            {
                xmlElem.AppendElem("FunctionCodeWrite", FunctionCodeWrite);
                xmlElem.AppendElem("RegisterStartAddressWrite", RegisterStartAddressWrite);
                xmlElem.AppendElem("RegisterCountWrite", RegisterCountWrite);
            }

            try
            {
                XmlElement listRegistersElem = xmlElem.AppendElem("ListRegistersWriteData");
                foreach (ProjectRegisterWriteData register in ListRegistersWriteData)
                {
                    register.SaveToXml(listRegistersElem.AppendElem("RegistersWriteData"));
                }
            }
            catch { }

            xmlElem.AppendElem("RegisterWriteData", HEX_STRING.BYTEARRAY_TO_HEXSTRING(RegisterWriteData));
        }
        #endregion Save
    }
    #endregion ProjectCommand

}
