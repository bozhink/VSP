using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ising_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            string fname="data-512-B01.txt";
            int dimension = 512;
            double initialJ = -1.0;
            double finalJ = 1.0;
            double stepJ = 0.01;

            int numberOfStepsForJ = (int)((finalJ - initialJ) / stepJ) + 1;
            
            Int64 clock1, clock2;

            int i;
            double J = initialJ;
            double B = 0.01;

            if (args.Length < 3)
            {
                Console.WriteLine("Usage: <program> <output-file-name> <matrix-size> <magnetic-field>");
                return;
            }
            else
            {
                fname = args[0];
                dimension = int.Parse(args[1]);
                B = double.Parse(args[2]);
            }
            

            StreamWriter writer = new StreamWriter(fname,false);

            for (i = 0; i < numberOfStepsForJ; i++)
            {
                IsingClass ising = new IsingClass(dimension, dimension, J, B);
                clock1 = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000
                    + DateTime.Now.Millisecond;

                Thermodynamics.CalculateProperties(ising, 100, ising.iDimx * ising.iDimy);

                clock2 = (DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second) * 1000
                    + DateTime.Now.Millisecond;

                writer.WriteLine("{0:f4}\t{1:f4}\t{2:f4}\t{3:f4}\t{4:f4}\t{5:f4}", B, J,
                    Thermodynamics.meanMagneticMoment, Thermodynamics.magneticSusceptibility,
                    Thermodynamics.meanEnergy, Thermodynamics.heatCapacitance);
                Console.WriteLine("{0}: {1}",J,clock2 - clock1);

                J += stepJ;
            }

            writer.Close();
        }
    }
}
