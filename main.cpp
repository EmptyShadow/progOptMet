#include <iostream>
#include "cmath"
#include "library.h"

double f_lab1(double x);
double f_lab2(double x);

void lab1(double (*f)(double), double x1, double eps);
void lab2(double (*f)(double), double x1, double eps);
void zadanie1(double (*f)(double), double x1, double eps);

int main() {
    //lab1(f_lab1, 1, 1e-2);
    lab2(f_lab2, 2, 1e-2);
    //zadanie1(f_lab1, 1, 1e-2);
    return 0;
}

double f_lab1(double x) {
    return 2 * x * x + 16.0 / x;
}

double f_lab2(double x) {

    return pow(10.0 * pow(x, 3.0) + 3.0 * pow(x, 2.0) + x + 5.0, 2.0);
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

void lab2(double (*f)(double), double x1, double eps){
    double a1, b1;
    double x_, fx_;
    printf("Laboratory work number 2\n");
    printf("Perform student of group 5301 Nebotov D.S.\n\n");

    x_ = swenn(x1, a1, b1, f);
    x_ = methodSecants(a1, b1, f, eps);
    x_ = methodOfCubicInterpolation(x1, a1, b1, f, eps, 0.01 * x1);
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