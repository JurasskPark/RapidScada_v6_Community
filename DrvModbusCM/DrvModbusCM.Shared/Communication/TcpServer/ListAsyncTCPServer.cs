using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationMethods
{
    public class ListAsyncTCPServer
    {
        public static List<AsyncTCPServer> AsyncTCPServers { get; set; }
        public ListAsyncTCPServer()
        {
            AsyncTCPServers = new List<AsyncTCPServer>();
        }
    }
}
