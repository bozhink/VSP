#include <iostream>
#include "./class1.cpp"
using namespace std;

void main(){
	samp s = samp(3);
	samp *p = &s;
	cout << s.get();
	cout << p->get();
}