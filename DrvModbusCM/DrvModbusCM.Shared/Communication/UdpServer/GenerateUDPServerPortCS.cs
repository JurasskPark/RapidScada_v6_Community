using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;


    public static class GENERATE_UDP_SERVER_PORT
    {
		public static int PORT_NEW()
        {
			int port = 60000;
			for (int i = port; i < 65535 || CheckAvailableServerPort(i) == true; i++)
			{
				if (CheckAvailableServerPort(i) == true)
                {
					return i;
				}			
			}
			return port;
		}

		public static bool CheckAvailableServerPort(int port)
		{
			//LOG.InfoFormat("Checking Port {0}", port);
			bool isAvailable = true;

			// Evaluate current system tcp connections. This is the same information provided
			// by the netstat command line application, just in .Net strongly-typed object
			// form.  We will look through the list, and if our port we would like to use
			// in our TcpClient is occupied, we will set isAvailable to false.
			IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
			IPEndPoint[] udpConnInfoArray = ipGlobalProperties.GetActiveUdpListeners();

			foreach (IPEndPoint endpoint in udpConnInfoArray)
			{
				if (endpoint.Port == port)
				{
					isAvailable = false;
					break;
				}
			}
			return isAvailable;
		}
	}

