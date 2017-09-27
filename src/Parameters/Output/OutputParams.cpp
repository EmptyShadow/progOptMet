#include "OutputParams.h"

OutputParams::OutputParams() {}

OutputParams::~OutputParams() {}

std::string OutputParams::toString() {
    char number[15];
    std::string rez = "Output Parameters:\n";
    sprintf(number, "%d", k);
    rez += "\tk: " + (std::string)number + ";\n";
    sprintf(number, "%0.10f", x_);
    rez += "\tx_: " + (std::string)number + ";\n";
    sprintf(number, "%0.10f", f_x_);
    rez += "\tf_x_: " + (std::string)number + ";\n";
    rez += "\tintervalPoints:";
    for (double val : intervalPoints) {
        sprintf(number, "%0.10f", val);
        rez += " " + (std::string)number;
    }
    rez += ";\n";

    return rez;
}

OutputParams OutputParams::clone() {
    OutputParams output;
    output.k = k;
    output.f_x_ = f_x_;
    output.x_ = x_;
    for (int i = 0; i < intervalPoints.size(); i++) {
        output.intervalPoints.push_back(intervalPoints[i]);
    }
}