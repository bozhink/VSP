#include <iostream>
#include <fstream>
using namespace std;

int main(int argc, char *argv[])
{
	if(argc!=3)
	{
		cout << "Usage: " << argv[0] << " <input> <output>\n";
		return 1;
	}

	ifstream fin(argv[1]);
	ofstream fout(argv[2]);

	if(!fout){ cout << "Cannot open output file\n"; return 1; }
	if(!fin) { cout << "Cannot open input file\n"; return 1;  }

	char ch;
	int n=0;

	fin.unsetf(ios::skipws);

	while(!fin.eof())
	{
		fin >> ch;
		if(!fin.eof()) fout << ch;
		n++;
	}

	fout.close();
	fin.close();

	cout << "Number of copyed characters: " << n << endl;

	return 0;
}
