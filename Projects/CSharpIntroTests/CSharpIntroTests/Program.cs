using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Diagnostics;

namespace CSharpIntroTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nullable Types
            Nullable<int> i1 = null;
            int? i2 = null;
            int i = 5;
            int? ni = i;
            Console.WriteLine(i);
            Console.WriteLine(ni);
            Console.WriteLine(i1);
            Console.WriteLine(i2);
            i = ni.Value;
            Console.WriteLine(i);
            ni = null;
            Console.WriteLine(ni.HasValue);
            i = ni.GetValueOrDefault();
            Console.WriteLine(i);
            object container1 = "Hello World\n";
            Console.WriteLine(container1);
            container1 = 3;
            Console.WriteLine(container1);
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine(1 + " " + 0xA);
            char ch = '\u0000';
            Console.WriteLine(ch++);
            Console.WriteLine(ch++);
            Console.WriteLine(DateTime.Now);
            int? aa = 5;
            Console.WriteLine(aa ?? -1); // 5
            string name = null;
            Console.WriteLine(name ?? "(no name)"); // (no name)
            {
                int a = 6;
                int b = 3;
                Console.WriteLine(a + b / 2); // 7 
                Console.WriteLine((a + b) / 2); // 4 
            }
            string s = "Beer";
            Console.WriteLine(s is string); // True 
            string notNullString = s;
            string nullString = null;
            Console.WriteLine(nullString ?? "Unspecified"); // Unspecified 
            Console.WriteLine(notNullString ?? "Specified"); // Beer
            Console.WriteLine("{0,6}{1,6}{2,-6}", 123, 345, 765);
            Console.WriteLine("{0,6:c2}", 124.456767);
            Console.WriteLine("{0:G}", DayOfWeek.Wednesday);
            Console.WriteLine("{0:D}", DayOfWeek.Wednesday);
            Console.WriteLine("{0:X}", DayOfWeek.Wednesday);
            
            DateTime d = new DateTime(2011, 9, 2, 17, 34, 22);

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine("{0:N}", 1234.56);
            Console.WriteLine("{0:D}", d);

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
            Console.WriteLine("{0:N}", 1234.56);
            Console.WriteLine("{0:D}", d);

            int aaaaaaaa = 54345;
            String A = aaaaaaaa.ToString();
            Console.WriteLine(A[A.Length - 1]);

           /*
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Character entered: " + key.KeyChar);
            Console.WriteLine("Special keys: " + key.Modifiers);


            double d1 = DateTime.Now.Hour * 3600.0 + DateTime.Now.Minute * 60.0 +
                DateTime.Now.Second + DateTime.Now.Millisecond / 1000.0;
            Console.WriteLine(d1);
            //Process ps = Process.Start("mspaint.exe");
            //ps.WaitForExit();
            double d2 = DateTime.Now.Hour * 3600.0 + DateTime.Now.Minute * 60.0 +
                DateTime.Now.Second + DateTime.Now.Millisecond / 1000.0;
            Console.WriteLine(d2);
            Console.WriteLine(long.MaxValue);
            */
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}
