using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ising_Model
{
    static class Thermodynamics
    {
        public static double meanMagneticMoment = 0.0;
        public static double meanEnergy = 0.0;
        public static double magneticSusceptibility = 0.0;
        public static double heatCapacitance = 0.0;

        // Calculation of magnetic properties
        // numSamples = number of samples to be taken
        // mcSteps = Monte Carlo Micro Steps
        public static void CalculateMagneticProperties(IsingClass ising, int numSamples, int mcSteps) 
        {
            ising.StateGen();
            int i;
            double n2 = 1.0 / (ising.iDimx * ising.iDimy);
            double magneticMoment=0.0, magneticMoment2=0.0;
            for (i = 0; i < numSamples; i++)
            {
                ising.MCMS(mcSteps);
                magneticMoment += ising.MagneticMoment();
                magneticMoment2 += ising.magneticMoment * ising.magneticMoment;
            }
            magneticMoment *= n2;
            magneticMoment2 *= n2 * n2;
            meanMagneticMoment = magneticMoment / numSamples;
            magneticSusceptibility = magneticMoment2/numSamples - meanMagneticMoment*meanMagneticMoment;
        }

        // Calculation of magnetic and energetic properties
        // numSamples = number of samples to be taken
        // mcSteps = Monte Carlo Micro Steps
        public static void CalculateProperties(IsingClass ising, int numSamples, int mcSteps)
        {
            ising.StateGen();
            int i;
            double n2 = 1.0 / (ising.iDimx * ising.iDimy);
            double magneticMoment = 0.0, magneticMoment2 = 0.0;
            double magneticEnergy = 0.0, magneticEnergy2 = 0.0;

            for (i = 0; i < numSamples; i++)
            {
                ising.MCMS(mcSteps);
                ising.HamiltonianTT();
                magneticMoment += ising.magneticMoment;
                magneticMoment2 += ising.magneticMoment * ising.magneticMoment;
                magneticEnergy += ising.magneticEnergy;
                magneticEnergy2 += ising.magneticEnergy * ising.magneticEnergy;
            }
            magneticMoment *= n2;
            magneticMoment2 *= n2 * n2;
            magneticEnergy *= n2;
            magneticEnergy2 *= n2 * n2;
            meanMagneticMoment = magneticMoment / numSamples;
            magneticSusceptibility = magneticMoment2 / numSamples - meanMagneticMoment * meanMagneticMoment;
            meanEnergy = magneticEnergy / numSamples;
            heatCapacitance = magneticEnergy2 / numSamples - meanEnergy * meanEnergy;
        }
    }
}
