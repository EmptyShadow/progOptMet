#include <iostream>
#include "cmath"
#include "src/Methods/Composer/ComposerMethods.h"
#include "src/Core.h"

double f(double x);

Params createParams();

int main() {
    Core::load();
    std::list<std::string> list = Core::getNamesListMethodsOneDimSearch();
    Params p = createParams();
    for (std::string name: list) {
        Core::runMODS(name, p);
    }
    printf(p.logs.c_str());
    return 0;
}

double f(double x) {
    return 2 * x * x + 16.0 / x;
}

Params createParams() {
    Params p;

    p.input.m = 20;
    p.input.f = f;
    p.input.x1 = 1;
    p.input.eps_f = 1e-7;
    p.input.eps_arg = 1e-7;

    p.flags.hainComputing = 0;
    p.flags.eps_f = 0;
    p.flags.eps_arg = 1;
    p.flags.m = 0;

    return p;
}