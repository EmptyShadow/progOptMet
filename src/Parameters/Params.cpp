#include "Params.h"

Params::Params() {}

Params::~Params() {
    delete input;
    delete output;
    delete flags;
    delete errs;
    delete logs;
}

void Params::writelnInErrs(std::string *err) {
    (*errs) += (*err);
}
void Params::writelnInLogs(std::string *log) {
    (*logs) += (*log);
}

std::string *Params::toString(){
    std::string *str = new std::string();
    if (input != nullptr) {
        (*str) += (*(input->toString()));
    } else {
        (*str) += "Input parameters is't set!!!\n";
    }
    if (output != nullptr) {
        (*str) += (*(output->toString()));
    } else {
        (*str) += "Output parameters is't set!!!\n";
    }
    if (flags != nullptr) {
        (*str) += (*(flags->toString()));
    } else {
        (*str) += "Limiting flags parameters is't set!!!\n";
    }
    return str;
}

Params *Params::clone() {
    Params *params = new Params();
    if (input != nullptr) {
        params->input = input->clone();
    }
    if (output != nullptr) {
        params->output = output->clone();
    }
    if (flags != nullptr) {
        params->flags = flags->clone();
    }
    return params;
}