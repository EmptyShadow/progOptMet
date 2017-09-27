#include "GoldenNumbers.h"

double GoldenNumbers::lambdaGoldenSection(double a1, double b1) {
    double t = (3.0 - sqrt(5.0)) / 2.0;
    return a1 + t * abs(b1 - a1);
}

double GoldenNumbers::muGoldenSection(double a1, double b1) {
    double t = (sqrt(5.0) - 1.0) / 2.0;
    return a1 + t * abs(b1 - a1);
}