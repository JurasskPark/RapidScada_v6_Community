using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_DWORD
    {
        public static UInt32 FromByteArray(byte[] bytes)
        {
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static UInt32 FromBytes(byte param1, byte param2, byte param3, byte param4)
        {
            byte[] bytes = new byte[] { param1, param2, param3, param4 };
            return BitConverter.ToUInt32(bytes, 0);
        }

        public static UInt32[] ToArray(byte[] bytes)
        {
            UInt32[] values = new UInt32[bytes.Length / 4];
            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 4; cnt++)
            {
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++], bytes[counter++], bytes[counter++] });
            }
            return values;
        }

        public static byte[] ToByteArray(UInt32 value)
        {
            byte[] byteArray = BitConverter.GetBytes(value);
            Array.Reverse(byteArray);
            return byteArray;
        }

        public static byte[] ToByteArray(UInt32[] value)
        {
            HEX_ARRAY arr = new HEX_ARRAY();
            foreach (UInt32 val in value)
            {
                arr.Add(ToByteArray(val));
            }         
            return arr.array;
        }


    }
}
