﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProtocolModbus.INException
{
    public class IllegalIPAddressException : Exception
    {
        public IllegalIPAddressException()
            : base() { }

        public IllegalIPAddressException(string message)
            : base(message) { }

        public IllegalIPAddressException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public IllegalIPAddressException(string message, Exception innerException)
            : base(message, innerException) { }

        public IllegalIPAddressException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected IllegalIPAddressException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
