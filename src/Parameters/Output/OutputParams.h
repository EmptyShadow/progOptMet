//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_OUTPUTPARAMS_H
#define PROGOPTMET_OUTPUTPARAMS_H

#include "vector"
#include "stdio.h"
#include "string"

class OutputParams {
public:
    OutputParams();
    ~OutputParams();

    int k = 0; // количество пройденных итераций
    double x_ = 0.0; // аргумент, в котором функция принимает минимум на заданном интервале.
    double f_x_ = 0.0; // минимум функции
    std::vector<double> intervalPoints = {}; // точки интервала локализации

    std::string toString();
    OutputParams clone();
};


#endif //PROGOPTMET_OUTPUTPARAMS_H
