using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TimeCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: TimeCounter <program> <program options> ...");
                return;
            }

            for (int i = 0; i < args.Length; i++)
            {
                command += args[i] + " ";
            }

            Console.WriteLine("Command to be executed: " + command);

            DateTime dt1 = DateTime.Now;
            double d1 = dt1.Hour * 3600.0 + dt1.Minute * 60.0 +
                dt1.Second + dt1.Millisecond * 0.001;
            Console.WriteLine("Start time " + dt1);
            Process proc = Process.Start(command);
            proc.WaitForExit();
            DateTime dt2 = DateTime.Now;
            double d2 = dt2.Hour * 3600.0 + dt2.Minute * 60.0 +
                dt2.Second + dt2.Millisecond * 0.001;
            Console.WriteLine("End time " + dt1);
            Console.WriteLine("Elapsed time {0} seconds.", d2 - d1);
        }
    }
}
