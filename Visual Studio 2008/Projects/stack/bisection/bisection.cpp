#include <iostream>
#include <cmath>
using namespace std;

void bisection(double (*f)(double), double &a, double &b, double eps){
	double fa = f(a);
	double fb = f(b);
	double c, fc;
	while((b-a) > eps){
		c = (a+b)/2.0;
		fc = f(c);
		if ((fa*fc)<0){
			b = c;
			fb = fc;
		} else{
			a = c;
			fa = fc;
		}
	}
	return;
}


int main()
{
	double a = -0.3, b = 0.1;
	double eps = 1.0e-12;
	bisection(sin, a, b, eps);
	cout << a << " " << b << "\n";
	return 0;
}
