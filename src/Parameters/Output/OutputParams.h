//
// Created by Дмитрий on 24.09.2017.
//

#ifndef PROGOPTMET_OUTPUTPARAMS_H
#define PROGOPTMET_OUTPUTPARAMS_H

#include "string"

class Vector;

class OutputParams {
public:
    OutputParams();
    ~OutputParams();

    int k = 0; // количество пройденных итераций
    Vector *x_ = nullptr; // аргумент, в котором функция принимает минимум на заданном интервале.
    double f_x_; // минимум функции

    Vector *alfa = nullptr; // интервал приближения к минимуму
    double alfa_h = 0.01; //

    std::string *toString();
    OutputParams *clone();
};


#endif //PROGOPTMET_OUTPUTPARAMS_H
