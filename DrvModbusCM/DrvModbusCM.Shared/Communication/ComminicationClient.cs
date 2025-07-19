using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DrvModbusCM.Shared.Communication
{
    public enum OperationMode : int
    {
        [Description("Нет")]
        None = 0,
        [Description("Мастер")]
        Master = 1,
        [Description("Ведомый")]
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

    public enum ExecutionMode : int
    {
        [Description("Cинхронный")]
        Synchronous = 0,
        [Description("Acинхронный")]
        Asynchronous = 1,
    }
}
