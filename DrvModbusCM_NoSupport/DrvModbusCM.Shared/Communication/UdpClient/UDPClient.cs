using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

public class UDPClient : IDisposable
{

    private Socket mSocket;
    private byte[] bufferSender = new byte[2048];
    private byte[] bufferReceiver = new byte[2048];

    private static bool _connected = false;

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

        UDPClient._connected = false;
    }

    public void Data(string DeviceIPAddress, int DevicePort, int WriteTimeout, int ReadTimeout, int Timeout, byte[] bufferSender, ref byte[] bufferReceiver, ref string MessageError)
    {
        bufferReceiver = WriteData(DeviceIPAddress, DevicePort, WriteTimeout, ReadTimeout, Timeout, bufferSender, ref MessageError);
    }

    private byte[] WriteData(string DeviceIPAddress, int DevicePort, int WriteTimeout, int ReadTimeout, int Timeout, byte[] bufferSender, ref string MessageError)
    {
        try
        {
            UdpClient udpClient = new UdpClient(DevicePort);
            try
            {
                udpClient.Connect(DeviceIPAddress, DevicePort);
                udpClient.Send(bufferSender, bufferSender.Length);

                UdpClient udpClientB = new UdpClient();
                
                udpClientB.Send(bufferSender, bufferSender.Length, DeviceIPAddress, DevicePort);

                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, DevicePort);
                byte[] bufferReceiver = (byte[])null;


                bufferReceiver = udpClient.Receive(ref RemoteIpEndPoint);

                udpClient.Close();
                udpClientB.Close();

                return bufferReceiver;
            }
            catch (SocketException)
            {
                //Отдаём ошибку, что "Невозможно подключиться."
                MessageError = "[Невозможно подключиться]";
            }
            catch (TimeoutException)
            {
                //Отдаём ошибку, что "Время ожидания истекло."
                MessageError = "[Время ожидания истекло]";
            }
            catch (FormatException)
            {
                //Отдаём ошибку, что "Указан недопустимый IP-адрес."
                MessageError = "[Указан недопустимый IP-адрес]";
            }
            catch (ArgumentOutOfRangeException)
            {
                //Отдаём ошибку, что "Превышено значение порта."
                MessageError = "[Превышено значение порта]";
            }
            catch (Exception)
            {
                //Отдаём ошибку, что "Невозможно подключиться."
                MessageError = "[Невозможно подключиться]";
            }

            return (byte[])null;
        }
        catch (SystemException)
        {

        }
        return (byte[])null;
    }
}

