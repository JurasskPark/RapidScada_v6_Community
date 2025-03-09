using Scada.Comm.Drivers.DrvModbusCM;

namespace ProtocolModbus
{
    public partial class ModbusAddresses
    {
        public static void DecodingAddress(string address, out int addressInt, out int addressBit)
        {
            addressInt = 0;
            addressBit = 0;

            address = address.ToUpper().Replace("H", "").Replace("0X", "");

            addressInt = DriverUtils.FloatToInteger(address);
            addressBit = DriverUtils.FloatToFractionalNumber(address);
        }
    }
}
