using CommunicationMethods;
using Scada.Comm.Devices;
using Scada.Data.Entities;
using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Xml.Serialization;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    internal class DriverClient
    {
        #region Variables
        /// <summary>
        /// The application directories
        /// <para>Каталоги приложения</para>
        /// </summary>
        public AppDirs appDirs;
        /// <summary>
        /// The driver code
        /// <para>Код драйвера</para>
        /// </summary>
        public string driverCode;
        /// <summary>
        /// The device number
        /// <para>Номер устройства</para>
        /// </summary>
        public int deviceNum;
        /// <summary>
        /// Name configuration file
        /// <para>Название файл конфигурации</para>
        /// </summary>
        public string shortFileName;
        /// <summary>
        /// Project configuration
        /// <para>Конфигурация проекта</para>
        /// </summary>
        public Project project;
        /// <summary>
        /// Channel
        /// <para>Канал</para>
        /// </summary>
        private ProjectChannel channel;
        public ProjectChannel Channel
        {
            get { return channel; }
            set { channel = value; }
        }

        ////////////////////////////////////////

        /// <summary>
        /// Devices
        /// <para>Устройства</para>
        /// </summary>
        private List<ProjectDevice> devices;
        public List<ProjectDevice> Devices
        {
            get { return devices; }
            set { devices = value; }
        }

        /// <summary>
        /// Devices
        /// <para>Устройства</para>
        /// </summary>
        private ProjectDevice device;
        public ProjectDevice Device
        {
            get { return device; }
            set { device = value; }
        }

        ////////////////////////////////////////

        /// <summary>
        /// Commands Group
        /// <para>Группа команд</para>
        /// </summary>
        private List<ProjectGroupCommand> groupCommands;
        public List<ProjectGroupCommand> GroupCommands
        {
            get { return groupCommands; }
            set { groupCommands = value; }
        }

        /// <summary>
        /// Commands Group
        /// <para>Группа команд</para>
        /// </summary>
        private ProjectGroupCommand deviceGroupCommand;
        public ProjectGroupCommand GroupCommand
        {
            get { return deviceGroupCommand; }
            set { deviceGroupCommand = value; }
        }

        ////////////////////////////////////////

        /// <summary>
        /// Command
        /// <para>Команды</para>
        /// </summary>
        private List<ProjectCommand> commands;
        public List<ProjectCommand> Commands
        {
            get { return commands; }
            set { commands = value; }
        }

        /// <summary>
        /// Command
        /// <para>Команда</para>
        /// </summary>
        private ProjectCommand command;
        public ProjectCommand Command
        {
            get { return command; }
            set { command = value; }
        }

        ////////////////////////////////////////

        /// <summary>
        /// Tags Group
        /// <para>Группа тегов</para>
        /// </summary>
        private List<ProjectGroupTag> groupTags;
        public List<ProjectGroupTag> DeviceGroupTags
        {
            get { return groupTags; }
            set { groupTags = value; }
        }

        /// <summary>
        /// Tags Group
        /// <para>Группа тегов</para>
        /// </summary>
        private ProjectGroupTag groupTag;
        public ProjectGroupTag DeviceGroupTag
        {
            get { return groupTag; }
            set { groupTag = value; }
        }

        ////////////////////////////////////////

        /// <summary>
        /// Tag
        /// <para>Тег</para>
        /// </summary>
        private List<ProjectTag> tags;
        public List<ProjectTag> DeviceTags
        {
            get { return tags; }
            set { tags = value; }
        }

        /// <summary>
        /// Tag
        /// <para>Тег</para>
        /// </summary>
        private ProjectTag tag;
        public ProjectTag DeviceTag
        {
            get { return tag; }
            set { tag = value; }
        }


        /// <summary>
        /// Driver Tag
        /// <para>Тег драйвера</para>
        /// </summary>
        private List<CnlPrototypeGroup> driverTags;

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

            EventHandlerEventDevicePollTxRx(channel.ID, type, count);
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

            OnDebug(channel.ID, text);
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

        }



        public DriverClient(ProjectChannel channel)
        {
            this.channel = channel;
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
            while (channel.ThreadEnabled == true);

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
            //gatewaytypeprotocol = channel.GatewayTypeProtocol; //Тип протокола Шлюза 0 - выключен
            //gatewayport = channel.GatewayPort; //Порт
            //gatewayсonnectedclientsmax = channel.GatewayConnectedClientsMax; //Максимальное количество подключений
            //gatewayid = channel.ID; //ID канала

            ////Если поставлен признак не "Не задан" = 0, то значит выбран режим и нужно запустить 
            //if (channel.GatewayTypeProtocol != 0)
            //{
            //    //Передаем параметры в переменные
            //    gatewayport = channel.GatewayPort;
            //    gatewayсonnectedclientsmax = channel.GatewayConnectedClientsMax;
            //    //Если TCP сервер не запущен, то запускаем
            //    if (channel.ThreadEnabled == true)
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

                if (channel == null || devices == null)
                {
                    return;
                }

                //Название канала
                string name = channel.Name;
                bool debug = channel.Debug;

                //Текущее устройство
                for (int d = 0; d < devices.Count; d++)
                {
                    device = devices[d];

                    DebugerLog("[" + name + "] - [" + device.Name + "]");

                    //Если устройство выключено, то пропускаем
                    if (device.Enabled == false)
                    {
                        goto WORKEND;
                    }

                    List<ProjectGroupCommand> lstGroupCommnad = groupCommands.Where(gc => gc.ParentID == device.ID).ToList();
                    for (int g = 0; g < lstGroupCommnad.Count; g++)
                    {
                        ProjectGroupCommand groupCommand = lstGroupCommnad[g];

                        List<ProjectCommand> lstCommands = commands.Where(c => c.ParentID == groupCommand.ID).ToList();
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
                            device.DateTimeCommandLast = DateTime.Now;
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
                                //DebugerLog("[Parametr][" + command.Parametr + "]");
                                DebugerLog("[RegisterStartAddress][" + command.RegisterStartAddress + "]");
                                DebugerLog("[RegisterCount][" + command.RegisterCount + "]");
                            }

                            #region Переменные
                            //Лог
                            string logText = string.Empty;
                            //Сообщение ошибки
                            errMsg = string.Empty;
                            //Буфер данных запроса
                            byte[] bufferSender = new byte[channel.WriteBufferSize];
                            //Буфер данных ответа
                            byte[] bufferReceiver = new byte[channel.ReadBufferSize];
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
                            ulong deviceRegistersBytes = (ulong)device.DeviceRegistersBytes;
                            DebugerLog("[RegistersBytes][" + deviceRegistersBytes + "]");

                            #endregion Переменные

                            #region Протокол

                            //ModbusRTU
                            ModbusRTU masterRTU = new ModbusRTU();
                            //ModbusTCP
                            ModbusTCP masterTCP = new ModbusTCP();
                            //ModbusASCII
                            ModbusASCII masterASCII = new ModbusASCII();
                            //VTD
                            VTD masterVTD = new VTD();

                            //switch (device.TypeProtocol)
                            //{
                            //    case 0:
                            //        // Пусто
                            //        DebugerLog(DriverPhrases.NoProtocol);
                            //        continue;
                            //    case 1:
                            //        //Формирование буфера данных запроса
                            //        bufferSender = masterRTU.CalculateSendData(device.Address, (ushort)command.FunctionCode, (ushort)command.RegisterStartAddress, (ushort)command.RegisterCount, DriverUtils.ConvertUlongToUshort(command.RegisterWriteData));
                            //        byteNumberFunctionReceived = masterRTU.byteNumberFunctionReceived;
                            //        byteNumberAmountDataReceived = masterRTU.byteNumberAmountDataReceived;
                            //        DebugerLog(DriverPhrases.Request + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                            //        break;
                            //    case 2:
                            //        //Формирование буфера данных запроса
                            //        bufferSender = masterTCP.CalculateSendData(device.Address, (ushort)command.FunctionCode, (ushort)command.RegisterStartAddress, (ushort)command.RegisterCount, DriverUtils.ConvertUlongToUshort(command.RegisterWriteData));
                            //        byteNumberFunctionReceived = masterTCP.byteNumberFunctionReceived;
                            //        byteNumberAmountDataReceived = masterTCP.byteNumberAmountDataReceived;
                            //        DebugerLog(DriverPhrases.Request + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                            //        break;
                            //    case 3:
                            //        //Формирование буфера данных запроса
                            //        bufferSender = masterASCII.CalculateSendData(device.Address, (ushort)command.FunctionCode, (ushort)command.RegisterStartAddress, (ushort)command.RegisterCount, DriverUtils.ConvertUlongToUshort(command.RegisterWriteData));
                            //        byteNumberFunctionReceived = masterASCII.byteNumberFunctionReceived;
                            //        byteNumberAmountDataReceived = masterASCII.byteNumberAmountDataReceived;
                            //        DebugerLog(DriverPhrases.Request + "[ASCII][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "][HEX][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferSender)) + "]");
                            //        break;
                            //    case 4:
                            //        //Формирование буфера данных запроса
                            //        bufferSender = masterVTD.CalculateSendData(device.Address, (ushort)command.FunctionCode, (ushort)command.Parametr, (ushort)command.RegisterStartAddress, (ushort)command.RegisterCount, DriverUtils.ConvertUlongToUshort(command.RegisterWriteData), command.CurrentValue);
                            //        byteNumberFunctionReceived = masterVTD.byteNumberFunctionReceived;
                            //        byteNumberAmountDataReceived = masterVTD.byteNumberAmountDataReceived;
                            //        DebugerLog(DriverPhrases.Request + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                            //        break;
                            //    default:
                            //        continue;
                            //}

                            #endregion Протокол

                            #region Тип канала (отправка и получение данных)

                            //switch (channel.Type)
                            //{
                            //    case 0:
                            //        //Пусто
                            //        DebugerLog(DriverPhrases.NoType);
                            //        continue;
                            //    case 1:
                            //        // Последовательный порт
                            //        using (SerialPortClient serialClient = new SerialPortClient())
                            //        {
                            //            //Отправка команды
                            //            serialClient.Data(channel.SerialPortName, Convert.ToInt32(channel.SerialPortBaudRate), channel.SerialPortParity, Convert.ToInt32(channel.SerialPortDataBits), channel.SerialPortStopBits, channel.SerialPortHandshake, channel.SerialPortReceivedBytesThreshold, channel.SerialPortDtrEnable, channel.SerialPortRtsEnable, channel.WriteTimeout, channel.ReadTimeout, bufferSender, ref bufferReceiver, ref errMsg);
                            //        }
                            //        break;
                            //    case 2:
                            //        // TCP клиент
                            //        using (TCPClient tcpclient = new TCPClient())
                            //        {
                            //            //Отправка команды
                            //            tcpclient.Data(1, channel.ClientHost, channel.ClientPort, channel.WriteTimeout, channel.ReadTimeout, bufferSender, ref bufferReceiver, ref errMsg);
                            //        }
                            //        break;
                            //    case 3:
                            //        // UDP клиент
                            //        using (UDPClient udpclient = new UDPClient())
                            //        {
                            //            //Отправка команды
                            //            udpclient.Data(channel.ClientHost, channel.ClientPort, channel.WriteTimeout, channel.ReadTimeout, channel.Timeout, bufferSender, ref bufferReceiver, ref errMsg);
                            //        }
                            //        break;
                            //    default:
                            //        continue;
                            //}

                            //if (errMsg != string.Empty)
                            //{
                            //    DebugerLog(errMsg);
                            //    goto ERROR;
                            //}

                            #endregion Тип канала (отправка и получение данных)

                            #region Протокол

                            //switch (device.TypeProtocol)
                            //{
                            //    case 0:
                            //        continue;
                            //    case 1:

                            //        #region Проверка валидатности данных
                            //        //Проверка корректности поступленных данных
                            //        try
                            //        {
                            //            if (bufferReceiver == null)
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }

                            //            validate = masterRTU.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                            //            DebugerLog(DriverPhrases.Response + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                            //            if (validate)
                            //            {
                            //                numArrayRegisters = masterRTU.DecodeData(bufferReceiver);
                            //                if (debug)
                            //                {
                            //                    DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters) + "]");
                            //                }
                            //            }
                            //            else
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }
                            //        }
                            //        catch
                            //        {
                            //            goto ERROR;
                            //        }
                            //        #endregion Проверка валидатности данных

                            //        break;
                            //    case 2:

                            //        #region Проверка валидатности данных
                            //        //Проверка корректности поступленны данных  
                            //        try
                            //        {
                            //            if (bufferReceiver == null)
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }

                            //            validate = masterTCP.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                            //            DebugerLog(DriverPhrases.Response + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                            //            if (validate)
                            //            {
                            //                numArrayRegisters = masterTCP.DecodeData(bufferReceiver);
                            //                if (debug)
                            //                {
                            //                    DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters) + "]");
                            //                }
                            //            }
                            //            else
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }
                            //        }
                            //        catch
                            //        {
                            //            goto ERROR;
                            //        }
                            //        #endregion Проверка валидатности данных

                            //        break;
                            //    case 3:

                            //        #region Проверка валидатности данных
                            //        try
                            //        {
                            //            //Проверка корректности поступленны данных
                            //            if (bufferReceiver == null)
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }

                            //            validate = masterASCII.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                            //            DebugerLog(DriverPhrases.Response + "[ASCII][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "][HEX][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferReceiver)) + "]" + validateMessage + "");
                            //            bufferReceiver = HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferReceiver);

                            //            if (validate)
                            //            {
                            //                numArrayRegisters = masterASCII.DecodeData(bufferReceiver);
                            //                if (debug)
                            //                {
                            //                    DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters) + "]");
                            //                }
                            //            }
                            //            else
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }
                            //        }
                            //        catch
                            //        {
                            //            goto ERROR;
                            //        }
                            //        #endregion Проверка валидатности данных

                            //        break;
                            //    case 4:

                            //        #region Проверка валидатности данных
                            //        //Проверка корректности поступленных данных
                            //        try
                            //        {
                            //            if (bufferReceiver == null)
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }

                            //            validate = masterVTD.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                            //            DebugerLog(DriverPhrases.Response + "[" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                            //            if (validate)
                            //            {
                            //                numArrayRegisters = masterVTD.DecodeData(bufferReceiver);
                            //                if (debug)
                            //                {
                            //                    DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters) + "]");
                            //                }
                            //            }
                            //            else
                            //            {
                            //                device.Status = 2;
                            //                goto ERROR;
                            //            }
                            //        }
                            //        catch
                            //        {
                            //            goto ERROR;
                            //        }
                            //        #endregion Проверка валидатности данных

                            //        break;

                            //    default:
                            //        continue;

                            //}

                            #endregion Протокол

                            #region Качество (статус)
                            //Записываем данные
                            //Если данные не получили
                            if (numArrayRegisters == null)
                            {
                                //Переводим в Offline
                                device.Status = 2;
                                //goto ERROR;
                            }
                            else if (numArrayRegisters != null)
                            {

                                //Переводим в Online
                                device.Status = 1;
                                //Передаём дату успешного опроса
                                device.DateTimeCommandLastGood = DateTime.Now;
                                device.DateTimeLastSuccessfully = DateTime.Now;
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
                                        device.SetCoil((ulong)((ulong)command.RegisterStartAddress + (ulong)index), Coils[index]);
                                    }
                                    #endregion Write Data Coils
                                    break;
                                case 2:
                                    #region Write Data DiscreteInput
                                    bool[] DiscreteInputs = HEX_BOOLEAN.ToArray(numArrayRegisters);

                                    for (int index = 0; index < DiscreteInputs.Length; ++index)
                                    {
                                        device.SetDiscreteInput((ulong)(ulong)(command.RegisterStartAddress + (ulong)index), DiscreteInputs[index]);
                                    }
                                    #endregion Write Data DiscreteInput
                                    break;
                                case 3:
                                    #region Write Data HoldingRegister

                                    for (ulong index = 0; (ulong)index < (ulong)numArrayRegisters.Length / deviceRegistersBytes; ++index)
                                    {
                                        ulong RegAddr = ((ulong)command.RegisterStartAddress + (ulong)index);
                                        byte[] ArrData = HEX_OPERATION.BYTEARRAY_SEARCH(numArrayRegisters, (int)index * (int)deviceRegistersBytes, (int)deviceRegistersBytes);
                                        device.SetHoldingRegister(ArrData, RegAddr, deviceRegistersBytes);
                                    }

                                    #endregion Write Data HoldingRegister
                                    break;
                                case 4:
                                    #region Write Data InputRegister

                                    for (ulong index = 0; (ulong)index < (ulong)numArrayRegisters.Length / deviceRegistersBytes; ++index)
                                    {
                                        ulong RegAddr = ((ulong)command.RegisterStartAddress + (ulong)index);
                                        byte[] ArrData = HEX_OPERATION.BYTEARRAY_SEARCH(numArrayRegisters, (int)index * (int)deviceRegistersBytes, (int)deviceRegistersBytes);
                                        device.SetInputRegister(ArrData, RegAddr, deviceRegistersBytes);
                                    }

                                    #endregion Write Data InputRegister
                                    break;
                                //case ulong n when (n >= 80 && n <= 96):
                                //    #region Data Buffer
                                //    if (numArrayRegisters == null)
                                //    {
                                //        goto ERROR;
                                //    }

                                    //// write data
                                    //regAddr = masterVTD.GenerateRegisterAddress(command.FunctionCode, command.Parametr, command.RegisterStartAddress);
                                    //device.SetDataBuffer(HEX_STRING.BYTEARRAY_TO_HEXSTRING(numArrayRegisters), regAddr, deviceRegistersBytes);

                                    //if (debug)
                                    //{
                                    //    DebugerLog("Tag Address = " + regAddr.ToString() + "");
                                    //}

                                    //// read data
                                    //for (ulong index = 0; (ulong)index < (ulong)numArrayRegisters.Length / deviceRegistersBytes; ++index)
                                    //{
                                    //    regAddrStr = DriverUtils.NullToString(regAddr + index);

                                    //    List<ProjectTag> findTags = tags.Where(r => r.ID == device.ID && r.Address.StartsWith(regAddrStr)).ToList();
                                    //    if (findTags == null || findTags.Count == 0)
                                    //    {
                                    //        goto NEXTCOMMAND;
                                    //    }


                                    //if (command.CurrentValue)
                                    //{
                                    //    float[] arrValue = HEX_FLOAT.BYTEARRAY_TO_FLOATARRAY(numArrayRegisters, "");
                                    //    float value = 0f;
                                    //    if (command.FunctionCode == 84)
                                    //    {
                                    //        int indArrValue = arrValue.Length - 1;
                                    //        if (indArrValue <= 0)
                                    //        {
                                    //            value = arrValue[indArrValue];
                                    //        }
                                    //        else
                                    //        {
                                    //            value = arrValue[indArrValue - 1];
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        value = arrValue[arrValue.Length - 1];
                                    //    }

                                    //    DebugerLog("Tag Address Current = " + regAddrStr + "");

                                    //    for (int t = 0; t < findTags.Count; t++)
                                    //    {
                                    //        ServerSendValue(findTags[t].Code, value, 1);
                                    //    }
                                    //    goto NEXTCOMMAND;
                                    //}

                                    //            for (int t = 0; t < findTags.Count; t++)
                                    //            {
                                    //                ulong countReg = (ulong)ProjectTag.DeviceTagFormatDataRegisterCount(findTags[t], (int)deviceRegistersBytes);
                                    //                byte[] buffer = device.GetByteDataBuffer(Convert.ToUInt64(regAddr + index), countReg);

                                    //                if (debug)
                                    //                {
                                    //                    DebugerLog("findTagAddress = " + regAddrStr + " countReg = " + countReg + " deviceRegistersBytes = " + (int)deviceRegistersBytes + " hex = " + HEX_STRING.BYTEARRAY_TO_HEXSTRING(buffer));
                                    //                }

                                    //                byte[] bufferOrder = HEX_ARRAY.ArrayByteOrder(buffer, findTags[t].Sorting);

                                    //                if (debug)
                                    //                {
                                    //                    DebugerLog("Order by [" + findTags[t].Sorting + "]= " + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferOrder));
                                    //                }

                                    //                findTags[t].DataValue = ProjectTag.GetValue(findTags[t], bufferOrder);

                                    //                if (debug)
                                    //                {
                                    //                    DebugerLog("[" + findTags[t].Name.PadRight(32) + "][" + findTags[t].Address.PadRight(14) + "][" + findTags[t].TagType.ToString().PadRight(6) + "][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferOrder).PadRight(24) + "][" + countReg + "][" + findTags[t].DataValue.ToString() + "]");
                                    //                }

                                    //                ServerSendValue(findTags[t].Code, findTags[t].DataValue, 1);
                                    //            }
                                    //        }
                                    //        #endregion Data Buffer
                                    //        break;
                                    //    default:
                                    //        continue;
                                    //}

                                    //if (device.Status == 1)
                                    //{
                                    //    goto NEXTCOMMAND;
                                    //}

                                //#endregion Расшифровка

                                #region Запись данных



                                #endregion Запись данных

                                #region Обработка ошибок
                                ERROR:

                                    if (CountError == channel.CountError)
                                    {
                                        CountError = 0;

                                        DebugerLog(DriverPhrases.ExecutedError);

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
                            #endregion
                        }

                    NEXTDEVICE:
                        try { } catch { }
                    }
                }
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
                Thread.Sleep(channel.Timeout);
            }

        WORKEND:
            try { } catch { }
            #endregion Опрос устройств

        }
        #endregion Execute

        #region Timeout
        void TimeOut()
        {
            #region Timeout time between commands
            // waiting start time
            // время начала ожидания
            long channel_timeout_start = Environment.TickCount;
            // waiting end time
            // время окончания ожидания
            long channel_timeout_stop = channel_timeout_start + Convert.ToInt64(channel.Timeout);
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
                        ProjectDevice tmpDevice = channel.Devices.Find((Predicate<ProjectDevice>)(r => r.ID.ToString() == Device.ID.ToString()));

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
                        ProjectDevice tmpDevice = channel.Devices.Find((Predicate<ProjectDevice>)(r => r.ID.ToString() == Device.ID.ToString()));

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
                    if (device != null)
                    {
                        //В зависимости он настроек, сохраняем необходимое количество
                        for (int index = 0; index < 65535; ++index)
                        {
                            //Coils
                            if (device.CoilsExists(Convert.ToUInt16(index)))
                            {
                                string TextCoilsID = (index).ToString();
                                string TextCoilsWord = device.GetBooleanCoil(Convert.ToUInt16(index)).ToString();

                                stringList.Add(device.ID.ToString() + ";" + TextCoilsID + ";" + "CoilRegister;" + TextCoilsWord + ";");
                            }

                            //DiscreteInputs
                            if (device.DiscreteInputsExists(Convert.ToUInt16(index)))
                            {
                                string TextDiscreteInputsID = (index).ToString();
                                string TextDiscreteInputsWord = device.GetBooleanDiscreteInput(Convert.ToUInt16(index)).ToString();

                                stringList.Add(device.ID.ToString() + ";" + TextDiscreteInputsID + ";" + "DiscreteInput;" + TextDiscreteInputsWord + ";");
                            }

                            //HoldingRegisters
                            if (device.HoldingRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextHoldingID = (index).ToString();
                                string TextHoldingWord = device.GetUlongHoldingRegister(Convert.ToUInt16(index)).ToString();

                                stringList.Add(device.ID.ToString() + ";" + TextHoldingID + ";" + "HoldingRegister;" + TextHoldingWord + ";");
                            }

                            //InputRegisters
                            if (device.InputRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextInputID = (index).ToString();
                                string TextInputWord = device.GetUlongHoldingRegister(Convert.ToUInt16(index)).ToString();

                                stringList.Add(device.ID.ToString() + ";" + TextInputID + ";" + "InputRegister;" + TextInputWord + ";");
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