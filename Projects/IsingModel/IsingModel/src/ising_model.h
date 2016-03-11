// file ising_model.h

#ifndef ISING_MODEL
#define ISING_MODEL

#include <stdlib.h>
#include <math.h>
#include <time.h>

#include <iostream>
using namespace std;

class IsingModel {
private:
	int Lx, Ly; // lattice sizes
	int Lxp1, Lxm1, Lyp1, Lym1; // additional sizes
	int **spin_matrix; // array containig lattice
	double J, B; // exchange integral and external magnetic field
	double magnetic_moment, energy;
    /* 
	 * R-Matrix:
     * R(Spin,NeighbourSum):
     *   Spin = -1, +1
     *   NeighbourSum (NS) = -4, -2, 0, 2, 4
     * To use a normal array we redefine indices as follow:
     * +------------+------+------+
     * |     Spin   |  -1  |  +1  |
     * +------------+------+------+
     * | (Spin+1)/2 |   0  |   1  |
     * +------------+------+------+
     *
     * +----------+------+------+------+------+------+
     * |       NS |  -4  |  -2  |   0  |  +2  |  +4  |
     * +----------+------+------+------+------+------+
     * | (NS+4)/2 |   0  |   1  |   2  |   3  |   4  |
     * +----------+------+------+------+------+------+
     *
     * R(Spin,NS) = exp ( -2*Spin* ( B + J*NS ) )
     * R[i,j]     = exp ( -2*(2*i-1)*(B+J*(2*j-4)) ),
     * i = 0, 1; j = 0, 1, 2, 3, 4
	 */
	double r[2][5];
	
	// Private methods:
	void construct(int, int, double, double); // Common form of the constructors
	int neighbour_sum(int, int);
	void MCS(); // Monte Carlo Micro Step

public:
	IsingModel(int, double);
	IsingModel(int, double, double);
	IsingModel(int, int, double);
	IsingModel(int, int, double, double);
	~IsingModel();

	void ColdStart();
	void HotStart();

	void MCMS(int); // Monte Carlo Macro Step
	void MCMS();    // Monte Carlo Macro Step

	double MagneticMoment();
	double Energy();
	double GetMagneticMoment();
	double GetEnergy();

};



#endif // ISING_MODEL