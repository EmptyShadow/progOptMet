//
// Created by Дмитрий on 30.09.2017.
//

#ifndef PROGOPTMET_MATHPARSER_H
#define PROGOPTMET_MATHPARSER_H

#include "Result.h"
#include "../Func/Func.h"
#include "set"
#include "map"
#include "../String/String.h"
#include <regex>
#include "math.h"

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
    static std::set<std::string> getSetVars(std::string func);

private:
    std::map<std::string, double> vars; // карта переменных и значений
    std::string func;
    /**
     * Разбор сложения и вычитания
     * @param s
     * @return
     */
    Result PlusMinus(std::string s) throw(std::string);

    /**
     * Разбор умножения и деления
     * @param s
     * @return
     */
    Result MulDiv(std::string s) throw(std::string);

    /**
     * Разбор операции возведения в степень
     * @param s
     * @return
     */
    Result Degree(std::string s) throw(std::string);

    /**
     * Разбор скобок
     * @param s
     * @return
     */
    Result Bracket(std::string s) throw(std::string);

    /**
     * Символ буква?
     * @param ch
     * @return
     */
    static bool isLetter(char ch);

    /**
     * Символ число?
     * @param ch
     * @return
     */
    static bool isDigit(char ch);

    /**
     * Символ оператор?
     * @param ch
     * @return
     */
    static bool isOperator(char ch);

    /**
     * Разбор функции или переменной
     * @param s
     * @return
     */
    Result FunctionVariable(std::string s) throw(std::string);

    /**
     * Получение числа из строки
     * @param s
     * @return
     */
    static Result Num(std::string s) throw(std::string);

    /**
     * Получение значение по имени
     * @param varName
     * @return
     */
    double getVariable(std::string varName) throw(std::string);

    /**
     * Запуск на исполнение функции
     * @param func
     * @param r
     * @return
     */
    Result processFunction(std::string func, Result r);
};


#endif //PROGOPTMET_MATHPARSER_H
