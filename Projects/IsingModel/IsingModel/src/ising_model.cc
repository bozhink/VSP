#include "ising_model.h"

#ifdef ISING_MODEL

/*
 * Constructors and destructor
 */

void IsingModel::construct(int lx, int ly, double j, double b)
{
	srand((int)time(NULL));
	if (lx < 1 || ly < 1)
	{
		cerr << "IsingModel: ERROR: Invalid lattice size!\n";
		exit(1);
	}
	Lx = lx;
	Ly = ly;
	Lxp1 = Lx+1;
	Lxm1 = Lx-1;
	Lyp1 = Ly+1;
	Lym1 = Ly-1;
	J  = j;
	B  = b;
	magnetic_moment=0.0;
	energy = 0.0;
	// Initialization of the spin matrix
	spin_matrix = new int*[Lx];
	for (int i=0; i<Lx; i++) spin_matrix[i] = new int[Ly];
	for (int i=0; i<Lx; i++) for (int j=0; j<Ly; j++)
	{
		spin_matrix[i][j] = 0;
	}
	// Initialization of the r-matrix
	for (int i=0; i<2; i++) for (int j=0; j<5; j++)
	{
		r[i][j] = exp(-2.0 * (2 * i - 1) * (B + J * (2 * j - 4)));
	}
	cerr << "Created Ising model with sizes " << Lx << " by " << Ly << endl;
}

IsingModel::IsingModel(int L, double J) {
	construct(L, L, J, 0.0);
}

IsingModel::IsingModel(int L, double J, double B) {
	construct(L, L, J, B);
}

IsingModel::IsingModel(int Lx, int Ly, double J) {
	construct(Lx, Ly, J, 0.0);
}

IsingModel::IsingModel(int Lx, int Ly, double J, double B) {
	construct(Lx, Ly, J, B);
}

IsingModel::~IsingModel() {
	for (int i=0; i<Lx; i++)
		delete [] spin_matrix[i];
	delete [] spin_matrix;
	cerr << "Destroyed Ising model with sizes " << Lx << " by " << Ly << endl;
}

/*
 * State initialization functions
 */

void IsingModel::ColdStart() {
	for (int i=0; i<Lx; i++)
		for (int j=0; j<Ly; j++)
			spin_matrix[i][j] = 0;
}

void IsingModel::HotStart() {
	for (int i=0; i<Lx; i++)
		for (int j=0; j<Ly; j++)
			spin_matrix[i][j] = rand() % 2;
}

/*
 * Some private functions
 */
int IsingModel::neighbour_sum(int x, int y) {
	x %= Lx;
	y %= Ly;
	return spin_matrix[(x+Lxp1)%Lx][y] +
		   spin_matrix[(x+Lxm1)%Lx][y] +
		   spin_matrix[x][(y+Lyp1)%Ly] +
		   spin_matrix[x][(y+Lym1)%Ly];
}

void IsingModel::MCS() {
	int x = rand() % Lx;
	int y = rand() % Ly;
	int ns = neighbour_sum(x, y);
	if ( ((1.0*rand())/RAND_MAX) < r[spin_matrix[x][y]][ns])
	{
		spin_matrix[x][y] = (spin_matrix[x][y]+1) % 2; // flipping spin
	}
}

/*
 * Monte Carlo Macro Step
 */
void IsingModel::MCMS(int number_of_steps) {
	for (int i=0; i<number_of_steps; i++)
		MCS();
}

void IsingModel::MCMS() {
	MCMS(Lx*Ly);
}

/*
 * Exporting results
 */
double IsingModel::MagneticMoment() {
	magnetic_moment=0.0;
	for (int i=0; i<Lx; i++) for (int j=0; j<Ly; j++) {
		magnetic_moment += 1.0*(2*spin_matrix[i][j]-1);
	}
	return magnetic_moment;
}

double IsingModel::Energy() {
	int s, ns;
	magnetic_moment = 0.0;
	energy = 0.0;
	for (int i=0; i<Lx; i++) for (int j=0; j<Ly; j++) {
		s = 2*spin_matrix[i][j]-1;
		ns = 2*neighbour_sum(i,j)-4;
		magnetic_moment += 1.0*s;
		energy += 1.0*(s * ns);
	}
	energy = -J*energy + B*magnetic_moment;
	return energy;
}

double IsingModel::GetMagneticMoment() {
	return magnetic_moment;
}

double IsingModel::GetEnergy() {
	return energy;
}


#endif // ISING_MODEL