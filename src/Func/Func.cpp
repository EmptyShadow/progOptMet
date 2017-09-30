#include "Func.h"

Func::Func(std::string func) {
    this->func = func;
}

double Func::y(Vector &params) {
    // подставляю вектор переменных в функцию
    std::string term = MathParser::insertParams(func, params);
    // вычисляю и возвращаю значение
    return MathParser::parse(term);
}