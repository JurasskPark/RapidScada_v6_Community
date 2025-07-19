using Scada.Comm.Channels;
using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Channels;

namespace Scada.Comm.Drivers.DrvModbusCM
{
    internal class DriverThread
    {
        public DriverThread()
        {
            project = new Project();
            clients = new List<DriverClient>();
        }

        public DriverThread(Project project)
        {
            this.project = project;
            this.clients = new List<DriverClient>();
            foreach (ProjectChannel channel in project.Driver.GroupChannel.Group)
            {
                clients.Add(new DriverClient(channel));
            }
        }

        #region Variables
        public Project project { get; set; } 
        public List<DriverClient> clients { get; set; }
        #endregion Variables

        public void ThreadsStart()
        {
            if (clients != null && clients.Count > 0)
            {
                foreach (DriverClient client in clients)
                {
                    // делаем признак, что канал можно запускать
                    client.Channel.ThreadEnabled = true;
                    //А вот если пользователь выставил, что этот канал не надо запускать, то его пропускаем и не трогаем
                    if (client.Channel.Enabled == true)
                    {
                        //int port = 0;
                        //if (client.Channel.GatewayTypeProtocol == 0)
                        //{
                        //    //Если шлюз не указан т.е. выключен, то генерируем порт 
                        //    port = GENERATE_TCP_SERVER_PORT.PORT_NEW();
                        //}
                        //else
                        //{
                        //    bool checked_port = GENERATE_TCP_SERVER_PORT.CheckAvailableServerPort(Convert.ToInt32(thread_channel.GatewayPort));
                        //    if (checked_port == false)
                        //    {
                        //        MessageBox.Show("Указанный порт " + thread_channel.GatewayPort + " занят! Попробуйте другой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        return;
                        //    }

                        //    port = thread_channel.GatewayPort;
                        //}

                        //Получение RxTx 
                        DriverClient.EventHandlerEventDevicePollTxRx = new DriverClient.EventDevicePollTxRx(DevicePollTxRxGet);
                        //Получение лога
                        DriverClient.OnDebug = new DriverClient.DebugData(DevicePollLogGet);
                        //Получение информации с TCP сервера
                        //ThreadModbusDevicesPoll.OnDebugTCPServer = new ThreadModbusDevicesPoll.DebugDataTCPServer(DevicePollTCPServerLogGet);

                        new Thread(new ParameterizedThreadStart(client.ExecuteCycle))
                        {
                            IsBackground = true
                        }.Start((object)client);
                    }

                }
            }
        }

        public void ThreadsStop()
        {
            if (clients != null && clients.Count > 0)
            {
                foreach (DriverClient client in clients)
                {
                    client.Channel.ThreadEnabled = false;
                }
            }
        }
        //Получение RxTx
        public void DevicePollTxRxGet(Guid id, string type, int data)
        {
            //try
            //{
            //    if (!IsHandleCreated)
            //    {
            //        this.CreateControl();
            //    }

            //    if (IsHandleCreated)
            //    {
            //        this.Invoke((MethodInvoker)delegate
            //        {
            //            if (type == "Tx")
            //            {
            //                ModbusDevicePoolTx = ModbusDevicePoolTx + data;
            //                tls_DevicePoolTx.Text = ModbusDevicePoolTx.ToString();
            //            }

            //            if (type == "Rx")
            //            {
            //                ModbusDevicePoolRx = ModbusDevicePoolRx + data;
            //                tls_DevicePoolRx.Text = ModbusDevicePoolRx.ToString();
            //            }
            //        });
            //    }
            //    else
            //    {
            //        if (type == "Tx")
            //        {
            //            ModbusDevicePoolTx = ModbusDevicePoolTx + data;
            //            tls_DevicePoolTx.Text = ModbusDevicePoolTx.ToString();
            //        }

            //        if (type == "Rx")
            //        {
            //            ModbusDevicePoolRx = ModbusDevicePoolRx + data;
            //            tls_DevicePoolRx.Text = ModbusDevicePoolRx.ToString();
            //        }
            //    }
            //}
            //catch { }
        }


        public void DevicePollLogGet(Guid id, string text)
        {
            //try
            //{
            //    //Если выбранный последний канал не совпадает, с потоком канала, то не добавляем его на форму лога
            //    if (channelLogID != channel_id)
            //    {
            //        return;
            //    }

            //    if (!IsHandleCreated)
            //    {
            //        this.CreateControl();
            //    }

            //    if (IsHandleCreated)
            //    {
            //        this.Invoke((MethodInvoker)delegate
            //        {
            //            rch_Debug.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + text + Environment.NewLine);
            //            rch_Debug.ScrollToCaret();
            //            rch_Debug.Focus();

            //            //Если количество строк, больше 200, то очищаем RichTextBox
            //            //Число 200 беретеся из Настроек
            //            if (rch_Debug.Lines.Count() > 200)
            //            {
            //                rch_Debug.Text = "";
            //            }
            //        });
            //    }
            //    else
            //    {
            //        rch_Debug.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + text + Environment.NewLine);
            //        rch_Debug.ScrollToCaret();
            //        rch_Debug.Focus();

            //        //Если количество строк, больше 200, то очищаем RichTextBox
            //        //Число 200 беретеся из Настроек
            //        if (rch_Debug.Lines.Count() > 200)
            //        {
            //            rch_Debug.Text = "";
            //        }
            //    }

            //}
            //catch { }
        }

        public void DevicePollTCPServerLogGet(Guid id, string text)
        {
            //    try
            //    {
            //        //Если выбранный последний канал не совпадает, с потоком канала, то не добавляем его на форму лога
            //        if (channelLogID != channel_id)
            //        {
            //            return;
            //        }

            //        if (!IsHandleCreated)
            //        {
            //            this.CreateControl();
            //        }

            //        if (IsHandleCreated)
            //        {
            //            this.Invoke((MethodInvoker)delegate
            //            {
            //                rch_TCPServerLog.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + text + Environment.NewLine);
            //                rch_TCPServerLog.ScrollToCaret();
            //                rch_TCPServerLog.Focus();

            //                //Если количество строк, больше 200, то очищаем RichTextBox
            //                //Число 200 беретеся из Настроек
            //                if (rch_TCPServerLog.Lines.Count() > 200)
            //                {
            //                    rch_TCPServerLog.Text = "";
            //                }
            //            });
            //        }
            //        else
            //        {
            //            rch_TCPServerLog.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "] " + text + Environment.NewLine);
            //            rch_TCPServerLog.ScrollToCaret();
            //            rch_TCPServerLog.Focus();

            //            //Если количество строк, больше 200, то очищаем RichTextBox
            //            //Число 200 беретеся из Настроек
            //            if (rch_TCPServerLog.Lines.Count() > 200)
            //            {
            //                rch_TCPServerLog.Text = "";
            //            }
            //        }

            //    }
            //    catch { }
        }
    }
}

