#include "MultiDimSearch.h"

Vector *MultiDimSearch::x(Vector *x, double alfa, Vector *p) {
    Vector x2 = std::move(*x) + std::move(*p) * alfa;
    return x2.clone();
}