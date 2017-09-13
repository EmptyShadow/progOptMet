#include <iostream>
#include "library.h"

double f(double x);

int main() {
    double a1, b1;
    swenn(4, a1, b1, f);
    printf("a1: %0.31f; b1: %0.31f\n\n", a1, b1);
    double x_;
    x_ = dichotomy(a1, b1, f, 1e-5);
    printf("x_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = goldenSectionNum1(a1, b1, f, 10, 1e-7);
    printf("x_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = goldenSectionNum2(a1, b1, f, 10, 1e-7);
    printf("x_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = methodFibonacci1(a1, b1, f, 1e-7);
    printf("x_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));
    x_ = methodFibonacci2(a1, b1, f, 1e-7, 1e-7);
    printf("x_: %0.31f; f(x_): %0.31f\n\n", x_, f(x_));

    return 0;
}

double f(double x) {
    return x * x + 2 * x;
}