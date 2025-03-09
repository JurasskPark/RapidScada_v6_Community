using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_ULONG
    {
        public static ulong HEXARRAY_TO_ULONG(byte[] bytes, int startIndex, int deviceRegistersBytes)
        {
            ulong value = 0;
            switch (deviceRegistersBytes)
            {
                case 2: //2 байт
                    value = HEX_ENDIAN.SwapUInt16(BitConverter.ToUInt16(bytes, (int)startIndex * (int)deviceRegistersBytes));
                    break;
                case 4: //4 байт
                    value = HEX_ENDIAN.SwapUInt32(BitConverter.ToUInt32(bytes, (int)startIndex * (int)deviceRegistersBytes));
                    break;
            }
            return value;
        }

    }

}
