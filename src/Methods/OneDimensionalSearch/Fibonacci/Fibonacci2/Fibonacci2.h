//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_FIBONACCI2_H
#define PROGOPTMET_FIBONACCI2_H

#include "../FibonacciNumbers.h"
#include "../../../Method.h"

class Fibonacci2: public FibonacciNumbers, public Method {
public:
    Fibonacci2();
    ~Fibonacci2();

    virtual int run(Params &params);
};


#endif //PROGOPTMET_FIBONACCI2_H
