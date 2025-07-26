using Scada.Comm.Drivers.DrvModbusCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class ModbusRTU
{
    #region Переменные
    public int byteNumberFunctionReceived = 1;
    public int byteNumberAmountDataReceived = 2;
    #endregion Переменные

    #region Формирование запроса по протоколу Modbus RTU
    public byte[] CalculateSendData(ushort Address, ushort FunctionCode, ushort RegisterStartAddress, ushort RegisterCount, ushort[] Value)
    {
        byte[] byte_Frame = new byte[0];
        if (FunctionCode == 1 || FunctionCode == 2 || FunctionCode == 3 || FunctionCode == 4)
        {
            byte_Frame = Read(Address, FunctionCode, RegisterStartAddress, RegisterCount);
            return byte_Frame;
        }
        else if (FunctionCode == 5 || FunctionCode == 6)
        {
            byte_Frame = Write(Address, FunctionCode, RegisterStartAddress, HEX_WORD.ToByteArray(Value));
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
            byte_Frame = WriteMultipleCoils(Address, FunctionCode, RegisterStartAddress, RegisterCount, tmp_Values);
            return byte_Frame;
        }
        else if (FunctionCode == 16)
        {
            byte_Frame = WriteAll(Address, FunctionCode, RegisterStartAddress, HEX_WORD.ToByteArray(Value));
            return byte_Frame;
        }
        else if (FunctionCode == 99)
        {
            byte_Frame = HEX_WORD.ToByteArray(Value);
            return byte_Frame;
        }
        return byte_Frame;
    }

    private byte[] Read(ushort Address, ushort FunctionCode, ushort RegisterStartAddress, ushort RegisterCount)
    {
        byte[] frame = new byte[8];
        frame[0] = (byte)(Address);
        frame[1] = (byte)(FunctionCode);
        frame[2] = (byte)(RegisterStartAddress >> 8);
        frame[3] = (byte)(RegisterStartAddress);
        frame[4] = (byte)(RegisterCount >> 8);
        frame[5] = (byte)(RegisterCount);
        byte[] CRC16 = CalucalteCRC16BYTE(frame);
        frame[frame.Length - 2] = CRC16[0];
        frame[frame.Length - 1] = CRC16[1];
        return frame;
    }

    private byte[] Write(ushort Address, ushort FunctionCode, ushort RegisterStartAddress, byte[] Value)
    {
        int size = Value.Length;
        byte[] frame = new byte[6 + size];
        frame[0] = (byte)(Address);
        frame[1] = (byte)(FunctionCode);
        frame[2] = (byte)(RegisterStartAddress >> 8);
        frame[3] = (byte)(RegisterStartAddress);
        Array.Copy(Value, 0, frame, 4, size);
        byte[] CRC16 = CalucalteCRC16BYTE(frame);
        frame[frame.Length - 2] = CRC16[0];
        frame[frame.Length - 1] = CRC16[1];
        return frame;
    }

    private byte[] WriteAll(ushort Address, ushort FunctionCode, ushort RegisterStartAddress, byte[] Values)
    {
        int size = Values.Length;
        byte[] frame = new byte[9 + size];
        frame[0] = (byte)(Address);
        frame[1] = (byte)(FunctionCode);
        frame[2] = (byte)(RegisterStartAddress >> 8);
        frame[3] = (byte)(RegisterStartAddress);
        ushort amount = (ushort)(size / 2);
        frame[4] = (byte)(amount >> 8);
        frame[5] = (byte)(amount);
        frame[6] = (byte)(size);
        Array.Copy(Values, 0, frame, 7, size);
        byte[] CRC16 = CalucalteCRC16BYTE(frame);
        frame[frame.Length - 2] = CRC16[0];
        frame[frame.Length - 1] = CRC16[1];
        return frame;
    }

    private byte[] WriteMultipleCoils(ushort Address, ushort FunctionCode, ushort RegisterStartAddress, ushort RegisterCount, byte[] Values)
    {
        int size = Values.Length;
        byte[] frame = new byte[9 + size];
        frame[0] = (byte)(Address);
        frame[1] = (byte)(FunctionCode);
        frame[2] = (byte)(RegisterStartAddress >> 8);
        frame[3] = (byte)(RegisterStartAddress);
        frame[4] = (byte)(RegisterCount >> 8);
        frame[5] = (byte)RegisterCount;
        frame[6] = (byte)size;
        Array.Copy(Values, 0, frame, 7, size);
        byte[] CRC16 = CalucalteCRC16BYTE(frame);
        frame[frame.Length - 2] = CRC16[0];
        frame[frame.Length - 1] = CRC16[1];
        return frame;
    }


    public static byte[] CalucalteCRC16BYTE(byte[] data)
    {
        ushort CRCFull = 0xFFFF;
        byte CRCHigh = 0xFF, CRCLow = 0xFF;
        char CRCLSB;
        byte[] CRC = new byte[2];
        for (int i = 0; i < (data.Length) - 2; i++)
        {
            CRCFull = (ushort)(CRCFull ^ data[i]);

            for (int j = 0; j < 8; j++)
            {
                CRCLSB = (char)(CRCFull & 0x0001);
                CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                if (CRCLSB == 1)
                    CRCFull = (ushort)(CRCFull ^ 0xA001);
            }
        }
        CRC[1] = CRCHigh = (byte)((CRCFull >> 8) & 0xFF);
        CRC[0] = CRCLow = (byte)(CRCFull & 0xFF);
        return CRC;
    }
    #endregion Формирование запроса по протоколу Modbus RTU

    #region Формирование ответа по запроса Modbus RTU
    public byte[] ResponseMaker(ProjectDevice Device, byte[] bufferReceiver)
    {
        byte[] byteError = HEX_STRING.HEXSTRING_TO_BYTEARRAY("0B.AD.");
        return byteError;
        //ushort RegisterStartAddress = 0;
        //ushort RegisterCount = 0;
        //ushort CountArray = 0;
        //ushort Value = 0;
        //ushort[] Values = (ushort[])null;

        //byte[] CRC16 = (byte[])null;
        //byte[] bufferSender = (byte[])null;
        //byte[] byteError = HEX_STRING.HEXSTRING_TO_BYTEARRAY("0B.AD.");

        ////Устройство не найдено или не Online
        //if (Device == null || Device.Status != 1)
        //{
        //    return byteError;
        //}

        ////Посчитаем CRC16
        //if (bufferReceiver.Length > 2)
        //{
        //    //Сами посчитали CRC сумму отняв последние два байта
        //    byte[] tmp_bufferReceiverNoCRC16 = ((IEnumerable<byte>)bufferReceiver).Take<byte>(bufferReceiver.Length - 2).ToArray<byte>();

        //    //Получили CRC
        //    uint tmp_CRC16 = (uint)ushort.MaxValue;
        //    for (uint index_1 = 0; (ulong)index_1 < (ulong)tmp_bufferReceiverNoCRC16.Length; ++index_1)
        //    {
        //        ushort tmp_Value = (ushort)tmp_bufferReceiverNoCRC16[(int)(uint)(UIntPtr)index_1];
        //        for (ushort index2 = 0; (int)index2 < 8; ++index2)
        //        {
        //            tmp_CRC16 = (((int)tmp_Value ^ (int)(ushort)tmp_CRC16) & 1) != 0 ? tmp_CRC16 >> 1 ^ 40961U : tmp_CRC16 >> 1;
        //            tmp_Value >>= 1;
        //        }
        //    }

        //    if ((int)bufferReceiver[bufferReceiver.Length - 2] == (int)(byte)((uint)tmp_CRC16 & (uint)byte.MaxValue))
        //    {
        //        bool result = (int)bufferReceiver[bufferReceiver.Length - 1] == (int)(byte)((uint)tmp_CRC16 >> 8);
        //        if (result == false)
        //        {
        //            return byteError;
        //        }
        //    }
        //}

        ////Смотрим по функции что запрашивают и что будем отвечать
        //switch (bufferReceiver[1])
        //{
        //    //Функция 01
        //    case 1:
        //        if (bufferReceiver.Length < 8)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_01 = new byte[2];
        //        RegisterStartAddressArray_01[0] = bufferReceiver[2];
        //        RegisterStartAddressArray_01[1] = bufferReceiver[3];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_01);

        //        byte[] RegisterCountArray_01 = new byte[2];
        //        RegisterCountArray_01[0] = bufferReceiver[4];
        //        RegisterCountArray_01[1] = bufferReceiver[5];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_01);

        //        //Если нет таких регистров, отдаём ошибку
        //        if (!Device.CoilsExists(RegisterStartAddress, RegisterCount))
        //        {
        //            goto ERROR;
        //        }

        //        bufferSender = new byte[5 + ((RegisterCount + 7) / 8)];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = Decimal.ToByte((Decimal)((RegisterCount + 7) / 8));

        //        bool[] Coils = new bool[(RegisterCount)];
        //        for (int index = 0; index < Coils.Length; ++index)
        //        {
        //            Coils[index] = Device.GetBooleanCoil((ushort)(RegisterStartAddress + (uint)index));
        //        }
        //        byte[] bufferSenderCoils = HEX_BOOLEAN.ToByteArray(Coils);

        //        Array.Copy(bufferSenderCoils, 0, bufferSender, 3, bufferSenderCoils.Length);

        //        CRC16 = CalucalteCRC16BYTE(bufferSender);
        //        bufferSender[bufferSender.Length - 2] = CRC16[0];
        //        bufferSender[bufferSender.Length - 1] = CRC16[1];
        //        return bufferSender;
        //    //Функция 02
        //    case 2:
        //        if (bufferReceiver.Length < 8)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_02 = new byte[2];
        //        RegisterStartAddressArray_02[0] = bufferReceiver[2];
        //        RegisterStartAddressArray_02[1] = bufferReceiver[3];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_02);

        //        byte[] RegisterCountArray_02 = new byte[2];
        //        RegisterCountArray_02[0] = bufferReceiver[4];
        //        RegisterCountArray_02[1] = bufferReceiver[5];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_02);

        //        //Если нет таких регистров, отдаём ошибку
        //        if (!Device.DiscreteInputsExists(RegisterStartAddress, RegisterCount))
        //        {
        //            goto ERROR;
        //        }

        //        bufferSender = new byte[5 + ((RegisterCount + 7) / 8)];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = Decimal.ToByte((Decimal)((RegisterCount + 7) / 8));

        //        bool[] DiscreteInputs = new bool[(RegisterCount)];
        //        for (int index = 0; index < DiscreteInputs.Length; ++index)
        //        {
        //            DiscreteInputs[index] = Device.GetBooleanDiscreteInput((ushort)(RegisterStartAddress + (uint)index));
        //        }
        //        byte[] bufferSenderDiscreteInputs = HEX_BOOLEAN.ToByteArray(DiscreteInputs);

        //        Array.Copy(bufferSenderDiscreteInputs, 0, bufferSender, 3, bufferSenderDiscreteInputs.Length);

        //        CRC16 = CalucalteCRC16BYTE(bufferSender);
        //        bufferSender[bufferSender.Length - 2] = CRC16[0];
        //        bufferSender[bufferSender.Length - 1] = CRC16[1];
        //        return bufferSender;
        //    //Функция 03
        //    case 3:
        //        if (bufferReceiver.Length < 8)
        //        {
        //            goto ERROR;
        //        }

        //        if (Device.DeviceRegistersBytes == 0) //2 байт
        //        {
        //            byte[] RegisterStartAddressArray_03 = new byte[2];
        //            RegisterStartAddressArray_03[0] = bufferReceiver[2];
        //            RegisterStartAddressArray_03[1] = bufferReceiver[3];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_03);

        //            byte[] RegisterCountArray_03 = new byte[2];
        //            RegisterCountArray_03[0] = bufferReceiver[4];
        //            RegisterCountArray_03[1] = bufferReceiver[5];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_03);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.HoldingRegistersExists(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            bufferSender = new byte[(int)RegisterCount * 2 + 5];
        //            bufferSender[0] = bufferReceiver[0];
        //            bufferSender[1] = bufferReceiver[1];
        //            bufferSender[2] = Decimal.ToByte((Decimal)((int)RegisterCount * 2));

        //            for (int index = 0; index < (int)RegisterCount; ++index)
        //            {
        //                byte[] bytes = BitConverter.GetBytes(Device.GetIntHoldingRegister(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                bufferSender[index * 2 + 3] = bytes[1];
        //                bufferSender[index * 2 + 4] = bytes[0];
        //            }

        //            CRC16 = CalucalteCRC16BYTE(bufferSender);
        //            bufferSender[bufferSender.Length - 2] = CRC16[0];
        //            bufferSender[bufferSender.Length - 1] = CRC16[1];
        //            return bufferSender;
        //        }
        //        else if (Device.DeviceRegistersBytes == 1) //4 байт
        //        {
        //            byte[] RegisterStartAddressArray_03 = new byte[2];
        //            RegisterStartAddressArray_03[0] = bufferReceiver[2];
        //            RegisterStartAddressArray_03[1] = bufferReceiver[3];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_03);

        //            byte[] RegisterCountArray_03 = new byte[2];
        //            RegisterCountArray_03[0] = bufferReceiver[4];
        //            RegisterCountArray_03[1] = bufferReceiver[5];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_03);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.HoldingRegistersExists_4(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            if (Device.DeviceGatewayRegistersBytes == 0) //2 байт (шлюз)
        //            {
        //                bufferSender = new byte[(int)RegisterCount * 2 + 5];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = Decimal.ToByte((Decimal)((int)RegisterCount * 2));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    int AddressCount = Convert.ToUInt16((int)RegisterStartAddress + index);
        //                    if (AddressCount % 2 == 0)
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index + (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntHoldingRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 3] = bytes[3];
        //                        bufferSender[index * 2 + 4] = bytes[2];
        //                    }
        //                    else
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index - (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntHoldingRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 3] = bytes[1];
        //                        bufferSender[index * 2 + 4] = bytes[0];
        //                    }
        //                }

        //                CRC16 = CalucalteCRC16BYTE(bufferSender);
        //                bufferSender[bufferSender.Length - 2] = CRC16[0];
        //                bufferSender[bufferSender.Length - 1] = CRC16[1];
        //                return bufferSender;
        //            }
        //            else if (Device.DeviceGatewayRegistersBytes == 1) //4 байт (шлюз)
        //            {
        //                bufferSender = new byte[(int)RegisterCount * 4 + 5];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = Decimal.ToByte((Decimal)((int)RegisterCount * 4));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    byte[] bytes = BitConverter.GetBytes(Device.GetUIntHoldingRegister_4(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                    bufferSender[index * 4 + 3] = bytes[3];
        //                    bufferSender[index * 4 + 4] = bytes[2];
        //                    bufferSender[index * 4 + 5] = bytes[1];
        //                    bufferSender[index * 4 + 6] = bytes[0];
        //                }

        //                CRC16 = CalucalteCRC16BYTE(bufferSender);
        //                bufferSender[bufferSender.Length - 2] = CRC16[0];
        //                bufferSender[bufferSender.Length - 1] = CRC16[1];
        //                return bufferSender;
        //            }
        //        }
        //        return byteError;

        //    //Функция 04
        //    case 4:
        //        if (bufferReceiver.Length < 8)
        //        {
        //            goto ERROR;
        //        }

        //        if (Device.DeviceRegistersBytes == 0) //2 байт
        //        {
        //            byte[] RegisterStartAddressArray_04 = new byte[2];
        //            RegisterStartAddressArray_04[0] = bufferReceiver[2];
        //            RegisterStartAddressArray_04[1] = bufferReceiver[3];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_04);

        //            byte[] RegisterCountArray_04 = new byte[2];
        //            RegisterCountArray_04[0] = bufferReceiver[4];
        //            RegisterCountArray_04[1] = bufferReceiver[5];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_04);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.InputRegistersExists(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            bufferSender = new byte[(int)RegisterCount * 2 + 5];
        //            bufferSender[0] = bufferReceiver[0];
        //            bufferSender[1] = bufferReceiver[1];
        //            bufferSender[2] = Decimal.ToByte((Decimal)((int)RegisterCount * 2));

        //            for (int index = 0; index < (int)RegisterCount; ++index)
        //            {
        //                byte[] bytes = BitConverter.GetBytes(Device.GetIntInputRegister(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                bufferSender[index * 2 + 3] = bytes[1];
        //                bufferSender[index * 2 + 4] = bytes[0];
        //            }

        //            CRC16 = CalucalteCRC16BYTE(bufferSender);
        //            bufferSender[bufferSender.Length - 2] = CRC16[0];
        //            bufferSender[bufferSender.Length - 1] = CRC16[1];
        //            return bufferSender;
        //        }
        //        else if (Device.DeviceRegistersBytes == 1) //4 байт
        //        {
        //            byte[] RegisterStartAddressArray_04 = new byte[2];
        //            RegisterStartAddressArray_04[0] = bufferReceiver[2];
        //            RegisterStartAddressArray_04[1] = bufferReceiver[3];
        //            RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_04);

        //            byte[] RegisterCountArray_04 = new byte[2];
        //            RegisterCountArray_04[0] = bufferReceiver[4];
        //            RegisterCountArray_04[1] = bufferReceiver[5];
        //            RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_04);

        //            //Если нет таких регистров, отдаём ошибку
        //            if (!Device.InputRegistersExists_4(RegisterStartAddress, RegisterCount))
        //            {
        //                goto ERROR;
        //            }

        //            if (Device.DeviceGatewayRegistersBytes == 0) //2 байт (шлюз)
        //            {
        //                bufferSender = new byte[(int)RegisterCount * 4 + 5];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = Decimal.ToByte((Decimal)((int)RegisterCount * 4));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    int AddressCount = Convert.ToUInt16((int)RegisterStartAddress + index);
        //                    if (AddressCount % 2 == 0)
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index + (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntInputRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 3] = bytes[3];
        //                        bufferSender[index * 2 + 4] = bytes[2];
        //                    }
        //                    else
        //                    {
        //                        int tmpAddress = ((int)RegisterStartAddress + index - (AddressCount % 2)) / 2;
        //                        byte[] bytes = BitConverter.GetBytes(Device.GetUIntInputRegister_4(Convert.ToUInt16(tmpAddress)));
        //                        bufferSender[index * 2 + 3] = bytes[1];
        //                        bufferSender[index * 2 + 4] = bytes[0];
        //                    }
        //                }

        //                CRC16 = CalucalteCRC16BYTE(bufferSender);
        //                bufferSender[bufferSender.Length - 2] = CRC16[0];
        //                bufferSender[bufferSender.Length - 1] = CRC16[1];
        //                return bufferSender;
        //            }
        //            else if (Device.DeviceGatewayRegistersBytes == 1) //4 байт (шлюз)
        //            {
        //                bufferSender = new byte[(int)RegisterCount * 4 + 5];
        //                bufferSender[0] = bufferReceiver[0];
        //                bufferSender[1] = bufferReceiver[1];
        //                bufferSender[2] = Decimal.ToByte((Decimal)((int)RegisterCount * 4));

        //                for (int index = 0; index < (int)RegisterCount; ++index)
        //                {
        //                    byte[] bytes = BitConverter.GetBytes(Device.GetUIntInputRegister_4(Convert.ToUInt16((int)RegisterStartAddress + index)));
        //                    bufferSender[index * 4 + 3] = bytes[3];
        //                    bufferSender[index * 4 + 4] = bytes[2];
        //                    bufferSender[index * 4 + 5] = bytes[1];
        //                    bufferSender[index * 4 + 6] = bytes[0];
        //                }

        //                CRC16 = CalucalteCRC16BYTE(bufferSender);
        //                bufferSender[bufferSender.Length - 2] = CRC16[0];
        //                bufferSender[bufferSender.Length - 1] = CRC16[1];
        //                return bufferSender;
        //            }
        //        }
        //        return byteError;

        //    //Функция 05
        //    case 5:
        //        if (bufferReceiver.Length < 7)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_05 = new byte[2];
        //        RegisterStartAddressArray_05[0] = bufferReceiver[2];
        //        RegisterStartAddressArray_05[1] = bufferReceiver[3];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_05);

        //        byte[] ValueArray_05 = new byte[2];
        //        ValueArray_05[0] = bufferReceiver[4];
        //        ValueArray_05[1] = bufferReceiver[5];
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
        //        if (bufferReceiver.Length < 7)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_06 = new byte[2];
        //        RegisterStartAddressArray_06[0] = bufferReceiver[2];
        //        RegisterStartAddressArray_06[1] = bufferReceiver[3];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_06);

        //        byte[] ValueArray_06 = new byte[2];
        //        ValueArray_06[0] = bufferReceiver[4];
        //        ValueArray_06[1] = bufferReceiver[5];
        //        Value = HEX_WORD.FromByteArray(ValueArray_06);

        //        Device.SetHoldingRegister(RegisterStartAddress, Value);

        //        //Ответ должен соотвествовать запросу
        //        return bufferReceiver;
        //    //Функция 15
        //    case 15:
        //        if (bufferReceiver.Length < 7)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_15 = new byte[2];
        //        RegisterStartAddressArray_15[0] = bufferReceiver[2];
        //        RegisterStartAddressArray_15[1] = bufferReceiver[3];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_15);

        //        byte[] RegisterCountArray_15 = new byte[2];
        //        RegisterCountArray_15[0] = bufferReceiver[4];
        //        RegisterCountArray_15[1] = bufferReceiver[5];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_15);

        //        CountArray = (ushort)bufferReceiver[6];

        //        byte[] ValueArray_15 = new byte[CountArray];
        //        Array.Copy(bufferReceiver, 7, ValueArray_15, 0, CountArray);

        //        bool[] BooleanValues = new bool[RegisterCount];
        //        BooleanValues = HEX_BOOLEAN.ToArray(ValueArray_15);

        //        for (int index = 0; index < (int)BooleanValues.Length; ++index)
        //        {
        //            Device.SetCoil(Convert.ToUInt16((int)RegisterStartAddress + index), BooleanValues[index]);
        //        }

        //        bufferSender = new byte[8];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = bufferReceiver[2];
        //        bufferSender[3] = bufferReceiver[3];
        //        bufferSender[4] = bufferReceiver[4];
        //        bufferSender[5] = bufferReceiver[5];
        //        CRC16 = CalucalteCRC16BYTE(bufferSender);
        //        bufferSender[bufferSender.Length - 2] = CRC16[0];
        //        bufferSender[bufferSender.Length - 1] = CRC16[1];

        //        return bufferSender;
        //    //Функция 16
        //    case 16:
        //        if (bufferReceiver.Length < 7)
        //        {
        //            goto ERROR;
        //        }

        //        byte[] RegisterStartAddressArray_16 = new byte[2];
        //        RegisterStartAddressArray_16[0] = bufferReceiver[2];
        //        RegisterStartAddressArray_16[1] = bufferReceiver[3];
        //        RegisterStartAddress = HEX_WORD.FromByteArray(RegisterStartAddressArray_16);

        //        byte[] RegisterCountArray_16 = new byte[2];
        //        RegisterCountArray_16[0] = bufferReceiver[4];
        //        RegisterCountArray_16[1] = bufferReceiver[5];
        //        RegisterCount = HEX_WORD.FromByteArray(RegisterCountArray_16);

        //        CountArray = (ushort)bufferReceiver[6];

        //        byte[] ValueArray_16 = new byte[CountArray];
        //        Array.Copy(bufferReceiver, 7, ValueArray_16, 0, CountArray);

        //        Values = new ushort[CountArray];
        //        Values = HEX_WORD.ToArray(ValueArray_16);

        //        for (int index = 0; index < (int)Values.Length; ++index)
        //        {
        //            Device.SetHoldingRegister(Convert.ToUInt16((int)RegisterStartAddress + index), Values[index]);
        //        }

        //        bufferSender = new byte[8];
        //        bufferSender[0] = bufferReceiver[0];
        //        bufferSender[1] = bufferReceiver[1];
        //        bufferSender[2] = bufferReceiver[2];
        //        bufferSender[3] = bufferReceiver[3];
        //        bufferSender[4] = bufferReceiver[4];
        //        bufferSender[5] = bufferReceiver[5];
        //        CRC16 = CalucalteCRC16BYTE(bufferSender);
        //        bufferSender[bufferSender.Length - 2] = CRC16[0];
        //        bufferSender[bufferSender.Length - 1] = CRC16[1];
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
        //        CRC16 = CalucalteCRC16BYTE(bufferSender_Error);
        //        bufferSender_Error[bufferSender_Error.Length - 2] = CRC16[0];
        //        bufferSender_Error[bufferSender_Error.Length - 1] = CRC16[1];
        //        return bufferSender_Error;
        //}
    }

    #endregion Формирование ответа по запроса Modbus RTU

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
        //Проверяем ответило ли то устройство, которое мы опрашиваем
        if (bufferSender[0] != bufferReceiver[0])
        {
            result = false;
            Message = result ? okMessage : errMessage;
            return result;
        }
        //Проверяем, что функция запроса соотвествовать ответу
        if (bufferSender[1] != bufferReceiver[1])
        {
            result = false;
            Message = result ? okMessage : errMessage;
            return result;
        }
        //Если функция записи 5, 6, то запрос должен соотвествовать ответу
        if (bufferSender[1] == 5 || bufferSender[1] == 6)
        {
            //Сравниваем массивы
            if(!bufferSender.SequenceEqual(bufferReceiver))
            {
                result = false;
                Message = result ? okMessage : errMessage;
                return result;
            }
        }
        //Если функция записи 15, 16, то в ответе только информация о том, что RegisterStartAddress и RegisterCount получены и приняты
        if (bufferSender[1] == 15 || bufferSender[1] == 16)
        {
            if ((bufferSender[2] != bufferReceiver[2]) || 
                (bufferSender[3] != bufferReceiver[3]) || 
                (bufferSender[4] != bufferReceiver[4]) || 
                (bufferSender[5] != bufferReceiver[5]))
            {
                result = false;
                Message = result ? okMessage : errMessage;
                return result;
            }
        }
        //Если на месте функции, адрес фунции больше 128, то там ошибка и нам нужно эту ошибку отправить
        if (bufferReceiver[1] > 128)
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
        //Проверка на CRC16
        if (bufferReceiver.Length < 7)
        {
            result = false;
            Message = "[BAD][Получено от устройства " + bufferReceiver.Length + " байт.]";
            return result;
        }
        else
        {
            //Сами посчитали CRC16 сумму отняв последние 2 байта     
            byte[] bufferReceiverNoCRC16 = new byte[bufferReceiver.Length];
            Array.Copy(bufferReceiver, 0, bufferReceiverNoCRC16, 0, bufferReceiver.Length - 2);
            byte[] CRC16 = CalucalteCRC16BYTE(bufferReceiverNoCRC16);
            //Взяли CRC16 из bufferReceiver
            byte[] bufferReceiverCRC16 = new byte[2];
            Array.Copy(bufferReceiver, bufferReceiver.Length - 2, bufferReceiverCRC16, 0, 2);

            if (CRC16.SequenceEqual(bufferReceiverCRC16))
            {
                result = true;
                Message = result ? okMessage : errMessage;
                return result;
            }
            else
            {
                result = false;
                Message = result ? okMessage : errMessage;
                return result;
            }
        }
    }

    #endregion Проверка на корректность данных

    #region Полученние массива данных

    public byte[] DecodeData(byte[] bufferReceiver)
    {
        byte[] NumArrayRegisters = null;

        NumArrayRegisters = new byte[(int)bufferReceiver[2]];
        Array.Copy((Array)bufferReceiver, 3, (Array)NumArrayRegisters, 0, (int)bufferReceiver[2]);
     
        return NumArrayRegisters;
    }

    #endregion Полученние массива данных
}

