//
// Created by Дмитрий on 25.09.2017.
//

#ifndef PROGOPTMET_DICHOTOMY_H
#define PROGOPTMET_DICHOTOMY_H

#include "../../Method.h"

class Dichotomy: public Method {
public:
    Dichotomy();
    ~Dichotomy();

    virtual int run(Params &params);
};


#endif //PROGOPTMET_DICHOTOMY_H
