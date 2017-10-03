#include "Func.h"
#include "../String/String.h"
#include "../Parameters/Vars/Vector.h"
#include "../Parser/MathParser.h"

Func::Func(std::string *func) throw(std::string*) {
    this->func = func->substr(0);
    setFunc(&(this->func));
}

Func::~Func() {}

void Func::setFunc(std::string *func) throw(std::string*) {
    std::string f = func->substr(0);
    String::removeAll(&f, ' ');
    if (!f.compare("")) {
        throw new std::string("Error: empty function;");
    }
    this->func = f;
    vars.clear();
    vars = *(MathParser::getSetVars(&f));
}

double Func::y(Vector *params) throw(std::string*) {
    MathParser parser(this, params);
    // вычисляю и возвращаю значение
    return parser.parse();
}

double Func::inRandomVector() throw(std::string*) {
    Vector v = *(Vector::random(vars.size(), 10));
    return y(&v);
}

Func *Func::clone() {
    std::string f = func.substr(0);
    Func *n = new Func(&f);
    return n;
}