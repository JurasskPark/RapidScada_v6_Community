using Scada.Comm.Channels;
using Scada.Comm.Config;
using Scada.Comm.Devices;
using Scada.Comm.Lang;
using Scada.Data.Models;
using Scada.Lang;
using static System.Net.Mime.MediaTypeNames;

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
        public readonly string shortFileName;
        /// <summary>
        /// Path configuration file
        /// <para>Путь до файла конфигурации</para>
        /// </summary>
        public readonly string projectFileName;
        /// <summary>
        /// Project configuration
        /// <para>Конфигурация проекта</para>
        /// </summary>
        private readonly Project project;
        /// <summary>
        /// Channel
        /// <para>Канал</para>
        /// </summary>
        private readonly ProjectChannel channel;
      
        /// <summary>
        /// Driver Tag
        /// <para>Тег драйвера</para>
        /// </summary>
        private List<CnlPrototypeGroup> driverTags;
        /// <summary>
        /// List driver сlient
        /// <para>Список клиентов</para>
        /// </summary>
        private readonly List<DriverClient> lstClient = new List<DriverClient>();
        /// <summary>
        /// Error counter
        /// <para>Счетчик ошибок</para>
        /// </summary>
        private ushort countError;



        #endregion Variables

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public DevModbusCMLogic(ICommContext commContext, ILineContext lineContext, DeviceConfig deviceConfig)
            : base(commContext, lineContext, deviceConfig)
        {
            CanSendCommands = false;
            ConnectionRequired = false;

            this.DeviceNum = deviceConfig.DeviceNum;
            this.driverCode = DriverUtils.DriverCode;
            this.shortFileName = DriverUtils.GetFileName(deviceNum);
            this.projectFileName = Path.Combine(CommContext.AppDirs.ConfigDir, shortFileName);
            this.project = new Project();

            // load configuration
            string errMsg = string.Empty;

            // load a configuration
            project.Load(projectFileName, out errMsg);

            if (errMsg != string.Empty)
            {
                Log.WriteLine(errMsg);
            }
        }

        /// <summary>
        /// Performs actions after adding the device to a communication line.
        /// </summary>
        public override void OnCommLineStart()
        {
            try
            {
                DebugerLog("[Driver v.0009]");
                DebugerLog("[" + DriverDictonary.StartDriver + "]");
                DebugerLog("[" + DriverDictonary.Delay + "][" + DriverUtils.NullToString(PollingOptions.Delay) + "]");
                DebugerLog("[" + DriverDictonary.Timeout + "][" + DriverUtils.NullToString(PollingOptions.Timeout) + "]");
                DebugerLog("[" + DriverDictonary.Period + "][" + DriverUtils.NullToString(PollingOptions.Period) + "]");
            }
            catch (Exception ex)
            {
                DebugerLog(DriverUtils.InfoError(ex));
            }
        }

   


        /// <summary>
        /// 
        /// </summary>
        public override void OnCommLineTerminate()
        {

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
                       "Количество тегов не было получено т.к. конфигурационный файл не был загружен." :
                       "The number of tags was not received because the configuration file was not loaded.");
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

            LastRequestOK = false;

            // request data
            int tryNum = 0;

            while (RequestNeeded(ref tryNum))
            {
                if (Execute())
                {
                    LastRequestOK = true;
                }

                FinishRequest();
                tryNum++;
            }

            if (!LastRequestOK && !IsTerminated)
            {
                InvalidateData();
            }

            SleepPollingDelay();

            FinishRequest();
            FinishSession();
        }

        #region ReInitializing

        public void ReInitializingOPCserver()
        {
            try
            {
                TeleCommand cmd = new TeleCommand();
                cmd.CreationTime = DateTime.Now;
                cmd.CommandID = ScadaUtils.GenerateUniqueID(DateTime.Now);
                cmd.CmdVal = LineContext.CommLineNum;
                cmd.CmdCode = CommCmdCode.RestartLine;
                CommContext.SendCommand(cmd, "Restart Line");
            }
            catch (Exception ex)
            {
                DebugerLog(DriverUtils.InfoError(ex));
            }
        }
        #endregion ReInitializing

        #region Execute

        /// <summary>
        /// Operating cycle running in a separate thread.
        /// </summary>
        public bool Execute()
        {
            try
            {
                for (int i = 0; i < lstClient.Count; i++)
                {
                    DriverClient.OnDebug = new DriverClient.DebugData(DebugerLog);
                    DriverClient.OnSendValue = new DriverClient.SendValue(SetTagData);
                    DriverClient driverClientTemp = lstClient[i];

                    DebugerLog("[" + DriverDictonary.DeviceName + "]");
                    DebugerLog("[" + DriverDictonary.GroupTagName + "]");

                    object[] ResultsValue = new object[0];
                    string errMsg = string.Empty;

                    driverClientTemp.Execute(errMsg);
                    if (errMsg != string.Empty)
                    {
                        DebugerLog(errMsg);
                    }

                    Thread.Sleep(PollingOptions.Timeout);
                }
                return true;
            }
            catch (Exception ex)
            {
                DebugerLog(ex.ToString());
                //ReInitializingOPCserver();
                return false;
            }
        }

        #endregion Execute

       

        /// <summary>
        /// Sets value, status and format of the specified tag.
        /// </summary>
        private void SetTagData(string tagCode, object tagVal, int tagStat)
        {
            try
            {
                if (tagCode == null || tagCode == string.Empty || tagVal == null)
                {
                    return;
                }

                DebugerLog("[" + DriverUtils.NullToString(tagCode) + "][" + DriverUtils.NullToString(tagVal) + "][" + DriverUtils.NullToString(tagStat) + "]");

                if (DeviceTags.Count() > 0)
                {
                    DeviceTag tag = DeviceTags[tagCode];

                    if (tagVal is string strVal)
                    {
                        tag.DataType = TagDataType.Unicode;
                        tag.Format = TagFormat.String;
                        try { base.DeviceData.SetUnicode(tagCode, strVal, tagStat); } catch { }
                    }
                    else if (tagVal is DateTime dtVal)
                    {
                        tag.DataType = TagDataType.Double;
                        tag.Format = TagFormat.DateTime;
                        try { base.DeviceData.SetDateTime(tagCode, dtVal, tagStat); } catch { }
                    }
                    else
                    {
                        tag.DataType = TagDataType.Double;
                        tag.Format = TagFormat.FloatNumber;
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
            Log.WriteLine("" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + text);
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
