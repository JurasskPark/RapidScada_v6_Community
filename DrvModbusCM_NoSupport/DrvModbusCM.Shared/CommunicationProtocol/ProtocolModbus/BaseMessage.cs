using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtocolModbus
{
    public abstract class ModbusMessage
    {
        protected const byte FUNCTION_01 = 1;

        protected const byte FUNCTION_02 = 2;

        protected const byte FUNCTION_03 = 3;

        protected const byte FUNCTION_04 = 4;

        protected const byte FUNCTION_05 = 5;

        protected const byte FUNCTION_06 = 6;

        protected const byte FUNCTION_15 = 15;

        protected const byte FUNCTION_16 = 16;

        public static Dictionary<int, string> GetCommands()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            result.Add(1, "Read Coil Status");
            result.Add(2, "Read Input Status");
            result.Add(3, "Read Holding Register");
            result.Add(4, "Read Input Register");
            result.Add(5, "Write Single Coil");
            result.Add(6, "Write Single Register");
            result.Add(15, "Write Multiple Coils");
            result.Add(16, "Write Multiple Registers");
            return result;
        }
    
    }
}
