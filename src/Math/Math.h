#ifndef PROGOPTMET_MATH_H
#define PROGOPTMET_MATH_H

#include "math.h"

class Vector;

class Func;

class Math {
public:
    /**
     * Производная по направлению в точке
     * @param f
     * @param x
     * @param p
     * @return
     */
    static double directionalDerivative(Func *f, Vector *x, Vector *p);

    /**
     * Градиент
     * @param f
     * @param x
     * @param p
     * @return
     */
    static double gradient(Func *f, Vector *x, Vector *p);

    /**
     * Частная производная от numVar переменной
     * @param f
     * @param x
     * @param numVar
     * @return
     */
    static double partialDerivative(Func *f, Vector *x, int numVar);
};


#endif //PROGOPTMET_MATH_H
