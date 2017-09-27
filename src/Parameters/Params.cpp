#include "Params.h"

Params::Params() {}

Params::~Params() {}

void Params::writelnInErrs(std::string err) {
    errs += err;
}
void Params::writelnInLogs(std::string log) {
    logs += log;
}

std::string Params::toString(){
    std::string str;
    str += input.toString();
    str += output.toString();
    str += flags.toString();
    return str;
}

Params Params::clone() {
    Params params;
    params.input = input.clone();
    params.output = output.clone();
    params.flags = flags.clone();
    return params;
}