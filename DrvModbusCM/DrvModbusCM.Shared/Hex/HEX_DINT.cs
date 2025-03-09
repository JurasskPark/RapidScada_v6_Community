using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_DINT
    {

        public static int FromByteArray(byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static int FromBytes(byte v1, byte v2, byte v3, byte v4)
        {
            return (int)(v1 + v2 * Math.Pow(2, 8) + v3 * Math.Pow(2, 16) + v4 * Math.Pow(2, 24));
        }

        public static byte[] ToByteArray(int value)
        {
            byte[] array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        public static byte[] ToByteArray(int[] value)
        {
            HEX_ARRAY arr = new HEX_ARRAY();
            foreach (int val in value)
            {
                arr.Add(ToByteArray(val));
            }
            return arr.array;
        }

        public static int[] ToArray(byte[] bytes)
        {
            int[] values = new int[bytes.Length / 4];

            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
            {
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });
            }
            return values;
        }

        //Конвертирование
        public static int CDWord(Int64 value)
        {
            if (value > int.MaxValue)
            {
                value -= (long)int.MaxValue + 1;
                value = (long)int.MaxValue + 1 - value;
                value *= -1;
            }
            return (int)value;
        }
    }
}
