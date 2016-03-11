#include "pi4model.h"

#ifdef PI4MODEL

pi4Model::pi4Model(int l) {
	L = l;
	int i;
    /*
	 * Allocation of memory for lattice array
	 */
    lattice = (int**) malloc ( L * sizeof(int*));
    for (i=0; i<L; i++) {
        lattice[i] = (int*) malloc ( (i+1) * sizeof(int) );
    }
    if (!lattice) {
        fprintf(stderr, "%s: ERROR: Cannot allocate memory for lattice's array!\n");
        exit(2);
    }
}


pi4Model::~pi4Model() {
	int i;
    for (i=0; i<L; i++) free(lattice[i]);
    free(lattice);
}


void pi4Model::randomize() {
    int i, j;
    for (i=0; i<L; i++) {
        for (j=0; j<i+1; j++) {
            lattice[i][j] = rand() % THRESHOLD;
        }
    }
}


/*
 * alpha=1/4, beta=1/4, gamma=1/2
 */
void pi4Model::update() {
	int i, i1, j, j1, p;
    s = 0;
    t = 0;
    for (i=0; i<L-1; i++) {
        i1 = i + 1;
        for (j=0; j<i1; j++) {
            while (lattice[i][j] >= THRESHOLD) {
                t -= ((t-i1)&((t-i1)>>31)); /* t = max(t, i+1) */
                s++;
                lattice[i][j] -= THRESHOLD;
                p = rand() % 4;
                j1 = (j+1+i1) % i1;
                switch (p) {
                    case 0:
                        lattice[i1][j] += THRESHOLD;
                        break;
                    case 1:
                        lattice[i1][j1] += THRESHOLD;
                        break;
                    default:
                        lattice[i1][j] += THRESHOLD/2;
                        lattice[i1][j1] += THRESHOLD/2;
                }
            }
        }
    }
    t++;
    /* Last line */
    i1 = L-1;
    for (j=0; j<L; j++) {
        while (lattice[i1][j] >= THRESHOLD) {
            s++;
            lattice[i1][j] -= THRESHOLD;
        }
    }
}


void pi4Model::dropSand() {
	lattice[0][0]++;
}


int pi4Model::get_t() {
	return t;
}


int pi4Model::get_s() {
	return s;
}


#endif /* PI4MODEL */