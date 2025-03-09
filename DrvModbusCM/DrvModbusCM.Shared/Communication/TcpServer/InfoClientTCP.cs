using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommunicationMethods
{
    internal class InfoClientTCP
    {
        public Guid id;
        public string ip;
        public int port;

        public InfoClientTCP(Guid id, string ip, int port)
        {
            this.id = id;
            this.ip = ip;
            this.port = port;
        }
    }
}