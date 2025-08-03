using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{

    #region ProjectTag
    [Serializable]
    public class ProjectTag
    {
        public ProjectTag()
        {
            ID = new Guid();
            ParentID = new Guid();
            CommandID = new Guid();
            KeyImage = string.Empty;

            Name = string.Empty;
            Description = string.Empty;
            Code = string.Empty;
            Address = string.Empty;
            Format = FormatData.NONE;
            Sorting = string.Empty;

            Enabled = true;

            Scaled = FormatScaled.NONE;
            Coefficient = 1d;
            ScaledHigh = 0;
            ScaledLow = 0;
            RowHigh = 0;
            RowLow = 0;
        }

        #region Variables

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

        //ID команды
        private Guid commandID;
        [XmlAttribute]
        public Guid CommandID
        {
            get { return commandID; }
            set { commandID = value; }
        }

        //Иконка
        private string keyImage;
        [XmlAttribute]
        public string KeyImage
        {
            get { return keyImage; }
            set { keyImage = value; }
        }

        private string name;
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        [XmlAttribute]
        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        private string code;
        [XmlAttribute]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string address;
        [XmlAttribute]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private FormatData format;
        [XmlIgnore]
        public FormatData Format
        {
            set { format = value; }
            get { return format; }
        }

        private bool enabled;
        [XmlAttribute]
        public bool Enabled
        {
            set { enabled = value; }
            get { return enabled; }
        }

        private string sorting;
        [XmlAttribute]
        public string Sorting
        {
            set { sorting = value; }
            get { return sorting; }
        }

        private byte[] data;
        [XmlAttribute]
        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }

        private object dataValue;
        [XmlIgnore]
        public object DataValue
        {
            set { dataValue = value; }
            get { return dataValue; }
        }

        private DateTime tagDateTime;
        [XmlAttribute]
        public DateTime TagDateTime
        {
            set { tagDateTime = value; }
            get { return tagDateTime; }
        }

        private ushort quality;
        [XmlAttribute]
        public ushort Quality
        {
            set { quality = value; }
            get { return quality; }
        }

        private double coefficient;
        [XmlAttribute]
        public double Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

        private FormatScaled scaled;
        [XmlAttribute]
        public FormatScaled Scaled
        {
            set { scaled = value; }
            get { return scaled; }
        }

        private double scaledHigh;
        [XmlAttribute]
        public double ScaledHigh
        {
            get { return scaledHigh; }
            set { scaledHigh = value; }
        }

        private double scaledLow;
        [XmlAttribute]
        public double ScaledLow
        {
            get { return scaledLow; }
            set { scaledLow = value; }
        }

        private double rowHigh;
        [XmlAttribute]
        public double RowHigh
        {
            get { return rowHigh; }
            set { rowHigh = value; }
        }

        private double rowLow;
        [XmlAttribute]
        public double RowLow
        {
            get { return rowLow; }
            set { rowLow = value; }
        }

        public enum FormatData : int
        {
            NONE = 0,
            BIT,
            BIT32,
            BIT64,
            BOOL,
            BYTE,
            DATETIME4,
            DATETIME6,
            DATETIME8,
            DOUBLE,
            FLOAT,
            HEX,
            INT,
            INT_HI,
            INT_LO,
            LONG,
            SBYTE,
            SHORT,
            UINT,
            ULONG,
            USHORT,
        }

        public enum FormatScaled : int
        {
            NONE = 0,
            LINEAR = 1,
        }

        #endregion #region Variables

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
            ParentID = DriverUtils.StringToGuid(xmlNode.GetChildAsString("ParentID"));
            CommandID = DriverUtils.StringToGuid(xmlNode.GetChildAsString("CommandID"));

            Name = xmlNode.GetChildAsString("Name");
            Description = xmlNode.GetChildAsString("Description");
            KeyImage = xmlNode.GetChildAsString("KeyImage");
            Enabled = xmlNode.GetChildAsBool("Enabled");

            Code = xmlNode.GetChildAsString("Code");
            Address = xmlNode.GetChildAsString("Address");
            Format = (FormatData)Enum.Parse(typeof(FormatData), xmlNode.GetChildAsString("Format"));
            Sorting = xmlNode.GetChildAsString("Sorting");

            Scaled = (FormatScaled)Enum.Parse(typeof(FormatScaled), xmlNode.GetChildAsString("Scaled"));
            Coefficient = xmlNode.GetChildAsDouble("Coefficient");
            ScaledHigh = xmlNode.GetChildAsDouble("ScaledHigh");
            ScaledLow = xmlNode.GetChildAsDouble("ScaledLow");
            RowHigh = xmlNode.GetChildAsDouble("RowHigh");
            RowLow = xmlNode.GetChildAsDouble("RowLow");

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
            xmlElem.AppendElem("ParentID", ParentID.ToString());
            xmlElem.AppendElem("CommandID", CommandID.ToString());

            xmlElem.AppendElem("Name", Name);
            xmlElem.AppendElem("Description", Description);
            xmlElem.AppendElem("KeyImage", KeyImage);
            xmlElem.AppendElem("Enabled", Enabled);

            xmlElem.AppendElem("Code", Code);
            xmlElem.AppendElem("Address", Address);
            xmlElem.AppendElem("Format", Enum.GetName(typeof(FormatData), Format));
            xmlElem.AppendElem("Sorting", Sorting);

            xmlElem.AppendElem("Scaled", Enum.GetName(typeof(FormatScaled), Scaled));
            xmlElem.AppendElem("Coefficient", Coefficient);
            xmlElem.AppendElem("ScaledHigh", ScaledHigh);
            xmlElem.AppendElem("ScaledLow", ScaledLow);
            xmlElem.AppendElem("RowHigh", RowHigh);
            xmlElem.AppendElem("RowLow", RowLow);
        }
        #endregion Save

        #region Action
        public static int FormatDataRegisterCount(ProjectTag tag, int deviceRegistersBytes = 2)
        {
            int count = 0;
            FormatData format = (FormatData)Enum.Parse(typeof(FormatData), tag.Format.ToString());
            int startBit = 0;
            int endBit = 0;
            int countBit = 0;
            int address = DriverUtils.FloatToFractionalNumber(tag.address, out startBit, out endBit, out countBit);

            switch (format)
            {
                case ProjectTag.FormatData.BIT:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.BIT32:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 4;
                        case 2: return 2;
                        case 3: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.BIT64:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.BYTE:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.DATETIME4:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 6;
                        case 2: return 3;
                        case 3: return 2;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.DOUBLE:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.FLOAT:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 4;
                        case 2: return 2;
                        case 3: return 2;
                        case 4: return 1;
                    }

                    break;
                case ProjectTag.FormatData.HEX:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.INT:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.INT_HI:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.INT_LO:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.LONG:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.SBYTE:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.SHORT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 1;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.UINT:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 2;
                        case 4: return 1;
                    }
                    break;
                case ProjectTag.FormatData.ULONG:
                    switch (deviceRegistersBytes)
                    {
                        case 2: return 4;
                        case 4: return 2;
                    }
                    break;
                case ProjectTag.FormatData.USHORT:
                    switch (deviceRegistersBytes)
                    {
                        case 1: return 1;
                        case 2: return 1;
                        case 3: return 1;
                        case 4: return 1;
                    }
                    break;
            }
            return count;
        }

        public static object GetValue(ProjectTag tag, byte[] bytes)
        {
            object value = new object();
            FormatData format = tag.Format;
            int startBit = 0;
            int endBit = 0;
            int countBit = 0;
            int address = DriverUtils.FloatToFractionalNumber(tag.address, out startBit, out endBit, out countBit);
            byte[] buffer = new byte[bytes.Length];

            if(tag.Sorting != string.Empty)
            {
                try
                {
                    ApplyByteOrder(bytes, buffer, ParseByteOrder(tag.Sorting));
                    bytes = buffer;
                }
                catch { }
            }

            switch (format)
            {
                case ProjectTag.FormatData.BIT:
                    if (countBit == 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_STRINGBIN(bytes);
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit);
                    }
                    else if (endBit > 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit, countBit);
                    }
                    break;
                case ProjectTag.FormatData.BIT32:
                    if (countBit == 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_STRINGBIN(bytes);
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit);
                    }
                    else if (endBit > 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit, countBit);
                    }
                    break;
                case ProjectTag.FormatData.BIT64:
                    if (countBit == 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_STRINGBIN(bytes);
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit);
                    }
                    else if (endBit > 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit, countBit);
                    }
                    break;
                case ProjectTag.FormatData.BYTE:
                    sbyte[] byteValue = Array.ConvertAll(bytes, b => unchecked((sbyte)b));
                    value = byteValue[0];
                    break;
                case ProjectTag.FormatData.DATETIME6:
                    if (bytes.Length == 6)
                    {
                        value = HEX_DATETIME.DateTimeFromByteArray6(bytes);
                    }
                    break;
                case ProjectTag.FormatData.DATETIME8:
                    if (bytes.Length == 8)
                    {
                        value = HEX_DATETIME.DateTimeFromByteArray8(bytes);
                    }
                    break;
                case ProjectTag.FormatData.DOUBLE:
                    value = BitConverter.ToDouble(bytes, 0);
                    break;
                case ProjectTag.FormatData.FLOAT:
                    if (countBit == 0)
                    {
                        value = BitConverter.ToSingle(bytes, 0);
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit);
                    }
                    else if (endBit > 0 && countBit > 0)
                    {
                        value = HEX_BIT.HEXARRAY_TO_INT_BIT(bytes, startBit, countBit);
                    }
                    break;
                case ProjectTag.FormatData.HEX:
                    if (countBit == 0)
                    {
                        value = BitConverter.ToString(bytes, 0).ToString().Replace("-", "");
                    }
                    else if (endBit == 0 && countBit > 0)
                    {
                        byte[] tmpByte = new byte[2];
                        if (bytes.Length - 1 <= startBit)
                        {
                            tmpByte[0] = bytes[0];
                            tmpByte[1] = bytes[1];
                        }
                        else
                        {
                            tmpByte[0] = bytes[bytes.Length - 2 - startBit];
                            tmpByte[1] = bytes[bytes.Length - 1 - startBit];
                        }
                        value = BitConverter.ToString(tmpByte, 0).ToString().Replace("-", "");
                    }
                    break;
                case ProjectTag.FormatData.INT:
                    value = HEX_INT.FromByteArray(bytes);
                    break;
                case ProjectTag.FormatData.INT_HI:
                    value = HEX_INT.FromByteArrayHI(bytes);
                    break;
                case ProjectTag.FormatData.INT_LO:
                    value = HEX_INT.FromByteArrayLO(bytes);
                    break;
                case ProjectTag.FormatData.LONG:
                    value = BitConverter.ToInt64(bytes, 0);
                    break;
                case ProjectTag.FormatData.SBYTE:
                    sbyte[] sbyteValue = Array.ConvertAll(bytes, b => unchecked((sbyte)b));
                    value = sbyteValue[0];
                    break;
                case ProjectTag.FormatData.SHORT:
                    value = BitConverter.ToInt16(bytes, 0);
                    break;
                case ProjectTag.FormatData.UINT:
                    value = BitConverter.ToUInt32(bytes, 0);
                    break;
                case ProjectTag.FormatData.ULONG:
                    value = BitConverter.ToUInt64(bytes, 0);
                    break;
                case ProjectTag.FormatData.USHORT:
                    value = BitConverter.ToUInt16(bytes, 0);
                    break;
            }

            if (value is string strVal || value is byte[] byteVal || value is DateTime dtmVal)
            {
                return value;
            }

            try
            {
                value = tag.Coefficient * Convert.ToDouble(value);
            }
            catch
            {
                value = "<bad>";
            }

            try
            {
                if (tag.Scaled == FormatScaled.LINEAR)
                {
                    value = (((tag.ScaledHigh - tag.ScaledLow) / (tag.RowHigh - tag.RowLow)) * (Convert.ToSingle(value) - tag.RowLow)) + tag.ScaledLow;
                }
            }
            catch
            {
                value = "<bad>";
            }

            return value;
        }

        public static byte[] GetBytes(ProjectTag tag, object value)
        {
            if(value == null)
            {
                return new byte[0];
            }

            byte[] bytes = new byte[0];
            FormatData format = tag.Format;
            int startBit = 0;
            int endBit = 0;
            int countBit = 0;
            int address = DriverUtils.FloatToFractionalNumber(tag.address, out startBit, out endBit, out countBit);
            byte[] buffer = new byte[bytes.Length];

            switch (format)
            {
                case ProjectTag.FormatData.BIT:
                    bytes = BitConverter.GetBytes((bool)value);
                    break;
                case ProjectTag.FormatData.BIT32:
                    
                    break;
                case ProjectTag.FormatData.BIT64:
                    
                    break;
                case ProjectTag.FormatData.BOOL:
                    bytes = HEX_BOOLEAN.ToRegister((bool)value);
                    break;
                case ProjectTag.FormatData.BYTE:
                    
                    break;
                case ProjectTag.FormatData.DATETIME6:
                    
                    break;
                case ProjectTag.FormatData.DATETIME8:
                    
                    break;
                case ProjectTag.FormatData.DOUBLE:
                    bytes = BitConverter.GetBytes((double)value);
                    break;
                case ProjectTag.FormatData.FLOAT:
                    bytes = BitConverter.GetBytes((float)value);
                    break;
                case ProjectTag.FormatData.HEX:
                    
                    break;
                case ProjectTag.FormatData.INT:
                    bytes = BitConverter.GetBytes((int)value);
                    break;
                case ProjectTag.FormatData.INT_HI:
                    
                    break;
                case ProjectTag.FormatData.INT_LO:
                    
                    break;
                case ProjectTag.FormatData.LONG:
                    bytes = BitConverter.GetBytes((long)value);
                    break;
                case ProjectTag.FormatData.SBYTE:
                    
                    break;
                case ProjectTag.FormatData.SHORT:
                    bytes = BitConverter.GetBytes((short)value);
                    break;
                case ProjectTag.FormatData.UINT:
                    bytes = BitConverter.GetBytes((uint)value);
                    break;
                case ProjectTag.FormatData.ULONG:
                    bytes = BitConverter.GetBytes((ulong)value);
                    break;
                case ProjectTag.FormatData.USHORT:
                    bytes = BitConverter.GetBytes((ushort)value);
                    break;
            }

            if (tag.Sorting != string.Empty)
            {
                try
                {
                    ApplyByteOrder(bytes, buffer, ParseByteOrder(tag.Sorting));
                    bytes = buffer;
                }
                catch { }
            }

            return bytes;
        }

        public static bool IsObjectEmpty(object obj)
        {
            var properties = obj.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);
                if (value != null &&
                    !(value is string str && string.IsNullOrEmpty(str)))
                {
                    return false;
                }
            }
            return true;
        }

        public static ProjectTag ConvertRegisterToTag(ProjectRegisterWriteData register)
        {
            ProjectTag tag = new ProjectTag();
            tag.ID = Guid.NewGuid();
            tag.Address = register.RegAddr.ToString();
            tag.Name = register.RegName;
            tag.Description = register.RegDescription;
            tag.DataValue = register.RegValue;
            tag.Data = register.RegData;
            tag.Format = register.RegFormat;
            tag.Sorting = register.Sorting;
            return tag;
        }

        /// <summary>
        /// Parses a byte order array from the string notation like '0123456789ABCDEF'.
        /// </summary>
        public static int[] ParseByteOrder(string byteOrderStr)
        {
            if (string.IsNullOrEmpty(byteOrderStr))
            {
                return null;
            }
            else
            {
                int len = byteOrderStr.Length;
                int[] byteOrder = new int[len];

                for (int i = 0; i < len; i++)
                {
                    byteOrder[i] = int.TryParse(byteOrderStr[i].ToString(), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int n) ? n : 0;
                }

                return byteOrder;
            }
        }

        /// <summary>
        /// Copies the array elements in the specified byte order.
        /// </summary>
        public static void ApplyByteOrder(byte[] src, byte[] dest, int[] byteOrder)
        {
            ApplyByteOrder(src, 0, dest, 0, dest.Length, byteOrder, false);
        }

        /// <summary>
        /// Copies the array elements in the specified byte order.
        /// </summary>
        public static void ApplyByteOrder(byte[] src, int srcOffset, byte[] dest, int destOffset, int count,
            int[] byteOrder, bool reverse)
        {
            int srcLen = src == null ? 0 : src.Length;
            int endSrcInd = srcOffset + count - 1;
            int ordLen = byteOrder == null ? 0 : byteOrder.Length;

            if (byteOrder == null)
            {
                // copy data without byte order
                for (int i = 0; i < count; i++)
                {
                    int srcInd = reverse ? endSrcInd - i : srcOffset + i;
                    dest[destOffset++] = 0 <= srcInd && srcInd < srcLen ? src[srcInd] : (byte)0;
                }
            }
            else
            {
                // copy data with byte order
                for (int i = 0; i < count; i++)
                {
                    int srcInd = i < ordLen ? (reverse ? endSrcInd - byteOrder[i] : srcOffset + byteOrder[i]) : -1;
                    dest[destOffset++] = 0 <= srcInd && srcInd < srcLen ? src[srcInd] : (byte)0;
                }
            }
        }



        #region Scaled

        public static double CalcLineScaled(string Value, float DeviceTagCoefficient, int Scaled, double ScaledHigh, double ScaledLow, double RowHigh, double RowLow)
        {
            try
            {
                double ScaledValue = DriverUtils.DoubleAsDouble(Value);
                if (DriverUtils.DoubleIsNaN(ScaledValue))
                {
                    return ScaledValue;
                }
                if (Scaled == 0 && DeviceTagCoefficient == 1f)
                {
                    return ScaledValue;
                }
                else if (Scaled == 0 && DeviceTagCoefficient != 1f)
                {
                    ScaledValue = ScaledValue * DeviceTagCoefficient;
                    return ScaledValue;
                }
                else if (Scaled == 1)
                {
                    double Result = (((ScaledHigh - ScaledLow) / (RowHigh - RowLow)) * (ScaledValue - RowLow)) + ScaledLow;
                    Result = Result * DeviceTagCoefficient;
                    return Result;
                }

                return double.NaN;
            }
            catch
            {
                return double.NaN;
            }
        }

        #endregion Scaled

        #region Качество

        //OPC_QUALITY_BAD = 0; //Значение плохое, но конкретная причина неизвестна
        //OPC_QUALITY_CONFIG_ERROR = 4; //Существует специфическая для сервера проблема с конфигурацией
        //OPC_QUALITY_NOT_CONNECTED = 8; //Вход должен быть логически связан с чем-то, но не является
        //OPC_QUALITY_DEVICE_FAILURE = 12; //Обнаружен сбой устройства
        //OPC_QUALITY_SENSOR_FAILURE = 16; //Обнаружен сбой датчика
        //OPC_QUALITY_LAST_KNOWN = 20; //Связь прервалась. Однако доступно последнее известное значение.
        //OPC_QUALITY_COMM_FAILURE = 24; //Связь прервалась. Последнее известное значение недоступно.
        //OPC_QUALITY_OUT_OF_SERVICE = 28; //Блок отключен от сканирования или иным образом заблокирован.
        //OPC_QUALITY_SENSOR_CAL = 32; //Либо значение достигло одного из пределов датчика (в этом случае поле предела должно быть установлено равным 1 или 2), либо в противном случае известно, что датчик не откалиброван.
        //OPC_QUALITY_UNCERTAIN = 64; //Нет никакой конкретной причины, по которой значение является неопределенным.
        //OPC_QUALITY_LAST_USABLE = 68; //Последнее полезное значение
        //OPC_QUALITY_EGU_EXCEEDED = 84; //Возвращаемое значение выходит за пределы, определенные для этого параметра. Обратите внимание, что в этом случае флаг ограничения указывает, какой предел был превышен.
        //OPC_QUALITY_SUB_NORMAL = 88; //Значение получено из нескольких источников и содержит меньше требуемого количества хороших источников.
        //OPC_QUALITY_GOOD = 192; //Качество хорошая
        //OPC_QUALITY_LOCAL_OVERRIDE = 216; //Значение было переопределено. Как правило, это означает, что вход был отключен и заданное вручную значение было принудительно введено.

        #endregion Качество

        #endregion Action

    }

    #endregion ProjectTag


}
