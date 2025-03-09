using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_STRING
    {
        /// <summary> Преобразовываем строку из шестнадцатеричных цифр (например: E4 CA B2) в массив байтов. </summary>
        /// <param name="str_Data"> Строка, содержащая шестнадцатеричные цифры (с или без точек). </param>
        /// <returns> Возвращает массив байтов. </returns>
        public static byte[] HEXSTRING_TO_BYTEARRAY(string str_Data)
        {
            try
            {
                str_Data = str_Data.Replace(".", string.Empty).Replace(",", string.Empty).Replace(":", string.Empty).Replace(";", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty);
                var buffer = new List<byte>();
                for (int i = str_Data.Length - 1; i >= 0; i -= 2)
                {
                    if (i > 0)
                    {
                        buffer.Insert(0, Convert.ToByte(str_Data.Substring(i - 1, 2), 16));
                    }
                    else
                    {
                        buffer.Insert(0, Convert.ToByte(str_Data.Substring(i, 1), 16));
                    }
                }
                return buffer.ToArray();
            }
            catch
            {
                return (byte[])null;
            }
        }


        /// <summary> Преобразует массив байтов в отформатированную строку из шестнадцатеричных цифр (например: E4 CA B2)</summary>
        /// <param name="bytes_Data"> Массив байтов для перевода в строку шестнадцатеричных цифр. </param>
        /// <returns> Возвращает хорошо форматированную строку из шестнадцатеричных цифр с точками. </returns>
        public static string BYTEARRAY_TO_HEXSTRING(byte[] bytes_Data)
        {
            try
            {
                if (bytes_Data == null)
                {
                    return string.Empty;
                }

                StringBuilder sb = new StringBuilder(bytes_Data.Length * 3);
                foreach (byte b in bytes_Data)
                {
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, '.'));
                }
                return sb.ToString().ToUpper();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string BYTEARRAY_TO_HEXSTRINGFORMAT(byte[] bytes_Data)
        {
            try
            {
                if (bytes_Data == null)
                {
                    return string.Empty;
                }

                string result = string.Join(", ", bytes_Data.Select(item => "0x" + item.ToString("x2")));
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static byte[] HEXSTRINGFORMAT_TO_BYTEARRAY(string str_Data)
        {
            try
            {
                byte[] result = str_Data.Split(new char[] { ' ', ':', '.', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(item => Convert.ToByte(item, 16)).ToArray();
                return result;
            }
            catch
            {
                return (byte[])null;
            }
        }

        public static string HEXSTRING_TO_HEXSTRINGFORMAT(string str_Data)
        {
            try
            {
                byte[] bytes_Data = str_Data.Split(new char[] { ' ', ':', '.', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(item => Convert.ToByte(item, 16)).ToArray();
                string result = string.Join(", ", bytes_Data.Select(item => "0x" + item.ToString("x2")));
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string HEXSTRING_TO_CHAR(byte[] bytes_Data)
        {
            try
            {
                string result = string.Empty;
                foreach (byte hex in bytes_Data)
                {
                    // Convert the number expressed in base-16 to an integer.
                    int value = Convert.ToInt32(hex);
                    // Get the character corresponding to the integral value.
                    string stringValue = Char.ConvertFromUtf32(value);
                    char charValue = (char)value;
                    //Console.WriteLine("hexadecimal value = {0}, int value = {1}, char value = {2} or {3}", hex, value, stringValue, charValue);
                    result += charValue;
                }
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}