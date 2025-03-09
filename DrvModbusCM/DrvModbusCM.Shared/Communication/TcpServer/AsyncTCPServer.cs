using Scada.Comm.Drivers.DrvModbusCM;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using CommunicationMethods;

namespace CommunicationMethods
{
    public class AsyncTCPServer
    {
        //Guid Канала, по которому будет искаться устройство в списке девайсов
        private static Guid channelid;
        private static int typserver;
        private static int port;
        private static IPAddress ipaddress;
        //Слушатель
        TcpListener listener;
        //
        CancellationTokenSource cts;
        //
        private int connectedsocketsnum;
        //Максиммальное количество клиентов
        private int connectedclientsmax;
        //Количество клиентов
        private ConcurrentDictionary<string, TcpClient> clients;
        //Cтатус
        public bool statusrunning;
        //
        public enum ConnectionStatus { delete, add, info, sended, received }
        //
        MessageQueue tq = new MessageQueue(2);
        //
        private delegate void DataChanged(Message data);
        private event DataChanged DataEvent;
        //
        //Получение логов
        public delegate void DebugData(string ip, ConnectionStatus status, string text);
        public event DebugData Debuger;

        public AsyncTCPServer(int TypServer, int Port, int ConnectedClientsMax, Guid GatewayID)
        {
            cts = new CancellationTokenSource();
            listener = new TcpListener(IPAddress.Any, Port);
            ipaddress = IPAddress.Any;
            port = Port;
            typserver = TypServer;
            connectedsocketsnum = 0;
            connectedclientsmax = ConnectedClientsMax;
            channelid = GatewayID;
            clients = new ConcurrentDictionary<string, TcpClient>();
        }

        public void Run()
        {
            try
            {
                listener.Start();
                statusrunning = true;
                var task = Task.Run(() => AcceptClientsAsync(listener, cts.Token));
                if (task.IsFaulted)
                {
                    task.Wait();
                }

                DataEvent += tq.EnqueueTask;
                Debuger("", ConnectionStatus.info, "Запуск TCPServer " + ipaddress.ToString() + ":" + port.ToString() + "");
            }
            finally
            {
            }
        }

        public void Stop()
        {
            try
            {
                cts.Cancel();
                listener.Stop();
                tq.Dispose();
            }
            finally
            {
            }
            foreach (var client in clients.Values)
            {
                try
                {
                    ConnectionStatus cs = ConnectionStatus.delete;
                    string ip = client.Client.RemoteEndPoint.ToString();
                    Debuger(ip, cs, "");

                    client.Client.Close();
                }
                catch { }
                finally { }
            }
            clients.Clear();
            DataEvent -= tq.EnqueueTask;
            Debuger("", ConnectionStatus.info, "Остановлен TCPServer");
        }

        async Task AcceptClientsAsync(TcpListener listener, CancellationToken ct)
        {
            var ip = string.Empty;
            while (!ct.IsCancellationRequested)
            {
                if (connectedsocketsnum >= connectedclientsmax)
                {
                    statusrunning = false;
                    listener.Stop();
                    break;
                }

                var client = await Extensions.WithWaitCancellation(listener.AcceptTcpClientAsync(), ct);
                ip = client.Client.RemoteEndPoint.ToString();
                var task = Task.Run(() => EchoAsync(client, ip, ct));
            }
        }

        async Task EchoAsync(TcpClient client, string ip, CancellationToken ct)
        {
            var buf = new byte[4096 * 3];

            using (client)
            {
                if (client.Client.Poll(0, SelectMode.SelectRead))
                {
                    byte[] buff = new byte[1];
                    if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
                    {
                        buff = null;
                        return;
                    }
                    buff = null;
                }

                Interlocked.Increment(ref connectedsocketsnum);
                Debuger(ip, ConnectionStatus.info, "Клиентское соединение принято. К серверу подключено " + connectedsocketsnum + " клиентов.");

                clients.AddOrUpdate(ip, client, (n, o) => { return o; });
                ConnectionStatus connectionstatus = ConnectionStatus.add;
                Debuger(ip, connectionstatus, "Подключился клиент " + ip + "");

                using (var stream = client.GetStream())
                {
                    while (!ct.IsCancellationRequested)
                    {
                        var timeoutTask = Task.Delay(TimeSpan.FromSeconds(610));
                        var amountReadTask = stream.ReadAsync(buf, 0, buf.Length, ct);

                        var completedTask = await Task.WhenAny(timeoutTask, amountReadTask).ConfigureAwait(false);
                        if (completedTask == timeoutTask)
                        {
                            break;
                        }

                        if (amountReadTask.IsFaulted || amountReadTask.IsCanceled)
                        {
                            break;
                        }
                        var amountRead = amountReadTask.Result;
                        if (amountRead == 0) { break; }

                        ////////////////Получение данных от клиента
                        byte[] bufferReceiver = new byte[amountRead];
                        Array.Copy((Array)buf, bufferReceiver, amountRead);

                        //Пропускаем пустые пакеты
                        if (bufferReceiver == null || bufferReceiver.Length == 0)
                        {
                            return;
                        }

                        //Что получили от клиента покажем
                        string tmp_bufferReceiver = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver);
                        Debuger(ip, ConnectionStatus.received, "" + tmp_bufferReceiver + "");
                        ////////////////Получение данных от клиента

                        ////////////////Переменная
                        byte[] bufferSender = (byte[])null;
                        string tmp_bufferSender = string.Empty;
                        ////////////////Переменная

                        ////////////////Мастер запросов и ответов для устройств
                        string Message = string.Empty;
                        bufferSender = MasterDeviceReceiverSender.Sender(typserver, channelid, bufferReceiver, ref Message);
                        Debuger(ip, ConnectionStatus.info, Message);
                        ////////////////Мастер запросов и ответов для устройств

                        if (bufferSender == null)
                        {
                            bufferSender = HEX_STRING.HEXSTRING_TO_BYTEARRAY("");
                            tmp_bufferSender = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender);
                        }

                        ////////////////Поиск устройства

                        ////////////////Отправка данных клиенту
                        stream.Write(bufferSender, 0, bufferSender.Length);
                        tmp_bufferSender = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender);
                        Debuger(ip, ConnectionStatus.sended, "" + tmp_bufferSender + "");
                        ////////////////Отправка данных клиенту

                        Message ms = new Message()
                        {
                            ip = ip,
                            data = tmp_bufferSender
                        };

                        if (ms.data != string.Empty)
                        {
                            DataEvent(ms);
                        }
                    }
                }
            }
            buf = null;
            Interlocked.Decrement(ref connectedsocketsnum);

            Debuger(ip, ConnectionStatus.info, "Клиент " + ip + " отключен. К серверу подключено " + connectedsocketsnum + " клиентов.]");

            clients.TryRemove(ip, out TcpClient tcpClient);
            if (tcpClient != null)
            {
                tcpClient.Close();
            }

            tcpClient = null;
            ConnectionStatus cs = ConnectionStatus.delete;
            
            Debuger(ip, cs, "Отключился клиент " + ip + ".");

            if (connectedsocketsnum < connectedclientsmax && statusrunning == false)
            {
                ReStartListener();
            }
        }

        private void ReStartListener()
        {
            statusrunning = true;
            listener.Start();
            DataEvent += tq.EnqueueTask;
            var task = Task.Run(() => AcceptClientsAsync(listener, cts.Token));
        }


    }

}