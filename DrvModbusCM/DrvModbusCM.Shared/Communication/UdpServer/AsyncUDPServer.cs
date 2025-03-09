
using CommunicationMethods;
using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Message = CommunicationMethods.Message;

public class AsyncUDPServer
    {
        //Guid Канала, по которому будет искаться устройство в списке девайсов
        private static Guid channelid;
        private static int typserver;
        private static int port;
        private static IPAddress ipaddress;
        //Слушатель
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        private static IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);
        private EndPoint endPoint = (EndPoint)ipEndPoint;
        private byte[] bufferReceiver = new byte[4096 * 3];
        //
        CancellationTokenSource cts;
        //
        private int connectedsocketsnum;
        //Максиммальное количество клиентов
        private int connectedclientsmax;
        //Количество клиентов
        public List<InfoClientUDP> listInfoClientUDP = new List<InfoClientUDP>();
        private ConcurrentDictionary<string, UdpClient> clients;
        //Cтатус
        public bool statusrunning;
        //
        MessageQueue tq = new MessageQueue(2);

        public enum ConnectionStatus { delete, add, info, sended, received }
        //
        private delegate void DataChanged(Message data);
        private event DataChanged DataEvent;
        //
        //Получение логов
        public delegate void DebugData(string ip, ConnectionStatus status, string text);
        public event DebugData Debuger;
     
        public AsyncUDPServer(int TypServer, int Port, int ConnectedClientsMax, Guid GatewayID)
        {
            cts = new CancellationTokenSource();
            ipaddress = IPAddress.Any;
            port = Port;      
            typserver = TypServer;
            connectedsocketsnum = 0;
            connectedclientsmax = ConnectedClientsMax;
            channelid = GatewayID;
            clients = new ConcurrentDictionary<string, UdpClient>();        
        }

        public void Run()
        {
            try
            {
                statusrunning = true;
                DataEvent += tq.EnqueueTask;
                Debuger("", ConnectionStatus.info, "Запуск UDPServer " + ipaddress.ToString() + ":" + port.ToString() + "");

                ipEndPoint = new IPEndPoint(IPAddress.Any, port);
                endPoint = (EndPoint)ipEndPoint;

                socket.Bind(endPoint);
                socket.BeginReceiveFrom(bufferReceiver, 0, bufferReceiver.Length, SocketFlags.None, ref endPoint, new AsyncCallback(ReceiveCallback), socket);  
            }
            finally
            {
            }
        }

        public void Stop()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Shutdown(SocketShutdown.Receive);
                socket.Close();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                cts.Cancel();
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
                finally
                {

                }

            }
            clients.Clear();
            DataEvent -= tq.EnqueueTask;
            Debuger("", ConnectionStatus.info, "Остановлен UDPServer");
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                InfoClientUDP clientInfoClientUDP = new InfoClientUDP();
                clientInfoClientUDP.Socket = socket;
                clientInfoClientUDP.EndPoint = endPoint;
                Guid clientid = Guid.NewGuid();
                clientInfoClientUDP.id = clientid;
                ////
                int amountRead = socket.EndReceiveFrom(ar, ref endPoint);
                ////
                string ip = ((System.Net.IPEndPoint)endPoint).Address.ToString();
                int port = ((System.Net.IPEndPoint)endPoint).Port;

                clientInfoClientUDP.ip = ip;
                clientInfoClientUDP.port = port;

                if (!listInfoClientUDP.Contains(clientInfoClientUDP))
                {
                    listInfoClientUDP.Add(clientInfoClientUDP);
                }

                ConnectionStatus connectionstatus = ConnectionStatus.add;
                Debuger(ip, connectionstatus, "Подключился клиент " + ip + ":" + port + "");

                ////////////////Получение данных от клиента
                byte[] bufferReceiver = new byte[amountRead];
                Array.Copy((Array)this.bufferReceiver, bufferReceiver, amountRead);
                //Пропускаем пустые пакеты
                if (bufferReceiver == null || bufferReceiver.Length == 0)
                {
                    return;
                }

                //Что получили от клиента покажем
                string tmp_bufferReceiver = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver);
                Debuger(ip, ConnectionStatus.info, "" + tmp_bufferReceiver + "");
                ////////////////Получение данных от клиента

                ////////////////Переменная
                byte[] bufferSender = (byte[])null;
                string tmp_bufferSender = string.Empty;
                ////////////////Переменная

                ////////////////Мастер запросов и ответов для устройств
                string Message = string.Empty;
                bufferSender = MasterDeviceReceiverSender.Sender(typserver, channelid, bufferReceiver, ref Message);
                if (Message != string.Empty || Message != "")
                {
                    Debuger(ip, ConnectionStatus.info, Message);
                }
                ////////////////Мастер запросов и ответов для устройств

                if (bufferSender == null)
                {
                    bufferSender = HEX_STRING.HEXSTRING_TO_BYTEARRAY("");
                    tmp_bufferSender = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender);
                }

                //////////////////Поиск устройства

                //////////////////Отправка данных клиенту

                if (listInfoClientUDP.Count > 1)
                {
                    //foreach (var clientData in listInfoClientUDP)
                    //{
                    //    clientData.Socket.SendTo(bufferSender, clientInfoClientUDP.EndPoint);
                    //    Debuger(ip, ConnectionStatus.sended, HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender));
                    //}

                    InfoClientUDP clientData = listInfoClientUDP.Where(r => r.id == clientid).FirstOrDefault();
                    clientData.Socket.SendTo(bufferSender, clientInfoClientUDP.EndPoint);

                    Debuger(ip, ConnectionStatus.sended, HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender));

                    //Удаляем
                    listInfoClientUDP.Remove(clientData);
                    ConnectionStatus cs = ConnectionStatus.delete;
                    Debuger(ip, cs, "Отключился клиент " + ip + ".");
                }
                //////////////////Отправка данных клиенту

                //Количество клиентов
                connectedsocketsnum = listInfoClientUDP.Count();
                Debuger(ip, ConnectionStatus.info, "Клиентское соединение принято. К серверу подключено " + connectedsocketsnum + " клиентов.");

                //Снова начинаем чтение
                clientInfoClientUDP.Socket.BeginReceiveFrom(this.bufferReceiver, 0, this.bufferReceiver.Length, SocketFlags.None, ref clientInfoClientUDP.EndPoint, new AsyncCallback(ReceiveCallback), socket);

            }
            catch (Exception) { }
        }

    }

