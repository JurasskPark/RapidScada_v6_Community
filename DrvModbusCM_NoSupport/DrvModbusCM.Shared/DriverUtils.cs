using Scada.Comm.Devices;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class DriverUtils
    {
        #region General
        /// <summary>
        /// The driver code.
        /// </summary>
        public const string DriverCode = "DrvModbusCMU";

        /// <summary>
        /// The default filename of the configuration.
        /// </summary>
        public const string DefaultConfigFileName = DriverCode + ".xml";

        /// <summary>
        /// Gets the short name of the device configuration file.
        /// </summary>
        public static string GetFileName(int deviceNum)
        {
            return DeviceConfigBase.GetFileName(DriverUtils.DriverCode, deviceNum);
        }

        /// <summary>
        /// Gets the path of the device configuration file.
        /// </summary>
        /// <param name="deviceNum">Device number</param>
        /// <returns></returns>
        public static string GetDirPathName(int deviceNum) 
        {
            return DeviceConfigBase.GetFileName(DriverUtils.DriverCode, deviceNum); 
        }
        #endregion General

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
            // Value.ToString() allows for Value being DBNull, but will also convert int, double, etc.
            return Value == null ? "" : Value.ToString();

            // If this is not what you want then this form may suit you better, handles 'Null' and DBNull otherwise tries a straight cast
            // which will throw if Value isn't actually a string object.
            //return Value == null || Value == DBNull.Value ? "" : (string)Value;
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

        #endregion Float String
    }
}
