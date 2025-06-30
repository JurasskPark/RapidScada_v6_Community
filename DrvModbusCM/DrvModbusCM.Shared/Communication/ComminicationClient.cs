using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("Нет")]
        None = 0,
        [Description("Последовательный порт")]
        SerialPort = 1,
        [Description("Tcp клиент")]
        TcpClient = 2,
        [Description("Udp клиент")]
        UdpClient = 3,
    }
}
