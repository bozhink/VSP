using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ising_Model
{
    class IsingClass
    {
        private int idimx, idimy;
        public readonly int iDimx, iDimy;
        private int[] spinMatrix;
        private double J; // exchange integral
        private double B=0.0; //external magnetic field

        public double magneticMoment=0.0;
        public double magneticEnergy=0.0;

        // R-Matrix:
        // R(Spin,NeighbourSum):
        //   Spin = -1, +1
        //   NeighbourSum (NS) = -4, -2, 0, 2, 4
        // To use a normal array we redefine indices as follow:
        // +------------+------+------+
        // |     Spin   |  -1  |  +1  |
        // +------------+------+------+
        // | (Spin+1)/2 |   0  |   1  |
        // +------------+------+------+
        //
        // +----------+------+------+------+------+------+
        // |       NS |  -4  |  -2  |   0  |  +2  |  +4  |
        // +----------+------+------+------+------+------+
        // | (NS+4)/2 |   0  |   1  |   2  |   3  |   4  |
        // +----------+------+------+------+------+------+
        //
        // R(Spin,NS) = exp ( -2*Spin* ( B + J*NS ) )
        // R[i,j]     = exp ( -2*(2*i-1)*(B+J*(2*j-4)) ),
        // i = 0, 1; j = 0, 1, 2, 3, 4
        private double[,] rMatrix = new double[2, 5];

        private int seed;
        private System.Random rand;

        // Initialization
        public IsingClass(int dimx, int dimy, double _J, double _B)
        {
            this.idimx = dimx;
            this.idimy = dimy;
            this.iDimx = this.idimx;
            this.iDimy = this.idimy;
            this.J = _J;
            this.B = _B;
            int i, j;
            for (i = 0; i < 2; i++) for (j = 0; j < 4; j++)
            {
                rMatrix[i, j] = Math.Exp(-2 * (2 * i - 1) * (B + J * (2 * j - 4)));
            }
            this.spinMatrix = new int[idimx*idimy];
            this.seed = DateTime.Now.Hour*3601 + DateTime.Now.Minute*60 +DateTime.Now.Second;
            this.rand = new Random(seed);
        }

        // Generation of new initial state.
        // In this program is used hot start: uniform distribution of
        // probability of -1 and +1
        public void StateGen()
        {
            for (int i = 0; i < idimx*idimy; i++) spinMatrix[i] = 2*(rand.Next() % 2) - 1;
        }

        // Monte Carlo Micro Step with toroidal topology
        private int NeighbourSum(int i, int j)
        {
            int ni = idimx + i, nj = idimy + j;
            return spinMatrix[((ni + 1) % idimx)*idimx + j] +
                 spinMatrix[((ni - 1) % idimx)*idimx + j] +
                 spinMatrix[i*idimx + ((nj + 1) % idimy)] +
                 spinMatrix[i*idimx + ((nj - 1) % idimy)];
        }


        public void MCMSTT()
        {
            int i, j, NS; // NS = Neighbour Sum
            i = rand.Next() % idimx;
            j = rand.Next() % idimy;
            NS = NeighbourSum(i, j);
            if (rand.NextDouble() < rMatrix[(spinMatrix[i*idimx + j] + 1) / 2, (NS + 4) / 2])
                spinMatrix[i*idimx + j] = -spinMatrix[i*idimx + j];
        }

        // Monte Carlo Macro Step
        public void MCMS(int numSteps) // numSteps = number of micro steps to do
        {
            for (int i = 0; i < numSteps; i++) MCMSTT();
        }

        // Magnetic Moment calculation
        public double MagneticMoment()
        {
            magneticMoment = 0.0;
            for (int i = 0; i < idimx*idimy; i++) magneticMoment += spinMatrix[i];
            return magneticMoment;
        }

        // Calculation of Hamiltonian in case of Toroidal Topology
        public double HamiltonianTT()
        {
            int i, j;
            int im = 0, ns = 0;
            for (i = 0; i < idimx; i++) for (j = 0; j < idimy; j++)
            {
                im += spinMatrix[i*idimx + j];
                ns += spinMatrix[i*idimx + j] * NeighbourSum(i, j);
            }
            magneticMoment = im;
            magneticEnergy = -J * ns + B * im;
            return magneticEnergy;
        }
    }
}
