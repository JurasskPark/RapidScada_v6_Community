using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public class HEX_IPADDRESS
    {
        public static byte[] IP_ADDRESS(string ip)
        {
            byte[] ipadress = new byte[4];

            if (DriverUtils.IsIPAddress(ip))
            {
                string[] headers = ip.Split('.');
                ipadress[0] = Convert.ToByte(headers[0]);
                ipadress[1] = Convert.ToByte(headers[1]);
                ipadress[2] = Convert.ToByte(headers[2]);
                ipadress[3] = Convert.ToByte(headers[3]);
                return ipadress;
            }

            return ipadress;
        }



        public static string IP_ADDRESS(byte[] bytes)
        {
            if (bytes != null)
            {
                ushort tmp_hex_chislo_1 = Convert.ToUInt16(bytes[0]);
                ushort tmp_hex_chislo_2 = Convert.ToUInt16(bytes[1]);
                ushort tmp_hex_chislo_3 = Convert.ToUInt16(bytes[2]);
                ushort tmp_hex_chislo_4 = Convert.ToUInt16(bytes[3]);

                string ipadress = tmp_hex_chislo_1 + "." + tmp_hex_chislo_2 + "." + tmp_hex_chislo_3 + "." + tmp_hex_chislo_4;
                if (DriverUtils.IsIPAddress(ipadress))
                {
                    return ipadress;
                }                
            }
            return string.Empty;
        }
    }
}
