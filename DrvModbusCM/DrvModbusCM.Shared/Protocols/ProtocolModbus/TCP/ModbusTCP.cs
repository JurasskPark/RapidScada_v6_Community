using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ModbusTCP
{
    #region Переменные
    public int byteNumberFunctionReceived = 7;
    public int byteNumberAmountDataReceived = 8;
    #endregion Переменные

    #region Формирование запроса по протоколу Modbus TCP
    public byte[] CalculateSendData(ushort Address, ushort FunctionCode, ushort RegisterStartAddress, ushort RegisterCount, ushort[] Value)
    {
        byte[] byte_Frame = new byte[0];
        if (FunctionCode == 1 || FunctionCode == 2 || FunctionCode == 3 || FunctionCode == 4)
        {
            byte_Frame = Read(FunctionCode, Address, FunctionCode, RegisterStartAddress, RegisterCount);
            return byte_Frame;
        }
        else if (FunctionCode == 5 || FunctionCode == 6)
        {
            byte_Frame = Write(FunctionCode, Address, FunctionCode, RegisterStartAddress, HEX_WORD.ToByteArray(Value));
            return byte_Frame;
        }
        else if (FunctionCode == 15)
        {
            //Сколько в массиве переменых
            bool[] tmp_Buffer = new bool[Value.Length];
            //Жирный костыль... Ну  получается, что регистр True = 65280 (FF00), а нам нужно теперь обратно получить True
            for (int i = 0; i < Value.Length; i++)
            {
                if (Value[i] == 65280)
                {
                    tmp_Buffer[i] = true;
                }
                else
                {
                    tmp_Buffer[i] = false;
                }
            }
            byte[] tmp_Values = HEX_BOOLEAN.ToByteArray(tmp_Buffer);
            byte_Frame = WriteMultipleCoils(FunctionCode, Address, FunctionCode, RegisterStartAddress, RegisterCount, tmp_Values);
            return byte_Frame;
        }
        else if (FunctionCode == 16)
        {
            byte_Frame = WriteAll(FunctionCode, Address, FunctionCode, RegisterStartAddress, HEX_WORD.ToByteArray(Value));
            return byte_Frame;
        }
        else if (FunctionCode == 99)
        {
            byte_Frame = HEX_WORD.ToByteArray(Value);
            return byte_Frame;
        }
        return byte_Frame;
    }

    private byte[] Read(ushort ID, ushort Address, ushort FunctionCode, ushort RegisterStartAddress, ushort RegisterCount)
    {
        byte[] frame = new byte[12];
        frame[0] = (byte)(ID >> 8);                         //Идентификатор транзакции High
        frame[1] = (byte)(ID);                              //Идентификатор транзакции Low
        frame[2] = 0x0;                                     //Идентификатор протокола High
        frame[3] = 0x0;                                     //Идентификатор протокола Low
        frame[4] = 0x0;                                     //Длина сообщения (0 байт) High
        frame[5] = 0x6;                                     //Длина сообщения (6 байт (идут следом)) High
        frame[6] = (byte)(Address);                   //Адрес устройства 
        frame[7] = (byte)(FunctionCode);                    //Функциональный код (функция, которой читаем или записываем)    
        frame[8] = (byte)(RegisterStartAddress >> 8);       //Адрес первого регистра High
        frame[9] = (byte)(RegisterStartAddress);            //Адрес первого регистра Low  
        frame[10] = (byte)(RegisterCount >> 8);             //Количество требуемых регистров High
        frame[11] = (byte)(RegisterCount);                  //Количество требуемых регистров Low  	
        return frame;
    }

    private byte[] Write(ushort ID, ushort Address, ushort FunctionCode, ushort RegisterStartAddress, byte[] Value)
    {
        int size = Value.Length;
        byte[] frame = new byte[10 + size];
        frame[0] = (byte)(ID >> 8);
        frame[1] = (byte)(ID);
        frame[5] = (byte)(4 + size);
        frame[6] = (byte)(Address);
        frame[7] = (byte)(FunctionCode);
        frame[8] = (byte)(RegisterStartAddress >> 8);
        frame[9] = (byte)(RegisterStartAddress);
        Array.Copy(Value, 0, frame, 10, size);
        return frame;
    }

    private byte[] WriteAll(ushort ID, ushort Address, ushort FunctionCode, ushort RegisterStartAddress, byte[] Values)
    {
        int size = Values.Length;
        byte[] frame = new byte[13 + size];
        frame[0] = (byte)(ID >> 8);
        frame[1] = (byte)(ID);
        frame[2] = 0;
        frame[3] = 0;
        frame[4] = 0;
        frame[5] = (byte)(4 + size);
        frame[6] = (byte)(Address);
        frame[7] = (byte)(FunctionCode);
        frame[8] = (byte)(RegisterStartAddress >> 8);
        frame[9] = (byte)(RegisterStartAddress);
        ushort amount = (ushort)(size / 2);
        frame[10] = (byte)(amount >> 8);
        frame[11] = (byte)amount;
        frame[12] = (byte)size;
        Array.Copy(Values, 0, frame, 13, size);
        return frame;
    }

    private byte[] WriteMultipleCoils(ushort ID, ushort Address, ushort FunctionCode, ushort RegisterStartAddress, ushort RegisterCount, byte[] Values)
    {
        int size = Values.Length;
        byte[] frame = new byte[13 + size];
        frame[0] = (byte)(ID >> 8);
        frame[1] = (byte)ID;
        frame[2] = 0;
        frame[3] = 0;
        frame[4] = 0;
        frame[5] = (byte)(7 + size);
        frame[6] = (byte)(Address);
        frame[7] = (byte)(FunctionCode);
        frame[8] = (byte)(RegisterStartAddress >> 8);
        frame[9] = (byte)(RegisterStartAddress);
        frame[10] = (byte)(RegisterCount >> 8);
        frame[11] = (byte)RegisterCount;
        frame[12] = (byte)size;
        Array.Copy(Values, 0, frame, 13, size);
        return frame;
    }
    #endregion Формирование запроса по протоколу Modbus TCP

    #region Формирование ответа по запроса Modbus TCP
    public byte[] ResponseMaker(ProjectDevice Device, byte[] bufferReceiver)
    {
        byte[] byteError = HEX_STRING.HEXSTRING_TO_BYTEARRAY("0B.AD.");
        return byteError;
        //ushort RegisterStartAddress = 0;
        //ushort RegisterCount = 0;
        //byte[] bytescount = (byte[])null;
        //ushort CountArray = 0;
        //ushort Value = 0;
        //ushort[] Values = (ushort[])null;


        //byte[] bufferSender = (byte[])null;
        //byte[] byteError = HEX_STRING.HEXSTRING_TO_BYTEARRAY("0B.AD.");

        ////Устройство не найдено или не Online
        //if (Device == null || Device.Status != 1)
        //{
        //    return byteError;
        //}

        ////Смотрим по функции что запрашивают и что будем отвечать
        //switch (bufferReceiver[7])
        //{
        //    //Функция 01
        //    case 1:
        //        if (bufferReceiver.Length < 12)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_01 = new byte[2];
        //        RegisterStartAddressArray_01[0] = bufferReceiver[8];
        //        RegisterStartAddressArray_01[1] = bufferReceiver[9];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_01);

        //        byte[] RegisterCountArray_01 = new byte[2];
        //        RegisterCountArray_01[0] = bufferReceiver[10];
        //        RegisterCountArray_01[1] = bufferReceiver[11];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_01);

        //        //Если нет таких регистров, отдаём ошибку
        //        if (!Device.CoilsExists(RegisterStartAddress, RegisterCount))
        //        {
        //            goto ERROR;
        //        }

        //        bufferSender = new byte[9 + (RegisterCount * 2)];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = (byte)0;
        //        bufferSender[3] = (byte)0;
        //        bytescount = BitConverter.GetBytes((int)RegisterCount * 2 + 3);
        //        bufferSender[4] = bytescount[1];
        //        bufferSender[5] = bytescount[0];
        //        bufferSender[6] = bufferReceiver[6];
        //        bufferSender[7] = bufferReceiver[7];
        //        bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 2));

        //        bool[] Coils = new bool[(RegisterCount)];
        //        for (int index = 0; index < Coils.Length; ++index)
        //        {
        //            Coils[index] = Device.GetBooleanCoil((ushort)(RegisterStartAddress + (uint)index));
        //        }
        //        byte[] bufferSenderCoils = HEX_BOOLEAN.ToByteArray(Coils);

        //        Array.Copy(bufferSenderCoils, 0, bufferSender, 9, bufferSenderCoils.Length);

        //        return bufferSender;
        //    //Функция 02
        //    case 2:
        //        if (bufferReceiver.Length < 12)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_02 = new byte[2];
        //        RegisterStartAddressArray_02[0] = bufferReceiver[8];
        //        RegisterStartAddressArray_02[1] = bufferReceiver[9];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_02);

        //        byte[] RegisterCountArray_02 = new byte[2];
        //        RegisterCountArray_02[0] = bufferReceiver[10];
        //        RegisterCountArray_02[1] = bufferReceiver[11];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_02);

        //        //Если нет таких регистров, отдаём ошибку
        //        if (!Device.CoilsExists(RegisterStartAddress, RegisterCount))
        //        {
        //            goto ERROR;
        //        }

        //        bufferSender = new byte[9 + (RegisterCount * 2)];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = (byte)0;
        //        bufferSender[3] = (byte)0;
        //        bytescount = BitConverter.GetBytes((int)RegisterCount * 2 + 3);
        //        bufferSender[4] = bytescount[1];
        //        bufferSender[5] = bytescount[0];
        //        bufferSender[6] = bufferReceiver[6];
        //        bufferSender[7] = bufferReceiver[7];
        //        bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 2));

        //        bool[] DiscreteInputs = new bool[(RegisterCount)];
        //        for (int index = 0; index < DiscreteInputs.Length; ++index)
        //        {
        //            DiscreteInputs[index] = Device.GetBooleanDiscreteInput((ushort)(RegisterStartAddress + (uint)index));
        //        }
        //        byte[] bufferSenderDiscreteInputs = HEX_BOOLEAN.ToByteArray(DiscreteInputs);

        //        Array.Copy(bufferSenderDiscreteInputs, 0, bufferSender, 9, bufferSenderDiscreteInputs.Length);

        //        return bufferSender;
        //    //Функция 03
        //    case 3:
        //        if (bufferReceiver.Length < 12)
        //        {
        //            goto ERROR;
        //        }

        //        if (Device.DeviceRegistersBytes == 0) //2 байт
        //        {
        //            byte[] RegisterStartAddressArray_03 = new byte[2];
        //            RegisterStartAddressArray_03[0] = bufferReceiver[8];
        //            RegisterStartAddressArray_03[1] = bufferReceiver[9];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_03);

        //            byte[] RegisterCountArray_03 = new byte[2];
        //            RegisterCountArray_03[0] = bufferReceiver[10];
        //            RegisterCountArray_03[1] = bufferReceiver[11];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_03);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.HoldingRegistersExists(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            bufferSender = new byte[9 + (RegisterCount * 2)];
        //            bufferSender[0] = bufferReceiver[0];
        //            bufferSender[1] = bufferReceiver[1];
        //            bufferSender[2] = (byte)0;
        //            bufferSender[3] = (byte)0;
        //            bytescount = BitConverter.GetBytes((int)RegisterCount * 2 + 3);
        //            bufferSender[4] = bytescount[1];
        //            bufferSender[5] = bytescount[0];
        //            bufferSender[6] = bufferReceiver[6];
        //            bufferSender[7] = bufferReceiver[7];
        //            bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 2));

        //            for (int index = 0; index < (int)RegisterCount; ++index)
        //            {
        //                byte[] bytes = BitConverter.GetBytes(Device.GetIntHoldingRegister(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                bufferSender[index * 2 + 9] = bytes[1];
        //                bufferSender[index * 2 + 10] = bytes[0];
        //            }

        //            return bufferSender;
        //        }
        //        else if (Device.DeviceRegistersBytes == 1) //4 байт
        //        {
        //            byte[] RegisterStartAddressArray_03 = new byte[2];
        //            RegisterStartAddressArray_03[0] = bufferReceiver[8];
        //            RegisterStartAddressArray_03[1] = bufferReceiver[9];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_03);

        //            byte[] RegisterCountArray_03 = new byte[2];
        //            RegisterCountArray_03[0] = bufferReceiver[10];
        //            RegisterCountArray_03[1] = bufferReceiver[11];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_03);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.HoldingRegistersExists_4(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            if (Device.DeviceGatewayRegistersBytes == 0) //2 байт (шлюз)
        //            {
        //                bufferSender = new byte[9 + (RegisterCount * 2)];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = (byte)0;
        //                bufferSender[3] = (byte)0;
        //                bytescount = BitConverter.GetBytes((int)RegisterCount * 2 + 3);
        //                bufferSender[4] = bytescount[1];
        //                bufferSender[5] = bytescount[0];
        //                bufferSender[6] = bufferReceiver[6];
        //                bufferSender[7] = bufferReceiver[7];
        //                bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 2));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    int AddressCount = Convert.ToUInt16((int)RegisterStartAddress + index);
        //                    if (AddressCount % 2 == 0)
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index + (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntHoldingRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 9] = bytes[3];
        //                        bufferSender[index * 2 + 10] = bytes[2];
        //                    }
        //                    else
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index - (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntHoldingRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 9] = bytes[1];
        //                        bufferSender[index * 2 + 10] = bytes[0];
        //                    }
        //                }

        //                return bufferSender;
        //            }
        //            else if (Device.DeviceGatewayRegistersBytes == 1) //4 байт (шлюз)
        //            {
        //                bufferSender = new byte[9 + (RegisterCount * 4)];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = (byte)0;
        //                bufferSender[3] = (byte)0;
        //                bytescount = BitConverter.GetBytes((int)RegisterCount * 4 + 3);
        //                bufferSender[4] = bytescount[1];
        //                bufferSender[5] = bytescount[0];
        //                bufferSender[6] = bufferReceiver[6];
        //                bufferSender[7] = bufferReceiver[7];
        //                bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 4));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    byte[] bytes = BitConverter.GetBytes(Device.GetUIntHoldingRegister_4(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                    bufferSender[index * 4 + 9] = bytes[3];
        //                    bufferSender[index * 4 + 10] = bytes[2];
        //                    bufferSender[index * 4 + 11] = bytes[1];
        //                    bufferSender[index * 4 + 12] = bytes[0];
        //                }

        //                return bufferSender;
        //            }
        //        }
        //        return byteError;

        //    //Функция 04
        //    case 4:
        //        if (bufferReceiver.Length < 12)
        //        {
        //            goto ERROR;
        //        }

        //        if (Device.DeviceRegistersBytes == 0) //2 байт
        //        {
        //            byte[] RegisterStartAddressArray_04 = new byte[2];
        //            RegisterStartAddressArray_04[0] = bufferReceiver[8];
        //            RegisterStartAddressArray_04[1] = bufferReceiver[9];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_04);

        //            byte[] RegisterCountArray_04 = new byte[2];
        //            RegisterCountArray_04[0] = bufferReceiver[10];
        //            RegisterCountArray_04[1] = bufferReceiver[11];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_04);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.InputRegistersExists(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            bufferSender = new byte[9 + (RegisterCount * 2)];
        //            bufferSender[0] = bufferReceiver[0];
        //            bufferSender[1] = bufferReceiver[1];
        //            bufferSender[2] = (byte)0;
        //            bufferSender[3] = (byte)0;
        //            bytescount = BitConverter.GetBytes((int)RegisterCount * 2 + 3);
        //            bufferSender[4] = bytescount[1];
        //            bufferSender[5] = bytescount[0];
        //            bufferSender[6] = bufferReceiver[6];
        //            bufferSender[7] = bufferReceiver[7];
        //            bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 2));

        //            for (int index = 0; index < (int)RegisterCount; ++index)
        //            {
        //                byte[] bytes = BitConverter.GetBytes(Device.GetIntInputRegister(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                bufferSender[index * 2 + 9] = bytes[1];
        //                bufferSender[index * 2 + 10] = bytes[0];
        //            }

        //            return bufferSender;
        //        }
        //        else if (Device.DeviceRegistersBytes == 1) //4 байт
        //        {
        //            byte[] RegisterStartAddressArray_04 = new byte[2];
        //            RegisterStartAddressArray_04[0] = bufferReceiver[8];
        //            RegisterStartAddressArray_04[1] = bufferReceiver[9];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_04);

        //            byte[] RegisterCountArray_04 = new byte[2];
        //            RegisterCountArray_04[0] = bufferReceiver[10];
        //            RegisterCountArray_04[1] = bufferReceiver[11];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_04);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.InputRegistersExists_4(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            if (Device.DeviceGatewayRegistersBytes == 0) //2 байт (шлюз)
        //            {
        //                bufferSender = new byte[9 + (RegisterCount * 2)];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = (byte)0;
        //                bufferSender[3] = (byte)0;
        //                bytescount = BitConverter.GetBytes((int)RegisterCount * 2 + 3);
        //                bufferSender[4] = bytescount[1];
        //                bufferSender[5] = bytescount[0];
        //                bufferSender[6] = bufferReceiver[6];
        //                bufferSender[7] = bufferReceiver[7];
        //                bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 2));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    int AddressCount = Convert.ToUInt16((int)RegisterStartAddress + index);
        //                    if (AddressCount % 2 == 0)
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index + (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntInputRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 9] = bytes[3];
        //                        bufferSender[index * 2 + 10] = bytes[2];
        //                    }
        //                    else
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index - (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntInputRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 9] = bytes[1];
        //                        bufferSender[index * 2 + 10] = bytes[0];
        //                    }
        //                }
        //                return bufferSender;
        //            }
        //            else if (Device.DeviceGatewayRegistersBytes == 1) //4 байт (шлюз)
        //            {
        //                bufferSender = new byte[9 + (RegisterCount * 4)];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = (byte)0;
        //                bufferSender[3] = (byte)0;
        //                bytescount = BitConverter.GetBytes((int)RegisterCount * 4 + 3);
        //                bufferSender[4] = bytescount[1];
        //                bufferSender[5] = bytescount[0];
        //                bufferSender[6] = bufferReceiver[6];
        //                bufferSender[7] = bufferReceiver[7];
        //                bufferSender[8] = Decimal.ToByte((Decimal)(RegisterCount * 4));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    byte[] bytes = BitConverter.GetBytes(Device.GetUIntInputRegister_4(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                    bufferSender[index * 4 + 9] = bytes[3];
        //                    bufferSender[index * 4 + 10] = bytes[2];
        //                    bufferSender[index * 4 + 11] = bytes[1];
        //                    bufferSender[index * 4 + 12] = bytes[0];
        //                }
        //                return bufferSender;
        //            }
        //        }
        //        return byteError;

        //    //Функция 05
        //    case 5:
        //        if (bufferReceiver.Length < 11)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_05 = new byte[2];
        //        RegisterStartAddressArray_05[0] = bufferReceiver[8];
        //        RegisterStartAddressArray_05[1] = bufferReceiver[9];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_05);

        //        byte[] ValueArray_05 = new byte[2];
        //        ValueArray_05[0] = bufferReceiver[10];
        //        ValueArray_05[1] = bufferReceiver[11];
        //        Value = HEX_WORD.FromByteArray(ValueArray_05);

        //        if (Value == 65280)
        //        {
        //            Device.SetCoil(RegisterStartAddress, true);
        //        }
        //        else if (Value == 0)
        //        {
        //            Device.SetCoil(RegisterStartAddress, false);
        //        }
        //        else
        //        {
        //            //Кроме FF.00. и 00.00. цифр быть не должно
        //            goto ERROR;
        //        }
        //        //Ответ должен соотвествовать запросу
        //        return bufferReceiver;
        //    //Функция 06
        //    case 6:
        //        if (bufferReceiver.Length < 11)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_06 = new byte[2];
        //        RegisterStartAddressArray_06[0] = bufferReceiver[8];
        //        RegisterStartAddressArray_06[1] = bufferReceiver[9];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_06);

        //        byte[] ValueArray_06 = new byte[2];
        //        ValueArray_06[0] = bufferReceiver[10];
        //        ValueArray_06[1] = bufferReceiver[11];
        //        Value = HEX_WORD.FromByteArray(ValueArray_06);

        //        Device.SetHoldingRegister(RegisterStartAddress, Value);

        //        //Ответ должен соотвествовать запросу
        //        return bufferReceiver;
        //    //Функция 15
        //    case 15:
        //        if (bufferReceiver.Length < 11)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_15 = new byte[2];
        //        RegisterStartAddressArray_15[0] = bufferReceiver[8];
        //        RegisterStartAddressArray_15[1] = bufferReceiver[9];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_15);

        //        byte[] RegisterCountArray_15 = new byte[2];
        //        RegisterCountArray_15[0] = bufferReceiver[10];
        //        RegisterCountArray_15[1] = bufferReceiver[11];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_15);

        //        CountArray = (ushort)bufferReceiver[12];

        //        byte[] ValueArray_15 = new byte[CountArray];
        //        Array.Copy(bufferReceiver, 13, ValueArray_15, 0, CountArray);

        //        bool[] BooleanValues = new bool[RegisterCount];
        //        BooleanValues = HEX_BOOLEAN.ToArray(ValueArray_15);

        //        for (int index = 0; index < (int)BooleanValues.Length; ++index)
        //        {
        //            Device.SetCoil(Convert.ToUInt16((int)RegisterStartAddress + index), BooleanValues[index]);
        //        }

        //        bufferSender = new byte[12];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = bufferReceiver[2];
        //        bufferSender[3] = bufferReceiver[3];
        //        bufferSender[4] = bufferReceiver[4];
        //        bufferSender[5] = bufferReceiver[5];
        //        bufferSender[6] = bufferReceiver[6];
        //        bufferSender[7] = bufferReceiver[7];
        //        bufferSender[8] = bufferReceiver[8];
        //        bufferSender[9] = bufferReceiver[9];
        //        bufferSender[10] = bufferReceiver[10];
        //        bufferSender[11] = bufferReceiver[11];

        //        return bufferSender;
        //    //Функция 16
        //    case 16:
        //        if (bufferReceiver.Length < 11)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_16 = new byte[2];
        //        RegisterStartAddressArray_16[0] = bufferReceiver[8];
        //        RegisterStartAddressArray_16[1] = bufferReceiver[9];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_16);

        //        byte[] RegisterCountArray_16 = new byte[2];
        //        RegisterCountArray_16[0] = bufferReceiver[10];
        //        RegisterCountArray_16[1] = bufferReceiver[11];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_16);

        //        CountArray = (ushort)bufferReceiver[12];

        //        byte[] ValueArray_16 = new byte[CountArray];
        //        Array.Copy(bufferReceiver, 13, ValueArray_16, 0, CountArray);

        //        Values = new ushort[CountArray];
        //        Values = HEX_WORD.ToArray(ValueArray_16);

        //        for (int index = 0; index < (int)Values.Length; ++index)
        //        {
        //            Device.SetHoldingRegister(Convert.ToUInt16((int)RegisterStartAddress + index), Values[index]);
        //        }

        //        bufferSender = new byte[12];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = bufferReceiver[2];
        //        bufferSender[3] = bufferReceiver[3];
        //        bufferSender[4] = bufferReceiver[4];
        //        bufferSender[5] = bufferReceiver[5];
        //        bufferSender[6] = bufferReceiver[6];
        //        bufferSender[7] = bufferReceiver[7];
        //        bufferSender[8] = bufferReceiver[8];
        //        bufferSender[9] = bufferReceiver[9];
        //        bufferSender[10] = bufferReceiver[10];
        //        bufferSender[11] = bufferReceiver[11];

        //        return bufferSender;
        //    default:
        //    ERROR:
        //        //Раз ни одно условие не совпало, то отдаём ошибку
        //        byte[] bufferSender_Error = new byte[5];
        //        bufferSender_Error[0] = bufferReceiver[0];
        //        bufferSender_Error[1] = (byte)((uint)bufferReceiver[1] | 128U);
        //        bufferSender_Error[2] = (byte)1;
        //        bufferSender_Error[3] = (byte)0;
        //        bufferSender_Error[4] = (byte)0;
        //        return bufferSender_Error;
        //}
    }
    #endregion Формирование ответа по запроса Modbus TCP

    #region Проверка на корректность данных

    public bool ValidateData(byte[] bufferSender, byte[] bufferReceiver, ref string Message)
    {
        string errMessage = "[BAD]";
        string okMessage = "[OK]";
        bool result = true;

        //Проверяем пустые ли буферы на входе
        if (bufferSender == null || bufferReceiver == null)
        {
            result = false;
            Message = result ? okMessage : errMessage;
            return result;
        }
        //Проверяем transaction и protocol ID
        if (bufferSender[0] != bufferReceiver[0] &&
            bufferSender[1] != bufferReceiver[1] &&
            bufferReceiver[2] != 0 &&
            bufferReceiver[3] != 0)
        {
            result = false;
            Message = result ? okMessage : errMessage;
            return result;
        }
        //Проверяем ответило ли то устройство, которое мы опрашиваем
        if (bufferSender[6] != bufferReceiver[6])
        {
            result = false;
            Message = result ? okMessage : errMessage;
            return result;
        }
        //Проверяем, что функция запроса соотвествовать ответу
        if (bufferSender[7] != bufferReceiver[7])
        {
            result = false;
            Message = result ? okMessage : errMessage;
            return result;
        }
        //Если функция записи 5, 6, то запрос должен соотвествовать ответу
        if (bufferSender[7] == 5 || bufferSender[7] == 6)
        {
            //Сравниваем массивы
            if (!bufferSender.SequenceEqual(bufferReceiver))
            {
                result = false;
                Message = result ? okMessage : errMessage;
                return result;
            }
        }
        //Если функция записи 15, 16, то в ответе только информация о том, что RegisterStartAddress и RegisterCount получены и приняты
        if (bufferSender[7] == 15 || bufferSender[7] == 16)
        {
            if ((bufferSender[8] != bufferReceiver[8]) ||
                (bufferSender[9] != bufferReceiver[9]) ||
                (bufferSender[10] != bufferReceiver[10]) ||
                (bufferSender[11] != bufferReceiver[11]))
            {
                result = false;
                Message = result ? okMessage : errMessage;
                return result;
            }
        }
        //Если на месте функции, адрес фунции больше 128, то там ошибка и нам нужно эту ошибку отправить
        if (bufferReceiver[7] > 128)
        {
            byte exception = bufferReceiver[2];
            switch (exception)
            {
                case 1: Message = "Принятый код функции не может быть обработан."; break;
                case 2: Message = "Регистры, указанные в запросе, недоступны."; break;
                case 3: Message = "Значение, содержащееся в поле данных запроса, является недопустимой величиной."; break;
                case 4: Message = "Невосстанавливаемая ошибка имела место, пока ведомое устройство пыталось выполнить затребованное действие."; break;
                case 5: Message = "Ведомое устройство приняло запрос и обрабатывает его, но это требует много времени. Этот ответ предохраняет ведущее устройство от генерации ошибки тайм-аута."; break;
                case 6: Message = "Ведомое устройство занято обработкой команды. Ведущее устройство должно повторить сообщение позже, когда ведомое освободится."; break;
                case 7: Message = "Ведомое устройство не может выполнить программную функцию, заданную в запросе."; break;
                case 8: Message = "Ведомое устройство при чтении расширенной памяти обнаружило ошибку контроля четности."; break;
                case 100: Message = "Ошибка отправки данных."; break;
                case 101: Message = "Ошибка CRC-суммы."; break;
                case 102: Message = "Ошибка протокола."; break;
                case 103: Message = "Ошибка адреса."; break;
                case 104: Message = "Получено от устройства 0 байт."; break;
                case 128: Message = "Ошибка смещения."; break;
                case 253: Message = "Невозможно подключиться."; break;
                case 254: Message = "Соединение потеряно."; break;
                case 255: Message = "Время ожидания истекло."; break;
            }
            result = false;
            Message = "[BAD][" + Message + "]";
            return result;
        }

        return result;
    }

    #endregion Проверка на корректность данных

    #region Полученние массива данных

    public byte[] DecodeData(byte[] bufferReceiver)
    {
        byte[] NumArrayRegisters = null;

        switch ((int)bufferReceiver[7])
        {
            case 1:
            case 2:
            case 3:
            case 4:
                NumArrayRegisters = new byte[(int)bufferReceiver[8]];
                Array.Copy((Array)bufferReceiver, 9, (Array)NumArrayRegisters, 0, (int)bufferReceiver[8]);
                break;
        }

        return NumArrayRegisters;
    }

    #endregion Полученние массива данных
}

