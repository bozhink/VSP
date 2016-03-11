using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace funcdll
{
    public class Funcs
    {
        public double ThCuttingValue = 0.01;
        public int runTestNumber = 1000000;
        public double Add2(double a, double b)
        {
            return a + b;
        }
        public double Add(double a, double b)
        {
            double c;
            for (int i = 0; i < runTestNumber; i++)
            {
                c = Add2(a, b);
            }
            return Add2(a, b);
        }


        public double Th(double x)
        {
            if (Math.Abs(x) < ThCuttingValue)
            {
                return 1.0 + x * x * (0.4 * x * x - 1.0);
            }
            else
            {
                return Math.Tanh(x) / x;
            }
        }
    }
}
