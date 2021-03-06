/*
 * SpecialMath.h
 * Specific Atomics
 * Michael Lenz
 * 2-15-16
 * does specialty math
*/

#ifndef SAAS_SPECIALMATH_H
#define SAAS_SPECIALMATH_H
#include "Vector.h"
#include <cmath>
namespace SpecialMath {
    /*
     * Calculates the distance between two points represented as vectors
     * @return distance between a and b.
     */
    template<typename T, std::size_t N>
    double DistanceFormula(Saas_Util::Vector<T, N> a, Saas_Util::Vector<T, N> b);
    /*
     * Calculates the distance between a point and a line represted as a point and a direction vector
     * @return distance between the reference point and the line.
     */
    double LineDistance(Saas_Util::Vector<double, 3> pointOnLine,Saas_Util::Vector<double, 3> directionOfLine,
                        Saas_Util::Vector<double, 3> referencePoint);
};


#endif //SAAS_SPECIALMATH_H