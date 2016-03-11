#include <iostream>
using namespace std;

int main()
{
	cout << 123.23 << " hello " << 100 << '\n';
	cout << 10 << ' ' << -10 << '\n';
	cout << 100 << "\n\n";
	
	cout.unsetf(ios::dec);
	cout.setf(ios::hex | ios::scientific);

	cout << 123.23 << " hello " << 100 << '\n';

	cout.setf(ios::showpos);
	cout << 10 << ' ' << -10 << '\n';

	cout.setf(ios::showpoint | ios::fixed);
	cout << 100 << "\n\n";

	return 0;
}