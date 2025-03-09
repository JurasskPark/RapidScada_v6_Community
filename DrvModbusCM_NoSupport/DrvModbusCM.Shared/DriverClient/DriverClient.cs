using CommunicationMethods;
using ProtocolModbus;
using Scada.Comm.Devices;
using Scada.Comm.Drivers.DrvModbusCM;
using Scada.Data.Const;
using Scada.Lang;
using System.Data;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Xml.Serialization;

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

        #region Thread
        /// <summary>
        /// Thread
        /// Поток
        /// </summary>
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
        private Guid gatewaychannelID;
        #endregion Asynchronous TCP server

        #region EventDevicePollTxRx
        /// <summary>
        /// Receiving and transmitting information about RxTx
        /// <para>Получение и передача информации о RxTx<para>
        /// </summary>
        public static EventDevicePollTxRx EventHandlerEventDevicePollTxRx;
        public delegate void EventDevicePollTxRx(string type, int data);
        #endregion EventDevicePollTxRx

        #region DebugerLog
        /// <summary>
        /// Getting logs
        /// <para>Получение лога<para>
        /// </summary>
        public static DebugData OnDebug;
        public delegate void DebugData(string msg);
        internal void DebugerLog(string text)
        {
            if (OnDebug == null)
            {
                return;
            }

            OnDebug(text);
        }
        #endregion DebugerLog

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

        public DriverClient(Project project)
        {
            this.project = project;
            this.channel = project.Settings.ProjectChannelDevice;
            this.devices = project.Settings.ProjectDevice;
            this.deviceGroupCommands = project.Settings.ProjectDeviceGroupCommand;
            this.deviceCommands = project.Settings.ProjectDeviceCommand;
            this.deviceGroupTags = project.Settings.ProjectDeviceGroupTag;
            this.deviceTags = project.Settings.ProjectDeviceTag;
        }


        public List<CnlPrototypeGroup> GenerateCnlPrototypeGroups()
        {
            List<CnlPrototypeGroup> groups = new List<CnlPrototypeGroup>();
            CnlPrototypeGroup group = new CnlPrototypeGroup();

            string nameGroup = string.Empty;
            string nameTag = string.Empty;

            for (int d = 0; d < devices.Count; d++)
            {
                nameGroup = devices[d].DeviceName;
                Guid deviceID = devices[d].DeviceID;
                group = new CnlPrototypeGroup(nameGroup);

                List<ProjectDeviceTag> lstDeviceTags = deviceTags.Where(r => r.DeviceID == deviceID).ToList();

                for (int t = 0; t < lstDeviceTags.Count; t++)
                {
                    group.AddCnlPrototype("" + nameGroup + "." + lstDeviceTags[t].DeviceTagname + "", lstDeviceTags[t].DeviceTagname).SetFormat(FormatCode.G);
                }

                groups.Add(group);
            }

            driverTags = groups;
            return groups;
        }

        /// <summary>
        /// Sets value, status and format of the specified tag.
        /// </summary>
        private void SetTagData(int tagIndex, object tagVal, int tagStat)
        {
            //try
            //{
            //    if (DeviceTags.Count() > 0)
            //    {
            //        DeviceTag deviceTag = DeviceTags[tagIndex];

            //        if (tagVal is string strVal)
            //        {
            //            deviceTag.DataType = TagDataType.Unicode;
            //            deviceTag.Format = TagFormat.String;
            //            try { base.DeviceData.SetUnicode(tagIndex, strVal, tagStat); } catch { }
            //        }
            //        else if (tagVal is DateTime dtVal)
            //        {
            //            deviceTag.DataType = TagDataType.Double;
            //            deviceTag.Format = TagFormat.DateTime;
            //            try { base.DeviceData.SetDateTime(tagIndex, dtVal, tagStat); } catch { }
            //        }
            //        else
            //        {
            //            deviceTag.DataType = TagDataType.Double;
            //            deviceTag.Format = TagFormat.FloatNumber;
            //            try { base.DeviceData.Set(tagIndex, Convert.ToDouble(tagVal), tagStat); } catch { }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.WriteInfo(ex.BuildErrorMessage(Locale.IsRussian ?
            //        "Ошибка при установке данных тега" :
            //        "Error setting tag data"));
            //}
        }

        /// <summary>
        /// Sets value, status and format of the specified tag.
        /// </summary>
        private void SetTagData(string tagCode, object tagVal, int tagStat)
        {
            //try
            //{
            //    if (DeviceTags.Count() > 0)
            //    {
            //        DeviceTag deviceTag = DeviceTags[tagCode];

            //        if (tagVal is string strVal)
            //        {
            //            deviceTag.DataType = TagDataType.Unicode;
            //            deviceTag.Format = TagFormat.String;
            //            try { base.DeviceData.SetUnicode(tagCode, strVal, tagStat); } catch { }
            //        }
            //        else if (tagVal is DateTime dtVal)
            //        {
            //            deviceTag.DataType = TagDataType.Double;
            //            deviceTag.Format = TagFormat.DateTime;
            //            try { base.DeviceData.SetDateTime(tagCode, dtVal, tagStat); } catch { }
            //        }
            //        else
            //        {
            //            deviceTag.DataType = TagDataType.Double;
            //            deviceTag.Format = TagFormat.FloatNumber;
            //            try { base.DeviceData.Set(tagCode, Convert.ToDouble(tagVal), tagStat); } catch { }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.WriteInfo(ex.BuildErrorMessage(Locale.IsRussian ?
            //        "Ошибка при установке данных тега" :
            //        "Error setting tag data"));
            //}
        }


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

        void TCPServerStart()
        {
            var th = new Thread(TCPServerRun)
            {
                Priority = ThreadPriority.Highest
            };
            th.Start();
        }

        void TCPServerStop()
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
                atcpserver = new AsyncTCPServer(gatewaytypeprotocol, gatewayport, gatewayсonnectedclientsmax, gatewaychannelID);
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
                        Device.DeviceID = new Guid(strArray[0]);
                        ProjectDevice tmpDevice = channel.Devices.Find((Predicate<ProjectDevice>)(r => r.DeviceID.ToString() == Device.DeviceID.ToString()));

                        if (tmpDevice == null)
                        {
                            //Debuger.Log("В списке устройств не обнаружено устройство c ID [" + Device.DeviceID + "], которому добавляет информация из буфера данных!");
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
                        Device.DeviceID = new Guid(strArray[0]);
                        ProjectDevice tmpDevice = channel.Devices.Find((Predicate<ProjectDevice>)(r => r.DeviceID.ToString() == Device.DeviceID.ToString()));

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
                //Проходимся по списку устройств
                foreach (ProjectDevice tmpDevice in devices)
                {
                    //Если устройство действительно найдено
                    if (tmpDevice != null)
                    {
                        //В зависимости он настроек, сохраняем необходимое количество
                        for (int index = 0; index < 65535; ++index)
                        {
                            //Coils
                            if (tmpDevice.CoilsExists(Convert.ToUInt16(index)))
                            {
                                string TextCoilsID = (index).ToString();
                                string TextCoilsWord = tmpDevice.GetBooleanCoil(Convert.ToUInt16(index)).ToString();

                                stringList.Add(tmpDevice.DeviceID.ToString() + ";" + TextCoilsID + ";" + "CoilRegister;" + TextCoilsWord + ";");
                            }

                            //DiscreteInputs
                            if (tmpDevice.DiscreteInputsExists(Convert.ToUInt16(index)))
                            {
                                string TextDiscreteInputsID = (index).ToString();
                                string TextDiscreteInputsWord = tmpDevice.GetBooleanDiscreteInput(Convert.ToUInt16(index)).ToString();

                                stringList.Add(tmpDevice.DeviceID.ToString() + ";" + TextDiscreteInputsID + ";" + "DiscreteInput;" + TextDiscreteInputsWord + ";");
                            }

                            //HoldingRegisters
                            if (tmpDevice.HoldingRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextHoldingID = (index).ToString();
                                string TextHoldingWord = tmpDevice.GetUlongHoldingRegister(Convert.ToUInt16(index)).ToString();

                                stringList.Add(tmpDevice.DeviceID.ToString() + ";" + TextHoldingID + ";" + "HoldingRegister;" + TextHoldingWord + ";");
                            }

                            //InputRegisters
                            if (tmpDevice.InputRegistersExists(Convert.ToUInt16(index)))
                            {
                                string TextInputID = (index).ToString();
                                string TextInputWord = tmpDevice.GetUlongHoldingRegister(Convert.ToUInt16(index)).ToString();

                                stringList.Add(tmpDevice.DeviceID.ToString() + ";" + TextInputID + ";" + "InputRegister;" + TextInputWord + ";");
                            }
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