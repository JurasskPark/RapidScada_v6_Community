using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class MasterDeviceReceiverSender
    {

        public static byte[] Sender(int typserver, Guid channelid, byte[] bufferReceiver, ref string Message)
        {
            ////////////////Переменная
            byte[] bufferSender = (byte[])null;
            string tmp_bufferSender = string.Empty;
            ////////////////Переменная

            ////////////////Поиск устройства
            int tmp_DeviceAddress = 0;
            int tmp_DeviceFunction = 0;
            int tmp_RegisterStartAddress = 0;
            int tmp_RegisterCount = 0;

            ///////////////

            ///////////////

            bool Debug = true;

            if (typserver == 0)
            {

            }

            #region Запрос Modbus
            else if (typserver == 1) //ModbusRTU
            {
                tmp_DeviceAddress = (int)bufferReceiver[0];

                if (Debug)
                {
                    tmp_DeviceFunction = Convert.ToInt32(bufferReceiver[1]);

                    byte[] RegisterStartAddressArray = new byte[2];
                    RegisterStartAddressArray[0] = bufferReceiver[2];
                    RegisterStartAddressArray[1] = bufferReceiver[3];
                    tmp_RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray);

                    byte[] RegisterCountArray = new byte[2];
                    RegisterCountArray[0] = bufferReceiver[4];
                    RegisterCountArray[1] = bufferReceiver[5];
                    tmp_RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray);
                }
            }
            else if (typserver == 2) //ModbusTCP
            {
                tmp_DeviceAddress = (int)bufferReceiver[6];

                if (Debug)
                {
                    tmp_DeviceFunction = Convert.ToInt32(bufferReceiver[7]);

                    byte[] RegisterStartAddressArray = new byte[2];
                    RegisterStartAddressArray[0] = bufferReceiver[8];
                    RegisterStartAddressArray[1] = bufferReceiver[9];
                    tmp_RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray);

                    byte[] RegisterCountArray = new byte[2];
                    RegisterCountArray[0] = bufferReceiver[10];
                    RegisterCountArray[1] = bufferReceiver[11];
                    tmp_RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray);
                }
            }
            else if (typserver == 3) //ModbusASCII
            {
                bufferReceiver = HEX_ASCII.ASCIIBYTEARRAY_TO_BYTEARRAY(bufferReceiver);
                tmp_DeviceAddress = (int)bufferReceiver[1];

                if (Debug)
                {
                    tmp_DeviceFunction = Convert.ToInt32(bufferReceiver[2]);

                    byte[] RegisterStartAddressArray = new byte[2];
                    RegisterStartAddressArray[0] = bufferReceiver[3];
                    RegisterStartAddressArray[1] = bufferReceiver[4];
                    tmp_RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray);

                    byte[] RegisterCountArray = new byte[2];
                    RegisterCountArray[0] = bufferReceiver[5];
                    RegisterCountArray[1] = bufferReceiver[6];
                    tmp_RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray);
                }
            }
            #endregion Запрос Modbus

            #region Последовательный порт
            else if (typserver == 4)
            {
                try
                {
                    #region Конфигурирование последовательного порта
                    //ProjectChannelDevice channel = HARDWARE_GROUP_MODBUS.Channels.Where(r => r.ChannelID == channelid).FirstOrDefault();
                    //ProjectChannelDevice channel = HARDWARE_GROUP_MODBUS.Channels.Where(r => r.ChannelID == channelid).FirstOrDefault();
                    //SerialPortOpros opros = new SerialPortOpros();
                    //bufferSender = opros.Opros(channel);
                    return bufferSender;
                }
                catch
                {
                    return bufferSender;
                }
                #endregion Последовательный порт
            }

            #region Ответ Modbus 
            if (typserver >= 1 && typserver <= 3)
            {
                //Информация о запросе
                Message += "Запрос информации: Функция=" + tmp_DeviceFunction.ToString() + " Нач. регистр=" + tmp_RegisterStartAddress.ToString() + " Количество=" + tmp_RegisterCount.ToString() + "." + Environment.NewLine;
                //Поиск
                Message += "Поиск устройства с адресом " + tmp_DeviceAddress.ToString() + "." + Environment.NewLine;

                //ProjectDevice Device = ProjectChannelDevice.Devices.Find((Predicate<ProjectDevice>)(r => r.DeviceAddress == tmp_DeviceAddress && r.ChannelID == channelid));
                //if (Device == null)
                //{
                //    //Устройство не найдено
                //    Message += "Устройство с адресом " + tmp_DeviceAddress.ToString() + " не найдено." + Environment.NewLine;
                //    bufferSender = HEX_STRING.HEXSTRING_TO_BYTEARRAY("04.04.");
                //}
                //else
                //{
                //    if (typserver == 1) //ModbusRTU
                //    {
                //        ModbusRTU clientRTU = new ModbusRTU();
                //        bufferSender = clientRTU.ResponseMaker(Device, bufferReceiver);
                //    }
                //    else if (typserver == 2) //ModbusTCP
                //    {
                //        ModbusTCP clientTCP = new ModbusTCP();
                //        bufferSender = clientTCP.ResponseMaker(Device, bufferReceiver);
                //    }
                //    else if (typserver == 3) //ModbusASCII
                //    {
                //        ModbusASCII clientASCII = new ModbusASCII();
                //        bufferSender = clientASCII.ResponseMaker(Device, bufferReceiver);
                //    }
                //}
            }
            #endregion Ответ Modbus 

            return bufferSender;
        }
    }



    internal class SerialPortOpros
    {
        //Мастер
        //private CommunicationMaster MasterCommunication;

        public byte[] Opros(ProjectChannelDevice channel)
        {
            ////////////////Переменная
            byte[] bufferSender = (byte[])null;
            string tmp_bufferSender = string.Empty;
            ////////////////Переменная


            SerialPort sp = new SerialPort(channel.SerialPortName, Convert.ToInt32(channel.SerialPortBaudRate), (Parity)Enum.Parse(typeof(Parity), channel.SerialPortParity), Convert.ToInt32(channel.SerialPortDataBits), (StopBits)Enum.Parse(typeof(StopBits), channel.SerialPortStopBits));
            sp.WriteTimeout = channel.WriteTimeout;
            sp.ReadTimeout = channel.ReadTimeout;
            sp.Handshake = (Handshake)Enum.Parse(typeof(Handshake), channel.SerialPortHandshake);
            sp.DtrEnable = channel.SerialPortDtrEnable;
            sp.RtsEnable = channel.SerialPortRtsEnable;
            sp.ReceivedBytesThreshold = channel.SerialPortReceivedBytesThreshold;

            //Объявляем последовательный порт
            //SerialPortAdapter MasterSerialPort = new SerialPortAdapter(sp);

            //DebugerLog("[SerialPort]: "+ sp.PortName + ", "+ sp.BaudRate + ", "+ sp.DataBits + ", "+ sp.Parity + ", "+ sp.StopBits + "");

            //if (MasterCommunication != null)
            //{
            //    MasterCommunication.Disconnection();
            //}

            //MasterCommunication = new SerialPortAdapter(sp);
            //MasterCommunication.Connection();
            #endregion Конфигурирование последовательного порта

            #region Отправка и получение данных
            //Последовательный порт
            //Отправка запроса
            //MasterCommunication.Write(bufferSender);
            //Время ожидания запроса по таймауту
            //Время начала ожидания
            long timeout_start = Environment.TickCount;
            //Время окончания ожидания
            long timeout_stop = timeout_start + Convert.ToInt64(channel.ReadTimeout);
            //Начинается цикл, который работает до тех пор пока: - не выйдет время
            while (Environment.TickCount < timeout_stop)
            {
                //Временный буфер
                //byte[] tmp_bufferSenderSP = MasterCommunication.Read();
                //if (tmp_bufferSenderSP.Length > 0)
                //{
                //    bufferSender = new byte[tmp_bufferSenderSP.Length];
                //    bufferSender = tmp_bufferSenderSP;
                //    goto WHILE_END;
                //}
            }
        WHILE_END:
            try
            {
                //Закрываем подключение
                //MasterCommunication.Disconnection();
                //Возвращаем результат
                return bufferSender;
            }
            catch { return bufferSender; }
            #endregion Отправка и получение данных
        }
    }