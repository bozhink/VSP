#include "ising_model.h"
#include <iostream>
using namespace std;

int main(int argc, char**argv)
{
	int L = 100;
	double J = 0.6;
	IsingModel is(L, J);
	is.HotStart();
	is.MCMS();
	is.Energy();
	cout << "M = " << is.GetMagneticMoment() << " E = " << is.GetEnergy() << endl;
	return 0;
}
