using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_BIT
    {
        #region HEXSTRING

        public static string HEXSTRING_TO_STRINGBIN(string value)
        {
            try
            {
                string result = string.Empty;
                byte[] bytes = HEX_STRING.HEXSTRING_TO_BYTEARRAY(value);

                for (int i = 0; i < bytes.Length; i++)
                {
                    int num = bytes[i];

                    for (int j = 7; j >= 0; j--)
                    {
                        if ((num & (1 << j)) != 0)
                        {
                            result += '1';
                        }
                        else
                        {
                            result += '0';
                        }
                    }
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        #endregion HEXSTRING

        #region HEXARRAY

        public static string HEXARRAY_TO_STRINGBIN(byte[] bytes)
        {
            try
            {
                string result = string.Empty;

                for (int i = 0; i < bytes.Length; i++)
                {
                    int num = bytes[i];

                    for (int j = 7; j >= 0; j--)
                    {
                        if ((num & (1 << j)) != 0)
                        {
                            result += '1';
                        }
                        else
                        {
                            result += '0';
                        }
                    }
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static int HEXARRAY_TO_INT_BIT(byte[] bytes, int index)
        {
            try
            {
                int value = 0;
                string result = string.Empty;

                for (int i = 0; i < bytes.Length; i++)
                {
                    int num = bytes[i];

                    for (int j = 7; j >= 0; j--)
                    {
                        if ((num & (1 << j)) != 0)
                        {
                            result += '1';
                        }
                        else
                        {
                            result += '0';
                        }
                    }
                }

                char[] charArr = result.ToCharArray();
                Array.Reverse(charArr);
                string bit = charArr[index].ToString();

                value = Convert.ToInt32(bit);
                return value;
            }
            catch
            {
                return 0;
            }
        }

        public static int HEXARRAY_TO_INT_BIT(byte[] bytes, int index, int lenght)
        {
            try
            {
                int value = 0;
                string result = string.Empty;

                for (int i = 0; i < bytes.Length; i++)
                {
                    int num = bytes[i];

                    for (int j = 7; j >= 0; j--)
                    {
                        if ((num & (1 << j)) != 0)
                        {
                            result += '1';
                        }
                        else
                        {
                            result += '0';
                        }
                    }
                }

                char[] charArr = result.ToCharArray();
                Array.Reverse(charArr);

                string bit = string.Empty;
                for (int i = index; i <= index + lenght; i++)
                {
                    bit += charArr[i];
                }

                char[] charArrReverse = bit.ToCharArray();
                Array.Reverse(charArrReverse);
                bit = new string(charArrReverse);
                value = Convert.ToInt32(bit, 2);
                return value;
            }
            catch
            {
                return 0;
            }
        }

        #endregion HEXARRAY

        #region BYTE

        public static string BYTE_TO_STRINGBIN(byte value)
        {
            string result = string.Empty;

            for (int j = 7; j >= 0; j--)
            {
                if (((int)value & (1 << j)) != 0)
                {
                    result += '1';
                }
                else
                {
                    result += '0';
                }

            }
            return result;
        }

        #endregion BYTE








    }
}
