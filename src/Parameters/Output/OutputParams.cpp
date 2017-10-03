#include "OutputParams.h"
#include "../Vars/Vector.h"

OutputParams::OutputParams() {}

OutputParams::~OutputParams() {
    delete x_;
    delete alfa;
}

std::string *OutputParams::toString() {
    char number[15];
    std::string *rez = new std::string("Output Parameters:\n");

    sprintf(number, "\tk: %d;\n", k);
    (*rez) += number;

    (*rez) += "\tx_:\n\t\t";
    (*rez) += *(x_->toString());

    sprintf(number, "\tf_x_: %0.10f;\n", f_x_);
    (*rez) += number;

    (*rez) += "\talfa:\n\t\t";
    (*rez) += *(alfa->toString());

    sprintf(number, "\talfa_h: %0.10f;\n", alfa_h);
    (*rez) += number;

    return rez;
}

OutputParams *OutputParams::clone() {
    OutputParams *output = new OutputParams();
    output->k = k;
    output->x_ = x_ != nullptr ? x_->clone() : x_;
    output->f_x_ = f_x_;
    output->alfa = alfa != nullptr ? alfa->clone() : alfa;
    output->alfa_h = alfa_h;
    return output;
}