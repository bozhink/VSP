#include <iostream>
using namespace std;

extern "C" __declspec(dllimport) double AddNumbers(double a, double b);

void func(int &i, int &j)
{
	__asm{
		pop  i
		pop  j
		push i
		push j
	}
	return;
}

void main()
{
	double x, y, z;
	int ii=1, jj=2;
	func(ii, jj);
	cout << ii << ' ' << jj << endl;
	x=2.0;
	y=3.0;
	z=AddNumbers(x,y);
	cout << z<< endl;
	return;
}
