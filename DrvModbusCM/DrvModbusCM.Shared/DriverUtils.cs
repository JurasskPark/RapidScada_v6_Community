using Scada.Comm.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class DriverUtils
    {
        #region Basic
        /// <summary>
        /// The driver code.
        /// </summary>
        public const string DriverCode = "DrvModbusCM";

        /// <summary>
        /// The driver version.
        /// </summary>
        public const string Version = "6.4.0.0";

        /// <summary>
        /// The default filename of the configuration.
        /// </summary>
        public const string DefaultConfigFileName = DriverCode + ".xml";

        /// <summary>
        /// Gets the short name of the device configuration file.
        /// </summary>
        public static string GetFileName(int deviceNum = 0)
        {
            if (deviceNum == 0)
            {
                return $"{DriverCode}.xml";
            }
            else
            {
                return $"{DriverCode}_{deviceNum:D3}.xml";
            }
        }

        /// <summary>
        /// Gets the short name of the license file activation.
        /// </summary>
        public static string GetFileActivation(int deviceNum = 0)
        {
            return $"{DriverCode}_{deviceNum:D3}.bin";
        }

        /// <summary>
        /// Gets the short name of the device configuration file.
        /// </summary>
        public static string GetFileName()
        {
            return $"{DriverCode}.xml";
        }

        /// <summary>
        /// Application name.
        /// </summary>
        public static string Name(bool isRussian = false)
        {
            string text = isRussian ? "Взаимодействует с контроллерами по протоколу Modbus." : "Interacts with controllers via Modbus protocol.";
            return text;
        }

        /// <summary>
        /// Description of the application.
        /// </summary>
        public static string Description(bool isRussian = false)
        {
            string text = isRussian ?
                    "Преобразование текстовых файлов в данные SCADA." :
                    "Parsing text files to SCADA data.";
            return text;
        }

        /// <summary>
        /// Writes an configuration file depending on operating system.
        /// </summary>
        public static void WriteConfigFile(string fileName, bool windows)
        {
            string suffix = windows ? "Win" : "Linux";
            string resourceName = $"Scada.Comm.Drivers.DrvTextParserJP.Config.DrvTextParserJP.{suffix}.xml";
            string fileContents;

            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    fileContents = reader.ReadToEnd();
                }
            }

            File.WriteAllText(fileName, fileContents, Encoding.UTF8);
        }
        #endregion Basic

        #region Guid
        public static Guid StringToGuid(string id)
        {
            if (id == null || id.Length != 36)
            {
                return Guid.Empty;
            }
            if (reGuid.IsMatch(id))
            {
                return new Guid(id);
            }
            else
            {
                return Guid.Empty;
            }
        }

        public static bool IsGuid(string id)
        {
            if (id == null || id.Length != 36 || id.Equals("00000000-0000-0000-0000-000000000000"))
            {
                return false;
            }

            if (reGuid.IsMatch(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Regex reGuid = new Regex(@"^[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}$", RegexOptions.Compiled);

        #endregion Guid

        #region IP Address

        //Проверка валидности IP адреса
        public static bool IsIPAddress(string address)
        {
            //Инициализируем новый экземпляр класса System.Text.RegularExpressions.Regex
            //для указанного регулярного выражения.
            Regex IpMatch = new Regex(@"^([01]?\d\d?|2[0-4]\d|25[0-5])\.([01]?\d\d?|2[0-4]\d|25[0-5])\.([01]?\d\d?|2[0-4]\d|25[0-5])\.([01]?\d\d?|2[0-4]\d|25[0-5])$");
            //Выполняем проверку обнаружено ли в указанной входной строке соответствие регулярному
            //выражению, заданному в конструкторе System.Text.RegularExpressions.Regex.
            //если да то возвращаем true, если нет то false
            return IpMatch.IsMatch(address);
        }

        public static string IPAddressNoPort(string address)
        {
            //Если IP прошел на валидатность, то пингуем
            if (IsIPAddress(address) == true)
            {
                return address;
            }
            else if (IsIPAddress(address) == false) //Если IP не прошёл на валидатность, то попробуем удалить порт
            {
                //Парсим IP
                String[] IP = address.Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                //Перебираем что нам попало (Порт или IP)
                foreach (string addressTrue in IP)
                {
                    //Если попался IP, который истинный
                    if (IsIPAddress(addressTrue) == true)
                    {
                        return addressTrue;
                    }
                }
            }
            return null;
        }

        public static string PortNoIPAddress(string address)
        {
            //Если IP прошел на валидатность
            if (IsIPAddress(address) == true)
            {
                //Ничего не делаем
            }
            else if (IsIPAddress(address) == false) //Если IP не прошёл на валидатность, то попробуем удалить порт
            {
                //Парсим IP
                String[] IP = address.Split(new String[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                //Перебираем что нам попало (Порт или IP)
                foreach (string portTrue in IP)
                {
                    //Если попался IP, который истинный
                    if (IsIPAddress(portTrue) == true)
                    {
                        //Ничего не делаем
                    }
                    else
                    {
                        return portTrue;
                    }
                }
            }
            return null;
        }

        #endregion IP Address

        #region IsNullString

        public static string NullToString(object Value)
        {
            try
            {
                // check for null
                if (Value == null) return "";

                var type = Value.GetType();

                // check for invalid values in date times.
                if (type == typeof(DateTime))
                {
                    if (((DateTime)Value) == DateTime.MinValue)
                    {
                        return string.Empty;
                    }

                    var date = (DateTime)Value;

                    if (date.Millisecond > 0)
                    {
                        return date.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    }
                    else
                    {
                        return date.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                }

                // use only the local name for qualified names.
                if (type == typeof(XmlQualifiedName))
                {
                    return ((XmlQualifiedName)Value).Name;
                }

                // use only the name for system types.
                if (type.FullName == "System.RuntimeType")
                {
                    return ((Type)Value).FullName;
                }

                // treat byte arrays as a special case.
                if (type == typeof(byte[]))
                {
                    var bytes = (byte[])Value;

                    var buffer = new StringBuilder(bytes.Length * 3);

                    foreach (var character in bytes)
                    {
                        buffer.Append(character.ToString("X2"));
                        buffer.Append(".");
                    }

                    return buffer.ToString();
                }

                // show the element type and length for arrays.
                if (type.IsArray)
                {
                    string result = string.Empty;
                    int index = 0;
                    foreach (object element in (Array)Value)
                    {
                        result += String.Format("[{0}]", index++) + element.ToString() + Environment.NewLine;
                    }
                    return $"{type.GetElementType()?.Name}[{((Array)Value).Length}]{result}";
                }

                // instances of array are always treated as arrays of objects.
                if (type == typeof(Array))
                {
                    string result = string.Empty;
                    int index = 0;
                    foreach (object element in (Array)Value)
                    {
                        result += String.Format("[{0}]", index++) + element.ToString() + Environment.NewLine;
                    }
                    return $"Object[{((Array)Value).Length}]{result}";
                }

                // default behavior.
                return Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        #endregion IsNullString

        #region Сonverting Arrays

        public static ushort[] ConvertUlongToUshort(ulong[] array)
        {
            if (array == null)
            {
                return (ushort[])null;
            }

            ushort[] newArray = Array.ConvertAll(array, new Converter<ulong, ushort>(ulongToushort));
            return newArray;
        }

        public static ushort ulongToushort(ulong pf)
        {
            return Convert.ToUInt16(pf);
        }

        #endregion Сonverting Arrays

        #region Float String

        public static bool FloatAsTrue(string s)
        {
            s = FloatPuttingInOrder(s);
            if (s.LastIndexOf(".") != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static float FloatAsFloat(string s)
        {
            return float.Parse(FloatPuttingInOrder(s), CultureInfo.InvariantCulture);
        }

        public static int FloatToInteger(string s)
        {
            string[] parts = FloatPuttingInOrder(s).Split('.');
            return Convert.ToInt32(parts[0]);
        }

        public static int FloatToFractionalNumber(string s)
        {
            string[] parts = FloatPuttingInOrder(s).Split('.');
            if (parts.Length == 1)
            {
                return 0;
            }
            return Convert.ToInt32(parts[1]);
        }

        public static int FloatToFractionalNumber(string s, out int startBit, out int endBit, out int countBit)
        {
            startBit = 0;
            endBit = 0;
            countBit = 0;

            string[] parts = FloatPuttingInOrder(s).Split('.');
            if (parts.Length == 1)
            {
                return Convert.ToInt32(parts[0]);
            }
            string[] parts2 = parts[1].Split("-");
            if (parts2.Length == 1)
            {
                startBit = Convert.ToInt32(parts[1]);
                countBit = 1;
                return Convert.ToInt32(parts[0]);
            }
            startBit = Convert.ToInt32(parts2[0]);
            endBit = Convert.ToInt32(parts2[1]);
            countBit = endBit - startBit;
            return Convert.ToInt32(parts[0]);
        }

        private static string FloatPuttingInOrder(string s)
        {
            s = s.Replace(",", ".").Trim();
            return s;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct FloatUnion
        {
            [FieldOffset(0)]
            public float value;

            [FieldOffset(0)]
            public int binary;
        }

        public static bool IsNaN(float f)
        {
            FloatUnion union = new FloatUnion();
            union.value = f;

            return ((union.binary & 0x7F800000) == 0x7F800000) && ((union.binary & 0x007FFFFF) != 0);
        }

        #endregion Float String
     
        #region Double String

        public static double DoubleAsDouble(string s)
        {
            try
            {
                return double.Parse(DoublePuttingInOrder(s), CultureInfo.InvariantCulture);
            }
            catch
            {
                return double.NaN;
            }
        }

        private static string DoublePuttingInOrder(string s)
        {
            s = s.Replace(",", ".").Trim();
            return s;
        }

        #endregion Double String

        #region Exception Error
        public static string InfoError(Exception ex)
        {
            string errMsg = string.Empty;
            // Get stack trace for the exception with source file information
            var st = new StackTrace(ex, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();
            return errMsg = $"[ERROR] = " + ex.Message + Environment.NewLine +
                "[ST] = " + DriverUtils.NullToString(st) + Environment.NewLine +
                "[FRAME] = " + DriverUtils.NullToString(frame) + Environment.NewLine +
                "[LINE] = " + DriverUtils.NullToString(line);
        }

        #endregion Exception Error
    }
}
