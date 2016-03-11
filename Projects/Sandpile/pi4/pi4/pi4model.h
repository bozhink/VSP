#ifndef PI4MODEL
#define PI4MODEL
#include <stdio.h>
#include <stdlib.h>
#define THRESHOLD 2

class pi4Model {
private:
	int**lattice; /* Lattice array */
	int L;        /* Lattice size */
	int t;        /* Avalanche's length */
	int s;        /* Avalanche's size */
public:
	pi4Model(int l);
	~pi4Model();
	void randomize();
	void update();
	void dropSand();
	int get_s();
	int get_t();
};

#endif /* PI4MODEL */