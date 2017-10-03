//
// Created by Дмитрий on 28.09.2017.
//

#ifndef PROGOPTMET_FUNC_H
#define PROGOPTMET_FUNC_H

#include "string"
#include "set"

class Vector;

class Func {
public:
    std::string func = ""; // функция
    std::set<std::string> vars = {}; // переменные

    Func(std::string *func) throw(std::string*);

    ~Func();

    /**
     * Изменить функцию
     * @param func
     */
    void setFunc(std::string *func) throw(std::string*);

    /**
     * Вычислить функцию в случайной точке
     * @return
     */
    double inRandomVector() throw(std::string*);

    /**
     * Функция запуска на исполнение
     * @return
     */
    virtual double y(Vector *params) throw(std::string*);

    Func *clone();

};

#endif //PROGOPTMET_FUNC_H
