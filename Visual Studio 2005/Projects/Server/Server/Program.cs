using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipend = new IPEndPoint(IPAddress.Any, 8080);
            server.Bind(ipend);
            server.Listen(1);
            while (true)
            {
                NetworkStream stream=new NetworkStream(server.Accept(), true);
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);
                String str;
                str = reader.ReadLine();
                Console.WriteLine(str);
                if (str == "stop")
                {
                    writer.WriteLine("stopped");
                    Console.WriteLine("Stop accepted...");
                    writer.Flush();
                    break;
                }
                else
                {
                    writer.WriteLine("pong");
                    writer.Flush();
                }
            }
        }
    }
}
