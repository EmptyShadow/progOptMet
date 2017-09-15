#include <iostream>
#include "library.h"

double f(double x);

int main() {
    double a1, b1;
    double x_, fx_;

    swenn(4, a1, b1, f);
    printf("Swenn:\na1: %0.9f; b1: %0.9f\n\n", a1, b1);
    x_ = a3DSC(4, f, 1e-7, 1e-7);
    printf("Powell:\na1: %0.9f; b1: %0.9f; x_: %0.9f; f(x_): %0.9f\n\n", a1, b1, x_, f(x_));

    /*x_ = dichotomy(a1, b1, f, 1e-5);
    printf("Dichotomy:\nx_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = goldenSectionNum1(a1, b1, f, 10, 1e-7);
    printf("GoldenSectionNum1:\nx_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = goldenSectionNum2(a1, b1, f, 10, 1e-7);
    printf("GoldenSectionNum2:\nx_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = methodFibonacci1(a1, b1, f, 1e-7);
    printf("methodFibonacci1:\nx_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = methodFibonacci2(a1, b1, f, 1e-7, 1e-7);
    printf("methodFibonacci2:\nx_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = a1ei(a1, b1, f, 1e-7);
    printf("A1EI:\nx_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));*/

    return 0;
}

double f(double x) {
    return x * x + 2 * x;
}