#include "InputParams.h"

InputParams::InputParams() {}

InputParams::~InputParams() {}

std::string InputParams::toString() {
    char number[15];
    std::string str = "Input Parameters:\n";

    sprintf(number, "\tm: %d;\n", m);
    str += number;

    sprintf(number, "\tx1: %s;\n", x1.toString().c_str());
    str += number;

    str += "\tDirection:\n\t\t";
    str += direction.toString();

    str += "\tInterval staps local\n\t\t";
    str += intervalStapsLocal.toString();

    str += "\tInterval staps local\n";
    for (int i = 0; i < intervalLocal.size(); ++i) {
        sprintf(number, "\t\t%s\n", intervalLocal[i].toString().c_str());
        str += number;
    }

    sprintf(number, "\teps_arg: %0.10f;\n", eps_arg);
    str += number;

    sprintf(number, "\teps_f: %0.10f;\n", eps_f);
    str += number;

    return str;
}

InputParams InputParams::clone() {
    InputParams input;
    input.m = m;
    input.x1 = x1;
    input.direction = direction;
    input.intervalStapsLocal = intervalStapsLocal;
    input.intervalLocal = std::vector<Vector>(intervalLocal);
    input.eps_arg = eps_arg;
    input.eps_f = eps_f;

    input.f = f;

    return input;
}