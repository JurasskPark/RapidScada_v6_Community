using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_WORD
    {
        public static UInt16 FromByteArray(byte[] bytes)
        {
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return FromBytes(bytes[1], bytes[0]);
        }

        public static UInt16 FromBytes(byte LoVal, byte HiVal)
        {
            return (UInt16)(HiVal * 256 + LoVal);
        }

        public static UInt16 FromByteArrayHighByte(byte[] bytes)
        {
            if (bytes.Length != 2)
            {
                throw new FormatException("Size of byte array != 2");
            }
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return Convert.ToUInt16(bytes[0]);
        }

        public static UInt16 FromByteArrayLowByte(byte[] bytes)
        {
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return Convert.ToUInt16(bytes[1]);
        }

        public static byte[] ToByteArray(UInt16 value)
        {
            byte[] array = BitConverter.GetBytes(value);
            Array.Reverse(array);
            return array;
        }

        public static byte[] ToByteArray(UInt16[] value)
        {
            HEX_ARRAY arr = new HEX_ARRAY();
            foreach (UInt16 val in value)
            {
                arr.Add(ToByteArray(val));
            }            
            return arr.array;
        }

        public static UInt16[] ToArray(byte[] bytes)
        {
            UInt16[] values = new UInt16[bytes.Length / 2];
            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
            {
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });
            }
            return values;
        }
    }
}
