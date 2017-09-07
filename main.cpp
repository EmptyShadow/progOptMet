#include <iostream>
#include "library.h"

double f(double x);

int main() {
    double a1, b1;
    swenn(4, &a1, &b1, f);
    intervalNormalization(&a1, &b1);
    std::cout << "a1: " << a1 << " b1: " << b1 << std::endl;
    double x_ = dichotomy(a1, b1, f, 1e-5);
    std::cout << "x_: " << x_ << " f(x_): " << f(x_) << std::endl;
    return 0;
}

double f(double x) {
    return x * x + 2 * x;
}