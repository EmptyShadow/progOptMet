//
// Created by Дмитрий on 03.10.2017.
//

#ifndef PROGOPTMET_SWENN_H
#define PROGOPTMET_SWENN_H

#include "../MultiDimSearch.h"

class Swenn: public MultiDimSearch {
public:
    virtual int run(Params *p);
};


#endif //PROGOPTMET_SWENN_H
