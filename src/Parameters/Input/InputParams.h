//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_INPUTPARAMS_H
#define PROGOPTMET_INPUTPARAMS_H

#include "vector"
#include "stdio.h"
#include "string"
#include "../Vars/Vector.h"

class InputParams {
public:
    InputParams();
    ~InputParams();

    int m = 0; // ограничение по количеству итераций
    Vector x1; // стартовая точка
    Vector direction; // начальное направление
    Vector intervalStapsLocal; // интервал шага локализации
    std::vector<Vector> intervalLocal; // интервал локализации
    Vector (*f)(Vector) = nullptr; // функция
    double eps_arg = 0.0; // погрешность по аргументам
    double eps_f = 0.0; // погрешнасть по значениям функции
    std::string toString();
    InputParams clone();
};


#endif //PROGOPTMET_INPUTPARAMS_H
