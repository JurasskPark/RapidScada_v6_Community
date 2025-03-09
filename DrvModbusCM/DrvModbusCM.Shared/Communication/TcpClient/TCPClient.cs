using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Globalization;
using System.Threading;
using Scada.Comm.Drivers.DrvModbusCM;

public class TCPClient : IDisposable
{
    TcpClient tcpClient = new TcpClient();

    private Socket mSocket;
    private IPEndPoint server;

    private string ipAddress;
    private int port;

    private byte[] bufferSender = new byte[2048];
    private byte[] bufferReceiver = new byte[2048];

    private static int writeTimeout = 1000;
    private static int readTimeout = 1000;

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

    public TCPClient()
    {

    }

    public TCPClient(string ip = "127.0.0.1", int port = 502)
    {
        this.ipAddress = ip;
        this.port = port;
    }

    ~TCPClient()
    {
        this.Dispose();
    }

    public void Dispose()
    {
        if (this.mSocket != null)
        {
            this.mSocket = (Socket)null;
        }

        TCPClient._connected = false;
    }

    #region Connect

    public void Connect(string deviceIPAddress, int devicePort, int writeTimeout, int readTimeout)
    {
        try
        {
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(deviceIPAddress), devicePort);
            mSocket = new Socket(server.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            mSocket.Connect((EndPoint)server);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, (int)writeTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (int)readTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
            TCPClient._connected = true;
        }
        catch
        {
            TCPClient._connected = false;
        }
    }

    public void Connect()
    {
        try
        {
            this.mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.mSocket.SendBufferSize = bufferSender.Length;
            this.mSocket.ReceiveBufferSize = bufferReceiver.Length;
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(this.ipAddress), this.port);
            this.mSocket.Connect(server);
        }
        catch (SocketException ex)
        {
            throw ex;
        }
    }

    public void Connect(string ipAddress, int port)
    {
        try
        {
            this.mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.mSocket.SendBufferSize = bufferSender.Length;
            this.mSocket.ReceiveBufferSize = bufferReceiver.Length;
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(this.ipAddress), this.port);
            this.mSocket.Connect(server);
        }
        catch (SocketException ex)
        {
            throw ex;
        }
    }

    #endregion Connect

    #region Disconnect

    public void Disconnect()
    {
        if (mSocket == null)
        {
            return;
        }
        if (mSocket.Connected)
        {
            try
            {
                mSocket.Shutdown(SocketShutdown.Both);
            }
            catch { }
            mSocket.Close();
        }

        mSocket = (Socket)null;
        TCPClient._connected = false;
    }

    #endregion Disconnect

    #region Timeout

    public void SetTimeout(int timeout)
    {
        writeTimeout = timeout;
        readTimeout = timeout;
    }

    public void SetWriteTimeout(int timeout)
    {
        writeTimeout = timeout;
    }

    public void SetReadTimeout(int timeout)
    {
        readTimeout = timeout;
    }

    #endregion Timeout

    #region Status

    public bool ConnectedStatus(string deviceIPAddress, int devicePort, int writeTimeout, int readTimeout)
    {
        try
        {
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(deviceIPAddress), devicePort);
            mSocket = new Socket(server.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            mSocket.Connect((EndPoint)server);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, (int)writeTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (int)readTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
            TCPClient._connected = true;
        }
        catch
        {
            TCPClient._connected = false;
        }
        return TCPClient._connected;
    }

    #endregion Status

    #region Data
    public void Data(int mode, string deviceIPAddress, int devicePort, int writeTimeout, int readTimeout, byte[] bufferSender, ref byte[] bufferReceiver, ref string errMsg)
    {
        bufferReceiver = WriteData(mode, deviceIPAddress, devicePort, writeTimeout, readTimeout, bufferSender, ref errMsg);
    }

    private byte[] WriteData(int mode, string deviceIPAddress, int devicePort, int writeTimeout, int readTimeout, byte[] bufferSender, ref string errMsg)
    {
        try
        {
            int countDeviceData = 0;

            #region Опрос Асинхроный
            ///////////////////////////////////////////
            if (mode == 0)
            {
                try
                {
                    TcpClient tcpClient = new TcpClient();
                    IPAddress deviceipaddress = IPAddress.Parse(deviceIPAddress);
                    IAsyncResult asyncResult = tcpClient.BeginConnect(deviceipaddress, devicePort, (AsyncCallback)null, (object)null);
                    WaitHandle asyncWaitHandle = asyncResult.AsyncWaitHandle;

                    if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(readTimeout), false))
                    {
                        tcpClient.Close();
                        throw new TimeoutException();
                    }

                    NetworkStream stream = tcpClient.GetStream();
                    stream.WriteTimeout = writeTimeout;
                    stream.ReadTimeout = readTimeout;
                    int startTickCount = Environment.TickCount;
                    ////////////////////////////////
                    stream.Write(bufferSender, 0, bufferSender.Length);
                    ////////////////////////////////
                    byte[] readingData = new byte[bufferReceiver.Length];
                    bufferReceiver = (byte[])null;
                    String responseData = String.Empty;
                    StringBuilder completeMessage = new StringBuilder();

                    do
                    {
                        countDeviceData = stream.Read(readingData, 0, readingData.Length);
                        bufferReceiver = new byte[countDeviceData];
                        Array.Copy((Array)readingData, (Array)bufferReceiver, countDeviceData);
                        completeMessage.AppendFormat("{0}", HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver));
                    }
                    while (stream.DataAvailable);

                    //Переносим в bufferReceiver
                    responseData = completeMessage.ToString();
                    bufferReceiver = HEX_STRING.HEXSTRING_TO_BYTEARRAY(responseData);

                    tcpClient.EndConnect(asyncResult);
                    asyncWaitHandle.Close();
                    tcpClient.Close();

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
            }
            /////////////////////////////////////////////////
            #endregion Опрос Асинхроный

            #region Опрос Синхронный
            ///////////////////////////////////////////
            if (mode == 1)
            {
                try
                {
                    if (!ConnectedStatus(deviceIPAddress, devicePort, writeTimeout, readTimeout))
                    {
                        Connect(deviceIPAddress, devicePort, writeTimeout, readTimeout);
                    }

                    if (mSocket == null || !mSocket.Connected)
                    {
                        errMsg = "[Невозможно подключиться]";
                        return (byte[])null;
                    }

                    if (mSocket.Connected)
                    {
                        //Отправка данных
                        mSocket.Send(bufferSender, 0, bufferSender.Length, SocketFlags.None);

                        //Получение данных
                        //Количество полученных байт
                        Byte[] readingData = new Byte[bufferReceiver.Length];
                        String responseData = String.Empty;
                        bufferReceiver = (byte[])null;
                        countDeviceData = mSocket.Receive(readingData, 0, readingData.Length, SocketFlags.None);
                        bufferReceiver = new byte[countDeviceData];
                        Array.Copy((Array)readingData, (Array)bufferReceiver, countDeviceData);

                        Disconnect();
                    }
                }
                catch (SocketException)
                {
                    //Отдаём ошибку, что "Невозможно подключиться."
                    errMsg = "[Невозможно подключиться]";
                    return (byte[])null;
                }
                catch (TimeoutException)
                {
                    //Отдаём ошибку, что "Время ожидания истекло."
                    errMsg = "[Время ожидания истекло]";
                    return (byte[])null;
                }
                catch (FormatException)
                {
                    //Отдаём ошибку, что "Указан недопустимый IP-адрес."
                    errMsg = "[Указан недопустимый IP-адрес]";
                    return (byte[])null;
                }
                catch (ArgumentOutOfRangeException)
                {
                    //Отдаём ошибку, что "Превышено значение порта."
                    errMsg = "[Превышено значение порта]";
                    return (byte[])null;
                }
                catch (Exception)
                {
                    //Отдаём ошибку, что "Невозможно подключиться."
                    errMsg = "[Невозможно подключиться]";
                    return (byte[])null;
                }
            }
            ///////////////////////////////////////////
            #endregion Опрос Синхронный

            return bufferReceiver;
        }
        catch (SystemException)
        {

        }
        return (byte[])null;
    }

    #endregion Data

}

