#include <iostream>
#include <cstring>
using namespace std;

class card{
	char title[80];
	char author[80];
	int number;
public:
	void store(char *t, char *name, int num);
	void show();
};

void card::store(char *t, char *name, int num)
{
	strcpy(title, t);
	strcpy(author, name);
	number = num;
}

void card::show()
{
	cout << "Title: ............ " << title << "\n";
	cout << "Author: ........... " << author << "\n";
	cout << "Number of hand: ... " << number << "\n";
}

int main()
{
	card book1;
	book1.store("Dune", "Frank Herbert", 2);
	book1.show();
	return 0;
}
