/*
 * isim.cc -- Numerical Ising model simulation. 
 * 
 * Copyright (c) 06/2004, 08-10/2005 by Wolfgang Wieser, 
 *      email: > wwieser -a- gmx -*- de <
 * 
 * Version 1.5a (2005-10-05)
 * 
 * The above email is for bug reports and improvements of the core code, ONLY. 
 * It is not for general discussion or special questions about the code or 
 * about what is being done. 
 * Use plaintext emails; HTML mail may be considered as spam. 
 * 
 * ABOUT:
 * ------
 * 
 * Simulation of ISING model in a quadratic 2d area of variable length with 
 * external magnetic field switched off (H=0). 
 * The Ising model is an area of spins wich point either up or down. 
 * Nearest neighbour interaction is assumed (i.e. each spin has 4 neighbours), 
 * periodic boundary conditions. 
 * 
 * LICENSE:
 * --------
 * 
 * This file may be distributed and/or modified under the terms of the 
 * GNU General Public License version 2 as published by the Free Software 
 * Foundation. 
 * 
 * This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
 * WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
 * 
 * 
 * NOTE:
 * -----
 * 
 * This program uses the system rand() and srand() functions. 
 + For GNU libc-based systems, these work nice. 
 * If you have a system with a poor PRNG, include a different RNG here and 
 * use it for the simulations. Good results depend on good random numbers. 
 */

#include "alloc.h"
#include "area2d.h"

#include <stdio.h>
#include <math.h>
#include <assert.h>

// Define this to 1 to not get verbose progress output. 
// Useful if you run the program in the background with nohup...
#define QUIET 0


// Compute square of passed value.  
static inline double SQR(double x)
	{  return(x*x);  }


// Used at some positions in the code to (re)seed the RNG. Makes sure 
// that the program generally will NOT report identical results when 
// ran twice with identical parameters. 
// NOTE: If you don't have sys/time.h, comment the line out. 
//#include <sys/time.h>
#include <time.h>
static void _SeedRandom()
{
	static int last_seed=-1;
	
	// NOTE: If you don't have gettimeofday(), use something else like 
	//       time() or whatever to seed the RNG. 
	//timeval tv;
	//gettimeofday(&tv,NULL);
	//int seed=abs(tv.tv_usec/10+tv.tv_sec*100000);
	time_t tv;
	tv = time(NULL);
	int seed= tv*100000;
	if(seed!=last_seed)
	{  srand(last_seed=seed);  }
}


// Ising simulator class. 
// Contains spin area and can compute Monte-Carlo steps as well as the 
// average magnetisation. 
class IsingSimulator
{
	public:
		typedef char acell_t;
		
	private:
		Area2D<acell_t> area;
		
		// Reduced temperature. 
		double betaJ;
		// Precomputed exp(-E*betaJ) Boltzmann factors for all 5 possible 
		// neighbourhood configurations. 
		double d_exp_E_table[5];
		
		// Area size-1: 
		int L_1;
		
		// Count monte carlo steps since area initialisation: 
		int mcs;
		
		// Perform spin flip at location x,y in the area. 
		// If the flip is energetically favourable, always do it. 
		// Otherwise do it with a probability given by the Boltzmann factor 
		// exp(-beta*delta_E). 
		inline void _FlipSpin(int x,int y);
	public:
		// Pass area size als parameter. 
		IsingSimulator(int L);
		~IsingSimulator();
		
		// Set J/(k_B T) (reduced temperature): 
		void Set_betaJ(double betaJ);
		
		// Return number of performed MCS (Monte-Carlo steps). 
		inline int MCS() const
			{  return(mcs);  }
		
		// Return size of the area (length). 
		inline int L() const
			{  return(L_1+1);  }
		
		// Compute one MCS. 
		void MonteCarloStep();
		
		// Initialize the area: 
		// mode=0 -> T < T_C: initialize with spins all 1 (+1). 
		// mode=1 -> T > T_C: initialize with random spins
		void InitializeArea(int mode);
		
		// Compute average spin: 
		double AverageSpin() const;
		
		// Compute "internal energy", i.e. the value of the Hamiltonian. 
		// (Internal energy is the average of the Hamiltonian.) 
		double InternalEnergy() const;
};



void IsingSimulator::Set_betaJ(double _betaJ)
{
	betaJ=_betaJ;
	
	d_exp_E_table[0]=exp(-8.0*betaJ);
	d_exp_E_table[1]=exp(-4.0*betaJ);
	d_exp_E_table[2]=1.0;
	d_exp_E_table[3]=exp( 4.0*betaJ);
	d_exp_E_table[4]=exp( 8.0*betaJ);
}


double IsingSimulator::AverageSpin() const
{
	int nup=0;
	int ncells=area.W()*area.H();
	for(const acell_t *c=area.Cell(0,0),*cend=c+ncells; c<cend; c++)
		if(*c)  ++nup;
	return(double(nup-ncells+nup)/double(ncells));
}


double IsingSimulator::InternalEnergy() const
{
	// Only nearest neighbour interaction, of course. 
	// For each cell (x,y), compute energy with right and bottom neightbours. 
	// For the ones on the right and bottom borders we use periodic BC 
	// of course. 
	// The internal energy will not change when flipping ALL spins. 
	int uu=0;
	
	int endy=area.H()-1;
	int aw=area.W();
	for(int y=0; y<endy; y++)
	{
		const acell_t *c0=area.Cell(0,y);
		const acell_t *cend=c0+aw-1;  // -1 to leave away the last one. 
		for(const acell_t *c=c0; c<cend; c++)
		{
			if(*c==*(c+1))  ++uu;  // right neighbour
			if(*c==*(c+aw)) ++uu;  // down neighbour
		}
		// Last column in line. 
		if(*cend==*c0)  ++uu;
		if(*cend==*(cend+aw))  ++uu;
	}
	// Last line. 
	const acell_t *cf=area.Cell(0,0);
	const acell_t *cl=area.Cell(0,endy);
	const acell_t *clend=cl+aw-1;  // -1 to leave away the last one. 
	for(; cl<clend; cl++,cf++)
	{
		if(*cl==*(cl+1))  ++uu;  // right neighbour
		if(*cl==*cf)      ++uu;  // "down" neighbour which is in the first line
	}
	// Right bottom cell. 
	if(*clend==*area.Cell(0,endy))  ++uu;
	if(*cl==*cf)  ++uu;
	
	// uu is number of up-up plus down-down pairs, 0..2*W*H. 
	// In completely ordered phase, uu=2*W*H. 
	int H = area.W()*area.H() - uu;
	assert(H>=-area.W()*area.H());
	assert(H<=area.W()*area.H());
	
	// The hamiltonian is - sum_<i,j> S_i*S_j with S=+/-1, hence the energy 
	// difference between up-up and up-down is 2. So, multiply with 2. 
	return(2*H);
}


void IsingSimulator::InitializeArea(int mode)
{
	if(mode==0)
	{
		for(int y=0; y<area.H(); y++)
			for(int x=0; x<area.W(); x++)
				*area.Cell(x,y)=acell_t(1);
	}
	else
	{
		for(int y=0; y<area.H(); y++)
			for(int x=0; x<area.W(); x++)
				*area.Cell(x,y)=acell_t(rand() & 1);
	}
	
	mcs=0;
}


inline void IsingSimulator::_FlipSpin(int x,int y)
{
	acell_t *c=area.Cell(x,y);
	// Sum up over neighbours: 
	int nsum;
	if(!x || !y || x==L_1 || y==L_1)
		nsum = *area.Cell((x+1)%area.W(),y) + 
			*area.Cell(x,(y-1+area.H())%area.H()) + 
			*area.Cell((x-1+area.W())%area.W(),y) + 
			*area.Cell(x,(y+1)%area.H());
	else
		nsum = c[-1]+c[1]+c[-area.W()]+c[area.W()];
	
	// assert(nsum>=0 && nsum<=4);
	
	// nsum=4 if all neighbour cells are 1 and 0 if all of them are 0. 
	if(*c)  nsum=4-nsum;
	
	// Now, if all neighbours are 1 (0) and the center is 1 (0), nsum is 0 (0). 
	//      If all neighbours are 0 (1) and the center is 1 (0), nsum is 4 (4). 
	// So, nsum is now the number of differently directed spins in the 
	// neighbourhood. 
	// Or, if we made the spin flip of the center spin, nsum is the number 
	// of equally aligned spins in the neighbourhood. 
	// So, if we made the spin flip and nsum>2, then this is energetically 
	// favourable and we do the flip. 
	// If nsum<2, the spin flip is suppressed with a probability of 
	// exp(-dE * betaJ) = d_exp_E_table[nsum]. 
	// For nsum=2, both states have the same energy, so the thermal fluctuation 
	// happens with probability 1. 
	
	if(nsum>=2 ||   // dE<0
	   nsum<2 && int(d_exp_E_table[nsum]*RAND_MAX)>rand())
	{
		// Do the flip. 
		*c=(*c ? 0 : 1);
	}
}


void IsingSimulator::MonteCarloStep()
{
	int area_n=area.W()*area.H();
	int fx=-1,fy=0;
	for(int flip=0; flip<area_n; flip++)
	{
		// Choose location to flip: 
		// We just go through the complete area, cell-by-cell, line-by-line 
		// and try a flip on all of them. When this is done, one MCS has 
		// been simulated. 
		if(++fx>=area.W())
		{
			fx=0;
			if(++fy>=area.H())
				fy=0;
		}
		
		_FlipSpin(fx,fy);
	}
	
	++mcs;
}


IsingSimulator::IsingSimulator(int L) : 
	area(L,L)
{
	L_1=L-1;
}

IsingSimulator::~IsingSimulator()
{
}

//------------------------------------------------------------------------------

// Perform linear fit (linear regression), i.e. fit passed data 
// (x,y) with specified y standard deviation against a straight line. 
// Return coefficients of y = a + b*x in *a and *b and their 
// respective standard deviations in *a_sigma,*b_sigma. 
// Return value: chi^2 of the fit or negative values in case of error.
double LinearFit(
	const double *x,const double *y,const double *y_sigma,int ndata,
	double *_a,double *a_sigma,
	double *_b,double *b_sigma)
{
	// Implementation based on formulas 15.2.2 to 15.2.22 in 
	// Numerical Recipes in C: The Art of Scientific Computing 
	// (William  H. Press, Brian P. Flannery, Saul A. Teukolsky, 
	// William T. Vetterling; New York: Cambridge University Press) 
	// Written & verified to work correctly 06/2004 by Wolfgang Wieser. 
	
	double S=0.0,Sx=0.0,Sy=0.0;
	for(int i=0; i<ndata; i++)
	{
		double ss=1.0/SQR(y_sigma[i]);
		S+=ss;
		Sx+=x[i]*ss;
		Sy+=y[i]*ss;
	}
	//fprintf(stderr,"S=<%g %g %g>\n",S,Sx,Sy);
	
	double SxS=Sx/S;
	double b=0.0,Stt=0.0;
	for(int i=0; i<ndata; i++)
	{
		double ti=(x[i]-SxS)/y_sigma[i];
		b+=ti*y[i]/y_sigma[i];
		Stt+=ti*ti;
	}
	b/=Stt;
	//fprintf(stderr,"<b=%g,Stt=%g>\n",b,Stt);
	
	double a = (Sy - Sx*b) / S;
	if(_a) *_a=a;
	if(_b) *_b=b;
	if(a_sigma)  *a_sigma=sqrt((1.0+Sx*Sx/(S*Stt))/S);
	if(b_sigma)  *b_sigma=sqrt(1.0/Stt);
	// Cov(a,b)=-Sx/(S*Stt);
	// r_ab=Cov(a,b)/(sigma_a*sigma_b)
	
	double chi2=0.0;
	for(int i=0; i<ndata; i++)
		chi2+=SQR((y[i]-a-b*x[i])/y_sigma[i]);
	
	return(chi2);
}

//------------------------------------------------------------------------------
//------------------- DEMO APPLICATIONS OF THE ISING KERNEL --------------------

// Display the momentary magnetisation per spin as function of simulation 
// time. 
// Will make 2 plots, the first one with temperature betaJ_1, the second 
// one with betaJ_2. 
// betaJ is the "reduced temperature", i.e. betaJ = k_B * T / J 
// with k_B Boltzmann's constant, T temperature and J coupling strength 
// between spins. 
// The simulation starts with completely ordered state. 
// NOTE: MCS = monte carlo step = every spin on the area gets potentially 
//             flipped 
void DisplayMagnetisationPerSpinOverTime(
	double betaJ_1,double betaJ_2)
{
	int nsamples=200;        // <-- # of data points in diagram (time axis).
	int mcs_per_sample=5;    // <-- Record a data point every this many MCS. 
	IsingSimulator sim(64);  // <-- Tune are size here. 
	
	// Name of GNUPlot-generated postscript file. 
	const char *filename="magnetisation_per_spin_over_time.ps";
	
	//--------------------------------------------------------------------
	
	sim.Set_betaJ(betaJ_1);
	sim.InitializeArea(/*mode=*/0);
	
	printf("set term postsc color solid\n");
	printf("set outp \"%s\"\n",filename);
	printf("set title \"Magnetisation: %d samples, %d MCS/sample, L=%d\"\n",
		nsamples,mcs_per_sample,sim.L());
	printf("set xlabel \"MCS\"\n");
	printf("set ylabel \"M\"\n");
	printf("plot [] [-1:1] '-' with linespoints, '-' with linespoints\n");
	printf("%d %g\n",sim.MCS(),sim.AverageSpin());  // First data point. 
	for(int i=0; i<nsamples; i++)
	{
		for(int s=0; s<mcs_per_sample; s++)
			sim.MonteCarloStep();
		
		double avg_s=sim.AverageSpin();
		printf("%d %g\n",sim.MCS(),avg_s);
		
		#if !QUIET
		if(!(i&7))
		{  fprintf(stderr,"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
			"MCS[A]=%d",sim.MCS());  }
		#endif
	}
	printf("e\n");
	#if !QUIET
	fprintf(stderr,"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
		"MCS[A]=%d\n",sim.MCS());
	#endif
	
	sim.Set_betaJ(betaJ_2);
	sim.InitializeArea(/*mode=*/0);
	
	printf("%d %g\n",sim.MCS(),sim.AverageSpin());  // First data point. 
	for(int i=0; i<nsamples; i++)
	{
		for(int s=0; s<mcs_per_sample; s++)
			sim.MonteCarloStep();
		
		double avg_s=sim.AverageSpin();
		printf("%d %g\n",sim.MCS(),avg_s);
		
		#if !QUIET
		if(!(i&7))
		{  fprintf(stderr,"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
			"MCS[B]=%d",sim.MCS());  }
		#endif
	}
	printf("e\n");
	#if !QUIET
	fprintf(stderr,"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
		"MCS[B]=%d\n",sim.MCS());
	#endif
	
	fprintf(stderr,"Result stored in file %s.\n",filename);
}


// Display AVERAGE over time of magnetization per spin for different 
// (reciprocal reduced) temperatures from R_betaJ0 to R_betaJ1 using nsteps 
// steps. 
// Will compute MCS for each temperature until the sigma value (standard 
// deviation) of collected points drops below min_sigma; see the function 
// body for more tuning parameters. 
// All these computations are made for different area sizes as specified 
// in l_array[]. 
// NOTE: This function takes some time to compute. 
void DisplayMagnetisationTimeAverage()
{
	// R_betaJ0 is 1.0/(beta * J). 
	double R_betaJ0=1.0;   // from here...
	double R_betaJ1=4.0;   // ...to here in...
	
	// Make the complete temperature sweep from R_betaJ0 to R_betaJ1 for 
	// each area size specified in this array. LAST ENTRY MUST BE -1. 
	int l_array[]={32,64,/*128,256,*/-1};
	// Number of steps in the transition from R_betaJ0 to R_betaJ1: 
	// This has to be set for every area size. 
	int nsteps_array[]={21,21,/*61,61,*/-1};
	
	// Never take more than this number of samples for the average: 
	int max_samples=1000;
	// Do at least this many samples: 
	int min_samples=20;
	// Stop taking samples if the estimate for the standard deviation 
	// is smaller than this: 
	double min_sigma=1e-3;
	// A sample is taken after this many MCS: 
	int samp_mcs=20;
	// Do this many MCS initially to equilibrate: 
	int neq_mcs=20;
	
	// Name of GNUPlot-generated postscript file. 
	const char *filename="magnetisation_vs_temperature.ps";
	
	//--------------------------------------------------------------------
	
	printf("set term postsc color solid\n");
	printf("set outp \"%s\"\n",filename);
	printf("set title \"Magnetisation: (%d MCS/sample, skip %d MCS)\"\n",
		samp_mcs,neq_mcs);
	printf("set xlabel \"kT/J\"\n");
	printf("set ylabel \"|M|\"\n");
	printf("plot [] [0:1] ");
	for(int i=0; l_array[i]>=0; i++)
		printf("'-' notitle with errorbars, "
			"'-' %stitle \"L=%d\"%s%s",
			l_array[i]<48 ? "smooth csplines " : "",
			l_array[i],
			l_array[i]>=48 ? "with linespoints " : "",
			l_array[i+1]<0 ? "\n" : ", ");
	
	for(int li=0; l_array[li]>=0; li++)
	{
		IsingSimulator sim(l_array[li]);
		
		int nsteps=nsteps_array[li];       // this many steps
		assert(nsteps>0);
		
		double mag_avg[nsteps];
		double mag_sigma[nsteps];
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			
			sim.Set_betaJ(1.0/R_betaJ);
			sim.InitializeArea(/*mode=*/0);
			
			for(int i=0; i<neq_mcs; i++)
				sim.MonteCarloStep();
			
			double sum=0.0,sum2=0.0;
			int nsamples=0;
			while(nsamples<max_samples)
			{
				for(int s=0; s<samp_mcs; s++)
					sim.MonteCarloStep();
				
				double avg_s=fabs(sim.AverageSpin());
				sum+=avg_s;
				sum2+=avg_s*avg_s;
				++nsamples;
				
				if(nsamples>=min_samples && !(nsamples&0x3))
				{
					double avg=sum/nsamples;
					double sigma=sqrt( (sum2/nsamples - avg*avg)/nsamples );
					assert(!isnan(sigma));
					if(sigma<min_sigma) break;
				}
			}
			
			double avg=sum/nsamples;
			double sigma=sqrt( (sum2/nsamples - avg*avg)/nsamples );
			mag_avg[stp]=avg;
			mag_sigma[stp]=sigma;
			printf("%g %g %g\n",R_betaJ,avg,sigma);
			
			#if !QUIET
			fprintf(stderr,
				"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
				"L=%3d stp=%3d nsamp=%d    ",
				sim.L(),stp,nsamples);
			#endif
		}
		printf("e\n");
		#if !QUIET
		fprintf(stderr,"\n");
		#endif
		
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			printf("%g %g\n",R_betaJ,mag_avg[stp]);
		}
		printf("e\n");
	}
	
	fprintf(stderr,"Result stored in file %s.\n",filename);
}


// Simulates the ising model at the critical temperature k_B T_C / J = 2.269185 
// and uses scaling theory of finitly-sized areas to compute the ratios of 
// kritical exponents beta/nu and gamma/nu. 
void ComputeCriticalExponents()
{
	// Number of magnetization samples to gather. 
	// Use 20000 or more for good results and fast hardware. 
	int nsamples=2000;
	// Number of complete MCS to compute for each (of the nsamples) sample. 
	// Use 50..200 for good results and fast hardware. 
	int mcs_per_sample=40;
	
	// Use (finite) area sizes specified here in ascenting order. 
	// MUST BE TERMINATED BY -1. 
	int l_array[]={4,8,16,32,-1};
	
	// Name of GNUPlot-generated postscript file. 
	const char *filename="magnetisation_vs_area_size.ps";
	
	//--------------------------------------------------------------------
	
	int n_sizes=0;
	for(; l_array[n_sizes]>=0; n_sizes++);
	
	double mag_avg[n_sizes];
	double mag_sigma[n_sizes];
	double mag_avg2[n_sizes];
	double mag_sigma2[n_sizes];
	for(int li=0; l_array[li]>=0; li++)
	{
		IsingSimulator sim(l_array[li]);
		
		sim.Set_betaJ(1.0/2.269185);
		sim.InitializeArea(/*mode=*/0);
		
		double mag_sum=0.0;
		double mag_sum2=0.0;
		double mag_sum4=0.0;
		for(int i=0; i<nsamples; i++)
		{
			for(int s=0; s<mcs_per_sample; s++)
				sim.MonteCarloStep();
			
			double avg_s=fabs(sim.AverageSpin());
			mag_sum+=avg_s;
			mag_sum2+=SQR(avg_s);
			mag_sum4+=SQR(SQR(avg_s));
			
			#if !QUIET
			if(!(i&15))
			{  fprintf(stderr,"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
				"MCS[%d]=%d (%d%%)   ",
				sim.L(),sim.MCS(),
				100*sim.MCS()/(nsamples*mcs_per_sample));  }
			#endif
			
			if(!(i&15))
			{  _SeedRandom();  }
		}
		#if !QUIET
		fprintf(stderr,"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
			"MCS[%d]=%d (done)   \n",
			sim.L(),sim.MCS());
		#endif
		
		double avg=mag_sum/nsamples;
		double sigma=sqrt( (mag_sum2/nsamples - avg*avg)/nsamples );
		mag_avg[li]=avg;
		mag_sigma[li]=sigma;
		
		double avg2=mag_sum2/nsamples;
		double sigma2=sqrt( (mag_sum4/nsamples - avg2*avg2)/nsamples );
		mag_avg2[li]=avg2;
		mag_sigma2[li]=sigma2;
	}
	
	// Perform linar fit against data: 
	double fit_x[n_sizes];
	double fit_y[n_sizes];
	double fit_y_sigma[n_sizes];
	for(int li=0; li<n_sizes; li++)
	{
		fit_x[li]=log10(l_array[li]);
		fit_y[li]=log10(mag_avg[li]);
		fit_y_sigma[li]=0.5*(
			log10(mag_avg[li]+mag_sigma[li]) -
			log10(mag_avg[li]-mag_sigma[li]) );
	}
	double a,as,b,bs;
	double chi2=LinearFit(fit_x,fit_y,fit_y_sigma,n_sizes,&a,&as,&b,&bs);
	fprintf(stderr,"Linear fit: chi^2=%g; a=%g±%g, b=%g±%g\n",
		chi2,a,as,b,bs);
	fprintf(stderr,"  --> beta/nu=%g±%g\n",-b,bs);
	double beta_nu=-b;
	double beta_nu_s=bs;
	
	printf("set term postsc color solid\n");
	printf("set size 0.7, 0.7\n");
	printf("set outp \"%s\"\n",filename);
	printf("set title \"Avg. magnetisation: %d samples, %d MCS/sample\"\n",
		nsamples,mcs_per_sample);
	printf("set xlabel \"log10(L)\"\n");
	printf("set ylabel \"log10(|M|)\"\n");
	printf("plot [0.5:%g] %g%+g*x, '-' using 1:2:3:4 with errorbars\n",
		log10(l_array[n_sizes-1]*1.1),
		a,b);
	
	for(int li=0; li<n_sizes; li++)
	{
		printf("%g %g %g %g\n",
			fit_x[li],fit_y[li],
			log10(mag_avg[li]-mag_sigma[li]),
			log10(mag_avg[li]+mag_sigma[li]));
	}
	printf("e\n");
	
	//-------------------------------
	
	for(int li=0; li<n_sizes; li++)
	{
		fit_x[li]=log10(l_array[li]);
		double fact=SQR(l_array[li]);
		fit_y[li]=log10(mag_avg2[li]*fact);
		fit_y_sigma[li]=0.5*(
			log10((mag_avg2[li]+mag_sigma2[li])*fact) -
			log10((mag_avg2[li]-mag_sigma2[li])*fact) );
	}
	chi2=LinearFit(fit_x,fit_y,fit_y_sigma,n_sizes,&a,&as,&b,&bs);
	fprintf(stderr,"Linear fit: chi^2=%g; a=%g±%g, b=%g±%g\n",
		chi2,a,as,b,bs);
	fprintf(stderr,"  --> gamma/nu=%g±%g\n",b,bs);
	double gamma_nu=b;
	double gamma_nu_s=bs;
	
	printf("set title \"Avg. magnetisation^2: %d samples, %d MCS/sample\"\n",
		nsamples,mcs_per_sample);
	printf("set xlabel \"log10(L)\"\n");
	printf("set ylabel \"log10(M^2)\"\n");
	printf("plot [0.5:%g] %g%+g*x, '-' using 1:2:3:4 with errorbars\n",
		log10(l_array[n_sizes-1]*1.1),
		a,b);
	
	for(int li=0; li<n_sizes; li++)
	{
		double fact=SQR(l_array[li]);
		printf("%g %g %g %g\n",
			fit_x[li],fit_y[li],
			log10((mag_avg2[li]-mag_sigma2[li])*fact),
			log10((mag_avg2[li]+mag_sigma2[li])*fact));
	}
	printf("e\n");
	
	// 2*beta+gamma = nu*d...
	fprintf(stderr,"Test: %g±%g (should be 2)\n",
		2.0*beta_nu+gamma_nu,
		hypot(2.0*beta_nu_s,gamma_nu_s));
	
	fprintf(stderr,"Graph stored in file %s.\n",filename);
}


// Display susceptibility chi = \partial m / \partial H versus temperature 
// from R_betaJ0 to R_betaJ1 using nsteps steps. 
// Will compute MCS for each temperature until the sigma value (standard 
// deviation) of collected points drops below min_sigma; see the function 
// body for more tuning parameters. 
// All these computations are made for different area sizes as specified 
// in l_array[]. 
// NOTE: This function takes very to compute unless you use a small area 
//       and a large sigma value. 
void DisplaySusceptibilitySweep()
{
	// R_betaJ0 is 1.0/(beta * J). 
	double R_betaJ0=1.8;   // from here...
	double R_betaJ1=3.0;   // ...to here in...
	
	// Make the complete temperature sweep from R_betaJ0 to R_betaJ1 for 
	// each area size specified in this array. LAST ENTRY MUST BE -1. 
	int l_array[]={32/*,64,128,256*/,-1};
	// Number of steps in the transition from R_betaJ0 to R_betaJ1: 
	// This has to be set for every area size. 
	int nsteps_array[]={21/*21,21,41,61*/,-1};
	
	// Never take more than this number of samples for the average: 
	int max_samples=10000;
	// Do at least this many samples: 
	int min_samples=20;
	// Stop taking samples if the estimate for the standard deviation 
	// is smaller than this: (Sigma of the susceptibility.)
	double min_sigma=5;
	// A sample is taken after this many MCS: 
	int samp_mcs=20;
	// Do this many MCS initially to equilibrate: 
	int neq_mcs=20;
	
	// Name of GNUPlot-generated postscript file. 
	const char *filename="chi_vs_temperature.ps";
	
	// Dump data in the diagram into this file as well. 
	const char *datafile="suscept.dat";
	
	//--------------------------------------------------------------------
	
	FILE *fp=fopen(datafile,"w");
	if(!fp)
	{  fprintf(stderr,"Failed to open %s.\n",datafile);  exit(1);  }
	
	printf("set term postsc color solid\n");
	printf("set outp \"%s\"\n",filename);
	printf("set title \"chi: (%d MCS/sample, skip %d MCS, "
		"sigma=%g, max_samples=%d)\"\n",
		samp_mcs,neq_mcs,min_sigma,max_samples);
	printf("set xlabel \"kT/J\"\n");
	printf("set ylabel \"chi\"\n");
	printf("plot [] [0:] ");
	for(int i=0; l_array[i]>=0; i++)
		printf("'-' notitle with errorbars lt %d, "
			"'-' %stitle \"L=%d\"%slt %d%s",
			i+1,
			l_array[i]<0 ? "smooth csplines " : "",
			l_array[i],
			l_array[i]>=0 ? "with linespoints " : "",
			i+1,
			l_array[i+1]<0 ? "\n" : ", ");
	
	for(int li=0; l_array[li]>=0; li++)
	{
		IsingSimulator sim(l_array[li]);
		
		int nsteps=nsteps_array[li];       // this many steps
		assert(nsteps>0);
		
		double res_chi[nsteps];
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			
			sim.Set_betaJ(1.0/R_betaJ);
			sim.InitializeArea(/*mode=*/0);
			
			for(int i=0; i<neq_mcs; i++)
				sim.MonteCarloStep();
			
			double sum=0.0,sum2=0.0,sum4=0.0;
			int nsamples=0;
			for(;;)
			{
				for(int s=0; s<samp_mcs; s++)
					sim.MonteCarloStep();
				
				// NOTE: I am averaging the sum over spins here 
				//       (sum over spins = average spin * L^2). 
				double avg_s=fabs(sim.AverageSpin())*SQR(sim.L());
				sum+=avg_s;     avg_s*=avg_s;
				sum2+=avg_s;    avg_s*=avg_s;
				sum4+=avg_s;
				++nsamples;
				
				if(nsamples>=min_samples && !(nsamples&0x3) || 
					nsamples>=max_samples)
				{
					double avg=sum/nsamples;
					double avg2=sum2/nsamples;
					
					double sigma=sqrt( (avg2 - avg*avg)/nsamples );
					double sigma2=sqrt( (sum4/nsamples - avg2*avg2)/nsamples );
					
					// Unsure if the error estimate for chi_sigma is apropriate 
					// here. Please read the comment in DisplayHeatCapacitySweep() 
					// at the corresponding code location where a very similar 
					// calculation is done. 
					
					double chi = (avg2-SQR(avg)) / SQR(sim.L());
					double chi_sigma = hypot(sigma2,2*avg*sigma) / SQR(sim.L());
					assert(!isnan(chi_sigma));
					if(chi_sigma<min_sigma || nsamples>=max_samples)
					{
						res_chi[stp]=chi;
						printf("%g %g %g\n",R_betaJ,chi,chi_sigma);
						// Dump into data file as well. 
						fprintf(fp,"%g %g %g   %g %g %g\n",
							R_betaJ,chi,chi_sigma,
							sigma2,avg,sigma);
						fflush(fp);
						
						#if !QUIET
						fprintf(stderr,
							"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
							"L=%3d stp=%3d nsamp=%d;  chi=%.4g, sigma=%.4g        ",
							sim.L(),stp,nsamples,chi,chi_sigma);
						#endif
						
						break;
					}
				}
			}
		}
		printf("e\n");
		#if !QUIET
		fprintf(stderr,"\n");
		#endif
		
		// Output the same graph again, this time with linespoints. 
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			printf("%g %g\n",R_betaJ,res_chi[stp]);
		}
		printf("e\n");
	}
	
	fclose(fp);
	
	fprintf(stderr,"Result stored in files %s and %s.\n",filename,datafile);
}


// Like the other sweep functions: Compute the internal energy per spin 
// for different temperatures (and area sizes) and display them. 
void DisplayInternalEnergySweep()
{
	// R_betaJ0 is 1.0/(beta * J). 
	double R_betaJ0=1;//1.6;   // from here...
	double R_betaJ1=4;//3.2;   // ...to here in...
	
	// Make the complete temperature sweep from R_betaJ0 to R_betaJ1 for 
	// each area size specified in this array. LAST ENTRY MUST BE -1. 
	int l_array[]={8,32,128/*,256*/,-1};
	// Number of steps in the transition from R_betaJ0 to R_betaJ1: 
	// This has to be set for every area size. 
	int nsteps_array[]={61,61,61/**,61*/,-1};
	
	// Never take more than this number of samples for the average: 
	int max_samples=10000;
	// Do at least this many samples: 
	int min_samples=20;
	// Stop taking samples if the estimate for the standard deviation 
	// is smaller than this: (Sigma of the H/N; note that H/N<=2.)
	double min_sigma=5e-3;
	// A sample is taken after this many MCS: 
	int samp_mcs=20;
	// Do this many MCS initially to equilibrate: 
	int neq_mcs=20;
	
	// Name of GNUPlot-generated postscript file. 
	const char *filename="h_vs_temperature.ps";
	
	// Dump data in the diagram into this file as well. 
	const char *datafile="hamilton.dat";
	
	//--------------------------------------------------------------------
	
	FILE *fp=fopen(datafile,"w");
	if(!fp)
	{  fprintf(stderr,"Failed to open %s.\n",datafile);  exit(1);  }
	
	printf("set term postsc color solid\n");
	printf("set outp \"%s\"\n",filename);
	printf("set title \"H/N: (%d MCS/sample, skip %d MCS, "
		"sigma=%g, max_samples=%d)\"\n",
		samp_mcs,neq_mcs,min_sigma,max_samples);
	printf("set xlabel \"kT/J\"\n");
	printf("set ylabel \"H/N\"\n");
	printf("plot [] [-2:] ");
	for(int i=0; l_array[i]>=0; i++)
		printf("'-' notitle with errorbars lt %d, "
			"'-' %stitle \"L=%d\" %slt %d%s",
			i+1,
			l_array[i]<0 ? "smooth csplines " : "",
			l_array[i],
			l_array[i]>=0 ? "with linespoints " : "",
			i+1,
			l_array[i+1]<0 ? "\n" : ", ");
	
	for(int li=0; l_array[li]>=0; li++)
	{
		IsingSimulator sim(l_array[li]);
		
		int nsteps=nsteps_array[li];       // this many steps
		assert(nsteps>0);
		
		double res_H_N[nsteps];
		double res_H_N_sigma[nsteps];
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			double betaJ = 1.0/R_betaJ;
			
			sim.Set_betaJ(betaJ);
			sim.InitializeArea(/*mode=*/0);
			
			for(int i=0; i<neq_mcs; i++)
				sim.MonteCarloStep();
			
			double sum=0.0,sum2=0.0;
			int nsamples=0;
			for(;;)
			{
				for(int s=0; s<samp_mcs; s++)
					sim.MonteCarloStep();
				
				// In contrast to magnetisation, internal energy will not 
				// change the sign when "changing sideness" (i.e. flipping) 
				// the whole system. So, we do not need fabs() here. 
				double H_N=/*fabs*/(sim.InternalEnergy())/SQR(sim.L());
				sum+=H_N;
				sum2+=SQR(H_N);
				++nsamples;
				
				if(nsamples>=min_samples && !(nsamples&0x3) || 
					nsamples>=max_samples)
				{
					double avg=sum/nsamples;
					double avg2=sum2/nsamples;
					
					double sigma=sqrt( (avg2 - avg*avg)/nsamples );
					assert(finite(sigma));
					
					if(sigma<min_sigma || nsamples>=max_samples)
					{
						res_H_N[stp]=avg;
						res_H_N_sigma[stp]=sigma;
						
						// Write to gnuplot. 
						printf("%g %g %g\n",R_betaJ,avg,sigma);
						
						// Dump into data file as well. 
						fprintf(fp,"%g %g %g\n",R_betaJ,avg,sigma);
						fflush(fp);
						
						#if !QUIET
						fprintf(stderr,
							"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
							"L=%3d stp=%3d nsamp=%d;  H/N=%.4g, sigma=%.4g        ",
							sim.L(),stp,nsamples,avg,sigma);
						#endif
						
						break;
					}
				}
			}
		}
		printf("e\n");
		#if !QUIET
		fprintf(stderr,"\n");
		#endif
		
#if 1
		// Output the same graph again, this time with linespoints. 
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			printf("%g %g\n",R_betaJ,res_H_N[stp]);
		}
#else
		// Special version: Output numerical derivation. 
		for(int stp=1; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0+(R_betaJ1-R_betaJ0)*(stp-0.5)/(nsteps-1);
			double dT = (R_betaJ1-R_betaJ0)/(nsteps-1);
			printf("%g %g\n",R_betaJ,
				(res_H_N[stp]-res_H_N[stp-1])/dT);
		}
#endif
		printf("e\n");
	}
	
	fclose(fp);
	
	fprintf(stderr,"Result stored in files %s and %s.\n",filename,datafile);
}


// FDT tells us that C_v/k_B = beta^2 * Var(H). 
// Hence, we can display the heat capacity C_v for different temperatures. 
// Actually, we compute C_v/(N*k_B). 
// This is very similar to the DisplaySusceptibilitySweep() function. 
// The C_v/N value is quite independent of the area size since finite size 
// effects are small. 
// Preset parameters give a rough curve; for a really nice one you need to 
// set larger size, more samples and more steps and have it calculate a 
// day or so...
void DisplayHeatCapacitySweep()
{
	// R_betaJ0 is 1.0/(beta * J). 
	double R_betaJ0=1.0;   // from here...
	double R_betaJ1=4.0;    // ...to here in...
	
	// Make the complete temperature sweep from R_betaJ0 to R_betaJ1 for 
	// each area size specified in this array. LAST ENTRY MUST BE -1. 
	int l_array[]={16/*,32,64,128,256*/,-1};
	// Number of steps in the transition from R_betaJ0 to R_betaJ1: 
	// This has to be set for every area size. 
	int nsteps_array[]={31/*,41,41,61,61*/,-1};
	
	// Number of samples to take for the average (and variance): 
	int max_samples=2000;
	// A sample is taken after this many MCS: 
	int samp_mcs=20;
	// Do this many MCS initially to equilibrate: 
	int neq_mcs=20;
	
	const char *filename="cv_vs_temperature.ps";
	
	// Dump data in the diagram into this file as well. 
	const char *datafile="heatcap.dat";
	
	//--------------------------------------------------------------------
	
	FILE *fp=fopen(datafile,"w");
	if(!fp)
	{  fprintf(stderr,"Failed to open %s.\n",datafile);  exit(1);  }
	
	printf("set term postsc color solid\n");
	printf("set outp \"%s\"\n",filename);
	printf("set title \"C_v: (%d MCS/sample, skip %d MCS, "
		"max_samples=%d)\"\n",
		samp_mcs,neq_mcs,max_samples);
	printf("set xlabel \"kT/J\"\n");
	printf("set ylabel \"C_v/(N*k)\"\n");
	printf("plot [] [0:] ");
	for(int i=0; l_array[i]>=0; i++)
		printf("'-' notitle with linespoints lt %d%s",
			i+1,
			l_array[i+1]<0 ? "\n" : ", ");
	
	for(int li=0; l_array[li]>=0; li++)
	{
		IsingSimulator sim(l_array[li]);
		
		int nsteps=nsteps_array[li];       // this many steps
		assert(nsteps>0);
		
		double res_C_v_Nk[nsteps];
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			double betaJ = 1.0/R_betaJ;
			
			sim.Set_betaJ(betaJ);
			sim.InitializeArea(/*mode=*/0);
			
			for(int i=0; i<neq_mcs; i++)
				sim.MonteCarloStep();
			
			double sum=0.0,sum2=0.0;
			int nsamples=0;
			for(;;)
			{
				for(int s=0; s<samp_mcs; s++)
					sim.MonteCarloStep();
				
				double bH=betaJ*fabs(sim.InternalEnergy());
				sum+=bH;
				sum2+=SQR(bH);
				++nsamples;
				
				if(nsamples>=max_samples)
				{
					double avg=sum/nsamples;
					double avg2=sum2/nsamples;
					
					// Out of the simulation, we get (by time averaging) 
					// the averaged values for bH and bH^2 which are 
					// stored in the vars avg and avg2. 
					// We can hence calculate C_v/Nk = Var(bH) = <see below>. 
					double Var_bH = avg2 - avg*avg;
					
					// Compute heat capacity: 
					double C_v_Nk = Var_bH / SQR(sim.L());
					
					res_C_v_Nk[stp]=C_v_Nk;
					printf("%g %g\n",R_betaJ,C_v_Nk);
					// Dump into data file as well. 
					fprintf(fp,"%g %g\n",
						R_betaJ,C_v_Nk);
					fflush(fp);
					
					#if !QUIET
					fprintf(stderr,
						"\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"
						"L=%3d stp=%3d nsamp=%d;  C_v/Nk=%.4g        ",
						sim.L(),stp,nsamples,C_v_Nk);
					#endif
					
					break;
				}
				
				if(!(nsamples&0xfff))
				{  _SeedRandom();  }
			}
		}
		printf("e\n");
		#if !QUIET
		fprintf(stderr,"\n");
		#endif
		
#if 0
		// Output the same graph again, this time with linespoints. 
		for(int stp=0; stp<nsteps; stp++)
		{
			double R_betaJ = R_betaJ0 + (R_betaJ1-R_betaJ0)*stp/(nsteps-1);
			printf("%g %g\n",R_betaJ,res_C_v_Nk[stp]);
		}
		printf("e\n");
#endif
	}
	
	fclose(fp);
	
	fprintf(stderr,"Result stored in files %s and %s.\n",filename,datafile);
}

//------------------------------------------------------------------------------

int main()
{
	_SeedRandom();
	
	// Choose what the program should simulate: 
	// Uncomment at least one line. 
	// Feel free to add further functions. 
	
	//DisplayMagnetisationPerSpinOverTime(1.0/1.8, 1.0/2.8);
	//DisplayMagnetisationTimeAverage();
	//ComputeCriticalExponents();
	//DisplaySusceptibilitySweep();
	DisplayInternalEnergySweep();
	//DisplayHeatCapacitySweep();
	
	return(0);
}
