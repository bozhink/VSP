using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BooNetClient;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BooNetClient.BNClient client = new BooNetClient.BNClient();
            string command;
            try
            {
                command = args[0];
            }
            catch (Exception err)
            {
                command = "ping!";
                Console.WriteLine(">>>>" + err.Message);
            }
            try
            {
                client.Run("127.0.0.1", command);
            }
            catch (Exception err)
            {
                Console.WriteLine("Cannot connect");
                Console.WriteLine(">>>>" + err.Message);
            }
        }
    }
}
