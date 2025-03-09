using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_ENDIAN
    {
        private static readonly bool _LittleEndian = BitConverter.IsLittleEndian;

        public static bool IsBigEndian
        {
            get
            {
                return !HEX_ENDIAN._LittleEndian;
            }
        }

        public static bool IsLittleEndian
        {
            get
            {
                return HEX_ENDIAN._LittleEndian;
            }
        }

        public static short SwapInt16(short v)
        {
            return (short)(((int)v & (int)byte.MaxValue) << 8 | (int)v >> 8 & (int)byte.MaxValue);
        }

        public static ushort SwapUInt16(ushort v)
        {
            return (ushort)(((int)v & (int)byte.MaxValue) << 8 | (int)v >> 8 & (int)byte.MaxValue);
        }

        public static int SwapInt32(int v)
        {
            return ((int)HEX_ENDIAN.SwapInt16((short)v) & (int)ushort.MaxValue) << 16 | (int)HEX_ENDIAN.SwapInt16((short)(v >> 16)) & (int)ushort.MaxValue;
        }

        public static uint SwapUInt32(uint v)
        {
            return (uint)(((int)HEX_ENDIAN.SwapUInt16((ushort)v) & (int)ushort.MaxValue) << 16 | (int)HEX_ENDIAN.SwapUInt16((ushort)(v >> 16)) & (int)ushort.MaxValue);
        }

        public static long SwapInt64(long v)
        {
            return ((long)HEX_ENDIAN.SwapInt32((int)v) & (long)uint.MaxValue) << 32 | (long)HEX_ENDIAN.SwapInt32((int)(v >> 32)) & (long)uint.MaxValue;
        }

        public static ulong SwapUInt64(ulong v)
        {
            return (ulong)(((long)HEX_ENDIAN.SwapUInt32((uint)v) & (long)uint.MaxValue) << 32 | (long)HEX_ENDIAN.SwapUInt32((uint)(v >> 32)) & (long)uint.MaxValue);
        }
    }
}
