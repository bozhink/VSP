using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipend = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
                NetworkStream stream = new NetworkStream(s, true);
                StreamWriter writer = new StreamWriter(stream);
                StreamReader reader = new StreamReader(stream);
                s.Connect(ipend);

                writer.WriteLine("1");
                writer.Flush();
                
                Console.WriteLine(reader.ReadLine());
                s.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return;
        }
    }
}
