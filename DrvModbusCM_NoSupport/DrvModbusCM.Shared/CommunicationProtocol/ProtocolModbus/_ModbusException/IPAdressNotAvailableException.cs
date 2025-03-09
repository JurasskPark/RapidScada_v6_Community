using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProtocolModbus.INException
{
    public class IPAdressNotAvailableException : Exception
    {
        public IPAdressNotAvailableException()
            : base("Error code 03: IP address is not in the network") { }

        public IPAdressNotAvailableException(string message)
            : base(string.Format("Error code 03: {0}", message)) { }

        public IPAdressNotAvailableException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public IPAdressNotAvailableException(string message, Exception innerException)
            : base(message, innerException) { }

        public IPAdressNotAvailableException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected IPAdressNotAvailableException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
