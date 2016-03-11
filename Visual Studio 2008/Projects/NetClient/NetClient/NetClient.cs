using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace NetClient
{
    public class NetClient
    {
        public static String RunClient()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            NetworkStream stream = new NetworkStream(s, true);
            StreamWriter StreamWr = new StreamWriter(stream);
            StreamReader StreamRd = new StreamReader(stream);
            String ret;

            try
            {
                s.Connect(ipEndPoint);
                StreamWr.WriteLine("Hello. I`m a client.");
                StreamWr.Flush();

                ret = StreamRd.ReadLine();

                s.Close();
            }
            catch (Exception error)
            {
                ret = error.Message;
            }
            return ret;
        }
    }
}
