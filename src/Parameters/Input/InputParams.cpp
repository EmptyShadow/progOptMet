#include "InputParams.h"

#include "../Vars/Vector.h"
#include "../../Func/Func.h"

InputParams::InputParams() {}

InputParams::~InputParams() {
    delete x1;
    delete p;
    delete alfa;
    delete y;
}

std::string *InputParams::toString() {
    char number[15];
    std::string *str = new std::string("Input Parameters:\n");

    sprintf(number, "\tm: %d;\n", m);
    (*str) += number;

    sprintf(number, "\tx1: %s;\n", x1->toString()->c_str());
    (*str) += number;

    (*str) += "\tp:\n\t\t";
    (*str) += *(p->toString());

    (*str) += "\talfa:\n\t\t";
    (*str) += *(alfa->toString());

    sprintf(number, "\talfa_h: %0.10f;\n", alfa_h);
    (*str) += number;

    sprintf(number, "\teps_arg: %0.10f;\n", eps_arg);
    (*str) += number;

    sprintf(number, "\teps_f: %0.10f;\n", eps_f);
    (*str) += number;

    (*str) += "Function: " + y->func + ";\n";

    return str;
}

InputParams *InputParams::clone() {
    InputParams *input = new InputParams();
    input->m = m;
    input->x1 = x1 != nullptr ? x1->clone() : x1;
    input->p = p != nullptr ? p->clone() : p;
    input->alfa = alfa != nullptr ? alfa->clone() : alfa;
    input->alfa_h = alfa_h;
    input->eps_arg = eps_arg;
    input->eps_f = eps_f;
    input->y = y != nullptr ? y->clone() : y;

    return input;
}