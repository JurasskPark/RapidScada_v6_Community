using System;
using System.Collections.Generic;
using System.Text;

namespace DrvModbusCM.Shared.Communication
{
    public enum OperationMode : int
    {
        None = 0,
        Master = 1,
        Slave = 2,
    }

    public enum CommunicationClient : int
    {
        None = 0,
        SerialPort = 1,
        TcpClient = 2,
        UdpClient = 3,
    }
}
