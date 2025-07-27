using CommunicationMethods;
using DrvModbusCM.Shared.Communication;
using Master;
using Scada.Comm.Devices;
using System.Data;
using System.IO.Ports;
using System.Xml.Serialization;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    internal class DriverClient
    {
        #region Variables

        #region Basic
        /// <summary>
        /// Project configuration
        /// <para>Конфигурация проекта</para>
        /// </summary>
        public Project Project { get; set; } 

        /// <summary>
        /// Channel
        /// <para>Канал</para>
        /// </summary>
        public ProjectChannel Channel { get; set; }
       
        /// <summary>
        /// Devices
        /// <para>Устройства</para>
        /// </summary>
        public List<ProjectDevice> Devices { get; set; }
 
        /// <summary>
        /// Devices
        /// <para>Устройства</para>
        /// </summary>
         public ProjectDevice Device { get; set; }
        
        /// <summary>
        /// Commands Group
        /// <para>Группа команд</para>
        /// </summary>
        public List<ProjectGroupCommand> GroupCommands { get; set; }
        
        /// <summary>
        /// Commands Group
        /// <para>Группа команд</para>
        /// </summary>
        public ProjectGroupCommand GroupCommand { get; set; }

        /// <summary>
        /// Command
        /// <para>Команды</para>
        /// </summary>
        public List<ProjectCommand> Commands { get; set; }

        /// <summary>
        /// Command
        /// <para>Команда</para>
        /// </summary>
        public ProjectCommand Command { get; set; }

        /// <summary>
        /// Tags Group
        /// <para>Группа тегов</para>
        /// </summary>
        public List<ProjectGroupTag> GroupTags { get; set; }


        /// <summary>
        /// Tags Group
        /// <para>Группа тегов</para>
        /// </summary>
        public ProjectGroupTag GroupTag { get; set; }

        /// <summary>
        /// Tag
        /// <para>Тег</para>
        /// </summary>
        public List<ProjectTag> Tags { get; set; }

        /// <summary>
        /// Tag
        /// <para>Тег</para>
        /// </summary>
        public ProjectTag Tag { get; set; }

        /// <summary>
        /// Driver Tags
        /// <para>Теги драйвера</para>
        /// </summary>
        private List<CnlPrototypeGroup> DriverTags { get; set; }

        #endregion Basic

        #region Thread
        /// <summary>
        /// Thread
        /// Поток
        /// </summary>
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        static object lockObj = new object();
        private Thread thread;                                                      // the thread for communication with the server
        public volatile bool terminated;                                            // necessary to stop the thread
        public ushort CountError { get; private set; }                              // error counter
        #endregion Thread

        #region Asynchronous TCP server
        /// <summary>
        /// Asynchronous TCP server
        /// <para>Асинхронный TCP сервер<para>
        /// </summary>
        private ListAsyncTCPServer listAsyncTCPServer = new ListAsyncTCPServer();
        AsyncTCPServer atcpserver;
        private int gatewaytypeprotocol = 0;
        private int gatewayport = 60000;
        private int gatewayсonnectedclientsmax = 10;
        private Guid gatewayid;
        #endregion Asynchronous TCP server

        #region EventDevicePollTxRx
        /// <summary>
        /// Receiving and transmitting information about RxTx
        /// <para>Получение и передача информации о RxTx<para>
        /// </summary>
        public static EventDevicePollTxRx EventHandlerEventDevicePollTxRx;
        public delegate void EventDevicePollTxRx(Guid id, string type, int count);
        internal void DebugerTxRx(string type, int count)
        {
            if (EventHandlerEventDevicePollTxRx == null)
            {
                return;
            }

            EventHandlerEventDevicePollTxRx(Channel.ID, type, count);
        }
        #endregion EventDevicePollTxRx

        #region DebugerLog
        /// <summary>
        /// Getting logs
        /// <para>Получение лога<para>
        /// </summary>
        public static DebugData OnDebug;
        public delegate void DebugData(Guid id, string msg);
        internal void DebugerLog(string text)
        {
            if (OnDebug == null)
            {
                return;
            }

            OnDebug(Channel.ID, text);
        }
        #endregion DebugerLog

        #region SendTagValue
        /// <summary>
        /// Getting value in server
        /// <para>Передача значений на сервер<para>
        /// </summary>
        public static SendValue OnSendValue;
        public delegate void SendValue(string tagCode, object tagVal, int tagStat);
        internal void ServerSendValue(string tagCode, object tagVal, int tagStat)
        {
            OnSendValue(tagCode, tagVal, tagStat);
        }

        #endregion SendTagValue

        #region UpdateInfoAsyncTCPServer
        /// <summary>
        /// Getting information from a TCP server
        /// <para>Получение информации с TCP сервера<para>
        /// </summary>
        public static DebugDataTCPServer OnDebugTCPServer;
        public delegate void DebugDataTCPServer(string msg);
        internal void UpdateInfoAsyncTCPServer(string ip, AsyncTCPServer.ConnectionStatus status, string text)
        {
            try
            {
                string tmp_status = string.Empty;
                if (status == AsyncTCPServer.ConnectionStatus.add)
                {
                    tmp_status = "[Подключено]";
                }
                else if (status == AsyncTCPServer.ConnectionStatus.delete)
                {
                    tmp_status = "[Отключено ]";
                }
                else if (status == AsyncTCPServer.ConnectionStatus.info)
                {
                    tmp_status = "[Информация]";
                }
                else if (status == AsyncTCPServer.ConnectionStatus.received)
                {
                    tmp_status = "[Получено  ]";
                }
                else if (status == AsyncTCPServer.ConnectionStatus.sended)
                {
                    tmp_status = "[Отправлено]";
                }

                string result = "" + tmp_status + "[" + text + "]";

                OnDebugTCPServer(result);
            }
            catch { }
        }
        #endregion UpdateInfoAsyncTCPServer

        #endregion Variables

        public DriverClient()
        {
            this.Channel = new ProjectChannel();
            this.Devices = new List<ProjectDevice>();
            this.Device = new ProjectDevice();
            this.GroupCommands = new List<ProjectGroupCommand>();
            this.GroupCommand = new ProjectGroupCommand();
            this.Commands = new List<ProjectCommand>();
            this.Command = new ProjectCommand();
            this.GroupTags = new List<ProjectGroupTag>();
            this.GroupTag = new ProjectGroupTag();
            this.Tags = new List<ProjectTag>();
            this.Tag = new ProjectTag();
        }



        public DriverClient(ProjectChannel channel)
        {
            this.Channel = channel;
            this.Devices = Channel.Devices;
        }


        #region Initializing
        public bool InitializingDriver()
        {
            try
            {
                //channel = project.Settings.ProjectChannel;
                //devices = project.Settings.ProjectDevice;
                //groupCommands = project.Settings.ProjectGroupCommand;
                //commands = project.Settings.ProjectCommand;
                //groupTags = project.Settings.ProjectGroupTag;
                //tags = project.Settings.ProjectTag;

                DriverPhrases.Init();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion Initializing

        #region Execute
        /// <summary>
        /// Operating cycle running in a separate thread.
        /// </summary>
        public void ExecuteCycle(object obj)
        {
            #region Поток
            //Проверка условия должен ли поток работать (в цикле)
            do
            {
                Execute(obj);
            } 
            while (Channel.ThreadEnabled == true);

            #endregion Поток
        }

        /// <summary>
        /// Operating running in a separate thread.
        /// </summary>
        public void Execute(object obj)
        {

            string errMsg = string.Empty;

            #region TCPServer
            ////Передаем настройки Шлюза из свойств канала
            //gatewaytypeprotocol = Channel.GatewayTypeProtocol; //Тип протокола Шлюза 0 - выключен
            //gatewayport = Channel.GatewayPort; //Порт
            //gatewayсonnectedclientsmax = Channel.GatewayConnectedClientsMax; //Максимальное количество подключений
            //gatewayid = Channel.ID; //ID канала

            ////Если поставлен признак не "Не задан" = 0, то значит выбран режим и нужно запустить 
            //if (Channel.GatewayTypeProtocol != 0)
            //{
            //    //Передаем параметры в переменные
            //    gatewayport = Channel.GatewayPort;
            //    gatewayсonnectedclientsmax = Channel.GatewayConnectedClientsMax;
            //    //Если TCP сервер не запущен, то запускаем
            //    if (Channel.ThreadEnabled == true)
            //    {
            //        TCPServerStart();
            //    }
            //    else
            //    {
            //        TCPServerStop();
            //    }
            //}
            #endregion TCPServer

            #region Опрос устройств
            try
            {
                DebugerLog("[" + DriverUtils.Version + "]");

                if (Channel == null || Devices == null)
                {
                    return;
                }

                //Название канала
                string name = Channel.Name;
                bool debug = Channel.Debug;

                //Текущее устройство
                for (int d = 0; d < Devices.Count; d++)
                {
                    Device = Devices[d];

                    DebugerLog("[" + name + "] - [" + Device.Name + "]");

                    //Если устройство выключено, то пропускаем
                    if (Device.Enabled == false)
                    {
                        goto WORKEND;
                    }

                    ProjectGroupCommand groupCommnad = Device.GroupCommand;
                    List<ProjectCommand> lstCommands = groupCommnad.ListCommands;
                    for (int comi = 0; comi < lstCommands.Count; comi++)
                    {
                        #region Команда
                        ProjectCommand command = lstCommands[comi];
                        //Если команда выключена, то пропускаем
                        if (command.Enabled == false)
                        {
                            continue;
                        }

                        //Передаём время опроса
                        Device.DateTimeCommandLast = DateTime.Now;
                        CountError = 0;
                    #endregion Команда

                    //Начало работы логики
                    STEP_REPEAT_COMMAND:
                        //Счетчик
                        ++CountError;

                        DebugerLog("[" + command.Name + "]");

                        if (debug)
                        {
                            DebugerLog("[Debug]");
                            DebugerLog("[FunctionCod][" + command.FunctionCode + "]");
                            DebugerLog("[RegisterStartAddress][" + command.RegisterStartAddress + "]");
                            DebugerLog("[RegisterCount][" + command.RegisterCount + "]");
                        }

                        #region Переменные
                        //Лог
                        string logText = string.Empty;
                        //Сообщение ошибки
                        errMsg = string.Empty;
                        //Буфер данных запроса
                        byte[] bufferSender = new byte[Channel.WriteBufferSize];
                        //Буфер данных ответа
                        byte[] bufferReceiver = new byte[Channel.ReadBufferSize];
                        //Номер байта с объемом полученных данных
                        int byteNumberFunctionReceived = 0;
                        int byteNumberAmountDataReceived = 0;
                        //Массив регистров для вставки в буфер
                        byte[] numArrayRegisters = (byte[])null;
                        //Сообщение о валидатности данных или ошибке
                        string validateMessage = string.Empty;
                        //Признак корректности полученных данных
                        bool validate = true;
                        //номер адреса регистра
                        ulong regAddr = 0;
                        string regAddrStr = string.Empty;
                        //Количество регистров 2х байтные или 4х байтные
                        ulong deviceRegistersBytes = (ulong)Device.DeviceRegistersBytes;
                        DebugerLog("[RegistersBytes][" + deviceRegistersBytes + "]");

                        #endregion Переменные

                        #region Протокол

                        //ModbusRTU
                        ModbusRTU masterRTU = new ModbusRTU();
                        //ModbusTCP
                        ModbusTCP masterTCP = new ModbusTCP();
                        //ModbusASCII
                        ModbusASCII masterASCII = new ModbusASCII();

                        switch (Device.Protocol)
                        {
                            case DriverProtocol.None:
                                // Пусто
                                DebugerLog(DriverPhrases.NoProtocol);
                                continue;
                            case DriverProtocol.ModbusRTU:
                                //Формирование буфера данных запроса
                                bufferSender = masterRTU.CalculateSendData(Device.Address, (ushort)command.FunctionCode, (ushort)command.RegisterStartAddress, (ushort)command.RegisterCount, command.RegisterWriteData);
                                byteNumberFunctionReceived = masterRTU.byteNumberFunctionReceived;
                                byteNumberAmountDataReceived = masterRTU.byteNumberAmountDataReceived;
                                DebugerLog(DriverPhrases.Request + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                                break;
                            case DriverProtocol.ModbusTCP:
                                //Формирование буфера данных запроса
                                bufferSender = masterTCP.CalculateSendData(Device.Address, (ushort)command.FunctionCode, (ushort)command.RegisterStartAddress, (ushort)command.RegisterCount, command.RegisterWriteData);
                                byteNumberFunctionReceived = masterTCP.byteNumberFunctionReceived;
                                byteNumberAmountDataReceived = masterTCP.byteNumberAmountDataReceived;
                                DebugerLog(DriverPhrases.Request + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                                break;
                            case DriverProtocol.ModbusASCII:
                                //Формирование буфера данных запроса
                                bufferSender = masterASCII.CalculateSendData(Device.Address, (ushort)command.FunctionCode, (ushort)command.RegisterStartAddress, (ushort)command.RegisterCount, command.RegisterWriteData);
                                byteNumberFunctionReceived = masterASCII.byteNumberFunctionReceived;
                                byteNumberAmountDataReceived = masterASCII.byteNumberAmountDataReceived;
                                DebugerLog(DriverPhrases.Request + "[ASCII][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "][HEX][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferSender)) + "]");
                                break;
                            default:
                                continue;
                        }

                        #endregion Протокол

                        #region Тип канала (отправка и получение данных)

                        switch (Channel.TypeClient)
                        {
                            case CommunicationClient.None:
                                //Пусто
                                DebugerLog(DriverPhrases.NoType);
                                continue;
                            case CommunicationClient.SerialPort:
                                // Последовательный порт
                                using (SerialPortClient serialClient = new SerialPortClient(
                                    Channel.SerialPortSettings.SerialPortName,
                                    Channel.SerialPortSettings.SerialPortBaudRate,
                                    Channel.SerialPortSettings.SerialPortParity,
                                    Channel.SerialPortSettings.SerialPortDataBits,
                                    Channel.SerialPortSettings.SerialPortStopBits,
                                    Channel.SerialPortSettings.SerialPortHandshake,
                                    Channel.SerialPortSettings.SerialPortDtrEnable,
                                    Channel.SerialPortSettings.SerialPortRtsEnable,
                                    Channel.SerialPortSettings.SerialPortReceivedBytesThreshold,
                                    Channel.WriteTimeout,
                                    Channel.ReadTimeout,
                                    Channel.WriteBufferSize,
                                    Channel.ReadBufferSize
                                    ))
                                {
                                    //Отправка команды
                                    serialClient.Data(bufferSender, ref bufferReceiver, ref errMsg);
                                }
                                break;
                            case CommunicationClient.TcpClient:
                                // TCP клиент
                                using (TCPClient tcpclient = new TCPClient(Channel.EthernetClientSettings.ClientHost, Channel.EthernetClientSettings.ClientPort, Channel.WriteTimeout, Channel.ReadTimeout, Channel.WriteBufferSize, Channel.ReadBufferSize, ExecutionMode.Synchronous))
                                {
                                    //Отправка команды
                                    tcpclient.Data(bufferSender, ref bufferReceiver, ref errMsg);
                                }
                                break;
                            case CommunicationClient.UdpClient:
                                // UDP клиент
                                using (UDPClient udpclient = new UDPClient(Channel.EthernetClientSettings.ClientHost, Channel.EthernetClientSettings.ClientPort, Channel.WriteTimeout, Channel.ReadTimeout))
                                {
                                    //Отправка команды
                                    udpclient.Data(bufferSender, ref bufferReceiver, ref errMsg);
                                }
                                break;
                            default:
                                continue;
                        }

                        if (errMsg != string.Empty)
                        {
                            DebugerLog(errMsg);
                            goto ERROR;
                        }

                        #endregion Тип канала (отправка и получение данных)

                        #region Протокол

                        switch (Device.Protocol)
                        {
                            case DriverProtocol.None:

                                continue;

                            case DriverProtocol.ModbusRTU:

                                #region Проверка валидатности данных
                                //Проверка корректности поступленных данных
                                try
                                {
                                    if (bufferReceiver == null)
                                    {
                                        Device.Status = 2;
                                        goto ERROR;
                                    }

                                    validate = masterRTU.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                                    DebugerLog(DriverPhrases.Response + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                                    if (validate)
                                    {
                                        numArrayRegisters = masterRTU.DecodeData(bufferReceiver);
                                        if (debug)
                                        {
                                            DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters) + "]");
                                        }
                                    }
                                    else
                                    {
                                        Device.Status = 2;
                                        goto ERROR;
                                    }
                                }
                                catch
                                {
                                    goto ERROR;
                                }
                                #endregion Проверка валидатности данных

                                break;
                            case DriverProtocol.ModbusTCP:

                                #region Проверка валидатности данных
                                //Проверка корректности поступленны данных  
                                try
                                {
                                    if (bufferReceiver == null)
                                    {
                                        Device.Status = 2;
                                        goto ERROR;
                                    }

                                    validate = masterTCP.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                                    DebugerLog(DriverPhrases.Response + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                                    if (validate)
                                    {
                                        numArrayRegisters = masterTCP.DecodeData(bufferReceiver);
                                        if (debug)
                                        {
                                            DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters) + "]");
                                        }
                                    }
                                    else
                                    {
                                        Device.Status = 2;
                                        goto ERROR;
                                    }
                                }
                                catch
                                {
                                    goto ERROR;
                                }
                                #endregion Проверка валидатности данных

                                break;
                            case DriverProtocol.ModbusASCII:

                                #region Проверка валидатности данных
                                try
                                {
                                    //Проверка корректности поступленны данных
                                    if (bufferReceiver == null)
                                    {
                                        Device.Status = 2;
                                        goto ERROR;
                                    }

                                    validate = masterASCII.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                                    DebugerLog(DriverPhrases.Response + "[ASCII][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "][HEX][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferReceiver)) + "]" + validateMessage + "");
                                    bufferReceiver = HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferReceiver);

                                    if (validate)
                                    {
                                        numArrayRegisters = masterASCII.DecodeData(bufferReceiver);
                                        if (debug)
                                        {
                                            DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters) + "]");
                                        }
                                    }
                                    else
                                    {
                                        Device.Status = 2;
                                        goto ERROR;
                                    }
                                }
                                catch
                                {
                                    goto ERROR;
                                }
                                #endregion Проверка валидатности данных

                                break;
                            default:
                                continue;

                        }

                        #endregion Протокол

                        #region Качество (статус)
                        //Записываем данные
                        //Если данные не получили
                        if (numArrayRegisters == null)
                        {
                            //Переводим в Offline
                            Device.Status = 2;
                        }
                        else if (numArrayRegisters != null)
                        {
                            //Переводим в Online
                            Device.Status = 1;
                            //Передаём дату успешного опроса
                            Device.DateTimeCommandLastGood = DateTime.Now;
                            Device.DateTimeLastSuccessfully = DateTime.Now;
                        }
                        #endregion Качество (статус)

                        #region Расшифровка

                        switch (command.FunctionCode)
                        {
                            case 0:
                                continue;
                            case 1:

                                #region Write Data Coils
                                bool[] Coils = HEX_BOOLEAN.ToArray(numArrayRegisters);
                                for (int index = 0; index < Coils.Length; ++index)
                                {
                                    Device.SetCoil((ulong)((ulong)command.RegisterStartAddress + (ulong)index), Coils[index]);
                                }
                                #endregion Write Data Coils

                                break;
                            case 2:

                                #region Write Data DiscreteInput
                                bool[] DiscreteInputs = HEX_BOOLEAN.ToArray(numArrayRegisters);

                                for (int index = 0; index < DiscreteInputs.Length; ++index)
                                {
                                    Device.SetDiscreteInput((ulong)(ulong)(command.RegisterStartAddress + (ulong)index), DiscreteInputs[index]);
                                }
                                #endregion Write Data DiscreteInput

                                break;
                            case 3:

                                #region Write Data HoldingRegister

                                for (ulong index = 0; (ulong)index < (ulong)numArrayRegisters.Length / deviceRegistersBytes; ++index)
                                {
                                    ulong RegAddr = ((ulong)command.RegisterStartAddress + (ulong)index);
                                    byte[] ArrData = HEX_OPERATION.BYTEARRAY_SEARCH(numArrayRegisters, (int)index * (int)deviceRegistersBytes, (int)deviceRegistersBytes);
                                    Device.SetHoldingRegister(ArrData, RegAddr, deviceRegistersBytes);
                                }

                                #endregion Write Data HoldingRegister

                                break;
                            case 4:

                                #region Write Data InputRegister

                                for (ulong index = 0; (ulong)index < (ulong)numArrayRegisters.Length / deviceRegistersBytes; ++index)
                                {
                                    ulong RegAddr = ((ulong)command.RegisterStartAddress + (ulong)index);
                                    byte[] ArrData = HEX_OPERATION.BYTEARRAY_SEARCH(numArrayRegisters, (int)index * (int)deviceRegistersBytes, (int)deviceRegistersBytes);
                                    Device.SetInputRegister(ArrData, RegAddr, deviceRegistersBytes);
                                }

                                #endregion Write Data InputRegister

                                break;
                            default:
                                continue;
                        }



                        #endregion Расшифровка

                        #region  Поиск тегов

                        for (ushort i = (ushort)command.RegisterStartAddress; i < (ushort)command.RegisterCount - (ushort)command.RegisterStartAddress; i++)
                        {
                            byte[] bytes = new byte[0];
                            ulong addressRegister = command.RegisterStartAddress + (ulong)i;
                            string addressTag = ((ushort)command.FunctionCode).ToString() + ((ushort)command.RegisterStartAddress + (ushort)i).ToString("00000");
                            Tag = Device.GroupTag.ListTags.Where(t => t.Address.StartsWith(addressTag)).FirstOrDefault();
                                     
                            if(Tag != null)
                            {
                                ulong countRegisterTypeData = (ulong)ProjectTag.FormatDataRegisterCount(Tag, (int)deviceRegistersBytes);

                                switch ((ushort)command.FunctionCode)
                                {
                                    case (ushort)1:
                                       bool coil = Device.GetBooleanCoil(addressRegister);
                                        bytes = HEX_BOOLEAN.ToArray(coil);
                                    break;
                                    case (ushort)2:
                                        bool discreteInput = Device.GetBooleanDiscreteInput(addressRegister);
                                        bytes = HEX_BOOLEAN.ToArray(discreteInput);
                                        break;
                                    case (ushort)3:
                                        bytes = Device.GetUlongHoldingRegister(addressRegister, countRegisterTypeData);
                                        break;
                                    case (ushort)4:
                                        bytes = Device.GetUlongInputRegister(addressRegister, countRegisterTypeData);
                                        break;
                                }

                               Tag.DataValue = ProjectTag.GetValue(Tag, bytes);
                            }
                        }



                        #endregion Поиск тегов

                        #region Запись данных



                        #endregion Запись данных

                        if (Device.Status == 1)
                        {
                            goto NEXTCOMMAND;
                        }

                    #region Обработка ошибок
                    ERROR:

                        if (CountError == Channel.CountError)
                        {
                            CountError = 0;

                            DebugerLog(DriverPhrases.ExecutedError);

                            #region Old
                            //switch (command.FunctionCode)
                            //{
                            //    case 0:
                            //        continue;
                            //    case ulong n when (n >= 1 && n <= 16):



                            //        break;
                            //    case ulong n when (n >= 80 && n <= 96):

                            //        List<ProjectTag> findTags = tags.Where(r => r.CommandID == command.ID).ToList();
                            //        if (findTags != null && findTags.Count > 0)
                            //        {
                            //            for (int t = 0; t < findTags.Count; t++)
                            //            {
                            //                if (debug)
                            //                {
                            //                    DebugerLog("[" + findTags[t].Code + "][Bad]");
                            //                }

                            //                ServerSendValue(findTags[t].Code, 0, 0);
                            //            }
                            //        }

                            //        break;
                            //    default:
                            //        continue;
                            //}
                            #endregion Old

                            continue;
                        }
                        else
                        {
                            goto STEP_REPEAT_COMMAND;
                        }
                    #endregion Обработка ошибок

                    NEXTCOMMAND:
                        try { } catch { }
                    }

                }

            NEXTDEVICE:
                try { } catch { }


            }
            catch (Exception ex)
            {
                try
                {
                    errMsg = DriverUtils.InfoError(ex);
                    DebugerLog("[ERROR] [" + errMsg + "]");

                }
                catch { }

            }
            finally
            {
                //Время между пакетами
                Thread.Sleep(Channel.Timeout);
            }

        WORKEND:
            try { } catch { }
            #endregion Опрос устройств

        }
        #endregion Execute

        #region Timeout
       private void TimeOut()
        {
            #region Timeout time between commands
            // waiting start time
            // время начала ожидания
            long channel_timeout_start = Environment.TickCount;
            // waiting end time
            // время окончания ожидания
            long channel_timeout_stop = channel_timeout_start + Convert.ToInt64(Channel.Timeout);
            // the cycle begins, which runs until: - the time runs out
            // начинается цикл, который работает до тех пор пока: - не выйдет время
            while (Environment.TickCount < channel_timeout_stop)
            {
                goto CHANNEL_TIMEOUT_END;
            }
        CHANNEL_TIMEOUT_END:
            try { } catch { }
            #endregion Timeout time between commands
        }
        #endregion Timeout

        #region TCPServer

        public void TCPServerStart()
        {
            var th = new Thread(TCPServerRun)
            {
                Priority = ThreadPriority.Highest
            };
            th.Start();
        }

        public void TCPServerStop()
        {
            if (atcpserver != null)
            {
                atcpserver.Stop();
            }
        }

        private void TCPServerRun()
        {
            try
            {
                atcpserver = new AsyncTCPServer(gatewaytypeprotocol, gatewayport, gatewayсonnectedclientsmax, gatewayid);
                atcpserver.Debuger += UpdateInfoAsyncTCPServer;
                atcpserver.Run();

                ListAsyncTCPServer.AsyncTCPServers.Add(atcpserver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion TCPServer

        #region Buffer

        #region Буфер данных

        #region Чтение буфера данных

        public void BufferDataDefaultRead()
        {
            string filePath = ""; //Application.StartupPath + "\\DevicesBuffer.xCGbuf";
            TextReader textReader = (TextReader)null;

            try
            {
                //Если файла нет, то создаем
                if (!File.Exists(filePath))
                {
                    TextWriter textWriter = (TextWriter)null;
                    List<string> stringList = new List<string>();
                    try
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                        textWriter = (TextWriter)new StreamWriter(filePath, false);
                        xmlSerializer.Serialize(textWriter, (object)stringList);
                    }
                    finally
                    {
                        if (textWriter != null)
                        {
                            textWriter.Close();
                        }
                    }
                }


                if (File.Exists(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                    textReader = (TextReader)new StreamReader(filePath);
                    List<string> stringList = (List<string>)xmlSerializer.Deserialize(textReader);

                    foreach (string str in stringList)
                    {
                        char[] chArray = new char[1] { ';' };
                        string[] strArray = str.Split(chArray);
                        ProjectDevice Device = new ProjectDevice();
                        Device.ID = new Guid(strArray[0]);
                        ProjectDevice tmpDevice = Channel.Devices.Find((Predicate<ProjectDevice>)(r => r.ID.ToString() == Device.ID.ToString()));

                        if (tmpDevice == null)
                        {
                            //Debuger.Log("В списке устройств не обнаружено устройство c ID [" + Device.ID+ "], которому добавляет информация из буфера данных!");
                            return;
                        }

                        if (strArray[2] == "CoilRegister")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                bool Value = (bool)Convert.ToBoolean(strArray[3]);
                                tmpDevice.SetCoil(RegAdres, Value);
                            }
                            catch { }
                        }

                        if (strArray[2] == "DiscreteInput")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                bool Value = (bool)Convert.ToBoolean(strArray[3]);
                                tmpDevice.SetDiscreteInput(RegAdres, Value);
                            }
                            catch { }
                        }


                        if (strArray[2] == "HoldingRegister")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                ushort Value = Convert.ToUInt16(strArray[3]);
                                tmpDevice.SetHoldingRegister(RegAdres, Value);
                            }
                            catch { }
                        }

                        if (strArray[2] == "InputRegister")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                ushort Value = Convert.ToUInt16(strArray[3]);
                                tmpDevice.SetInputRegister(RegAdres, Value);
                            }
                            catch { }
                        }
                    }
                }
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
        }

        public void BufferDataRead(string filePath)
        {
            TextReader textReader = (TextReader)null;

            try
            {
                //Если файла нет, то создаем
                if (!File.Exists(filePath))
                {
                    TextWriter textWriter = (TextWriter)null;
                    List<string> stringList = new List<string>();
                    try
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                        textWriter = (TextWriter)new StreamWriter(filePath, false);
                        xmlSerializer.Serialize(textWriter, (object)stringList);
                    }
                    finally
                    {
                        if (textWriter != null)
                        {
                            textWriter.Close();
                        }
                    }
                }


                if (File.Exists(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                    textReader = (TextReader)new StreamReader(filePath);
                    List<string> stringList = (List<string>)xmlSerializer.Deserialize(textReader);

                    foreach (string str in stringList)
                    {
                        char[] chArray = new char[1] { ';' };
                        string[] strArray = str.Split(chArray);
                        ProjectDevice Device = new ProjectDevice();
                        Device.ID= new Guid(strArray[0]);
                        ProjectDevice tmpDevice = Channel.Devices.Find((Predicate<ProjectDevice>)(r => r.ID.ToString() == Device.ID.ToString()));

                        if (tmpDevice == null)
                        {
                            return;
                        }

                        if (strArray[2] == "CoilRegister")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                bool Value = (bool)Convert.ToBoolean(strArray[3]);
                                tmpDevice.SetCoil(RegAdres, Value);
                            }
                            catch { }
                        }

                        if (strArray[2] == "DiscreteInput")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                bool Value = (bool)Convert.ToBoolean(strArray[3]);
                                tmpDevice.SetDiscreteInput(RegAdres, Value);
                            }
                            catch { }
                        }


                        if (strArray[2] == "HoldingRegister")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                ushort Value = Convert.ToUInt16(strArray[3]);
                                tmpDevice.SetHoldingRegister(RegAdres, Value);
                            }
                            catch { }
                        }

                        if (strArray[2] == "InputRegister")
                        {
                            try
                            {
                                ushort RegAdres = Convert.ToUInt16(Convert.ToInt16(strArray[1]));
                                ushort Value = Convert.ToUInt16(strArray[3]);
                                tmpDevice.SetInputRegister(RegAdres, Value);
                            }
                            catch { }
                        }
                    }
                }
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
        }

        #endregion Чтение буфера данных

        #region Сохранение буфера данных

        public void BufferDataDefaultWrite()
        {
            string filePath = ""; // Application.StartupPath + @$"\DevicesBuffer.drvBuf";
            List<string> stringList = new List<string>();
            TextWriter textWriter = (TextWriter)null;

            #region Создание файла
            //Если файла нет, то создаем
            if (!File.Exists(filePath))
            {

                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                    textWriter = (TextWriter)new StreamWriter(filePath, false);
                    xmlSerializer.Serialize(textWriter, (object)stringList);
                }
                finally
                {
                    if (textWriter != null)
                    {
                        textWriter.Close();
                    }
                }
            }
            #endregion Создание файла

            #region Проходимся по списку устройств
            try
            {
                    //Если устройство действительно найдено
                    if (Device != null)
                    {
                        //В зависимости он настроек, сохраняем необходимое количество
                        for (int index = 0; index < 65535; ++index)
                        {
                            //Coils
                            if (Device.CoilsExists(Convert.ToUInt16(index)))
                            {
                                string TextCoilsID = (index).ToString();
                                string TextCoilsWord = Device.GetBooleanCoil(Convert.ToUInt16(index)).ToString();

                                stringList.Add(Device.ID.ToString() + ";" + TextCoilsID + ";" + "CoilRegister;" + TextCoilsWord + ";");
                            }

                            //DiscreteInputs
                            if (Device.DiscreteInputsExists(Convert.ToUInt16(index)))
                            {
                                string TextDiscreteInputsID = (index).ToString();
                                string TextDiscreteInputsWord = Device.GetBooleanDiscreteInput(Convert.ToUInt16(index)).ToString();

                                stringList.Add(Device.ID.ToString() + ";" + TextDiscreteInputsID + ";" + "DiscreteInput;" + TextDiscreteInputsWord + ";");
                            }

                            //HoldingRegisters
                            if (Device.HoldingRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextHoldingID = (index).ToString();
                                string TextHoldingWord = Device.GetUlongHoldingRegister(Convert.ToUInt16(index)).ToString();

                                stringList.Add(Device.ID.ToString() + ";" + TextHoldingID + ";" + "HoldingRegister;" + TextHoldingWord + ";");
                            }

                            //InputRegisters
                            if (Device.InputRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextInputID = (index).ToString();
                                string TextInputWord = Device.GetUlongHoldingRegister(Convert.ToUInt16(index)).ToString();

                                stringList.Add(Device.ID.ToString() + ";" + TextInputID + ";" + "InputRegister;" + TextInputWord + ";");
                            }
                        }
                    }
                
            }
            catch (Exception ex)
            {
                DebugerLog(ex.ToString());
            }
            #endregion Проходимся по списку устройств

            #region Запись в файл
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                textWriter = (TextWriter)new StreamWriter(filePath, false);
                xmlSerializer.Serialize(textWriter, (object)stringList);
            }
            finally
            {
                if (textWriter != null)
                {
                    textWriter.Close();
                }
            }
            #endregion Запись в файл
        }

        #endregion Сохранение буфера данных

        #endregion Буфер данных

        #endregion Buffer

    }

}