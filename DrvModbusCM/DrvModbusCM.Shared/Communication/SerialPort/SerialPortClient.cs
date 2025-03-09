using Scada.Data.Entities;
using Scada.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;

public class SerialPortClient : IDisposable
{
    private SerialPort serialClient = new SerialPort();

    private byte[] bufferSender = new byte[2048];
    private byte[] bufferReceiver = new byte[2048];
    private int countBufferReceiver = 0;

    private static int writeTimeout = 1000;
    private static int readTimeout = 1000;

    private static bool _connected = false;

    private const string NewLine = "\r\n";

    public SerialPortClient()
    {
        this.serialClient = new SerialPort();
        this.serialClient.NewLine = NewLine;
        this.serialClient.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

    public SerialPortClient(SerialPort serialPort)
    {
        this.serialClient = serialPort;
        this.serialClient.NewLine = NewLine;
        this.serialClient.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

    public SerialPortClient(string serialPortName, int serialPortBaudRate, string serialPortParity, int serialPortDataBits, string serialPortStopBits)
    {
        this.serialClient = new SerialPort(serialPortName, serialPortBaudRate, (Parity)Enum.Parse(typeof(Parity), serialPortParity), serialPortDataBits, (StopBits)Enum.Parse(typeof(StopBits), serialPortStopBits));
        this.serialClient.NewLine = NewLine;
        this.serialClient.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
    }

    ~SerialPortClient()
    {
        this.Dispose();
    }

    public void Dispose()
    {
        if (this.serialClient != null)
        {
            this.serialClient = null;
        }

        SerialPortClient._connected = false;
    }

    public void Connection()
    {
        if (StatusPort())
        {
            this.serialClient.Close();
        }
        else
        {
            this.serialClient.Open();
        }
    }

    public void Disconnection()
    {
        if (StatusPort())
        {
            this.serialClient.Close();
        }
    }

    public bool StatusPort()
    {
        return _connected = this.serialClient.IsOpen;
    }

    public int InfiniteTimeout
    {
        get { return SerialPort.InfiniteTimeout; }
    }

    public int ReadTimeout
    {
        get { return serialClient.ReadTimeout; }
        set { serialClient.ReadTimeout = value; }
    }

    public int WriteTimeout
    {
        get { return serialClient.WriteTimeout; }
        set { serialClient.WriteTimeout = value; }
    }

    #region Data
    public void Data(string serialPortName, int serialPortBaudRate, string serialPortParity, int serialPortDataBits, string serialPortStopBits, string serialPortHandshake, int serialPortReceivedBytesThreshold, bool serialPortDtrEnable, bool serialPortRtsEnable,  int writeTimeout, int readTimeout, byte[] bufferSender, ref byte[] bufferReceiver, ref string errMsg)
    {
        bufferReceiver = WriteData(serialPortName, serialPortBaudRate, serialPortParity, serialPortDataBits, serialPortStopBits, serialPortHandshake, serialPortReceivedBytesThreshold, serialPortDtrEnable, serialPortRtsEnable, writeTimeout, readTimeout, bufferSender, ref errMsg);
    }

    private byte[] WriteData(string serialPortName, int serialPortBaudRate, string serialPortParity, int serialPortDataBits, string serialPortStopBits, string serialPortHandshake, int serialPortReceivedBytesThreshold, bool serialPortDtrEnable, bool serialPortRtsEnable, int writeTimeout, int readTimeout, byte[] bufferSender, ref string errMsg)
    {
        try
        {
            #region Конфигурирование последовательного порта
            //Создаем последовательный порт и передаем ему настройки и параметры
            serialClient = new SerialPort(serialPortName, serialPortBaudRate, (Parity)Enum.Parse(typeof(Parity), serialPortParity), serialPortDataBits, (StopBits)Enum.Parse(typeof(StopBits), serialPortStopBits));
            serialClient.WriteTimeout = writeTimeout;
            serialClient.ReadTimeout = readTimeout;
            serialClient.Handshake = (Handshake)Enum.Parse(typeof(Handshake), serialPortHandshake);
            serialClient.DtrEnable = serialPortDtrEnable;
            serialClient.RtsEnable = serialPortRtsEnable;
            serialClient.ReceivedBytesThreshold = serialPortReceivedBytesThreshold;

            if (!StatusPort())
            {
                Connection();
            }

            #endregion Конфигурирование последовательного порта

            #region Отправка и получение данных


            if (StatusPort())
            {
                serialClient.DiscardOutBuffer();
                serialClient.DiscardInBuffer();
                //Отправка запроса
                serialClient.Write(bufferSender, 0, bufferSender.Length);


                //Время ожидания запроса по таймауту
                //Время начала ожидания
                long timeout_start = Environment.TickCount;
                //Время окончания ожидания
                long timeout_stop = timeout_start + Convert.ToInt64(readTimeout);
                // задали размер массива
                byte[] readingData = new byte[bufferReceiver.Length];
                int countDeviceData = 0;
                // а сама массив на прием делаем пустым
                bufferReceiver = (byte[])null;
                
                // Начинается цикл, который работает до тех пор пока: -не выйдет время
                while (Environment.TickCount < timeout_stop)
                {
                    if (serialClient.BytesToRead > 0)
                    {
                        countDeviceData = serialClient.Read(readingData, 0, readingData.Length);
                        bufferReceiver = new byte[countDeviceData];
                        Array.Copy((Array)readingData, (Array)bufferReceiver, countDeviceData);
                        goto WHILE_END;
                    }
                }
            WHILE_END:
                try
                {
                    //Закрываем подключение
                    Disconnection();
                }
                catch { }
                Thread.Sleep(10);
                #endregion Отправка и получение данных
                return bufferReceiver;
            }
            else
            {
                return (byte[])null;
            }
        }
        catch (Exception ex)
        {
            //Отдаём ошибку, что "Невозможно подключиться."
            errMsg += ex.Message.ToString();
            return (byte[])null;
        }

    }

    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        try
        {
            while (0 != sp.BytesToRead)
            {
                if (countBufferReceiver < bufferReceiver.Length - 2)
                {
                    bufferReceiver[countBufferReceiver++] = (byte)sp.ReadByte();
                    bufferReceiver[countBufferReceiver] = 0;
                }
                else
                {
                    sp.ReadByte();
                }
                    
            }
        }
        catch { }
    }

    #endregion Data


}

