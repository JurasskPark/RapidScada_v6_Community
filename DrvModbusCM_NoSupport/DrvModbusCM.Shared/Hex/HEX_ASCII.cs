using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_ASCII
    {
        /// <summary>
        /// Преобразовываем строку в массив байтов в кодировке ASCII. 
        /// </summary>
        /// <param name="str_Data">Строка</param>
        /// <returns>Возвращает массив байтов в кодировке ASCII.</returns>
        public static byte[] HEXSTRING_TO_BYTEARRAY(string str_Data)
        {
            return Encoding.ASCII.GetBytes(str_Data);
        }

        public static byte[] BYTEARRAY_TO_ASCIIBYTEARRAY(byte[] bytes_Data)
        {
            return Encoding.ASCII.GetBytes(HEX_STRING.BYTEARRAY_TO_HEXSTRING(bytes_Data).Replace(".", ""));
        }

        public static byte[] ASCIIBYTEARRAY_TO_BYTEARRAY(byte[] bytes)
        {
            byte[] numArray = (byte[])null;
            string result_text = string.Empty;
            string str_symbol = string.Empty;

            string tmp_string_1 = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bytes).Replace(".", "");
            string tmp_string_2 = tmp_string_1.Substring(0, tmp_string_1.Length - 4);
            string tmp_string_3 = tmp_string_2.Substring(2);

            byte[] tmp_numArray = HEX_STRING.HEXSTRING_TO_BYTEARRAY(tmp_string_3);

            ASCIIEncoding ascii = new ASCIIEncoding();
            string win1251 = Encoding.GetEncoding(1251).GetString(Enumerable.Range(0, 256).Select(n => (byte)n).ToArray());

            foreach (byte value in tmp_numArray)
            {
                try
                {
                    int chislo = Convert.ToInt32(value);
                    result_text += win1251[chislo].ToString();
                }
                catch { }
            }

            string itog = "3A" + result_text + "0D0A";
            numArray = HEX_STRING.HEXSTRING_TO_BYTEARRAY(itog);

            return numArray;
        }

        public static string ASCIIBYTEARRAY_TO_STRING(byte[] bytes, bool code)
        {
            string result_text = string.Empty;
            string str_symbol = string.Empty;
            ASCIIEncoding ascii = new ASCIIEncoding();
            string win1251 = Encoding.GetEncoding(1251).GetString(Enumerable.Range(0, 256).Select(n => (byte)n).ToArray());

            if (code == false)
            {
                foreach (byte value in bytes)
                {
                    if (value == 0x00) { str_symbol += ""; }
                    else if (value == 0x01) { str_symbol += ""; }
                    else if (value == 0x02) { str_symbol += ""; }
                    else if (value == 0x03) { str_symbol += ""; }
                    else if (value == 0x04) { str_symbol += ""; }
                    else if (value == 0x05) { str_symbol += ""; }
                    else if (value == 0x06) { str_symbol += ""; }
                    else if (value == 0x07) { str_symbol += ""; }
                    else if (value == 0x08) { str_symbol += ""; }
                    else if (value == 0x09) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x0A) { str_symbol += ""; }
                    else if (value == 0x0B) { str_symbol += ""; }
                    else if (value == 0x0C) { str_symbol += ""; }
                    else if (value == 0x0D) { str_symbol += ""; }
                    else if (value == 0x0E) { str_symbol += ""; }
                    else if (value == 0x0F) { str_symbol += ""; }
                    else if (value == 0x10) { str_symbol += ""; }
                    else if (value == 0x11) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x12) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x13) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x14) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x15) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x16) { str_symbol += ""; }
                    else if (value == 0x17) { str_symbol += ""; }
                    else if (value == 0x18) { str_symbol += ""; }
                    else if (value == 0x19) { str_symbol += ""; }
                    else if (value == 0x1A) { str_symbol += ""; }
                    else if (value == 0x1B) { str_symbol += ""; }
                    else if (value == 0x1C) { str_symbol += ""; }
                    else if (value == 0x1D) { str_symbol += ""; }
                    else if (value == 0x1E) { str_symbol += ""; }
                    else if (value == 0x1F) { str_symbol += ""; }
                    else if (value == 0x20) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x2B) { str_symbol += ""; }
                    else if (value == 0x3A) { str_symbol += ""; result_text += str_symbol; }

                    else
                    {
                        try
                        {
                            int chislo = Convert.ToInt32(value);
                            result_text += win1251[chislo].ToString();
                        }
                        catch { }
                    }
                }
            }
            else if (code == true)
            {
                foreach (byte value in bytes)
                {
                    if (value == 0x00) { str_symbol += "[NUL]"; result_text += str_symbol; }
                    else if (value == 0x01) { str_symbol += "[SOH]"; result_text += str_symbol; }
                    else if (value == 0x02) { str_symbol += "[STX]"; result_text += str_symbol; }
                    else if (value == 0x03) { str_symbol += "[ETX]"; result_text += str_symbol; }
                    else if (value == 0x04) { str_symbol += "[EOT]"; result_text += str_symbol; }
                    else if (value == 0x05) { str_symbol += "[ENQ]"; result_text += str_symbol; }
                    else if (value == 0x06) { str_symbol += "[ACK]"; result_text += str_symbol; }
                    else if (value == 0x07) { str_symbol += "[BEL]"; result_text += str_symbol; }
                    else if (value == 0x08) { str_symbol += "[BS]"; result_text += str_symbol; }
                    else if (value == 0x09) { str_symbol += "[TAB]"; result_text += str_symbol; }
                    else if (value == 0x0A) { str_symbol += "[LF]"; result_text += str_symbol; }
                    else if (value == 0x0B) { str_symbol += "[VT]"; result_text += str_symbol; }
                    else if (value == 0x0C) { str_symbol += "[FF]"; result_text += str_symbol; }
                    else if (value == 0x0D) { str_symbol += "[CR]"; result_text += str_symbol; }
                    else if (value == 0x0E) { str_symbol += "[SO]"; result_text += str_symbol; }
                    else if (value == 0x0F) { str_symbol += "[SI]"; result_text += str_symbol; }
                    else if (value == 0x10) { str_symbol += "[DLE]"; result_text += str_symbol; }
                    else if (value == 0x11) { str_symbol += "[DC1]"; result_text += str_symbol; }
                    else if (value == 0x12) { str_symbol += "[DC2]"; result_text += str_symbol; }
                    else if (value == 0x13) { str_symbol += "[DC3]"; result_text += str_symbol; }
                    else if (value == 0x14) { str_symbol += "[DC4]"; result_text += str_symbol; }
                    else if (value == 0x15) { str_symbol += "[NAK]"; result_text += str_symbol; }
                    else if (value == 0x16) { str_symbol += "[SYN]"; result_text += str_symbol; }
                    else if (value == 0x17) { str_symbol += "[ETB]"; result_text += str_symbol; }
                    else if (value == 0x18) { str_symbol += "[CAN]"; result_text += str_symbol; }
                    else if (value == 0x19) { str_symbol += "[EM]"; result_text += str_symbol; }
                    else if (value == 0x1A) { str_symbol += "[SUB]"; result_text += str_symbol; }
                    else if (value == 0x1B) { str_symbol += "[ESC]"; result_text += str_symbol; }
                    else if (value == 0x1C) { str_symbol += "[FS]"; result_text += str_symbol; }
                    else if (value == 0x1D) { str_symbol += "[GS]"; result_text += str_symbol; }
                    else if (value == 0x1E) { str_symbol += "[RS]"; result_text += str_symbol; }
                    else if (value == 0x1F) { str_symbol += "[US]"; result_text += str_symbol; }
                    else if (value == 0x20) { str_symbol += " "; result_text += str_symbol; }
                    else if (value == 0x7F) { str_symbol += "[DEL]"; result_text += str_symbol; }
                    else
                    {
                        try
                        {
                            int chislo = Convert.ToInt32(value);
                            result_text += win1251[chislo].ToString();
                        }
                        catch { }
                    }
                }
            }

            result_text = result_text.Replace("  ", " ");
            return result_text;
        }
    }
}
