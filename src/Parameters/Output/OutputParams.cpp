#include "OutputParams.h"

OutputParams::OutputParams() {}

OutputParams::~OutputParams() {}

std::string OutputParams::toString() {
    char number[15];
    std::string rez = "Output Parameters:\n";

    sprintf(number, "\tk: %d;\n", k);
    rez += number;

    rez += "\tX_:\n\t\t";
    rez += x_.toString();

    rez += "\tInterval staps local\n\t\t";
    rez += intervalStapsLocal.toString();

    rez += "\tInterval staps local\n";
    for (int i = 0; i < intervalLocal.size(); ++i) {
        sprintf(number, "\t\t%s\n", intervalLocal[i].toString().c_str());
        rez += number;
    }

    sprintf(number, "\tf_x_: %d;\n", f_x_);
    rez += number;

    return rez;
}

OutputParams OutputParams::clone() {
    OutputParams output;
    output.k = k;
    output.f_x_ = f_x_;
    output.x_ = x_;
    output.intervalStapsLocal = intervalStapsLocal;
    output.intervalLocal = std::vector(intervalLocal);
    return output;
}