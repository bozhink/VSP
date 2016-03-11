using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bell
{
    class Program
    {
        string[] wait = { "\\", "|", "/", "-" };

        public void Show()
        {
            for (; ; )
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("\rHello, World!......");
                    Console.Write(wait[i]);
                    Thread.Sleep(1000);
                }
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Thread th = new Thread(new ThreadStart(p.Show));
            th.Name = "Show Method";
            th.Start();
            //th.Abort();
        }
    }
}
