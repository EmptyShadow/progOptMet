#include <iostream>
#include "library.h"

double f_lab1(double x);

void lab1(double (*f)(double), double x1, double eps);
void zadanie1(double (*f)(double), double x1, double eps);

int main() {
    lab1(f_lab1, 1, 1e-2);
    zadanie1(f_lab1, 1, 1e-2);

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

double f_lab1(double x) {
    return 2 * x * x + 16.0 / x;
}

void lab1(double (*f)(double), double x1, double eps){
    double a1, b1, a, b;
    double x_, fx_;
    printf("Laboratory work number 1\n");
    printf("Perform student of group 5301 Nebotov D.S.\n\n");

    x_ = swenn(x1, a1, b1, f);

    a = a1; b = b1;

    x_ = midpointMethod(a1, b1, f, eps);

    a1 = a; b1 = b;

    x_ = goldenSectionNum1(a1, b1, f, 20, eps);

}

void zadanie1(double (*f)(double), double x1, double eps){
    double a1, b1, a, b;
    double x_, fx_;
    printf("Zadanie number 1\n");
    printf("Perform student of group 5301 Nebotov D.S.\n\n");

    x_ = swenn(x1, a1, b1, f);

    a = a1; b = b1;

    x_ = goldenSectionNum1(a1, b1, f, 20, eps);

    a1 = a; b1 = b;

    x_ = methodPowellA2PI(a1, b1, f, eps, eps);

}