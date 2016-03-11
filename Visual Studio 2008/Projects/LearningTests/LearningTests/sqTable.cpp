#include <iostream>
#include <iomanip>
#include <cmath>
using namespace std;

void first();
void second();

int main()
{
	first();
	second();
	return 0;
}

void first()
{
	double x;
	cout.precision(4);
	cout << "      x   sqrt(x)   x^2\n\n";

	for (x=2.0; x<=20.0; x++)
	{
		cout.width(7); cout << x << " ";
		cout.width(7); cout << sqrt(x) << " ";
		cout.width(7); cout << x*x << '\n';
	}
	return;
}

void second()
{
	double x;
	cout.precision(4);
	cout << "      x   sqrt(x)   x^2\n\n";

	for (x=2.0; x<=20.0; x++)
	{
		cout << setw(7) << x << " ";
		cout << setw(7) << sqrt(x) << " ";
		cout << setw(7) << x*x << '\n';
	}
	return;
}