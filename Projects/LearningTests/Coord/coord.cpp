#include <iostream>
using namespace std;

class coord {
	int x, y;
public:
	coord() { x=0; y=0;}
	coord(int xx, int yy) { x=xx; y=yy; }
	friend ostream &operator<<(ostream &stream, coord &ob);
	friend istream &operator>>(istream &stream, coord &ob);
};

ostream &operator<<(ostream &stream, coord &ob)
{
	stream << ob.x << ", " << ob.y << endl;
	return stream;
}

istream &operator>>(istream &stream, coord &ob)
{
	cout << "Enter coordinates: ";
	stream >> ob.x >> ob.y;
	return stream;
}

class triangle {
	int height, base;
public:
	triangle(int h, int b) { height=h; base=b; }
	friend ostream &operator<<(ostream &stream, triangle &ob);
};

ostream &operator<<(ostream &stream, triangle &ob)
{
	int i, j, k, h;

	i=j=ob.base-1;
	for(h=ob.height-1; h; h--)
	{
		for(k=i; k; k--) stream << ' ';
		stream << '*';

		if(j!=i)
		{
			for(k=j-i-1; k; k--) stream << ' ';
			stream << '*';
		}

		i--;
		stream << '\n';
	}
	for(k=0; k<ob.base; k++) stream << '*';
	stream << '\n';

	return stream;
}

int main()
{
	coord a(1,1), b(10,23);
	triangle t1(5,5), t2(10,10), t3(12,12);
	cout << a << b;
	//cin  >> a;
	cout << a;
	cout << t1;
	cout << endl << t2 << endl << t3;
	return 0;
}