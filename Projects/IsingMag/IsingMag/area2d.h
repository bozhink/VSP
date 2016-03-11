/*
 * area2d.h -- Basic 2dim area template. 
 * 
 * Copyright (c) 2004 by Wolfgang Wieser, email: > wwieser -a- gmx -*- de <
 * 
 * This file may be distributed and/or modified under the terms of the 
 * GNU General Public License version 2 as published by the Free Software 
 * Foundation. 
 * 
 * This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
 * WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
 * 
 */


#ifndef _AREA2D_H_
#define _AREA2D_H_ 1

// Simple 2dim area template of specified type. 
template<typename T>class Area2D
{
	private:
		int w,h;   // Area size. 
		T *c;      // Cells of the are (usual scanline order). 
		
		// Not C++-safe: Do not use these (hence private). 
		Area2D &operator=(const Area2D &) {}
		Area2D(const Area2D &) {}
	public:
		// Create area; 
		inline Area2D(int _w,int _h) : w(_w),h(_h)
			{  c=new T[w*h];  }
		// Destroy area. 
		inline ~Area2D()
			{  delete[] c;  }
		
		// Get area size: 
		int W() const  {  return(w);  }
		int H() const  {  return(h);  }
		
		// Get pointer to area element with specified coordinates: 
		// Note: No range check. 
		inline T *Cell(int x,int y)        {  return(&c[w*y+x]);  }
		inline T *operator()(int x,int y)  {  return(Cell(x,y));  }
		inline const T *Cell(int x,int y)  const        {  return(&c[w*y+x]);  }
		inline const T *operator()(int x,int y)  const  {  return(Cell(x,y));  }
};

// For debugging: 
extern void DumpArea2D(const Area2D<int> *a);

#endif  /* _AREA2D_H_ */
