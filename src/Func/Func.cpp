#include "Func.h"

Func::Func(std::string func) {
    setFunc(func);
}

void Func::setFunc(std::string func) {
    String::replaceAll(func, ' ', '');
    if (!func.compare("")) {
        throw "Error: empty function;";
    }
    this->func = func;
    this->vars = MathParser::getSetVars(func);

    inRandomVector();
}

double Func::inRandomVector() {
    Vector params = Vector::random(vars.size(), 10);
    return y(params);
}

double Func::y(Vector &params) {
    if (vars.size() != params.size()) {
        throw "Error: Size vector != size variable function;";
    }
    MathParser parser((*this), params);
    // вычисляю и возвращаю значение
    return parser.parse();
}