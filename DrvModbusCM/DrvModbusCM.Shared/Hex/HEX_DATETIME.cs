using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_DATETIME
    {
        public static DateTime DateFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new FormatException("Size of byte array != 4");
            }
            return new DateTime(2000 + bytes[2], bytes[1], bytes[0]);
        }

        public static DateTime TimeFromByteArray(byte[] bytes)
        {
            if (bytes.Length != 4)
            {
                throw new FormatException("Size of byte array != 4");
            }
            return new DateTime(0, 0, 0, bytes[2], bytes[1], bytes[0]);
        }

        public static DateTime DateTimeFromByteArray6(byte[] bytes)
        {
            if (bytes.Length != 6)
            {
                throw new FormatException("Size of byte array != 6");
            }
            return new DateTime(2000 + bytes[2], bytes[1], bytes[0], bytes[5], bytes[4], bytes[3]);
        }

        public static DateTime DateTimeFromByteArray8(byte[] bytes)
        {
            if (bytes.Length != 8)
            {
                throw new FormatException("Size of byte array != 8");
            }
            return new DateTime(2000 + bytes[2], bytes[1], bytes[0], bytes[6], bytes[5], bytes[4]);
        }


    }
}
