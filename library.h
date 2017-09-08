#ifndef UNTITLED_LIBRARY_H
#define UNTITLED_LIBRARY_H

int swenn(double x1, double *a1, double *b1, double (*f)(double));
void intervalNormalization(double *a, double *b);

double dichotomy(double a1, double b1, double (*f)(double), double eps = 1e-7);

double goldenSectionNum1(double a1, double b1, double (*f)(double), double m = 20, double eps = 1e-7);
double lambdaGoldenSection(double a1, double b1);
double muGoldenSection(double a1, double b1);
double goldenSectionNum2(double a1, double b1, double (*f)(double), double m = 20, double eps = 1e-7);

#endif