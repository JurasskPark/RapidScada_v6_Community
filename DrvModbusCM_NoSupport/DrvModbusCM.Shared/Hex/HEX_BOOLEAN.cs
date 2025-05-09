﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_BOOLEAN
    {
        public static byte[] ToArray(bool value)
        {
            byte[] bytes = new byte[1];
            if (value == true)
            {
                bytes[0] = 1;
            }
            else
            {
                bytes[0] = 0;
            }      
            return bytes;
        }


        public static bool[] ToArray(byte[] value)
        {
            List<bool> result = new List<bool>();
            BitArray bits = new BitArray(value);
            for (int i = 0; i < bits.Count; i++)
            {
                result.Add(bits[i]);
            }
            return result.ToArray();
        }

        public static byte[] ToByteArray(bool[] bits)
        {
            int numBytes = bits.Length / 8;
            int bitEven = bits.Length % 8;
            if (bitEven != 0)
            {
                numBytes++;
            }
            Array.Reverse(bits);
            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }
            Array.Reverse(bytes);
            return bytes;
        }

        public static bool GetValue(byte value, int bit)
        {
            if ((value & (int)Math.Pow(2, bit)) != 0)
                return true;
            else
                return false;
        }

        public static byte SetBit(byte value, int bit)
        {
            return (byte)(value | (byte)Math.Pow(2, bit));
        }

        public static byte ClearBit(byte value, int bit)
        {
            return (byte)(value & (byte)(~(byte)Math.Pow(2, bit)));
        }
    }
}
