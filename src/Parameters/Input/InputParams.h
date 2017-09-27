//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_INPUTPARAMS_H
#define PROGOPTMET_INPUTPARAMS_H

#include "vector"
#include "stdio.h"
#include "string"

class InputParams {
public:
    InputParams();
    ~InputParams();

    int m = 0; // ограничение по количеству итераций
    double x1 = 0.0; // стартовая точка
    std::vector<double> intervalPoints = {}; // начальный интервал локализации
    double (*f)(double) = nullptr; // функция
    double eps_arg = 0.0; // погрешность по аргументам
    double eps_f = 0.0; // погрешнасть по значениям функции
    std::string toString();
    InputParams clone();
};


#endif //PROGOPTMET_INPUTPARAMS_H
