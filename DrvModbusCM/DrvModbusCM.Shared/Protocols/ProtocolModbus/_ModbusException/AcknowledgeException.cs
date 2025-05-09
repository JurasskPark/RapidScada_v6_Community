﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProtocolModbus.INException
{
    public class AcknowledgeException : Exception
    {
        public AcknowledgeException()
            : base(IMessage.ILLEGAL_DATA_ADDRESS) { }

        public AcknowledgeException(string message)
            : base(message) { }

        public AcknowledgeException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public AcknowledgeException(string message, Exception innerException)
            : base(message, innerException) { }

        public AcknowledgeException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected AcknowledgeException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
