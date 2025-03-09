using Scada.Comm.Channels;
using Scada.Comm.Config;
using Scada.Comm.Devices;
using Scada.Comm.Lang;
using Scada.Data.Models;
using Scada.Lang;
using System;
using System.Diagnostics;
using System.Threading;
using Scada.Comm.Drivers.DrvModbusCM;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Scada.Log;
using Scada.Data.Entities;
using System.IO.Ports;
using System.Collections;
using Scada.Agent;
using System.Reflection;
using Scada.Config;
using System.Net;
using Scada.Protocol;

namespace Scada.Comm.Drivers.DrvModbusCM.Logic
{
    /// <summary>
    /// Implements the device logic.
    /// <para>Реализует логику устройства.</para>
    /// </summary>
    internal class DevModbusCMLogic : DeviceLogic
    {
        #region Variables
        /// <summary>
        /// The application directories
        /// <para>Каталоги приложения</para>
        /// </summary>
        private readonly AppDirs appDirs;
        /// <summary>
        /// The driver code
        /// <para>Код драйвера</para>
        /// </summary>
        private readonly string driverCode;
        /// <summary>
        /// The device number
        /// <para>Номер устройства</para>
        /// </summary>
        private readonly int deviceNum;
        /// <summary>
        /// Name configuration file
        /// <para>Название файл конфигурации</para>
        /// </summary>
        public string shortFileName;
        /// <summary>
        /// Path configuration file
        /// <para>Путь до файла конфигурации</para>
        /// </summary>
        public string projectFileName;
        /// <summary>
        /// Project configuration
        /// <para>Конфигурация проекта</para>
        /// </summary>
        private Project project;
        /// <summary>
        /// Channel
        /// <para>Канал</para>
        /// </summary>
        private ProjectChannelDevice channel;
        /// <summary>
        /// Devices
        /// <para>Устройства</para>
        /// </summary>
        public List<ProjectDevice> devices;
        /// <summary>
        /// Commands Group
        /// <para>Группа команд</para>
        /// </summary>
        private List<ProjectDeviceGroupCommand> deviceGroupCommands;
        /// <summary>
        /// Command
        /// <para>Команда</para>
        /// </summary>
        private List<ProjectDeviceCommand> deviceCommands;
        /// <summary>
        /// Tags Group
        /// <para>Группа тегов</para>
        /// </summary>
        private List<ProjectDeviceGroupTag> deviceGroupTags;
        /// <summary>
        /// Tag
        /// <para>Тег</para>
        /// </summary>
        private List<ProjectDeviceTag> deviceTags;
        /// <summary>
        /// Driver Tag
        /// <para>Тег драйвера</para>
        /// </summary>
        private List<CnlPrototypeGroup> driverTags;
        /// <summary>
        /// Error counter
        /// <para>Счетчик ошибок</para>
        /// </summary>
        public ushort CountError { get; private set; }

        #endregion Variables

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DevModbusCMLogic(ICommContext commContext, ILineContext lineContext, DeviceConfig deviceConfig)
            : base(commContext, lineContext, deviceConfig)
        {
            CanSendCommands = false;
            ConnectionRequired = false;

            this.deviceNum = deviceConfig.DeviceNum;
            this.driverCode = DriverUtils.DriverCode;
            this.shortFileName = DriverUtils.GetFileName(deviceNum);
            this.projectFileName = Path.Combine(CommContext.AppDirs.ConfigDir, shortFileName);
            this.project = new Project();
        }

        /// <summary>
        /// Performs actions after adding the device to a communication line.
        /// </summary>
        public override void OnCommLineStart()
        {
            Log.WriteLine(Locale.IsRussian ?
                "Запуск приложения" :
                "Launching the application");

            Log.WriteLine(PollingOptions.Timeout.ToString());

            // load configuration
            string errMsg = string.Empty;

            // load a configuration
            project.Load(projectFileName, out errMsg);

            this.channel = project.Settings.ProjectChannelDevice;
            this.devices = project.Settings.ProjectDevice;
            this.deviceGroupCommands = project.Settings.ProjectDeviceGroupCommand;
            this.deviceCommands = project.Settings.ProjectDeviceCommand;
            this.deviceGroupTags = project.Settings.ProjectDeviceGroupTag;
            this.deviceTags = project.Settings.ProjectDeviceTag;

            //// getting the Rx Tx
            //DriverClient.EventHandlerEventDevicePollTxRx = new DriverClient.EventDevicePollTxRx(DevicePollTxRxGet);
            //// getting the log
            //DriverClient.OnDebug = new DriverClient.DebugData(PollLogGet);
            //// getting information from a TCP server
            //DriverClient.OnDebugTCPServer = new DriverClient.DebugDataTCPServer(DevicePollTCPServerLogGet);
            //driverClient = new DriverClient(project);
            //driverClient.appDirs = appDirs;
            //driverClient.deviceNum = deviceNum;
            //driverClient.driverCode = driverCode;
            //driverClient.shortFileName = shortFileName;
            //driverClient.GenerateCnlPrototypeGroups();
            //driverClient.CnlPrototypeGroupsGetValue();


            if (errMsg != string.Empty)
            {
                Log.WriteLine(errMsg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnCommLineTerminate()
        {
            //driverClient.Close();
        }

        /// <summary>
        /// Performs actions after setting the connection.
        /// </summary>
        public override void OnConnectionSet()
        {

        }


        /// <summary>
        /// Initializes the device tags.
        /// </summary>
        public override void InitDeviceTags()
        {
            if (project == null)
            {
                Log.WriteLine(Locale.IsRussian ?
                       "Количество тегов не было получено т.к. конфигурационный файл не был загружен" :
                       "The number of tags was not received because the configuration file was not loaded");
                return;
            }
            if (project.Load(projectFileName, out string errMsg))
            {
                foreach (CnlPrototypeGroup group in CnlPrototypeFactory.GetCnlPrototypeGroups(project))
                {
                    DeviceTags.AddGroup(group.ToTagGroup());
                }
            }
            else
            {
                Log.WriteLine(errMsg);
            }
        }


        /// <summary>
        /// Performs a communication session.
        /// </summary>
        public override void Session()
        {
            base.Session();

            Execute();

            FinishRequest();
            FinishSession();
        }

        #region Execute
        /// <summary>
        /// Operating cycle running in a separate thread.
        /// </summary>
        public void Execute()
        {
            try
            {
                DebugerLog("Versiion: 0011");

                //Название канала
                string channelName = channel.ChannelName;
                bool debug = true;

                //Производим поиск по устройств по Guid канала, а точнее фильтруем
                List<ProjectDevice> lstDevice = devices.Where(r => r.ChannelID == channel.ChannelID).ToList();

                for (int devi = 0; devi < lstDevice.Count; devi++)
                {
                    //Текущее устройство
                    ProjectDevice device = lstDevice[devi];
                    DebugerLog("[" + channelName + "] - [" + device.DeviceName + "]");

                    //Если устройство выключено, то пропускаем
                    if (device.DeviceEnabled == false)
                    {
                        goto WORKEND;
                    }

                    List<ProjectDeviceCommand> lstDeviceCommands = deviceCommands.Where(r => r.DeviceID == device.DeviceID).ToList();
                    for (int comi = 0; comi < lstDeviceCommands.Count; comi++)
                    {
                        #region Команда
                        ProjectDeviceCommand deviceCommand = lstDeviceCommands[comi];
                        //Если команда выключена, то пропускаем
                        if (deviceCommand.DeviceCommandEnabled == false)
                        {
                            goto WORKEND;
                        }

                        //Передаём время опроса
                        device.DeviceDateTimeCommandLast = DateTime.Now;
                        CountError = 0;
                    #endregion Команда

                    //Начало работы логики
                    STEP_REPEAT_COMMAND:
                        //Счетчик
                        ++CountError;

                        DebugerLog("[№" + CountError + "][" + deviceCommand.DeviceCommandName + "]");

                        if(debug)
                        {
                            DebugerLog("[Debug]");
                            DebugerLog("[FunctionCod][" + deviceCommand.DeviceCommandFunctionCode + "]");
                            DebugerLog("[RegisterStartAddress][" + deviceCommand.DeviceCommandRegisterStartAddress + "]");
                            DebugerLog("[RegisterCount][" + deviceCommand.DeviceCommandRegisterCount + "]");
                            DebugerLog("[Parametr][" + deviceCommand.DeviceCommandParametr + "]");
                        }

                        #region Переменные
                        //Лог
                        string logText = string.Empty;
                        //Сообщение ошибки
                        string messageError = string.Empty;
                        //Буфер данных запроса
                        byte[] bufferSender = new byte[channel.WriteBufferSize];
                        //Буфер данных ответа
                        byte[] bufferReceiver = new byte[channel.ReadBufferSize];
                        //Номер байта с объемом полученных данных
                        int byteNumberFunctionReceived = 0;
                        int byteNumberAmountDataReceived = 0;
                        //Массив регистров для вставки в буфер
                        byte[] NumArrayRegisters = (byte[])null;
                        //Сообщение о валидатности данных или ошибке
                        string validateMessage = string.Empty;
                        //Признак корректности полученных данных
                        bool validate = true;

                        ulong deviceRegistersBytes = 2;
                        //Количество регистров 2х байтные или 4х байтные
                        switch (device.DeviceRegistersBytes)
                        {
                            case 0: //2 байт
                                deviceRegistersBytes = 2;
                                break;
                            case 1: //4 байт
                                deviceRegistersBytes = 4;
                                break;
                        }


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

                        switch (device.DeviceTypeProtocol)
                        {
                            case 0:
                                // Пусто
                                DebugerLog("[Протокол не выбран]");
                                continue;
                            case 1:
                                //Формирование буфера данных запроса
                                bufferSender = masterRTU.CalculateSendData(device.DeviceAddress, (ushort)deviceCommand.DeviceCommandFunctionCode, (ushort)deviceCommand.DeviceCommandRegisterStartAddress, (ushort)deviceCommand.DeviceCommandRegisterCount, DriverUtils.ConvertUlongToUshort(deviceCommand.DeviceCommandRegisterWriteData));
                                byteNumberFunctionReceived = masterRTU.byteNumberFunctionReceived;
                                byteNumberAmountDataReceived = masterRTU.byteNumberAmountDataReceived;
                                DebugerLog("[Запрос][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                                break;
                            case 2:
                                //Формирование буфера данных запроса
                                bufferSender = masterTCP.CalculateSendData(device.DeviceAddress, (ushort)deviceCommand.DeviceCommandFunctionCode, (ushort)deviceCommand.DeviceCommandRegisterStartAddress, (ushort)deviceCommand.DeviceCommandRegisterCount, DriverUtils.ConvertUlongToUshort(deviceCommand.DeviceCommandRegisterWriteData));
                                byteNumberFunctionReceived = masterTCP.byteNumberFunctionReceived;
                                byteNumberAmountDataReceived = masterTCP.byteNumberAmountDataReceived;
                                DebugerLog("[Запрос][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                                break;
                            case 3:
                                //Формирование буфера данных запроса
                                bufferSender = masterASCII.CalculateSendData(device.DeviceAddress, (ushort)deviceCommand.DeviceCommandFunctionCode, (ushort)deviceCommand.DeviceCommandRegisterStartAddress, (ushort)deviceCommand.DeviceCommandRegisterCount, DriverUtils.ConvertUlongToUshort(deviceCommand.DeviceCommandRegisterWriteData));
                                byteNumberFunctionReceived = masterASCII.byteNumberFunctionReceived;
                                byteNumberAmountDataReceived = masterASCII.byteNumberAmountDataReceived;
                                DebugerLog("[Запрос][ASCII][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "][HEX][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferSender)) + "]");
                                break;
                            case 4:
                                //Формирование буфера данных запроса
                                bufferSender = masterVTD.CalculateSendData(device.DeviceAddress, (ushort)deviceCommand.DeviceCommandFunctionCode, (ushort)deviceCommand.DeviceCommandParametr, (ushort)deviceCommand.DeviceCommandRegisterStartAddress, (ushort)deviceCommand.DeviceCommandRegisterCount, DriverUtils.ConvertUlongToUshort(deviceCommand.DeviceCommandRegisterWriteData));
                                byteNumberFunctionReceived = masterVTD.byteNumberFunctionReceived;
                                byteNumberAmountDataReceived = masterVTD.byteNumberAmountDataReceived;
                                DebugerLog("[Запрос][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferSender) + "]");
                                break;
                            default:
                                continue;
                        }

                        #endregion Протокол

                        #region Тип канала (отправка и получение данных)

                        messageError = string.Empty;

                        switch (channel.ChannelType)
                        {
                            case 0:
                                //Пусто
                                DebugerLog("[Не выбран тип канала!]");
                                continue;
                            case 1:
                                // Последовательный порт
                                using (SerialPortClient serialClient = new SerialPortClient())
                                {
                                    //Отправка команды
                                    serialClient.Data(channel.SerialPortName, Convert.ToInt32(channel.SerialPortBaudRate), channel.SerialPortParity, Convert.ToInt32(channel.SerialPortDataBits), channel.SerialPortStopBits, channel.SerialPortHandshake, channel.SerialPortReceivedBytesThreshold, channel.SerialPortDtrEnable, channel.SerialPortRtsEnable, channel.WriteTimeout, channel.ReadTimeout, bufferSender, ref bufferReceiver, ref messageError);
                                }
                                break;
                            case 2:
                                // TCP клиент
                                using (TCPClient tcpclient = new TCPClient())
                                {
                                    //Отправка команды
                                    tcpclient.Data(1, channel.ClientHost, channel.ClientPort, channel.WriteTimeout, channel.ReadTimeout, bufferSender, ref bufferReceiver, ref messageError);
                                }
                                break;
                            case 3:
                                // UDP клиент
                                using (UDPClient udpclient = new UDPClient())
                                {
                                    //Отправка команды
                                    udpclient.Data(channel.ClientHost, channel.ClientPort, channel.WriteTimeout, channel.ReadTimeout, channel.Timeout, bufferSender, ref bufferReceiver, ref messageError);
                                }
                                break;
                            default:
                                continue;
                        }

                        // Отладка1 потом включить!!!!!!!!!!!!!!
                        if (messageError != string.Empty)
                        {
                            DebugerLog(messageError);
                            goto ERROR;
                        }

                        #endregion Тип канала (отправка и получение данных)

                        #region Протокол

                        switch (device.DeviceTypeProtocol)
                        {
                            case 0:
                                continue;
                            case 1:

                                #region Проверка валидатности данных
                                //Проверка корректности поступленных данных
                                try
                                {
                                    validate = masterRTU.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                                    DebugerLog("[Ответ ][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                                    if (validate)
                                    {
                                        NumArrayRegisters = masterRTU.DecodeData(bufferReceiver);
                                        if (debug)
                                        {
                                            DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(NumArrayRegisters) + "]");
                                        }
                                    }
                                    else
                                    {
                                        device.DeviceStatus = 2;
                                        goto ERROR;
                                    }
                                }
                                catch
                                {
                                    goto ERROR;
                                }
                                #endregion Проверка валидатности данных

                                break;
                            case 2:

                                #region Проверка валидатности данных
                                //Проверка корректности поступленны данных  
                                try
                                {
                                    validate = masterTCP.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                                    DebugerLog("[Ответ ][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                                    if (validate)
                                    {
                                        NumArrayRegisters = masterTCP.DecodeData(bufferReceiver);
                                        if (debug)
                                        {
                                            DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(NumArrayRegisters) + "]");
                                        }
                                    }
                                    else
                                    {
                                        device.DeviceStatus = 2;
                                        goto ERROR;
                                    }
                                }
                                catch
                                {
                                    goto ERROR;
                                }
                                #endregion Проверка валидатности данных

                                break;
                            case 3:

                                #region Проверка валидатности данных
                                try
                                {
                                    //Проверка корректности поступленны данных
                                    validate = masterASCII.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                                    DebugerLog("[Ответ ][ASCII][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "][HEX][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferReceiver)) + "]" + validateMessage + "");
                                    bufferReceiver = HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferReceiver);

                                    if (validate)
                                    {
                                        NumArrayRegisters = masterASCII.DecodeData(bufferReceiver);
                                        if (debug)
                                        {
                                            DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(NumArrayRegisters) + "]");
                                        }
                                    }
                                    else
                                    {
                                        device.DeviceStatus = 2;
                                        goto ERROR;
                                    }
                                }
                                catch
                                {
                                    goto ERROR;
                                }
                                #endregion Проверка валидатности данных

                                break;
                            case 4:

                                #region Проверка валидатности данных
                                //Проверка корректности поступленных данных
                                try
                                {
                                    validate = masterVTD.ValidateData(bufferSender, bufferReceiver, ref validateMessage);
                                    DebugerLog("[Ответ ][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferReceiver) + "]" + validateMessage + "");

                                    if (validate)
                                    {
                                        NumArrayRegisters = masterVTD.DecodeData(bufferReceiver);
                                        if (debug)
                                        {
                                            DebugerLog("[NumArrayRegisters][" + HEX_STRING.BYTEARRAY_TO_HEXSTRING(NumArrayRegisters) + "]");
                                        }
                                    }
                                    else
                                    {
                                        device.DeviceStatus = 2;
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
                        if (NumArrayRegisters == null)
                        {
                            //Переводим в Offline
                            device.DeviceStatus = 2;
                        }
                        else if (NumArrayRegisters != null)
                        {

                            //Переводим в Online
                            device.DeviceStatus = 1;
                            //Передаём дату успешного опроса
                            device.DeviceDateTimeCommandLastGood = DateTime.Now;
                            device.DeviceDateTimeLastSuccessfully = DateTime.Now;
                        }
                        #endregion Качество (статус)

                        #region Расшифровка

                        switch (deviceCommand.DeviceCommandFunctionCode)
                        {
                            case 0:
                                continue;
                            case 1:
                                #region Write Data Coils
                                bool[] Coils = HEX_BOOLEAN.ToArray(NumArrayRegisters);
                                for (int index = 0; index < Coils.Length; ++index)
                                {
                                    device.SetCoil((ulong)((ulong)deviceCommand.DeviceCommandRegisterStartAddress + (ulong)index), Coils[index]);
                                }
                                #endregion Write Data Coils
                                break;
                            case 2:
                                #region Write Data DiscreteInput
                                bool[] DiscreteInputs = HEX_BOOLEAN.ToArray(NumArrayRegisters);

                                for (int index = 0; index < DiscreteInputs.Length; ++index)
                                {
                                    device.SetDiscreteInput((ulong)(ulong)(deviceCommand.DeviceCommandRegisterStartAddress + (ulong)index), DiscreteInputs[index]);
                                }
                                #endregion Write Data DiscreteInput
                                break;
                            case 3:
                                #region Write Data HoldingRegister

                                for (ulong index = 0; (ulong)index < (ulong)NumArrayRegisters.Length / deviceRegistersBytes; ++index)
                                {
                                    device.SetHoldingRegister((ulong)((ulong)deviceCommand.DeviceCommandRegisterStartAddress + (ulong)index), (ulong)HEX_ENDIAN.SwapUInt32(BitConverter.ToUInt32(NumArrayRegisters, (int)index * (int)deviceRegistersBytes)));
                                }

                                #endregion Write Data HoldingRegister
                                break;
                            case 4:
                                #region Write Data InputRegister

                                for (ulong index = 0; (ulong)index < (ulong)NumArrayRegisters.Length / deviceRegistersBytes; ++index)
                                {

                                    device.SetInputRegister((ulong)((ulong)deviceCommand.DeviceCommandRegisterStartAddress + (ulong)index), (ulong)HEX_ENDIAN.SwapUInt32(BitConverter.ToUInt32(NumArrayRegisters, (int)index * (int)deviceRegistersBytes)));
                                }

                                #endregion Write Data InputRegister
                                break;
                            case ulong n when (n >= 80 && n <= 96):
                                #region
                                for (ulong index = 0; (ulong)index < (ulong)NumArrayRegisters.Length / deviceRegistersBytes; ++index)
                                {
                                    ulong regAddr = Convert.ToUInt64(masterVTD.GenerateRegisterAddress(deviceCommand.DeviceCommandFunctionCode, deviceCommand.DeviceCommandParametr, (deviceCommand.DeviceCommandRegisterStartAddress + index)));
                                    ulong value = HEX_ULONG.HEXARRAY_TO_ULONG(NumArrayRegisters, (int)index, (int)deviceRegistersBytes);
                                    device.SetDataBuffer(regAddr, value);

                                    if(debug)
                                    {
                                        DebugerLog("Write Data = [" + regAddr + "][" + value + "]");
                                    }
                                }

                                // read data
                                for (ulong index = 0; (ulong)index < (ulong)NumArrayRegisters.Length / deviceRegistersBytes; ++index)
                                {
                                    string findTagAddress = masterVTD.GenerateRegisterAddress(deviceCommand.DeviceCommandFunctionCode, deviceCommand.DeviceCommandParametr, (deviceCommand.DeviceCommandRegisterStartAddress + index));
                                    
                                    if (debug)
                                    {
                                        DebugerLog("Tag Address = " + findTagAddress + "");
                                    }

                                    List<ProjectDeviceTag> findTags = deviceTags.Where(r => r.DeviceID == device.DeviceID && r.DeviceTagAddress.StartsWith(findTagAddress)).ToList();
                                    for (int t = 0; t < findTags.Count; t++)
                                    {
                                        ulong countReg = (ulong)ProjectDeviceTag.DeviceTagFormatDataRegisterCount(findTags[t], (int)deviceRegistersBytes);
                                        byte[] buffer = device.GetByteDataBuffer(Convert.ToUInt32(findTagAddress), countReg, (int)deviceRegistersBytes);    
                                        byte[] bufferOrder = HEX_ARRAY.ArrayByteOrder(buffer, findTags[t].DeviceTagSorting);
                                        string strbufferOrder = HEX_STRING.BYTEARRAY_TO_HEXSTRING(bufferOrder);
                                        findTags[t].DeviceTagDataValue = ProjectDeviceTag.GetValue(findTags[t], bufferOrder);
 
                                        if(debug)
                                        {
                                            DebugerLog("[" + findTags[t].DeviceTagname.PadRight(32) + "][" + findTags[t].DeviceTagAddress.PadRight(14) + "][" + findTags[t].DeviceTagType.ToString().PadRight(6) + "][" + strbufferOrder.PadRight(24) + "][" + countReg + "][" + findTags[t].DeviceTagDataValue.ToString() + "]");
                                        }

                                        ProjectDeviceTag tmpTag = deviceTags.Where(r => r.DeviceID == device.DeviceID && r.DeviceTagID == findTags[t].DeviceTagID).FirstOrDefault();
                                        int indexTag = deviceTags.IndexOf(tmpTag);

                                        if (tmpTag == null || tmpTag.DeviceTagEnabled == false)
                                        {
                                            continue;
                                        }

                                        if (device.DeviceStatus == 1)
                                        {
                                            if (tmpTag.DeviceTagCode != string.Empty)
                                            {
                                                SetTagData(tmpTag.DeviceTagCode, findTags[t].DeviceTagDataValue, 1);
                                            }
                                            else
                                            {
                                                SetTagData(indexTag, findTags[t].DeviceTagDataValue, 1);
                                            }
                                        }
                                        else
                                        {
                                            if (tmpTag.DeviceTagCode != string.Empty)
                                            {
                                                SetTagData(tmpTag.DeviceTagCode, findTags[t].DeviceTagDataValue, 0);
                                            }
                                            else
                                            {
                                                SetTagData(indexTag, findTags[t].DeviceTagDataValue, 0);
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            default:
                                continue;
                        }

                        if (device.DeviceStatus == 1)
                        {
                            goto NEXTCOMMAND;
                        }

                    #endregion Расшифровка

                    #region Обработка ошибок
                    ERROR:

                        if (CountError == channel.CountError)
                        {
                            CountError = 0;
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

                NEXTDEVICE:
                    try { } catch { }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    DebugerLog("[ERROR] [" + ex.Message.ToString() + "]");
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

        }
        #endregion Execute


        /// <summary>
        /// Sets value, status and format of the specified tag.
        /// </summary>
        private void SetTagData(int tagIndex, object tagVal, int tagStat)
        {
            try
            {
                if (DeviceTags.Count() > 0)
                {
                    DeviceTag deviceTag = DeviceTags[tagIndex];

                    if (tagVal is bool boolVal)
                    {
                        deviceTag.DataType = TagDataType.Double;
                        deviceTag.Format = TagFormat.OffOn;
                        try { base.DeviceData.Set(tagIndex, Convert.ToDouble(boolVal), tagStat); } catch { }
                    }
                    if (tagVal is string strVal)
                    {
                        deviceTag.DataType = TagDataType.Unicode;
                        deviceTag.Format = TagFormat.String;
                        try { base.DeviceData.SetUnicode(tagIndex, strVal, tagStat); } catch { }
                    }
                    else if (tagVal is int intVal)
                    {
                        deviceTag.DataType = TagDataType.Int64;
                        deviceTag.Format = TagFormat.IntNumber;
                        try { base.DeviceData.SetInt64(tagIndex, intVal, tagStat); } catch { }
                    }
                    else if (tagVal is long longVal)
                    {
                        deviceTag.DataType = TagDataType.Int64;
                        deviceTag.Format = TagFormat.IntNumber;
                        try { base.DeviceData.SetInt64(tagIndex, longVal, tagStat); } catch { }
                    }
                    else if (tagVal is DateTime dtVal)
                    {
                        deviceTag.DataType = TagDataType.Double;
                        deviceTag.Format = TagFormat.DateTime;
                        try { base.DeviceData.SetDateTime(tagIndex, dtVal, tagStat); } catch { }
                    }
                    else
                    {
                        deviceTag.DataType = TagDataType.Double;
                        deviceTag.Format = TagFormat.FloatNumber;
                        try { base.DeviceData.Set(tagIndex, Convert.ToDouble(tagVal), tagStat); } catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteInfo(ex.BuildErrorMessage(Locale.IsRussian ?
                    "Ошибка при установке данных тега" :
                    "Error setting tag data"));
            }
        }

        /// <summary>
        /// Sets value, status and format of the specified tag.
        /// </summary>
        private void SetTagData(string tagCode, object tagVal, int tagStat)
        {
            try
            {
                if (DeviceTags.Count() > 0)
                {
                    DeviceTag deviceTag = DeviceTags[tagCode];

                    if (tagVal is string strVal)
                    {
                        deviceTag.DataType = TagDataType.Unicode;
                        deviceTag.Format = TagFormat.String;
                        try { base.DeviceData.SetUnicode(tagCode, strVal, tagStat); } catch { }
                    }
                    else if (tagVal is DateTime dtVal)
                    {
                        deviceTag.DataType = TagDataType.Double;
                        deviceTag.Format = TagFormat.DateTime;
                        try { base.DeviceData.SetDateTime(tagCode, dtVal, tagStat); } catch { }
                    }
                    else
                    {
                        deviceTag.DataType = TagDataType.Double;
                        deviceTag.Format = TagFormat.FloatNumber;
                        try { base.DeviceData.Set(tagCode, Convert.ToDouble(tagVal), tagStat); } catch { }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteInfo(ex.BuildErrorMessage(Locale.IsRussian ?
                    "Ошибка при установке данных тега" :
                    "Error setting tag data"));
            }
        }

        /// <summary>
        /// Builds a log text about reading data.
        /// </summary>
        protected static string BuildReadLogText(byte[] buffer, int offset, int readCnt, ProtocolFormat format)
        {
            return $"{CommPhrases.ReceiveNotation} ({readCnt}): " +
                ScadaUtils.BytesToString(buffer, offset, readCnt, format == ProtocolFormat.Hex);
        }


        /// <summary>
        /// Sends the telecontrol command.
        /// </summary>
        public override void SendCommand(TeleCommand cmd)
        {
            base.SendCommand(cmd);

            FinishCommand();
        }

        //Получение RxTx
        //void DevicePollTxRxGet(string type, int data)
        //{
        //    try
        //    {
        //        if (type == "Tx")
        //        {
        //            ModbusDevicePoolTx = ModbusDevicePoolTx + Convert.ToUInt64(data);
        //            Log.WriteLine("" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Tx = " + data.ToString() + " Total Tx = " + ModbusDevicePoolTx.ToString() + "");
        //        }

        //        if (type == "Rx")
        //        {
        //            ModbusDevicePoolRx = ModbusDevicePoolRx + Convert.ToUInt64(data);
        //            Log.WriteLine("" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Rx = " + data.ToString() + " Total Rx = " + ModbusDevicePoolTx.ToString() + "");
        //        }
        //    }
        //    catch { }
        //}

        public void DebugerLog(string text)
        {
            Log.WriteLine("" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff") + " " + text);
        }

        void DevicePollTCPServerLogGet(string text)
        {
            try
            {
                Log.WriteLine("" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + text);
            }
            catch { }
        }

    }
}
