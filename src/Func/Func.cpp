#include "Func.h"

Func::Func(std::string func) {
    String::replaceAll(func, ' ', '');
    this->func = func;
    if (!func.compare("")) {
        throw "Error: empty function;";
    }
    this->vars = MathParser::getSetVars(func);

    Vector params = Vector::random(vars.size(), 10);
    y(params);
}

double Func::y(Vector &params) {
    if (vars.size() != params.size()) {
        throw "Error: Size vector != size variable function;";
    }
    MathParser parser((*this), params);
    // вычисляю и возвращаю значение
    return parser.parse();
}