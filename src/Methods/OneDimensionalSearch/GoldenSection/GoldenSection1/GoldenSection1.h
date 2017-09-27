//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_GOLDENSECTION1_H
#define PROGOPTMET_GOLDENSECTION1_H

#include "../GoldenNumbers.h"
#include "../../../Method.h"

/**
 * Метод золотого сечения
 */

class GoldenSection1: public GoldenNumbers, public Method {
public:
    GoldenSection1();
    ~GoldenSection1();

    virtual int run(Params &params);
};


#endif //PROGOPTMET_GOLDENSECTION1_H
