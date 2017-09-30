//
// Created by Дмитрий on 28.09.2017.
//

#ifndef PROGOPTMET_FUNC_H
#define PROGOPTMET_FUNC_H

#include "string"
#include "../Parameters/Vars/Vector.h"
#include "../Parser/MathParser.h"
#include "list"
#include "exception"

class Func {
public:
    std::string func = ""; // функция
    std::list<std::string> vars; // переменные

    Func(std::string func) throw(std::string);

    /**
     * Функция запуска на исполнение
     * @return
     */
    virtual double y(Vector &params) throw(std::string);

    std::list<std::string> listVars;

};

#endif //PROGOPTMET_FUNC_H
