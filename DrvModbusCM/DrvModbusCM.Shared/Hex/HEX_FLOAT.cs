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

        public static float BYTEARRAY_TO_FLOAT(byte[] bytes, string byteOrderStr)
        {
            float value = 0.0f;
            byte[] bytesOrder = HEX_ARRAY.ArrayByteOrder(bytes, byteOrderStr);
            value = BitConverter.ToSingle(bytesOrder, 0);
            return value;
        }

        public static float[] BYTEARRAY_TO_FLOATARRAY(byte[] bytes, string byteOrderStr)
        {
            int count = bytes.Length / 4; 
            float[] array_float = new float[count];

            if (bytes.Length / 4 > 0)
            {
                byte[] numArray = new byte[4];

                for (int index = 0; index < bytes.Length / 4; ++index)
                {
                    numArray[0] = bytes[index * 4 + 0];
                    numArray[1] = bytes[index * 4 + 1];
                    numArray[2] = bytes[index * 4 + 2];
                    numArray[3] = bytes[index * 4 + 3];

                    byte[] bytesOrder = HEX_ARRAY.ArrayByteOrder(numArray, byteOrderStr);
                    float value = BitConverter.ToSingle(bytesOrder, 0);
                    array_float[index] = value;
                }
            }
            return array_float;
        }
    }
}
