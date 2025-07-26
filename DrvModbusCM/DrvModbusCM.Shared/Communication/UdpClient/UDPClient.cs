using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class UDPClient : IDisposable
{
    UdpClient udpClientSender = new UdpClient();
    UdpClient udpClientReceiver = new UdpClient();

    private Socket mSocket;

    public IPAddress ipAddress { get; set; }
    public int port { get; set; }

    public byte[] bufferSender { get; set; }
    public byte[] bufferReceiver { get; set; }

    public int writeTimeout { get; set; }
    public int readTimeout { get; set; }

    private static bool connected = false;

    public const byte excIllegalFunction = 1;
    public const byte excIllegalDataAdr = 2;
    public const byte excIllegalDataVal = 3;
    public const byte excSlaveDeviceFailure = 4;
    public const byte excAck = 5;
    public const byte excSlaveIsBusy = 6;
    public const byte excGatePathUnavailable = 10;
    public const byte excExceptionNotConnected = 253;
    public const byte excExceptionConnectionLost = 254;
    public const byte excExceptionTimeout = 255;


    public UDPClient()
    {
        this.ipAddress = IPAddress.Loopback;
        this.port = 502;
        this.bufferSender = new byte[2048];
        this.bufferReceiver = new byte[2048];
        this.writeTimeout = 1000;
        this.readTimeout = 1000;    

        udpClientSender = new UdpClient();
        udpClientReceiver = new UdpClient();
    }

    public UDPClient(string clientIp = "127.0.0.1", int clientPort = 502)
    {
        this.ipAddress = IPAddress.Parse(clientIp);
        this.port = clientPort;
        this.bufferSender = new byte[2048];
        this.bufferReceiver = new byte[2048];
        this.writeTimeout = 1000;
        this.readTimeout = 1000;

        udpClientSender = new UdpClient();
        udpClientReceiver = new UdpClient();
    }

    public UDPClient(IPAddress clientIp, int clientPort = 502)
    {
        this.ipAddress = clientIp;
        this.port = clientPort;
        this.bufferSender = new byte[2048];
        this.bufferReceiver = new byte[2048];
        this.writeTimeout = 1000;
        this.readTimeout = 1000;

        udpClientSender = new UdpClient();
        udpClientReceiver = new UdpClient();
    }

    public UDPClient(string clientIp = "127.0.0.1", int clientPort = 502, int clientWriteTimeout = 1000, int clientReadTimeout = 1000, int clientWriteBufferSize = 2048, int clientReadBufferSize = 2048)
    {
        this.ipAddress = IPAddress.Parse(clientIp);
        this.port = clientPort;
        this.writeTimeout = clientWriteTimeout;
        this.readTimeout = clientReadTimeout;
        this.bufferSender = new byte[clientWriteBufferSize];
        this.bufferReceiver = new byte[clientReadBufferSize];

        udpClientSender = new UdpClient();
        udpClientReceiver = new UdpClient();
    }

    public UDPClient(IPAddress clientIp, int clientPort = 502, int clientWriteTimeout = 1000, int clientReadTimeout = 1000, int clientWriteBufferSize = 2048, int clientReadBufferSize = 2048)
    {
        this.ipAddress = clientIp;
        this.port = clientPort;
        this.writeTimeout = clientWriteTimeout;
        this.readTimeout = clientReadTimeout;
        this.bufferSender = new byte[clientWriteBufferSize];
        this.bufferReceiver = new byte[clientReadBufferSize];

        udpClientSender = new UdpClient();
        udpClientReceiver = new UdpClient();
    }

    ~UDPClient()
    {
        this.Dispose();
    }

    public void Dispose()
    {
        if (this.mSocket != null)
        {
            this.mSocket = (Socket)null;
        }

        UDPClient.connected = false;
    }

    public void Data(byte[] bufferSender, ref byte[] bufferReceiver, ref string errMsg)
    {
        bufferReceiver = WriteData(bufferSender, ref errMsg);
    }

    private byte[] WriteData(byte[] bufferSender, ref string errMsg)
    {
        try
        {
            udpClientSender = new UdpClient(this.port);
            try
            {
                udpClientSender.Connect(this.ipAddress, this.port);
                udpClientSender.Send(bufferSender, bufferSender.Length);

                udpClientReceiver = new UdpClient();
                udpClientReceiver.Send(bufferSender, bufferSender.Length, this.ipAddress.ToString(), this.port);

                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, this.port);
                byte[] bufferReceiver = (byte[])null;

                bufferReceiver = udpClientSender.Receive(ref RemoteIpEndPoint);

                udpClientSender.Close();
                udpClientReceiver.Close();

                return bufferReceiver;
            }
            catch (SocketException)
            {
                //Отдаём ошибку, что "Невозможно подключиться."
                errMsg = "[Невозможно подключиться]";
            }
            catch (TimeoutException)
            {
                //Отдаём ошибку, что "Время ожидания истекло."
                errMsg = "[Время ожидания истекло]";
            }
            catch (FormatException)
            {
                //Отдаём ошибку, что "Указан недопустимый IP-адрес."
                errMsg = "[Указан недопустимый IP-адрес]";
            }
            catch (ArgumentOutOfRangeException)
            {
                //Отдаём ошибку, что "Превышено значение порта."
                errMsg = "[Превышено значение порта]";
            }
            catch (Exception)
            {
                //Отдаём ошибку, что "Невозможно подключиться."
                errMsg = "[Невозможно подключиться]";
            }

            return (byte[])null;
        }
        catch (SystemException)
        {

        }
        return (byte[])null;
    }
}

