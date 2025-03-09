using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_OPERATION
    {
        public static byte[] BYTEARRAY_COMBINE(byte[] bytes_Data_1, byte[] bytes_Data_2)
        {
            try
            {
                byte[] newArray = (byte[])null;

                if (bytes_Data_1 == null && bytes_Data_2.Length > 0)
                {
                    return bytes_Data_2;
                }
                else if (bytes_Data_2 == null && bytes_Data_1.Length > 0)
                {
                    return bytes_Data_1;
                }
                else if (bytes_Data_1 == null && bytes_Data_2 == null)
                {
                    return null;
                }

                newArray = new byte[bytes_Data_1.Length + bytes_Data_2.Length];
                Array.Copy(bytes_Data_1, 0, newArray, 0, bytes_Data_1.Length);
                Array.Copy(bytes_Data_2, 0, newArray, bytes_Data_1.Length, bytes_Data_2.Length);
                return newArray;
            }
            catch
            {
                return (byte[])null;
            }
        }

        public static byte[] BYTEARRAY_SEARCH(byte[] bytes_Data, int address_array, int number_of_array_cells)
        {       
            try
            {
                byte[] newArray = new byte[number_of_array_cells];
                Array.Copy(bytes_Data, address_array, newArray, 0, number_of_array_cells);
                return newArray;
            }
            catch
            {
                return (byte[])null;
            }
        }
    }
}
