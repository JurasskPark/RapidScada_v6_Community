using DrvModbusCM.Shared.Communication;
using Scada.Comm.Drivers.DrvModbusCM;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPClient : IDisposable
{
    TcpClient tcpClient = new TcpClient();

    private Socket mSocket;
    private IPEndPoint server;

    public ExecutionMode mode { get; set; }
    public IPAddress ipAddress { get; set; }
    public int port { get; set; }


    public byte[] bufferSender  { get; set; }
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

    public TCPClient()
    {
        this.ipAddress = IPAddress.Loopback;
        this.port = 502;
        this.bufferSender = new byte[2048];
        this.bufferReceiver = new byte[2048];
        this.writeTimeout = 1000;
        this.readTimeout = 1000;
    }

    public TCPClient(string clientIp = "127.0.0.1", int clientPort = 502)
    {
        this.ipAddress = IPAddress.Parse(clientIp);
        this.port = clientPort;
        this.bufferSender = new byte[2048];
        this.bufferReceiver = new byte[2048];
        this.writeTimeout = 1000;
        this.readTimeout = 1000;
    }

    public TCPClient(IPAddress clientIp, int clientPort = 502)
    {
        this.ipAddress = clientIp;
        this.port = clientPort;
        this.bufferSender = new byte[2048];
        this.bufferReceiver = new byte[2048];
        this.writeTimeout = 1000;
        this.readTimeout = 1000;
    }

    public TCPClient(string clientIp = "127.0.0.1", int clientPort = 502, int clientWriteTimeout = 1000, int clientReadTimeout = 1000, int clientWriteBufferSize = 2048, int clientReadBufferSize = 2048, ExecutionMode clientMode = ExecutionMode.Synchronous)
    {
        this.mode = clientMode;
        this.ipAddress = IPAddress.Parse(clientIp);
        this.port = clientPort;
        this.writeTimeout = clientWriteTimeout;
        this.readTimeout = clientReadTimeout;
        this.bufferSender = new byte[clientWriteBufferSize];
        this.bufferReceiver = new byte[clientReadBufferSize];
    }

    public TCPClient(IPAddress clientIp, int clientPort = 502, int clientWriteTimeout = 1000, int clientReadTimeout = 1000, int clientWriteBufferSize = 2048, int clientReadBufferSize = 2048, ExecutionMode clientMode = ExecutionMode.Synchronous)
    {
        this.mode = clientMode;
        this.ipAddress = clientIp;
        this.port = clientPort;
        this.writeTimeout = clientWriteTimeout;
        this.readTimeout = clientReadTimeout;
        this.bufferSender = new byte[clientWriteBufferSize];
        this.bufferReceiver = new byte[clientReadBufferSize];
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

        TCPClient.connected = false;
    }

    #region Connect
    public void Connect()
    {
        try
        {
            this.mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.mSocket.SendBufferSize = bufferSender.Length;
            this.mSocket.ReceiveBufferSize = bufferReceiver.Length;
            IPEndPoint server = new IPEndPoint(this.ipAddress, this.port);
            this.mSocket.Connect(server);
        }
        catch (SocketException ex)
        {
            throw ex;
        }
    }

    public void Connect(string clientIp, int clientPort)
    {
        try
        {
            Connect(IPAddress.Parse(clientIp), clientPort);
        }
        catch (SocketException ex)
        {
            throw ex;
        }
    }

    public void Connect(IPAddress clientIp, int clientPort)
    {
        try
        {
            this.mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.mSocket.SendBufferSize = bufferSender.Length;
            this.mSocket.ReceiveBufferSize = bufferReceiver.Length;
            IPEndPoint server = new IPEndPoint(this.ipAddress, this.port);
            this.mSocket.Connect(server);
        }
        catch (SocketException ex)
        {
            throw ex;
        }
    }

    public void Connect(string clientIp, int clientPort = 502, int clientWriteTimeout = 1000, int clientReadTimeout = 1000)
    {
        Connect(IPAddress.Parse(clientIp), clientPort, clientWriteTimeout, clientReadTimeout);
    }

    public void Connect(IPAddress clientIp, int clientPort = 502, int clientWriteTimeout = 1000, int clientReadTimeout = 1000)
    {
        try
        {
            IPEndPoint server = new IPEndPoint(clientIp, clientPort);
            mSocket = new Socket(server.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            mSocket.Connect((EndPoint)server);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, (int)clientWriteTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, (int)clientReadTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
            TCPClient.connected = true;
        }
        catch
        {
            TCPClient.connected = false;
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
        TCPClient.connected = false;
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
    public bool ConnectedStatus(string clientIp, int clientPort, int clientWriteTimeout, int clientReadTimeout)
    {
        return ConnectedStatus(IPAddress.Parse(clientIp), clientPort, clientWriteTimeout, clientReadTimeout);
    }

    public bool ConnectedStatus(IPAddress clientIp, int clientPort, int clientWriteTimeout, int clientReadTimeout)
    {
        try
        {
            IPEndPoint server = new IPEndPoint(clientIp, clientPort);
            mSocket = new Socket(server.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            mSocket.Connect((EndPoint)server);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, clientWriteTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, clientReadTimeout);
            mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Debug, 1);
            TCPClient.connected = true;
        }
        catch
        {
            TCPClient.connected = false;
        }
        return TCPClient.connected;
    }

    #endregion Status

    #region Data
    public void Data(byte[] bufferSender, ref byte[] bufferReceiver, ref string errMsg)
    {
        bufferReceiver = WriteData(bufferSender, ref errMsg);
    }

    private byte[] WriteData(byte[] bufferSender, ref string errMsg)
    {
        try
        {
            int countDeviceData = 0;

            #region Опрос Синхронный
            ///////////////////////////////////////////
            if (mode == ExecutionMode.Synchronous)
            {
                try
                {
                    if (!ConnectedStatus(ipAddress, port, writeTimeout, readTimeout))
                    {
                        Connect(ipAddress, port, writeTimeout, readTimeout);
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

            #region Опрос Асинхроный
            ///////////////////////////////////////////
            if (mode == ExecutionMode.Asynchronous)
            {
                try
                {
                    TcpClient tcpClient = new TcpClient();
                    IAsyncResult asyncResult = tcpClient.BeginConnect(ipAddress, port, (AsyncCallback)null, (object)null);
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

            return bufferReceiver;
        }
        catch (SystemException)
        {

        }
        return (byte[])null;
    }

    #endregion Data

}

