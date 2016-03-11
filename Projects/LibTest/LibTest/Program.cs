using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace LibTest
{
    class LibImport
    {
        private const String DllFile = "E:\\projects\\lazarus\\dll\\lib.dll";
        [DllImport(DllFile, CharSet=CharSet.Auto)]
        public static extern void Hi();
        [DllImport(DllFile)]
        public static extern double F(double x);
        [DllImport("Example.dll")]
        public static extern double AddNumbers(double a, double b);
        [DllImport("Random.dll")]
        public static extern double Rand();
       // [DllImport("filedb.dll")]
       // public static extern void Init(string fp);
        [DllImport("libmyfun.dll")]
        public static extern double myfun_(double x);
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            LibImport.Hi();
            Console.WriteLine(LibImport.F(2.56d));
            Console.WriteLine(LibImport.AddNumbers(2.56d, 3.14d));
            Console.WriteLine(LibImport.Rand());
            //LibImport.Init("E:\\x.dat");
            Console.ReadKey();

            double x = 10.0;
            Console.WriteLine(LibImport.myfun_(x));

            Console.ReadKey();
        }
    }
}
