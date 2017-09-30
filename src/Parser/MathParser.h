//
// Created by Дмитрий on 30.09.2017.
//

#ifndef PROGOPTMET_MATHPARSER_H
#define PROGOPTMET_MATHPARSER_H

#include "Result.h"
#include "../Func/Func.h"
#include "list"
#include "map"

class MathParser {
public:
    MathParser(Func &func, Vector &params) throw(std::string);

    /**
     * Начало вычисления функции
     * @param func
     * @return
     */
    double parse() throw(std::string);

    /**
     * Получение списка уникальных переменных в функции
     * @param func
     * @return
     */
    static std::list<std::string> getListVars(std::string func);

private:
    std::map<std::string, double> vars; // карта переменных и значений
    /**
     * Разбор сложения и вычитания
     * @param s
     * @return
     */
    static Result PlusMinus(std::string s) throw(std::string);

    /**
     * Разбор умножения и деления
     * @param s
     * @return
     */
    static Result MulDiv(std::string s) throw(std::string);

    /**
     * Разбор скобок
     * @param s
     * @return
     */
    static Result Braket(std::string s) throw(std::string);

    /**
     * Символ буква?
     * @param ch
     * @return
     */
    static bool isLetter(char ch) throw(std::string);

    /**
     * Символ число?
     * @param ch
     * @return
     */
    static bool isDigit(char ch) throw(std::string);

    /**
     * Разбор функции или переменной
     * @param s
     * @return
     */
    static Result FunctionVariable(std::string s) throw(std::string);
};


#endif //PROGOPTMET_MATHPARSER_H
