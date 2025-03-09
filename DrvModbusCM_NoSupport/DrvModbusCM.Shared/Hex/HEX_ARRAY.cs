using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_ARRAY
    {
        List<byte> list = new List<byte>();

        public byte[] array
        {
            get { return list.ToArray(); }
        }

        public HEX_ARRAY()
        {
            list = new List<byte>();
        }

        public HEX_ARRAY(int size)
        {
            list = new List<byte>(size);
        }

        public void Clear()
        {
            list = new List<byte>();
        }

        public void Add(byte item)
        {
            list.Add(item);
        }

        public void Add(byte[] items)
        {
            list.AddRange(items);
        }

        /// <summary>
        /// Parses a byte order array from the string notation like '01234567'.
        /// </summary>
        public static byte[] ArrayByteOrder(byte[] bytes, string byteOrderStr)
        {
            if (string.IsNullOrEmpty(byteOrderStr) || bytes.Length != byteOrderStr.Length)
            {
                return bytes;
            }
            else
            {
                int len = byteOrderStr.Length;
                byte[] byteOrder = new byte[bytes.Length];

                for (int i = 0; i < len; i++)
                {
                    byteOrder[i] = bytes[int.TryParse(byteOrderStr[i].ToString(), out int n) ? n : 0];
                }

                return byteOrder;
            }
        }

        /// <summary>
        /// Get a reverse byte array
        /// </summary>
        public static byte[] ArrayReverse(byte[] bytes)
        {
            if(bytes == null)
            {
                return (byte[])null;
            }
            Array.Reverse(bytes);
            return bytes;
        }

    }
}
