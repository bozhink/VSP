using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LineCount
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Ussage: LineCount <file-name>");
                return;
            }
            else
            {
                StreamReader reader = new StreamReader(args[0]);
                int lineNumber = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    lineNumber++;
                    // Console.WriteLine("Line #{0}: {1}", lineNumber, line);
                    line = reader.ReadLine();
                }
                Console.WriteLine("{0}", lineNumber);
            }
        }
    }
}
