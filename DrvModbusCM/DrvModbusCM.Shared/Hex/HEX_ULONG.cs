using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_ULONG
    {
        public static ulong HEXARRAY_TO_HEXARRAYULONG(byte[] bytes)
        {
            ulong value = 0;
            byte[] arrValue = new byte[8];
            arrValue[0] = 0;
            arrValue[1] = 0;
            arrValue[2] = 0;
            arrValue[3] = 0;
            arrValue[4] = 0;
            arrValue[5] = 0;
            arrValue[6] = 0;
            arrValue[7] = 0;


            bytes = HEX_ARRAY.ArrayReverse(bytes);

            for (int i = 0; i < bytes.Length - 1; ++i)
            {
                arrValue[i] = bytes[i];
            }

            value = BitConverter.ToUInt64(arrValue);
            return value;
        }

        public static byte[] HEXARRAYULONG_TO_HEXARRAY(ulong value)
        {
            byte[] arrValue = new byte[8];
            arrValue[0] = 0;
            arrValue[1] = 0;
            arrValue[2] = 0;
            arrValue[3] = 0;
            arrValue[4] = 0;
            arrValue[5] = 0;
            arrValue[6] = 0;
            arrValue[7] = 0;

            arrValue = BitConverter.GetBytes(value);
            return arrValue;
        }
    }

}
