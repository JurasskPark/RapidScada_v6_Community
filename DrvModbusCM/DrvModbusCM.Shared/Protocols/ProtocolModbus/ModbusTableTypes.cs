namespace ProtocolModbus
{
    public enum ModbusTableTypes
    {
        /// <summary>
        /// Флаги (1 бит, чтение и запись, 1X-обращения)
        /// </summary>
        Coils,

        /// <summary>
        /// Дискретные входы (1 бит, только чтение, 2X-обращения)
        /// </summary>
        DiscreteInputs,

        /// <summary>
        /// Регистры хранения (16 бит, чтение и запись, 3X-обращения)
        /// </summary>
        HoldingRegisters,

        /// <summary>
        /// Входные регистры (16 бит, только чтение, 4X-обращения)
        /// </summary>
        InputRegisters
    }
}
