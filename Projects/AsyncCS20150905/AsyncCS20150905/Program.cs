using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCS20150905
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Parallel.For(0, 100, (index, loopState) =>
            ////{
            ////    //if (index > loopState.LowestBreakIteration)
            ////    //{
            ////    //    return;
            ////    //}

            ////    if (index == 10)
            ////    {
            ////        loopState.Break();
            ////    }
            ////    //loopState.Stop();
            ////    Console.WriteLine(index);
            ////});


            //Dictionary<string, string> s = new Dictionary<string, string>();
            ConcurrentBag<string> cb = new ConcurrentBag<string>();
            cb.Add("xx");

            /*
             * Deadlock
             */
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                lock ("first")
                {
                    Console.WriteLine("A");
                    lock ("second")
                    {
                        Console.WriteLine("B");
                    }
                }
                Console.WriteLine("Exit 1");
            });

            Task.Run(() =>
            {
                Thread.Sleep(1000);
                lock ("second")
                {
                    Console.WriteLine("b");
                    lock ("first")
                    {
                        Console.WriteLine("a");
                    }
                }
                Console.WriteLine("Exit 2");
            });

            while(true)
            {

            }
        }
    }
}
