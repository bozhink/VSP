using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;

namespace DllTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MathComp obj = new MathComp();
            long lRes = obj.Add(10, 20);
            obj.Extra = true;
            Console.WriteLine(lRes);
            return;
        }
    }
}
