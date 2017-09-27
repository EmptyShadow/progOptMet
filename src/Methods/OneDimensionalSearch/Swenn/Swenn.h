//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_SWENN_H
#define PROGOPTMET_SWENN_H

#include "../../Method.h"
#include "string"

/**
* Метод Свенна, локализующий интервал поиска минимума унимодальной функции,
* в которой выполняются условия
* Если x1 < x2 < x*, то f1 > f2 > f*
* Если x* < x1 < x2, то f* < f1 < f2
*
* @param x1 - начальная точка
* @param &a1 - левый конец локализованого интервала
* @param &b1 - правый конец локализованого интервала
* @param f  - функция от одной переменной
* @return аппроксимированный минимум
*/
class Swenn : public Method {
public:
    Swenn();
    ~Swenn();

    virtual int run(Params &params);

    /**
    * Функция нормализации интервала
    * @param &a - левый конец локализованого интервала
    * @param &b - правый конец локализованого интервала
    */
    void intervalNormalization(double &a, double &b);
};


#endif //PROGOPTMET_SWENN_H
