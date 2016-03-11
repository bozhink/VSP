// ExclusionProcess.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

unsigned int chain[L];      /* Array, which contains the cain sites. */
unsigned int histogram[L];
unsigned int J[L];
double dos[L], dJ[L];

char code[2];

const double p = 0.5;

int nextupdate(int current, int next, double p);
void statistics(int left, int right, double*x, double*mean, double*stdev);
void init();
void genpos();
void draw();

void main (int argc, char**argv) {
    int i, j, iter;
    unsigned int Neff;
    double dneff, mdos, sdos, mJ, sJ;
    FILE*fp;
    
    if (argc < 2) {
        fprintf(stderr, "Usage: %s <output file name>\n", argv[0]);
        exit(1);
    }
    
    init();
    genpos();

    /* Simulation */
    // draw();
    for (i = 0; i < NITER * L; i++) {
        nextupdate(pos(i), pos(i-1), p);
        // if (!(i%NITER)) draw();
    }
    
    Neff=0;
    for (i=0; i<L; i++) Neff += histogram[i];
    printf("Effective number of iterations = %d\n", Neff);
    
    /* Calculation of DOS and current */
    dneff = (1.0*N)/Neff;
    for (i=0; i<L; i++) {
        dos[i] = histogram[i] * dneff;
        dJ[i]  = J[i] * dneff;
    }
    /* Export of results */
    fp = fopen(argv[1], "w");
    if (!fp) {
        fprintf(stderr, "%s: ERROR opening output file!\n", argv[0]);
        exit(1);
    }
    for (i=0; i<L; i++) {
        fprintf(fp, "%d\t%d\t%lf\t%d\t%lf\n", 
           i, histogram[i], dos[i], J[i], dJ[i]);
    }
    
    statistics(0, L, dos, &mdos, &sdos);
    statistics(0, L, dJ, &mJ, &sJ);
    
    fprintf(fp, "#\n# mean DOS = %lf\n# stddev = %lf\n#\n", mdos, sdos);
    fprintf(fp, "#\n# mean J = %lf\n# stddev = %lf\n#\n", mJ, sJ);
    fprintf(fp, "#\n# exact J = %lf\n#\n", exact(p, mdos));
    fclose(fp);
}

/*
 * Initialization
 */
void init() {
    int i;
    code[0] = '-';
    code[1] = 'X';
    for (i=0; i<L; i++) {
        chain[i] = 0;
        histogram[i] = 0;
        J[i] = 0;
    }
    srand(time(NULL));
}

/*
 * Generation of initial positions
 */
void genpos () {
    int i, pos;
    pos = rand() % L;
    chain[pos] = 1;
    for (i=1; i<N; i++) {
    updatePosition:
        pos = rand() % L;
        if (chain[pos]!=0) goto updatePosition;
        chain[pos] = 1;
    }
}

/*
 * Drawing the chain
 */
void draw () {
    int j;
    for (j=L-1; j>=0; j--) printf("%c", code[chain[j]]);
    printf("\n");
}

int nextupdate(int current, int next, double p) {
    int moved = 0; /* Is moved */
    int pos; /* position */
    
    pos = current;
    if (chain[current]) {
        if (chain[next] == 0 && drand() < p) {
            chain[current]--;
            chain[next]++;
            moved = 1;
            pos = next;
            J[current]++;
        }
        histogram[pos]++;
    }
    
    return moved;
}

/*
 * Statstical properties
 */
void statistics(int left, int right, double*x, double*mean, double*stdev) {
    int i;
    double sx, sxx;
    sx  = 0.0;
    sxx = 0.0;
    for (i=left; i<right; i++) {
        sx  += x[i];
        sxx += x[i]*x[i];
    }
    sx /= (right-left);
    sxx /= (right-left);
    *mean = sx;
    *stdev = sqrt(sxx-sx*sx);
}
