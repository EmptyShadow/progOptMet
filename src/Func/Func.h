//
// Created by Дмитрий on 28.09.2017.
//

#ifndef PROGOPTMET_FUNC_H
#define PROGOPTMET_FUNC_H

#include "string"
#include "../Parameters/Vars/Vector.h"
#include "../Parser/MathParser.h"
#include "set"
#include "exception"
#include "../String/String.h"

class Func {
public:
    std::string func = ""; // функция
    std::set<std::string> vars; // переменные

    Func(std::string func) throw(std::string);

    /**
     * Функция запуска на исполнение
     * @return
     */
    virtual double y(Vector &params) throw(std::string);

};

#endif //PROGOPTMET_FUNC_H
