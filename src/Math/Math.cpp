#include "Math.h"
#include "../Func/Func.h"
#include "../Parameters/Vars/Vector.h"

double Math::directionalDerivative(Func *f, Vector *x, Vector *p) {
    double eps = 1e-7;
    Vector x2 = std::move(*x) + std::move(*p) * eps;
    return (f->y(&x2) - f->y(x)) / eps;
}

double Math::gradient(Func *f, Vector *x, Vector *p) {
    double summ = 0.0;
    if (x->size() == p->size()) {
        // Берем частные производные по каждой переменной и умножаем на орту
        for (int i = 0; i < x->size(); ++i) {
            summ += partialDerivative(f, x, i) * (*p)[i];
        }
    }
    return summ;
}

double Math::partialDerivative(Func *f, Vector *x, int numVar) {
    double eps = 1e-7;
    Vector *e_i = Vector::getZeroBeside(x->size(), numVar);
    Vector x2 = *x + (*e_i) * eps;
    delete e_i;
    return (f->y(&x2) - f->y(std::move(x))) / eps;
}
