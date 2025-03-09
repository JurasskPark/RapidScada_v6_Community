using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_FLOAT
    {

        public static float FromByteArray(byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

 
        public static float FromDWord(Int32 value)
        {
            byte[] b = HEX_DINT.ToByteArray(value);
            float d = FromByteArray(b);
            return d;
        }

        public static float FromDWord(UInt32 value)
        {
            byte[] b = HEX_DWORD.ToByteArray(value);
            float d = FromByteArray(b);
            return d;
        }

        public static byte[] ToByteArray(float value)
        {
            byte[] array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        public static byte[] ToByteArray(float[] value)
        {
            HEX_ARRAY arr = new HEX_ARRAY();
            foreach (float val in value)
            {
                arr.Add(ToByteArray(val));
            }
            return arr.array;
        }

        public static float[] ToArrayInverse(byte[] bytes)
        {
            float[] values = new float[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
            {
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });
            }
            return values;
        }

        public static float ToFloat(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new FormatException("Size of byte array > 4)");
            } 
            Array.Reverse(bytes);
            int size = bytes.Length / 2;
            for (int i = 0; i < size; i++)
            {
                bytes[i] += bytes[i + size];
                bytes[i + size] = (byte)(bytes[i] - bytes[i + size]);
                bytes[i] = (byte)(bytes[i] - bytes[i + size]);
            }
            return BitConverter.ToSingle(bytes, 0);
        }

        public static float[] ToArray(byte[] bytes)
        {
            int size = 4;
            int idx = 0;
            float[] result = new float[bytes.Length / size];
            do
            {
                byte[] data = new byte[size];
                Array.Copy(bytes, idx, data, 0, data.Length);
                result[idx / size] = ToFloat(data);
                idx += size;
            } while (idx < bytes.Length);
            return result;
        }


       
        private static byte? BinStringToByte(string txt)
        {
            int cnt = 0;
            int ret = 0;

            if (txt.Length == 8)
            {
                for (cnt = 7; cnt >= 0; cnt += -1)
                {
                    if (int.Parse(txt.Substring(cnt, 1)) == 1)
                    {
                        ret += (int)(Math.Pow(2, (txt.Length - 1 - cnt)));
                    }
                }
                return (byte)ret;
            }
            return null;
        }

        public static float BYTEARRAY_TO_FLOAT(byte[] byteArray, string Order)
        {
            float value_float = 0.0f;

            if (byteArray.Length / 4 > 0)
            {
                string tmp_string = HEX_STRING.BYTEARRAY_TO_HEXSTRING(byteArray);
                string[] str_Array = tmp_string.Split('.');
                byte[] numArray = new byte[str_Array.Length];

                if (Order == "0123")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));
                    }
                }
                else if (Order == "1032")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));
                    }
                }
                else if (Order == "2301")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));
                    }
                }
                else if (Order == "3210")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));
                    }
                }

                value_float = BitConverter.ToSingle(numArray, 0);
            }
            return value_float;
        }

        public static float[] BYTEARRAY_TO_FLOATARRAY(byte[] byteArray, string Order)
        {
            float value_float = 0.0f;

            int count = byteArray.Length / 4; 
            float[] array_float = new float[count];

            if (byteArray.Length / 4 > 0)
            {
                string tmp_string = HEX_STRING.BYTEARRAY_TO_HEXSTRING(byteArray);
                string[] str_Array = tmp_string.Split('.');
                byte[] numArray = new byte[str_Array.Length];

                if (Order == "0123")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));

                        value_float = BitConverter.ToSingle(numArray, 0);
                        array_float[index] = value_float;
                    }
                }
                else if (Order == "1032")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));

                        value_float = BitConverter.ToSingle(numArray, 0);
                        array_float[index] = value_float;
                    }
                }
                else if (Order == "2301")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));

                        value_float = BitConverter.ToSingle(numArray, 0);
                        array_float[index] = value_float;
                    }
                }
                else if (Order == "3210")
                {
                    for (int index = 0; index < str_Array.Length / 4; ++index)
                    {
                        numArray[0] = Convert.ToByte(int.Parse(str_Array[index * 4 + 0], NumberStyles.HexNumber));
                        numArray[1] = Convert.ToByte(int.Parse(str_Array[index * 4 + 1], NumberStyles.HexNumber));
                        numArray[2] = Convert.ToByte(int.Parse(str_Array[index * 4 + 2], NumberStyles.HexNumber));
                        numArray[3] = Convert.ToByte(int.Parse(str_Array[index * 4 + 3], NumberStyles.HexNumber));

                        value_float = BitConverter.ToSingle(numArray, 0);
                        array_float[index] = value_float;
                    }
                }           
            }
            return array_float;
        }
    }
}
