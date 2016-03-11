////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading;
////using System.Threading.Tasks;

////namespace SuareRootsAsync
////{
////    class Program
////    {
////        static Dictionary<int, double> GetSuareRoots(List<int> numbers)
////        {
////            Dictionary<int, double> qrTabes = new Dictionary<int, double>();
////            foreach (int number in numbers)
////            {
////                Thread.Sleep(500);
////                qrTabes[number] = Math.Sqrt(number);
////            }

////            return qrTabes;
////        }

////        static Task<Dictionary<int, double>> GetSuareRootsAsync(List<int> numbers)
////        {
////            Task<Dictionary<int, double>>  sq = Task.Run(() => GetSuareRoots(numbers));

////            return sq;
////        }

////        static void PrintSquareRootsAsync(List<int> numbers)
////        {
////            GetSuareRootsAsync(numbers).ContinueWith(
////                (resultTask) =>
////                {
////                    if (resultTask.IsFaulted) // error status
////                    {
////                        Console.WriteLine(resultTask.Exception);
////                    }

////                    foreach (var item in resultTask.Result)
////                    {
////                        Console.WriteLine(item.Key + " " + item.Value);
////                    }
////                }
////                );
////        }

////        static void Main(string[] args)
////        {
////            //Task.Run();

////            PrintSquareRootsAsync(Enumerable.Range(0, 10000).ToList());

////            Console.WriteLine("done");


////                Console.ReadLine();
////        }
////    }
////}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuareRootsAsync
{
    class Program
    {
        static Dictionary<int, double> GetSuareRoots(List<int> numbers)
        {
            Dictionary<int, double> qrTabes = new Dictionary<int, double>();
            foreach (int number in numbers)
            {
                Thread.Sleep(10);
                qrTabes[number] = Math.Sqrt(number);
            }

            return qrTabes;
        }

        static Task<Dictionary<int, double>> GetSuareRootsAsync(List<int> numbers)
        {
            Task<Dictionary<int, double>> sq = Task.Run(() => GetSuareRoots(numbers));

            return sq;
        }

        static async void PrintSquareRootsAsync(List<int> numbers)
        {
            try
            {
                Dictionary<int, double> table = await GetSuareRootsAsync(numbers);

                foreach (var entry in table)
                {
                    Console.WriteLine(entry.Key + " " + entry.Value);
                }
            }
            catch (Exception)
            {
                // This works.
            }
        }

        static void Main(string[] args)
        {
            //Task.Run();

            PrintSquareRootsAsync(Enumerable.Range(0, 10).ToList());

            Console.WriteLine("done");


            Console.ReadLine();
        }
    }
}
