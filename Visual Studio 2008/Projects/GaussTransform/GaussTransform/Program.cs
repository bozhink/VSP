using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rational;

namespace GaussTransform
{
    class Program
    {
            const int N = 20; 

        static void Main(string[] args)
        {
            Rational.Rational[] a = new Rational.Rational  [N];
            System.Random rnd = new Random();
            ulong[] gcode = new ulong[N];
            for (int j = 0; j < N; j++)
            {
                a[j] = new Rational.Rational((ulong)rnd.Next(10));
                System.Console.Write(a[j].Numerator);
                System.Console.Write(" ");
            }

            System.Console.WriteLine();
            
            Rational.Rational s = Rational.Gauss.GaussCode(a);
            Rational.Rational x = new Rational.Rational(s);

            //System.Console.Write(s.Numerator); System.Console.Write(" ");
            //System.Console.WriteLine(s.Denominator);

            //for (int i = 0; i < n - 2; i++)
            //{
            //    s = rational.gauss.phi(s);
            //    system.console.write(s.numerator); system.console.write(" ");
            //    system.console.writeline(s.denominator);
            //}

            System.Console.WriteLine("Decoding...");

            Rational.Gauss.GaussDecode(x, N, out gcode);

            for (int j = 0; j < N; j++)
            {
                System.Console.Write(gcode[j]);
                System.Console.Write(" ");
            }
            System.Console.WriteLine();
            Rational.Rational new0 = new Rational.Rational(9657, 86765);
            Rational.Rational new1 = new Rational.Rational(189862, 37654764);
            System.Console.WriteLine((Rational.Rational.sum(new0, new1)).Numerator);
            System.Console.WriteLine((Rational.Rational.sum(new0, new1)).Denominator);

            ulong [] g=new ulong[N];
            Rational.Gauss.GaussDecode(new Rational.Rational(2),N,out g);


            System.Console.ReadKey();
        }
    }
}
