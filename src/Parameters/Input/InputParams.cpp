#include "InputParams.h"

InputParams::InputParams() {}

InputParams::~InputParams() {}

std::string InputParams::toString() {
    char number[15];
    std::string str = "Input Parameters:\n";
    sprintf(number, "%d", m);
    str += "\tm: " + (std::string)number + ";\n";
    sprintf(number, "%0.10f", x1);
    str += "\tx1: " + (std::string)number + ";\n";
    sprintf(number, "%0.10f", eps_arg);
    str += "\teps_arg: " + (std::string)number + ";\n";
    sprintf(number, "%0.10f", eps_f);
    str += "\teps_f: " + (std::string)number + ";\n";
    str += "\tintervalPoints:";
    for (double val : intervalPoints) {
        sprintf(number, "%0.10f", val);
        str+= " " + (std::string)number;
    }
    str += ";\n";
    return str;
}

InputParams InputParams::clone() {
    InputParams input;
    input.m = m;
    input.eps_arg = eps_arg;
    input.eps_f = eps_f;
    input.x1 = x1;
    for (int i = 0; i < intervalPoints.size(); i++) {
        input.intervalPoints.push_back(intervalPoints[i]);
    }
    input.f = f;
}