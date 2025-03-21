﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProtocolModbus.INException
{
    public class IllegalDataAddressException : Exception
    {
        public IllegalDataAddressException()
            : base(IMessage.ILLEGAL_DATA_ADDRESS) { }

        public IllegalDataAddressException(string message)
            : base(message) { }

        public IllegalDataAddressException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public IllegalDataAddressException(string message, Exception innerException)
            : base(message, innerException) { }

        public IllegalDataAddressException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected IllegalDataAddressException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
