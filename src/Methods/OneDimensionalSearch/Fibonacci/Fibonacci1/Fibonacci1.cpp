#include "Fibonacci1.h"

Fibonacci1::Fibonacci1() {
    name = "Fibonacci 1";
}

Fibonacci1::~Fibonacci1() {}

int Fibonacci1::run(Params &params) {
    params.writelnInLogs("Start method Fibonacci 1\n");
    params.writelnInLogs(params.input.toString());
    if (params.input.intervalPoints.size() < 2) {
        params.writelnInErrs("Error: input interval minimization;\n");
        return 1;
    }

    double a1 = params.input.intervalPoints[0], b1 = params.input.intervalPoints[1], Ln = params.input.eps_arg;
    double (*f)(double) = params.input.f;
    int n;
    double Fn = getNextNumber(abs(a1 - b1) / Ln, n), Fnm = getNNumber(n - 1), Fnmm = Fn - Fnm, Fnp = Fn + Fnm;
    double delta = abs(b1 - a1) / Fnp;
    double x1 = a1 + abs(b1 - a1) * Fnmm / Fn,
            x2 = a1 + abs(b1 - a1) * Fnm / Fn,
            f1, f2;
    int k = 1;
    do {
        f1 = f(x1);
        f2 = f(x2);
        Fn = Fnm;
        Fnm = Fnmm;
        Fnmm = Fn - Fnm;
        if (f1 < f2) {
            b1 = x2;
            x2 = x1;
            x1 = a1 + abs(b1 - a1) * Fnmm / Fn;
        } else {
            a1 = x1;
            x1 = x2;
            x2 = a1 + abs(b1 - a1) * Fnm / Fn;
        }
        k++;
        if (params.flags.m) {
            if (k > params.input.m) {
                break;
            }
        }
        if (params.flags.eps_arg) {
            if (abs(b1 - a1) <= params.input.eps_arg) {
                break;
            }
        }
        if (params.flags.eps_f) {
            if (abs(f(b1) - f(a1)) <= params.input.eps_arg) {
                break;
            }
        }
    } while (k < (n - 1));
    x2 = x1 + delta;
    if (f(x1) < f(x2)) {
        b1 = x1;
    } else {
        a1 = x2;
    }
    double x_ = (a1 + b1) / 2.0;

    params.output.k = k;
    params.output.x_  = x_;
    params.output.f_x_ = f(x_);
    params.output.intervalPoints.clear();
    params.output.intervalPoints.push_back(a1);
    params.output.intervalPoints.push_back(b1);
    if (params.flags.hainComputing) {
        params.input.intervalPoints.clear();
        params.input.intervalPoints.push_back(a1);
        params.input.intervalPoints.push_back(b1);
        params.input.x1 = x_;
    }

    params.writelnInLogs(params.output.toString());
    params.writelnInLogs("End method Fibonacci 1\n\n");

    return 0;
}