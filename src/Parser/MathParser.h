//
// Created by Дмитрий on 30.09.2017.
//

#ifndef PROGOPTMET_MATHPARSER_H
#define PROGOPTMET_MATHPARSER_H

#include "Result.h"
#include "../Func/Func.h"

class MathParser {
public:
    MathParser();

    static double parse(std::string func);

    static std::string insertParams(std::string &func, Vector &params);
};


#endif //PROGOPTMET_MATHPARSER_H
