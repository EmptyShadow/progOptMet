//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_FIBONACCI1_H
#define PROGOPTMET_FIBONACCI1_H

#include "../FibonacciNumbers.h"
#include "../../../Method.h"

class Fibonacci1: public FibonacciNumbers, public Method {
public:
    Fibonacci1();
    ~Fibonacci1();

    virtual int run(Params &params);
};


#endif //PROGOPTMET_FIBONACCI1_H
