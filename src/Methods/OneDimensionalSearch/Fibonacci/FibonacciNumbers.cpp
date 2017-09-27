#include "FibonacciNumbers.h"

double FibonacciNumbers::getNNumber(int n) {
    if (n == 0) {
        return 0.0;
    } else if (n == 1 || n == 2) {
        return 1.0;
    }
    double fkmm = 1.0, fkm = 1.0, k = 2, fk;
    do {
        fk = fkm + fkmm;
        fkmm = fkm;
        fkm = fk;
        k++;
    } while (k < n);
    return fk;
}

double FibonacciNumbers::getNextNumber(double fn, int &n) {
    n = 2;
    if (fn < 1.0) {
        return 1.0;
    }
    double fkmm = 1.0, fkm = 1.0, fk;
    do {
        fk = fkm + fkmm;
        fkmm = fkm;
        fkm = fk;
        n++;
    } while (fk <= fn);
    return fk;
}