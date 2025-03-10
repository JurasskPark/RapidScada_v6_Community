using Scada.Comm.Drivers.DrvModbusCM;
using System.Diagnostics.Metrics;
using System.Net;
using System.Windows.Input;

namespace Master
{
    public enum DriverProtocol : int
    {
        None = 0,
        ModbusRTU = 1,
        ModbusTCP = 2,
        ModbusASCII = 3,
    }

    public class Protocol
    {
        public Protocol() 
        {
            TypProtocolServer = 0;
            Devices = new List<ProjectDevice>();
            Command = new ProjectCommand();
            BufferReceiver = new byte[0];
            BufferSender = new byte[0];
            Parameters = new List<string>();
            MessagesReceiver = new List<string>();
            MessagesSender = new List<string>();
        }

        private ProtocolMaster Master;
        public int TypProtocolServer { get; set; }
        public Guid IdServer { get; set; }
        public string IP { get; set; }
        public List<ProjectDevice> Devices { get; set; }
        public ProjectCommand Command { get; set; }
        public byte[] BufferReceiver { get; set; }
        public byte[] BufferSender { get; set; }
        public List<string> Parameters { get; set; }
        public List<string> MessagesReceiver { get; set; }
        public List<string> MessagesSender { get; set; }


        public byte[] Read(byte[] bytes, List<string> parameters, ref List<string> messages)
        {
            byte[] result = null;
            BufferReceiver = bytes;
            Parameters = parameters;
            messages = MessagesSender;
            result = BufferSender;
            return result;
        }

        public byte[] Read(byte[] bytes, List<string> parameters)
        {
            byte[] result = null;
            BufferReceiver = bytes;
            Parameters = parameters;
            result = BufferSender;
            return result;
        }

        public byte[] Read(byte[] bytes)
        {
            byte[] result = null;
            result = BufferSender;
            return result;
        }

        public byte[] Read()
        {
            byte[] result = null;
            result = BufferSender;
            return result;
        }

        public byte[] Write(byte[] bytes, List<string> parameters, ref List<string> messages)
        {
            byte[] result = null;
            BufferReceiver = bytes;
            Parameters = parameters;
            MessagesReceiver = messages;
            DataProccesing();
            messages = MessagesReceiver;
            return result = BufferSender;
        }

        public byte[] Write(byte[] bytes, List<string> parameters)
        {
            byte[] result = null;
            BufferReceiver = bytes;
            Parameters = parameters;
            DataProccesing();
            return result = BufferSender;
        }

        public byte[] Write(byte[] bytes)
        {
            byte[] result = null;
            BufferReceiver = bytes;
            DataProccesing();
            return result = BufferSender;
        }

        public byte[] Write()
        {
            byte[] result = null;
            return result = BufferSender;
        }

        public void DataProccesing()
        {
            try
            {
                //// ip device               
                //IPAddress deviceIP = IPAddress.Parse(StatusIP.IpAddressNoPort(IP));
                //string cmdDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff");

                //#region MessagesReceiver

                //MessagesReceiver = Parameters;

                //List<string> infoProtocol = Information(BufferReceiver);
                //Dictionary<string, string> infoParameters = ParameterDecryptor.Converter(infoProtocol);

                //string cmdInfoReceiver = string.Empty;

                //if (infoProtocol != null && infoProtocol.Count > 0)
                //{
                //    string cmdNameReceiver = Convert.ToString(infoParameters.Where(x => x.Key == "Name").FirstOrDefault().Value);
                   
                //    MessagesReceiver.Add(@$"CmdName|{cmdNameReceiver}");

                //    string cmdParametersReceiver = string.Empty;
                //    cmdParametersReceiver = Convert.ToString(infoParameters.Where(x => x.Key == "Parameters").FirstOrDefault().Value);
                //    cmdParametersReceiver = cmdParametersReceiver.Replace("''", "'");

                //    MessagesReceiver.Add(@$"CmdParameters|{cmdParametersReceiver}");

                //    cmdInfoReceiver = ParameterDecryptor.DictionaryToString(infoParameters);
                //}

                //MessagesReceiver.Add(@$"CmdHexadecimal|{Hex.StringX16.ToStringFormatDot(BufferReceiver)}");
                //MessagesReceiver.Add(@$"CmdDate|{cmdDate}");
                //MessagesReceiver.Add(@$"Message|[{deviceIP.ToString()}][Received][{Hex.StringX16.ToStringFormatDot(BufferReceiver)}]" + Environment.NewLine + "[Info]" + Environment.NewLine + cmdInfoReceiver);          
                //MessagesReceiver.AddRange(Parameters);

                //#endregion MessagesReceiver

                //#region MessagesSender

                //MessagesSender = Parameters;

                //// command
                //string Name = Convert.ToString(infoParameters.Where(x => x.Key == "Name").FirstOrDefault().Value);
                //bool Reverse = Convert.ToBoolean(infoParameters.Where(x => x.Key == "Reverse").FirstOrDefault().Value);
                //int deviceAddress = Convert.ToInt32(infoParameters.Where(x => x.Key == "DeviceID").FirstOrDefault().Value);
                //short DeviceID = Convert.ToInt16(infoParameters.Where(x => x.Key == "DeviceID").FirstOrDefault().Value);
                //bool ReplyExpected = Convert.ToBoolean(infoParameters.Where(x => x.Key == "ReplyExpected").FirstOrDefault().Value);
                //byte Stream = Convert.ToByte(infoParameters.Where(x => x.Key == "Stream").FirstOrDefault().Value);
                //byte Function = Convert.ToByte(infoParameters.Where(x => x.Key == "Function").FirstOrDefault().Value);

                //if (Devices == null)
                //{
                //    ListDevices listDevices = new ListDevices();
                //    Devices = listDevices.GetDevices(IdServer);
                //}

                //// Поиск устройства
                //Device device = (Device)Devices.Where(d => d.IP.Equals(deviceIP)).Where(d => d.Address == deviceAddress).FirstOrDefault();
                //if (device == null)
                //{
                //    // если устройство не нашли, то ищем в БД
                //    device = new Device();
                //    device = device.GetDevice(deviceIP, deviceAddress);
                //}

                //Command = (DeviceCommand)device.Commands.Where(c => c.Stream == (int)Stream).Where(c => c.Function == (int)Function + 1).FirstOrDefault();
                //if (Command == null)
                //{
                //    // если комманду не нашли, то ищем в БД
                //    Command = new DeviceCommand();
                //    Command = Command.GetCommand(device.ID, (int)Stream, (int)Function + 1);
                //}

                ////////////////////////////////////////////////////////////

                //BufferSender = ResponseMaker(BufferReceiver, Command.Hexadecimal);

                ////////////////////////////////////////////////////////////

                //string cmdInfoSender = string.Empty;

                //if (Command.Name != null || Command.Parameters != null)
                //{
                //    string cmdNameSender = Command.Name;
                //    MessagesSender.Add(@$"CmdName|{cmdNameSender}");

                //    cmdInfoSender += "Name=" + cmdNameSender + Environment.NewLine;

                //    string cmdParametersSender = string.Empty;
                //    cmdParametersSender = Command.Parameters;
                //    cmdParametersSender = cmdParametersSender.Replace("''", "'");
                //    MessagesSender.Add(@$"CmdParameters|{cmdParametersSender}");

                //    cmdInfoSender += "Parameters=" + cmdParametersSender + Environment.NewLine;
                //}

                //MessagesSender.Add(@$"CmdHexadecimal|{Hex.StringX16.ToStringFormatDot(BufferSender)}");
                //MessagesSender.Add(@$"CmdDate|{cmdDate}");
                //MessagesSender.Add(@$"CmdAnswerDate|{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff")}");
                //MessagesSender.Add(@$"Message|[{deviceIP.ToString()}][Sended][{Hex.StringX16.ToStringFormatDot(BufferSender)}]" + Environment.NewLine + "[Info]" + Environment.NewLine + cmdInfoSender);

                //#endregion MessagesSender
            }
            catch { }
        }

        public List<string> Information(byte[] bytes)
        {
            List<string> result = new List<string>();
            //BufferReceiver = bytes;
            //switch (TypProtocolServer)
            //{
            //    case 1:
            //        ProtocolSECS protocolSECS = new ProtocolSECS();
            //        result = MessagesReceiver = protocolSECS.InformationAnalyzer(bytes);
            //        break;
            //    case 2:
            //        ProtocolHSMS protocolHSMS = new ProtocolHSMS();
            //        result = MessagesReceiver = protocolHSMS.InformationAnalyzer(bytes);
            //        break;
            //}

            return result;
        }

        public byte[] ResponseMaker(byte[] bytes, byte[] bytes2)
        {
            byte[]? result = null;
            BufferReceiver = bytes;
            switch (TypProtocolServer)
            {
                case 1:
                    ModbusRTU protocolModbusRTU = new ModbusRTU();
                    //return BufferSender = protocolModbusRTU.ResponseMaker(bytes, bytes2);
                    break;
                case 2:
                    ModbusTCP protocolModbusTCP = new ModbusTCP();
                    //return BufferSender = protocolModbusTCP.ResponseMaker(bytes, bytes2);
                    break;
                case 3:
                    ModbusASCII protocolModbusASCII = new ModbusASCII();
                    //return BufferSender = protocolModbusASCII.ResponseMaker(bytes, bytes2);
                    break;
            }

            return result;
        }
    }
}
