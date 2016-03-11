using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace httpget
{
    public class http
    {
        public static int Run(string ipaddr, int port, string query)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipend = new IPEndPoint(IPAddress.Parse(ipaddr), port);
            NetworkStream stream = new NetworkStream(s);
            StreamReader streamr = new StreamReader(stream);
            StreamWriter streamw = new StreamWriter(stream);
            try
            {
                s.Connect(ipend);
            }
            catch (Exception error)
            {
                return -1;
            }

            try
            {
                s.Close();
            }
            catch (Exception error)
            {
                return -2;
            }
            return 0;
        }
    }
}
