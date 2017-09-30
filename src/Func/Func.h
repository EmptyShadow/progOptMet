//
// Created by Дмитрий on 28.09.2017.
//

#ifndef PROGOPTMET_FUNC_H
#define PROGOPTMET_FUNC_H

#include "string"
#include "../Parameters/Vars/Vector.h"
#include "../Parser/MathParser.h"

class Func {
public:
    std::string func = ""; // функция

    Func(std::string func);

    /**
     * Функция запуска на исполнение
     * @return
     */
    virtual double y(Vector &params);
};


#endif //PROGOPTMET_FUNC_H
