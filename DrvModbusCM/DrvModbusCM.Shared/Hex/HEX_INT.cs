using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    class HEX_INT
    {
        private short _value;

        public static short FromByteArray(byte[] bytes)
        {

            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return FromBytes(bytes[1], bytes[0]);
        }

        public static int FromByteArrayHI(byte[] bytes)
        {
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return  Convert.ToInt32(bytes[0]);
        }

        public static int FromByteArrayLO(byte[] bytes)
        {
            // bytes[0] -> HighByte
            // bytes[1] -> LowByte
            return Convert.ToInt32(bytes[1]);
        }

        public static short FromBytes(byte LoVal, byte HiVal)
        {
            return (short)(HiVal * 256 + LoVal);
        }

        public static byte[] ToByteArray(short value)
        {
            byte[] byteArray = BitConverter.GetBytes(value);
            Array.Reverse(byteArray);
            return byteArray;
        }

        public static byte[] ToByteArray(short[] value)
        {
            HEX_ARRAY arr = new HEX_ARRAY();
            foreach (short val in value)
            {
                arr.Add(ToByteArray(val));
            }            
            return arr.array;
        }

        public static short[] ToArray(byte[] bytes)
        {
            short[] values = new short[bytes.Length / 2];
            int counter = 0;
            for (int cnt = 0; cnt < bytes.Length / 2; cnt++)
            {
                values[cnt] = FromByteArray(new byte[] { bytes[counter++], bytes[counter++] });
            }
            return values;
        }

        public static short CWord(int value)
        {
            if (value > 32767)
            {
                value -= 32768;
                value = 32768 - value;
                value *= -1;
            }
            return (short)value;
        }

        public short Value
        {
            get { return this._value; }
            set { this._value = value; }
        }



    }
}
