// Ponto.cpp : Defines the exported functions by Ponto.lib
//

#include "Ponto.h"
#include <math.h>
#include <iostream>

/*
 * This is the constructor of a class that has been exported.
 * see aula01_Ponto.h for the class definition
 */
Ponto::Ponto(int x, int y, int z)
{
	this->_z = z;
	this->_x = x;
	this->_y = y;
}

double Ponto::getModule() {	 
	return sqrt((double)_x*_x + _y*_y + _z*_z);
}

void Ponto::print(){
	printf("Point v3 SUPER (x = %d, y = %d, z=%d)\n", _x, _y, _z);
}
