//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_OUTPUTPARAMS_H
#define PROGOPTMET_OUTPUTPARAMS_H

#include "vector"
#include "stdio.h"
#include "string"
#include "../Vars/Vector.h"

class OutputParams {
public:
    OutputParams();
    ~OutputParams();

    int k = 0; // количество пройденных итераций
    Vector x_; // аргумент, в котором функция принимает минимум на заданном интервале.
    double f_x_; // минимум функции

    Vector intervalStapsLocal; // интервал шага локализации
    std::vector<Vector> intervalLocal; // интервал локализации

    std::string toString();
    OutputParams clone();
};


#endif //PROGOPTMET_OUTPUTPARAMS_H
