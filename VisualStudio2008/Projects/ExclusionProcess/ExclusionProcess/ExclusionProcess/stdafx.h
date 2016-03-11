// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#include <stdio.h>
#include <tchar.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#define L 10
#define N 5
#define pos(x) ((x+L)%L)
#define NITER 10000
#define drand() ((1.0*rand()) / RAND_MAX)
#define exact(p, r) ((1.0*p*r*(1-r))/(1-p*r))




// TODO: reference additional headers your program requires here
