using System;
using System.Collections.Generic;
using System.Text;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    public enum DriverProtocol : int
    {
        None = 0,
        ModbusRTU = 1,
        ModbusTCP = 2,
        ModbusASCII = 3,
    }
}
