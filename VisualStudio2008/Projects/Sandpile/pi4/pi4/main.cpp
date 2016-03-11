#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <iostream>
#include "pi4model.h"

using namespace std;

FILE*fp;      /* Output file handler */
char*fname;   /* Output file name */

int main(int argc, char**argv) {
	int i, N, L;
	int t, s;

	srand((unsigned int)time(NULL));

    if (argc<3) {
        fprintf(stderr, "Usage: %s <N> <L> [<FN>]\n", argv[0]);
        fprintf(stderr, "  where:\n");
        fprintf(stderr, "          N  =  number of iterations\n");
        fprintf(stderr, "          L  =  lattice size\n");
        fprintf(stderr, "         FN  =  output file name\n");
        exit(1);
    }
    if (argc < 4) {
        fp = stdout;
    } else {
        fname = argv[3];
        fp = fopen(fname, "a");
        if (!fp) {
            fprintf(stderr, "%s: ERROR: Cannot open output file!\n", argv[0]);
            exit(2);
        }
    }
    
    N = atoi(argv[1]);
	L = atoi(argv[2]);

	cout << "Number of iterations: " << N << endl;
	cout << "Lattice size:         " << L << endl;

	pi4Model model(L);

	// Simulation
	for (i=0; i<N; i++) {
        if ((fp!=stdout) && !(i%(N/1000))) fprintf(stderr, "\r# Iteration #%d", i);
    again:
		model.randomize();
        model.dropSand();
		model.update();
		t = model.get_t();
		s = model.get_s();
        if (t==L) goto again;
        fprintf(fp, "%d %d\n", t, s);
    }
	fprintf(stderr, "\n");

	fclose(fp);
	return 0;
}
