using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ListAsyncUDPServer
    {
        public static List<AsyncUDPServer> AsyncUDPServers { get; set; }
        public ListAsyncUDPServer()
        {
            AsyncUDPServers = new List<AsyncUDPServer>();
        }
    }

