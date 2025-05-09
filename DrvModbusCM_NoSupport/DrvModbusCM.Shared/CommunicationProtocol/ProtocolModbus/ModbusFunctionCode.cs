﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolModbus
{
    public static class ModbusFunctionCode
    {
        /// <summary>
        /// Считать флаги
        /// </summary>
        public const byte ReadCoils = 0x01;

        /// <summary>
        /// Считать дискретные входы
        /// </summary>
        public const byte ReadDiscreteInputs = 0x02;

        /// <summary>
        /// Считать регистры хранения
        /// </summary>
        public const byte ReadHoldingRegisters = 0x03;

        /// <summary>
        /// Считать входные регистры
        /// </summary>
        public const byte ReadInputRegisters = 0x04;

        /// <summary>
        /// Записать флаг
        /// </summary>
        public const byte WriteSingleCoil = 0x05;

        /// <summary>
        /// Записать регистр хранения
        /// </summary>
        public const byte WriteSingleRegister = 0x06;

        /// <summary>
        /// Записать множество флагов
        /// </summary>
        public const byte WriteMultipleCoils = 0x0F;

        /// <summary>
        /// Записать множество регистров хранения
        /// </summary>
        public const byte WriteMultipleRegisters = 0x10;
    }
}
