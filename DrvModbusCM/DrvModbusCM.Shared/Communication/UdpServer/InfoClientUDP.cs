using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


    public class InfoClientUDP
    {
        public EndPoint EndPoint;
        public Socket Socket;

        public Guid id;
        public string ip;
        public int port;

        public InfoClientUDP()
        {
 
        }

        public InfoClientUDP(Guid id, string ip, int port)
        {
            this.id = id;
            this.ip = ip;
            this.port = port;
        }
    }

