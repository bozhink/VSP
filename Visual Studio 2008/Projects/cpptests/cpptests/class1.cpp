#include <iostream>
using namespace std;
class samp {
	int n;
public:
	samp(int n){this->n = n;}
	~samp(){cout << "...  :(";}
	int get(){return n;}
} ;