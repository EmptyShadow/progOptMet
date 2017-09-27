//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_GOLDENSECTION2_H
#define PROGOPTMET_GOLDENSECTION2_H

#include "../GoldenNumbers.h"
#include "../../../Method.h"

/**
 * Метод золотого сечения основанный на свойстве семетрии
 */

class GoldenSection2: public GoldenNumbers, public Method {
public:
    GoldenSection2();
    ~GoldenSection2();

    virtual int run(Params &params);
};

#endif //PROGOPTMET_GOLDENSECTION2_H
