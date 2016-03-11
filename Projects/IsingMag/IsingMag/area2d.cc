#include <stdio.h>
#include "area2d.h"


void DumpArea2D(const Area2D<int> *a)
{
	printf("--------------------<dump>--------------------\n");
	for(int y=0; y<a->H(); y++)
	{
		for(int x=0; x<a->W(); x++)
		{
			int v=*a->Cell(x,y);
			printf(v ? " %3d" : "    ",v);
		}
		printf("\n");
	}
}
