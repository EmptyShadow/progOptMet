#ifndef UNTITLED_LIBRARY_H
#define UNTITLED_LIBRARY_H

int swenn(double x1, double *a1, double *b1, double (*f)(double));
double dichotomy(double a1, double b1, double (*f)(double), double eps = 1e-7);
void intervalNormalization(double *a, double *b);

#endif